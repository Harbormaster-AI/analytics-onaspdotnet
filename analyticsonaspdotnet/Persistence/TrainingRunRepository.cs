
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class TrainingRunRepository : ITrainingRunRepository
{
    private readonly ApplicationDbContext _db;

    public TrainingRunRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<TrainingRun?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.TrainingRuns
            .Include(x => x.Experiment)
            .Include(x => x.ModelVersion)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<TrainingRun>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.TrainingRuns
            .AsNoTracking()
            .Include(x => x.Experiment)
            .Include(x => x.ModelVersion)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(TrainingRun trainingRun, CancellationToken cancellationToken)
    {
        _db.TrainingRuns.Add(trainingRun);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(TrainingRun trainingRun, CancellationToken cancellationToken)
    {
        _db.TrainingRuns.Update(trainingRun);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(TrainingRun trainingRun, CancellationToken cancellationToken)
    {
        _db.TrainingRuns.Remove(trainingRun);
        await _db.SaveChangesAsync(cancellationToken);
    }


    public async Task AddToInputDatasetsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.DataSets
            .Where(dataSet =>
                request.ChildIds.Contains(dataSet.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    dataSet =>
                        EF.Property<Guid?>(
                            dataSet,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromInputDatasetsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.DataSets
            .Where(dataSet =>
                request.ChildIds.Contains(dataSet.Id) &&
                EF.Property<Guid?>(
                    dataSet,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    dataSet =>
                        EF.Property<Guid?>(
                            dataSet,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToFeaturesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Features
            .Where(feature =>
                request.ChildIds.Contains(feature.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    feature =>
                        EF.Property<Guid?>(
                            feature,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromFeaturesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Features
            .Where(feature =>
                request.ChildIds.Contains(feature.Id) &&
                EF.Property<Guid?>(
                    feature,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    feature =>
                        EF.Property<Guid?>(
                            feature,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToRunMetricsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.RunMetrics
            .Where(runMetric =>
                request.ChildIds.Contains(runMetric.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    runMetric =>
                        EF.Property<Guid?>(
                            runMetric,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromRunMetricsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.RunMetrics
            .Where(runMetric =>
                request.ChildIds.Contains(runMetric.Id) &&
                EF.Property<Guid?>(
                    runMetric,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    runMetric =>
                        EF.Property<Guid?>(
                            runMetric,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToRunParametersAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.RunParameters
            .Where(runParameter =>
                request.ChildIds.Contains(runParameter.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    runParameter =>
                        EF.Property<Guid?>(
                            runParameter,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromRunParametersAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.RunParameters
            .Where(runParameter =>
                request.ChildIds.Contains(runParameter.Id) &&
                EF.Property<Guid?>(
                    runParameter,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    runParameter =>
                        EF.Property<Guid?>(
                            runParameter,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }

}

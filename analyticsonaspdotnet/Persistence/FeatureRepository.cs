
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class FeatureRepository : IFeatureRepository
{
    private readonly ApplicationDbContext _db;

    public FeatureRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Feature?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Features
            .Include(x => x.FeatureSet)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Feature>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Features
            .AsNoTracking()
            .Include(x => x.FeatureSet)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Feature feature, CancellationToken cancellationToken)
    {
        _db.Features.Add(feature);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Feature feature, CancellationToken cancellationToken)
    {
        _db.Features.Update(feature);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Feature feature, CancellationToken cancellationToken)
    {
        _db.Features.Remove(feature);
        await _db.SaveChangesAsync(cancellationToken);
    }


    public async Task AddToSourceDatasetsAsync(
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

    public async Task RemoveFromSourceDatasetsAsync(
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


    public async Task AddToModelsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Model_s
            .Where(model_ =>
                request.ChildIds.Contains(model_.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    model_ =>
                        EF.Property<Guid?>(
                            model_,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromModelsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Model_s
            .Where(model_ =>
                request.ChildIds.Contains(model_.Id) &&
                EF.Property<Guid?>(
                    model_,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    model_ =>
                        EF.Property<Guid?>(
                            model_,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToTrainingRunsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.TrainingRuns
            .Where(trainingRun =>
                request.ChildIds.Contains(trainingRun.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    trainingRun =>
                        EF.Property<Guid?>(
                            trainingRun,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromTrainingRunsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.TrainingRuns
            .Where(trainingRun =>
                request.ChildIds.Contains(trainingRun.Id) &&
                EF.Property<Guid?>(
                    trainingRun,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    trainingRun =>
                        EF.Property<Guid?>(
                            trainingRun,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }

}

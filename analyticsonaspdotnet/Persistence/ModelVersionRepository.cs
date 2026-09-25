
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class ModelVersionRepository : IModelVersionRepository
{
    private readonly ApplicationDbContext _db;

    public ModelVersionRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<ModelVersion?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.ModelVersions
            .Include(x => x.Model_)
            .Include(x => x.TrainingRun)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<ModelVersion>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.ModelVersions
            .AsNoTracking()
            .Include(x => x.Model_)
            .Include(x => x.TrainingRun)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(ModelVersion modelVersion, CancellationToken cancellationToken)
    {
        _db.ModelVersions.Add(modelVersion);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(ModelVersion modelVersion, CancellationToken cancellationToken)
    {
        _db.ModelVersions.Update(modelVersion);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(ModelVersion modelVersion, CancellationToken cancellationToken)
    {
        _db.ModelVersions.Remove(modelVersion);
        await _db.SaveChangesAsync(cancellationToken);
    }


    public async Task AddToEvaluationMetricsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.EvaluationMetrics
            .Where(evaluationMetric =>
                request.ChildIds.Contains(evaluationMetric.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    evaluationMetric =>
                        EF.Property<Guid?>(
                            evaluationMetric,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromEvaluationMetricsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.EvaluationMetrics
            .Where(evaluationMetric =>
                request.ChildIds.Contains(evaluationMetric.Id) &&
                EF.Property<Guid?>(
                    evaluationMetric,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    evaluationMetric =>
                        EF.Property<Guid?>(
                            evaluationMetric,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToDeploymentsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.InferenceEndpoints
            .Where(inferenceEndpoint =>
                request.ChildIds.Contains(inferenceEndpoint.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    inferenceEndpoint =>
                        EF.Property<Guid?>(
                            inferenceEndpoint,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromDeploymentsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.InferenceEndpoints
            .Where(inferenceEndpoint =>
                request.ChildIds.Contains(inferenceEndpoint.Id) &&
                EF.Property<Guid?>(
                    inferenceEndpoint,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    inferenceEndpoint =>
                        EF.Property<Guid?>(
                            inferenceEndpoint,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToFeatureSetsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.FeatureSets
            .Where(featureSet =>
                request.ChildIds.Contains(featureSet.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    featureSet =>
                        EF.Property<Guid?>(
                            featureSet,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromFeatureSetsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.FeatureSets
            .Where(featureSet =>
                request.ChildIds.Contains(featureSet.Id) &&
                EF.Property<Guid?>(
                    featureSet,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    featureSet =>
                        EF.Property<Guid?>(
                            featureSet,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToDatasetsAsync(
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

    public async Task RemoveFromDatasetsAsync(
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

}

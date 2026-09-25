
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class TagRepository : ITagRepository
{
    private readonly ApplicationDbContext _db;

    public TagRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Tag?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Tags
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Tag>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Tags
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Tag tag, CancellationToken cancellationToken)
    {
        _db.Tags.Add(tag);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Tag tag, CancellationToken cancellationToken)
    {
        _db.Tags.Update(tag);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Tag tag, CancellationToken cancellationToken)
    {
        _db.Tags.Remove(tag);
        await _db.SaveChangesAsync(cancellationToken);
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


    public async Task AddToModelVersionsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.ModelVersions
            .Where(modelVersion =>
                request.ChildIds.Contains(modelVersion.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    modelVersion =>
                        EF.Property<Guid?>(
                            modelVersion,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromModelVersionsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.ModelVersions
            .Where(modelVersion =>
                request.ChildIds.Contains(modelVersion.Id) &&
                EF.Property<Guid?>(
                    modelVersion,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    modelVersion =>
                        EF.Property<Guid?>(
                            modelVersion,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToDashboardsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Dashboards
            .Where(dashboard =>
                request.ChildIds.Contains(dashboard.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    dashboard =>
                        EF.Property<Guid?>(
                            dashboard,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromDashboardsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Dashboards
            .Where(dashboard =>
                request.ChildIds.Contains(dashboard.Id) &&
                EF.Property<Guid?>(
                    dashboard,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    dashboard =>
                        EF.Property<Guid?>(
                            dashboard,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToReportsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Reports
            .Where(report =>
                request.ChildIds.Contains(report.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    report =>
                        EF.Property<Guid?>(
                            report,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromReportsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Reports
            .Where(report =>
                request.ChildIds.Contains(report.Id) &&
                EF.Property<Guid?>(
                    report,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    report =>
                        EF.Property<Guid?>(
                            report,
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


    public async Task AddToMetricsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Metrics
            .Where(metric =>
                request.ChildIds.Contains(metric.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    metric =>
                        EF.Property<Guid?>(
                            metric,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromMetricsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Metrics
            .Where(metric =>
                request.ChildIds.Contains(metric.Id) &&
                EF.Property<Guid?>(
                    metric,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    metric =>
                        EF.Property<Guid?>(
                            metric,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }

}


using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class AccessPolicyRepository : IAccessPolicyRepository
{
    private readonly ApplicationDbContext _db;

    public AccessPolicyRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<AccessPolicy?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.AccessPolicys
            .Include(x => x.Workspace)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<AccessPolicy>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.AccessPolicys
            .AsNoTracking()
            .Include(x => x.Workspace)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(AccessPolicy accessPolicy, CancellationToken cancellationToken)
    {
        _db.AccessPolicys.Add(accessPolicy);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(AccessPolicy accessPolicy, CancellationToken cancellationToken)
    {
        _db.AccessPolicys.Update(accessPolicy);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(AccessPolicy accessPolicy, CancellationToken cancellationToken)
    {
        _db.AccessPolicys.Remove(accessPolicy);
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

}

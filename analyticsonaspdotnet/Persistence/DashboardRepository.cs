
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class DashboardRepository : IDashboardRepository
{
    private readonly ApplicationDbContext _db;

    public DashboardRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Dashboard?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Dashboards
            .Include(x => x.Workspace)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Dashboard>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Dashboards
            .AsNoTracking()
            .Include(x => x.Workspace)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Dashboard dashboard, CancellationToken cancellationToken)
    {
        _db.Dashboards.Add(dashboard);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Dashboard dashboard, CancellationToken cancellationToken)
    {
        _db.Dashboards.Update(dashboard);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Dashboard dashboard, CancellationToken cancellationToken)
    {
        _db.Dashboards.Remove(dashboard);
        await _db.SaveChangesAsync(cancellationToken);
    }


    public async Task AddToVisualizationsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Visualizations
            .Where(visualization =>
                request.ChildIds.Contains(visualization.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    visualization =>
                        EF.Property<Guid?>(
                            visualization,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromVisualizationsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Visualizations
            .Where(visualization =>
                request.ChildIds.Contains(visualization.Id) &&
                EF.Property<Guid?>(
                    visualization,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    visualization =>
                        EF.Property<Guid?>(
                            visualization,
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


    public async Task AddToAlertsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Alerts
            .Where(alert =>
                request.ChildIds.Contains(alert.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    alert =>
                        EF.Property<Guid?>(
                            alert,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromAlertsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Alerts
            .Where(alert =>
                request.ChildIds.Contains(alert.Id) &&
                EF.Property<Guid?>(
                    alert,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    alert =>
                        EF.Property<Guid?>(
                            alert,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToQueriesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.BIQuerys
            .Where(bIQuery =>
                request.ChildIds.Contains(bIQuery.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    bIQuery =>
                        EF.Property<Guid?>(
                            bIQuery,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromQueriesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.BIQuerys
            .Where(bIQuery =>
                request.ChildIds.Contains(bIQuery.Id) &&
                EF.Property<Guid?>(
                    bIQuery,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    bIQuery =>
                        EF.Property<Guid?>(
                            bIQuery,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToTagsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Tags
            .Where(tag =>
                request.ChildIds.Contains(tag.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    tag =>
                        EF.Property<Guid?>(
                            tag,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromTagsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Tags
            .Where(tag =>
                request.ChildIds.Contains(tag.Id) &&
                EF.Property<Guid?>(
                    tag,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    tag =>
                        EF.Property<Guid?>(
                            tag,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }

}


using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class BIQueryRepository : IBIQueryRepository
{
    private readonly ApplicationDbContext _db;

    public BIQueryRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<BIQuery?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.BIQuerys
            .Include(x => x.Workspace)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<BIQuery>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.BIQuerys
            .AsNoTracking()
            .Include(x => x.Workspace)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(BIQuery bIQuery, CancellationToken cancellationToken)
    {
        _db.BIQuerys.Add(bIQuery);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(BIQuery bIQuery, CancellationToken cancellationToken)
    {
        _db.BIQuerys.Update(bIQuery);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(BIQuery bIQuery, CancellationToken cancellationToken)
    {
        _db.BIQuerys.Remove(bIQuery);
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


    public async Task AddToNotebooksAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Notebooks
            .Where(notebook =>
                request.ChildIds.Contains(notebook.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    notebook =>
                        EF.Property<Guid?>(
                            notebook,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromNotebooksAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Notebooks
            .Where(notebook =>
                request.ChildIds.Contains(notebook.Id) &&
                EF.Property<Guid?>(
                    notebook,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    notebook =>
                        EF.Property<Guid?>(
                            notebook,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }

}

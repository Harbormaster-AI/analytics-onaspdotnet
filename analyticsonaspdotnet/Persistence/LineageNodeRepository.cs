
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class LineageNodeRepository : ILineageNodeRepository
{
    private readonly ApplicationDbContext _db;

    public LineageNodeRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<LineageNode?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.LineageNodes
            .Include(x => x.Workspace)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<LineageNode>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.LineageNodes
            .AsNoTracking()
            .Include(x => x.Workspace)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(LineageNode lineageNode, CancellationToken cancellationToken)
    {
        _db.LineageNodes.Add(lineageNode);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(LineageNode lineageNode, CancellationToken cancellationToken)
    {
        _db.LineageNodes.Update(lineageNode);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(LineageNode lineageNode, CancellationToken cancellationToken)
    {
        _db.LineageNodes.Remove(lineageNode);
        await _db.SaveChangesAsync(cancellationToken);
    }


    public async Task AddToInputsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.LineageNodes
            .Where(lineageNode =>
                request.ChildIds.Contains(lineageNode.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    lineageNode =>
                        EF.Property<Guid?>(
                            lineageNode,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromInputsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.LineageNodes
            .Where(lineageNode =>
                request.ChildIds.Contains(lineageNode.Id) &&
                EF.Property<Guid?>(
                    lineageNode,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    lineageNode =>
                        EF.Property<Guid?>(
                            lineageNode,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToOutputsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.LineageNodes
            .Where(lineageNode =>
                request.ChildIds.Contains(lineageNode.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    lineageNode =>
                        EF.Property<Guid?>(
                            lineageNode,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromOutputsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.LineageNodes
            .Where(lineageNode =>
                request.ChildIds.Contains(lineageNode.Id) &&
                EF.Property<Guid?>(
                    lineageNode,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    lineageNode =>
                        EF.Property<Guid?>(
                            lineageNode,
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


    public async Task AddToPipelinesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.DataPipelines
            .Where(dataPipeline =>
                request.ChildIds.Contains(dataPipeline.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    dataPipeline =>
                        EF.Property<Guid?>(
                            dataPipeline,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromPipelinesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.DataPipelines
            .Where(dataPipeline =>
                request.ChildIds.Contains(dataPipeline.Id) &&
                EF.Property<Guid?>(
                    dataPipeline,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    dataPipeline =>
                        EF.Property<Guid?>(
                            dataPipeline,
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

}


using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class AnalyticsWorkspaceRepository : IAnalyticsWorkspaceRepository
{
    private readonly ApplicationDbContext _db;

    public AnalyticsWorkspaceRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<AnalyticsWorkspace?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.AnalyticsWorkspaces
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<AnalyticsWorkspace>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.AnalyticsWorkspaces
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(AnalyticsWorkspace analyticsWorkspace, CancellationToken cancellationToken)
    {
        _db.AnalyticsWorkspaces.Add(analyticsWorkspace);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(AnalyticsWorkspace analyticsWorkspace, CancellationToken cancellationToken)
    {
        _db.AnalyticsWorkspaces.Update(analyticsWorkspace);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(AnalyticsWorkspace analyticsWorkspace, CancellationToken cancellationToken)
    {
        _db.AnalyticsWorkspaces.Remove(analyticsWorkspace);
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


    public async Task AddToDataSourcesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.DataSources
            .Where(dataSource =>
                request.ChildIds.Contains(dataSource.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    dataSource =>
                        EF.Property<Guid?>(
                            dataSource,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromDataSourcesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.DataSources
            .Where(dataSource =>
                request.ChildIds.Contains(dataSource.Id) &&
                EF.Property<Guid?>(
                    dataSource,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    dataSource =>
                        EF.Property<Guid?>(
                            dataSource,
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


    public async Task AddToPoliciesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.AccessPolicys
            .Where(accessPolicy =>
                request.ChildIds.Contains(accessPolicy.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    accessPolicy =>
                        EF.Property<Guid?>(
                            accessPolicy,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromPoliciesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.AccessPolicys
            .Where(accessPolicy =>
                request.ChildIds.Contains(accessPolicy.Id) &&
                EF.Property<Guid?>(
                    accessPolicy,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    accessPolicy =>
                        EF.Property<Guid?>(
                            accessPolicy,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToLineageNodesAsync(
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

    public async Task RemoveFromLineageNodesAsync(
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

}

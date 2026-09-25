
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class ReportRepository : IReportRepository
{
    private readonly ApplicationDbContext _db;

    public ReportRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Report?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Reports
            .Include(x => x.Workspace)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Report>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Reports
            .AsNoTracking()
            .Include(x => x.Workspace)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Report report, CancellationToken cancellationToken)
    {
        _db.Reports.Add(report);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Report report, CancellationToken cancellationToken)
    {
        _db.Reports.Update(report);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Report report, CancellationToken cancellationToken)
    {
        _db.Reports.Remove(report);
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


    public async Task AddToSemanticModelsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.SemanticModels
            .Where(semanticModel =>
                request.ChildIds.Contains(semanticModel.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    semanticModel =>
                        EF.Property<Guid?>(
                            semanticModel,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromSemanticModelsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.SemanticModels
            .Where(semanticModel =>
                request.ChildIds.Contains(semanticModel.Id) &&
                EF.Property<Guid?>(
                    semanticModel,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    semanticModel =>
                        EF.Property<Guid?>(
                            semanticModel,
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

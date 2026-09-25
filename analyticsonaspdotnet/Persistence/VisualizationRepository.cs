
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class VisualizationRepository : IVisualizationRepository
{
    private readonly ApplicationDbContext _db;

    public VisualizationRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Visualization?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Visualizations
            .Include(x => x.Dashboard)
            .Include(x => x.Report)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Visualization>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Visualizations
            .AsNoTracking()
            .Include(x => x.Dashboard)
            .Include(x => x.Report)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Visualization visualization, CancellationToken cancellationToken)
    {
        _db.Visualizations.Add(visualization);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Visualization visualization, CancellationToken cancellationToken)
    {
        _db.Visualizations.Update(visualization);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Visualization visualization, CancellationToken cancellationToken)
    {
        _db.Visualizations.Remove(visualization);
        await _db.SaveChangesAsync(cancellationToken);
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


    public async Task AddToDimensionsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Dimensions
            .Where(dimension =>
                request.ChildIds.Contains(dimension.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    dimension =>
                        EF.Property<Guid?>(
                            dimension,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromDimensionsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Dimensions
            .Where(dimension =>
                request.ChildIds.Contains(dimension.Id) &&
                EF.Property<Guid?>(
                    dimension,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    dimension =>
                        EF.Property<Guid?>(
                            dimension,
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

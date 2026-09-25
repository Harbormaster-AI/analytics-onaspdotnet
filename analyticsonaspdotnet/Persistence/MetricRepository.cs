
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class MetricRepository : IMetricRepository
{
    private readonly ApplicationDbContext _db;

    public MetricRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Metric?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Metrics
            .Include(x => x.SemanticModel)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Metric>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Metrics
            .AsNoTracking()
            .Include(x => x.SemanticModel)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Metric metric, CancellationToken cancellationToken)
    {
        _db.Metrics.Add(metric);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Metric metric, CancellationToken cancellationToken)
    {
        _db.Metrics.Update(metric);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Metric metric, CancellationToken cancellationToken)
    {
        _db.Metrics.Remove(metric);
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


    public async Task AddToGlossaryTermsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.BusinessGlossaryTerms
            .Where(businessGlossaryTerm =>
                request.ChildIds.Contains(businessGlossaryTerm.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    businessGlossaryTerm =>
                        EF.Property<Guid?>(
                            businessGlossaryTerm,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromGlossaryTermsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.BusinessGlossaryTerms
            .Where(businessGlossaryTerm =>
                request.ChildIds.Contains(businessGlossaryTerm.Id) &&
                EF.Property<Guid?>(
                    businessGlossaryTerm,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    businessGlossaryTerm =>
                        EF.Property<Guid?>(
                            businessGlossaryTerm,
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

}

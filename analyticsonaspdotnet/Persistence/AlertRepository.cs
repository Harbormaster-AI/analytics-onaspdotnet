
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class AlertRepository : IAlertRepository
{
    private readonly ApplicationDbContext _db;

    public AlertRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Alert?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Alerts
            .Include(x => x.Metric)
            .Include(x => x.Dashboard)
            .Include(x => x.Dataset)
            .Include(x => x.Rule)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Alert>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Alerts
            .AsNoTracking()
            .Include(x => x.Metric)
            .Include(x => x.Dashboard)
            .Include(x => x.Dataset)
            .Include(x => x.Rule)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Alert alert, CancellationToken cancellationToken)
    {
        _db.Alerts.Add(alert);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Alert alert, CancellationToken cancellationToken)
    {
        _db.Alerts.Update(alert);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Alert alert, CancellationToken cancellationToken)
    {
        _db.Alerts.Remove(alert);
        await _db.SaveChangesAsync(cancellationToken);
    }


    public async Task AddToAnomaliesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Anomalys
            .Where(anomaly =>
                request.ChildIds.Contains(anomaly.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    anomaly =>
                        EF.Property<Guid?>(
                            anomaly,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromAnomaliesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Anomalys
            .Where(anomaly =>
                request.ChildIds.Contains(anomaly.Id) &&
                EF.Property<Guid?>(
                    anomaly,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    anomaly =>
                        EF.Property<Guid?>(
                            anomaly,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToSubscribersAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Subscribers
            .Where(subscriber =>
                request.ChildIds.Contains(subscriber.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    subscriber =>
                        EF.Property<Guid?>(
                            subscriber,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromSubscribersAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Subscribers
            .Where(subscriber =>
                request.ChildIds.Contains(subscriber.Id) &&
                EF.Property<Guid?>(
                    subscriber,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    subscriber =>
                        EF.Property<Guid?>(
                            subscriber,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }

}

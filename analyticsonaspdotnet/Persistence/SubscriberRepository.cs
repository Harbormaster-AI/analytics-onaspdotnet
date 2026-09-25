
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class SubscriberRepository : ISubscriberRepository
{
    private readonly ApplicationDbContext _db;

    public SubscriberRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Subscriber?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Subscribers
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Subscriber>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Subscribers
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Subscriber subscriber, CancellationToken cancellationToken)
    {
        _db.Subscribers.Add(subscriber);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Subscriber subscriber, CancellationToken cancellationToken)
    {
        _db.Subscribers.Update(subscriber);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Subscriber subscriber, CancellationToken cancellationToken)
    {
        _db.Subscribers.Remove(subscriber);
        await _db.SaveChangesAsync(cancellationToken);
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

}

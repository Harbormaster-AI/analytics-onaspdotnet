using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface ISubscriberRepository
{
    Task<Subscriber?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Subscriber>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Subscriber subscriber, CancellationToken cancellationToken);
    Task UpdateAsync(Subscriber subscriber, CancellationToken cancellationToken);
    Task DeleteAsync(Subscriber subscriber, CancellationToken cancellationToken);

    Task AddToAlertsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromAlertsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

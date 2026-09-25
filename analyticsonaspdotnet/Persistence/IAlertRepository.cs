using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface IAlertRepository
{
    Task<Alert?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Alert>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Alert alert, CancellationToken cancellationToken);
    Task UpdateAsync(Alert alert, CancellationToken cancellationToken);
    Task DeleteAsync(Alert alert, CancellationToken cancellationToken);

    Task AddToAnomaliesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromAnomaliesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToSubscribersAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromSubscribersAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

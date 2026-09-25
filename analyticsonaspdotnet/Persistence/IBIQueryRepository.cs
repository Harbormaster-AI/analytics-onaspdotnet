using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface IBIQueryRepository
{
    Task<BIQuery?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<BIQuery>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(BIQuery bIQuery, CancellationToken cancellationToken);
    Task UpdateAsync(BIQuery bIQuery, CancellationToken cancellationToken);
    Task DeleteAsync(BIQuery bIQuery, CancellationToken cancellationToken);

    Task AddToDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToReportsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromReportsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToDashboardsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDashboardsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToNotebooksAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromNotebooksAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

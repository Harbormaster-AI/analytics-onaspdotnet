using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface IDashboardRepository
{
    Task<Dashboard?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Dashboard>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Dashboard dashboard, CancellationToken cancellationToken);
    Task UpdateAsync(Dashboard dashboard, CancellationToken cancellationToken);
    Task DeleteAsync(Dashboard dashboard, CancellationToken cancellationToken);

    Task AddToVisualizationsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromVisualizationsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToReportsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromReportsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToAlertsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromAlertsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToQueriesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromQueriesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToTagsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromTagsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface IAnalyticsWorkspaceRepository
{
    Task<AnalyticsWorkspace?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<AnalyticsWorkspace>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(AnalyticsWorkspace analyticsWorkspace, CancellationToken cancellationToken);
    Task UpdateAsync(AnalyticsWorkspace analyticsWorkspace, CancellationToken cancellationToken);
    Task DeleteAsync(AnalyticsWorkspace analyticsWorkspace, CancellationToken cancellationToken);

    Task AddToDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToDataSourcesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDataSourcesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToPipelinesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromPipelinesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToDashboardsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDashboardsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToReportsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromReportsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToNotebooksAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromNotebooksAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToModelsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromModelsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToFeatureSetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromFeatureSetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToPoliciesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromPoliciesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToLineageNodesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromLineageNodesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

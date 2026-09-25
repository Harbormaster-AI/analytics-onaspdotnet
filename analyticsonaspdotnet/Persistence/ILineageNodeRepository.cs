using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface ILineageNodeRepository
{
    Task<LineageNode?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<LineageNode>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(LineageNode lineageNode, CancellationToken cancellationToken);
    Task UpdateAsync(LineageNode lineageNode, CancellationToken cancellationToken);
    Task DeleteAsync(LineageNode lineageNode, CancellationToken cancellationToken);

    Task AddToInputsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromInputsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToOutputsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromOutputsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToModelsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromModelsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToPipelinesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromPipelinesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToDashboardsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDashboardsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToReportsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromReportsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

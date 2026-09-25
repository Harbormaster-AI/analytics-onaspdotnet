using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface IAccessPolicyRepository
{
    Task<AccessPolicy?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<AccessPolicy>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(AccessPolicy accessPolicy, CancellationToken cancellationToken);
    Task UpdateAsync(AccessPolicy accessPolicy, CancellationToken cancellationToken);
    Task DeleteAsync(AccessPolicy accessPolicy, CancellationToken cancellationToken);

    Task AddToDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToDashboardsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDashboardsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToReportsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromReportsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToModelsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromModelsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToFeatureSetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromFeatureSetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

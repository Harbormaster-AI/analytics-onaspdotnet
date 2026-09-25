using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface ITagRepository
{
    Task<Tag?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Tag>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Tag tag, CancellationToken cancellationToken);
    Task UpdateAsync(Tag tag, CancellationToken cancellationToken);
    Task DeleteAsync(Tag tag, CancellationToken cancellationToken);

    Task AddToDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToModelsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromModelsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToModelVersionsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromModelVersionsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToDashboardsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDashboardsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToReportsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromReportsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToFeatureSetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromFeatureSetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToMetricsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromMetricsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface IModel_Repository
{
    Task<Model_?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Model_>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Model_ model_, CancellationToken cancellationToken);
    Task UpdateAsync(Model_ model_, CancellationToken cancellationToken);
    Task DeleteAsync(Model_ model_, CancellationToken cancellationToken);

    Task AddToVersionsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromVersionsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToFeatureSetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromFeatureSetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToExperimentsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromExperimentsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToTagsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromTagsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

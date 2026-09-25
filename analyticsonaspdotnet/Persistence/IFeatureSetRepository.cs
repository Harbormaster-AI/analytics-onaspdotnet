using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface IFeatureSetRepository
{
    Task<FeatureSet?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<FeatureSet>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(FeatureSet featureSet, CancellationToken cancellationToken);
    Task UpdateAsync(FeatureSet featureSet, CancellationToken cancellationToken);
    Task DeleteAsync(FeatureSet featureSet, CancellationToken cancellationToken);

    Task AddToFeaturesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromFeaturesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToModelsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromModelsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToModelVersionsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromModelVersionsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToTagsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromTagsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

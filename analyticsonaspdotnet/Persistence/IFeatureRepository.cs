using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface IFeatureRepository
{
    Task<Feature?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Feature>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Feature feature, CancellationToken cancellationToken);
    Task UpdateAsync(Feature feature, CancellationToken cancellationToken);
    Task DeleteAsync(Feature feature, CancellationToken cancellationToken);

    Task AddToSourceDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromSourceDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToModelsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromModelsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToTrainingRunsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromTrainingRunsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

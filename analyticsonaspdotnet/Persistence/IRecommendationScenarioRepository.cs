using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface IRecommendationScenarioRepository
{
    Task<RecommendationScenario?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<RecommendationScenario>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(RecommendationScenario recommendationScenario, CancellationToken cancellationToken);
    Task UpdateAsync(RecommendationScenario recommendationScenario, CancellationToken cancellationToken);
    Task DeleteAsync(RecommendationScenario recommendationScenario, CancellationToken cancellationToken);

    Task AddToModelsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromModelsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToExperimentsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromExperimentsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToAlertsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromAlertsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

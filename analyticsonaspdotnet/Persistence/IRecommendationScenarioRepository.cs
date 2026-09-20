using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IRecommendationScenarioRepository
{
    Task<RecommendationScenario?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<RecommendationScenario>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(RecommendationScenario recommendationScenario, CancellationToken cancellationToken);
    Task UpdateAsync(RecommendationScenario recommendationScenario, CancellationToken cancellationToken);
    Task DeleteAsync(RecommendationScenario recommendationScenario, CancellationToken cancellationToken);
}

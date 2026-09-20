using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IFraudScenarioRepository
{
    Task<FraudScenario?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<FraudScenario>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(FraudScenario fraudScenario, CancellationToken cancellationToken);
    Task UpdateAsync(FraudScenario fraudScenario, CancellationToken cancellationToken);
    Task DeleteAsync(FraudScenario fraudScenario, CancellationToken cancellationToken);
}

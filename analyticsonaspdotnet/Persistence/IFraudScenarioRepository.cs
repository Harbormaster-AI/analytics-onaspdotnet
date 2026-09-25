using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface IFraudScenarioRepository
{
    Task<FraudScenario?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<FraudScenario>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(FraudScenario fraudScenario, CancellationToken cancellationToken);
    Task UpdateAsync(FraudScenario fraudScenario, CancellationToken cancellationToken);
    Task DeleteAsync(FraudScenario fraudScenario, CancellationToken cancellationToken);

    Task AddToModelsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromModelsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToAlertsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromAlertsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToSignalsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromSignalsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

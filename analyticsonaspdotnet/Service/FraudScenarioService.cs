using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface IFraudScenarioService {

    Task Create(FraudScenario model , CancellationToken cancellationToken);
    Task<bool> Update(FraudScenario model, CancellationToken cancellationToken);
    Task<FraudScenario?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<FraudScenario>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------

    Task<bool> AddToModels(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromModels(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToAlerts(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromAlerts(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToSignals(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromSignals(MultipleAssociationRequest request, CancellationToken cancellationToken);

}

public class FraudScenarioService : IFraudScenarioService
{
    private readonly IFraudScenarioRepository _repository;
    private readonly ILogger<FraudScenarioService> _logger;

    public FraudScenarioService(
        IFraudScenarioRepository repository, ILogger<FraudScenarioService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(FraudScenario model, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.AddAsync(model, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
        }
    }

    public async Task<bool> Update(FraudScenario model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.Name = model.Name;
            existing.RiskAppetite = model.RiskAppetite;
            existing.DetectionType = model.DetectionType;

            await _repository.UpdateAsync(existing, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
            return false;
        }
        return true;
    }

    public Task<FraudScenario?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<FraudScenario>> GetAll(CancellationToken cancellationToken)
    => _repository.GetAllAsync(cancellationToken);

    public async Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken)
    {
        var existing = await _repository.GetByIdAsync(identifier.Id, cancellationToken);
        if (existing is null)
        {
            return false;
        }

        try
        {
            await _repository.DeleteAsync(existing, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
            return false;
        }
        return true;

    }


    public async Task<bool> AddToModels(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromModels(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToAlerts(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromAlerts(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToSignals(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromSignals(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }



}

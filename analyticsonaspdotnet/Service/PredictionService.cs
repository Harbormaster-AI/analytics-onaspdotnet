using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface IPredictionService {

    Task Create(Prediction model , CancellationToken cancellationToken);
    Task<bool> Update(Prediction model, CancellationToken cancellationToken);
    Task<Prediction?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<Prediction>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------
    Task<bool> AssignEndpoint(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignEndpoint(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AssignModelVersion(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignModelVersion(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AssignDataset(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignDataset(AssociationRequest request, CancellationToken cancellationToken);


}

public class PredictionService : IPredictionService
{
    private readonly IPredictionRepository _repository;
    private readonly ILogger<PredictionService> _logger;

    public PredictionService(
        IPredictionRepository repository, ILogger<PredictionService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(Prediction model, CancellationToken cancellationToken)
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

    public async Task<bool> Update(Prediction model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.ReferenceKey = model.ReferenceKey;
            existing.PredictedAt = model.PredictedAt;
            existing.Score = model.Score;

            await _repository.UpdateAsync(existing, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
            return false;
        }
        return true;
    }

    public Task<Prediction?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<Prediction>> GetAll(CancellationToken cancellationToken)
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

    public async Task<bool> AssignEndpoint(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignEndpoint(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AssignModelVersion(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignModelVersion(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AssignDataset(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignDataset(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }




}

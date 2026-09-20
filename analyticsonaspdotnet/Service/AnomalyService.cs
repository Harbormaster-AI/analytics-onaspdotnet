using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface IAnomalyService {

    Task Create(Anomaly model , CancellationToken cancellationToken);
    Task<bool> Update(Anomaly model, CancellationToken cancellationToken);
    Task<Anomaly?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<Anomaly>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------
    Task<bool> AssignTimeSeries(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignTimeSeries(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AssignAlert(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignAlert(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AssignDataset(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignDataset(AssociationRequest request, CancellationToken cancellationToken);


}

public class AnomalyService : IAnomalyService
{
    private readonly IAnomalyRepository _repository;
    private readonly ILogger<AnomalyService> _logger;

    public AnomalyService(
        IAnomalyRepository repository, ILogger<AnomalyService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(Anomaly model, CancellationToken cancellationToken)
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

    public async Task<bool> Update(Anomaly model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.OccurredAt = model.OccurredAt;
            existing.Details = model.Details;
            existing.AnomalyType = model.AnomalyType;
            existing.Severity = model.Severity;

            await _repository.UpdateAsync(existing, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
            return false;
        }
        return true;
    }

    public Task<Anomaly?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<Anomaly>> GetAll(CancellationToken cancellationToken)
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

    public async Task<bool> AssignTimeSeries(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignTimeSeries(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AssignAlert(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignAlert(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AssignDataset(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignDataset(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }




}

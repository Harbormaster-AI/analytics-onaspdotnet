using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface IAlertService {

    Task Create(Alert model , CancellationToken cancellationToken);
    Task<bool> Update(Alert model, CancellationToken cancellationToken);
    Task<Alert?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<Alert>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------
    Task<bool> AssignMetric(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignMetric(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AssignDashboard(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignDashboard(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AssignDataset(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignDataset(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AssignRule(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignRule(AssociationRequest request, CancellationToken cancellationToken);

    Task<bool> AddToAnomalies(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromAnomalies(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToSubscribers(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromSubscribers(MultipleAssociationRequest request, CancellationToken cancellationToken);

}

public class AlertService : IAlertService
{
    private readonly IAlertRepository _repository;
    private readonly ILogger<AlertService> _logger;

    public AlertService(
        IAlertRepository repository, ILogger<AlertService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(Alert model, CancellationToken cancellationToken)
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

    public async Task<bool> Update(Alert model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.Title = model.Title;
            existing.CreatedAt = model.CreatedAt;
            existing.Severity = model.Severity;
            existing.Status = model.Status;

            await _repository.UpdateAsync(existing, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
            return false;
        }
        return true;
    }

    public Task<Alert?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<Alert>> GetAll(CancellationToken cancellationToken)
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

    public async Task<bool> AssignMetric(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignMetric(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AssignDashboard(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignDashboard(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AssignDataset(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignDataset(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AssignRule(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignRule(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }


    public async Task<bool> AddToAnomalies(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromAnomalies(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToSubscribers(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromSubscribers(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }



}

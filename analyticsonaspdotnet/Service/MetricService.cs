using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface IMetricService {

    Task Create(Metric model , CancellationToken cancellationToken);
    Task<bool> Update(Metric model, CancellationToken cancellationToken);
    Task<Metric?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<Metric>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------
    Task<bool> AssignSemanticModel(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignSemanticModel(AssociationRequest request, CancellationToken cancellationToken);

    Task<bool> AddToDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToGlossaryTerms(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromGlossaryTerms(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToAlerts(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromAlerts(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToVisualizations(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromVisualizations(MultipleAssociationRequest request, CancellationToken cancellationToken);

}

public class MetricService : IMetricService
{
    private readonly IMetricRepository _repository;
    private readonly ILogger<MetricService> _logger;

    public MetricService(
        IMetricRepository repository, ILogger<MetricService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(Metric model, CancellationToken cancellationToken)
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

    public async Task<bool> Update(Metric model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.Name = model.Name;
            existing.Expression = model.Expression;
            existing.Unit = model.Unit;
            existing.MetricType = model.MetricType;

            await _repository.UpdateAsync(existing, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
            return false;
        }
        return true;
    }

    public Task<Metric?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<Metric>> GetAll(CancellationToken cancellationToken)
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

    public async Task<bool> AssignSemanticModel(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignSemanticModel(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }


    public async Task<bool> AddToDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToGlossaryTerms(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromGlossaryTerms(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToAlerts(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromAlerts(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToVisualizations(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromVisualizations(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }



}

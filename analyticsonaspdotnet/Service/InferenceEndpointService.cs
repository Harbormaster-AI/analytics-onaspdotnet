using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface IInferenceEndpointService {

    Task Create(InferenceEndpoint model , CancellationToken cancellationToken);
    Task<bool> Update(InferenceEndpoint model, CancellationToken cancellationToken);
    Task<InferenceEndpoint?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<InferenceEndpoint>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------
    Task<bool> AssignModelVersion(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignModelVersion(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AssignWorkspace(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignWorkspace(AssociationRequest request, CancellationToken cancellationToken);

    Task<bool> AddToPredictions(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromPredictions(MultipleAssociationRequest request, CancellationToken cancellationToken);

}

public class InferenceEndpointService : IInferenceEndpointService
{
    private readonly IInferenceEndpointRepository _repository;
    private readonly ILogger<InferenceEndpointService> _logger;

    public InferenceEndpointService(
        IInferenceEndpointRepository repository, ILogger<InferenceEndpointService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(InferenceEndpoint model, CancellationToken cancellationToken)
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

    public async Task<bool> Update(InferenceEndpoint model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.Name = model.Name;
            existing.EndpointUrl = model.EndpointUrl;
            existing.TrafficShare = model.TrafficShare;
            existing.Mode = model.Mode;

            await _repository.UpdateAsync(existing, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
            return false;
        }
        return true;
    }

    public Task<InferenceEndpoint?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<InferenceEndpoint>> GetAll(CancellationToken cancellationToken)
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

    public async Task<bool> AssignModelVersion(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignModelVersion(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AssignWorkspace(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignWorkspace(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }


    public async Task<bool> AddToPredictions(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromPredictions(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }



}

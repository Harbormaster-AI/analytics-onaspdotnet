using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface ISemanticModelService {

    Task Create(SemanticModel model , CancellationToken cancellationToken);
    Task<bool> Update(SemanticModel model, CancellationToken cancellationToken);
    Task<SemanticModel?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<SemanticModel>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------

    Task<bool> AddToDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToDimensions(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromDimensions(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToMeasures(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromMeasures(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToGlossaryTerms(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromGlossaryTerms(MultipleAssociationRequest request, CancellationToken cancellationToken);

}

public class SemanticModelService : ISemanticModelService
{
    private readonly ISemanticModelRepository _repository;
    private readonly ILogger<SemanticModelService> _logger;

    public SemanticModelService(
        ISemanticModelRepository repository, ILogger<SemanticModelService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(SemanticModel model, CancellationToken cancellationToken)
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

    public async Task<bool> Update(SemanticModel model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.Name = model.Name;
            existing.Version = model.Version;
            existing.Grain = model.Grain;

            await _repository.UpdateAsync(existing, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
            return false;
        }
        return true;
    }

    public Task<SemanticModel?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<SemanticModel>> GetAll(CancellationToken cancellationToken)
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


    public async Task<bool> AddToDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToDimensions(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromDimensions(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToMeasures(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromMeasures(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToGlossaryTerms(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromGlossaryTerms(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }



}

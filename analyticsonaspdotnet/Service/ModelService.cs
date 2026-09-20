using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface IModelService {

    Task Create(Model model , CancellationToken cancellationToken);
    Task<bool> Update(Model model, CancellationToken cancellationToken);
    Task<Model?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<Model>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------
    Task<bool> AssignWorkspace(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignWorkspace(AssociationRequest request, CancellationToken cancellationToken);

    Task<bool> AddToVersions(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromVersions(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToFeatureSets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromFeatureSets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToExperiments(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromExperiments(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToTags(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromTags(MultipleAssociationRequest request, CancellationToken cancellationToken);

}

public class ModelService : IModelService
{
    private readonly IModelRepository _repository;
    private readonly ILogger<ModelService> _logger;

    public ModelService(
        IModelRepository repository, ILogger<ModelService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(Model model, CancellationToken cancellationToken)
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

    public async Task<bool> Update(Model model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.Name = model.Name;
            existing.TaskDescription = model.TaskDescription;
            existing.ModelType = model.ModelType;

            await _repository.UpdateAsync(existing, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
            return false;
        }
        return true;
    }

    public Task<Model?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<Model>> GetAll(CancellationToken cancellationToken)
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

    public async Task<bool> AssignWorkspace(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignWorkspace(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }


    public async Task<bool> AddToVersions(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromVersions(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToFeatureSets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromFeatureSets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToExperiments(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromExperiments(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToTags(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromTags(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }



}

using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface IFeatureSetService {

    Task Create(FeatureSet model , CancellationToken cancellationToken);
    Task<bool> Update(FeatureSet model, CancellationToken cancellationToken);
    Task<FeatureSet?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<FeatureSet>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------
    Task<bool> AssignWorkspace(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignWorkspace(AssociationRequest request, CancellationToken cancellationToken);

    Task<bool> AddToFeatures(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromFeatures(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToModels(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromModels(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToModelVersions(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromModelVersions(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToTags(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromTags(MultipleAssociationRequest request, CancellationToken cancellationToken);

}

public class FeatureSetService : IFeatureSetService
{
    private readonly IFeatureSetRepository _repository;
    private readonly ILogger<FeatureSetService> _logger;

    public FeatureSetService(
        IFeatureSetRepository repository, ILogger<FeatureSetService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(FeatureSet model, CancellationToken cancellationToken)
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

    public async Task<bool> Update(FeatureSet model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.Name = model.Name;
            existing.RefreshSchedule = model.RefreshSchedule;
            existing.StoreType = model.StoreType;

            await _repository.UpdateAsync(existing, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
            return false;
        }
        return true;
    }

    public Task<FeatureSet?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<FeatureSet>> GetAll(CancellationToken cancellationToken)
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


    public async Task<bool> AddToFeatures(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromFeatures(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToModels(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromModels(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToModelVersions(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromModelVersions(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToTags(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromTags(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }



}

using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface IFeatureService {

    Task Create(Feature model , CancellationToken cancellationToken);
    Task<bool> Update(Feature model, CancellationToken cancellationToken);
    Task<Feature?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<Feature>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------
    Task<bool> AssignFeatureSet(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignFeatureSet(AssociationRequest request, CancellationToken cancellationToken);

    Task<bool> AddToSourceDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromSourceDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToModels(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromModels(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToTrainingRuns(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromTrainingRuns(MultipleAssociationRequest request, CancellationToken cancellationToken);

}

public class FeatureService : IFeatureService
{
    private readonly IFeatureRepository _repository;
    private readonly ILogger<FeatureService> _logger;

    public FeatureService(
        IFeatureRepository repository, ILogger<FeatureService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(Feature model, CancellationToken cancellationToken)
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

    public async Task<bool> Update(Feature model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.Name = model.Name;
            existing.Description = model.Description;
            existing.DataType = model.DataType;

            await _repository.UpdateAsync(existing, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
            return false;
        }
        return true;
    }

    public Task<Feature?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<Feature>> GetAll(CancellationToken cancellationToken)
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

    public async Task<bool> AssignFeatureSet(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignFeatureSet(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }


    public async Task<bool> AddToSourceDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromSourceDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToModels(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromModels(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToTrainingRuns(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromTrainingRuns(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }



}

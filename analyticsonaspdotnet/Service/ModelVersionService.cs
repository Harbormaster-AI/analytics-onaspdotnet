using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface IModelVersionService {

    Task Create(ModelVersion model , CancellationToken cancellationToken);
    Task<bool> Update(ModelVersion model, CancellationToken cancellationToken);
    Task<ModelVersion?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<ModelVersion>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------
    Task<bool> AssignModel(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignModel(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AssignTrainingRun(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignTrainingRun(AssociationRequest request, CancellationToken cancellationToken);

    Task<bool> AddToEvaluationMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromEvaluationMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToDeployments(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromDeployments(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToFeatureSets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromFeatureSets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);

}

public class ModelVersionService : IModelVersionService
{
    private readonly IModelVersionRepository _repository;
    private readonly ILogger<ModelVersionService> _logger;

    public ModelVersionService(
        IModelVersionRepository repository, ILogger<ModelVersionService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(ModelVersion model, CancellationToken cancellationToken)
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

    public async Task<bool> Update(ModelVersion model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.Version = model.Version;
            existing.Lifecycle = model.Lifecycle;
            existing.TrainingStatus = model.TrainingStatus;

            await _repository.UpdateAsync(existing, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
            return false;
        }
        return true;
    }

    public Task<ModelVersion?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<ModelVersion>> GetAll(CancellationToken cancellationToken)
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

    public async Task<bool> AssignModel(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignModel(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AssignTrainingRun(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignTrainingRun(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }


    public async Task<bool> AddToEvaluationMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromEvaluationMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToDeployments(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromDeployments(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToFeatureSets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromFeatureSets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }



}

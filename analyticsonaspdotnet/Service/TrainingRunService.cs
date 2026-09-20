using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface ITrainingRunService {

    Task Create(TrainingRun model , CancellationToken cancellationToken);
    Task<bool> Update(TrainingRun model, CancellationToken cancellationToken);
    Task<TrainingRun?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<TrainingRun>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------
    Task<bool> AssignExperiment(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignExperiment(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AssignModelVersion(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignModelVersion(AssociationRequest request, CancellationToken cancellationToken);

    Task<bool> AddToInputDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromInputDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToFeatures(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromFeatures(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToRunMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromRunMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToRunParameters(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromRunParameters(MultipleAssociationRequest request, CancellationToken cancellationToken);

}

public class TrainingRunService : ITrainingRunService
{
    private readonly ITrainingRunRepository _repository;
    private readonly ILogger<TrainingRunService> _logger;

    public TrainingRunService(
        ITrainingRunRepository repository, ILogger<TrainingRunService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(TrainingRun model, CancellationToken cancellationToken)
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

    public async Task<bool> Update(TrainingRun model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.RunLabel = model.RunLabel;
            existing.StartedAt = model.StartedAt;
            existing.CompletedAt = model.CompletedAt;
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

    public Task<TrainingRun?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<TrainingRun>> GetAll(CancellationToken cancellationToken)
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

    public async Task<bool> AssignExperiment(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignExperiment(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AssignModelVersion(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignModelVersion(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }


    public async Task<bool> AddToInputDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromInputDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToFeatures(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromFeatures(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToRunMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromRunMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToRunParameters(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromRunParameters(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }



}

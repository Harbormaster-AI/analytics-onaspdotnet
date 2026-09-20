using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface IDataPipelineService {

    Task Create(DataPipeline model , CancellationToken cancellationToken);
    Task<bool> Update(DataPipeline model, CancellationToken cancellationToken);
    Task<DataPipeline?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<DataPipeline>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------
    Task<bool> AssignWorkspace(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignWorkspace(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AssignLineageNode(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignLineageNode(AssociationRequest request, CancellationToken cancellationToken);

    Task<bool> AddToTasks(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromTasks(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToSources(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromSources(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToOutputs(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromOutputs(MultipleAssociationRequest request, CancellationToken cancellationToken);

}

public class DataPipelineService : IDataPipelineService
{
    private readonly IDataPipelineRepository _repository;
    private readonly ILogger<DataPipelineService> _logger;

    public DataPipelineService(
        IDataPipelineRepository repository, ILogger<DataPipelineService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(DataPipeline model, CancellationToken cancellationToken)
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

    public async Task<bool> Update(DataPipeline model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.Name = model.Name;
            existing.Schedule = model.Schedule;
            existing.TriggerType = model.TriggerType;
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

    public Task<DataPipeline?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<DataPipeline>> GetAll(CancellationToken cancellationToken)
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

    public async Task<bool> AssignLineageNode(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignLineageNode(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }


    public async Task<bool> AddToTasks(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromTasks(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToSources(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromSources(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToOutputs(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromOutputs(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }



}

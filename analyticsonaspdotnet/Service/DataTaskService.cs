using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface IDataTaskService {

    Task Create(DataTask model , CancellationToken cancellationToken);
    Task<bool> Update(DataTask model, CancellationToken cancellationToken);
    Task<DataTask?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<DataTask>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------
    Task<bool> AssignPipeline(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignPipeline(AssociationRequest request, CancellationToken cancellationToken);

    Task<bool> AddToInputDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromInputDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToOutputDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromOutputDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);

}

public class DataTaskService : IDataTaskService
{
    private readonly IDataTaskRepository _repository;
    private readonly ILogger<DataTaskService> _logger;

    public DataTaskService(
        IDataTaskRepository repository, ILogger<DataTaskService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(DataTask model, CancellationToken cancellationToken)
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

    public async Task<bool> Update(DataTask model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.Name = model.Name;
            existing.Command = model.Command;
            existing.Retries = model.Retries;
            existing.TaskType = model.TaskType;

            await _repository.UpdateAsync(existing, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
            return false;
        }
        return true;
    }

    public Task<DataTask?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<DataTask>> GetAll(CancellationToken cancellationToken)
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

    public async Task<bool> AssignPipeline(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignPipeline(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }


    public async Task<bool> AddToInputDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromInputDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToOutputDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromOutputDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }



}

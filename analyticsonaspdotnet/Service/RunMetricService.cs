using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface IRunMetricService {

    Task Create(RunMetric model , CancellationToken cancellationToken);
    Task<bool> Update(RunMetric model, CancellationToken cancellationToken);
    Task<RunMetric?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<RunMetric>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------
    Task<bool> AssignTrainingRun(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignTrainingRun(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AssignMetric(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignMetric(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AssignDataset(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignDataset(AssociationRequest request, CancellationToken cancellationToken);


}

public class RunMetricService : IRunMetricService
{
    private readonly IRunMetricRepository _repository;
    private readonly ILogger<RunMetricService> _logger;

    public RunMetricService(
        IRunMetricRepository repository, ILogger<RunMetricService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(RunMetric model, CancellationToken cancellationToken)
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

    public async Task<bool> Update(RunMetric model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.Name = model.Name;
            existing.Value = model.Value;

            await _repository.UpdateAsync(existing, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
            return false;
        }
        return true;
    }

    public Task<RunMetric?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<RunMetric>> GetAll(CancellationToken cancellationToken)
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

    public async Task<bool> AssignTrainingRun(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignTrainingRun(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AssignMetric(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignMetric(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AssignDataset(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignDataset(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }




}

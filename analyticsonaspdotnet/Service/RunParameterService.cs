using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface IRunParameterService {

    Task Create(RunParameter model , CancellationToken cancellationToken);
    Task<bool> Update(RunParameter model, CancellationToken cancellationToken);
    Task<RunParameter?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<RunParameter>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------
    Task<bool> AssignTrainingRun(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignTrainingRun(AssociationRequest request, CancellationToken cancellationToken);


}

public class RunParameterService : IRunParameterService
{
    private readonly IRunParameterRepository _repository;
    private readonly ILogger<RunParameterService> _logger;

    public RunParameterService(
        IRunParameterRepository repository, ILogger<RunParameterService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(RunParameter model, CancellationToken cancellationToken)
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

    public async Task<bool> Update(RunParameter model, CancellationToken cancellationToken)
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

    public Task<RunParameter?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<RunParameter>> GetAll(CancellationToken cancellationToken)
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




}

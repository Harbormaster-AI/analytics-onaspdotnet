using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface IQualityCheckService {

    Task Create(QualityCheck model , CancellationToken cancellationToken);
    Task<bool> Update(QualityCheck model, CancellationToken cancellationToken);
    Task<QualityCheck?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<QualityCheck>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------
    Task<bool> AssignRule(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignRule(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AssignDataset(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignDataset(AssociationRequest request, CancellationToken cancellationToken);


}

public class QualityCheckService : IQualityCheckService
{
    private readonly IQualityCheckRepository _repository;
    private readonly ILogger<QualityCheckService> _logger;

    public QualityCheckService(
        IQualityCheckRepository repository, ILogger<QualityCheckService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(QualityCheck model, CancellationToken cancellationToken)
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

    public async Task<bool> Update(QualityCheck model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.CheckedAt = model.CheckedAt;
            existing.ObservedValue = model.ObservedValue;
            existing.SampleSize = model.SampleSize;
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

    public Task<QualityCheck?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<QualityCheck>> GetAll(CancellationToken cancellationToken)
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

    public async Task<bool> AssignRule(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignRule(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AssignDataset(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> UnassignDataset(AssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }




}

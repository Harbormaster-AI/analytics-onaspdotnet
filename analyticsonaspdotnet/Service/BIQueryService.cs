using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface IBIQueryService {

    Task Create(BIQuery model , CancellationToken cancellationToken);
    Task<bool> Update(BIQuery model, CancellationToken cancellationToken);
    Task<BIQuery?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<BIQuery>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------
    Task<bool> AssignWorkspace(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignWorkspace(AssociationRequest request, CancellationToken cancellationToken);

    Task<bool> AddToDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToReports(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromReports(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToDashboards(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromDashboards(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToNotebooks(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromNotebooks(MultipleAssociationRequest request, CancellationToken cancellationToken);

}

public class BIQueryService : IBIQueryService
{
    private readonly IBIQueryRepository _repository;
    private readonly ILogger<BIQueryService> _logger;

    public BIQueryService(
        IBIQueryRepository repository, ILogger<BIQueryService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(BIQuery model, CancellationToken cancellationToken)
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

    public async Task<bool> Update(BIQuery model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.Name = model.Name;
            existing.Text = model.Text;
            existing.Dialect = model.Dialect;

            await _repository.UpdateAsync(existing, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
            return false;
        }
        return true;
    }

    public Task<BIQuery?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<BIQuery>> GetAll(CancellationToken cancellationToken)
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


    public async Task<bool> AddToDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToReports(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromReports(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToDashboards(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromDashboards(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToNotebooks(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromNotebooks(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }



}

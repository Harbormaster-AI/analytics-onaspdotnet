using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface IAccessPolicyService {

    Task Create(AccessPolicy model , CancellationToken cancellationToken);
    Task<bool> Update(AccessPolicy model, CancellationToken cancellationToken);
    Task<AccessPolicy?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<AccessPolicy>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------
    Task<bool> AssignWorkspace(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignWorkspace(AssociationRequest request, CancellationToken cancellationToken);

    Task<bool> AddToDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToDashboards(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromDashboards(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToReports(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromReports(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToModels(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromModels(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToFeatureSets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromFeatureSets(MultipleAssociationRequest request, CancellationToken cancellationToken);

}

public class AccessPolicyService : IAccessPolicyService
{
    private readonly IAccessPolicyRepository _repository;
    private readonly ILogger<AccessPolicyService> _logger;

    public AccessPolicyService(
        IAccessPolicyRepository repository, ILogger<AccessPolicyService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(AccessPolicy model, CancellationToken cancellationToken)
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

    public async Task<bool> Update(AccessPolicy model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.Name = model.Name;
            existing.SubjectName = model.SubjectName;
            existing.AccessLevel = model.AccessLevel;
            existing.SubjectType = model.SubjectType;

            await _repository.UpdateAsync(existing, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
            return false;
        }
        return true;
    }

    public Task<AccessPolicy?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<AccessPolicy>> GetAll(CancellationToken cancellationToken)
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

    public async Task<bool> AddToDashboards(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromDashboards(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToReports(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromReports(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToModels(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromModels(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToFeatureSets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromFeatureSets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }



}

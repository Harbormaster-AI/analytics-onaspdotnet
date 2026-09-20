using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface IAnalyticsWorkspaceService {

    Task Create(AnalyticsWorkspace model , CancellationToken cancellationToken);
    Task<bool> Update(AnalyticsWorkspace model, CancellationToken cancellationToken);
    Task<AnalyticsWorkspace?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<AnalyticsWorkspace>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------

    Task<bool> AddToDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToDataSources(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromDataSources(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToPipelines(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromPipelines(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToDashboards(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromDashboards(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToReports(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromReports(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToNotebooks(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromNotebooks(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToModels(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromModels(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToFeatureSets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromFeatureSets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToPolicies(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromPolicies(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToLineageNodes(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromLineageNodes(MultipleAssociationRequest request, CancellationToken cancellationToken);

}

public class AnalyticsWorkspaceService : IAnalyticsWorkspaceService
{
    private readonly IAnalyticsWorkspaceRepository _repository;
    private readonly ILogger<AnalyticsWorkspaceService> _logger;

    public AnalyticsWorkspaceService(
        IAnalyticsWorkspaceRepository repository, ILogger<AnalyticsWorkspaceService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(AnalyticsWorkspace model, CancellationToken cancellationToken)
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

    public async Task<bool> Update(AnalyticsWorkspace model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.Name = model.Name;
            existing.BusinessDomain = model.BusinessDomain;
            existing.OwnerTeam = model.OwnerTeam;
            existing.GovernanceTier = model.GovernanceTier;

            await _repository.UpdateAsync(existing, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
            return false;
        }
        return true;
    }

    public Task<AnalyticsWorkspace?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<AnalyticsWorkspace>> GetAll(CancellationToken cancellationToken)
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


    public async Task<bool> AddToDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToDataSources(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromDataSources(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToPipelines(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromPipelines(MultipleAssociationRequest request, CancellationToken cancellationToken) {
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

    public async Task<bool> AddToNotebooks(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromNotebooks(MultipleAssociationRequest request, CancellationToken cancellationToken) {
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

    public async Task<bool> AddToPolicies(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromPolicies(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToLineageNodes(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromLineageNodes(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }



}

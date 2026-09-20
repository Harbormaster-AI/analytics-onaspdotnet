using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface IDataSetService {

    Task Create(DataSet model , CancellationToken cancellationToken);
    Task<bool> Update(DataSet model, CancellationToken cancellationToken);
    Task<DataSet?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<DataSet>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------
    Task<bool> AssignWorkspace(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignWorkspace(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AssignLineageNode(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignLineageNode(AssociationRequest request, CancellationToken cancellationToken);

    Task<bool> AddToSources(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromSources(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToPipelines(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromPipelines(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToSemanticModels(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromSemanticModels(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToDimensions(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromDimensions(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToMeasures(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromMeasures(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToQualityRules(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromQualityRules(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToTags(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromTags(MultipleAssociationRequest request, CancellationToken cancellationToken);

}

public class DataSetService : IDataSetService
{
    private readonly IDataSetRepository _repository;
    private readonly ILogger<DataSetService> _logger;

    public DataSetService(
        IDataSetRepository repository, ILogger<DataSetService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(DataSet model, CancellationToken cancellationToken)
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

    public async Task<bool> Update(DataSet model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.Name = model.Name;
            existing.SchemaVersion = model.SchemaVersion;
            existing.RefreshSchedule = model.RefreshSchedule;
            existing.Sensitive = model.Sensitive;
            existing.DataFormat = model.DataFormat;

            await _repository.UpdateAsync(existing, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
            return false;
        }
        return true;
    }

    public Task<DataSet?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<DataSet>> GetAll(CancellationToken cancellationToken)
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


    public async Task<bool> AddToSources(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromSources(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToPipelines(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromPipelines(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToSemanticModels(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromSemanticModels(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToDimensions(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromDimensions(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToMeasures(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromMeasures(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToQualityRules(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromQualityRules(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToTags(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromTags(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }



}

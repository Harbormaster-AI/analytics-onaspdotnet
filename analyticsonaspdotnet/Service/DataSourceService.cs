using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface IDataSourceService {

    Task Create(DataSource model , CancellationToken cancellationToken);
    Task<bool> Update(DataSource model, CancellationToken cancellationToken);
    Task<DataSource?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<DataSource>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------
    Task<bool> AssignWorkspace(AssociationRequest request, CancellationToken cancellationToken);
    Task<bool> UnassignWorkspace(AssociationRequest request, CancellationToken cancellationToken);

    Task<bool> AddToProducedDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromProducedDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToPipelines(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromPipelines(MultipleAssociationRequest request, CancellationToken cancellationToken);

}

public class DataSourceService : IDataSourceService
{
    private readonly IDataSourceRepository _repository;
    private readonly ILogger<DataSourceService> _logger;

    public DataSourceService(
        IDataSourceRepository repository, ILogger<DataSourceService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(DataSource model, CancellationToken cancellationToken)
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

    public async Task<bool> Update(DataSource model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.Name = model.Name;
            existing.Connection = model.Connection;
            existing.Streaming = model.Streaming;
            existing.SourceType = model.SourceType;
            existing.Format = model.Format;

            await _repository.UpdateAsync(existing, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
            return false;
        }
        return true;
    }

    public Task<DataSource?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<DataSource>> GetAll(CancellationToken cancellationToken)
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


    public async Task<bool> AddToProducedDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromProducedDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToPipelines(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromPipelines(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }



}

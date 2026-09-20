using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface ITimeSeriesService {

    Task Create(TimeSeries model , CancellationToken cancellationToken);
    Task<bool> Update(TimeSeries model, CancellationToken cancellationToken);
    Task<TimeSeries?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<TimeSeries>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------

    Task<bool> AddToDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToForecasts(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromForecasts(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToAnomalies(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromAnomalies(MultipleAssociationRequest request, CancellationToken cancellationToken);

}

public class TimeSeriesService : ITimeSeriesService
{
    private readonly ITimeSeriesRepository _repository;
    private readonly ILogger<TimeSeriesService> _logger;

    public TimeSeriesService(
        ITimeSeriesRepository repository, ILogger<TimeSeriesService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(TimeSeries model, CancellationToken cancellationToken)
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

    public async Task<bool> Update(TimeSeries model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.Name = model.Name;
            existing.Timezone = model.Timezone;
            existing.Granularity = model.Granularity;

            await _repository.UpdateAsync(existing, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
            return false;
        }
        return true;
    }

    public Task<TimeSeries?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<TimeSeries>> GetAll(CancellationToken cancellationToken)
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

    public async Task<bool> AddToForecasts(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromForecasts(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToAnomalies(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromAnomalies(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }



}

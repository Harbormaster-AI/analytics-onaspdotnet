using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface ITimeSeriesRepository
{
    Task<TimeSeries?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<TimeSeries>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(TimeSeries timeSeries, CancellationToken cancellationToken);
    Task UpdateAsync(TimeSeries timeSeries, CancellationToken cancellationToken);
    Task DeleteAsync(TimeSeries timeSeries, CancellationToken cancellationToken);

    Task AddToDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToForecastsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromForecastsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToAnomaliesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromAnomaliesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

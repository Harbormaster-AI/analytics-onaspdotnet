using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface ITimeSeriesRepository
{
    Task<TimeSeries?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<TimeSeries>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(TimeSeries timeSeries, CancellationToken cancellationToken);
    Task UpdateAsync(TimeSeries timeSeries, CancellationToken cancellationToken);
    Task DeleteAsync(TimeSeries timeSeries, CancellationToken cancellationToken);
}

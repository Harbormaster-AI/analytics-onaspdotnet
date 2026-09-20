using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IMetricRepository
{
    Task<Metric?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Metric>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Metric metric, CancellationToken cancellationToken);
    Task UpdateAsync(Metric metric, CancellationToken cancellationToken);
    Task DeleteAsync(Metric metric, CancellationToken cancellationToken);
}

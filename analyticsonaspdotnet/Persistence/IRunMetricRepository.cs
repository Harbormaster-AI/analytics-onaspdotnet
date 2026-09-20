using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IRunMetricRepository
{
    Task<RunMetric?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<RunMetric>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(RunMetric runMetric, CancellationToken cancellationToken);
    Task UpdateAsync(RunMetric runMetric, CancellationToken cancellationToken);
    Task DeleteAsync(RunMetric runMetric, CancellationToken cancellationToken);
}

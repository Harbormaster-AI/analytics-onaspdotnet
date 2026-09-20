using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IAnomalyRepository
{
    Task<Anomaly?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Anomaly>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Anomaly anomaly, CancellationToken cancellationToken);
    Task UpdateAsync(Anomaly anomaly, CancellationToken cancellationToken);
    Task DeleteAsync(Anomaly anomaly, CancellationToken cancellationToken);
}

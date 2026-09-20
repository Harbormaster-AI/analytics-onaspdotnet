using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IDashboardRepository
{
    Task<Dashboard?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Dashboard>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Dashboard dashboard, CancellationToken cancellationToken);
    Task UpdateAsync(Dashboard dashboard, CancellationToken cancellationToken);
    Task DeleteAsync(Dashboard dashboard, CancellationToken cancellationToken);
}

using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IAnalyticsWorkspaceRepository
{
    Task<AnalyticsWorkspace?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<AnalyticsWorkspace>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(AnalyticsWorkspace analyticsWorkspace, CancellationToken cancellationToken);
    Task UpdateAsync(AnalyticsWorkspace analyticsWorkspace, CancellationToken cancellationToken);
    Task DeleteAsync(AnalyticsWorkspace analyticsWorkspace, CancellationToken cancellationToken);
}

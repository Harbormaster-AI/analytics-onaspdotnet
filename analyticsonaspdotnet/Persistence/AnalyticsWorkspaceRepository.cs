using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class AnalyticsWorkspaceRepository : IAnalyticsWorkspaceRepository
{
    private readonly ApplicationDbContext _db;

    public AnalyticsWorkspaceRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<AnalyticsWorkspace?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.AnalyticsWorkspaces
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<AnalyticsWorkspace>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.AnalyticsWorkspaces
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(AnalyticsWorkspace analyticsWorkspace, CancellationToken cancellationToken)
    {
        _db.AnalyticsWorkspaces.Add(analyticsWorkspace);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(AnalyticsWorkspace analyticsWorkspace, CancellationToken cancellationToken)
    {
        _db.AnalyticsWorkspaces.Update(analyticsWorkspace);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(AnalyticsWorkspace analyticsWorkspace, CancellationToken cancellationToken)
    {
        _db.AnalyticsWorkspaces.Remove(analyticsWorkspace);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class DashboardRepository : IDashboardRepository
{
    private readonly ApplicationDbContext _db;

    public DashboardRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Dashboard?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Dashboards
            .Include(x => x.Workspace)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Dashboard>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Dashboards
            .AsNoTracking()
            .Include(x => x.Workspace)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Dashboard dashboard, CancellationToken cancellationToken)
    {
        _db.Dashboards.Add(dashboard);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Dashboard dashboard, CancellationToken cancellationToken)
    {
        _db.Dashboards.Update(dashboard);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Dashboard dashboard, CancellationToken cancellationToken)
    {
        _db.Dashboards.Remove(dashboard);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

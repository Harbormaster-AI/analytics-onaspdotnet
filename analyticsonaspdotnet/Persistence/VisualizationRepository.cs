using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class VisualizationRepository : IVisualizationRepository
{
    private readonly ApplicationDbContext _db;

    public VisualizationRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Visualization?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Visualizations
            .Include(x => x.Dashboard)
            .Include(x => x.Report)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Visualization>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Visualizations
            .AsNoTracking()
            .Include(x => x.Dashboard)
            .Include(x => x.Report)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Visualization visualization, CancellationToken cancellationToken)
    {
        _db.Visualizations.Add(visualization);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Visualization visualization, CancellationToken cancellationToken)
    {
        _db.Visualizations.Update(visualization);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Visualization visualization, CancellationToken cancellationToken)
    {
        _db.Visualizations.Remove(visualization);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

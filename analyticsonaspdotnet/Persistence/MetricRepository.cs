using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class MetricRepository : IMetricRepository
{
    private readonly ApplicationDbContext _db;

    public MetricRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Metric?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Metrics
            .Include(x => x.SemanticModel)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Metric>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Metrics
            .AsNoTracking()
            .Include(x => x.SemanticModel)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Metric metric, CancellationToken cancellationToken)
    {
        _db.Metrics.Add(metric);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Metric metric, CancellationToken cancellationToken)
    {
        _db.Metrics.Update(metric);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Metric metric, CancellationToken cancellationToken)
    {
        _db.Metrics.Remove(metric);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

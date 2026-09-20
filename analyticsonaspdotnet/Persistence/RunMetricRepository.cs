using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class RunMetricRepository : IRunMetricRepository
{
    private readonly ApplicationDbContext _db;

    public RunMetricRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<RunMetric?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.RunMetrics
            .Include(x => x.TrainingRun)
            .Include(x => x.Metric)
            .Include(x => x.Dataset)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<RunMetric>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.RunMetrics
            .AsNoTracking()
            .Include(x => x.TrainingRun)
            .Include(x => x.Metric)
            .Include(x => x.Dataset)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(RunMetric runMetric, CancellationToken cancellationToken)
    {
        _db.RunMetrics.Add(runMetric);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(RunMetric runMetric, CancellationToken cancellationToken)
    {
        _db.RunMetrics.Update(runMetric);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(RunMetric runMetric, CancellationToken cancellationToken)
    {
        _db.RunMetrics.Remove(runMetric);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

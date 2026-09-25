
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class EvaluationMetricRepository : IEvaluationMetricRepository
{
    private readonly ApplicationDbContext _db;

    public EvaluationMetricRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<EvaluationMetric?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.EvaluationMetrics
            .Include(x => x.ModelVersion)
            .Include(x => x.Metric)
            .Include(x => x.Dataset)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<EvaluationMetric>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.EvaluationMetrics
            .AsNoTracking()
            .Include(x => x.ModelVersion)
            .Include(x => x.Metric)
            .Include(x => x.Dataset)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(EvaluationMetric evaluationMetric, CancellationToken cancellationToken)
    {
        _db.EvaluationMetrics.Add(evaluationMetric);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(EvaluationMetric evaluationMetric, CancellationToken cancellationToken)
    {
        _db.EvaluationMetrics.Update(evaluationMetric);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(EvaluationMetric evaluationMetric, CancellationToken cancellationToken)
    {
        _db.EvaluationMetrics.Remove(evaluationMetric);
        await _db.SaveChangesAsync(cancellationToken);
    }

}

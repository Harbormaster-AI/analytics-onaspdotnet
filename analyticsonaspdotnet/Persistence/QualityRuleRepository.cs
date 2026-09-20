using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class QualityRuleRepository : IQualityRuleRepository
{
    private readonly ApplicationDbContext _db;

    public QualityRuleRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<QualityRule?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.QualityRules
            .Include(x => x.Dataset)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<QualityRule>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.QualityRules
            .AsNoTracking()
            .Include(x => x.Dataset)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(QualityRule qualityRule, CancellationToken cancellationToken)
    {
        _db.QualityRules.Add(qualityRule);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(QualityRule qualityRule, CancellationToken cancellationToken)
    {
        _db.QualityRules.Update(qualityRule);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(QualityRule qualityRule, CancellationToken cancellationToken)
    {
        _db.QualityRules.Remove(qualityRule);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

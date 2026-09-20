using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class QualityCheckRepository : IQualityCheckRepository
{
    private readonly ApplicationDbContext _db;

    public QualityCheckRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<QualityCheck?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.QualityChecks
            .Include(x => x.Rule)
            .Include(x => x.Dataset)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<QualityCheck>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.QualityChecks
            .AsNoTracking()
            .Include(x => x.Rule)
            .Include(x => x.Dataset)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(QualityCheck qualityCheck, CancellationToken cancellationToken)
    {
        _db.QualityChecks.Add(qualityCheck);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(QualityCheck qualityCheck, CancellationToken cancellationToken)
    {
        _db.QualityChecks.Update(qualityCheck);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(QualityCheck qualityCheck, CancellationToken cancellationToken)
    {
        _db.QualityChecks.Remove(qualityCheck);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

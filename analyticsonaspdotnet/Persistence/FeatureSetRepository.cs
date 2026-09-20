using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class FeatureSetRepository : IFeatureSetRepository
{
    private readonly ApplicationDbContext _db;

    public FeatureSetRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<FeatureSet?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.FeatureSets
            .Include(x => x.Workspace)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<FeatureSet>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.FeatureSets
            .AsNoTracking()
            .Include(x => x.Workspace)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(FeatureSet featureSet, CancellationToken cancellationToken)
    {
        _db.FeatureSets.Add(featureSet);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(FeatureSet featureSet, CancellationToken cancellationToken)
    {
        _db.FeatureSets.Update(featureSet);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(FeatureSet featureSet, CancellationToken cancellationToken)
    {
        _db.FeatureSets.Remove(featureSet);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

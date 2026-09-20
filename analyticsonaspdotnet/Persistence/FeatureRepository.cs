using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class FeatureRepository : IFeatureRepository
{
    private readonly ApplicationDbContext _db;

    public FeatureRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Feature?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Features
            .Include(x => x.FeatureSet)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Feature>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Features
            .AsNoTracking()
            .Include(x => x.FeatureSet)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Feature feature, CancellationToken cancellationToken)
    {
        _db.Features.Add(feature);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Feature feature, CancellationToken cancellationToken)
    {
        _db.Features.Update(feature);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Feature feature, CancellationToken cancellationToken)
    {
        _db.Features.Remove(feature);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

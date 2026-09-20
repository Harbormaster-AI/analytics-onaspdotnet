using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class DimensionRepository : IDimensionRepository
{
    private readonly ApplicationDbContext _db;

    public DimensionRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Dimension?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Dimensions
            .Include(x => x.SemanticModel)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Dimension>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Dimensions
            .AsNoTracking()
            .Include(x => x.SemanticModel)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Dimension dimension, CancellationToken cancellationToken)
    {
        _db.Dimensions.Add(dimension);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Dimension dimension, CancellationToken cancellationToken)
    {
        _db.Dimensions.Update(dimension);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Dimension dimension, CancellationToken cancellationToken)
    {
        _db.Dimensions.Remove(dimension);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

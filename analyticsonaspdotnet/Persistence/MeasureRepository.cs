using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class MeasureRepository : IMeasureRepository
{
    private readonly ApplicationDbContext _db;

    public MeasureRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Measure?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Measures
            .Include(x => x.SemanticModel)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Measure>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Measures
            .AsNoTracking()
            .Include(x => x.SemanticModel)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Measure measure, CancellationToken cancellationToken)
    {
        _db.Measures.Add(measure);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Measure measure, CancellationToken cancellationToken)
    {
        _db.Measures.Update(measure);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Measure measure, CancellationToken cancellationToken)
    {
        _db.Measures.Remove(measure);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class BIQueryRepository : IBIQueryRepository
{
    private readonly ApplicationDbContext _db;

    public BIQueryRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<BIQuery?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.BIQuerys
            .Include(x => x.Workspace)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<BIQuery>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.BIQuerys
            .AsNoTracking()
            .Include(x => x.Workspace)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(BIQuery bIQuery, CancellationToken cancellationToken)
    {
        _db.BIQuerys.Add(bIQuery);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(BIQuery bIQuery, CancellationToken cancellationToken)
    {
        _db.BIQuerys.Update(bIQuery);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(BIQuery bIQuery, CancellationToken cancellationToken)
    {
        _db.BIQuerys.Remove(bIQuery);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class LineageNodeRepository : ILineageNodeRepository
{
    private readonly ApplicationDbContext _db;

    public LineageNodeRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<LineageNode?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.LineageNodes
            .Include(x => x.Workspace)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<LineageNode>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.LineageNodes
            .AsNoTracking()
            .Include(x => x.Workspace)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(LineageNode lineageNode, CancellationToken cancellationToken)
    {
        _db.LineageNodes.Add(lineageNode);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(LineageNode lineageNode, CancellationToken cancellationToken)
    {
        _db.LineageNodes.Update(lineageNode);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(LineageNode lineageNode, CancellationToken cancellationToken)
    {
        _db.LineageNodes.Remove(lineageNode);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

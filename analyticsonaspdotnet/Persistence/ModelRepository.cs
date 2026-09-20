using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class ModelRepository : IModelRepository
{
    private readonly ApplicationDbContext _db;

    public ModelRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Model?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Models
            .Include(x => x.Workspace)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Model>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Models
            .AsNoTracking()
            .Include(x => x.Workspace)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Model model, CancellationToken cancellationToken)
    {
        _db.Models.Add(model);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Model model, CancellationToken cancellationToken)
    {
        _db.Models.Update(model);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Model model, CancellationToken cancellationToken)
    {
        _db.Models.Remove(model);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

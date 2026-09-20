using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class Model_Repository : IModel_Repository
{
    private readonly ApplicationDbContext _db;

    public Model_Repository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Model_?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Model_s
            .Include(x => x.Workspace)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Model_>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Model_s
            .AsNoTracking()
            .Include(x => x.Workspace)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Model_ model_, CancellationToken cancellationToken)
    {
        _db.Model_s.Add(model_);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Model_ model_, CancellationToken cancellationToken)
    {
        _db.Model_s.Update(model_);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Model_ model_, CancellationToken cancellationToken)
    {
        _db.Model_s.Remove(model_);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

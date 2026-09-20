using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class TagRepository : ITagRepository
{
    private readonly ApplicationDbContext _db;

    public TagRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Tag?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Tags
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Tag>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Tags
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Tag tag, CancellationToken cancellationToken)
    {
        _db.Tags.Add(tag);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Tag tag, CancellationToken cancellationToken)
    {
        _db.Tags.Update(tag);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Tag tag, CancellationToken cancellationToken)
    {
        _db.Tags.Remove(tag);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

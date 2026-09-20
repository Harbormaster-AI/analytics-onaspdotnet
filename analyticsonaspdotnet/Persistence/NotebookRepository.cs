using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class NotebookRepository : INotebookRepository
{
    private readonly ApplicationDbContext _db;

    public NotebookRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Notebook?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Notebooks
            .Include(x => x.Workspace)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Notebook>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Notebooks
            .AsNoTracking()
            .Include(x => x.Workspace)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Notebook notebook, CancellationToken cancellationToken)
    {
        _db.Notebooks.Add(notebook);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Notebook notebook, CancellationToken cancellationToken)
    {
        _db.Notebooks.Update(notebook);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Notebook notebook, CancellationToken cancellationToken)
    {
        _db.Notebooks.Remove(notebook);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

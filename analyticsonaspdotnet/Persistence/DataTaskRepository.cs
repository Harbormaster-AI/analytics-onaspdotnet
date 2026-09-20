using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class DataTaskRepository : IDataTaskRepository
{
    private readonly ApplicationDbContext _db;

    public DataTaskRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<DataTask?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.DataTasks
            .Include(x => x.Pipeline)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<DataTask>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.DataTasks
            .AsNoTracking()
            .Include(x => x.Pipeline)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(DataTask dataTask, CancellationToken cancellationToken)
    {
        _db.DataTasks.Add(dataTask);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(DataTask dataTask, CancellationToken cancellationToken)
    {
        _db.DataTasks.Update(dataTask);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(DataTask dataTask, CancellationToken cancellationToken)
    {
        _db.DataTasks.Remove(dataTask);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

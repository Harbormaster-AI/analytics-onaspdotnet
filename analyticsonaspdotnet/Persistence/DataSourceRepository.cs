using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class DataSourceRepository : IDataSourceRepository
{
    private readonly ApplicationDbContext _db;

    public DataSourceRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<DataSource?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.DataSources
            .Include(x => x.Workspace)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<DataSource>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.DataSources
            .AsNoTracking()
            .Include(x => x.Workspace)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(DataSource dataSource, CancellationToken cancellationToken)
    {
        _db.DataSources.Add(dataSource);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(DataSource dataSource, CancellationToken cancellationToken)
    {
        _db.DataSources.Update(dataSource);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(DataSource dataSource, CancellationToken cancellationToken)
    {
        _db.DataSources.Remove(dataSource);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class DataSetRepository : IDataSetRepository
{
    private readonly ApplicationDbContext _db;

    public DataSetRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<DataSet?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.DataSets
            .Include(x => x.Workspace)
            .Include(x => x.LineageNode)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<DataSet>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.DataSets
            .AsNoTracking()
            .Include(x => x.Workspace)
            .Include(x => x.LineageNode)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(DataSet dataSet, CancellationToken cancellationToken)
    {
        _db.DataSets.Add(dataSet);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(DataSet dataSet, CancellationToken cancellationToken)
    {
        _db.DataSets.Update(dataSet);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(DataSet dataSet, CancellationToken cancellationToken)
    {
        _db.DataSets.Remove(dataSet);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

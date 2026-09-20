using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class DataPipelineRepository : IDataPipelineRepository
{
    private readonly ApplicationDbContext _db;

    public DataPipelineRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<DataPipeline?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.DataPipelines
            .Include(x => x.Workspace)
            .Include(x => x.LineageNode)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<DataPipeline>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.DataPipelines
            .AsNoTracking()
            .Include(x => x.Workspace)
            .Include(x => x.LineageNode)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(DataPipeline dataPipeline, CancellationToken cancellationToken)
    {
        _db.DataPipelines.Add(dataPipeline);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(DataPipeline dataPipeline, CancellationToken cancellationToken)
    {
        _db.DataPipelines.Update(dataPipeline);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(DataPipeline dataPipeline, CancellationToken cancellationToken)
    {
        _db.DataPipelines.Remove(dataPipeline);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

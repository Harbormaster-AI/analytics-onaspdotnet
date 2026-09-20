using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class ModelVersionRepository : IModelVersionRepository
{
    private readonly ApplicationDbContext _db;

    public ModelVersionRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<ModelVersion?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.ModelVersions
            .Include(x => x.Model)
            .Include(x => x.TrainingRun)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<ModelVersion>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.ModelVersions
            .AsNoTracking()
            .Include(x => x.Model)
            .Include(x => x.TrainingRun)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(ModelVersion modelVersion, CancellationToken cancellationToken)
    {
        _db.ModelVersions.Add(modelVersion);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(ModelVersion modelVersion, CancellationToken cancellationToken)
    {
        _db.ModelVersions.Update(modelVersion);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(ModelVersion modelVersion, CancellationToken cancellationToken)
    {
        _db.ModelVersions.Remove(modelVersion);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

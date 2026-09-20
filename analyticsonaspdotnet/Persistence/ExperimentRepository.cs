using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class ExperimentRepository : IExperimentRepository
{
    private readonly ApplicationDbContext _db;

    public ExperimentRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Experiment?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Experiments
            .Include(x => x.Workspace)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Experiment>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Experiments
            .AsNoTracking()
            .Include(x => x.Workspace)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Experiment experiment, CancellationToken cancellationToken)
    {
        _db.Experiments.Add(experiment);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Experiment experiment, CancellationToken cancellationToken)
    {
        _db.Experiments.Update(experiment);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Experiment experiment, CancellationToken cancellationToken)
    {
        _db.Experiments.Remove(experiment);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

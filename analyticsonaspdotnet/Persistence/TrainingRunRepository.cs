using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class TrainingRunRepository : ITrainingRunRepository
{
    private readonly ApplicationDbContext _db;

    public TrainingRunRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<TrainingRun?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.TrainingRuns
            .Include(x => x.Experiment)
            .Include(x => x.ModelVersion)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<TrainingRun>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.TrainingRuns
            .AsNoTracking()
            .Include(x => x.Experiment)
            .Include(x => x.ModelVersion)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(TrainingRun trainingRun, CancellationToken cancellationToken)
    {
        _db.TrainingRuns.Add(trainingRun);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(TrainingRun trainingRun, CancellationToken cancellationToken)
    {
        _db.TrainingRuns.Update(trainingRun);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(TrainingRun trainingRun, CancellationToken cancellationToken)
    {
        _db.TrainingRuns.Remove(trainingRun);
        await _db.SaveChangesAsync(cancellationToken);
    }
}


using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class RunParameterRepository : IRunParameterRepository
{
    private readonly ApplicationDbContext _db;

    public RunParameterRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<RunParameter?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.RunParameters
            .Include(x => x.TrainingRun)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<RunParameter>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.RunParameters
            .AsNoTracking()
            .Include(x => x.TrainingRun)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(RunParameter runParameter, CancellationToken cancellationToken)
    {
        _db.RunParameters.Add(runParameter);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(RunParameter runParameter, CancellationToken cancellationToken)
    {
        _db.RunParameters.Update(runParameter);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(RunParameter runParameter, CancellationToken cancellationToken)
    {
        _db.RunParameters.Remove(runParameter);
        await _db.SaveChangesAsync(cancellationToken);
    }

}

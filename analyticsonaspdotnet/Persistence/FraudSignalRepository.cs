using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class FraudSignalRepository : IFraudSignalRepository
{
    private readonly ApplicationDbContext _db;

    public FraudSignalRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<FraudSignal?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.FraudSignals
            .Include(x => x.Scenario)
            .Include(x => x.Dataset)
            .Include(x => x.ModelVersion)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<FraudSignal>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.FraudSignals
            .AsNoTracking()
            .Include(x => x.Scenario)
            .Include(x => x.Dataset)
            .Include(x => x.ModelVersion)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(FraudSignal fraudSignal, CancellationToken cancellationToken)
    {
        _db.FraudSignals.Add(fraudSignal);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(FraudSignal fraudSignal, CancellationToken cancellationToken)
    {
        _db.FraudSignals.Update(fraudSignal);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(FraudSignal fraudSignal, CancellationToken cancellationToken)
    {
        _db.FraudSignals.Remove(fraudSignal);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

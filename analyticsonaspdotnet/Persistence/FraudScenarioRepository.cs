using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class FraudScenarioRepository : IFraudScenarioRepository
{
    private readonly ApplicationDbContext _db;

    public FraudScenarioRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<FraudScenario?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.FraudScenarios
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<FraudScenario>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.FraudScenarios
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(FraudScenario fraudScenario, CancellationToken cancellationToken)
    {
        _db.FraudScenarios.Add(fraudScenario);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(FraudScenario fraudScenario, CancellationToken cancellationToken)
    {
        _db.FraudScenarios.Update(fraudScenario);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(FraudScenario fraudScenario, CancellationToken cancellationToken)
    {
        _db.FraudScenarios.Remove(fraudScenario);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

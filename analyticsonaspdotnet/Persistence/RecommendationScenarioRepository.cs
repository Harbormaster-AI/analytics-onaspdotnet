using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class RecommendationScenarioRepository : IRecommendationScenarioRepository
{
    private readonly ApplicationDbContext _db;

    public RecommendationScenarioRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<RecommendationScenario?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.RecommendationScenarios
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<RecommendationScenario>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.RecommendationScenarios
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(RecommendationScenario recommendationScenario, CancellationToken cancellationToken)
    {
        _db.RecommendationScenarios.Add(recommendationScenario);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(RecommendationScenario recommendationScenario, CancellationToken cancellationToken)
    {
        _db.RecommendationScenarios.Update(recommendationScenario);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(RecommendationScenario recommendationScenario, CancellationToken cancellationToken)
    {
        _db.RecommendationScenarios.Remove(recommendationScenario);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

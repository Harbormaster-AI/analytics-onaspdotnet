using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class SemanticModelRepository : ISemanticModelRepository
{
    private readonly ApplicationDbContext _db;

    public SemanticModelRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<SemanticModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.SemanticModels
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<SemanticModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.SemanticModels
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(SemanticModel semanticModel, CancellationToken cancellationToken)
    {
        _db.SemanticModels.Add(semanticModel);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(SemanticModel semanticModel, CancellationToken cancellationToken)
    {
        _db.SemanticModels.Update(semanticModel);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(SemanticModel semanticModel, CancellationToken cancellationToken)
    {
        _db.SemanticModels.Remove(semanticModel);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

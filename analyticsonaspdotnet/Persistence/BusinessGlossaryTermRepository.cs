using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class BusinessGlossaryTermRepository : IBusinessGlossaryTermRepository
{
    private readonly ApplicationDbContext _db;

    public BusinessGlossaryTermRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<BusinessGlossaryTerm?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.BusinessGlossaryTerms
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<BusinessGlossaryTerm>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.BusinessGlossaryTerms
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(BusinessGlossaryTerm businessGlossaryTerm, CancellationToken cancellationToken)
    {
        _db.BusinessGlossaryTerms.Add(businessGlossaryTerm);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(BusinessGlossaryTerm businessGlossaryTerm, CancellationToken cancellationToken)
    {
        _db.BusinessGlossaryTerms.Update(businessGlossaryTerm);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(BusinessGlossaryTerm businessGlossaryTerm, CancellationToken cancellationToken)
    {
        _db.BusinessGlossaryTerms.Remove(businessGlossaryTerm);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

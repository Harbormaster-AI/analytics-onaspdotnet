using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IBusinessGlossaryTermRepository
{
    Task<BusinessGlossaryTerm?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<BusinessGlossaryTerm>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(BusinessGlossaryTerm businessGlossaryTerm, CancellationToken cancellationToken);
    Task UpdateAsync(BusinessGlossaryTerm businessGlossaryTerm, CancellationToken cancellationToken);
    Task DeleteAsync(BusinessGlossaryTerm businessGlossaryTerm, CancellationToken cancellationToken);
}

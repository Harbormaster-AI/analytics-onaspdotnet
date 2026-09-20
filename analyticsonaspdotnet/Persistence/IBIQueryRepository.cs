using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IBIQueryRepository
{
    Task<BIQuery?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<BIQuery>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(BIQuery bIQuery, CancellationToken cancellationToken);
    Task UpdateAsync(BIQuery bIQuery, CancellationToken cancellationToken);
    Task DeleteAsync(BIQuery bIQuery, CancellationToken cancellationToken);
}

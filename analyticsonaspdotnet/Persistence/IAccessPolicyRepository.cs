using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IAccessPolicyRepository
{
    Task<AccessPolicy?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<AccessPolicy>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(AccessPolicy accessPolicy, CancellationToken cancellationToken);
    Task UpdateAsync(AccessPolicy accessPolicy, CancellationToken cancellationToken);
    Task DeleteAsync(AccessPolicy accessPolicy, CancellationToken cancellationToken);
}

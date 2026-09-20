using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IModel_Repository
{
    Task<Model_?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Model_>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Model_ model_, CancellationToken cancellationToken);
    Task UpdateAsync(Model_ model_, CancellationToken cancellationToken);
    Task DeleteAsync(Model_ model_, CancellationToken cancellationToken);
}

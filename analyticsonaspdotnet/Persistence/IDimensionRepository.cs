using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IDimensionRepository
{
    Task<Dimension?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Dimension>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Dimension dimension, CancellationToken cancellationToken);
    Task UpdateAsync(Dimension dimension, CancellationToken cancellationToken);
    Task DeleteAsync(Dimension dimension, CancellationToken cancellationToken);
}

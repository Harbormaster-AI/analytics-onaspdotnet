using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IMeasureRepository
{
    Task<Measure?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Measure>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Measure measure, CancellationToken cancellationToken);
    Task UpdateAsync(Measure measure, CancellationToken cancellationToken);
    Task DeleteAsync(Measure measure, CancellationToken cancellationToken);
}

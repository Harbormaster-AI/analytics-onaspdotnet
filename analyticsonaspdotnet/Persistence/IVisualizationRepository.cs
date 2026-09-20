using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IVisualizationRepository
{
    Task<Visualization?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Visualization>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Visualization visualization, CancellationToken cancellationToken);
    Task UpdateAsync(Visualization visualization, CancellationToken cancellationToken);
    Task DeleteAsync(Visualization visualization, CancellationToken cancellationToken);
}

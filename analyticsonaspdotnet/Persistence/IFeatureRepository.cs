using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IFeatureRepository
{
    Task<Feature?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Feature>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Feature feature, CancellationToken cancellationToken);
    Task UpdateAsync(Feature feature, CancellationToken cancellationToken);
    Task DeleteAsync(Feature feature, CancellationToken cancellationToken);
}

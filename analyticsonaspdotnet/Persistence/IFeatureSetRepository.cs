using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IFeatureSetRepository
{
    Task<FeatureSet?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<FeatureSet>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(FeatureSet featureSet, CancellationToken cancellationToken);
    Task UpdateAsync(FeatureSet featureSet, CancellationToken cancellationToken);
    Task DeleteAsync(FeatureSet featureSet, CancellationToken cancellationToken);
}

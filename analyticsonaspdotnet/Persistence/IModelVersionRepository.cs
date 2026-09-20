using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IModelVersionRepository
{
    Task<ModelVersion?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<ModelVersion>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(ModelVersion modelVersion, CancellationToken cancellationToken);
    Task UpdateAsync(ModelVersion modelVersion, CancellationToken cancellationToken);
    Task DeleteAsync(ModelVersion modelVersion, CancellationToken cancellationToken);
}

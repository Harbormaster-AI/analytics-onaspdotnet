using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IInferenceEndpointRepository
{
    Task<InferenceEndpoint?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<InferenceEndpoint>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(InferenceEndpoint inferenceEndpoint, CancellationToken cancellationToken);
    Task UpdateAsync(InferenceEndpoint inferenceEndpoint, CancellationToken cancellationToken);
    Task DeleteAsync(InferenceEndpoint inferenceEndpoint, CancellationToken cancellationToken);
}

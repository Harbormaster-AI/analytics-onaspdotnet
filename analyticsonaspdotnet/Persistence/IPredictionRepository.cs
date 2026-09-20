using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IPredictionRepository
{
    Task<Prediction?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Prediction>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Prediction prediction, CancellationToken cancellationToken);
    Task UpdateAsync(Prediction prediction, CancellationToken cancellationToken);
    Task DeleteAsync(Prediction prediction, CancellationToken cancellationToken);
}

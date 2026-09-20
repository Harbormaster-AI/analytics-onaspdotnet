using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface ITrainingRunRepository
{
    Task<TrainingRun?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<TrainingRun>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(TrainingRun trainingRun, CancellationToken cancellationToken);
    Task UpdateAsync(TrainingRun trainingRun, CancellationToken cancellationToken);
    Task DeleteAsync(TrainingRun trainingRun, CancellationToken cancellationToken);
}

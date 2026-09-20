using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IEvaluationMetricRepository
{
    Task<EvaluationMetric?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<EvaluationMetric>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(EvaluationMetric evaluationMetric, CancellationToken cancellationToken);
    Task UpdateAsync(EvaluationMetric evaluationMetric, CancellationToken cancellationToken);
    Task DeleteAsync(EvaluationMetric evaluationMetric, CancellationToken cancellationToken);
}

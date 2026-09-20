using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IQualityRuleRepository
{
    Task<QualityRule?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<QualityRule>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(QualityRule qualityRule, CancellationToken cancellationToken);
    Task UpdateAsync(QualityRule qualityRule, CancellationToken cancellationToken);
    Task DeleteAsync(QualityRule qualityRule, CancellationToken cancellationToken);
}

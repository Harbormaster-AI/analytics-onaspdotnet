using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface IQualityRuleRepository
{
    Task<QualityRule?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<QualityRule>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(QualityRule qualityRule, CancellationToken cancellationToken);
    Task UpdateAsync(QualityRule qualityRule, CancellationToken cancellationToken);
    Task DeleteAsync(QualityRule qualityRule, CancellationToken cancellationToken);

    Task AddToChecksAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromChecksAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IQualityCheckRepository
{
    Task<QualityCheck?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<QualityCheck>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(QualityCheck qualityCheck, CancellationToken cancellationToken);
    Task UpdateAsync(QualityCheck qualityCheck, CancellationToken cancellationToken);
    Task DeleteAsync(QualityCheck qualityCheck, CancellationToken cancellationToken);
}

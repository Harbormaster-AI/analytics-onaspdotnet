using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface IFraudSignalRepository
{
    Task<FraudSignal?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<FraudSignal>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(FraudSignal fraudSignal, CancellationToken cancellationToken);
    Task UpdateAsync(FraudSignal fraudSignal, CancellationToken cancellationToken);
    Task DeleteAsync(FraudSignal fraudSignal, CancellationToken cancellationToken);


}

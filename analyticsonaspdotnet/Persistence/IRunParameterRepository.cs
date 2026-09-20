using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IRunParameterRepository
{
    Task<RunParameter?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<RunParameter>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(RunParameter runParameter, CancellationToken cancellationToken);
    Task UpdateAsync(RunParameter runParameter, CancellationToken cancellationToken);
    Task DeleteAsync(RunParameter runParameter, CancellationToken cancellationToken);
}

using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IDataTaskRepository
{
    Task<DataTask?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<DataTask>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(DataTask dataTask, CancellationToken cancellationToken);
    Task UpdateAsync(DataTask dataTask, CancellationToken cancellationToken);
    Task DeleteAsync(DataTask dataTask, CancellationToken cancellationToken);
}

using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IDataSourceRepository
{
    Task<DataSource?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<DataSource>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(DataSource dataSource, CancellationToken cancellationToken);
    Task UpdateAsync(DataSource dataSource, CancellationToken cancellationToken);
    Task DeleteAsync(DataSource dataSource, CancellationToken cancellationToken);
}

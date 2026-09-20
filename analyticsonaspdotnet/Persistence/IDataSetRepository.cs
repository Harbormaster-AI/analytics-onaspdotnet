using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IDataSetRepository
{
    Task<DataSet?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<DataSet>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(DataSet dataSet, CancellationToken cancellationToken);
    Task UpdateAsync(DataSet dataSet, CancellationToken cancellationToken);
    Task DeleteAsync(DataSet dataSet, CancellationToken cancellationToken);
}

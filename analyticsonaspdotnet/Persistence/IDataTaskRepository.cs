using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface IDataTaskRepository
{
    Task<DataTask?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<DataTask>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(DataTask dataTask, CancellationToken cancellationToken);
    Task UpdateAsync(DataTask dataTask, CancellationToken cancellationToken);
    Task DeleteAsync(DataTask dataTask, CancellationToken cancellationToken);

    Task AddToInputDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromInputDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToOutputDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromOutputDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

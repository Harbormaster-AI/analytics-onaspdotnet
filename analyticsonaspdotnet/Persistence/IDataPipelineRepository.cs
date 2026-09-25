using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface IDataPipelineRepository
{
    Task<DataPipeline?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<DataPipeline>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(DataPipeline dataPipeline, CancellationToken cancellationToken);
    Task UpdateAsync(DataPipeline dataPipeline, CancellationToken cancellationToken);
    Task DeleteAsync(DataPipeline dataPipeline, CancellationToken cancellationToken);

    Task AddToTasksAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromTasksAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToSourcesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromSourcesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToOutputsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromOutputsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

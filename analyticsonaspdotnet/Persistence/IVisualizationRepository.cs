using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface IVisualizationRepository
{
    Task<Visualization?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Visualization>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Visualization visualization, CancellationToken cancellationToken);
    Task UpdateAsync(Visualization visualization, CancellationToken cancellationToken);
    Task DeleteAsync(Visualization visualization, CancellationToken cancellationToken);

    Task AddToMetricsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromMetricsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToDimensionsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDimensionsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

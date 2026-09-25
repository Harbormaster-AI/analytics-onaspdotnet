using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface IMetricRepository
{
    Task<Metric?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Metric>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Metric metric, CancellationToken cancellationToken);
    Task UpdateAsync(Metric metric, CancellationToken cancellationToken);
    Task DeleteAsync(Metric metric, CancellationToken cancellationToken);

    Task AddToDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToGlossaryTermsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromGlossaryTermsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToAlertsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromAlertsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToVisualizationsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromVisualizationsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

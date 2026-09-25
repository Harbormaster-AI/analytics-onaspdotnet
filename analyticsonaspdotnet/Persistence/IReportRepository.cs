using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface IReportRepository
{
    Task<Report?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Report>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Report report, CancellationToken cancellationToken);
    Task UpdateAsync(Report report, CancellationToken cancellationToken);
    Task DeleteAsync(Report report, CancellationToken cancellationToken);

    Task AddToVisualizationsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromVisualizationsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToSemanticModelsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromSemanticModelsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToQueriesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromQueriesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToTagsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromTagsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

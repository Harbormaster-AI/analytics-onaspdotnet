using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface INotebookRepository
{
    Task<Notebook?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Notebook>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Notebook notebook, CancellationToken cancellationToken);
    Task UpdateAsync(Notebook notebook, CancellationToken cancellationToken);
    Task DeleteAsync(Notebook notebook, CancellationToken cancellationToken);

    Task AddToDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToExperimentsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromExperimentsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToQueriesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromQueriesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

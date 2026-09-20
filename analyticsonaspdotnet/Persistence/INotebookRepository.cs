using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface INotebookRepository
{
    Task<Notebook?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Notebook>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Notebook notebook, CancellationToken cancellationToken);
    Task UpdateAsync(Notebook notebook, CancellationToken cancellationToken);
    Task DeleteAsync(Notebook notebook, CancellationToken cancellationToken);
}

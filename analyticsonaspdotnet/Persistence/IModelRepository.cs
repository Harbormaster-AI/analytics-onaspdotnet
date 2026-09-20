using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface IModelRepository
{
    Task<Model?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Model>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Model model, CancellationToken cancellationToken);
    Task UpdateAsync(Model model, CancellationToken cancellationToken);
    Task DeleteAsync(Model model, CancellationToken cancellationToken);
}

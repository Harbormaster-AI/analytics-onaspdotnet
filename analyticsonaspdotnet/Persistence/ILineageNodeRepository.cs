using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface ILineageNodeRepository
{
    Task<LineageNode?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<LineageNode>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(LineageNode lineageNode, CancellationToken cancellationToken);
    Task UpdateAsync(LineageNode lineageNode, CancellationToken cancellationToken);
    Task DeleteAsync(LineageNode lineageNode, CancellationToken cancellationToken);
}

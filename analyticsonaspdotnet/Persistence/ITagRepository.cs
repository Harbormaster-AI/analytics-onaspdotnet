using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface ITagRepository
{
    Task<Tag?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Tag>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Tag tag, CancellationToken cancellationToken);
    Task UpdateAsync(Tag tag, CancellationToken cancellationToken);
    Task DeleteAsync(Tag tag, CancellationToken cancellationToken);
}

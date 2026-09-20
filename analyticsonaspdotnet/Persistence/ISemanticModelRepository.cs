using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public interface ISemanticModelRepository
{
    Task<SemanticModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<SemanticModel>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(SemanticModel semanticModel, CancellationToken cancellationToken);
    Task UpdateAsync(SemanticModel semanticModel, CancellationToken cancellationToken);
    Task DeleteAsync(SemanticModel semanticModel, CancellationToken cancellationToken);
}

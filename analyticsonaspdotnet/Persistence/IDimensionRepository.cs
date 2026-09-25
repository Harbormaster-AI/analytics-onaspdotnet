using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface IDimensionRepository
{
    Task<Dimension?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Dimension>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Dimension dimension, CancellationToken cancellationToken);
    Task UpdateAsync(Dimension dimension, CancellationToken cancellationToken);
    Task DeleteAsync(Dimension dimension, CancellationToken cancellationToken);

    Task AddToDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToGlossaryTermsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromGlossaryTermsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

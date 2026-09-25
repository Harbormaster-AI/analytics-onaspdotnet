using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface IMeasureRepository
{
    Task<Measure?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Measure>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Measure measure, CancellationToken cancellationToken);
    Task UpdateAsync(Measure measure, CancellationToken cancellationToken);
    Task DeleteAsync(Measure measure, CancellationToken cancellationToken);

    Task AddToDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToGlossaryTermsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromGlossaryTermsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

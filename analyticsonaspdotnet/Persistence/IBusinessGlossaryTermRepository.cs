using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface IBusinessGlossaryTermRepository
{
    Task<BusinessGlossaryTerm?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<BusinessGlossaryTerm>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(BusinessGlossaryTerm businessGlossaryTerm, CancellationToken cancellationToken);
    Task UpdateAsync(BusinessGlossaryTerm businessGlossaryTerm, CancellationToken cancellationToken);
    Task DeleteAsync(BusinessGlossaryTerm businessGlossaryTerm, CancellationToken cancellationToken);

    Task AddToRelatedTermsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromRelatedTermsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToMetricsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromMetricsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToDimensionsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDimensionsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToMeasuresAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromMeasuresAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

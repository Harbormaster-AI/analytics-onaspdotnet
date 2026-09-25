using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface ISemanticModelRepository
{
    Task<SemanticModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<SemanticModel>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(SemanticModel semanticModel, CancellationToken cancellationToken);
    Task UpdateAsync(SemanticModel semanticModel, CancellationToken cancellationToken);
    Task DeleteAsync(SemanticModel semanticModel, CancellationToken cancellationToken);

    Task AddToDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToMetricsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromMetricsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToDimensionsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDimensionsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToMeasuresAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromMeasuresAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToGlossaryTermsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromGlossaryTermsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

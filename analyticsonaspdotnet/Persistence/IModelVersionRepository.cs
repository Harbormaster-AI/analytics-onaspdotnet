using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface IModelVersionRepository
{
    Task<ModelVersion?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<ModelVersion>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(ModelVersion modelVersion, CancellationToken cancellationToken);
    Task UpdateAsync(ModelVersion modelVersion, CancellationToken cancellationToken);
    Task DeleteAsync(ModelVersion modelVersion, CancellationToken cancellationToken);

    Task AddToEvaluationMetricsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromEvaluationMetricsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToDeploymentsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDeploymentsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToFeatureSetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromFeatureSetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

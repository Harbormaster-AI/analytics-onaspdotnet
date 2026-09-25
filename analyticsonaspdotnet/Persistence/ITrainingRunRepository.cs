using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface ITrainingRunRepository
{
    Task<TrainingRun?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<TrainingRun>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(TrainingRun trainingRun, CancellationToken cancellationToken);
    Task UpdateAsync(TrainingRun trainingRun, CancellationToken cancellationToken);
    Task DeleteAsync(TrainingRun trainingRun, CancellationToken cancellationToken);

    Task AddToInputDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromInputDatasetsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToFeaturesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromFeaturesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToRunMetricsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromRunMetricsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToRunParametersAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromRunParametersAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

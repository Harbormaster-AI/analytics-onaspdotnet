using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface IExperimentRepository
{
    Task<Experiment?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Experiment>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Experiment experiment, CancellationToken cancellationToken);
    Task UpdateAsync(Experiment experiment, CancellationToken cancellationToken);
    Task DeleteAsync(Experiment experiment, CancellationToken cancellationToken);

    Task AddToTrainingRunsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromTrainingRunsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToModelsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromModelsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToNotebooksAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromNotebooksAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

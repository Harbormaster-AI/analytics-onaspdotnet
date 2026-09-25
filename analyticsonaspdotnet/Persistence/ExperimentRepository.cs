
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class ExperimentRepository : IExperimentRepository
{
    private readonly ApplicationDbContext _db;

    public ExperimentRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Experiment?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Experiments
            .Include(x => x.Workspace)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Experiment>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Experiments
            .AsNoTracking()
            .Include(x => x.Workspace)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Experiment experiment, CancellationToken cancellationToken)
    {
        _db.Experiments.Add(experiment);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Experiment experiment, CancellationToken cancellationToken)
    {
        _db.Experiments.Update(experiment);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Experiment experiment, CancellationToken cancellationToken)
    {
        _db.Experiments.Remove(experiment);
        await _db.SaveChangesAsync(cancellationToken);
    }


    public async Task AddToTrainingRunsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.TrainingRuns
            .Where(trainingRun =>
                request.ChildIds.Contains(trainingRun.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    trainingRun =>
                        EF.Property<Guid?>(
                            trainingRun,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromTrainingRunsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.TrainingRuns
            .Where(trainingRun =>
                request.ChildIds.Contains(trainingRun.Id) &&
                EF.Property<Guid?>(
                    trainingRun,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    trainingRun =>
                        EF.Property<Guid?>(
                            trainingRun,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToModelsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Model_s
            .Where(model_ =>
                request.ChildIds.Contains(model_.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    model_ =>
                        EF.Property<Guid?>(
                            model_,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromModelsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Model_s
            .Where(model_ =>
                request.ChildIds.Contains(model_.Id) &&
                EF.Property<Guid?>(
                    model_,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    model_ =>
                        EF.Property<Guid?>(
                            model_,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToNotebooksAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Notebooks
            .Where(notebook =>
                request.ChildIds.Contains(notebook.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    notebook =>
                        EF.Property<Guid?>(
                            notebook,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromNotebooksAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Notebooks
            .Where(notebook =>
                request.ChildIds.Contains(notebook.Id) &&
                EF.Property<Guid?>(
                    notebook,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    notebook =>
                        EF.Property<Guid?>(
                            notebook,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }

}

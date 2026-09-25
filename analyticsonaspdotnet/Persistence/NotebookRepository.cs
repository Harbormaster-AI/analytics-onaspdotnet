
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class NotebookRepository : INotebookRepository
{
    private readonly ApplicationDbContext _db;

    public NotebookRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Notebook?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Notebooks
            .Include(x => x.Workspace)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Notebook>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Notebooks
            .AsNoTracking()
            .Include(x => x.Workspace)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Notebook notebook, CancellationToken cancellationToken)
    {
        _db.Notebooks.Add(notebook);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Notebook notebook, CancellationToken cancellationToken)
    {
        _db.Notebooks.Update(notebook);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Notebook notebook, CancellationToken cancellationToken)
    {
        _db.Notebooks.Remove(notebook);
        await _db.SaveChangesAsync(cancellationToken);
    }


    public async Task AddToDatasetsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.DataSets
            .Where(dataSet =>
                request.ChildIds.Contains(dataSet.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    dataSet =>
                        EF.Property<Guid?>(
                            dataSet,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromDatasetsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.DataSets
            .Where(dataSet =>
                request.ChildIds.Contains(dataSet.Id) &&
                EF.Property<Guid?>(
                    dataSet,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    dataSet =>
                        EF.Property<Guid?>(
                            dataSet,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToExperimentsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Experiments
            .Where(experiment =>
                request.ChildIds.Contains(experiment.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    experiment =>
                        EF.Property<Guid?>(
                            experiment,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromExperimentsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Experiments
            .Where(experiment =>
                request.ChildIds.Contains(experiment.Id) &&
                EF.Property<Guid?>(
                    experiment,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    experiment =>
                        EF.Property<Guid?>(
                            experiment,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToQueriesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.BIQuerys
            .Where(bIQuery =>
                request.ChildIds.Contains(bIQuery.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    bIQuery =>
                        EF.Property<Guid?>(
                            bIQuery,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromQueriesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.BIQuerys
            .Where(bIQuery =>
                request.ChildIds.Contains(bIQuery.Id) &&
                EF.Property<Guid?>(
                    bIQuery,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    bIQuery =>
                        EF.Property<Guid?>(
                            bIQuery,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }

}

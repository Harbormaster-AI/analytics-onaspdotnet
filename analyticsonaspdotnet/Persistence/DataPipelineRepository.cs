
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class DataPipelineRepository : IDataPipelineRepository
{
    private readonly ApplicationDbContext _db;

    public DataPipelineRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<DataPipeline?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.DataPipelines
            .Include(x => x.Workspace)
            .Include(x => x.LineageNode)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<DataPipeline>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.DataPipelines
            .AsNoTracking()
            .Include(x => x.Workspace)
            .Include(x => x.LineageNode)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(DataPipeline dataPipeline, CancellationToken cancellationToken)
    {
        _db.DataPipelines.Add(dataPipeline);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(DataPipeline dataPipeline, CancellationToken cancellationToken)
    {
        _db.DataPipelines.Update(dataPipeline);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(DataPipeline dataPipeline, CancellationToken cancellationToken)
    {
        _db.DataPipelines.Remove(dataPipeline);
        await _db.SaveChangesAsync(cancellationToken);
    }


    public async Task AddToTasksAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.DataTasks
            .Where(dataTask =>
                request.ChildIds.Contains(dataTask.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    dataTask =>
                        EF.Property<Guid?>(
                            dataTask,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromTasksAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.DataTasks
            .Where(dataTask =>
                request.ChildIds.Contains(dataTask.Id) &&
                EF.Property<Guid?>(
                    dataTask,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    dataTask =>
                        EF.Property<Guid?>(
                            dataTask,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToSourcesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.DataSources
            .Where(dataSource =>
                request.ChildIds.Contains(dataSource.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    dataSource =>
                        EF.Property<Guid?>(
                            dataSource,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromSourcesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.DataSources
            .Where(dataSource =>
                request.ChildIds.Contains(dataSource.Id) &&
                EF.Property<Guid?>(
                    dataSource,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    dataSource =>
                        EF.Property<Guid?>(
                            dataSource,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToOutputsAsync(
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

    public async Task RemoveFromOutputsAsync(
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

}

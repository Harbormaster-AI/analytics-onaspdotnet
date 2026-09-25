
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class DataSourceRepository : IDataSourceRepository
{
    private readonly ApplicationDbContext _db;

    public DataSourceRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<DataSource?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.DataSources
            .Include(x => x.Workspace)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<DataSource>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.DataSources
            .AsNoTracking()
            .Include(x => x.Workspace)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(DataSource dataSource, CancellationToken cancellationToken)
    {
        _db.DataSources.Add(dataSource);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(DataSource dataSource, CancellationToken cancellationToken)
    {
        _db.DataSources.Update(dataSource);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(DataSource dataSource, CancellationToken cancellationToken)
    {
        _db.DataSources.Remove(dataSource);
        await _db.SaveChangesAsync(cancellationToken);
    }


    public async Task AddToProducedDatasetsAsync(
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

    public async Task RemoveFromProducedDatasetsAsync(
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


    public async Task AddToPipelinesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.DataPipelines
            .Where(dataPipeline =>
                request.ChildIds.Contains(dataPipeline.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    dataPipeline =>
                        EF.Property<Guid?>(
                            dataPipeline,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromPipelinesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.DataPipelines
            .Where(dataPipeline =>
                request.ChildIds.Contains(dataPipeline.Id) &&
                EF.Property<Guid?>(
                    dataPipeline,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    dataPipeline =>
                        EF.Property<Guid?>(
                            dataPipeline,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }

}

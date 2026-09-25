
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class ForecastRepository : IForecastRepository
{
    private readonly ApplicationDbContext _db;

    public ForecastRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Forecast?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Forecasts
            .Include(x => x.ModelVersion)
            .Include(x => x.TimeSeries)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Forecast>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Forecasts
            .AsNoTracking()
            .Include(x => x.ModelVersion)
            .Include(x => x.TimeSeries)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Forecast forecast, CancellationToken cancellationToken)
    {
        _db.Forecasts.Add(forecast);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Forecast forecast, CancellationToken cancellationToken)
    {
        _db.Forecasts.Update(forecast);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Forecast forecast, CancellationToken cancellationToken)
    {
        _db.Forecasts.Remove(forecast);
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

}

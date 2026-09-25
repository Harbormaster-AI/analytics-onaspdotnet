
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class TimeSeriesRepository : ITimeSeriesRepository
{
    private readonly ApplicationDbContext _db;

    public TimeSeriesRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<TimeSeries?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.TimeSeriess
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<TimeSeries>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.TimeSeriess
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(TimeSeries timeSeries, CancellationToken cancellationToken)
    {
        _db.TimeSeriess.Add(timeSeries);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(TimeSeries timeSeries, CancellationToken cancellationToken)
    {
        _db.TimeSeriess.Update(timeSeries);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(TimeSeries timeSeries, CancellationToken cancellationToken)
    {
        _db.TimeSeriess.Remove(timeSeries);
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


    public async Task AddToForecastsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Forecasts
            .Where(forecast =>
                request.ChildIds.Contains(forecast.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    forecast =>
                        EF.Property<Guid?>(
                            forecast,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromForecastsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Forecasts
            .Where(forecast =>
                request.ChildIds.Contains(forecast.Id) &&
                EF.Property<Guid?>(
                    forecast,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    forecast =>
                        EF.Property<Guid?>(
                            forecast,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToAnomaliesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Anomalys
            .Where(anomaly =>
                request.ChildIds.Contains(anomaly.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    anomaly =>
                        EF.Property<Guid?>(
                            anomaly,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromAnomaliesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Anomalys
            .Where(anomaly =>
                request.ChildIds.Contains(anomaly.Id) &&
                EF.Property<Guid?>(
                    anomaly,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    anomaly =>
                        EF.Property<Guid?>(
                            anomaly,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }

}

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
}

using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class AnomalyRepository : IAnomalyRepository
{
    private readonly ApplicationDbContext _db;

    public AnomalyRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Anomaly?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Anomalys
            .Include(x => x.TimeSeries)
            .Include(x => x.Alert)
            .Include(x => x.Dataset)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Anomaly>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Anomalys
            .AsNoTracking()
            .Include(x => x.TimeSeries)
            .Include(x => x.Alert)
            .Include(x => x.Dataset)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Anomaly anomaly, CancellationToken cancellationToken)
    {
        _db.Anomalys.Add(anomaly);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Anomaly anomaly, CancellationToken cancellationToken)
    {
        _db.Anomalys.Update(anomaly);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Anomaly anomaly, CancellationToken cancellationToken)
    {
        _db.Anomalys.Remove(anomaly);
        await _db.SaveChangesAsync(cancellationToken);
    }
}

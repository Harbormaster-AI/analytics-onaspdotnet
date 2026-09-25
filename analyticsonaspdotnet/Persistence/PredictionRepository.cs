
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class PredictionRepository : IPredictionRepository
{
    private readonly ApplicationDbContext _db;

    public PredictionRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Prediction?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Predictions
            .Include(x => x.Endpoint)
            .Include(x => x.ModelVersion)
            .Include(x => x.Dataset)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Prediction>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Predictions
            .AsNoTracking()
            .Include(x => x.Endpoint)
            .Include(x => x.ModelVersion)
            .Include(x => x.Dataset)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Prediction prediction, CancellationToken cancellationToken)
    {
        _db.Predictions.Add(prediction);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Prediction prediction, CancellationToken cancellationToken)
    {
        _db.Predictions.Update(prediction);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Prediction prediction, CancellationToken cancellationToken)
    {
        _db.Predictions.Remove(prediction);
        await _db.SaveChangesAsync(cancellationToken);
    }

}

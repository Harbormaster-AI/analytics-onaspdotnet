
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class InferenceEndpointRepository : IInferenceEndpointRepository
{
    private readonly ApplicationDbContext _db;

    public InferenceEndpointRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<InferenceEndpoint?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.InferenceEndpoints
            .Include(x => x.ModelVersion)
            .Include(x => x.Workspace)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<InferenceEndpoint>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.InferenceEndpoints
            .AsNoTracking()
            .Include(x => x.ModelVersion)
            .Include(x => x.Workspace)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(InferenceEndpoint inferenceEndpoint, CancellationToken cancellationToken)
    {
        _db.InferenceEndpoints.Add(inferenceEndpoint);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(InferenceEndpoint inferenceEndpoint, CancellationToken cancellationToken)
    {
        _db.InferenceEndpoints.Update(inferenceEndpoint);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(InferenceEndpoint inferenceEndpoint, CancellationToken cancellationToken)
    {
        _db.InferenceEndpoints.Remove(inferenceEndpoint);
        await _db.SaveChangesAsync(cancellationToken);
    }


    public async Task AddToPredictionsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Predictions
            .Where(prediction =>
                request.ChildIds.Contains(prediction.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    prediction =>
                        EF.Property<Guid?>(
                            prediction,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromPredictionsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Predictions
            .Where(prediction =>
                request.ChildIds.Contains(prediction.Id) &&
                EF.Property<Guid?>(
                    prediction,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    prediction =>
                        EF.Property<Guid?>(
                            prediction,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }

}

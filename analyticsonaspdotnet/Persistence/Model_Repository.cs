
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class Model_Repository : IModel_Repository
{
    private readonly ApplicationDbContext _db;

    public Model_Repository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Model_?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Model_s
            .Include(x => x.Workspace)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Model_>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Model_s
            .AsNoTracking()
            .Include(x => x.Workspace)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Model_ model_, CancellationToken cancellationToken)
    {
        _db.Model_s.Add(model_);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Model_ model_, CancellationToken cancellationToken)
    {
        _db.Model_s.Update(model_);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Model_ model_, CancellationToken cancellationToken)
    {
        _db.Model_s.Remove(model_);
        await _db.SaveChangesAsync(cancellationToken);
    }


    public async Task AddToVersionsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.ModelVersions
            .Where(modelVersion =>
                request.ChildIds.Contains(modelVersion.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    modelVersion =>
                        EF.Property<Guid?>(
                            modelVersion,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromVersionsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.ModelVersions
            .Where(modelVersion =>
                request.ChildIds.Contains(modelVersion.Id) &&
                EF.Property<Guid?>(
                    modelVersion,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    modelVersion =>
                        EF.Property<Guid?>(
                            modelVersion,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToFeatureSetsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.FeatureSets
            .Where(featureSet =>
                request.ChildIds.Contains(featureSet.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    featureSet =>
                        EF.Property<Guid?>(
                            featureSet,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromFeatureSetsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.FeatureSets
            .Where(featureSet =>
                request.ChildIds.Contains(featureSet.Id) &&
                EF.Property<Guid?>(
                    featureSet,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    featureSet =>
                        EF.Property<Guid?>(
                            featureSet,
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


    public async Task AddToTagsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Tags
            .Where(tag =>
                request.ChildIds.Contains(tag.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    tag =>
                        EF.Property<Guid?>(
                            tag,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromTagsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Tags
            .Where(tag =>
                request.ChildIds.Contains(tag.Id) &&
                EF.Property<Guid?>(
                    tag,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    tag =>
                        EF.Property<Guid?>(
                            tag,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }

}

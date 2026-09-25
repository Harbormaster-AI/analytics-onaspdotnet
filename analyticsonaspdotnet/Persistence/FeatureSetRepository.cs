
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class FeatureSetRepository : IFeatureSetRepository
{
    private readonly ApplicationDbContext _db;

    public FeatureSetRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<FeatureSet?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.FeatureSets
            .Include(x => x.Workspace)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<FeatureSet>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.FeatureSets
            .AsNoTracking()
            .Include(x => x.Workspace)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(FeatureSet featureSet, CancellationToken cancellationToken)
    {
        _db.FeatureSets.Add(featureSet);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(FeatureSet featureSet, CancellationToken cancellationToken)
    {
        _db.FeatureSets.Update(featureSet);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(FeatureSet featureSet, CancellationToken cancellationToken)
    {
        _db.FeatureSets.Remove(featureSet);
        await _db.SaveChangesAsync(cancellationToken);
    }


    public async Task AddToFeaturesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Features
            .Where(feature =>
                request.ChildIds.Contains(feature.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    feature =>
                        EF.Property<Guid?>(
                            feature,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromFeaturesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Features
            .Where(feature =>
                request.ChildIds.Contains(feature.Id) &&
                EF.Property<Guid?>(
                    feature,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    feature =>
                        EF.Property<Guid?>(
                            feature,
                            "FraudSignal_Id"),
                    (Guid?)null));
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


    public async Task AddToModelsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Model_s
            .Where(model_ =>
                request.ChildIds.Contains(model_.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    model_ =>
                        EF.Property<Guid?>(
                            model_,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromModelsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Model_s
            .Where(model_ =>
                request.ChildIds.Contains(model_.Id) &&
                EF.Property<Guid?>(
                    model_,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    model_ =>
                        EF.Property<Guid?>(
                            model_,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToModelVersionsAsync(
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

    public async Task RemoveFromModelVersionsAsync(
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

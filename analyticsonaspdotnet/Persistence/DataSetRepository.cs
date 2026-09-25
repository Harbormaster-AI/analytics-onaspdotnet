
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class DataSetRepository : IDataSetRepository
{
    private readonly ApplicationDbContext _db;

    public DataSetRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<DataSet?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.DataSets
            .Include(x => x.Workspace)
            .Include(x => x.LineageNode)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<DataSet>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.DataSets
            .AsNoTracking()
            .Include(x => x.Workspace)
            .Include(x => x.LineageNode)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(DataSet dataSet, CancellationToken cancellationToken)
    {
        _db.DataSets.Add(dataSet);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(DataSet dataSet, CancellationToken cancellationToken)
    {
        _db.DataSets.Update(dataSet);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(DataSet dataSet, CancellationToken cancellationToken)
    {
        _db.DataSets.Remove(dataSet);
        await _db.SaveChangesAsync(cancellationToken);
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


    public async Task AddToSemanticModelsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.SemanticModels
            .Where(semanticModel =>
                request.ChildIds.Contains(semanticModel.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    semanticModel =>
                        EF.Property<Guid?>(
                            semanticModel,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromSemanticModelsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.SemanticModels
            .Where(semanticModel =>
                request.ChildIds.Contains(semanticModel.Id) &&
                EF.Property<Guid?>(
                    semanticModel,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    semanticModel =>
                        EF.Property<Guid?>(
                            semanticModel,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToDimensionsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Dimensions
            .Where(dimension =>
                request.ChildIds.Contains(dimension.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    dimension =>
                        EF.Property<Guid?>(
                            dimension,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromDimensionsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Dimensions
            .Where(dimension =>
                request.ChildIds.Contains(dimension.Id) &&
                EF.Property<Guid?>(
                    dimension,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    dimension =>
                        EF.Property<Guid?>(
                            dimension,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToMeasuresAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Measures
            .Where(measure =>
                request.ChildIds.Contains(measure.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    measure =>
                        EF.Property<Guid?>(
                            measure,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromMeasuresAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Measures
            .Where(measure =>
                request.ChildIds.Contains(measure.Id) &&
                EF.Property<Guid?>(
                    measure,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    measure =>
                        EF.Property<Guid?>(
                            measure,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToMetricsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Metrics
            .Where(metric =>
                request.ChildIds.Contains(metric.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    metric =>
                        EF.Property<Guid?>(
                            metric,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromMetricsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Metrics
            .Where(metric =>
                request.ChildIds.Contains(metric.Id) &&
                EF.Property<Guid?>(
                    metric,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    metric =>
                        EF.Property<Guid?>(
                            metric,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToQualityRulesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.QualityRules
            .Where(qualityRule =>
                request.ChildIds.Contains(qualityRule.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    qualityRule =>
                        EF.Property<Guid?>(
                            qualityRule,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromQualityRulesAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.QualityRules
            .Where(qualityRule =>
                request.ChildIds.Contains(qualityRule.Id) &&
                EF.Property<Guid?>(
                    qualityRule,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    qualityRule =>
                        EF.Property<Guid?>(
                            qualityRule,
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

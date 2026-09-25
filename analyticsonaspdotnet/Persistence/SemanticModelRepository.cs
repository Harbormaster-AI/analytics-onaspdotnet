
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class SemanticModelRepository : ISemanticModelRepository
{
    private readonly ApplicationDbContext _db;

    public SemanticModelRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<SemanticModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.SemanticModels
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<SemanticModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.SemanticModels
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(SemanticModel semanticModel, CancellationToken cancellationToken)
    {
        _db.SemanticModels.Add(semanticModel);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(SemanticModel semanticModel, CancellationToken cancellationToken)
    {
        _db.SemanticModels.Update(semanticModel);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(SemanticModel semanticModel, CancellationToken cancellationToken)
    {
        _db.SemanticModels.Remove(semanticModel);
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


    public async Task AddToGlossaryTermsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.BusinessGlossaryTerms
            .Where(businessGlossaryTerm =>
                request.ChildIds.Contains(businessGlossaryTerm.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    businessGlossaryTerm =>
                        EF.Property<Guid?>(
                            businessGlossaryTerm,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromGlossaryTermsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.BusinessGlossaryTerms
            .Where(businessGlossaryTerm =>
                request.ChildIds.Contains(businessGlossaryTerm.Id) &&
                EF.Property<Guid?>(
                    businessGlossaryTerm,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    businessGlossaryTerm =>
                        EF.Property<Guid?>(
                            businessGlossaryTerm,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }

}


using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class BusinessGlossaryTermRepository : IBusinessGlossaryTermRepository
{
    private readonly ApplicationDbContext _db;

    public BusinessGlossaryTermRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<BusinessGlossaryTerm?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.BusinessGlossaryTerms
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<BusinessGlossaryTerm>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.BusinessGlossaryTerms
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(BusinessGlossaryTerm businessGlossaryTerm, CancellationToken cancellationToken)
    {
        _db.BusinessGlossaryTerms.Add(businessGlossaryTerm);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(BusinessGlossaryTerm businessGlossaryTerm, CancellationToken cancellationToken)
    {
        _db.BusinessGlossaryTerms.Update(businessGlossaryTerm);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(BusinessGlossaryTerm businessGlossaryTerm, CancellationToken cancellationToken)
    {
        _db.BusinessGlossaryTerms.Remove(businessGlossaryTerm);
        await _db.SaveChangesAsync(cancellationToken);
    }


    public async Task AddToRelatedTermsAsync(
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

    public async Task RemoveFromRelatedTermsAsync(
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

}

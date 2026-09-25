
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class MeasureRepository : IMeasureRepository
{
    private readonly ApplicationDbContext _db;

    public MeasureRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Measure?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Measures
            .Include(x => x.SemanticModel)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Measure>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Measures
            .AsNoTracking()
            .Include(x => x.SemanticModel)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Measure measure, CancellationToken cancellationToken)
    {
        _db.Measures.Add(measure);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Measure measure, CancellationToken cancellationToken)
    {
        _db.Measures.Update(measure);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Measure measure, CancellationToken cancellationToken)
    {
        _db.Measures.Remove(measure);
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


using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class DimensionRepository : IDimensionRepository
{
    private readonly ApplicationDbContext _db;

    public DimensionRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Dimension?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Dimensions
            .Include(x => x.SemanticModel)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Dimension>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Dimensions
            .AsNoTracking()
            .Include(x => x.SemanticModel)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Dimension dimension, CancellationToken cancellationToken)
    {
        _db.Dimensions.Add(dimension);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Dimension dimension, CancellationToken cancellationToken)
    {
        _db.Dimensions.Update(dimension);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Dimension dimension, CancellationToken cancellationToken)
    {
        _db.Dimensions.Remove(dimension);
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

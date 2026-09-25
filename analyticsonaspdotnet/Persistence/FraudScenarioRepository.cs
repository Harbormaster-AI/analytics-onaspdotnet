
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class FraudScenarioRepository : IFraudScenarioRepository
{
    private readonly ApplicationDbContext _db;

    public FraudScenarioRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<FraudScenario?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.FraudScenarios
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<FraudScenario>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.FraudScenarios
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(FraudScenario fraudScenario, CancellationToken cancellationToken)
    {
        _db.FraudScenarios.Add(fraudScenario);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(FraudScenario fraudScenario, CancellationToken cancellationToken)
    {
        _db.FraudScenarios.Update(fraudScenario);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(FraudScenario fraudScenario, CancellationToken cancellationToken)
    {
        _db.FraudScenarios.Remove(fraudScenario);
        await _db.SaveChangesAsync(cancellationToken);
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


    public async Task AddToAlertsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Alerts
            .Where(alert =>
                request.ChildIds.Contains(alert.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    alert =>
                        EF.Property<Guid?>(
                            alert,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromAlertsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.Alerts
            .Where(alert =>
                request.ChildIds.Contains(alert.Id) &&
                EF.Property<Guid?>(
                    alert,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    alert =>
                        EF.Property<Guid?>(
                            alert,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }


    public async Task AddToSignalsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.FraudSignals
            .Where(fraudSignal =>
                request.ChildIds.Contains(fraudSignal.Id))
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    fraudSignal =>
                        EF.Property<Guid?>(
                            fraudSignal,
                            "FraudSignal_Id"),
                    request.ParentId));
    }

    public async Task RemoveFromSignalsAsync(
        MultipleAssociationRequest request,
        CancellationToken cancellationToken)
    {
        await _db.FraudSignals
            .Where(fraudSignal =>
                request.ChildIds.Contains(fraudSignal.Id) &&
                EF.Property<Guid?>(
                    fraudSignal,
                    "FraudSignal_Id") == request.ParentId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(
                    fraudSignal =>
                        EF.Property<Guid?>(
                            fraudSignal,
                            "FraudSignal_Id"),
                    (Guid?)null));
    }

}


using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Domain;

using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class RecommendationScenarioRepository : IRecommendationScenarioRepository
{
    private readonly ApplicationDbContext _db;

    public RecommendationScenarioRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<RecommendationScenario?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.RecommendationScenarios
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<RecommendationScenario>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.RecommendationScenarios
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(RecommendationScenario recommendationScenario, CancellationToken cancellationToken)
    {
        _db.RecommendationScenarios.Add(recommendationScenario);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(RecommendationScenario recommendationScenario, CancellationToken cancellationToken)
    {
        _db.RecommendationScenarios.Update(recommendationScenario);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(RecommendationScenario recommendationScenario, CancellationToken cancellationToken)
    {
        _db.RecommendationScenarios.Remove(recommendationScenario);
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

}


using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class RecommendationScenarioEndpoints
{
    public static IEndpointRouteBuilder MapRecommendationScenarioEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/recommendationScenario").WithTags("RecommendationScenarios");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);


    group.MapPut("/addToModels", AddToModels);
    group.MapPut("/removeFromModels", RemoveFromModels);

    group.MapPut("/addToDatasets", AddToDatasets);
    group.MapPut("/removeFromDatasets", RemoveFromDatasets);

    group.MapPut("/addToExperiments", AddToExperiments);
    group.MapPut("/removeFromExperiments", RemoveFromExperiments);

    group.MapPut("/addToAlerts", AddToAlerts);
    group.MapPut("/removeFromAlerts", RemoveFromAlerts);


        return app;
    }

    private static async Task<IResult> Create(
        RecommendationScenarioRequest request,
        IRecommendationScenarioService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToRecommendationScenario( request );

        try
        {
            await service.Create(model, cancellationToken);
        }
        catch (InvalidOperationException ex)
        {
            return Results.BadRequest(new { error = ex.Message });
        }

        return Results.NoContent();
    }

    private static async Task<IResult> Update(
        RecommendationScenarioRequest request,
        IRecommendationScenarioService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToRecommendationScenario( request );

        try
        {
            var updated = await service.Update(model, cancellationToken);
            return updated ? Results.NoContent() : Results.NotFound();
        }
        catch (InvalidOperationException ex)
        {
            return Results.BadRequest(new { error = ex.Message });
        }
    }


    private static async Task<IResult> Get(
        IdentifierRequest identifier,
        IRecommendationScenarioService service,
        CancellationToken cancellationToken) {

        var recommendationScenario = await service.Get(identifier, cancellationToken);
        return recommendationScenario is null ? Results.NotFound() : Results.Ok( recommendationScenario );
    }


    private static async Task<IResult> GetAll(
        IRecommendationScenarioService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( RecommendationScenarioResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IRecommendationScenarioService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToModels(
        MultipleAssociationRequest request,
        IRecommendationScenarioService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToModels(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromModels(
        MultipleAssociationRequest request,
        IRecommendationScenarioService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromModels(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToDatasets(
        MultipleAssociationRequest request,
        IRecommendationScenarioService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDatasets(
        MultipleAssociationRequest request,
        IRecommendationScenarioService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToExperiments(
        MultipleAssociationRequest request,
        IRecommendationScenarioService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToExperiments(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromExperiments(
        MultipleAssociationRequest request,
        IRecommendationScenarioService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromExperiments(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToAlerts(
        MultipleAssociationRequest request,
        IRecommendationScenarioService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToAlerts(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromAlerts(
        MultipleAssociationRequest request,
        IRecommendationScenarioService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromAlerts(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static RecommendationScenario mapRequestToRecommendationScenario( RecommendationScenarioRequest request ) {
        var model = new RecommendationScenario
        {
            Id = request.Id,
            Name = request.Name,
            Objective = request.Objective,
            RecommendationType = request.RecommendationType,
        };
        return model;
    }

}

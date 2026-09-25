
using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class FraudScenarioEndpoints
{
    public static IEndpointRouteBuilder MapFraudScenarioEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/fraudScenario").WithTags("FraudScenarios");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);


    group.MapPut("/addToModels", AddToModels);
    group.MapPut("/removeFromModels", RemoveFromModels);

    group.MapPut("/addToDatasets", AddToDatasets);
    group.MapPut("/removeFromDatasets", RemoveFromDatasets);

    group.MapPut("/addToAlerts", AddToAlerts);
    group.MapPut("/removeFromAlerts", RemoveFromAlerts);

    group.MapPut("/addToSignals", AddToSignals);
    group.MapPut("/removeFromSignals", RemoveFromSignals);


        return app;
    }

    private static async Task<IResult> Create(
        FraudScenarioRequest request,
        IFraudScenarioService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToFraudScenario( request );

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
        FraudScenarioRequest request,
        IFraudScenarioService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToFraudScenario( request );

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
        IFraudScenarioService service,
        CancellationToken cancellationToken) {

        var fraudScenario = await service.Get(identifier, cancellationToken);
        return fraudScenario is null ? Results.NotFound() : Results.Ok( fraudScenario );
    }


    private static async Task<IResult> GetAll(
        IFraudScenarioService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( FraudScenarioResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IFraudScenarioService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToModels(
        MultipleAssociationRequest request,
        IFraudScenarioService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToModels(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromModels(
        MultipleAssociationRequest request,
        IFraudScenarioService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromModels(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToDatasets(
        MultipleAssociationRequest request,
        IFraudScenarioService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDatasets(
        MultipleAssociationRequest request,
        IFraudScenarioService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToAlerts(
        MultipleAssociationRequest request,
        IFraudScenarioService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToAlerts(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromAlerts(
        MultipleAssociationRequest request,
        IFraudScenarioService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromAlerts(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToSignals(
        MultipleAssociationRequest request,
        IFraudScenarioService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToSignals(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromSignals(
        MultipleAssociationRequest request,
        IFraudScenarioService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromSignals(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static FraudScenario mapRequestToFraudScenario( FraudScenarioRequest request ) {
        var model = new FraudScenario
        {
            Id = request.Id,
            Name = request.Name,
            RiskAppetite = request.RiskAppetite,
            DetectionType = request.DetectionType,
        };
        return model;
    }

}

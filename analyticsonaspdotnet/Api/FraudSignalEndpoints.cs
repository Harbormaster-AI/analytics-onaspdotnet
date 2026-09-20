using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class FraudSignalEndpoints
{
    public static IEndpointRouteBuilder MapFraudSignalEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/fraudSignal").WithTags("FraudSignals");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignScenario", AssignScenario);
        group.MapPut("/unassignScenario", UnassignScenario);
        group.MapPut("/assignDataset", AssignDataset);
        group.MapPut("/unassignDataset", UnassignDataset);
        group.MapPut("/assignModelVersion", AssignModelVersion);
        group.MapPut("/unassignModelVersion", UnassignModelVersion);


        return app;
    }

    private static async Task<IResult> Create(
        FraudSignalRequest request,
        IFraudSignalService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToFraudSignal( request );

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
        FraudSignalRequest request,
        IFraudSignalService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToFraudSignal( request );

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
        IFraudSignalService service,
        CancellationToken cancellationToken) {

        var fraudSignal = await service.Get(identifier, cancellationToken);
        return fraudSignal is null ? Results.NotFound() : Results.Ok( fraudSignal );
    }


    private static async Task<IResult> GetAll(
        IFraudSignalService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( FraudSignalResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IFraudSignalService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignScenario(
        AssociationRequest request,
        IFraudSignalService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignScenario(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignScenario(
    AssociationRequest request,
    IFraudSignalService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignScenario(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignDataset(
        AssociationRequest request,
        IFraudSignalService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignDataset(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignDataset(
    AssociationRequest request,
    IFraudSignalService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignDataset(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignModelVersion(
        AssociationRequest request,
        IFraudSignalService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignModelVersion(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignModelVersion(
    AssociationRequest request,
    IFraudSignalService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignModelVersion(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static FraudSignal mapRequestToFraudSignal( FraudSignalRequest request ) {
        var model = new FraudSignal
        {
            Id = request.Id,
            Name = request.Name,
            RuleLogic = request.RuleLogic,
            SignalType = request.SignalType,
        };
        return model;
    }

}

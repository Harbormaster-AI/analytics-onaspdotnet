using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class AnomalyEndpoints
{
    public static IEndpointRouteBuilder MapAnomalyEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/anomaly").WithTags("Anomalys");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignTimeSeries", AssignTimeSeries);
        group.MapPut("/unassignTimeSeries", UnassignTimeSeries);
        group.MapPut("/assignAlert", AssignAlert);
        group.MapPut("/unassignAlert", UnassignAlert);
        group.MapPut("/assignDataset", AssignDataset);
        group.MapPut("/unassignDataset", UnassignDataset);


        return app;
    }

    private static async Task<IResult> Create(
        AnomalyRequest request,
        IAnomalyService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToAnomaly( request );

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
        AnomalyRequest request,
        IAnomalyService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToAnomaly( request );

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
        IAnomalyService service,
        CancellationToken cancellationToken) {

        var anomaly = await service.Get(identifier, cancellationToken);
        return anomaly is null ? Results.NotFound() : Results.Ok( anomaly );
    }


    private static async Task<IResult> GetAll(
        IAnomalyService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( AnomalyResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IAnomalyService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignTimeSeries(
        AssociationRequest request,
        IAnomalyService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignTimeSeries(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignTimeSeries(
    AssociationRequest request,
    IAnomalyService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignTimeSeries(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignAlert(
        AssociationRequest request,
        IAnomalyService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignAlert(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignAlert(
    AssociationRequest request,
    IAnomalyService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignAlert(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignDataset(
        AssociationRequest request,
        IAnomalyService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignDataset(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignDataset(
    AssociationRequest request,
    IAnomalyService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignDataset(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static Anomaly mapRequestToAnomaly( AnomalyRequest request ) {
        var model = new Anomaly
        {
            Id = request.Id,
            OccurredAt = request.OccurredAt,
            Details = request.Details,
            AnomalyType = request.AnomalyType,
            Severity = request.Severity,
        };
        return model;
    }

}

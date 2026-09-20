using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class PredictionEndpoints
{
    public static IEndpointRouteBuilder MapPredictionEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/prediction").WithTags("Predictions");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignEndpoint", AssignEndpoint);
        group.MapPut("/unassignEndpoint", UnassignEndpoint);
        group.MapPut("/assignModelVersion", AssignModelVersion);
        group.MapPut("/unassignModelVersion", UnassignModelVersion);
        group.MapPut("/assignDataset", AssignDataset);
        group.MapPut("/unassignDataset", UnassignDataset);


        return app;
    }

    private static async Task<IResult> Create(
        PredictionRequest request,
        IPredictionService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToPrediction( request );

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
        PredictionRequest request,
        IPredictionService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToPrediction( request );

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
        IPredictionService service,
        CancellationToken cancellationToken) {

        var prediction = await service.Get(identifier, cancellationToken);
        return prediction is null ? Results.NotFound() : Results.Ok( prediction );
    }


    private static async Task<IResult> GetAll(
        IPredictionService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( PredictionResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IPredictionService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignEndpoint(
        AssociationRequest request,
        IPredictionService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignEndpoint(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignEndpoint(
    AssociationRequest request,
    IPredictionService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignEndpoint(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignModelVersion(
        AssociationRequest request,
        IPredictionService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignModelVersion(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignModelVersion(
    AssociationRequest request,
    IPredictionService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignModelVersion(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignDataset(
        AssociationRequest request,
        IPredictionService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignDataset(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignDataset(
    AssociationRequest request,
    IPredictionService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignDataset(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static Prediction mapRequestToPrediction( PredictionRequest request ) {
        var model = new Prediction
        {
            Id = request.Id,
            ReferenceKey = request.ReferenceKey,
            PredictedAt = request.PredictedAt,
            Score = request.Score,
        };
        return model;
    }

}

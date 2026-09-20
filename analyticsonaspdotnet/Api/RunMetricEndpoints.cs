using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class RunMetricEndpoints
{
    public static IEndpointRouteBuilder MapRunMetricEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/runMetric").WithTags("RunMetrics");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignTrainingRun", AssignTrainingRun);
        group.MapPut("/unassignTrainingRun", UnassignTrainingRun);
        group.MapPut("/assignMetric", AssignMetric);
        group.MapPut("/unassignMetric", UnassignMetric);
        group.MapPut("/assignDataset", AssignDataset);
        group.MapPut("/unassignDataset", UnassignDataset);


        return app;
    }

    private static async Task<IResult> Create(
        RunMetricRequest request,
        IRunMetricService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToRunMetric( request );

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
        RunMetricRequest request,
        IRunMetricService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToRunMetric( request );

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
        IRunMetricService service,
        CancellationToken cancellationToken) {

        var runMetric = await service.Get(identifier, cancellationToken);
        return runMetric is null ? Results.NotFound() : Results.Ok( runMetric );
    }


    private static async Task<IResult> GetAll(
        IRunMetricService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( RunMetricResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IRunMetricService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignTrainingRun(
        AssociationRequest request,
        IRunMetricService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignTrainingRun(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignTrainingRun(
    AssociationRequest request,
    IRunMetricService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignTrainingRun(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignMetric(
        AssociationRequest request,
        IRunMetricService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignMetric(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignMetric(
    AssociationRequest request,
    IRunMetricService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignMetric(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignDataset(
        AssociationRequest request,
        IRunMetricService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignDataset(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignDataset(
    AssociationRequest request,
    IRunMetricService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignDataset(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static RunMetric mapRequestToRunMetric( RunMetricRequest request ) {
        var model = new RunMetric
        {
            Id = request.Id,
            Name = request.Name,
            Value = request.Value,
        };
        return model;
    }

}

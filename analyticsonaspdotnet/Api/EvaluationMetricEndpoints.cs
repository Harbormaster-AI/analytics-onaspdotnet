
using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class EvaluationMetricEndpoints
{
    public static IEndpointRouteBuilder MapEvaluationMetricEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/evaluationMetric").WithTags("EvaluationMetrics");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignModelVersion", AssignModelVersion);
        group.MapPut("/unassignModelVersion", UnassignModelVersion);
        group.MapPut("/assignMetric", AssignMetric);
        group.MapPut("/unassignMetric", UnassignMetric);
        group.MapPut("/assignDataset", AssignDataset);
        group.MapPut("/unassignDataset", UnassignDataset);


        return app;
    }

    private static async Task<IResult> Create(
        EvaluationMetricRequest request,
        IEvaluationMetricService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToEvaluationMetric( request );

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
        EvaluationMetricRequest request,
        IEvaluationMetricService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToEvaluationMetric( request );

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
        IEvaluationMetricService service,
        CancellationToken cancellationToken) {

        var evaluationMetric = await service.Get(identifier, cancellationToken);
        return evaluationMetric is null ? Results.NotFound() : Results.Ok( evaluationMetric );
    }


    private static async Task<IResult> GetAll(
        IEvaluationMetricService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( EvaluationMetricResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IEvaluationMetricService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignModelVersion(
        AssociationRequest request,
        IEvaluationMetricService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignModelVersion(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignModelVersion(
    AssociationRequest request,
    IEvaluationMetricService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignModelVersion(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignMetric(
        AssociationRequest request,
        IEvaluationMetricService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignMetric(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignMetric(
    AssociationRequest request,
    IEvaluationMetricService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignMetric(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignDataset(
        AssociationRequest request,
        IEvaluationMetricService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignDataset(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignDataset(
    AssociationRequest request,
    IEvaluationMetricService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignDataset(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static EvaluationMetric mapRequestToEvaluationMetric( EvaluationMetricRequest request ) {
        var model = new EvaluationMetric
        {
            Id = request.Id,
            Name = request.Name,
            Value = request.Value,
        };
        return model;
    }

}

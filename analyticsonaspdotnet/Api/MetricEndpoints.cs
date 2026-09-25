
using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class MetricEndpoints
{
    public static IEndpointRouteBuilder MapMetricEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/metric").WithTags("Metrics");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignSemanticModel", AssignSemanticModel);
        group.MapPut("/unassignSemanticModel", UnassignSemanticModel);

    group.MapPut("/addToDatasets", AddToDatasets);
    group.MapPut("/removeFromDatasets", RemoveFromDatasets);

    group.MapPut("/addToGlossaryTerms", AddToGlossaryTerms);
    group.MapPut("/removeFromGlossaryTerms", RemoveFromGlossaryTerms);

    group.MapPut("/addToAlerts", AddToAlerts);
    group.MapPut("/removeFromAlerts", RemoveFromAlerts);

    group.MapPut("/addToVisualizations", AddToVisualizations);
    group.MapPut("/removeFromVisualizations", RemoveFromVisualizations);


        return app;
    }

    private static async Task<IResult> Create(
        MetricRequest request,
        IMetricService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToMetric( request );

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
        MetricRequest request,
        IMetricService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToMetric( request );

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
        IMetricService service,
        CancellationToken cancellationToken) {

        var metric = await service.Get(identifier, cancellationToken);
        return metric is null ? Results.NotFound() : Results.Ok( metric );
    }


    private static async Task<IResult> GetAll(
        IMetricService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( MetricResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IMetricService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignSemanticModel(
        AssociationRequest request,
        IMetricService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignSemanticModel(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignSemanticModel(
    AssociationRequest request,
    IMetricService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignSemanticModel(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToDatasets(
        MultipleAssociationRequest request,
        IMetricService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDatasets(
        MultipleAssociationRequest request,
        IMetricService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToGlossaryTerms(
        MultipleAssociationRequest request,
        IMetricService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToGlossaryTerms(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromGlossaryTerms(
        MultipleAssociationRequest request,
        IMetricService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromGlossaryTerms(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToAlerts(
        MultipleAssociationRequest request,
        IMetricService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToAlerts(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromAlerts(
        MultipleAssociationRequest request,
        IMetricService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromAlerts(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToVisualizations(
        MultipleAssociationRequest request,
        IMetricService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToVisualizations(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromVisualizations(
        MultipleAssociationRequest request,
        IMetricService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromVisualizations(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static Metric mapRequestToMetric( MetricRequest request ) {
        var model = new Metric
        {
            Id = request.Id,
            Name = request.Name,
            Expression = request.Expression,
            Unit = request.Unit,
            MetricType = request.MetricType,
        };
        return model;
    }

}

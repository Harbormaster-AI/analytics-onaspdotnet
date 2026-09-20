using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class VisualizationEndpoints
{
    public static IEndpointRouteBuilder MapVisualizationEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/visualization").WithTags("Visualizations");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignDashboard", AssignDashboard);
        group.MapPut("/unassignDashboard", UnassignDashboard);
        group.MapPut("/assignReport", AssignReport);
        group.MapPut("/unassignReport", UnassignReport);

    group.MapPut("/addToMetrics", AddToMetrics);
    group.MapPut("/removeFromMetrics", RemoveFromMetrics);

    group.MapPut("/addToDimensions", AddToDimensions);
    group.MapPut("/removeFromDimensions", RemoveFromDimensions);

    group.MapPut("/addToDatasets", AddToDatasets);
    group.MapPut("/removeFromDatasets", RemoveFromDatasets);


        return app;
    }

    private static async Task<IResult> Create(
        VisualizationRequest request,
        IVisualizationService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToVisualization( request );

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
        VisualizationRequest request,
        IVisualizationService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToVisualization( request );

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
        IVisualizationService service,
        CancellationToken cancellationToken) {

        var visualization = await service.Get(identifier, cancellationToken);
        return visualization is null ? Results.NotFound() : Results.Ok( visualization );
    }


    private static async Task<IResult> GetAll(
        IVisualizationService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( VisualizationResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IVisualizationService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignDashboard(
        AssociationRequest request,
        IVisualizationService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignDashboard(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignDashboard(
    AssociationRequest request,
    IVisualizationService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignDashboard(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignReport(
        AssociationRequest request,
        IVisualizationService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignReport(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignReport(
    AssociationRequest request,
    IVisualizationService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignReport(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToMetrics(
        MultipleAssociationRequest request,
        IVisualizationService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToMetrics(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromMetrics(
        MultipleAssociationRequest request,
        IVisualizationService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromMetrics(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToDimensions(
        MultipleAssociationRequest request,
        IVisualizationService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDimensions(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDimensions(
        MultipleAssociationRequest request,
        IVisualizationService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDimensions(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToDatasets(
        MultipleAssociationRequest request,
        IVisualizationService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDatasets(
        MultipleAssociationRequest request,
        IVisualizationService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static Visualization mapRequestToVisualization( VisualizationRequest request ) {
        var model = new Visualization
        {
            Id = request.Id,
            Title = request.Title,
            Options = request.Options,
            ChartType = request.ChartType,
        };
        return model;
    }

}

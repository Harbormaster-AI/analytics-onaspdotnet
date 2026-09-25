
using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class DashboardEndpoints
{
    public static IEndpointRouteBuilder MapDashboardEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/dashboard").WithTags("Dashboards");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignWorkspace", AssignWorkspace);
        group.MapPut("/unassignWorkspace", UnassignWorkspace);

    group.MapPut("/addToVisualizations", AddToVisualizations);
    group.MapPut("/removeFromVisualizations", RemoveFromVisualizations);

    group.MapPut("/addToReports", AddToReports);
    group.MapPut("/removeFromReports", RemoveFromReports);

    group.MapPut("/addToDatasets", AddToDatasets);
    group.MapPut("/removeFromDatasets", RemoveFromDatasets);

    group.MapPut("/addToAlerts", AddToAlerts);
    group.MapPut("/removeFromAlerts", RemoveFromAlerts);

    group.MapPut("/addToQueries", AddToQueries);
    group.MapPut("/removeFromQueries", RemoveFromQueries);

    group.MapPut("/addToTags", AddToTags);
    group.MapPut("/removeFromTags", RemoveFromTags);


        return app;
    }

    private static async Task<IResult> Create(
        DashboardRequest request,
        IDashboardService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToDashboard( request );

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
        DashboardRequest request,
        IDashboardService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToDashboard( request );

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
        IDashboardService service,
        CancellationToken cancellationToken) {

        var dashboard = await service.Get(identifier, cancellationToken);
        return dashboard is null ? Results.NotFound() : Results.Ok( dashboard );
    }


    private static async Task<IResult> GetAll(
        IDashboardService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( DashboardResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IDashboardService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignWorkspace(
        AssociationRequest request,
        IDashboardService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignWorkspace(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignWorkspace(
    AssociationRequest request,
    IDashboardService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignWorkspace(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToVisualizations(
        MultipleAssociationRequest request,
        IDashboardService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToVisualizations(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromVisualizations(
        MultipleAssociationRequest request,
        IDashboardService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromVisualizations(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToReports(
        MultipleAssociationRequest request,
        IDashboardService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToReports(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromReports(
        MultipleAssociationRequest request,
        IDashboardService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromReports(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToDatasets(
        MultipleAssociationRequest request,
        IDashboardService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDatasets(
        MultipleAssociationRequest request,
        IDashboardService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToAlerts(
        MultipleAssociationRequest request,
        IDashboardService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToAlerts(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromAlerts(
        MultipleAssociationRequest request,
        IDashboardService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromAlerts(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToQueries(
        MultipleAssociationRequest request,
        IDashboardService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToQueries(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromQueries(
        MultipleAssociationRequest request,
        IDashboardService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromQueries(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToTags(
        MultipleAssociationRequest request,
        IDashboardService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToTags(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromTags(
        MultipleAssociationRequest request,
        IDashboardService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromTags(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static Dashboard mapRequestToDashboard( DashboardRequest request ) {
        var model = new Dashboard
        {
            Id = request.Id,
            Title = request.Title,
            Theme = request.Theme,
            Status = request.Status,
        };
        return model;
    }

}

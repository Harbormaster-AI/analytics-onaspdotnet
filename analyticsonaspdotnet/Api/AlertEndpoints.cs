
using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class AlertEndpoints
{
    public static IEndpointRouteBuilder MapAlertEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/alert").WithTags("Alerts");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignMetric", AssignMetric);
        group.MapPut("/unassignMetric", UnassignMetric);
        group.MapPut("/assignDashboard", AssignDashboard);
        group.MapPut("/unassignDashboard", UnassignDashboard);
        group.MapPut("/assignDataset", AssignDataset);
        group.MapPut("/unassignDataset", UnassignDataset);
        group.MapPut("/assignRule", AssignRule);
        group.MapPut("/unassignRule", UnassignRule);

    group.MapPut("/addToAnomalies", AddToAnomalies);
    group.MapPut("/removeFromAnomalies", RemoveFromAnomalies);

    group.MapPut("/addToSubscribers", AddToSubscribers);
    group.MapPut("/removeFromSubscribers", RemoveFromSubscribers);


        return app;
    }

    private static async Task<IResult> Create(
        AlertRequest request,
        IAlertService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToAlert( request );

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
        AlertRequest request,
        IAlertService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToAlert( request );

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
        IAlertService service,
        CancellationToken cancellationToken) {

        var alert = await service.Get(identifier, cancellationToken);
        return alert is null ? Results.NotFound() : Results.Ok( alert );
    }


    private static async Task<IResult> GetAll(
        IAlertService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( AlertResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IAlertService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignMetric(
        AssociationRequest request,
        IAlertService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignMetric(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignMetric(
    AssociationRequest request,
    IAlertService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignMetric(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignDashboard(
        AssociationRequest request,
        IAlertService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignDashboard(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignDashboard(
    AssociationRequest request,
    IAlertService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignDashboard(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignDataset(
        AssociationRequest request,
        IAlertService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignDataset(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignDataset(
    AssociationRequest request,
    IAlertService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignDataset(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignRule(
        AssociationRequest request,
        IAlertService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignRule(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignRule(
    AssociationRequest request,
    IAlertService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignRule(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToAnomalies(
        MultipleAssociationRequest request,
        IAlertService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToAnomalies(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromAnomalies(
        MultipleAssociationRequest request,
        IAlertService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromAnomalies(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToSubscribers(
        MultipleAssociationRequest request,
        IAlertService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToSubscribers(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromSubscribers(
        MultipleAssociationRequest request,
        IAlertService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromSubscribers(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static Alert mapRequestToAlert( AlertRequest request ) {
        var model = new Alert
        {
            Id = request.Id,
            Title = request.Title,
            CreatedAt = request.CreatedAt,
            Severity = request.Severity,
            Status = request.Status,
        };
        return model;
    }

}

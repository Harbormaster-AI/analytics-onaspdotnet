
using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class BIQueryEndpoints
{
    public static IEndpointRouteBuilder MapBIQueryEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/bIQuery").WithTags("BIQuerys");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignWorkspace", AssignWorkspace);
        group.MapPut("/unassignWorkspace", UnassignWorkspace);

    group.MapPut("/addToDatasets", AddToDatasets);
    group.MapPut("/removeFromDatasets", RemoveFromDatasets);

    group.MapPut("/addToReports", AddToReports);
    group.MapPut("/removeFromReports", RemoveFromReports);

    group.MapPut("/addToDashboards", AddToDashboards);
    group.MapPut("/removeFromDashboards", RemoveFromDashboards);

    group.MapPut("/addToNotebooks", AddToNotebooks);
    group.MapPut("/removeFromNotebooks", RemoveFromNotebooks);


        return app;
    }

    private static async Task<IResult> Create(
        BIQueryRequest request,
        IBIQueryService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToBIQuery( request );

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
        BIQueryRequest request,
        IBIQueryService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToBIQuery( request );

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
        IBIQueryService service,
        CancellationToken cancellationToken) {

        var bIQuery = await service.Get(identifier, cancellationToken);
        return bIQuery is null ? Results.NotFound() : Results.Ok( bIQuery );
    }


    private static async Task<IResult> GetAll(
        IBIQueryService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( BIQueryResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IBIQueryService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignWorkspace(
        AssociationRequest request,
        IBIQueryService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignWorkspace(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignWorkspace(
    AssociationRequest request,
    IBIQueryService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignWorkspace(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToDatasets(
        MultipleAssociationRequest request,
        IBIQueryService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDatasets(
        MultipleAssociationRequest request,
        IBIQueryService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToReports(
        MultipleAssociationRequest request,
        IBIQueryService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToReports(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromReports(
        MultipleAssociationRequest request,
        IBIQueryService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromReports(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToDashboards(
        MultipleAssociationRequest request,
        IBIQueryService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDashboards(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDashboards(
        MultipleAssociationRequest request,
        IBIQueryService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDashboards(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToNotebooks(
        MultipleAssociationRequest request,
        IBIQueryService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToNotebooks(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromNotebooks(
        MultipleAssociationRequest request,
        IBIQueryService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromNotebooks(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static BIQuery mapRequestToBIQuery( BIQueryRequest request ) {
        var model = new BIQuery
        {
            Id = request.Id,
            Name = request.Name,
            Text = request.Text,
            Dialect = request.Dialect,
        };
        return model;
    }

}

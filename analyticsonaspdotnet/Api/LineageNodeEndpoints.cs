using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class LineageNodeEndpoints
{
    public static IEndpointRouteBuilder MapLineageNodeEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/lineageNode").WithTags("LineageNodes");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignWorkspace", AssignWorkspace);
        group.MapPut("/unassignWorkspace", UnassignWorkspace);

    group.MapPut("/addToInputs", AddToInputs);
    group.MapPut("/removeFromInputs", RemoveFromInputs);

    group.MapPut("/addToOutputs", AddToOutputs);
    group.MapPut("/removeFromOutputs", RemoveFromOutputs);

    group.MapPut("/addToDatasets", AddToDatasets);
    group.MapPut("/removeFromDatasets", RemoveFromDatasets);

    group.MapPut("/addToModels", AddToModels);
    group.MapPut("/removeFromModels", RemoveFromModels);

    group.MapPut("/addToPipelines", AddToPipelines);
    group.MapPut("/removeFromPipelines", RemoveFromPipelines);

    group.MapPut("/addToDashboards", AddToDashboards);
    group.MapPut("/removeFromDashboards", RemoveFromDashboards);

    group.MapPut("/addToReports", AddToReports);
    group.MapPut("/removeFromReports", RemoveFromReports);


        return app;
    }

    private static async Task<IResult> Create(
        LineageNodeRequest request,
        ILineageNodeService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToLineageNode( request );

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
        LineageNodeRequest request,
        ILineageNodeService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToLineageNode( request );

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
        ILineageNodeService service,
        CancellationToken cancellationToken) {

        var lineageNode = await service.Get(identifier, cancellationToken);
        return lineageNode is null ? Results.NotFound() : Results.Ok( lineageNode );
    }


    private static async Task<IResult> GetAll(
        ILineageNodeService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( LineageNodeResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        ILineageNodeService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignWorkspace(
        AssociationRequest request,
        ILineageNodeService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignWorkspace(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignWorkspace(
    AssociationRequest request,
    ILineageNodeService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignWorkspace(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToInputs(
        MultipleAssociationRequest request,
        ILineageNodeService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToInputs(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromInputs(
        MultipleAssociationRequest request,
        ILineageNodeService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromInputs(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToOutputs(
        MultipleAssociationRequest request,
        ILineageNodeService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToOutputs(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromOutputs(
        MultipleAssociationRequest request,
        ILineageNodeService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromOutputs(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToDatasets(
        MultipleAssociationRequest request,
        ILineageNodeService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDatasets(
        MultipleAssociationRequest request,
        ILineageNodeService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToModels(
        MultipleAssociationRequest request,
        ILineageNodeService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToModels(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromModels(
        MultipleAssociationRequest request,
        ILineageNodeService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromModels(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToPipelines(
        MultipleAssociationRequest request,
        ILineageNodeService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToPipelines(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromPipelines(
        MultipleAssociationRequest request,
        ILineageNodeService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromPipelines(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToDashboards(
        MultipleAssociationRequest request,
        ILineageNodeService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDashboards(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDashboards(
        MultipleAssociationRequest request,
        ILineageNodeService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDashboards(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToReports(
        MultipleAssociationRequest request,
        ILineageNodeService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToReports(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromReports(
        MultipleAssociationRequest request,
        ILineageNodeService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromReports(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static LineageNode mapRequestToLineageNode( LineageNodeRequest request ) {
        var model = new LineageNode
        {
            Id = request.Id,
            Name = request.Name,
            QualifiedName = request.QualifiedName,
            NodeType = request.NodeType,
        };
        return model;
    }

}

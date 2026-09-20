using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class DataPipelineEndpoints
{
    public static IEndpointRouteBuilder MapDataPipelineEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/dataPipeline").WithTags("DataPipelines");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignWorkspace", AssignWorkspace);
        group.MapPut("/unassignWorkspace", UnassignWorkspace);
        group.MapPut("/assignLineageNode", AssignLineageNode);
        group.MapPut("/unassignLineageNode", UnassignLineageNode);

    group.MapPut("/addToTasks", AddToTasks);
    group.MapPut("/removeFromTasks", RemoveFromTasks);

    group.MapPut("/addToSources", AddToSources);
    group.MapPut("/removeFromSources", RemoveFromSources);

    group.MapPut("/addToOutputs", AddToOutputs);
    group.MapPut("/removeFromOutputs", RemoveFromOutputs);


        return app;
    }

    private static async Task<IResult> Create(
        DataPipelineRequest request,
        IDataPipelineService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToDataPipeline( request );

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
        DataPipelineRequest request,
        IDataPipelineService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToDataPipeline( request );

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
        IDataPipelineService service,
        CancellationToken cancellationToken) {

        var dataPipeline = await service.Get(identifier, cancellationToken);
        return dataPipeline is null ? Results.NotFound() : Results.Ok( dataPipeline );
    }


    private static async Task<IResult> GetAll(
        IDataPipelineService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( DataPipelineResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IDataPipelineService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignWorkspace(
        AssociationRequest request,
        IDataPipelineService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignWorkspace(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignWorkspace(
    AssociationRequest request,
    IDataPipelineService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignWorkspace(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignLineageNode(
        AssociationRequest request,
        IDataPipelineService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignLineageNode(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignLineageNode(
    AssociationRequest request,
    IDataPipelineService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignLineageNode(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToTasks(
        MultipleAssociationRequest request,
        IDataPipelineService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToTasks(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromTasks(
        MultipleAssociationRequest request,
        IDataPipelineService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromTasks(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToSources(
        MultipleAssociationRequest request,
        IDataPipelineService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToSources(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromSources(
        MultipleAssociationRequest request,
        IDataPipelineService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromSources(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToOutputs(
        MultipleAssociationRequest request,
        IDataPipelineService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToOutputs(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromOutputs(
        MultipleAssociationRequest request,
        IDataPipelineService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromOutputs(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static DataPipeline mapRequestToDataPipeline( DataPipelineRequest request ) {
        var model = new DataPipeline
        {
            Id = request.Id,
            Name = request.Name,
            Schedule = request.Schedule,
            TriggerType = request.TriggerType,
            Status = request.Status,
        };
        return model;
    }

}

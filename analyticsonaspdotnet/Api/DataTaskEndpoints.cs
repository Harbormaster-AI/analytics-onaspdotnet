
using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class DataTaskEndpoints
{
    public static IEndpointRouteBuilder MapDataTaskEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/dataTask").WithTags("DataTasks");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignPipeline", AssignPipeline);
        group.MapPut("/unassignPipeline", UnassignPipeline);

    group.MapPut("/addToInputDatasets", AddToInputDatasets);
    group.MapPut("/removeFromInputDatasets", RemoveFromInputDatasets);

    group.MapPut("/addToOutputDatasets", AddToOutputDatasets);
    group.MapPut("/removeFromOutputDatasets", RemoveFromOutputDatasets);


        return app;
    }

    private static async Task<IResult> Create(
        DataTaskRequest request,
        IDataTaskService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToDataTask( request );

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
        DataTaskRequest request,
        IDataTaskService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToDataTask( request );

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
        IDataTaskService service,
        CancellationToken cancellationToken) {

        var dataTask = await service.Get(identifier, cancellationToken);
        return dataTask is null ? Results.NotFound() : Results.Ok( dataTask );
    }


    private static async Task<IResult> GetAll(
        IDataTaskService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( DataTaskResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IDataTaskService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignPipeline(
        AssociationRequest request,
        IDataTaskService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignPipeline(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignPipeline(
    AssociationRequest request,
    IDataTaskService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignPipeline(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToInputDatasets(
        MultipleAssociationRequest request,
        IDataTaskService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToInputDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromInputDatasets(
        MultipleAssociationRequest request,
        IDataTaskService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromInputDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToOutputDatasets(
        MultipleAssociationRequest request,
        IDataTaskService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToOutputDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromOutputDatasets(
        MultipleAssociationRequest request,
        IDataTaskService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromOutputDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static DataTask mapRequestToDataTask( DataTaskRequest request ) {
        var model = new DataTask
        {
            Id = request.Id,
            Name = request.Name,
            Command = request.Command,
            Retries = request.Retries,
            TaskType = request.TaskType,
        };
        return model;
    }

}

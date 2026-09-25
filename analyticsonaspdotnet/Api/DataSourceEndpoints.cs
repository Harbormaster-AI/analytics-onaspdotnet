
using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class DataSourceEndpoints
{
    public static IEndpointRouteBuilder MapDataSourceEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/dataSource").WithTags("DataSources");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignWorkspace", AssignWorkspace);
        group.MapPut("/unassignWorkspace", UnassignWorkspace);

    group.MapPut("/addToProducedDatasets", AddToProducedDatasets);
    group.MapPut("/removeFromProducedDatasets", RemoveFromProducedDatasets);

    group.MapPut("/addToPipelines", AddToPipelines);
    group.MapPut("/removeFromPipelines", RemoveFromPipelines);


        return app;
    }

    private static async Task<IResult> Create(
        DataSourceRequest request,
        IDataSourceService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToDataSource( request );

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
        DataSourceRequest request,
        IDataSourceService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToDataSource( request );

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
        IDataSourceService service,
        CancellationToken cancellationToken) {

        var dataSource = await service.Get(identifier, cancellationToken);
        return dataSource is null ? Results.NotFound() : Results.Ok( dataSource );
    }


    private static async Task<IResult> GetAll(
        IDataSourceService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( DataSourceResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IDataSourceService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignWorkspace(
        AssociationRequest request,
        IDataSourceService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignWorkspace(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignWorkspace(
    AssociationRequest request,
    IDataSourceService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignWorkspace(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToProducedDatasets(
        MultipleAssociationRequest request,
        IDataSourceService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToProducedDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromProducedDatasets(
        MultipleAssociationRequest request,
        IDataSourceService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromProducedDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToPipelines(
        MultipleAssociationRequest request,
        IDataSourceService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToPipelines(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromPipelines(
        MultipleAssociationRequest request,
        IDataSourceService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromPipelines(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static DataSource mapRequestToDataSource( DataSourceRequest request ) {
        var model = new DataSource
        {
            Id = request.Id,
            Name = request.Name,
            Connection = request.Connection,
            Streaming = request.Streaming,
            SourceType = request.SourceType,
            Format = request.Format,
        };
        return model;
    }

}

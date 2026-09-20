using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class DataSetEndpoints
{
    public static IEndpointRouteBuilder MapDataSetEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/dataSet").WithTags("DataSets");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignWorkspace", AssignWorkspace);
        group.MapPut("/unassignWorkspace", UnassignWorkspace);
        group.MapPut("/assignLineageNode", AssignLineageNode);
        group.MapPut("/unassignLineageNode", UnassignLineageNode);

    group.MapPut("/addToSources", AddToSources);
    group.MapPut("/removeFromSources", RemoveFromSources);

    group.MapPut("/addToPipelines", AddToPipelines);
    group.MapPut("/removeFromPipelines", RemoveFromPipelines);

    group.MapPut("/addToSemanticModels", AddToSemanticModels);
    group.MapPut("/removeFromSemanticModels", RemoveFromSemanticModels);

    group.MapPut("/addToDimensions", AddToDimensions);
    group.MapPut("/removeFromDimensions", RemoveFromDimensions);

    group.MapPut("/addToMeasures", AddToMeasures);
    group.MapPut("/removeFromMeasures", RemoveFromMeasures);

    group.MapPut("/addToMetrics", AddToMetrics);
    group.MapPut("/removeFromMetrics", RemoveFromMetrics);

    group.MapPut("/addToQualityRules", AddToQualityRules);
    group.MapPut("/removeFromQualityRules", RemoveFromQualityRules);

    group.MapPut("/addToTags", AddToTags);
    group.MapPut("/removeFromTags", RemoveFromTags);


        return app;
    }

    private static async Task<IResult> Create(
        DataSetRequest request,
        IDataSetService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToDataSet( request );

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
        DataSetRequest request,
        IDataSetService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToDataSet( request );

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
        IDataSetService service,
        CancellationToken cancellationToken) {

        var dataSet = await service.Get(identifier, cancellationToken);
        return dataSet is null ? Results.NotFound() : Results.Ok( dataSet );
    }


    private static async Task<IResult> GetAll(
        IDataSetService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( DataSetResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IDataSetService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignWorkspace(
        AssociationRequest request,
        IDataSetService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignWorkspace(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignWorkspace(
    AssociationRequest request,
    IDataSetService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignWorkspace(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignLineageNode(
        AssociationRequest request,
        IDataSetService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignLineageNode(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignLineageNode(
    AssociationRequest request,
    IDataSetService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignLineageNode(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToSources(
        MultipleAssociationRequest request,
        IDataSetService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToSources(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromSources(
        MultipleAssociationRequest request,
        IDataSetService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromSources(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToPipelines(
        MultipleAssociationRequest request,
        IDataSetService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToPipelines(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromPipelines(
        MultipleAssociationRequest request,
        IDataSetService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromPipelines(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToSemanticModels(
        MultipleAssociationRequest request,
        IDataSetService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToSemanticModels(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromSemanticModels(
        MultipleAssociationRequest request,
        IDataSetService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromSemanticModels(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToDimensions(
        MultipleAssociationRequest request,
        IDataSetService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDimensions(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDimensions(
        MultipleAssociationRequest request,
        IDataSetService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDimensions(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToMeasures(
        MultipleAssociationRequest request,
        IDataSetService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToMeasures(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromMeasures(
        MultipleAssociationRequest request,
        IDataSetService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromMeasures(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToMetrics(
        MultipleAssociationRequest request,
        IDataSetService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToMetrics(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromMetrics(
        MultipleAssociationRequest request,
        IDataSetService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromMetrics(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToQualityRules(
        MultipleAssociationRequest request,
        IDataSetService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToQualityRules(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromQualityRules(
        MultipleAssociationRequest request,
        IDataSetService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromQualityRules(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToTags(
        MultipleAssociationRequest request,
        IDataSetService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToTags(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromTags(
        MultipleAssociationRequest request,
        IDataSetService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromTags(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static DataSet mapRequestToDataSet( DataSetRequest request ) {
        var model = new DataSet
        {
            Id = request.Id,
            Name = request.Name,
            SchemaVersion = request.SchemaVersion,
            RefreshSchedule = request.RefreshSchedule,
            Sensitive = request.Sensitive,
            DataFormat = request.DataFormat,
        };
        return model;
    }

}

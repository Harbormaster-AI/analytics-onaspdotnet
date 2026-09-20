using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class FeatureEndpoints
{
    public static IEndpointRouteBuilder MapFeatureEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/feature").WithTags("Features");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignFeatureSet", AssignFeatureSet);
        group.MapPut("/unassignFeatureSet", UnassignFeatureSet);

    group.MapPut("/addToSourceDatasets", AddToSourceDatasets);
    group.MapPut("/removeFromSourceDatasets", RemoveFromSourceDatasets);

    group.MapPut("/addToModels", AddToModels);
    group.MapPut("/removeFromModels", RemoveFromModels);

    group.MapPut("/addToTrainingRuns", AddToTrainingRuns);
    group.MapPut("/removeFromTrainingRuns", RemoveFromTrainingRuns);


        return app;
    }

    private static async Task<IResult> Create(
        FeatureRequest request,
        IFeatureService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToFeature( request );

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
        FeatureRequest request,
        IFeatureService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToFeature( request );

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
        IFeatureService service,
        CancellationToken cancellationToken) {

        var feature = await service.Get(identifier, cancellationToken);
        return feature is null ? Results.NotFound() : Results.Ok( feature );
    }


    private static async Task<IResult> GetAll(
        IFeatureService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( FeatureResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IFeatureService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignFeatureSet(
        AssociationRequest request,
        IFeatureService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignFeatureSet(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignFeatureSet(
    AssociationRequest request,
    IFeatureService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignFeatureSet(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToSourceDatasets(
        MultipleAssociationRequest request,
        IFeatureService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToSourceDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromSourceDatasets(
        MultipleAssociationRequest request,
        IFeatureService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromSourceDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToModels(
        MultipleAssociationRequest request,
        IFeatureService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToModels(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromModels(
        MultipleAssociationRequest request,
        IFeatureService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromModels(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToTrainingRuns(
        MultipleAssociationRequest request,
        IFeatureService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToTrainingRuns(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromTrainingRuns(
        MultipleAssociationRequest request,
        IFeatureService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromTrainingRuns(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static Feature mapRequestToFeature( FeatureRequest request ) {
        var model = new Feature
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            DataType = request.DataType,
        };
        return model;
    }

}


using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class FeatureSetEndpoints
{
    public static IEndpointRouteBuilder MapFeatureSetEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/featureSet").WithTags("FeatureSets");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignWorkspace", AssignWorkspace);
        group.MapPut("/unassignWorkspace", UnassignWorkspace);

    group.MapPut("/addToFeatures", AddToFeatures);
    group.MapPut("/removeFromFeatures", RemoveFromFeatures);

    group.MapPut("/addToDatasets", AddToDatasets);
    group.MapPut("/removeFromDatasets", RemoveFromDatasets);

    group.MapPut("/addToModels", AddToModels);
    group.MapPut("/removeFromModels", RemoveFromModels);

    group.MapPut("/addToModelVersions", AddToModelVersions);
    group.MapPut("/removeFromModelVersions", RemoveFromModelVersions);

    group.MapPut("/addToTags", AddToTags);
    group.MapPut("/removeFromTags", RemoveFromTags);


        return app;
    }

    private static async Task<IResult> Create(
        FeatureSetRequest request,
        IFeatureSetService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToFeatureSet( request );

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
        FeatureSetRequest request,
        IFeatureSetService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToFeatureSet( request );

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
        IFeatureSetService service,
        CancellationToken cancellationToken) {

        var featureSet = await service.Get(identifier, cancellationToken);
        return featureSet is null ? Results.NotFound() : Results.Ok( featureSet );
    }


    private static async Task<IResult> GetAll(
        IFeatureSetService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( FeatureSetResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IFeatureSetService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignWorkspace(
        AssociationRequest request,
        IFeatureSetService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignWorkspace(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignWorkspace(
    AssociationRequest request,
    IFeatureSetService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignWorkspace(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToFeatures(
        MultipleAssociationRequest request,
        IFeatureSetService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToFeatures(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromFeatures(
        MultipleAssociationRequest request,
        IFeatureSetService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromFeatures(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToDatasets(
        MultipleAssociationRequest request,
        IFeatureSetService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDatasets(
        MultipleAssociationRequest request,
        IFeatureSetService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToModels(
        MultipleAssociationRequest request,
        IFeatureSetService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToModels(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromModels(
        MultipleAssociationRequest request,
        IFeatureSetService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromModels(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToModelVersions(
        MultipleAssociationRequest request,
        IFeatureSetService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToModelVersions(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromModelVersions(
        MultipleAssociationRequest request,
        IFeatureSetService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromModelVersions(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToTags(
        MultipleAssociationRequest request,
        IFeatureSetService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToTags(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromTags(
        MultipleAssociationRequest request,
        IFeatureSetService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromTags(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static FeatureSet mapRequestToFeatureSet( FeatureSetRequest request ) {
        var model = new FeatureSet
        {
            Id = request.Id,
            Name = request.Name,
            RefreshSchedule = request.RefreshSchedule,
            StoreType = request.StoreType,
        };
        return model;
    }

}

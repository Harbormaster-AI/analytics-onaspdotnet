using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class ModelEndpoints
{
    public static IEndpointRouteBuilder MapModelEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/model").WithTags("Models");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignWorkspace", AssignWorkspace);
        group.MapPut("/unassignWorkspace", UnassignWorkspace);

    group.MapPut("/addToVersions", AddToVersions);
    group.MapPut("/removeFromVersions", RemoveFromVersions);

    group.MapPut("/addToFeatureSets", AddToFeatureSets);
    group.MapPut("/removeFromFeatureSets", RemoveFromFeatureSets);

    group.MapPut("/addToExperiments", AddToExperiments);
    group.MapPut("/removeFromExperiments", RemoveFromExperiments);

    group.MapPut("/addToTags", AddToTags);
    group.MapPut("/removeFromTags", RemoveFromTags);


        return app;
    }

    private static async Task<IResult> Create(
        ModelRequest request,
        IModelService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToModel( request );

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
        ModelRequest request,
        IModelService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToModel( request );

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
        IModelService service,
        CancellationToken cancellationToken) {

        var model = await service.Get(identifier, cancellationToken);
        return model is null ? Results.NotFound() : Results.Ok( model );
    }


    private static async Task<IResult> GetAll(
        IModelService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( ModelResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IModelService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignWorkspace(
        AssociationRequest request,
        IModelService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignWorkspace(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignWorkspace(
    AssociationRequest request,
    IModelService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignWorkspace(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToVersions(
        MultipleAssociationRequest request,
        IModelService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToVersions(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromVersions(
        MultipleAssociationRequest request,
        IModelService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromVersions(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToFeatureSets(
        MultipleAssociationRequest request,
        IModelService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToFeatureSets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromFeatureSets(
        MultipleAssociationRequest request,
        IModelService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromFeatureSets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToExperiments(
        MultipleAssociationRequest request,
        IModelService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToExperiments(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromExperiments(
        MultipleAssociationRequest request,
        IModelService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromExperiments(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToTags(
        MultipleAssociationRequest request,
        IModelService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToTags(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromTags(
        MultipleAssociationRequest request,
        IModelService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromTags(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static Model mapRequestToModel( ModelRequest request ) {
        var model = new Model
        {
            Id = request.Id,
            Name = request.Name,
            TaskDescription = request.TaskDescription,
            ModelType = request.ModelType,
        };
        return model;
    }

}


using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class ModelVersionEndpoints
{
    public static IEndpointRouteBuilder MapModelVersionEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/modelVersion").WithTags("ModelVersions");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignModel_", AssignModel_);
        group.MapPut("/unassignModel_", UnassignModel_);
        group.MapPut("/assignTrainingRun", AssignTrainingRun);
        group.MapPut("/unassignTrainingRun", UnassignTrainingRun);

    group.MapPut("/addToEvaluationMetrics", AddToEvaluationMetrics);
    group.MapPut("/removeFromEvaluationMetrics", RemoveFromEvaluationMetrics);

    group.MapPut("/addToDeployments", AddToDeployments);
    group.MapPut("/removeFromDeployments", RemoveFromDeployments);

    group.MapPut("/addToFeatureSets", AddToFeatureSets);
    group.MapPut("/removeFromFeatureSets", RemoveFromFeatureSets);

    group.MapPut("/addToDatasets", AddToDatasets);
    group.MapPut("/removeFromDatasets", RemoveFromDatasets);


        return app;
    }

    private static async Task<IResult> Create(
        ModelVersionRequest request,
        IModelVersionService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToModelVersion( request );

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
        ModelVersionRequest request,
        IModelVersionService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToModelVersion( request );

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
        IModelVersionService service,
        CancellationToken cancellationToken) {

        var modelVersion = await service.Get(identifier, cancellationToken);
        return modelVersion is null ? Results.NotFound() : Results.Ok( modelVersion );
    }


    private static async Task<IResult> GetAll(
        IModelVersionService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( ModelVersionResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IModelVersionService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignModel_(
        AssociationRequest request,
        IModelVersionService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignModel_(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignModel_(
    AssociationRequest request,
    IModelVersionService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignModel_(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignTrainingRun(
        AssociationRequest request,
        IModelVersionService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignTrainingRun(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignTrainingRun(
    AssociationRequest request,
    IModelVersionService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignTrainingRun(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToEvaluationMetrics(
        MultipleAssociationRequest request,
        IModelVersionService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToEvaluationMetrics(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromEvaluationMetrics(
        MultipleAssociationRequest request,
        IModelVersionService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromEvaluationMetrics(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToDeployments(
        MultipleAssociationRequest request,
        IModelVersionService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDeployments(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDeployments(
        MultipleAssociationRequest request,
        IModelVersionService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDeployments(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToFeatureSets(
        MultipleAssociationRequest request,
        IModelVersionService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToFeatureSets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromFeatureSets(
        MultipleAssociationRequest request,
        IModelVersionService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromFeatureSets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToDatasets(
        MultipleAssociationRequest request,
        IModelVersionService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDatasets(
        MultipleAssociationRequest request,
        IModelVersionService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static ModelVersion mapRequestToModelVersion( ModelVersionRequest request ) {
        var model = new ModelVersion
        {
            Id = request.Id,
            Version = request.Version,
            Lifecycle = request.Lifecycle,
            TrainingStatus = request.TrainingStatus,
        };
        return model;
    }

}

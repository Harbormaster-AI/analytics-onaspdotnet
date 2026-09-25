
using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class TrainingRunEndpoints
{
    public static IEndpointRouteBuilder MapTrainingRunEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/trainingRun").WithTags("TrainingRuns");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignExperiment", AssignExperiment);
        group.MapPut("/unassignExperiment", UnassignExperiment);
        group.MapPut("/assignModelVersion", AssignModelVersion);
        group.MapPut("/unassignModelVersion", UnassignModelVersion);

    group.MapPut("/addToInputDatasets", AddToInputDatasets);
    group.MapPut("/removeFromInputDatasets", RemoveFromInputDatasets);

    group.MapPut("/addToFeatures", AddToFeatures);
    group.MapPut("/removeFromFeatures", RemoveFromFeatures);

    group.MapPut("/addToRunMetrics", AddToRunMetrics);
    group.MapPut("/removeFromRunMetrics", RemoveFromRunMetrics);

    group.MapPut("/addToRunParameters", AddToRunParameters);
    group.MapPut("/removeFromRunParameters", RemoveFromRunParameters);


        return app;
    }

    private static async Task<IResult> Create(
        TrainingRunRequest request,
        ITrainingRunService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToTrainingRun( request );

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
        TrainingRunRequest request,
        ITrainingRunService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToTrainingRun( request );

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
        ITrainingRunService service,
        CancellationToken cancellationToken) {

        var trainingRun = await service.Get(identifier, cancellationToken);
        return trainingRun is null ? Results.NotFound() : Results.Ok( trainingRun );
    }


    private static async Task<IResult> GetAll(
        ITrainingRunService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( TrainingRunResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        ITrainingRunService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignExperiment(
        AssociationRequest request,
        ITrainingRunService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignExperiment(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignExperiment(
    AssociationRequest request,
    ITrainingRunService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignExperiment(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignModelVersion(
        AssociationRequest request,
        ITrainingRunService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignModelVersion(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignModelVersion(
    AssociationRequest request,
    ITrainingRunService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignModelVersion(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToInputDatasets(
        MultipleAssociationRequest request,
        ITrainingRunService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToInputDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromInputDatasets(
        MultipleAssociationRequest request,
        ITrainingRunService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromInputDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToFeatures(
        MultipleAssociationRequest request,
        ITrainingRunService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToFeatures(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromFeatures(
        MultipleAssociationRequest request,
        ITrainingRunService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromFeatures(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToRunMetrics(
        MultipleAssociationRequest request,
        ITrainingRunService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToRunMetrics(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromRunMetrics(
        MultipleAssociationRequest request,
        ITrainingRunService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromRunMetrics(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToRunParameters(
        MultipleAssociationRequest request,
        ITrainingRunService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToRunParameters(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromRunParameters(
        MultipleAssociationRequest request,
        ITrainingRunService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromRunParameters(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static TrainingRun mapRequestToTrainingRun( TrainingRunRequest request ) {
        var model = new TrainingRun
        {
            Id = request.Id,
            RunLabel = request.RunLabel,
            StartedAt = request.StartedAt,
            CompletedAt = request.CompletedAt,
            Status = request.Status,
        };
        return model;
    }

}

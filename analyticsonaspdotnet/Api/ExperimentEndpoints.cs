
using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class ExperimentEndpoints
{
    public static IEndpointRouteBuilder MapExperimentEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/experiment").WithTags("Experiments");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignWorkspace", AssignWorkspace);
        group.MapPut("/unassignWorkspace", UnassignWorkspace);

    group.MapPut("/addToTrainingRuns", AddToTrainingRuns);
    group.MapPut("/removeFromTrainingRuns", RemoveFromTrainingRuns);

    group.MapPut("/addToModels", AddToModels);
    group.MapPut("/removeFromModels", RemoveFromModels);

    group.MapPut("/addToNotebooks", AddToNotebooks);
    group.MapPut("/removeFromNotebooks", RemoveFromNotebooks);


        return app;
    }

    private static async Task<IResult> Create(
        ExperimentRequest request,
        IExperimentService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToExperiment( request );

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
        ExperimentRequest request,
        IExperimentService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToExperiment( request );

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
        IExperimentService service,
        CancellationToken cancellationToken) {

        var experiment = await service.Get(identifier, cancellationToken);
        return experiment is null ? Results.NotFound() : Results.Ok( experiment );
    }


    private static async Task<IResult> GetAll(
        IExperimentService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( ExperimentResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IExperimentService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignWorkspace(
        AssociationRequest request,
        IExperimentService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignWorkspace(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignWorkspace(
    AssociationRequest request,
    IExperimentService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignWorkspace(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToTrainingRuns(
        MultipleAssociationRequest request,
        IExperimentService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToTrainingRuns(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromTrainingRuns(
        MultipleAssociationRequest request,
        IExperimentService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromTrainingRuns(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToModels(
        MultipleAssociationRequest request,
        IExperimentService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToModels(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromModels(
        MultipleAssociationRequest request,
        IExperimentService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromModels(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToNotebooks(
        MultipleAssociationRequest request,
        IExperimentService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToNotebooks(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromNotebooks(
        MultipleAssociationRequest request,
        IExperimentService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromNotebooks(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static Experiment mapRequestToExperiment( ExperimentRequest request ) {
        var model = new Experiment
        {
            Id = request.Id,
            Name = request.Name,
            Objective = request.Objective,
            Status = request.Status,
        };
        return model;
    }

}

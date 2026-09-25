
using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class RunParameterEndpoints
{
    public static IEndpointRouteBuilder MapRunParameterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/runParameter").WithTags("RunParameters");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignTrainingRun", AssignTrainingRun);
        group.MapPut("/unassignTrainingRun", UnassignTrainingRun);


        return app;
    }

    private static async Task<IResult> Create(
        RunParameterRequest request,
        IRunParameterService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToRunParameter( request );

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
        RunParameterRequest request,
        IRunParameterService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToRunParameter( request );

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
        IRunParameterService service,
        CancellationToken cancellationToken) {

        var runParameter = await service.Get(identifier, cancellationToken);
        return runParameter is null ? Results.NotFound() : Results.Ok( runParameter );
    }


    private static async Task<IResult> GetAll(
        IRunParameterService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( RunParameterResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IRunParameterService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignTrainingRun(
        AssociationRequest request,
        IRunParameterService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignTrainingRun(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignTrainingRun(
    AssociationRequest request,
    IRunParameterService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignTrainingRun(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static RunParameter mapRequestToRunParameter( RunParameterRequest request ) {
        var model = new RunParameter
        {
            Id = request.Id,
            Name = request.Name,
            Value = request.Value,
        };
        return model;
    }

}

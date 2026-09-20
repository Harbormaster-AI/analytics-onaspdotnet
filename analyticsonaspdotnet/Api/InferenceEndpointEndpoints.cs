using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class InferenceEndpointEndpoints
{
    public static IEndpointRouteBuilder MapInferenceEndpointEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/inferenceEndpoint").WithTags("InferenceEndpoints");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignModelVersion", AssignModelVersion);
        group.MapPut("/unassignModelVersion", UnassignModelVersion);
        group.MapPut("/assignWorkspace", AssignWorkspace);
        group.MapPut("/unassignWorkspace", UnassignWorkspace);

    group.MapPut("/addToPredictions", AddToPredictions);
    group.MapPut("/removeFromPredictions", RemoveFromPredictions);


        return app;
    }

    private static async Task<IResult> Create(
        InferenceEndpointRequest request,
        IInferenceEndpointService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToInferenceEndpoint( request );

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
        InferenceEndpointRequest request,
        IInferenceEndpointService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToInferenceEndpoint( request );

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
        IInferenceEndpointService service,
        CancellationToken cancellationToken) {

        var inferenceEndpoint = await service.Get(identifier, cancellationToken);
        return inferenceEndpoint is null ? Results.NotFound() : Results.Ok( inferenceEndpoint );
    }


    private static async Task<IResult> GetAll(
        IInferenceEndpointService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( InferenceEndpointResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IInferenceEndpointService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignModelVersion(
        AssociationRequest request,
        IInferenceEndpointService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignModelVersion(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignModelVersion(
    AssociationRequest request,
    IInferenceEndpointService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignModelVersion(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignWorkspace(
        AssociationRequest request,
        IInferenceEndpointService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignWorkspace(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignWorkspace(
    AssociationRequest request,
    IInferenceEndpointService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignWorkspace(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToPredictions(
        MultipleAssociationRequest request,
        IInferenceEndpointService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToPredictions(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromPredictions(
        MultipleAssociationRequest request,
        IInferenceEndpointService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromPredictions(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static InferenceEndpoint mapRequestToInferenceEndpoint( InferenceEndpointRequest request ) {
        var model = new InferenceEndpoint
        {
            Id = request.Id,
            Name = request.Name,
            EndpointUrl = request.EndpointUrl,
            TrafficShare = request.TrafficShare,
            Mode = request.Mode,
        };
        return model;
    }

}

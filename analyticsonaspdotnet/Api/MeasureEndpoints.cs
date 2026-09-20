using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class MeasureEndpoints
{
    public static IEndpointRouteBuilder MapMeasureEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/measure").WithTags("Measures");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignSemanticModel", AssignSemanticModel);
        group.MapPut("/unassignSemanticModel", UnassignSemanticModel);

    group.MapPut("/addToDatasets", AddToDatasets);
    group.MapPut("/removeFromDatasets", RemoveFromDatasets);

    group.MapPut("/addToGlossaryTerms", AddToGlossaryTerms);
    group.MapPut("/removeFromGlossaryTerms", RemoveFromGlossaryTerms);


        return app;
    }

    private static async Task<IResult> Create(
        MeasureRequest request,
        IMeasureService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToMeasure( request );

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
        MeasureRequest request,
        IMeasureService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToMeasure( request );

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
        IMeasureService service,
        CancellationToken cancellationToken) {

        var measure = await service.Get(identifier, cancellationToken);
        return measure is null ? Results.NotFound() : Results.Ok( measure );
    }


    private static async Task<IResult> GetAll(
        IMeasureService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( MeasureResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IMeasureService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignSemanticModel(
        AssociationRequest request,
        IMeasureService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignSemanticModel(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignSemanticModel(
    AssociationRequest request,
    IMeasureService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignSemanticModel(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToDatasets(
        MultipleAssociationRequest request,
        IMeasureService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDatasets(
        MultipleAssociationRequest request,
        IMeasureService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToGlossaryTerms(
        MultipleAssociationRequest request,
        IMeasureService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToGlossaryTerms(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromGlossaryTerms(
        MultipleAssociationRequest request,
        IMeasureService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromGlossaryTerms(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static Measure mapRequestToMeasure( MeasureRequest request ) {
        var model = new Measure
        {
            Id = request.Id,
            Name = request.Name,
            Format = request.Format,
            Aggregation = request.Aggregation,
        };
        return model;
    }

}

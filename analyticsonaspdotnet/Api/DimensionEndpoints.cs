using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class DimensionEndpoints
{
    public static IEndpointRouteBuilder MapDimensionEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/dimension").WithTags("Dimensions");

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
        DimensionRequest request,
        IDimensionService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToDimension( request );

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
        DimensionRequest request,
        IDimensionService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToDimension( request );

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
        IDimensionService service,
        CancellationToken cancellationToken) {

        var dimension = await service.Get(identifier, cancellationToken);
        return dimension is null ? Results.NotFound() : Results.Ok( dimension );
    }


    private static async Task<IResult> GetAll(
        IDimensionService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( DimensionResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IDimensionService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignSemanticModel(
        AssociationRequest request,
        IDimensionService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignSemanticModel(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignSemanticModel(
    AssociationRequest request,
    IDimensionService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignSemanticModel(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToDatasets(
        MultipleAssociationRequest request,
        IDimensionService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDatasets(
        MultipleAssociationRequest request,
        IDimensionService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToGlossaryTerms(
        MultipleAssociationRequest request,
        IDimensionService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToGlossaryTerms(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromGlossaryTerms(
        MultipleAssociationRequest request,
        IDimensionService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromGlossaryTerms(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static Dimension mapRequestToDimension( DimensionRequest request ) {
        var model = new Dimension
        {
            Id = request.Id,
            Name = request.Name,
            TypeTime = request.TypeTime,
            DimensionType = request.DimensionType,
        };
        return model;
    }

}

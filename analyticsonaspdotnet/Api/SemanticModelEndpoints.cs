using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class SemanticModelEndpoints
{
    public static IEndpointRouteBuilder MapSemanticModelEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/semanticModel").WithTags("SemanticModels");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);


    group.MapPut("/addToDatasets", AddToDatasets);
    group.MapPut("/removeFromDatasets", RemoveFromDatasets);

    group.MapPut("/addToMetrics", AddToMetrics);
    group.MapPut("/removeFromMetrics", RemoveFromMetrics);

    group.MapPut("/addToDimensions", AddToDimensions);
    group.MapPut("/removeFromDimensions", RemoveFromDimensions);

    group.MapPut("/addToMeasures", AddToMeasures);
    group.MapPut("/removeFromMeasures", RemoveFromMeasures);

    group.MapPut("/addToGlossaryTerms", AddToGlossaryTerms);
    group.MapPut("/removeFromGlossaryTerms", RemoveFromGlossaryTerms);


        return app;
    }

    private static async Task<IResult> Create(
        SemanticModelRequest request,
        ISemanticModelService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToSemanticModel( request );

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
        SemanticModelRequest request,
        ISemanticModelService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToSemanticModel( request );

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
        ISemanticModelService service,
        CancellationToken cancellationToken) {

        var semanticModel = await service.Get(identifier, cancellationToken);
        return semanticModel is null ? Results.NotFound() : Results.Ok( semanticModel );
    }


    private static async Task<IResult> GetAll(
        ISemanticModelService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( SemanticModelResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        ISemanticModelService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToDatasets(
        MultipleAssociationRequest request,
        ISemanticModelService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDatasets(
        MultipleAssociationRequest request,
        ISemanticModelService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToMetrics(
        MultipleAssociationRequest request,
        ISemanticModelService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToMetrics(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromMetrics(
        MultipleAssociationRequest request,
        ISemanticModelService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromMetrics(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToDimensions(
        MultipleAssociationRequest request,
        ISemanticModelService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDimensions(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDimensions(
        MultipleAssociationRequest request,
        ISemanticModelService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDimensions(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToMeasures(
        MultipleAssociationRequest request,
        ISemanticModelService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToMeasures(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromMeasures(
        MultipleAssociationRequest request,
        ISemanticModelService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromMeasures(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToGlossaryTerms(
        MultipleAssociationRequest request,
        ISemanticModelService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToGlossaryTerms(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromGlossaryTerms(
        MultipleAssociationRequest request,
        ISemanticModelService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromGlossaryTerms(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static SemanticModel mapRequestToSemanticModel( SemanticModelRequest request ) {
        var model = new SemanticModel
        {
            Id = request.Id,
            Name = request.Name,
            Version = request.Version,
            Grain = request.Grain,
        };
        return model;
    }

}

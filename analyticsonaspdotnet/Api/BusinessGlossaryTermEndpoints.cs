using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class BusinessGlossaryTermEndpoints
{
    public static IEndpointRouteBuilder MapBusinessGlossaryTermEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/businessGlossaryTerm").WithTags("BusinessGlossaryTerms");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);


    group.MapPut("/addToRelatedTerms", AddToRelatedTerms);
    group.MapPut("/removeFromRelatedTerms", RemoveFromRelatedTerms);

    group.MapPut("/addToMetrics", AddToMetrics);
    group.MapPut("/removeFromMetrics", RemoveFromMetrics);

    group.MapPut("/addToDatasets", AddToDatasets);
    group.MapPut("/removeFromDatasets", RemoveFromDatasets);

    group.MapPut("/addToDimensions", AddToDimensions);
    group.MapPut("/removeFromDimensions", RemoveFromDimensions);

    group.MapPut("/addToMeasures", AddToMeasures);
    group.MapPut("/removeFromMeasures", RemoveFromMeasures);


        return app;
    }

    private static async Task<IResult> Create(
        BusinessGlossaryTermRequest request,
        IBusinessGlossaryTermService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToBusinessGlossaryTerm( request );

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
        BusinessGlossaryTermRequest request,
        IBusinessGlossaryTermService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToBusinessGlossaryTerm( request );

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
        IBusinessGlossaryTermService service,
        CancellationToken cancellationToken) {

        var businessGlossaryTerm = await service.Get(identifier, cancellationToken);
        return businessGlossaryTerm is null ? Results.NotFound() : Results.Ok( businessGlossaryTerm );
    }


    private static async Task<IResult> GetAll(
        IBusinessGlossaryTermService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( BusinessGlossaryTermResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IBusinessGlossaryTermService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToRelatedTerms(
        MultipleAssociationRequest request,
        IBusinessGlossaryTermService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToRelatedTerms(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromRelatedTerms(
        MultipleAssociationRequest request,
        IBusinessGlossaryTermService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromRelatedTerms(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToMetrics(
        MultipleAssociationRequest request,
        IBusinessGlossaryTermService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToMetrics(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromMetrics(
        MultipleAssociationRequest request,
        IBusinessGlossaryTermService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromMetrics(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToDatasets(
        MultipleAssociationRequest request,
        IBusinessGlossaryTermService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDatasets(
        MultipleAssociationRequest request,
        IBusinessGlossaryTermService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToDimensions(
        MultipleAssociationRequest request,
        IBusinessGlossaryTermService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDimensions(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDimensions(
        MultipleAssociationRequest request,
        IBusinessGlossaryTermService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDimensions(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToMeasures(
        MultipleAssociationRequest request,
        IBusinessGlossaryTermService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToMeasures(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromMeasures(
        MultipleAssociationRequest request,
        IBusinessGlossaryTermService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromMeasures(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static BusinessGlossaryTerm mapRequestToBusinessGlossaryTerm( BusinessGlossaryTermRequest request ) {
        var model = new BusinessGlossaryTerm
        {
            Id = request.Id,
            Term = request.Term,
            Definition = request.Definition,
            Steward = request.Steward,
        };
        return model;
    }

}

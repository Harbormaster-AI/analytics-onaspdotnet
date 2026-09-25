
using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class TagEndpoints
{
    public static IEndpointRouteBuilder MapTagEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/tag").WithTags("Tags");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);


    group.MapPut("/addToDatasets", AddToDatasets);
    group.MapPut("/removeFromDatasets", RemoveFromDatasets);

    group.MapPut("/addToModels", AddToModels);
    group.MapPut("/removeFromModels", RemoveFromModels);

    group.MapPut("/addToModelVersions", AddToModelVersions);
    group.MapPut("/removeFromModelVersions", RemoveFromModelVersions);

    group.MapPut("/addToDashboards", AddToDashboards);
    group.MapPut("/removeFromDashboards", RemoveFromDashboards);

    group.MapPut("/addToReports", AddToReports);
    group.MapPut("/removeFromReports", RemoveFromReports);

    group.MapPut("/addToFeatureSets", AddToFeatureSets);
    group.MapPut("/removeFromFeatureSets", RemoveFromFeatureSets);

    group.MapPut("/addToMetrics", AddToMetrics);
    group.MapPut("/removeFromMetrics", RemoveFromMetrics);


        return app;
    }

    private static async Task<IResult> Create(
        TagRequest request,
        ITagService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToTag( request );

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
        TagRequest request,
        ITagService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToTag( request );

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
        ITagService service,
        CancellationToken cancellationToken) {

        var tag = await service.Get(identifier, cancellationToken);
        return tag is null ? Results.NotFound() : Results.Ok( tag );
    }


    private static async Task<IResult> GetAll(
        ITagService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( TagResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        ITagService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToDatasets(
        MultipleAssociationRequest request,
        ITagService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDatasets(
        MultipleAssociationRequest request,
        ITagService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToModels(
        MultipleAssociationRequest request,
        ITagService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToModels(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromModels(
        MultipleAssociationRequest request,
        ITagService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromModels(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToModelVersions(
        MultipleAssociationRequest request,
        ITagService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToModelVersions(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromModelVersions(
        MultipleAssociationRequest request,
        ITagService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromModelVersions(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToDashboards(
        MultipleAssociationRequest request,
        ITagService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDashboards(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDashboards(
        MultipleAssociationRequest request,
        ITagService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDashboards(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToReports(
        MultipleAssociationRequest request,
        ITagService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToReports(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromReports(
        MultipleAssociationRequest request,
        ITagService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromReports(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToFeatureSets(
        MultipleAssociationRequest request,
        ITagService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToFeatureSets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromFeatureSets(
        MultipleAssociationRequest request,
        ITagService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromFeatureSets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToMetrics(
        MultipleAssociationRequest request,
        ITagService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToMetrics(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromMetrics(
        MultipleAssociationRequest request,
        ITagService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromMetrics(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static Tag mapRequestToTag( TagRequest request ) {
        var model = new Tag
        {
            Id = request.Id,
            Name = request.Name,
            Category = request.Category,
        };
        return model;
    }

}

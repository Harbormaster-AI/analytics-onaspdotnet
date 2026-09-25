
using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class ReportEndpoints
{
    public static IEndpointRouteBuilder MapReportEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/report").WithTags("Reports");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignWorkspace", AssignWorkspace);
        group.MapPut("/unassignWorkspace", UnassignWorkspace);

    group.MapPut("/addToVisualizations", AddToVisualizations);
    group.MapPut("/removeFromVisualizations", RemoveFromVisualizations);

    group.MapPut("/addToDatasets", AddToDatasets);
    group.MapPut("/removeFromDatasets", RemoveFromDatasets);

    group.MapPut("/addToSemanticModels", AddToSemanticModels);
    group.MapPut("/removeFromSemanticModels", RemoveFromSemanticModels);

    group.MapPut("/addToQueries", AddToQueries);
    group.MapPut("/removeFromQueries", RemoveFromQueries);

    group.MapPut("/addToTags", AddToTags);
    group.MapPut("/removeFromTags", RemoveFromTags);


        return app;
    }

    private static async Task<IResult> Create(
        ReportRequest request,
        IReportService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToReport( request );

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
        ReportRequest request,
        IReportService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToReport( request );

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
        IReportService service,
        CancellationToken cancellationToken) {

        var report = await service.Get(identifier, cancellationToken);
        return report is null ? Results.NotFound() : Results.Ok( report );
    }


    private static async Task<IResult> GetAll(
        IReportService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( ReportResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IReportService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignWorkspace(
        AssociationRequest request,
        IReportService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignWorkspace(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignWorkspace(
    AssociationRequest request,
    IReportService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignWorkspace(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToVisualizations(
        MultipleAssociationRequest request,
        IReportService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToVisualizations(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromVisualizations(
        MultipleAssociationRequest request,
        IReportService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromVisualizations(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToDatasets(
        MultipleAssociationRequest request,
        IReportService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDatasets(
        MultipleAssociationRequest request,
        IReportService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToSemanticModels(
        MultipleAssociationRequest request,
        IReportService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToSemanticModels(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromSemanticModels(
        MultipleAssociationRequest request,
        IReportService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromSemanticModels(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToQueries(
        MultipleAssociationRequest request,
        IReportService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToQueries(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromQueries(
        MultipleAssociationRequest request,
        IReportService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromQueries(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToTags(
        MultipleAssociationRequest request,
        IReportService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToTags(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromTags(
        MultipleAssociationRequest request,
        IReportService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromTags(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static Report mapRequestToReport( ReportRequest request ) {
        var model = new Report
        {
            Id = request.Id,
            Title = request.Title,
            Audience = request.Audience,
            Status = request.Status,
        };
        return model;
    }

}

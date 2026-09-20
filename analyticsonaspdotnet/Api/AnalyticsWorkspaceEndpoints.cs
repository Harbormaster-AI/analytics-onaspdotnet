using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class AnalyticsWorkspaceEndpoints
{
    public static IEndpointRouteBuilder MapAnalyticsWorkspaceEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/analyticsWorkspace").WithTags("AnalyticsWorkspaces");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);


    group.MapPut("/addToDatasets", AddToDatasets);
    group.MapPut("/removeFromDatasets", RemoveFromDatasets);

    group.MapPut("/addToDataSources", AddToDataSources);
    group.MapPut("/removeFromDataSources", RemoveFromDataSources);

    group.MapPut("/addToPipelines", AddToPipelines);
    group.MapPut("/removeFromPipelines", RemoveFromPipelines);

    group.MapPut("/addToDashboards", AddToDashboards);
    group.MapPut("/removeFromDashboards", RemoveFromDashboards);

    group.MapPut("/addToReports", AddToReports);
    group.MapPut("/removeFromReports", RemoveFromReports);

    group.MapPut("/addToNotebooks", AddToNotebooks);
    group.MapPut("/removeFromNotebooks", RemoveFromNotebooks);

    group.MapPut("/addToModels", AddToModels);
    group.MapPut("/removeFromModels", RemoveFromModels);

    group.MapPut("/addToFeatureSets", AddToFeatureSets);
    group.MapPut("/removeFromFeatureSets", RemoveFromFeatureSets);

    group.MapPut("/addToPolicies", AddToPolicies);
    group.MapPut("/removeFromPolicies", RemoveFromPolicies);

    group.MapPut("/addToLineageNodes", AddToLineageNodes);
    group.MapPut("/removeFromLineageNodes", RemoveFromLineageNodes);


        return app;
    }

    private static async Task<IResult> Create(
        AnalyticsWorkspaceRequest request,
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToAnalyticsWorkspace( request );

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
        AnalyticsWorkspaceRequest request,
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToAnalyticsWorkspace( request );

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
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {

        var analyticsWorkspace = await service.Get(identifier, cancellationToken);
        return analyticsWorkspace is null ? Results.NotFound() : Results.Ok( analyticsWorkspace );
    }


    private static async Task<IResult> GetAll(
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( AnalyticsWorkspaceResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToDatasets(
        MultipleAssociationRequest request,
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDatasets(
        MultipleAssociationRequest request,
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToDataSources(
        MultipleAssociationRequest request,
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDataSources(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDataSources(
        MultipleAssociationRequest request,
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDataSources(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToPipelines(
        MultipleAssociationRequest request,
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToPipelines(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromPipelines(
        MultipleAssociationRequest request,
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromPipelines(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToDashboards(
        MultipleAssociationRequest request,
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDashboards(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDashboards(
        MultipleAssociationRequest request,
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDashboards(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToReports(
        MultipleAssociationRequest request,
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToReports(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromReports(
        MultipleAssociationRequest request,
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromReports(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToNotebooks(
        MultipleAssociationRequest request,
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToNotebooks(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromNotebooks(
        MultipleAssociationRequest request,
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromNotebooks(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToModels(
        MultipleAssociationRequest request,
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToModels(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromModels(
        MultipleAssociationRequest request,
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromModels(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToFeatureSets(
        MultipleAssociationRequest request,
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToFeatureSets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromFeatureSets(
        MultipleAssociationRequest request,
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromFeatureSets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToPolicies(
        MultipleAssociationRequest request,
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToPolicies(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromPolicies(
        MultipleAssociationRequest request,
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromPolicies(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToLineageNodes(
        MultipleAssociationRequest request,
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToLineageNodes(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromLineageNodes(
        MultipleAssociationRequest request,
        IAnalyticsWorkspaceService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromLineageNodes(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static AnalyticsWorkspace mapRequestToAnalyticsWorkspace( AnalyticsWorkspaceRequest request ) {
        var model = new AnalyticsWorkspace
        {
            Id = request.Id,
            Name = request.Name,
            BusinessDomain = request.BusinessDomain,
            OwnerTeam = request.OwnerTeam,
            GovernanceTier = request.GovernanceTier,
        };
        return model;
    }

}

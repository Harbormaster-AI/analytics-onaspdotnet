using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class AccessPolicyEndpoints
{
    public static IEndpointRouteBuilder MapAccessPolicyEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/accessPolicy").WithTags("AccessPolicys");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignWorkspace", AssignWorkspace);
        group.MapPut("/unassignWorkspace", UnassignWorkspace);

    group.MapPut("/addToDatasets", AddToDatasets);
    group.MapPut("/removeFromDatasets", RemoveFromDatasets);

    group.MapPut("/addToDashboards", AddToDashboards);
    group.MapPut("/removeFromDashboards", RemoveFromDashboards);

    group.MapPut("/addToReports", AddToReports);
    group.MapPut("/removeFromReports", RemoveFromReports);

    group.MapPut("/addToModels", AddToModels);
    group.MapPut("/removeFromModels", RemoveFromModels);

    group.MapPut("/addToFeatureSets", AddToFeatureSets);
    group.MapPut("/removeFromFeatureSets", RemoveFromFeatureSets);


        return app;
    }

    private static async Task<IResult> Create(
        AccessPolicyRequest request,
        IAccessPolicyService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToAccessPolicy( request );

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
        AccessPolicyRequest request,
        IAccessPolicyService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToAccessPolicy( request );

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
        IAccessPolicyService service,
        CancellationToken cancellationToken) {

        var accessPolicy = await service.Get(identifier, cancellationToken);
        return accessPolicy is null ? Results.NotFound() : Results.Ok( accessPolicy );
    }


    private static async Task<IResult> GetAll(
        IAccessPolicyService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( AccessPolicyResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IAccessPolicyService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignWorkspace(
        AssociationRequest request,
        IAccessPolicyService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignWorkspace(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignWorkspace(
    AssociationRequest request,
    IAccessPolicyService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignWorkspace(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToDatasets(
        MultipleAssociationRequest request,
        IAccessPolicyService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDatasets(
        MultipleAssociationRequest request,
        IAccessPolicyService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToDashboards(
        MultipleAssociationRequest request,
        IAccessPolicyService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDashboards(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDashboards(
        MultipleAssociationRequest request,
        IAccessPolicyService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDashboards(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToReports(
        MultipleAssociationRequest request,
        IAccessPolicyService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToReports(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromReports(
        MultipleAssociationRequest request,
        IAccessPolicyService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromReports(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToModels(
        MultipleAssociationRequest request,
        IAccessPolicyService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToModels(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromModels(
        MultipleAssociationRequest request,
        IAccessPolicyService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromModels(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToFeatureSets(
        MultipleAssociationRequest request,
        IAccessPolicyService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToFeatureSets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromFeatureSets(
        MultipleAssociationRequest request,
        IAccessPolicyService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromFeatureSets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static AccessPolicy mapRequestToAccessPolicy( AccessPolicyRequest request ) {
        var model = new AccessPolicy
        {
            Id = request.Id,
            Name = request.Name,
            SubjectName = request.SubjectName,
            AccessLevel = request.AccessLevel,
            SubjectType = request.SubjectType,
        };
        return model;
    }

}

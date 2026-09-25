
using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class QualityCheckEndpoints
{
    public static IEndpointRouteBuilder MapQualityCheckEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/qualityCheck").WithTags("QualityChecks");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignRule", AssignRule);
        group.MapPut("/unassignRule", UnassignRule);
        group.MapPut("/assignDataset", AssignDataset);
        group.MapPut("/unassignDataset", UnassignDataset);


        return app;
    }

    private static async Task<IResult> Create(
        QualityCheckRequest request,
        IQualityCheckService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToQualityCheck( request );

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
        QualityCheckRequest request,
        IQualityCheckService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToQualityCheck( request );

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
        IQualityCheckService service,
        CancellationToken cancellationToken) {

        var qualityCheck = await service.Get(identifier, cancellationToken);
        return qualityCheck is null ? Results.NotFound() : Results.Ok( qualityCheck );
    }


    private static async Task<IResult> GetAll(
        IQualityCheckService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( QualityCheckResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IQualityCheckService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignRule(
        AssociationRequest request,
        IQualityCheckService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignRule(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignRule(
    AssociationRequest request,
    IQualityCheckService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignRule(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignDataset(
        AssociationRequest request,
        IQualityCheckService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignDataset(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignDataset(
    AssociationRequest request,
    IQualityCheckService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignDataset(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static QualityCheck mapRequestToQualityCheck( QualityCheckRequest request ) {
        var model = new QualityCheck
        {
            Id = request.Id,
            CheckedAt = request.CheckedAt,
            ObservedValue = request.ObservedValue,
            SampleSize = request.SampleSize,
            Status = request.Status,
        };
        return model;
    }

}

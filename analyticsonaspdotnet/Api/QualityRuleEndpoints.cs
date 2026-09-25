
using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class QualityRuleEndpoints
{
    public static IEndpointRouteBuilder MapQualityRuleEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/qualityRule").WithTags("QualityRules");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignDataset", AssignDataset);
        group.MapPut("/unassignDataset", UnassignDataset);

    group.MapPut("/addToChecks", AddToChecks);
    group.MapPut("/removeFromChecks", RemoveFromChecks);


        return app;
    }

    private static async Task<IResult> Create(
        QualityRuleRequest request,
        IQualityRuleService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToQualityRule( request );

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
        QualityRuleRequest request,
        IQualityRuleService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToQualityRule( request );

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
        IQualityRuleService service,
        CancellationToken cancellationToken) {

        var qualityRule = await service.Get(identifier, cancellationToken);
        return qualityRule is null ? Results.NotFound() : Results.Ok( qualityRule );
    }


    private static async Task<IResult> GetAll(
        IQualityRuleService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( QualityRuleResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IQualityRuleService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignDataset(
        AssociationRequest request,
        IQualityRuleService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignDataset(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignDataset(
    AssociationRequest request,
    IQualityRuleService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignDataset(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToChecks(
        MultipleAssociationRequest request,
        IQualityRuleService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToChecks(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromChecks(
        MultipleAssociationRequest request,
        IQualityRuleService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromChecks(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static QualityRule mapRequestToQualityRule( QualityRuleRequest request ) {
        var model = new QualityRule
        {
            Id = request.Id,
            Name = request.Name,
            Threshold = request.Threshold,
            TargetField = request.TargetField,
            Dimension = request.Dimension,
            Operator_ = request.Operator_,
        };
        return model;
    }

}

using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class ForecastEndpoints
{
    public static IEndpointRouteBuilder MapForecastEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/forecast").WithTags("Forecasts");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignModelVersion", AssignModelVersion);
        group.MapPut("/unassignModelVersion", UnassignModelVersion);
        group.MapPut("/assignTimeSeries", AssignTimeSeries);
        group.MapPut("/unassignTimeSeries", UnassignTimeSeries);

    group.MapPut("/addToDatasets", AddToDatasets);
    group.MapPut("/removeFromDatasets", RemoveFromDatasets);


        return app;
    }

    private static async Task<IResult> Create(
        ForecastRequest request,
        IForecastService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToForecast( request );

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
        ForecastRequest request,
        IForecastService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToForecast( request );

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
        IForecastService service,
        CancellationToken cancellationToken) {

        var forecast = await service.Get(identifier, cancellationToken);
        return forecast is null ? Results.NotFound() : Results.Ok( forecast );
    }


    private static async Task<IResult> GetAll(
        IForecastService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( ForecastResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        IForecastService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignModelVersion(
        AssociationRequest request,
        IForecastService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignModelVersion(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignModelVersion(
    AssociationRequest request,
    IForecastService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignModelVersion(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignTimeSeries(
        AssociationRequest request,
        IForecastService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignTimeSeries(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignTimeSeries(
    AssociationRequest request,
    IForecastService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignTimeSeries(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToDatasets(
        MultipleAssociationRequest request,
        IForecastService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDatasets(
        MultipleAssociationRequest request,
        IForecastService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static Forecast mapRequestToForecast( ForecastRequest request ) {
        var model = new Forecast
        {
            Id = request.Id,
            Name = request.Name,
            Horizon = request.Horizon,
            Granularity = request.Granularity,
        };
        return model;
    }

}

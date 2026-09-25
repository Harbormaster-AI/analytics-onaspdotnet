
using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class TimeSeriesEndpoints
{
    public static IEndpointRouteBuilder MapTimeSeriesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/timeSeries").WithTags("TimeSeriess");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);


    group.MapPut("/addToDatasets", AddToDatasets);
    group.MapPut("/removeFromDatasets", RemoveFromDatasets);

    group.MapPut("/addToForecasts", AddToForecasts);
    group.MapPut("/removeFromForecasts", RemoveFromForecasts);

    group.MapPut("/addToAnomalies", AddToAnomalies);
    group.MapPut("/removeFromAnomalies", RemoveFromAnomalies);


        return app;
    }

    private static async Task<IResult> Create(
        TimeSeriesRequest request,
        ITimeSeriesService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToTimeSeries( request );

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
        TimeSeriesRequest request,
        ITimeSeriesService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToTimeSeries( request );

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
        ITimeSeriesService service,
        CancellationToken cancellationToken) {

        var timeSeries = await service.Get(identifier, cancellationToken);
        return timeSeries is null ? Results.NotFound() : Results.Ok( timeSeries );
    }


    private static async Task<IResult> GetAll(
        ITimeSeriesService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( TimeSeriesResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        ITimeSeriesService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToDatasets(
        MultipleAssociationRequest request,
        ITimeSeriesService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDatasets(
        MultipleAssociationRequest request,
        ITimeSeriesService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToForecasts(
        MultipleAssociationRequest request,
        ITimeSeriesService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToForecasts(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromForecasts(
        MultipleAssociationRequest request,
        ITimeSeriesService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromForecasts(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToAnomalies(
        MultipleAssociationRequest request,
        ITimeSeriesService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToAnomalies(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromAnomalies(
        MultipleAssociationRequest request,
        ITimeSeriesService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromAnomalies(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static TimeSeries mapRequestToTimeSeries( TimeSeriesRequest request ) {
        var model = new TimeSeries
        {
            Id = request.Id,
            Name = request.Name,
            Timezone = request.Timezone,
            Granularity = request.Granularity,
        };
        return model;
    }

}

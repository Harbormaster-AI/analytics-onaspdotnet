using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class SubscriberEndpoints
{
    public static IEndpointRouteBuilder MapSubscriberEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/subscriber").WithTags("Subscribers");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);


    group.MapPut("/addToAlerts", AddToAlerts);
    group.MapPut("/removeFromAlerts", RemoveFromAlerts);


        return app;
    }

    private static async Task<IResult> Create(
        SubscriberRequest request,
        ISubscriberService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToSubscriber( request );

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
        SubscriberRequest request,
        ISubscriberService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToSubscriber( request );

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
        ISubscriberService service,
        CancellationToken cancellationToken) {

        var subscriber = await service.Get(identifier, cancellationToken);
        return subscriber is null ? Results.NotFound() : Results.Ok( subscriber );
    }


    private static async Task<IResult> GetAll(
        ISubscriberService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( SubscriberResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        ISubscriberService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToAlerts(
        MultipleAssociationRequest request,
        ISubscriberService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToAlerts(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromAlerts(
        MultipleAssociationRequest request,
        ISubscriberService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromAlerts(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static Subscriber mapRequestToSubscriber( SubscriberRequest request ) {
        var model = new Subscriber
        {
            Id = request.Id,
            Name = request.Name,
            Address = request.Address,
            Channel = request.Channel,
        };
        return model;
    }

}


using analyticsonaspdotnet.Service;
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Api;

public static class NotebookEndpoints
{
    public static IEndpointRouteBuilder MapNotebookEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/notebook").WithTags("Notebooks");

        group.MapPost("/create", Create);
        group.MapPost("/get", Get);
        group.MapGet("/getAll", GetAll);
        group.MapPost("/update", Update);
        group.MapPost("/delete", Delete);

        group.MapPut("/assignWorkspace", AssignWorkspace);
        group.MapPut("/unassignWorkspace", UnassignWorkspace);

    group.MapPut("/addToDatasets", AddToDatasets);
    group.MapPut("/removeFromDatasets", RemoveFromDatasets);

    group.MapPut("/addToExperiments", AddToExperiments);
    group.MapPut("/removeFromExperiments", RemoveFromExperiments);

    group.MapPut("/addToQueries", AddToQueries);
    group.MapPut("/removeFromQueries", RemoveFromQueries);


        return app;
    }

    private static async Task<IResult> Create(
        NotebookRequest request,
        INotebookService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToNotebook( request );

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
        NotebookRequest request,
        INotebookService service,
        CancellationToken cancellationToken) {

        var model = mapRequestToNotebook( request );

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
        INotebookService service,
        CancellationToken cancellationToken) {

        var notebook = await service.Get(identifier, cancellationToken);
        return notebook is null ? Results.NotFound() : Results.Ok( notebook );
    }


    private static async Task<IResult> GetAll(
        INotebookService service,
        CancellationToken cancellationToken) {

        var all = await service.GetAll(cancellationToken);
        return Results.Ok( all.Select( NotebookResponse.FromModel ) );
        }

    private static async Task<IResult> Delete(
        IdentifierRequest identifier,
        INotebookService service,
        CancellationToken cancellationToken) {
        var deleted = await service.Delete(identifier, cancellationToken);
        return deleted ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> AssignWorkspace(
        AssociationRequest request,
        INotebookService service,
        CancellationToken cancellationToken) {
        var assigned = await service.AssignWorkspace(request, cancellationToken);
        return assigned ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> UnassignWorkspace(
    AssociationRequest request,
    INotebookService service,
    CancellationToken cancellationToken) {
        var unassigned = await service.UnassignWorkspace(request, cancellationToken);
        return unassigned ? Results.NoContent() : Results.NotFound();
    }


    private static async Task<IResult> AddToDatasets(
        MultipleAssociationRequest request,
        INotebookService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToDatasets(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromDatasets(
        MultipleAssociationRequest request,
        INotebookService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromDatasets(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToExperiments(
        MultipleAssociationRequest request,
        INotebookService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToExperiments(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromExperiments(
        MultipleAssociationRequest request,
        INotebookService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromExperiments(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static async Task<IResult> AddToQueries(
        MultipleAssociationRequest request,
        INotebookService service,
        CancellationToken cancellationToken) {
        var addTo = await service.AddToQueries(request, cancellationToken);
        return addTo ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> RemoveFromQueries(
        MultipleAssociationRequest request,
        INotebookService service,
        CancellationToken cancellationToken) {
        var removeFrom = await service.RemoveFromQueries(request, cancellationToken);
        return removeFrom ? Results.NoContent() : Results.NotFound();
    }
    private static Notebook mapRequestToNotebook( NotebookRequest request ) {
        var model = new Notebook
        {
            Id = request.Id,
            Title = request.Title,
            Repository = request.Repository,
            Language = request.Language,
        };
        return model;
    }

}

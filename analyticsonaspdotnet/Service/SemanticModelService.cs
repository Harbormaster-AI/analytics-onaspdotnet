
using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;
using analyticsonaspdotnet.Telemetry;

namespace analyticsonaspdotnet.Service;

public interface ISemanticModelService {

    Task Create(SemanticModel model , CancellationToken cancellationToken);
    Task<bool> Update(SemanticModel model, CancellationToken cancellationToken);
    Task<SemanticModel?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<SemanticModel>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);
    // ------------------------------
    // Single Associations
    // -------------------------------

    Task<bool> AddToDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToDimensions(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromDimensions(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToMeasures(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromMeasures(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToGlossaryTerms(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromGlossaryTerms(MultipleAssociationRequest request, CancellationToken cancellationToken);

}

public class SemanticModelService : ISemanticModelService
{
    private readonly ApplicationTelemetry _telemetry;
    private readonly ISemanticModelRepository _repository;
    private readonly ILogger<SemanticModelService> _logger;
    private readonly IServiceResolver _serviceResolver;


    public SemanticModelService(
        ApplicationTelemetry telemetry,
        ISemanticModelRepository repository,
        ILogger<SemanticModelService> logger,
        IServiceResolver serviceResolver)
    {
        _telemetry = telemetry;
        _repository = repository;
        _logger = logger;
        _serviceResolver = serviceResolver;
    }

    public async Task Create(SemanticModel model, CancellationToken cancellationToken)
    {
        try
        {
            await _telemetry.Execute(
                "SemanticModel",
                "CreateSemanticModel",
                () => _repository.AddAsync(model, cancellationToken));
        }
        catch (Exception ex)
        {
            _logger.LogError(
                    ex,
                    "Unexpected error while creating Transaction.");
        }
    }

    public async Task<bool> Update(SemanticModel model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.Name = model.Name;
            existing.Version = model.Version;
            existing.Grain = model.Grain;

            await _telemetry.Execute(
                "SemanticModel",
                "UpdateSemanticModel",
                () => _repository.UpdateAsync(existing, cancellationToken));
        }
        catch (Exception ex)
        {
            _logger.LogError(
                    ex,
                    "Unexpected error while creating Transaction.");
            return false;
        }
        return true;
    }

    public Task<SemanticModel?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<SemanticModel>> GetAll(CancellationToken cancellationToken)
    => _repository.GetAllAsync(cancellationToken);

    public async Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken)
    {
        var existing = await _repository.GetByIdAsync(identifier.Id, cancellationToken);
        if (existing is null)
        {
            return false;
        }

        try
        {
            await _telemetry.Execute(
                "SemanticModel",
                "UpdateSemanticModel",
                () => _repository.DeleteAsync(existing, cancellationToken));
        }
        catch (Exception ex)
        {
            _logger.LogError(
                    ex,
                    "Unexpected error while creating Transaction.");
            return false;
        }
        return true;
    }


    public async Task<bool> AddToDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        try {
            await _telemetry.Execute(
                "SemanticModel",
                "AddToDatasets",
                () => _repository.AddToDatasetsAsync(request, cancellationToken));
        }
        catch (Exception ex)
        {
           _logger.LogError(
                   ex,
                   "Unexpected error while creating Transaction.");
            return false;
        }
        return true;
    }

    public async Task<bool> RemoveFromDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        try {
            await _telemetry.Execute(
                "SemanticModel",
                "RemoveFromDatasets",
                () => _repository.RemoveFromDatasetsAsync(request, cancellationToken));
        }
        catch (Exception ex)
        {
            _logger.LogError(
                    ex,
                    "Unexpected error while creating Transaction.");
            return false;
        }
        return true;
    }

    public async Task<bool> AddToMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        try {
            await _telemetry.Execute(
                "SemanticModel",
                "AddToMetrics",
                () => _repository.AddToMetricsAsync(request, cancellationToken));
        }
        catch (Exception ex)
        {
           _logger.LogError(
                   ex,
                   "Unexpected error while creating Transaction.");
            return false;
        }
        return true;
    }

    public async Task<bool> RemoveFromMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        try {
            await _telemetry.Execute(
                "SemanticModel",
                "RemoveFromMetrics",
                () => _repository.RemoveFromMetricsAsync(request, cancellationToken));
        }
        catch (Exception ex)
        {
            _logger.LogError(
                    ex,
                    "Unexpected error while creating Transaction.");
            return false;
        }
        return true;
    }

    public async Task<bool> AddToDimensions(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        try {
            await _telemetry.Execute(
                "SemanticModel",
                "AddToDimensions",
                () => _repository.AddToDimensionsAsync(request, cancellationToken));
        }
        catch (Exception ex)
        {
           _logger.LogError(
                   ex,
                   "Unexpected error while creating Transaction.");
            return false;
        }
        return true;
    }

    public async Task<bool> RemoveFromDimensions(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        try {
            await _telemetry.Execute(
                "SemanticModel",
                "RemoveFromDimensions",
                () => _repository.RemoveFromDimensionsAsync(request, cancellationToken));
        }
        catch (Exception ex)
        {
            _logger.LogError(
                    ex,
                    "Unexpected error while creating Transaction.");
            return false;
        }
        return true;
    }

    public async Task<bool> AddToMeasures(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        try {
            await _telemetry.Execute(
                "SemanticModel",
                "AddToMeasures",
                () => _repository.AddToMeasuresAsync(request, cancellationToken));
        }
        catch (Exception ex)
        {
           _logger.LogError(
                   ex,
                   "Unexpected error while creating Transaction.");
            return false;
        }
        return true;
    }

    public async Task<bool> RemoveFromMeasures(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        try {
            await _telemetry.Execute(
                "SemanticModel",
                "RemoveFromMeasures",
                () => _repository.RemoveFromMeasuresAsync(request, cancellationToken));
        }
        catch (Exception ex)
        {
            _logger.LogError(
                    ex,
                    "Unexpected error while creating Transaction.");
            return false;
        }
        return true;
    }

    public async Task<bool> AddToGlossaryTerms(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        try {
            await _telemetry.Execute(
                "SemanticModel",
                "AddToGlossaryTerms",
                () => _repository.AddToGlossaryTermsAsync(request, cancellationToken));
        }
        catch (Exception ex)
        {
           _logger.LogError(
                   ex,
                   "Unexpected error while creating Transaction.");
            return false;
        }
        return true;
    }

    public async Task<bool> RemoveFromGlossaryTerms(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        try {
            await _telemetry.Execute(
                "SemanticModel",
                "RemoveFromGlossaryTerms",
                () => _repository.RemoveFromGlossaryTermsAsync(request, cancellationToken));
        }
        catch (Exception ex)
        {
            _logger.LogError(
                    ex,
                    "Unexpected error while creating Transaction.");
            return false;
        }
        return true;
    }



}

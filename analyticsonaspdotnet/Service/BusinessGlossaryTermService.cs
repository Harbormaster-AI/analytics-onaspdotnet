using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Service;

public interface IBusinessGlossaryTermService {

    Task Create(BusinessGlossaryTerm model , CancellationToken cancellationToken);
    Task<bool> Update(BusinessGlossaryTerm model, CancellationToken cancellationToken);
    Task<BusinessGlossaryTerm?> Get(IdentifierRequest identifier, CancellationToken cancellationToken);
    Task<IReadOnlyList<BusinessGlossaryTerm>> GetAll(CancellationToken cancellationToken);
    Task<bool> Delete(IdentifierRequest identifier, CancellationToken cancellationToken);

    // ------------------------------
    // Single Associations
    // -------------------------------

    Task<bool> AddToRelatedTerms(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromRelatedTerms(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToDimensions(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromDimensions(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> AddToMeasures(MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task<bool> RemoveFromMeasures(MultipleAssociationRequest request, CancellationToken cancellationToken);

}

public class BusinessGlossaryTermService : IBusinessGlossaryTermService
{
    private readonly IBusinessGlossaryTermRepository _repository;
    private readonly ILogger<BusinessGlossaryTermService> _logger;

    public BusinessGlossaryTermService(
        IBusinessGlossaryTermRepository repository, ILogger<BusinessGlossaryTermService> logger )
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task Create(BusinessGlossaryTerm model, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.AddAsync(model, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
        }
    }

    public async Task<bool> Update(BusinessGlossaryTerm model, CancellationToken cancellationToken)
    {
        try {
            var existing = await _repository.GetByIdAsync(model.Id, cancellationToken);
            if (existing is null)
            {
                return false;
            }
            existing.Term = model.Term;
            existing.Definition = model.Definition;
            existing.Steward = model.Steward;

            await _repository.UpdateAsync(existing, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
            return false;
        }
        return true;
    }

    public Task<BusinessGlossaryTerm?> Get(IdentifierRequest identifier, CancellationToken cancellationToken)
    => _repository.GetByIdAsync(identifier.Id, cancellationToken);

    public Task<IReadOnlyList<BusinessGlossaryTerm>> GetAll(CancellationToken cancellationToken)
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
            await _repository.DeleteAsync(existing, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
            return false;
        }
        return true;

    }


    public async Task<bool> AddToRelatedTerms(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromRelatedTerms(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromMetrics(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromDatasets(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToDimensions(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromDimensions(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }

    public async Task<bool> AddToMeasures(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }
    public async Task<bool> RemoveFromMeasures(MultipleAssociationRequest request, CancellationToken cancellationToken) {
        return true;
    }



}

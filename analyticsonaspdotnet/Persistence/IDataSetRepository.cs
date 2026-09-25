using analyticsonaspdotnet.Domain;
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Persistence;

public interface IDataSetRepository
{
    Task<DataSet?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<DataSet>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(DataSet dataSet, CancellationToken cancellationToken);
    Task UpdateAsync(DataSet dataSet, CancellationToken cancellationToken);
    Task DeleteAsync(DataSet dataSet, CancellationToken cancellationToken);

    Task AddToSourcesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromSourcesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToPipelinesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromPipelinesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToSemanticModelsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromSemanticModelsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToDimensionsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromDimensionsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToMeasuresAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromMeasuresAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToMetricsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromMetricsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToQualityRulesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromQualityRulesAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task AddToTagsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);
    Task RemoveFromTagsAsync( MultipleAssociationRequest request, CancellationToken cancellationToken);

}

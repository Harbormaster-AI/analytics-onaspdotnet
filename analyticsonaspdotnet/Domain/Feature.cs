using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class Feature
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? FeatureId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual string? Description { get; set; } 
public virtual FeatureSet? FeatureSet { get; set; } 
public virtual ICollection<DataSet> SourceDatasets { get; set; } = new List<DataSet>();
public virtual ICollection<Model> Models { get; set; } = new List<Model>();
public virtual ICollection<TrainingRun> TrainingRuns { get; set; } = new List<TrainingRun>();
 public virtual DataType? DataType { get; set; } 

    public static Feature FromRequest(FeatureRequest request) {
        return new Feature {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            DataType = request.DataType,
        };
    }
}

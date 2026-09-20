using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class Model
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? ModelId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual string? TaskDescription { get; set; } 
public virtual AnalyticsWorkspace? Workspace { get; set; } 
public virtual ICollection<ModelVersion> Versions { get; set; } = new List<ModelVersion>();
public virtual ICollection<FeatureSet> FeatureSets { get; set; } = new List<FeatureSet>();
public virtual ICollection<Experiment> Experiments { get; set; } = new List<Experiment>();
public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
 public virtual ModelType? ModelType { get; set; } 

    public static Model FromRequest(ModelRequest request) {
        return new Model {
            Id = request.Id,
            Name = request.Name,
            TaskDescription = request.TaskDescription,
            ModelType = request.ModelType,
        };
    }
}

using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class FeatureSet
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? FeaturesetId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual CronSchedule? RefreshSchedule { get; set; } 
public virtual AnalyticsWorkspace? Workspace { get; set; } 
public virtual ICollection<Feature> Features { get; set; } = new List<Feature>();
public virtual ICollection<DataSet> Datasets { get; set; } = new List<DataSet>();
public virtual ICollection<Model> Models { get; set; } = new List<Model>();
public virtual ICollection<ModelVersion> ModelVersions { get; set; } = new List<ModelVersion>();
public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
 public virtual FeatureStoreType? StoreType { get; set; } 

    public static FeatureSet FromRequest(FeatureSetRequest request) {
        return new FeatureSet {
            Id = request.Id,
            Name = request.Name,
            RefreshSchedule = request.RefreshSchedule,
            StoreType = request.StoreType,
        };
    }
}

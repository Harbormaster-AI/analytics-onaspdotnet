using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class Tag
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? TagId { get; set; } 
 public virtual string? Name { get; set; } 
public virtual ICollection<DataSet> Datasets { get; set; } = new List<DataSet>();
public virtual ICollection<Model_> Models { get; set; } = new List<Model_>();
public virtual ICollection<ModelVersion> ModelVersions { get; set; } = new List<ModelVersion>();
public virtual ICollection<Dashboard> Dashboards { get; set; } = new List<Dashboard>();
public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
public virtual ICollection<FeatureSet> FeatureSets { get; set; } = new List<FeatureSet>();
public virtual ICollection<Metric> Metrics { get; set; } = new List<Metric>();
 public virtual TagCategory? Category { get; set; } 

    public static Tag FromRequest(TagRequest request) {
        return new Tag {
            Id = request.Id,
            Name = request.Name,
            Category = request.Category,
        };
    }
}

using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class DataSet
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? DatasetId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual string? SchemaVersion { get; set; } 
 public virtual CronSchedule? RefreshSchedule { get; set; } 
 public virtual bool? Sensitive { get; set; } 
public virtual AnalyticsWorkspace? Workspace { get; set; } 
public virtual ICollection<DataSource> Sources { get; set; } = new List<DataSource>();
public virtual ICollection<DataPipeline> Pipelines { get; set; } = new List<DataPipeline>();
public virtual ICollection<SemanticModel> SemanticModels { get; set; } = new List<SemanticModel>();
public virtual ICollection<Dimension> Dimensions { get; set; } = new List<Dimension>();
public virtual ICollection<Measure> Measures { get; set; } = new List<Measure>();
public virtual ICollection<Metric> Metrics { get; set; } = new List<Metric>();
public virtual ICollection<QualityRule> QualityRules { get; set; } = new List<QualityRule>();
public virtual LineageNode? LineageNode { get; set; } 
public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
 public virtual DataFormat? DataFormat { get; set; } 

    public static DataSet FromRequest(DataSetRequest request) {
        return new DataSet {
            Id = request.Id,
            Name = request.Name,
            SchemaVersion = request.SchemaVersion,
            RefreshSchedule = request.RefreshSchedule,
            Sensitive = request.Sensitive,
            DataFormat = request.DataFormat,
        };
    }
}

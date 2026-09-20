using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class DataSource
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? DatasourceId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual ConnectionInfo? Connection { get; set; } 
 public virtual bool? Streaming { get; set; } 
public virtual AnalyticsWorkspace? Workspace { get; set; } 
public virtual ICollection<DataSet> ProducedDatasets { get; set; } = new List<DataSet>();
public virtual ICollection<DataPipeline> Pipelines { get; set; } = new List<DataPipeline>();
 public virtual DataSourceType? SourceType { get; set; } 
 public virtual DataFormat? Format { get; set; } 

    public static DataSource FromRequest(DataSourceRequest request) {
        return new DataSource {
            Id = request.Id,
            Name = request.Name,
            Connection = request.Connection,
            Streaming = request.Streaming,
            SourceType = request.SourceType,
            Format = request.Format,
        };
    }
}

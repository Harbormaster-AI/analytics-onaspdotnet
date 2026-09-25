
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class DataPipeline
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? DatapipelineId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual CronSchedule? Schedule { get; set; } 
public virtual AnalyticsWorkspace? Workspace { get; set; } 
public virtual ICollection<DataTask> Tasks { get; set; } = new List<DataTask>();
public virtual ICollection<DataSource> Sources { get; set; } = new List<DataSource>();
public virtual ICollection<DataSet> Outputs { get; set; } = new List<DataSet>();
public virtual LineageNode? LineageNode { get; set; } 
 public virtual PipelineTriggerType? TriggerType { get; set; } 
 public virtual PipelineStatus? Status { get; set; } 

    public static DataPipeline FromRequest(DataPipelineRequest request) {
        return new DataPipeline {
            Id = request.Id,
            Name = request.Name,
            Schedule = request.Schedule,
            TriggerType = request.TriggerType,
            Status = request.Status,
        };
    }
}

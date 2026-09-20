using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class DataTask
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? DatataskId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual string? Command { get; set; } 
 public virtual int? Retries { get; set; } 
public virtual DataPipeline? Pipeline { get; set; } 
public virtual ICollection<DataSet> InputDatasets { get; set; } = new List<DataSet>();
public virtual ICollection<DataSet> OutputDatasets { get; set; } = new List<DataSet>();
 public virtual DataTaskType? TaskType { get; set; } 

    public static DataTask FromRequest(DataTaskRequest request) {
        return new DataTask {
            Id = request.Id,
            Name = request.Name,
            Command = request.Command,
            Retries = request.Retries,
            TaskType = request.TaskType,
        };
    }
}

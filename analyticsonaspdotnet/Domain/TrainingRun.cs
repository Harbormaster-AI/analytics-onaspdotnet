using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class TrainingRun
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? TrainingrunId { get; set; } 
 public virtual string? RunLabel { get; set; } 
 public virtual DateOnly? StartedAt { get; set; } 
 public virtual DateOnly? CompletedAt { get; set; } 
public virtual Experiment? Experiment { get; set; } 
public virtual ModelVersion? ModelVersion { get; set; } 
public virtual ICollection<DataSet> InputDatasets { get; set; } = new List<DataSet>();
public virtual ICollection<Feature> Features { get; set; } = new List<Feature>();
public virtual ICollection<RunMetric> RunMetrics { get; set; } = new List<RunMetric>();
public virtual ICollection<RunParameter> RunParameters { get; set; } = new List<RunParameter>();
 public virtual TrainingStatus? Status { get; set; } 

    public static TrainingRun FromRequest(TrainingRunRequest request) {
        return new TrainingRun {
            Id = request.Id,
            RunLabel = request.RunLabel,
            StartedAt = request.StartedAt,
            CompletedAt = request.CompletedAt,
            Status = request.Status,
        };
    }
}

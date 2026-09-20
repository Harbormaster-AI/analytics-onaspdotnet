using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class RunMetric
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? RunmetricId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual decimal? Value { get; set; } 
public virtual TrainingRun? TrainingRun { get; set; } 
public virtual Metric? Metric { get; set; } 
public virtual DataSet? Dataset { get; set; } 

    public static RunMetric FromRequest(RunMetricRequest request) {
        return new RunMetric {
            Id = request.Id,
            Name = request.Name,
            Value = request.Value,
        };
    }
}

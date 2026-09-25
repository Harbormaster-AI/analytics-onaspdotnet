
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class EvaluationMetric
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? EvaluationmetricId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual decimal? Value { get; set; } 
public virtual ModelVersion? ModelVersion { get; set; } 
public virtual Metric? Metric { get; set; } 
public virtual DataSet? Dataset { get; set; } 

    public static EvaluationMetric FromRequest(EvaluationMetricRequest request) {
        return new EvaluationMetric {
            Id = request.Id,
            Name = request.Name,
            Value = request.Value,
        };
    }
}

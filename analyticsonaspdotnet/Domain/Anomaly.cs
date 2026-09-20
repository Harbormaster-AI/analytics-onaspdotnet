using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class Anomaly
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? AnomalyId { get; set; } 
 public virtual DateOnly? OccurredAt { get; set; } 
 public virtual string? Details { get; set; } 
public virtual TimeSeries? TimeSeries { get; set; } 
public virtual Alert? Alert { get; set; } 
public virtual DataSet? Dataset { get; set; } 
 public virtual AnomalyType? AnomalyType { get; set; } 
 public virtual AlertSeverity? Severity { get; set; } 

    public static Anomaly FromRequest(AnomalyRequest request) {
        return new Anomaly {
            Id = request.Id,
            OccurredAt = request.OccurredAt,
            Details = request.Details,
            AnomalyType = request.AnomalyType,
            Severity = request.Severity,
        };
    }
}


using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class Alert
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? AlertId { get; set; } 
 public virtual string? Title { get; set; } 
 public virtual DateOnly? CreatedAt { get; set; } 
public virtual Metric? Metric { get; set; } 
public virtual Dashboard? Dashboard { get; set; } 
public virtual DataSet? Dataset { get; set; } 
public virtual QualityRule? Rule { get; set; } 
public virtual ICollection<Anomaly> Anomalies { get; set; } = new List<Anomaly>();
public virtual ICollection<Subscriber> Subscribers { get; set; } = new List<Subscriber>();
 public virtual AlertSeverity? Severity { get; set; } 
 public virtual AlertStatus? Status { get; set; } 

    public static Alert FromRequest(AlertRequest request) {
        return new Alert {
            Id = request.Id,
            Title = request.Title,
            CreatedAt = request.CreatedAt,
            Severity = request.Severity,
            Status = request.Status,
        };
    }
}

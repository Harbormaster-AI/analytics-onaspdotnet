
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class QualityCheck
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? QualitycheckId { get; set; } 
 public virtual DateOnly? CheckedAt { get; set; } 
 public virtual decimal? ObservedValue { get; set; } 
 public virtual int? SampleSize { get; set; } 
public virtual QualityRule? Rule { get; set; } 
public virtual DataSet? Dataset { get; set; } 
 public virtual QualityStatus? Status { get; set; } 

    public static QualityCheck FromRequest(QualityCheckRequest request) {
        return new QualityCheck {
            Id = request.Id,
            CheckedAt = request.CheckedAt,
            ObservedValue = request.ObservedValue,
            SampleSize = request.SampleSize,
            Status = request.Status,
        };
    }
}

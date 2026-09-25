
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class QualityRule
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? QualityruleId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual Threshold? Threshold { get; set; } 
 public virtual string? TargetField { get; set; } 
public virtual DataSet? Dataset { get; set; } 
public virtual ICollection<QualityCheck> Checks { get; set; } = new List<QualityCheck>();
 public virtual QualityDimension? Dimension { get; set; } 
 public virtual ComparisonOperator? Operator_ { get; set; } 

    public static QualityRule FromRequest(QualityRuleRequest request) {
        return new QualityRule {
            Id = request.Id,
            Name = request.Name,
            Threshold = request.Threshold,
            TargetField = request.TargetField,
            Dimension = request.Dimension,
            Operator_ = request.Operator_,
        };
    }
}

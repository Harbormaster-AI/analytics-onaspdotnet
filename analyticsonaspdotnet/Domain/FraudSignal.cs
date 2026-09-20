using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class FraudSignal
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? FraudsignalId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual string? RuleLogic { get; set; } 
public virtual FraudScenario? Scenario { get; set; } 
public virtual DataSet? Dataset { get; set; } 
public virtual ModelVersion? ModelVersion { get; set; } 
 public virtual FraudSignalType? SignalType { get; set; } 

    public static FraudSignal FromRequest(FraudSignalRequest request) {
        return new FraudSignal {
            Id = request.Id,
            Name = request.Name,
            RuleLogic = request.RuleLogic,
            SignalType = request.SignalType,
        };
    }
}

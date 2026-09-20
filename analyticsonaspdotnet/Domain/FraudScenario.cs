using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class FraudScenario
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? FraudscenarioId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual string? RiskAppetite { get; set; } 
public virtual ICollection<Model_> Models { get; set; } = new List<Model_>();
public virtual ICollection<DataSet> Datasets { get; set; } = new List<DataSet>();
public virtual ICollection<Alert> Alerts { get; set; } = new List<Alert>();
public virtual ICollection<FraudSignal> Signals { get; set; } = new List<FraudSignal>();
 public virtual FraudDetectionType? DetectionType { get; set; } 

    public static FraudScenario FromRequest(FraudScenarioRequest request) {
        return new FraudScenario {
            Id = request.Id,
            Name = request.Name,
            RiskAppetite = request.RiskAppetite,
            DetectionType = request.DetectionType,
        };
    }
}

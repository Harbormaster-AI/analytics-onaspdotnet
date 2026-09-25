
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class RecommendationScenario
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? RecommendationscenarioId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual string? Objective { get; set; } 
public virtual ICollection<Model_> Models { get; set; } = new List<Model_>();
public virtual ICollection<DataSet> Datasets { get; set; } = new List<DataSet>();
public virtual ICollection<Experiment> Experiments { get; set; } = new List<Experiment>();
public virtual ICollection<Alert> Alerts { get; set; } = new List<Alert>();
 public virtual RecommendationType? RecommendationType { get; set; } 

    public static RecommendationScenario FromRequest(RecommendationScenarioRequest request) {
        return new RecommendationScenario {
            Id = request.Id,
            Name = request.Name,
            Objective = request.Objective,
            RecommendationType = request.RecommendationType,
        };
    }
}

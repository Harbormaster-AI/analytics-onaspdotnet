using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class Experiment
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? ExperimentId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual string? Objective { get; set; } 
public virtual AnalyticsWorkspace? Workspace { get; set; } 
public virtual ICollection<TrainingRun> TrainingRuns { get; set; } = new List<TrainingRun>();
public virtual ICollection<Model> Models { get; set; } = new List<Model>();
public virtual ICollection<Notebook> Notebooks { get; set; } = new List<Notebook>();
 public virtual ExperimentStatus? Status { get; set; } 

    public static Experiment FromRequest(ExperimentRequest request) {
        return new Experiment {
            Id = request.Id,
            Name = request.Name,
            Objective = request.Objective,
            Status = request.Status,
        };
    }
}

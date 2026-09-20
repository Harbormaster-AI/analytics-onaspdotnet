using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class RunParameter
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? RunparameterId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual string? Value { get; set; } 
public virtual TrainingRun? TrainingRun { get; set; } 

    public static RunParameter FromRequest(RunParameterRequest request) {
        return new RunParameter {
            Id = request.Id,
            Name = request.Name,
            Value = request.Value,
        };
    }
}

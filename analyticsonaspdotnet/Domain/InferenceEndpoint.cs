using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class InferenceEndpoint
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? InferenceendpointId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual string? EndpointUrl { get; set; } 
 public virtual Percentage? TrafficShare { get; set; } 
public virtual ModelVersion? ModelVersion { get; set; } 
public virtual AnalyticsWorkspace? Workspace { get; set; } 
public virtual ICollection<Prediction> Predictions { get; set; } = new List<Prediction>();
 public virtual InferenceMode? Mode { get; set; } 

    public static InferenceEndpoint FromRequest(InferenceEndpointRequest request) {
        return new InferenceEndpoint {
            Id = request.Id,
            Name = request.Name,
            EndpointUrl = request.EndpointUrl,
            TrafficShare = request.TrafficShare,
            Mode = request.Mode,
        };
    }
}

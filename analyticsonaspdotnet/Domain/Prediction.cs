
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class Prediction
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? PredictionId { get; set; } 
 public virtual string? ReferenceKey { get; set; } 
 public virtual DateOnly? PredictedAt { get; set; } 
 public virtual decimal? Score { get; set; } 
public virtual InferenceEndpoint? Endpoint { get; set; } 
public virtual ModelVersion? ModelVersion { get; set; } 
public virtual DataSet? Dataset { get; set; } 

    public static Prediction FromRequest(PredictionRequest request) {
        return new Prediction {
            Id = request.Id,
            ReferenceKey = request.ReferenceKey,
            PredictedAt = request.PredictedAt,
            Score = request.Score,
        };
    }
}

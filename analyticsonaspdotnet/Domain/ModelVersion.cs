
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class ModelVersion
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? ModelversionId { get; set; } 
 public virtual string? Version { get; set; } 
public virtual Model_? Model_ { get; set; } 
public virtual TrainingRun? TrainingRun { get; set; } 
public virtual ICollection<EvaluationMetric> EvaluationMetrics { get; set; } = new List<EvaluationMetric>();
public virtual ICollection<InferenceEndpoint> Deployments { get; set; } = new List<InferenceEndpoint>();
public virtual ICollection<FeatureSet> FeatureSets { get; set; } = new List<FeatureSet>();
public virtual ICollection<DataSet> Datasets { get; set; } = new List<DataSet>();
 public virtual ModelLifecycle? Lifecycle { get; set; } 
 public virtual TrainingStatus? TrainingStatus { get; set; } 

    public static ModelVersion FromRequest(ModelVersionRequest request) {
        return new ModelVersion {
            Id = request.Id,
            Version = request.Version,
            Lifecycle = request.Lifecycle,
            TrainingStatus = request.TrainingStatus,
        };
    }
}

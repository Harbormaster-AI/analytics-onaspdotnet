using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class AccessPolicy
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? AccesspolicyId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual string? SubjectName { get; set; } 
public virtual AnalyticsWorkspace? Workspace { get; set; } 
public virtual ICollection<DataSet> Datasets { get; set; } = new List<DataSet>();
public virtual ICollection<Dashboard> Dashboards { get; set; } = new List<Dashboard>();
public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
public virtual ICollection<Model_> Models { get; set; } = new List<Model_>();
public virtual ICollection<FeatureSet> FeatureSets { get; set; } = new List<FeatureSet>();
 public virtual AccessLevel? AccessLevel { get; set; } 
 public virtual SubjectType? SubjectType { get; set; } 

    public static AccessPolicy FromRequest(AccessPolicyRequest request) {
        return new AccessPolicy {
            Id = request.Id,
            Name = request.Name,
            SubjectName = request.SubjectName,
            AccessLevel = request.AccessLevel,
            SubjectType = request.SubjectType,
        };
    }
}


using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class AnalyticsWorkspace
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? AnalyticsworkspaceId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual string? BusinessDomain { get; set; } 
 public virtual string? OwnerTeam { get; set; } 
public virtual ICollection<DataSet> Datasets { get; set; } = new List<DataSet>();
public virtual ICollection<DataSource> DataSources { get; set; } = new List<DataSource>();
public virtual ICollection<DataPipeline> Pipelines { get; set; } = new List<DataPipeline>();
public virtual ICollection<Dashboard> Dashboards { get; set; } = new List<Dashboard>();
public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
public virtual ICollection<Notebook> Notebooks { get; set; } = new List<Notebook>();
public virtual ICollection<Model_> Models { get; set; } = new List<Model_>();
public virtual ICollection<FeatureSet> FeatureSets { get; set; } = new List<FeatureSet>();
public virtual ICollection<AccessPolicy> Policies { get; set; } = new List<AccessPolicy>();
public virtual ICollection<LineageNode> LineageNodes { get; set; } = new List<LineageNode>();
 public virtual GovernanceTier? GovernanceTier { get; set; } 

    public static AnalyticsWorkspace FromRequest(AnalyticsWorkspaceRequest request) {
        return new AnalyticsWorkspace {
            Id = request.Id,
            Name = request.Name,
            BusinessDomain = request.BusinessDomain,
            OwnerTeam = request.OwnerTeam,
            GovernanceTier = request.GovernanceTier,
        };
    }
}

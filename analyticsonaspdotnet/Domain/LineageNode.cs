
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class LineageNode
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? LineagenodeId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual string? QualifiedName { get; set; } 
public virtual AnalyticsWorkspace? Workspace { get; set; } 
public virtual ICollection<LineageNode> Inputs { get; set; } = new List<LineageNode>();
public virtual ICollection<LineageNode> Outputs { get; set; } = new List<LineageNode>();
public virtual ICollection<DataSet> Datasets { get; set; } = new List<DataSet>();
public virtual ICollection<Model_> Models { get; set; } = new List<Model_>();
public virtual ICollection<DataPipeline> Pipelines { get; set; } = new List<DataPipeline>();
public virtual ICollection<Dashboard> Dashboards { get; set; } = new List<Dashboard>();
public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
 public virtual LineageNodeType? NodeType { get; set; } 

    public static LineageNode FromRequest(LineageNodeRequest request) {
        return new LineageNode {
            Id = request.Id,
            Name = request.Name,
            QualifiedName = request.QualifiedName,
            NodeType = request.NodeType,
        };
    }
}

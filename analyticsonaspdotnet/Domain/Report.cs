
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class Report
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? ReportId { get; set; } 
 public virtual string? Title { get; set; } 
 public virtual string? Audience { get; set; } 
public virtual AnalyticsWorkspace? Workspace { get; set; } 
public virtual ICollection<Visualization> Visualizations { get; set; } = new List<Visualization>();
public virtual ICollection<DataSet> Datasets { get; set; } = new List<DataSet>();
public virtual ICollection<SemanticModel> SemanticModels { get; set; } = new List<SemanticModel>();
public virtual ICollection<BIQuery> Queries { get; set; } = new List<BIQuery>();
public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
 public virtual ReportStatus? Status { get; set; } 

    public static Report FromRequest(ReportRequest request) {
        return new Report {
            Id = request.Id,
            Title = request.Title,
            Audience = request.Audience,
            Status = request.Status,
        };
    }
}

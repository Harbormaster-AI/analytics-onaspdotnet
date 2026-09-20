using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class Dashboard
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? DashboardId { get; set; } 
 public virtual string? Title { get; set; } 
 public virtual string? Theme { get; set; } 
public virtual AnalyticsWorkspace? Workspace { get; set; } 
public virtual ICollection<Visualization> Visualizations { get; set; } = new List<Visualization>();
public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
public virtual ICollection<DataSet> Datasets { get; set; } = new List<DataSet>();
public virtual ICollection<Alert> Alerts { get; set; } = new List<Alert>();
public virtual ICollection<BIQuery> Queries { get; set; } = new List<BIQuery>();
public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
 public virtual DashboardStatus? Status { get; set; } 

    public static Dashboard FromRequest(DashboardRequest request) {
        return new Dashboard {
            Id = request.Id,
            Title = request.Title,
            Theme = request.Theme,
            Status = request.Status,
        };
    }
}

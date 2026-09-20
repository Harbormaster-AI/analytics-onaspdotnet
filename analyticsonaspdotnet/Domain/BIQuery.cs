using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class BIQuery
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? BiqueryId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual string? Text { get; set; } 
public virtual AnalyticsWorkspace? Workspace { get; set; } 
public virtual ICollection<DataSet> Datasets { get; set; } = new List<DataSet>();
public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
public virtual ICollection<Dashboard> Dashboards { get; set; } = new List<Dashboard>();
public virtual ICollection<Notebook> Notebooks { get; set; } = new List<Notebook>();
 public virtual SQLDialect? Dialect { get; set; } 

    public static BIQuery FromRequest(BIQueryRequest request) {
        return new BIQuery {
            Id = request.Id,
            Name = request.Name,
            Text = request.Text,
            Dialect = request.Dialect,
        };
    }
}

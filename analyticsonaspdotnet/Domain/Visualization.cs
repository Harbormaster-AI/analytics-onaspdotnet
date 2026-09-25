
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class Visualization
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? VisualizationId { get; set; } 
 public virtual string? Title { get; set; } 
 public virtual ChartOptions? Options { get; set; } 
public virtual Dashboard? Dashboard { get; set; } 
public virtual Report? Report { get; set; } 
public virtual ICollection<Metric> Metrics { get; set; } = new List<Metric>();
public virtual ICollection<Dimension> Dimensions { get; set; } = new List<Dimension>();
public virtual ICollection<DataSet> Datasets { get; set; } = new List<DataSet>();
 public virtual ChartType? ChartType { get; set; } 

    public static Visualization FromRequest(VisualizationRequest request) {
        return new Visualization {
            Id = request.Id,
            Title = request.Title,
            Options = request.Options,
            ChartType = request.ChartType,
        };
    }
}

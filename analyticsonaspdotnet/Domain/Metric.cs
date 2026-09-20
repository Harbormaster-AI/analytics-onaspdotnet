using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class Metric
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? MetricId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual string? Expression { get; set; } 
 public virtual string? Unit { get; set; } 
public virtual SemanticModel? SemanticModel { get; set; } 
public virtual ICollection<DataSet> Datasets { get; set; } = new List<DataSet>();
public virtual ICollection<BusinessGlossaryTerm> GlossaryTerms { get; set; } = new List<BusinessGlossaryTerm>();
public virtual ICollection<Alert> Alerts { get; set; } = new List<Alert>();
public virtual ICollection<Visualization> Visualizations { get; set; } = new List<Visualization>();
 public virtual MetricType? MetricType { get; set; } 

    public static Metric FromRequest(MetricRequest request) {
        return new Metric {
            Id = request.Id,
            Name = request.Name,
            Expression = request.Expression,
            Unit = request.Unit,
            MetricType = request.MetricType,
        };
    }
}

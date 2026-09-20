using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class SemanticModel
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? SemanticmodelId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual string? Version { get; set; } 
 public virtual string? Grain { get; set; } 
public virtual ICollection<DataSet> Datasets { get; set; } = new List<DataSet>();
public virtual ICollection<Metric> Metrics { get; set; } = new List<Metric>();
public virtual ICollection<Dimension> Dimensions { get; set; } = new List<Dimension>();
public virtual ICollection<Measure> Measures { get; set; } = new List<Measure>();
public virtual ICollection<BusinessGlossaryTerm> GlossaryTerms { get; set; } = new List<BusinessGlossaryTerm>();

    public static SemanticModel FromRequest(SemanticModelRequest request) {
        return new SemanticModel {
            Id = request.Id,
            Name = request.Name,
            Version = request.Version,
            Grain = request.Grain,
        };
    }
}


using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class Measure
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? MeasureId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual string? Format { get; set; } 
public virtual SemanticModel? SemanticModel { get; set; } 
public virtual ICollection<DataSet> Datasets { get; set; } = new List<DataSet>();
public virtual ICollection<BusinessGlossaryTerm> GlossaryTerms { get; set; } = new List<BusinessGlossaryTerm>();
 public virtual AggregationType? Aggregation { get; set; } 

    public static Measure FromRequest(MeasureRequest request) {
        return new Measure {
            Id = request.Id,
            Name = request.Name,
            Format = request.Format,
            Aggregation = request.Aggregation,
        };
    }
}

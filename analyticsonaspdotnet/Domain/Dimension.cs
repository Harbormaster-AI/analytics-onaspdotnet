using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class Dimension
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? DimensionId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual bool? TypeTime { get; set; } 
public virtual SemanticModel? SemanticModel { get; set; } 
public virtual ICollection<DataSet> Datasets { get; set; } = new List<DataSet>();
public virtual ICollection<BusinessGlossaryTerm> GlossaryTerms { get; set; } = new List<BusinessGlossaryTerm>();
 public virtual DimensionType? DimensionType { get; set; } 

    public static Dimension FromRequest(DimensionRequest request) {
        return new Dimension {
            Id = request.Id,
            Name = request.Name,
            TypeTime = request.TypeTime,
            DimensionType = request.DimensionType,
        };
    }
}

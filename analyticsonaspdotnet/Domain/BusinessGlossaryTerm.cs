using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class BusinessGlossaryTerm
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? BusinessglossarytermId { get; set; } 
 public virtual string? Term { get; set; } 
 public virtual string? Definition { get; set; } 
 public virtual string? Steward { get; set; } 
public virtual ICollection<BusinessGlossaryTerm> RelatedTerms { get; set; } = new List<BusinessGlossaryTerm>();
public virtual ICollection<Metric> Metrics { get; set; } = new List<Metric>();
public virtual ICollection<DataSet> Datasets { get; set; } = new List<DataSet>();
public virtual ICollection<Dimension> Dimensions { get; set; } = new List<Dimension>();
public virtual ICollection<Measure> Measures { get; set; } = new List<Measure>();

    public static BusinessGlossaryTerm FromRequest(BusinessGlossaryTermRequest request) {
        return new BusinessGlossaryTerm {
            Id = request.Id,
            Term = request.Term,
            Definition = request.Definition,
            Steward = request.Steward,
        };
    }
}

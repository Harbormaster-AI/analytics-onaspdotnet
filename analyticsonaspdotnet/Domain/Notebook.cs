
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class Notebook
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? NotebookId { get; set; } 
 public virtual string? Title { get; set; } 
 public virtual RepositoryRef? Repository { get; set; } 
public virtual AnalyticsWorkspace? Workspace { get; set; } 
public virtual ICollection<DataSet> Datasets { get; set; } = new List<DataSet>();
public virtual ICollection<Experiment> Experiments { get; set; } = new List<Experiment>();
public virtual ICollection<BIQuery> Queries { get; set; } = new List<BIQuery>();
 public virtual NotebookLanguage? Language { get; set; } 

    public static Notebook FromRequest(NotebookRequest request) {
        return new Notebook {
            Id = request.Id,
            Title = request.Title,
            Repository = request.Repository,
            Language = request.Language,
        };
    }
}

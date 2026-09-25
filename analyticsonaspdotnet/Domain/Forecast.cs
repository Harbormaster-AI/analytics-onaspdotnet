
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class Forecast
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? ForecastId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual int? Horizon { get; set; } 
public virtual ModelVersion? ModelVersion { get; set; } 
public virtual TimeSeries? TimeSeries { get; set; } 
public virtual ICollection<DataSet> Datasets { get; set; } = new List<DataSet>();
 public virtual TimeGranularity? Granularity { get; set; } 

    public static Forecast FromRequest(ForecastRequest request) {
        return new Forecast {
            Id = request.Id,
            Name = request.Name,
            Horizon = request.Horizon,
            Granularity = request.Granularity,
        };
    }
}

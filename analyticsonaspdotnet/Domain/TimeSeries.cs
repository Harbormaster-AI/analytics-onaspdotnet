
using analyticsonaspdotnet.Contracts;

namespace analyticsonaspdotnet.Domain;

public class TimeSeries
{
    public Guid Id { get; set; } = Guid.NewGuid();

 public virtual long? TimeseriesId { get; set; } 
 public virtual string? Name { get; set; } 
 public virtual string? Timezone { get; set; } 
public virtual ICollection<DataSet> Datasets { get; set; } = new List<DataSet>();
public virtual ICollection<Forecast> Forecasts { get; set; } = new List<Forecast>();
public virtual ICollection<Anomaly> Anomalies { get; set; } = new List<Anomaly>();
 public virtual TimeGranularity? Granularity { get; set; } 

    public static TimeSeries FromRequest(TimeSeriesRequest request) {
        return new TimeSeries {
            Id = request.Id,
            Name = request.Name,
            Timezone = request.Timezone,
            Granularity = request.Granularity,
        };
    }
}

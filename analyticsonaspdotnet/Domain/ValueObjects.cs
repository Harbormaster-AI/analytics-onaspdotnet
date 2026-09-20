using System.ComponentModel.DataAnnotations.Schema;

namespace analyticsonaspdotnet.Domain;

    [ComplexType]
    public record ConnectionInfo(
    string Host,
    int Port,
    string Database,
    string Username
    );

    [ComplexType]
    public record CronSchedule(
    string Expression,
    string Timezone
    );

    [ComplexType]
    public record Threshold(
    decimal Limit,
    bool Inclusive
    );

    [ComplexType]
    public record ChartOptions(
    bool Stacked,
    string LegendPosition
    );

    [ComplexType]
    public record RepositoryRef(
    string Url,
    string Branch,
    string Path
    );

    [ComplexType]
    public record Percentage(
    decimal Value
    );


using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Contracts;

public class IdentifierRequest
{
    public Guid Id { get; set; }
}

public class AssociationRequest
{
    public Guid ParentId { get; set; }
    public Guid ChildId { get; set; }
}

public class MultipleAssociationRequest
{
    public Guid ParentId { get; set; }
    public List<Guid> ChildIds { get; set; } = new();
}

public class AnalyticsWorkspaceRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual string? BusinessDomain { get; set; } 
 public virtual string? OwnerTeam { get; set; } 
 public virtual GovernanceTier? GovernanceTier { get; set; } 
}

public class AnalyticsWorkspaceResponse : AnalyticsWorkspaceRequest {
    public static AnalyticsWorkspaceResponse FromModel(AnalyticsWorkspace model) {
        return new AnalyticsWorkspaceResponse {
            Id = model.Id,
            Name = model.Name,
            BusinessDomain = model.BusinessDomain,
            OwnerTeam = model.OwnerTeam,
            GovernanceTier = model.GovernanceTier,
        };
    }
}

public class DataSourceRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual ConnectionInfo? Connection { get; set; } 
 public virtual bool? Streaming { get; set; } 
 public virtual DataSourceType? SourceType { get; set; } 
 public virtual DataFormat? Format { get; set; } 
}

public class DataSourceResponse : DataSourceRequest {
    public static DataSourceResponse FromModel(DataSource model) {
        return new DataSourceResponse {
            Id = model.Id,
            Name = model.Name,
            Connection = model.Connection,
            Streaming = model.Streaming,
            SourceType = model.SourceType,
            Format = model.Format,
        };
    }
}

public class DataSetRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual string? SchemaVersion { get; set; } 
 public virtual CronSchedule? RefreshSchedule { get; set; } 
 public virtual bool? Sensitive { get; set; } 
 public virtual DataFormat? DataFormat { get; set; } 
}

public class DataSetResponse : DataSetRequest {
    public static DataSetResponse FromModel(DataSet model) {
        return new DataSetResponse {
            Id = model.Id,
            Name = model.Name,
            SchemaVersion = model.SchemaVersion,
            RefreshSchedule = model.RefreshSchedule,
            Sensitive = model.Sensitive,
            DataFormat = model.DataFormat,
        };
    }
}

public class DataPipelineRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual CronSchedule? Schedule { get; set; } 
 public virtual PipelineTriggerType? TriggerType { get; set; } 
 public virtual PipelineStatus? Status { get; set; } 
}

public class DataPipelineResponse : DataPipelineRequest {
    public static DataPipelineResponse FromModel(DataPipeline model) {
        return new DataPipelineResponse {
            Id = model.Id,
            Name = model.Name,
            Schedule = model.Schedule,
            TriggerType = model.TriggerType,
            Status = model.Status,
        };
    }
}

public class DataTaskRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual string? Command { get; set; } 
 public virtual int? Retries { get; set; } 
 public virtual DataTaskType? TaskType { get; set; } 
}

public class DataTaskResponse : DataTaskRequest {
    public static DataTaskResponse FromModel(DataTask model) {
        return new DataTaskResponse {
            Id = model.Id,
            Name = model.Name,
            Command = model.Command,
            Retries = model.Retries,
            TaskType = model.TaskType,
        };
    }
}

public class SemanticModelRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual string? Version { get; set; } 
 public virtual string? Grain { get; set; } 
}

public class SemanticModelResponse : SemanticModelRequest {
    public static SemanticModelResponse FromModel(SemanticModel model) {
        return new SemanticModelResponse {
            Id = model.Id,
            Name = model.Name,
            Version = model.Version,
            Grain = model.Grain,
        };
    }
}

public class DimensionRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual bool? TypeTime { get; set; } 
 public virtual DimensionType? DimensionType { get; set; } 
}

public class DimensionResponse : DimensionRequest {
    public static DimensionResponse FromModel(Dimension model) {
        return new DimensionResponse {
            Id = model.Id,
            Name = model.Name,
            TypeTime = model.TypeTime,
            DimensionType = model.DimensionType,
        };
    }
}

public class MeasureRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual string? Format { get; set; } 
 public virtual AggregationType? Aggregation { get; set; } 
}

public class MeasureResponse : MeasureRequest {
    public static MeasureResponse FromModel(Measure model) {
        return new MeasureResponse {
            Id = model.Id,
            Name = model.Name,
            Format = model.Format,
            Aggregation = model.Aggregation,
        };
    }
}

public class MetricRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual string? Expression { get; set; } 
 public virtual string? Unit { get; set; } 
 public virtual MetricType? MetricType { get; set; } 
}

public class MetricResponse : MetricRequest {
    public static MetricResponse FromModel(Metric model) {
        return new MetricResponse {
            Id = model.Id,
            Name = model.Name,
            Expression = model.Expression,
            Unit = model.Unit,
            MetricType = model.MetricType,
        };
    }
}

public class ReportRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Title { get; set; } 
 public virtual string? Audience { get; set; } 
 public virtual ReportStatus? Status { get; set; } 
}

public class ReportResponse : ReportRequest {
    public static ReportResponse FromModel(Report model) {
        return new ReportResponse {
            Id = model.Id,
            Title = model.Title,
            Audience = model.Audience,
            Status = model.Status,
        };
    }
}

public class DashboardRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Title { get; set; } 
 public virtual string? Theme { get; set; } 
 public virtual DashboardStatus? Status { get; set; } 
}

public class DashboardResponse : DashboardRequest {
    public static DashboardResponse FromModel(Dashboard model) {
        return new DashboardResponse {
            Id = model.Id,
            Title = model.Title,
            Theme = model.Theme,
            Status = model.Status,
        };
    }
}

public class VisualizationRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Title { get; set; } 
 public virtual ChartOptions? Options { get; set; } 
 public virtual ChartType? ChartType { get; set; } 
}

public class VisualizationResponse : VisualizationRequest {
    public static VisualizationResponse FromModel(Visualization model) {
        return new VisualizationResponse {
            Id = model.Id,
            Title = model.Title,
            Options = model.Options,
            ChartType = model.ChartType,
        };
    }
}

public class NotebookRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Title { get; set; } 
 public virtual RepositoryRef? Repository { get; set; } 
 public virtual NotebookLanguage? Language { get; set; } 
}

public class NotebookResponse : NotebookRequest {
    public static NotebookResponse FromModel(Notebook model) {
        return new NotebookResponse {
            Id = model.Id,
            Title = model.Title,
            Repository = model.Repository,
            Language = model.Language,
        };
    }
}

public class BIQueryRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual string? Text { get; set; } 
 public virtual SQLDialect? Dialect { get; set; } 
}

public class BIQueryResponse : BIQueryRequest {
    public static BIQueryResponse FromModel(BIQuery model) {
        return new BIQueryResponse {
            Id = model.Id,
            Name = model.Name,
            Text = model.Text,
            Dialect = model.Dialect,
        };
    }
}

public class ExperimentRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual string? Objective { get; set; } 
 public virtual ExperimentStatus? Status { get; set; } 
}

public class ExperimentResponse : ExperimentRequest {
    public static ExperimentResponse FromModel(Experiment model) {
        return new ExperimentResponse {
            Id = model.Id,
            Name = model.Name,
            Objective = model.Objective,
            Status = model.Status,
        };
    }
}

public class TrainingRunRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? RunLabel { get; set; } 
 public virtual DateOnly? StartedAt { get; set; } 
 public virtual DateOnly? CompletedAt { get; set; } 
 public virtual TrainingStatus? Status { get; set; } 
}

public class TrainingRunResponse : TrainingRunRequest {
    public static TrainingRunResponse FromModel(TrainingRun model) {
        return new TrainingRunResponse {
            Id = model.Id,
            RunLabel = model.RunLabel,
            StartedAt = model.StartedAt,
            CompletedAt = model.CompletedAt,
            Status = model.Status,
        };
    }
}

public class RunMetricRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual decimal? Value { get; set; } 
}

public class RunMetricResponse : RunMetricRequest {
    public static RunMetricResponse FromModel(RunMetric model) {
        return new RunMetricResponse {
            Id = model.Id,
            Name = model.Name,
            Value = model.Value,
        };
    }
}

public class RunParameterRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual string? Value { get; set; } 
}

public class RunParameterResponse : RunParameterRequest {
    public static RunParameterResponse FromModel(RunParameter model) {
        return new RunParameterResponse {
            Id = model.Id,
            Name = model.Name,
            Value = model.Value,
        };
    }
}

public class ModelRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual string? TaskDescription { get; set; } 
 public virtual ModelType? ModelType { get; set; } 
}

public class ModelResponse : ModelRequest {
    public static ModelResponse FromModel(Model model) {
        return new ModelResponse {
            Id = model.Id,
            Name = model.Name,
            TaskDescription = model.TaskDescription,
            ModelType = model.ModelType,
        };
    }
}

public class ModelVersionRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Version { get; set; } 
 public virtual ModelLifecycle? Lifecycle { get; set; } 
 public virtual TrainingStatus? TrainingStatus { get; set; } 
}

public class ModelVersionResponse : ModelVersionRequest {
    public static ModelVersionResponse FromModel(ModelVersion model) {
        return new ModelVersionResponse {
            Id = model.Id,
            Version = model.Version,
            Lifecycle = model.Lifecycle,
            TrainingStatus = model.TrainingStatus,
        };
    }
}

public class EvaluationMetricRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual decimal? Value { get; set; } 
}

public class EvaluationMetricResponse : EvaluationMetricRequest {
    public static EvaluationMetricResponse FromModel(EvaluationMetric model) {
        return new EvaluationMetricResponse {
            Id = model.Id,
            Name = model.Name,
            Value = model.Value,
        };
    }
}

public class FeatureSetRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual CronSchedule? RefreshSchedule { get; set; } 
 public virtual FeatureStoreType? StoreType { get; set; } 
}

public class FeatureSetResponse : FeatureSetRequest {
    public static FeatureSetResponse FromModel(FeatureSet model) {
        return new FeatureSetResponse {
            Id = model.Id,
            Name = model.Name,
            RefreshSchedule = model.RefreshSchedule,
            StoreType = model.StoreType,
        };
    }
}

public class FeatureRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual string? Description { get; set; } 
 public virtual DataType? DataType { get; set; } 
}

public class FeatureResponse : FeatureRequest {
    public static FeatureResponse FromModel(Feature model) {
        return new FeatureResponse {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            DataType = model.DataType,
        };
    }
}

public class InferenceEndpointRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual string? EndpointUrl { get; set; } 
 public virtual Percentage? TrafficShare { get; set; } 
 public virtual InferenceMode? Mode { get; set; } 
}

public class InferenceEndpointResponse : InferenceEndpointRequest {
    public static InferenceEndpointResponse FromModel(InferenceEndpoint model) {
        return new InferenceEndpointResponse {
            Id = model.Id,
            Name = model.Name,
            EndpointUrl = model.EndpointUrl,
            TrafficShare = model.TrafficShare,
            Mode = model.Mode,
        };
    }
}

public class PredictionRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? ReferenceKey { get; set; } 
 public virtual DateOnly? PredictedAt { get; set; } 
 public virtual decimal? Score { get; set; } 
}

public class PredictionResponse : PredictionRequest {
    public static PredictionResponse FromModel(Prediction model) {
        return new PredictionResponse {
            Id = model.Id,
            ReferenceKey = model.ReferenceKey,
            PredictedAt = model.PredictedAt,
            Score = model.Score,
        };
    }
}

public class ForecastRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual int? Horizon { get; set; } 
 public virtual TimeGranularity? Granularity { get; set; } 
}

public class ForecastResponse : ForecastRequest {
    public static ForecastResponse FromModel(Forecast model) {
        return new ForecastResponse {
            Id = model.Id,
            Name = model.Name,
            Horizon = model.Horizon,
            Granularity = model.Granularity,
        };
    }
}

public class TimeSeriesRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual string? Timezone { get; set; } 
 public virtual TimeGranularity? Granularity { get; set; } 
}

public class TimeSeriesResponse : TimeSeriesRequest {
    public static TimeSeriesResponse FromModel(TimeSeries model) {
        return new TimeSeriesResponse {
            Id = model.Id,
            Name = model.Name,
            Timezone = model.Timezone,
            Granularity = model.Granularity,
        };
    }
}

public class AnomalyRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual DateOnly? OccurredAt { get; set; } 
 public virtual string? Details { get; set; } 
 public virtual AnomalyType? AnomalyType { get; set; } 
 public virtual AlertSeverity? Severity { get; set; } 
}

public class AnomalyResponse : AnomalyRequest {
    public static AnomalyResponse FromModel(Anomaly model) {
        return new AnomalyResponse {
            Id = model.Id,
            OccurredAt = model.OccurredAt,
            Details = model.Details,
            AnomalyType = model.AnomalyType,
            Severity = model.Severity,
        };
    }
}

public class QualityRuleRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual Threshold? Threshold { get; set; } 
 public virtual string? TargetField { get; set; } 
 public virtual QualityDimension? Dimension { get; set; } 
 public virtual ComparisonOperator? Operator { get; set; } 
}

public class QualityRuleResponse : QualityRuleRequest {
    public static QualityRuleResponse FromModel(QualityRule model) {
        return new QualityRuleResponse {
            Id = model.Id,
            Name = model.Name,
            Threshold = model.Threshold,
            TargetField = model.TargetField,
            Dimension = model.Dimension,
            Operator = model.Operator,
        };
    }
}

public class QualityCheckRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual DateOnly? CheckedAt { get; set; } 
 public virtual decimal? ObservedValue { get; set; } 
 public virtual int? SampleSize { get; set; } 
 public virtual QualityStatus? Status { get; set; } 
}

public class QualityCheckResponse : QualityCheckRequest {
    public static QualityCheckResponse FromModel(QualityCheck model) {
        return new QualityCheckResponse {
            Id = model.Id,
            CheckedAt = model.CheckedAt,
            ObservedValue = model.ObservedValue,
            SampleSize = model.SampleSize,
            Status = model.Status,
        };
    }
}

public class LineageNodeRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual string? QualifiedName { get; set; } 
 public virtual LineageNodeType? NodeType { get; set; } 
}

public class LineageNodeResponse : LineageNodeRequest {
    public static LineageNodeResponse FromModel(LineageNode model) {
        return new LineageNodeResponse {
            Id = model.Id,
            Name = model.Name,
            QualifiedName = model.QualifiedName,
            NodeType = model.NodeType,
        };
    }
}

public class TagRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual TagCategory? Category { get; set; } 
}

public class TagResponse : TagRequest {
    public static TagResponse FromModel(Tag model) {
        return new TagResponse {
            Id = model.Id,
            Name = model.Name,
            Category = model.Category,
        };
    }
}

public class AccessPolicyRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual string? SubjectName { get; set; } 
 public virtual AccessLevel? AccessLevel { get; set; } 
 public virtual SubjectType? SubjectType { get; set; } 
}

public class AccessPolicyResponse : AccessPolicyRequest {
    public static AccessPolicyResponse FromModel(AccessPolicy model) {
        return new AccessPolicyResponse {
            Id = model.Id,
            Name = model.Name,
            SubjectName = model.SubjectName,
            AccessLevel = model.AccessLevel,
            SubjectType = model.SubjectType,
        };
    }
}

public class AlertRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Title { get; set; } 
 public virtual DateOnly? CreatedAt { get; set; } 
 public virtual AlertSeverity? Severity { get; set; } 
 public virtual AlertStatus? Status { get; set; } 
}

public class AlertResponse : AlertRequest {
    public static AlertResponse FromModel(Alert model) {
        return new AlertResponse {
            Id = model.Id,
            Title = model.Title,
            CreatedAt = model.CreatedAt,
            Severity = model.Severity,
            Status = model.Status,
        };
    }
}

public class SubscriberRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual string? Address { get; set; } 
 public virtual NotificationChannel? Channel { get; set; } 
}

public class SubscriberResponse : SubscriberRequest {
    public static SubscriberResponse FromModel(Subscriber model) {
        return new SubscriberResponse {
            Id = model.Id,
            Name = model.Name,
            Address = model.Address,
            Channel = model.Channel,
        };
    }
}

public class BusinessGlossaryTermRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Term { get; set; } 
 public virtual string? Definition { get; set; } 
 public virtual string? Steward { get; set; } 
}

public class BusinessGlossaryTermResponse : BusinessGlossaryTermRequest {
    public static BusinessGlossaryTermResponse FromModel(BusinessGlossaryTerm model) {
        return new BusinessGlossaryTermResponse {
            Id = model.Id,
            Term = model.Term,
            Definition = model.Definition,
            Steward = model.Steward,
        };
    }
}

public class RecommendationScenarioRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual string? Objective { get; set; } 
 public virtual RecommendationType? RecommendationType { get; set; } 
}

public class RecommendationScenarioResponse : RecommendationScenarioRequest {
    public static RecommendationScenarioResponse FromModel(RecommendationScenario model) {
        return new RecommendationScenarioResponse {
            Id = model.Id,
            Name = model.Name,
            Objective = model.Objective,
            RecommendationType = model.RecommendationType,
        };
    }
}

public class FraudScenarioRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual string? RiskAppetite { get; set; } 
 public virtual FraudDetectionType? DetectionType { get; set; } 
}

public class FraudScenarioResponse : FraudScenarioRequest {
    public static FraudScenarioResponse FromModel(FraudScenario model) {
        return new FraudScenarioResponse {
            Id = model.Id,
            Name = model.Name,
            RiskAppetite = model.RiskAppetite,
            DetectionType = model.DetectionType,
        };
    }
}

public class FraudSignalRequest {
    public Guid Id { get; set; } = Guid.NewGuid();
 public virtual string? Name { get; set; } 
 public virtual string? RuleLogic { get; set; } 
 public virtual FraudSignalType? SignalType { get; set; } 
}

public class FraudSignalResponse : FraudSignalRequest {
    public static FraudSignalResponse FromModel(FraudSignal model) {
        return new FraudSignalResponse {
            Id = model.Id,
            Name = model.Name,
            RuleLogic = model.RuleLogic,
            SignalType = model.SignalType,
        };
    }
}


using Microsoft.EntityFrameworkCore;

using analyticsonaspdotnet.Domain;

namespace analyticsonaspdotnet.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

public DbSet<AnalyticsWorkspace> AnalyticsWorkspaces => Set<AnalyticsWorkspace>();
public DbSet<DataSource> DataSources => Set<DataSource>();
public DbSet<DataSet> DataSets => Set<DataSet>();
public DbSet<DataPipeline> DataPipelines => Set<DataPipeline>();
public DbSet<DataTask> DataTasks => Set<DataTask>();
public DbSet<SemanticModel> SemanticModels => Set<SemanticModel>();
public DbSet<Dimension> Dimensions => Set<Dimension>();
public DbSet<Measure> Measures => Set<Measure>();
public DbSet<Metric> Metrics => Set<Metric>();
public DbSet<Report> Reports => Set<Report>();
public DbSet<Dashboard> Dashboards => Set<Dashboard>();
public DbSet<Visualization> Visualizations => Set<Visualization>();
public DbSet<Notebook> Notebooks => Set<Notebook>();
public DbSet<BIQuery> BIQuerys => Set<BIQuery>();
public DbSet<Experiment> Experiments => Set<Experiment>();
public DbSet<TrainingRun> TrainingRuns => Set<TrainingRun>();
public DbSet<RunMetric> RunMetrics => Set<RunMetric>();
public DbSet<RunParameter> RunParameters => Set<RunParameter>();
public DbSet<Model> Models => Set<Model>();
public DbSet<ModelVersion> ModelVersions => Set<ModelVersion>();
public DbSet<EvaluationMetric> EvaluationMetrics => Set<EvaluationMetric>();
public DbSet<FeatureSet> FeatureSets => Set<FeatureSet>();
public DbSet<Feature> Features => Set<Feature>();
public DbSet<InferenceEndpoint> InferenceEndpoints => Set<InferenceEndpoint>();
public DbSet<Prediction> Predictions => Set<Prediction>();
public DbSet<Forecast> Forecasts => Set<Forecast>();
public DbSet<TimeSeries> TimeSeriess => Set<TimeSeries>();
public DbSet<Anomaly> Anomalys => Set<Anomaly>();
public DbSet<QualityRule> QualityRules => Set<QualityRule>();
public DbSet<QualityCheck> QualityChecks => Set<QualityCheck>();
public DbSet<LineageNode> LineageNodes => Set<LineageNode>();
public DbSet<Tag> Tags => Set<Tag>();
public DbSet<AccessPolicy> AccessPolicys => Set<AccessPolicy>();
public DbSet<Alert> Alerts => Set<Alert>();
public DbSet<Subscriber> Subscribers => Set<Subscriber>();
public DbSet<BusinessGlossaryTerm> BusinessGlossaryTerms => Set<BusinessGlossaryTerm>();
public DbSet<RecommendationScenario> RecommendationScenarios => Set<RecommendationScenario>();
public DbSet<FraudScenario> FraudScenarios => Set<FraudScenario>();
public DbSet<FraudSignal> FraudSignals => Set<FraudSignal>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        // AnalyticsWorkspace has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<AnalyticsWorkspace>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("DatasetsId");

        // AnalyticsWorkspace has one or more DataSources of type DataSource
        modelBuilder.Entity<DataSource>()
            .HasOne<AnalyticsWorkspace>()
            .WithMany(parent => parent.DataSources)
            .HasForeignKey("DataSourcesId");

        // AnalyticsWorkspace has one or more Pipelines of type DataPipeline
        modelBuilder.Entity<DataPipeline>()
            .HasOne<AnalyticsWorkspace>()
            .WithMany(parent => parent.Pipelines)
            .HasForeignKey("PipelinesId");

        // AnalyticsWorkspace has one or more Dashboards of type Dashboard
        modelBuilder.Entity<Dashboard>()
            .HasOne<AnalyticsWorkspace>()
            .WithMany(parent => parent.Dashboards)
            .HasForeignKey("DashboardsId");

        // AnalyticsWorkspace has one or more Reports of type Report
        modelBuilder.Entity<Report>()
            .HasOne<AnalyticsWorkspace>()
            .WithMany(parent => parent.Reports)
            .HasForeignKey("ReportsId");

        // AnalyticsWorkspace has one or more Notebooks of type Notebook
        modelBuilder.Entity<Notebook>()
            .HasOne<AnalyticsWorkspace>()
            .WithMany(parent => parent.Notebooks)
            .HasForeignKey("NotebooksId");

        // AnalyticsWorkspace has one or more Models of type Model
        modelBuilder.Entity<Model>()
            .HasOne<AnalyticsWorkspace>()
            .WithMany(parent => parent.Models)
            .HasForeignKey("ModelsId");

        // AnalyticsWorkspace has one or more FeatureSets of type FeatureSet
        modelBuilder.Entity<FeatureSet>()
            .HasOne<AnalyticsWorkspace>()
            .WithMany(parent => parent.FeatureSets)
            .HasForeignKey("FeatureSetsId");

        // AnalyticsWorkspace has one or more Policies of type AccessPolicy
        modelBuilder.Entity<AccessPolicy>()
            .HasOne<AnalyticsWorkspace>()
            .WithMany(parent => parent.Policies)
            .HasForeignKey("PoliciesId");

        // AnalyticsWorkspace has one or more LineageNodes of type LineageNode
        modelBuilder.Entity<LineageNode>()
            .HasOne<AnalyticsWorkspace>()
            .WithMany(parent => parent.LineageNodes)
            .HasForeignKey("LineageNodesId");

        // DataSource has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<DataSource>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("WorkspaceId");


        // DataSource has one or more ProducedDatasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<DataSource>()
            .WithMany(parent => parent.ProducedDatasets)
            .HasForeignKey("ProducedDatasetsId");

        // DataSource has one or more Pipelines of type DataPipeline
        modelBuilder.Entity<DataPipeline>()
            .HasOne<DataSource>()
            .WithMany(parent => parent.Pipelines)
            .HasForeignKey("PipelinesId");

        // DataSet has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<DataSet>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("WorkspaceId");

        // DataSet has one LineageNode of type LineageNode
        modelBuilder.Entity<DataSet>()
            .HasOne(x => x.LineageNode)
            .WithMany()
            .HasForeignKey("LineageNodeId");


        // DataSet has one or more Sources of type DataSource
        modelBuilder.Entity<DataSource>()
            .HasOne<DataSet>()
            .WithMany(parent => parent.Sources)
            .HasForeignKey("SourcesId");

        // DataSet has one or more Pipelines of type DataPipeline
        modelBuilder.Entity<DataPipeline>()
            .HasOne<DataSet>()
            .WithMany(parent => parent.Pipelines)
            .HasForeignKey("PipelinesId");

        // DataSet has one or more SemanticModels of type SemanticModel
        modelBuilder.Entity<SemanticModel>()
            .HasOne<DataSet>()
            .WithMany(parent => parent.SemanticModels)
            .HasForeignKey("SemanticModelsId");

        // DataSet has one or more Dimensions of type Dimension
        modelBuilder.Entity<Dimension>()
            .HasOne<DataSet>()
            .WithMany(parent => parent.Dimensions)
            .HasForeignKey("DimensionsId");

        // DataSet has one or more Measures of type Measure
        modelBuilder.Entity<Measure>()
            .HasOne<DataSet>()
            .WithMany(parent => parent.Measures)
            .HasForeignKey("MeasuresId");

        // DataSet has one or more Metrics of type Metric
        modelBuilder.Entity<Metric>()
            .HasOne<DataSet>()
            .WithMany(parent => parent.Metrics)
            .HasForeignKey("MetricsId");

        // DataSet has one or more QualityRules of type QualityRule
        modelBuilder.Entity<QualityRule>()
            .HasOne<DataSet>()
            .WithMany(parent => parent.QualityRules)
            .HasForeignKey("QualityRulesId");

        // DataSet has one or more Tags of type Tag
        modelBuilder.Entity<Tag>()
            .HasOne<DataSet>()
            .WithMany(parent => parent.Tags)
            .HasForeignKey("TagsId");

        // DataPipeline has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<DataPipeline>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("WorkspaceId");

        // DataPipeline has one LineageNode of type LineageNode
        modelBuilder.Entity<DataPipeline>()
            .HasOne(x => x.LineageNode)
            .WithMany()
            .HasForeignKey("LineageNodeId");


        // DataPipeline has one or more Tasks of type DataTask
        modelBuilder.Entity<DataTask>()
            .HasOne<DataPipeline>()
            .WithMany(parent => parent.Tasks)
            .HasForeignKey("TasksId");

        // DataPipeline has one or more Sources of type DataSource
        modelBuilder.Entity<DataSource>()
            .HasOne<DataPipeline>()
            .WithMany(parent => parent.Sources)
            .HasForeignKey("SourcesId");

        // DataPipeline has one or more Outputs of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<DataPipeline>()
            .WithMany(parent => parent.Outputs)
            .HasForeignKey("OutputsId");

        // DataTask has one Pipeline of type DataPipeline
        modelBuilder.Entity<DataTask>()
            .HasOne(x => x.Pipeline)
            .WithMany()
            .HasForeignKey("PipelineId");


        // DataTask has one or more InputDatasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<DataTask>()
            .WithMany(parent => parent.InputDatasets)
            .HasForeignKey("InputDatasetsId");

        // DataTask has one or more OutputDatasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<DataTask>()
            .WithMany(parent => parent.OutputDatasets)
            .HasForeignKey("OutputDatasetsId");


        // SemanticModel has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<SemanticModel>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("DatasetsId");

        // SemanticModel has one or more Metrics of type Metric
        modelBuilder.Entity<Metric>()
            .HasOne<SemanticModel>()
            .WithMany(parent => parent.Metrics)
            .HasForeignKey("MetricsId");

        // SemanticModel has one or more Dimensions of type Dimension
        modelBuilder.Entity<Dimension>()
            .HasOne<SemanticModel>()
            .WithMany(parent => parent.Dimensions)
            .HasForeignKey("DimensionsId");

        // SemanticModel has one or more Measures of type Measure
        modelBuilder.Entity<Measure>()
            .HasOne<SemanticModel>()
            .WithMany(parent => parent.Measures)
            .HasForeignKey("MeasuresId");

        // SemanticModel has one or more GlossaryTerms of type BusinessGlossaryTerm
        modelBuilder.Entity<BusinessGlossaryTerm>()
            .HasOne<SemanticModel>()
            .WithMany(parent => parent.GlossaryTerms)
            .HasForeignKey("GlossaryTermsId");

        // Dimension has one SemanticModel of type SemanticModel
        modelBuilder.Entity<Dimension>()
            .HasOne(x => x.SemanticModel)
            .WithMany()
            .HasForeignKey("SemanticModelId");


        // Dimension has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<Dimension>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("DatasetsId");

        // Dimension has one or more GlossaryTerms of type BusinessGlossaryTerm
        modelBuilder.Entity<BusinessGlossaryTerm>()
            .HasOne<Dimension>()
            .WithMany(parent => parent.GlossaryTerms)
            .HasForeignKey("GlossaryTermsId");

        // Measure has one SemanticModel of type SemanticModel
        modelBuilder.Entity<Measure>()
            .HasOne(x => x.SemanticModel)
            .WithMany()
            .HasForeignKey("SemanticModelId");


        // Measure has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<Measure>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("DatasetsId");

        // Measure has one or more GlossaryTerms of type BusinessGlossaryTerm
        modelBuilder.Entity<BusinessGlossaryTerm>()
            .HasOne<Measure>()
            .WithMany(parent => parent.GlossaryTerms)
            .HasForeignKey("GlossaryTermsId");

        // Metric has one SemanticModel of type SemanticModel
        modelBuilder.Entity<Metric>()
            .HasOne(x => x.SemanticModel)
            .WithMany()
            .HasForeignKey("SemanticModelId");


        // Metric has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<Metric>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("DatasetsId");

        // Metric has one or more GlossaryTerms of type BusinessGlossaryTerm
        modelBuilder.Entity<BusinessGlossaryTerm>()
            .HasOne<Metric>()
            .WithMany(parent => parent.GlossaryTerms)
            .HasForeignKey("GlossaryTermsId");

        // Metric has one or more Alerts of type Alert
        modelBuilder.Entity<Alert>()
            .HasOne<Metric>()
            .WithMany(parent => parent.Alerts)
            .HasForeignKey("AlertsId");

        // Metric has one or more Visualizations of type Visualization
        modelBuilder.Entity<Visualization>()
            .HasOne<Metric>()
            .WithMany(parent => parent.Visualizations)
            .HasForeignKey("VisualizationsId");

        // Report has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<Report>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("WorkspaceId");


        // Report has one or more Visualizations of type Visualization
        modelBuilder.Entity<Visualization>()
            .HasOne<Report>()
            .WithMany(parent => parent.Visualizations)
            .HasForeignKey("VisualizationsId");

        // Report has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<Report>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("DatasetsId");

        // Report has one or more SemanticModels of type SemanticModel
        modelBuilder.Entity<SemanticModel>()
            .HasOne<Report>()
            .WithMany(parent => parent.SemanticModels)
            .HasForeignKey("SemanticModelsId");

        // Report has one or more Queries of type BIQuery
        modelBuilder.Entity<BIQuery>()
            .HasOne<Report>()
            .WithMany(parent => parent.Queries)
            .HasForeignKey("QueriesId");

        // Report has one or more Tags of type Tag
        modelBuilder.Entity<Tag>()
            .HasOne<Report>()
            .WithMany(parent => parent.Tags)
            .HasForeignKey("TagsId");

        // Dashboard has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<Dashboard>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("WorkspaceId");


        // Dashboard has one or more Visualizations of type Visualization
        modelBuilder.Entity<Visualization>()
            .HasOne<Dashboard>()
            .WithMany(parent => parent.Visualizations)
            .HasForeignKey("VisualizationsId");

        // Dashboard has one or more Reports of type Report
        modelBuilder.Entity<Report>()
            .HasOne<Dashboard>()
            .WithMany(parent => parent.Reports)
            .HasForeignKey("ReportsId");

        // Dashboard has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<Dashboard>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("DatasetsId");

        // Dashboard has one or more Alerts of type Alert
        modelBuilder.Entity<Alert>()
            .HasOne<Dashboard>()
            .WithMany(parent => parent.Alerts)
            .HasForeignKey("AlertsId");

        // Dashboard has one or more Queries of type BIQuery
        modelBuilder.Entity<BIQuery>()
            .HasOne<Dashboard>()
            .WithMany(parent => parent.Queries)
            .HasForeignKey("QueriesId");

        // Dashboard has one or more Tags of type Tag
        modelBuilder.Entity<Tag>()
            .HasOne<Dashboard>()
            .WithMany(parent => parent.Tags)
            .HasForeignKey("TagsId");

        // Visualization has one Dashboard of type Dashboard
        modelBuilder.Entity<Visualization>()
            .HasOne(x => x.Dashboard)
            .WithMany()
            .HasForeignKey("DashboardId");

        // Visualization has one Report of type Report
        modelBuilder.Entity<Visualization>()
            .HasOne(x => x.Report)
            .WithMany()
            .HasForeignKey("ReportId");


        // Visualization has one or more Metrics of type Metric
        modelBuilder.Entity<Metric>()
            .HasOne<Visualization>()
            .WithMany(parent => parent.Metrics)
            .HasForeignKey("MetricsId");

        // Visualization has one or more Dimensions of type Dimension
        modelBuilder.Entity<Dimension>()
            .HasOne<Visualization>()
            .WithMany(parent => parent.Dimensions)
            .HasForeignKey("DimensionsId");

        // Visualization has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<Visualization>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("DatasetsId");

        // Notebook has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<Notebook>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("WorkspaceId");


        // Notebook has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<Notebook>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("DatasetsId");

        // Notebook has one or more Experiments of type Experiment
        modelBuilder.Entity<Experiment>()
            .HasOne<Notebook>()
            .WithMany(parent => parent.Experiments)
            .HasForeignKey("ExperimentsId");

        // Notebook has one or more Queries of type BIQuery
        modelBuilder.Entity<BIQuery>()
            .HasOne<Notebook>()
            .WithMany(parent => parent.Queries)
            .HasForeignKey("QueriesId");

        // BIQuery has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<BIQuery>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("WorkspaceId");


        // BIQuery has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<BIQuery>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("DatasetsId");

        // BIQuery has one or more Reports of type Report
        modelBuilder.Entity<Report>()
            .HasOne<BIQuery>()
            .WithMany(parent => parent.Reports)
            .HasForeignKey("ReportsId");

        // BIQuery has one or more Dashboards of type Dashboard
        modelBuilder.Entity<Dashboard>()
            .HasOne<BIQuery>()
            .WithMany(parent => parent.Dashboards)
            .HasForeignKey("DashboardsId");

        // BIQuery has one or more Notebooks of type Notebook
        modelBuilder.Entity<Notebook>()
            .HasOne<BIQuery>()
            .WithMany(parent => parent.Notebooks)
            .HasForeignKey("NotebooksId");

        // Experiment has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<Experiment>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("WorkspaceId");


        // Experiment has one or more TrainingRuns of type TrainingRun
        modelBuilder.Entity<TrainingRun>()
            .HasOne<Experiment>()
            .WithMany(parent => parent.TrainingRuns)
            .HasForeignKey("TrainingRunsId");

        // Experiment has one or more Models of type Model
        modelBuilder.Entity<Model>()
            .HasOne<Experiment>()
            .WithMany(parent => parent.Models)
            .HasForeignKey("ModelsId");

        // Experiment has one or more Notebooks of type Notebook
        modelBuilder.Entity<Notebook>()
            .HasOne<Experiment>()
            .WithMany(parent => parent.Notebooks)
            .HasForeignKey("NotebooksId");

        // TrainingRun has one Experiment of type Experiment
        modelBuilder.Entity<TrainingRun>()
            .HasOne(x => x.Experiment)
            .WithMany()
            .HasForeignKey("ExperimentId");

        // TrainingRun has one ModelVersion of type ModelVersion
        modelBuilder.Entity<TrainingRun>()
            .HasOne(x => x.ModelVersion)
            .WithMany()
            .HasForeignKey("ModelVersionId");


        // TrainingRun has one or more InputDatasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<TrainingRun>()
            .WithMany(parent => parent.InputDatasets)
            .HasForeignKey("InputDatasetsId");

        // TrainingRun has one or more Features of type Feature
        modelBuilder.Entity<Feature>()
            .HasOne<TrainingRun>()
            .WithMany(parent => parent.Features)
            .HasForeignKey("FeaturesId");

        // TrainingRun has one or more RunMetrics of type RunMetric
        modelBuilder.Entity<RunMetric>()
            .HasOne<TrainingRun>()
            .WithMany(parent => parent.RunMetrics)
            .HasForeignKey("RunMetricsId");

        // TrainingRun has one or more RunParameters of type RunParameter
        modelBuilder.Entity<RunParameter>()
            .HasOne<TrainingRun>()
            .WithMany(parent => parent.RunParameters)
            .HasForeignKey("RunParametersId");

        // RunMetric has one TrainingRun of type TrainingRun
        modelBuilder.Entity<RunMetric>()
            .HasOne(x => x.TrainingRun)
            .WithMany()
            .HasForeignKey("TrainingRunId");

        // RunMetric has one Metric of type Metric
        modelBuilder.Entity<RunMetric>()
            .HasOne(x => x.Metric)
            .WithMany()
            .HasForeignKey("MetricId");

        // RunMetric has one Dataset of type DataSet
        modelBuilder.Entity<RunMetric>()
            .HasOne(x => x.Dataset)
            .WithMany()
            .HasForeignKey("DatasetId");


        // RunParameter has one TrainingRun of type TrainingRun
        modelBuilder.Entity<RunParameter>()
            .HasOne(x => x.TrainingRun)
            .WithMany()
            .HasForeignKey("TrainingRunId");


        // Model has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<Model>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("WorkspaceId");


        // Model has one or more Versions of type ModelVersion
        modelBuilder.Entity<ModelVersion>()
            .HasOne<Model>()
            .WithMany(parent => parent.Versions)
            .HasForeignKey("VersionsId");

        // Model has one or more FeatureSets of type FeatureSet
        modelBuilder.Entity<FeatureSet>()
            .HasOne<Model>()
            .WithMany(parent => parent.FeatureSets)
            .HasForeignKey("FeatureSetsId");

        // Model has one or more Experiments of type Experiment
        modelBuilder.Entity<Experiment>()
            .HasOne<Model>()
            .WithMany(parent => parent.Experiments)
            .HasForeignKey("ExperimentsId");

        // Model has one or more Tags of type Tag
        modelBuilder.Entity<Tag>()
            .HasOne<Model>()
            .WithMany(parent => parent.Tags)
            .HasForeignKey("TagsId");

        // ModelVersion has one Model of type Model
        modelBuilder.Entity<ModelVersion>()
            .HasOne(x => x.Model)
            .WithMany()
            .HasForeignKey("ModelId");

        // ModelVersion has one TrainingRun of type TrainingRun
        modelBuilder.Entity<ModelVersion>()
            .HasOne(x => x.TrainingRun)
            .WithMany()
            .HasForeignKey("TrainingRunId");


        // ModelVersion has one or more EvaluationMetrics of type EvaluationMetric
        modelBuilder.Entity<EvaluationMetric>()
            .HasOne<ModelVersion>()
            .WithMany(parent => parent.EvaluationMetrics)
            .HasForeignKey("EvaluationMetricsId");

        // ModelVersion has one or more Deployments of type InferenceEndpoint
        modelBuilder.Entity<InferenceEndpoint>()
            .HasOne<ModelVersion>()
            .WithMany(parent => parent.Deployments)
            .HasForeignKey("DeploymentsId");

        // ModelVersion has one or more FeatureSets of type FeatureSet
        modelBuilder.Entity<FeatureSet>()
            .HasOne<ModelVersion>()
            .WithMany(parent => parent.FeatureSets)
            .HasForeignKey("FeatureSetsId");

        // ModelVersion has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<ModelVersion>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("DatasetsId");

        // EvaluationMetric has one ModelVersion of type ModelVersion
        modelBuilder.Entity<EvaluationMetric>()
            .HasOne(x => x.ModelVersion)
            .WithMany()
            .HasForeignKey("ModelVersionId");

        // EvaluationMetric has one Metric of type Metric
        modelBuilder.Entity<EvaluationMetric>()
            .HasOne(x => x.Metric)
            .WithMany()
            .HasForeignKey("MetricId");

        // EvaluationMetric has one Dataset of type DataSet
        modelBuilder.Entity<EvaluationMetric>()
            .HasOne(x => x.Dataset)
            .WithMany()
            .HasForeignKey("DatasetId");


        // FeatureSet has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<FeatureSet>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("WorkspaceId");


        // FeatureSet has one or more Features of type Feature
        modelBuilder.Entity<Feature>()
            .HasOne<FeatureSet>()
            .WithMany(parent => parent.Features)
            .HasForeignKey("FeaturesId");

        // FeatureSet has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<FeatureSet>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("DatasetsId");

        // FeatureSet has one or more Models of type Model
        modelBuilder.Entity<Model>()
            .HasOne<FeatureSet>()
            .WithMany(parent => parent.Models)
            .HasForeignKey("ModelsId");

        // FeatureSet has one or more ModelVersions of type ModelVersion
        modelBuilder.Entity<ModelVersion>()
            .HasOne<FeatureSet>()
            .WithMany(parent => parent.ModelVersions)
            .HasForeignKey("ModelVersionsId");

        // FeatureSet has one or more Tags of type Tag
        modelBuilder.Entity<Tag>()
            .HasOne<FeatureSet>()
            .WithMany(parent => parent.Tags)
            .HasForeignKey("TagsId");

        // Feature has one FeatureSet of type FeatureSet
        modelBuilder.Entity<Feature>()
            .HasOne(x => x.FeatureSet)
            .WithMany()
            .HasForeignKey("FeatureSetId");


        // Feature has one or more SourceDatasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<Feature>()
            .WithMany(parent => parent.SourceDatasets)
            .HasForeignKey("SourceDatasetsId");

        // Feature has one or more Models of type Model
        modelBuilder.Entity<Model>()
            .HasOne<Feature>()
            .WithMany(parent => parent.Models)
            .HasForeignKey("ModelsId");

        // Feature has one or more TrainingRuns of type TrainingRun
        modelBuilder.Entity<TrainingRun>()
            .HasOne<Feature>()
            .WithMany(parent => parent.TrainingRuns)
            .HasForeignKey("TrainingRunsId");

        // InferenceEndpoint has one ModelVersion of type ModelVersion
        modelBuilder.Entity<InferenceEndpoint>()
            .HasOne(x => x.ModelVersion)
            .WithMany()
            .HasForeignKey("ModelVersionId");

        // InferenceEndpoint has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<InferenceEndpoint>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("WorkspaceId");


        // InferenceEndpoint has one or more Predictions of type Prediction
        modelBuilder.Entity<Prediction>()
            .HasOne<InferenceEndpoint>()
            .WithMany(parent => parent.Predictions)
            .HasForeignKey("PredictionsId");

        // Prediction has one Endpoint of type InferenceEndpoint
        modelBuilder.Entity<Prediction>()
            .HasOne(x => x.Endpoint)
            .WithMany()
            .HasForeignKey("EndpointId");

        // Prediction has one ModelVersion of type ModelVersion
        modelBuilder.Entity<Prediction>()
            .HasOne(x => x.ModelVersion)
            .WithMany()
            .HasForeignKey("ModelVersionId");

        // Prediction has one Dataset of type DataSet
        modelBuilder.Entity<Prediction>()
            .HasOne(x => x.Dataset)
            .WithMany()
            .HasForeignKey("DatasetId");


        // Forecast has one ModelVersion of type ModelVersion
        modelBuilder.Entity<Forecast>()
            .HasOne(x => x.ModelVersion)
            .WithMany()
            .HasForeignKey("ModelVersionId");

        // Forecast has one TimeSeries of type TimeSeries
        modelBuilder.Entity<Forecast>()
            .HasOne(x => x.TimeSeries)
            .WithMany()
            .HasForeignKey("TimeSeriesId");


        // Forecast has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<Forecast>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("DatasetsId");


        // TimeSeries has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<TimeSeries>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("DatasetsId");

        // TimeSeries has one or more Forecasts of type Forecast
        modelBuilder.Entity<Forecast>()
            .HasOne<TimeSeries>()
            .WithMany(parent => parent.Forecasts)
            .HasForeignKey("ForecastsId");

        // TimeSeries has one or more Anomalies of type Anomaly
        modelBuilder.Entity<Anomaly>()
            .HasOne<TimeSeries>()
            .WithMany(parent => parent.Anomalies)
            .HasForeignKey("AnomaliesId");

        // Anomaly has one TimeSeries of type TimeSeries
        modelBuilder.Entity<Anomaly>()
            .HasOne(x => x.TimeSeries)
            .WithMany()
            .HasForeignKey("TimeSeriesId");

        // Anomaly has one Alert of type Alert
        modelBuilder.Entity<Anomaly>()
            .HasOne(x => x.Alert)
            .WithMany()
            .HasForeignKey("AlertId");

        // Anomaly has one Dataset of type DataSet
        modelBuilder.Entity<Anomaly>()
            .HasOne(x => x.Dataset)
            .WithMany()
            .HasForeignKey("DatasetId");


        // QualityRule has one Dataset of type DataSet
        modelBuilder.Entity<QualityRule>()
            .HasOne(x => x.Dataset)
            .WithMany()
            .HasForeignKey("DatasetId");


        // QualityRule has one or more Checks of type QualityCheck
        modelBuilder.Entity<QualityCheck>()
            .HasOne<QualityRule>()
            .WithMany(parent => parent.Checks)
            .HasForeignKey("ChecksId");

        // QualityCheck has one Rule of type QualityRule
        modelBuilder.Entity<QualityCheck>()
            .HasOne(x => x.Rule)
            .WithMany()
            .HasForeignKey("RuleId");

        // QualityCheck has one Dataset of type DataSet
        modelBuilder.Entity<QualityCheck>()
            .HasOne(x => x.Dataset)
            .WithMany()
            .HasForeignKey("DatasetId");


        // LineageNode has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<LineageNode>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("WorkspaceId");


        // LineageNode has one or more Inputs of type LineageNode
        modelBuilder.Entity<LineageNode>()
            .HasOne<LineageNode>()
            .WithMany(parent => parent.Inputs)
            .HasForeignKey("InputsId");

        // LineageNode has one or more Outputs of type LineageNode
        modelBuilder.Entity<LineageNode>()
            .HasOne<LineageNode>()
            .WithMany(parent => parent.Outputs)
            .HasForeignKey("OutputsId");

        // LineageNode has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<LineageNode>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("DatasetsId");

        // LineageNode has one or more Models of type Model
        modelBuilder.Entity<Model>()
            .HasOne<LineageNode>()
            .WithMany(parent => parent.Models)
            .HasForeignKey("ModelsId");

        // LineageNode has one or more Pipelines of type DataPipeline
        modelBuilder.Entity<DataPipeline>()
            .HasOne<LineageNode>()
            .WithMany(parent => parent.Pipelines)
            .HasForeignKey("PipelinesId");

        // LineageNode has one or more Dashboards of type Dashboard
        modelBuilder.Entity<Dashboard>()
            .HasOne<LineageNode>()
            .WithMany(parent => parent.Dashboards)
            .HasForeignKey("DashboardsId");

        // LineageNode has one or more Reports of type Report
        modelBuilder.Entity<Report>()
            .HasOne<LineageNode>()
            .WithMany(parent => parent.Reports)
            .HasForeignKey("ReportsId");


        // Tag has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<Tag>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("DatasetsId");

        // Tag has one or more Models of type Model
        modelBuilder.Entity<Model>()
            .HasOne<Tag>()
            .WithMany(parent => parent.Models)
            .HasForeignKey("ModelsId");

        // Tag has one or more ModelVersions of type ModelVersion
        modelBuilder.Entity<ModelVersion>()
            .HasOne<Tag>()
            .WithMany(parent => parent.ModelVersions)
            .HasForeignKey("ModelVersionsId");

        // Tag has one or more Dashboards of type Dashboard
        modelBuilder.Entity<Dashboard>()
            .HasOne<Tag>()
            .WithMany(parent => parent.Dashboards)
            .HasForeignKey("DashboardsId");

        // Tag has one or more Reports of type Report
        modelBuilder.Entity<Report>()
            .HasOne<Tag>()
            .WithMany(parent => parent.Reports)
            .HasForeignKey("ReportsId");

        // Tag has one or more FeatureSets of type FeatureSet
        modelBuilder.Entity<FeatureSet>()
            .HasOne<Tag>()
            .WithMany(parent => parent.FeatureSets)
            .HasForeignKey("FeatureSetsId");

        // Tag has one or more Metrics of type Metric
        modelBuilder.Entity<Metric>()
            .HasOne<Tag>()
            .WithMany(parent => parent.Metrics)
            .HasForeignKey("MetricsId");

        // AccessPolicy has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<AccessPolicy>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("WorkspaceId");


        // AccessPolicy has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<AccessPolicy>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("DatasetsId");

        // AccessPolicy has one or more Dashboards of type Dashboard
        modelBuilder.Entity<Dashboard>()
            .HasOne<AccessPolicy>()
            .WithMany(parent => parent.Dashboards)
            .HasForeignKey("DashboardsId");

        // AccessPolicy has one or more Reports of type Report
        modelBuilder.Entity<Report>()
            .HasOne<AccessPolicy>()
            .WithMany(parent => parent.Reports)
            .HasForeignKey("ReportsId");

        // AccessPolicy has one or more Models of type Model
        modelBuilder.Entity<Model>()
            .HasOne<AccessPolicy>()
            .WithMany(parent => parent.Models)
            .HasForeignKey("ModelsId");

        // AccessPolicy has one or more FeatureSets of type FeatureSet
        modelBuilder.Entity<FeatureSet>()
            .HasOne<AccessPolicy>()
            .WithMany(parent => parent.FeatureSets)
            .HasForeignKey("FeatureSetsId");

        // Alert has one Metric of type Metric
        modelBuilder.Entity<Alert>()
            .HasOne(x => x.Metric)
            .WithMany()
            .HasForeignKey("MetricId");

        // Alert has one Dashboard of type Dashboard
        modelBuilder.Entity<Alert>()
            .HasOne(x => x.Dashboard)
            .WithMany()
            .HasForeignKey("DashboardId");

        // Alert has one Dataset of type DataSet
        modelBuilder.Entity<Alert>()
            .HasOne(x => x.Dataset)
            .WithMany()
            .HasForeignKey("DatasetId");

        // Alert has one Rule of type QualityRule
        modelBuilder.Entity<Alert>()
            .HasOne(x => x.Rule)
            .WithMany()
            .HasForeignKey("RuleId");


        // Alert has one or more Anomalies of type Anomaly
        modelBuilder.Entity<Anomaly>()
            .HasOne<Alert>()
            .WithMany(parent => parent.Anomalies)
            .HasForeignKey("AnomaliesId");

        // Alert has one or more Subscribers of type Subscriber
        modelBuilder.Entity<Subscriber>()
            .HasOne<Alert>()
            .WithMany(parent => parent.Subscribers)
            .HasForeignKey("SubscribersId");


        // Subscriber has one or more Alerts of type Alert
        modelBuilder.Entity<Alert>()
            .HasOne<Subscriber>()
            .WithMany(parent => parent.Alerts)
            .HasForeignKey("AlertsId");


        // BusinessGlossaryTerm has one or more RelatedTerms of type BusinessGlossaryTerm
        modelBuilder.Entity<BusinessGlossaryTerm>()
            .HasOne<BusinessGlossaryTerm>()
            .WithMany(parent => parent.RelatedTerms)
            .HasForeignKey("RelatedTermsId");

        // BusinessGlossaryTerm has one or more Metrics of type Metric
        modelBuilder.Entity<Metric>()
            .HasOne<BusinessGlossaryTerm>()
            .WithMany(parent => parent.Metrics)
            .HasForeignKey("MetricsId");

        // BusinessGlossaryTerm has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<BusinessGlossaryTerm>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("DatasetsId");

        // BusinessGlossaryTerm has one or more Dimensions of type Dimension
        modelBuilder.Entity<Dimension>()
            .HasOne<BusinessGlossaryTerm>()
            .WithMany(parent => parent.Dimensions)
            .HasForeignKey("DimensionsId");

        // BusinessGlossaryTerm has one or more Measures of type Measure
        modelBuilder.Entity<Measure>()
            .HasOne<BusinessGlossaryTerm>()
            .WithMany(parent => parent.Measures)
            .HasForeignKey("MeasuresId");


        // RecommendationScenario has one or more Models of type Model
        modelBuilder.Entity<Model>()
            .HasOne<RecommendationScenario>()
            .WithMany(parent => parent.Models)
            .HasForeignKey("ModelsId");

        // RecommendationScenario has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<RecommendationScenario>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("DatasetsId");

        // RecommendationScenario has one or more Experiments of type Experiment
        modelBuilder.Entity<Experiment>()
            .HasOne<RecommendationScenario>()
            .WithMany(parent => parent.Experiments)
            .HasForeignKey("ExperimentsId");

        // RecommendationScenario has one or more Alerts of type Alert
        modelBuilder.Entity<Alert>()
            .HasOne<RecommendationScenario>()
            .WithMany(parent => parent.Alerts)
            .HasForeignKey("AlertsId");


        // FraudScenario has one or more Models of type Model
        modelBuilder.Entity<Model>()
            .HasOne<FraudScenario>()
            .WithMany(parent => parent.Models)
            .HasForeignKey("ModelsId");

        // FraudScenario has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<FraudScenario>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("DatasetsId");

        // FraudScenario has one or more Alerts of type Alert
        modelBuilder.Entity<Alert>()
            .HasOne<FraudScenario>()
            .WithMany(parent => parent.Alerts)
            .HasForeignKey("AlertsId");

        // FraudScenario has one or more Signals of type FraudSignal
        modelBuilder.Entity<FraudSignal>()
            .HasOne<FraudScenario>()
            .WithMany(parent => parent.Signals)
            .HasForeignKey("SignalsId");

        // FraudSignal has one Scenario of type FraudScenario
        modelBuilder.Entity<FraudSignal>()
            .HasOne(x => x.Scenario)
            .WithMany()
            .HasForeignKey("ScenarioId");

        // FraudSignal has one Dataset of type DataSet
        modelBuilder.Entity<FraudSignal>()
            .HasOne(x => x.Dataset)
            .WithMany()
            .HasForeignKey("DatasetId");

        // FraudSignal has one ModelVersion of type ModelVersion
        modelBuilder.Entity<FraudSignal>()
            .HasOne(x => x.ModelVersion)
            .WithMany()
            .HasForeignKey("ModelVersionId");


    }
}

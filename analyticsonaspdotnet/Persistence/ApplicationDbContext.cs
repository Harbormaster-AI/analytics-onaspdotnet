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
    public DbSet<Model_> Model_s => Set<Model_>();
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
            .HasForeignKey("AnalyticsWorkspace_Id");

        // AnalyticsWorkspace has one or more DataSources of type DataSource
        modelBuilder.Entity<DataSource>()
            .HasOne<AnalyticsWorkspace>()
            .WithMany(parent => parent.DataSources)
            .HasForeignKey("AnalyticsWorkspace_Id");

        // AnalyticsWorkspace has one or more Pipelines of type DataPipeline
        modelBuilder.Entity<DataPipeline>()
            .HasOne<AnalyticsWorkspace>()
            .WithMany(parent => parent.Pipelines)
            .HasForeignKey("AnalyticsWorkspace_Id");

        // AnalyticsWorkspace has one or more Dashboards of type Dashboard
        modelBuilder.Entity<Dashboard>()
            .HasOne<AnalyticsWorkspace>()
            .WithMany(parent => parent.Dashboards)
            .HasForeignKey("AnalyticsWorkspace_Id");

        // AnalyticsWorkspace has one or more Reports of type Report
        modelBuilder.Entity<Report>()
            .HasOne<AnalyticsWorkspace>()
            .WithMany(parent => parent.Reports)
            .HasForeignKey("AnalyticsWorkspace_Id");

        // AnalyticsWorkspace has one or more Notebooks of type Notebook
        modelBuilder.Entity<Notebook>()
            .HasOne<AnalyticsWorkspace>()
            .WithMany(parent => parent.Notebooks)
            .HasForeignKey("AnalyticsWorkspace_Id");

        // AnalyticsWorkspace has one or more Models of type Model_
        modelBuilder.Entity<Model_>()
            .HasOne<AnalyticsWorkspace>()
            .WithMany(parent => parent.Models)
            .HasForeignKey("AnalyticsWorkspace_Id");

        // AnalyticsWorkspace has one or more FeatureSets of type FeatureSet
        modelBuilder.Entity<FeatureSet>()
            .HasOne<AnalyticsWorkspace>()
            .WithMany(parent => parent.FeatureSets)
            .HasForeignKey("AnalyticsWorkspace_Id");

        // AnalyticsWorkspace has one or more Policies of type AccessPolicy
        modelBuilder.Entity<AccessPolicy>()
            .HasOne<AnalyticsWorkspace>()
            .WithMany(parent => parent.Policies)
            .HasForeignKey("AnalyticsWorkspace_Id");

        // AnalyticsWorkspace has one or more LineageNodes of type LineageNode
        modelBuilder.Entity<LineageNode>()
            .HasOne<AnalyticsWorkspace>()
            .WithMany(parent => parent.LineageNodes)
            .HasForeignKey("AnalyticsWorkspace_Id");

        // DataSource has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<DataSource>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("Workspace_Id");


        // DataSource has one or more ProducedDatasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<DataSource>()
            .WithMany(parent => parent.ProducedDatasets)
            .HasForeignKey("DataSource_Id");

        // DataSource has one or more Pipelines of type DataPipeline
        modelBuilder.Entity<DataPipeline>()
            .HasOne<DataSource>()
            .WithMany(parent => parent.Pipelines)
            .HasForeignKey("DataSource_Id");

        // DataSet has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<DataSet>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("Workspace_Id");

        // DataSet has one LineageNode of type LineageNode
        modelBuilder.Entity<DataSet>()
            .HasOne(x => x.LineageNode)
            .WithMany()
            .HasForeignKey("LineageNode_Id");


        // DataSet has one or more Sources of type DataSource
        modelBuilder.Entity<DataSource>()
            .HasOne<DataSet>()
            .WithMany(parent => parent.Sources)
            .HasForeignKey("DataSet_Id");

        // DataSet has one or more Pipelines of type DataPipeline
        modelBuilder.Entity<DataPipeline>()
            .HasOne<DataSet>()
            .WithMany(parent => parent.Pipelines)
            .HasForeignKey("DataSet_Id");

        // DataSet has one or more SemanticModels of type SemanticModel
        modelBuilder.Entity<SemanticModel>()
            .HasOne<DataSet>()
            .WithMany(parent => parent.SemanticModels)
            .HasForeignKey("DataSet_Id");

        // DataSet has one or more Dimensions of type Dimension
        modelBuilder.Entity<Dimension>()
            .HasOne<DataSet>()
            .WithMany(parent => parent.Dimensions)
            .HasForeignKey("DataSet_Id");

        // DataSet has one or more Measures of type Measure
        modelBuilder.Entity<Measure>()
            .HasOne<DataSet>()
            .WithMany(parent => parent.Measures)
            .HasForeignKey("DataSet_Id");

        // DataSet has one or more Metrics of type Metric
        modelBuilder.Entity<Metric>()
            .HasOne<DataSet>()
            .WithMany(parent => parent.Metrics)
            .HasForeignKey("DataSet_Id");

        // DataSet has one or more QualityRules of type QualityRule
        modelBuilder.Entity<QualityRule>()
            .HasOne<DataSet>()
            .WithMany(parent => parent.QualityRules)
            .HasForeignKey("DataSet_Id");

        // DataSet has one or more Tags of type Tag
        modelBuilder.Entity<Tag>()
            .HasOne<DataSet>()
            .WithMany(parent => parent.Tags)
            .HasForeignKey("DataSet_Id");

        // DataPipeline has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<DataPipeline>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("Workspace_Id");

        // DataPipeline has one LineageNode of type LineageNode
        modelBuilder.Entity<DataPipeline>()
            .HasOne(x => x.LineageNode)
            .WithMany()
            .HasForeignKey("LineageNode_Id");


        // DataPipeline has one or more Tasks of type DataTask
        modelBuilder.Entity<DataTask>()
            .HasOne<DataPipeline>()
            .WithMany(parent => parent.Tasks)
            .HasForeignKey("DataPipeline_Id");

        // DataPipeline has one or more Sources of type DataSource
        modelBuilder.Entity<DataSource>()
            .HasOne<DataPipeline>()
            .WithMany(parent => parent.Sources)
            .HasForeignKey("DataPipeline_Id");

        // DataPipeline has one or more Outputs of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<DataPipeline>()
            .WithMany(parent => parent.Outputs)
            .HasForeignKey("DataPipeline_Id");

        // DataTask has one Pipeline of type DataPipeline
        modelBuilder.Entity<DataTask>()
            .HasOne(x => x.Pipeline)
            .WithMany()
            .HasForeignKey("Pipeline_Id");


        // DataTask has one or more InputDatasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<DataTask>()
            .WithMany(parent => parent.InputDatasets)
            .HasForeignKey("DataTask_Id");

        // DataTask has one or more OutputDatasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<DataTask>()
            .WithMany(parent => parent.OutputDatasets)
            .HasForeignKey("DataTask_Id");


        // SemanticModel has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<SemanticModel>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("SemanticModel_Id");

        // SemanticModel has one or more Metrics of type Metric
        modelBuilder.Entity<Metric>()
            .HasOne<SemanticModel>()
            .WithMany(parent => parent.Metrics)
            .HasForeignKey("SemanticModel_Id");

        // SemanticModel has one or more Dimensions of type Dimension
        modelBuilder.Entity<Dimension>()
            .HasOne<SemanticModel>()
            .WithMany(parent => parent.Dimensions)
            .HasForeignKey("SemanticModel_Id");

        // SemanticModel has one or more Measures of type Measure
        modelBuilder.Entity<Measure>()
            .HasOne<SemanticModel>()
            .WithMany(parent => parent.Measures)
            .HasForeignKey("SemanticModel_Id");

        // SemanticModel has one or more GlossaryTerms of type BusinessGlossaryTerm
        modelBuilder.Entity<BusinessGlossaryTerm>()
            .HasOne<SemanticModel>()
            .WithMany(parent => parent.GlossaryTerms)
            .HasForeignKey("SemanticModel_Id");

        // Dimension has one SemanticModel of type SemanticModel
        modelBuilder.Entity<Dimension>()
            .HasOne(x => x.SemanticModel)
            .WithMany()
            .HasForeignKey("SemanticModel_Id");


        // Dimension has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<Dimension>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("Dimension_Id");

        // Dimension has one or more GlossaryTerms of type BusinessGlossaryTerm
        modelBuilder.Entity<BusinessGlossaryTerm>()
            .HasOne<Dimension>()
            .WithMany(parent => parent.GlossaryTerms)
            .HasForeignKey("Dimension_Id");

        // Measure has one SemanticModel of type SemanticModel
        modelBuilder.Entity<Measure>()
            .HasOne(x => x.SemanticModel)
            .WithMany()
            .HasForeignKey("SemanticModel_Id");


        // Measure has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<Measure>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("Measure_Id");

        // Measure has one or more GlossaryTerms of type BusinessGlossaryTerm
        modelBuilder.Entity<BusinessGlossaryTerm>()
            .HasOne<Measure>()
            .WithMany(parent => parent.GlossaryTerms)
            .HasForeignKey("Measure_Id");

        // Metric has one SemanticModel of type SemanticModel
        modelBuilder.Entity<Metric>()
            .HasOne(x => x.SemanticModel)
            .WithMany()
            .HasForeignKey("SemanticModel_Id");


        // Metric has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<Metric>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("Metric_Id");

        // Metric has one or more GlossaryTerms of type BusinessGlossaryTerm
        modelBuilder.Entity<BusinessGlossaryTerm>()
            .HasOne<Metric>()
            .WithMany(parent => parent.GlossaryTerms)
            .HasForeignKey("Metric_Id");

        // Metric has one or more Alerts of type Alert
        modelBuilder.Entity<Alert>()
            .HasOne<Metric>()
            .WithMany(parent => parent.Alerts)
            .HasForeignKey("Metric_Id");

        // Metric has one or more Visualizations of type Visualization
        modelBuilder.Entity<Visualization>()
            .HasOne<Metric>()
            .WithMany(parent => parent.Visualizations)
            .HasForeignKey("Metric_Id");

        // Report has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<Report>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("Workspace_Id");


        // Report has one or more Visualizations of type Visualization
        modelBuilder.Entity<Visualization>()
            .HasOne<Report>()
            .WithMany(parent => parent.Visualizations)
            .HasForeignKey("Report_Id");

        // Report has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<Report>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("Report_Id");

        // Report has one or more SemanticModels of type SemanticModel
        modelBuilder.Entity<SemanticModel>()
            .HasOne<Report>()
            .WithMany(parent => parent.SemanticModels)
            .HasForeignKey("Report_Id");

        // Report has one or more Queries of type BIQuery
        modelBuilder.Entity<BIQuery>()
            .HasOne<Report>()
            .WithMany(parent => parent.Queries)
            .HasForeignKey("Report_Id");

        // Report has one or more Tags of type Tag
        modelBuilder.Entity<Tag>()
            .HasOne<Report>()
            .WithMany(parent => parent.Tags)
            .HasForeignKey("Report_Id");

        // Dashboard has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<Dashboard>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("Workspace_Id");


        // Dashboard has one or more Visualizations of type Visualization
        modelBuilder.Entity<Visualization>()
            .HasOne<Dashboard>()
            .WithMany(parent => parent.Visualizations)
            .HasForeignKey("Dashboard_Id");

        // Dashboard has one or more Reports of type Report
        modelBuilder.Entity<Report>()
            .HasOne<Dashboard>()
            .WithMany(parent => parent.Reports)
            .HasForeignKey("Dashboard_Id");

        // Dashboard has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<Dashboard>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("Dashboard_Id");

        // Dashboard has one or more Alerts of type Alert
        modelBuilder.Entity<Alert>()
            .HasOne<Dashboard>()
            .WithMany(parent => parent.Alerts)
            .HasForeignKey("Dashboard_Id");

        // Dashboard has one or more Queries of type BIQuery
        modelBuilder.Entity<BIQuery>()
            .HasOne<Dashboard>()
            .WithMany(parent => parent.Queries)
            .HasForeignKey("Dashboard_Id");

        // Dashboard has one or more Tags of type Tag
        modelBuilder.Entity<Tag>()
            .HasOne<Dashboard>()
            .WithMany(parent => parent.Tags)
            .HasForeignKey("Dashboard_Id");

        // Visualization has one Dashboard of type Dashboard
        modelBuilder.Entity<Visualization>()
            .HasOne(x => x.Dashboard)
            .WithMany()
            .HasForeignKey("Dashboard_Id");

        // Visualization has one Report of type Report
        modelBuilder.Entity<Visualization>()
            .HasOne(x => x.Report)
            .WithMany()
            .HasForeignKey("Report_Id");


        // Visualization has one or more Metrics of type Metric
        modelBuilder.Entity<Metric>()
            .HasOne<Visualization>()
            .WithMany(parent => parent.Metrics)
            .HasForeignKey("Visualization_Id");

        // Visualization has one or more Dimensions of type Dimension
        modelBuilder.Entity<Dimension>()
            .HasOne<Visualization>()
            .WithMany(parent => parent.Dimensions)
            .HasForeignKey("Visualization_Id");

        // Visualization has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<Visualization>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("Visualization_Id");

        // Notebook has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<Notebook>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("Workspace_Id");


        // Notebook has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<Notebook>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("Notebook_Id");

        // Notebook has one or more Experiments of type Experiment
        modelBuilder.Entity<Experiment>()
            .HasOne<Notebook>()
            .WithMany(parent => parent.Experiments)
            .HasForeignKey("Notebook_Id");

        // Notebook has one or more Queries of type BIQuery
        modelBuilder.Entity<BIQuery>()
            .HasOne<Notebook>()
            .WithMany(parent => parent.Queries)
            .HasForeignKey("Notebook_Id");

        // BIQuery has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<BIQuery>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("Workspace_Id");


        // BIQuery has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<BIQuery>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("BIQuery_Id");

        // BIQuery has one or more Reports of type Report
        modelBuilder.Entity<Report>()
            .HasOne<BIQuery>()
            .WithMany(parent => parent.Reports)
            .HasForeignKey("BIQuery_Id");

        // BIQuery has one or more Dashboards of type Dashboard
        modelBuilder.Entity<Dashboard>()
            .HasOne<BIQuery>()
            .WithMany(parent => parent.Dashboards)
            .HasForeignKey("BIQuery_Id");

        // BIQuery has one or more Notebooks of type Notebook
        modelBuilder.Entity<Notebook>()
            .HasOne<BIQuery>()
            .WithMany(parent => parent.Notebooks)
            .HasForeignKey("BIQuery_Id");

        // Experiment has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<Experiment>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("Workspace_Id");


        // Experiment has one or more TrainingRuns of type TrainingRun
        modelBuilder.Entity<TrainingRun>()
            .HasOne<Experiment>()
            .WithMany(parent => parent.TrainingRuns)
            .HasForeignKey("Experiment_Id");

        // Experiment has one or more Models of type Model_
        modelBuilder.Entity<Model_>()
            .HasOne<Experiment>()
            .WithMany(parent => parent.Models)
            .HasForeignKey("Experiment_Id");

        // Experiment has one or more Notebooks of type Notebook
        modelBuilder.Entity<Notebook>()
            .HasOne<Experiment>()
            .WithMany(parent => parent.Notebooks)
            .HasForeignKey("Experiment_Id");

        // TrainingRun has one Experiment of type Experiment
        modelBuilder.Entity<TrainingRun>()
            .HasOne(x => x.Experiment)
            .WithMany()
            .HasForeignKey("Experiment_Id");

        // TrainingRun has one ModelVersion of type ModelVersion
        modelBuilder.Entity<TrainingRun>()
            .HasOne(x => x.ModelVersion)
            .WithMany()
            .HasForeignKey("ModelVersion_Id");


        // TrainingRun has one or more InputDatasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<TrainingRun>()
            .WithMany(parent => parent.InputDatasets)
            .HasForeignKey("TrainingRun_Id");

        // TrainingRun has one or more Features of type Feature
        modelBuilder.Entity<Feature>()
            .HasOne<TrainingRun>()
            .WithMany(parent => parent.Features)
            .HasForeignKey("TrainingRun_Id");

        // TrainingRun has one or more RunMetrics of type RunMetric
        modelBuilder.Entity<RunMetric>()
            .HasOne<TrainingRun>()
            .WithMany(parent => parent.RunMetrics)
            .HasForeignKey("TrainingRun_Id");

        // TrainingRun has one or more RunParameters of type RunParameter
        modelBuilder.Entity<RunParameter>()
            .HasOne<TrainingRun>()
            .WithMany(parent => parent.RunParameters)
            .HasForeignKey("TrainingRun_Id");

        // RunMetric has one TrainingRun of type TrainingRun
        modelBuilder.Entity<RunMetric>()
            .HasOne(x => x.TrainingRun)
            .WithMany()
            .HasForeignKey("TrainingRun_Id");

        // RunMetric has one Metric of type Metric
        modelBuilder.Entity<RunMetric>()
            .HasOne(x => x.Metric)
            .WithMany()
            .HasForeignKey("Metric_Id");

        // RunMetric has one Dataset of type DataSet
        modelBuilder.Entity<RunMetric>()
            .HasOne(x => x.Dataset)
            .WithMany()
            .HasForeignKey("Dataset_Id");


        // RunParameter has one TrainingRun of type TrainingRun
        modelBuilder.Entity<RunParameter>()
            .HasOne(x => x.TrainingRun)
            .WithMany()
            .HasForeignKey("TrainingRun_Id");


        // Model_ has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<Model_>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("Workspace_Id");


        // Model_ has one or more Versions of type ModelVersion
        modelBuilder.Entity<ModelVersion>()
            .HasOne<Model_>()
            .WithMany(parent => parent.Versions)
            .HasForeignKey("Model__Id");

        // Model_ has one or more FeatureSets of type FeatureSet
        modelBuilder.Entity<FeatureSet>()
            .HasOne<Model_>()
            .WithMany(parent => parent.FeatureSets)
            .HasForeignKey("Model__Id");

        // Model_ has one or more Experiments of type Experiment
        modelBuilder.Entity<Experiment>()
            .HasOne<Model_>()
            .WithMany(parent => parent.Experiments)
            .HasForeignKey("Model__Id");

        // Model_ has one or more Tags of type Tag
        modelBuilder.Entity<Tag>()
            .HasOne<Model_>()
            .WithMany(parent => parent.Tags)
            .HasForeignKey("Model__Id");

        // ModelVersion has one Model_ of type Model_
        modelBuilder.Entity<ModelVersion>()
            .HasOne(x => x.Model_)
            .WithMany()
            .HasForeignKey("Model__Id");

        // ModelVersion has one TrainingRun of type TrainingRun
        modelBuilder.Entity<ModelVersion>()
            .HasOne(x => x.TrainingRun)
            .WithMany()
            .HasForeignKey("TrainingRun_Id");


        // ModelVersion has one or more EvaluationMetrics of type EvaluationMetric
        modelBuilder.Entity<EvaluationMetric>()
            .HasOne<ModelVersion>()
            .WithMany(parent => parent.EvaluationMetrics)
            .HasForeignKey("ModelVersion_Id");

        // ModelVersion has one or more Deployments of type InferenceEndpoint
        modelBuilder.Entity<InferenceEndpoint>()
            .HasOne<ModelVersion>()
            .WithMany(parent => parent.Deployments)
            .HasForeignKey("ModelVersion_Id");

        // ModelVersion has one or more FeatureSets of type FeatureSet
        modelBuilder.Entity<FeatureSet>()
            .HasOne<ModelVersion>()
            .WithMany(parent => parent.FeatureSets)
            .HasForeignKey("ModelVersion_Id");

        // ModelVersion has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<ModelVersion>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("ModelVersion_Id");

        // EvaluationMetric has one ModelVersion of type ModelVersion
        modelBuilder.Entity<EvaluationMetric>()
            .HasOne(x => x.ModelVersion)
            .WithMany()
            .HasForeignKey("ModelVersion_Id");

        // EvaluationMetric has one Metric of type Metric
        modelBuilder.Entity<EvaluationMetric>()
            .HasOne(x => x.Metric)
            .WithMany()
            .HasForeignKey("Metric_Id");

        // EvaluationMetric has one Dataset of type DataSet
        modelBuilder.Entity<EvaluationMetric>()
            .HasOne(x => x.Dataset)
            .WithMany()
            .HasForeignKey("Dataset_Id");


        // FeatureSet has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<FeatureSet>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("Workspace_Id");


        // FeatureSet has one or more Features of type Feature
        modelBuilder.Entity<Feature>()
            .HasOne<FeatureSet>()
            .WithMany(parent => parent.Features)
            .HasForeignKey("FeatureSet_Id");

        // FeatureSet has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<FeatureSet>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("FeatureSet_Id");

        // FeatureSet has one or more Models of type Model_
        modelBuilder.Entity<Model_>()
            .HasOne<FeatureSet>()
            .WithMany(parent => parent.Models)
            .HasForeignKey("FeatureSet_Id");

        // FeatureSet has one or more ModelVersions of type ModelVersion
        modelBuilder.Entity<ModelVersion>()
            .HasOne<FeatureSet>()
            .WithMany(parent => parent.ModelVersions)
            .HasForeignKey("FeatureSet_Id");

        // FeatureSet has one or more Tags of type Tag
        modelBuilder.Entity<Tag>()
            .HasOne<FeatureSet>()
            .WithMany(parent => parent.Tags)
            .HasForeignKey("FeatureSet_Id");

        // Feature has one FeatureSet of type FeatureSet
        modelBuilder.Entity<Feature>()
            .HasOne(x => x.FeatureSet)
            .WithMany()
            .HasForeignKey("FeatureSet_Id");


        // Feature has one or more SourceDatasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<Feature>()
            .WithMany(parent => parent.SourceDatasets)
            .HasForeignKey("Feature_Id");

        // Feature has one or more Models of type Model_
        modelBuilder.Entity<Model_>()
            .HasOne<Feature>()
            .WithMany(parent => parent.Models)
            .HasForeignKey("Feature_Id");

        // Feature has one or more TrainingRuns of type TrainingRun
        modelBuilder.Entity<TrainingRun>()
            .HasOne<Feature>()
            .WithMany(parent => parent.TrainingRuns)
            .HasForeignKey("Feature_Id");

        // InferenceEndpoint has one ModelVersion of type ModelVersion
        modelBuilder.Entity<InferenceEndpoint>()
            .HasOne(x => x.ModelVersion)
            .WithMany()
            .HasForeignKey("ModelVersion_Id");

        // InferenceEndpoint has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<InferenceEndpoint>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("Workspace_Id");


        // InferenceEndpoint has one or more Predictions of type Prediction
        modelBuilder.Entity<Prediction>()
            .HasOne<InferenceEndpoint>()
            .WithMany(parent => parent.Predictions)
            .HasForeignKey("InferenceEndpoint_Id");

        // Prediction has one Endpoint of type InferenceEndpoint
        modelBuilder.Entity<Prediction>()
            .HasOne(x => x.Endpoint)
            .WithMany()
            .HasForeignKey("Endpoint_Id");

        // Prediction has one ModelVersion of type ModelVersion
        modelBuilder.Entity<Prediction>()
            .HasOne(x => x.ModelVersion)
            .WithMany()
            .HasForeignKey("ModelVersion_Id");

        // Prediction has one Dataset of type DataSet
        modelBuilder.Entity<Prediction>()
            .HasOne(x => x.Dataset)
            .WithMany()
            .HasForeignKey("Dataset_Id");


        // Forecast has one ModelVersion of type ModelVersion
        modelBuilder.Entity<Forecast>()
            .HasOne(x => x.ModelVersion)
            .WithMany()
            .HasForeignKey("ModelVersion_Id");

        // Forecast has one TimeSeries of type TimeSeries
        modelBuilder.Entity<Forecast>()
            .HasOne(x => x.TimeSeries)
            .WithMany()
            .HasForeignKey("TimeSeries_Id");


        // Forecast has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<Forecast>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("Forecast_Id");


        // TimeSeries has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<TimeSeries>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("TimeSeries_Id");

        // TimeSeries has one or more Forecasts of type Forecast
        modelBuilder.Entity<Forecast>()
            .HasOne<TimeSeries>()
            .WithMany(parent => parent.Forecasts)
            .HasForeignKey("TimeSeries_Id");

        // TimeSeries has one or more Anomalies of type Anomaly
        modelBuilder.Entity<Anomaly>()
            .HasOne<TimeSeries>()
            .WithMany(parent => parent.Anomalies)
            .HasForeignKey("TimeSeries_Id");

        // Anomaly has one TimeSeries of type TimeSeries
        modelBuilder.Entity<Anomaly>()
            .HasOne(x => x.TimeSeries)
            .WithMany()
            .HasForeignKey("TimeSeries_Id");

        // Anomaly has one Alert of type Alert
        modelBuilder.Entity<Anomaly>()
            .HasOne(x => x.Alert)
            .WithMany()
            .HasForeignKey("Alert_Id");

        // Anomaly has one Dataset of type DataSet
        modelBuilder.Entity<Anomaly>()
            .HasOne(x => x.Dataset)
            .WithMany()
            .HasForeignKey("Dataset_Id");


        // QualityRule has one Dataset of type DataSet
        modelBuilder.Entity<QualityRule>()
            .HasOne(x => x.Dataset)
            .WithMany()
            .HasForeignKey("Dataset_Id");


        // QualityRule has one or more Checks of type QualityCheck
        modelBuilder.Entity<QualityCheck>()
            .HasOne<QualityRule>()
            .WithMany(parent => parent.Checks)
            .HasForeignKey("QualityRule_Id");

        // QualityCheck has one Rule of type QualityRule
        modelBuilder.Entity<QualityCheck>()
            .HasOne(x => x.Rule)
            .WithMany()
            .HasForeignKey("Rule_Id");

        // QualityCheck has one Dataset of type DataSet
        modelBuilder.Entity<QualityCheck>()
            .HasOne(x => x.Dataset)
            .WithMany()
            .HasForeignKey("Dataset_Id");


        // LineageNode has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<LineageNode>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("Workspace_Id");


        // LineageNode has one or more Inputs of type LineageNode
        modelBuilder.Entity<LineageNode>()
            .HasOne<LineageNode>()
            .WithMany(parent => parent.Inputs)
            .HasForeignKey("LineageNode_Id");

        // LineageNode has one or more Outputs of type LineageNode
        modelBuilder.Entity<LineageNode>()
            .HasOne<LineageNode>()
            .WithMany(parent => parent.Outputs)
            .HasForeignKey("LineageNode_Id");

        // LineageNode has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<LineageNode>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("LineageNode_Id");

        // LineageNode has one or more Models of type Model_
        modelBuilder.Entity<Model_>()
            .HasOne<LineageNode>()
            .WithMany(parent => parent.Models)
            .HasForeignKey("LineageNode_Id");

        // LineageNode has one or more Pipelines of type DataPipeline
        modelBuilder.Entity<DataPipeline>()
            .HasOne<LineageNode>()
            .WithMany(parent => parent.Pipelines)
            .HasForeignKey("LineageNode_Id");

        // LineageNode has one or more Dashboards of type Dashboard
        modelBuilder.Entity<Dashboard>()
            .HasOne<LineageNode>()
            .WithMany(parent => parent.Dashboards)
            .HasForeignKey("LineageNode_Id");

        // LineageNode has one or more Reports of type Report
        modelBuilder.Entity<Report>()
            .HasOne<LineageNode>()
            .WithMany(parent => parent.Reports)
            .HasForeignKey("LineageNode_Id");


        // Tag has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<Tag>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("Tag_Id");

        // Tag has one or more Models of type Model_
        modelBuilder.Entity<Model_>()
            .HasOne<Tag>()
            .WithMany(parent => parent.Models)
            .HasForeignKey("Tag_Id");

        // Tag has one or more ModelVersions of type ModelVersion
        modelBuilder.Entity<ModelVersion>()
            .HasOne<Tag>()
            .WithMany(parent => parent.ModelVersions)
            .HasForeignKey("Tag_Id");

        // Tag has one or more Dashboards of type Dashboard
        modelBuilder.Entity<Dashboard>()
            .HasOne<Tag>()
            .WithMany(parent => parent.Dashboards)
            .HasForeignKey("Tag_Id");

        // Tag has one or more Reports of type Report
        modelBuilder.Entity<Report>()
            .HasOne<Tag>()
            .WithMany(parent => parent.Reports)
            .HasForeignKey("Tag_Id");

        // Tag has one or more FeatureSets of type FeatureSet
        modelBuilder.Entity<FeatureSet>()
            .HasOne<Tag>()
            .WithMany(parent => parent.FeatureSets)
            .HasForeignKey("Tag_Id");

        // Tag has one or more Metrics of type Metric
        modelBuilder.Entity<Metric>()
            .HasOne<Tag>()
            .WithMany(parent => parent.Metrics)
            .HasForeignKey("Tag_Id");

        // AccessPolicy has one Workspace of type AnalyticsWorkspace
        modelBuilder.Entity<AccessPolicy>()
            .HasOne(x => x.Workspace)
            .WithMany()
            .HasForeignKey("Workspace_Id");


        // AccessPolicy has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<AccessPolicy>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("AccessPolicy_Id");

        // AccessPolicy has one or more Dashboards of type Dashboard
        modelBuilder.Entity<Dashboard>()
            .HasOne<AccessPolicy>()
            .WithMany(parent => parent.Dashboards)
            .HasForeignKey("AccessPolicy_Id");

        // AccessPolicy has one or more Reports of type Report
        modelBuilder.Entity<Report>()
            .HasOne<AccessPolicy>()
            .WithMany(parent => parent.Reports)
            .HasForeignKey("AccessPolicy_Id");

        // AccessPolicy has one or more Models of type Model_
        modelBuilder.Entity<Model_>()
            .HasOne<AccessPolicy>()
            .WithMany(parent => parent.Models)
            .HasForeignKey("AccessPolicy_Id");

        // AccessPolicy has one or more FeatureSets of type FeatureSet
        modelBuilder.Entity<FeatureSet>()
            .HasOne<AccessPolicy>()
            .WithMany(parent => parent.FeatureSets)
            .HasForeignKey("AccessPolicy_Id");

        // Alert has one Metric of type Metric
        modelBuilder.Entity<Alert>()
            .HasOne(x => x.Metric)
            .WithMany()
            .HasForeignKey("Metric_Id");

        // Alert has one Dashboard of type Dashboard
        modelBuilder.Entity<Alert>()
            .HasOne(x => x.Dashboard)
            .WithMany()
            .HasForeignKey("Dashboard_Id");

        // Alert has one Dataset of type DataSet
        modelBuilder.Entity<Alert>()
            .HasOne(x => x.Dataset)
            .WithMany()
            .HasForeignKey("Dataset_Id");

        // Alert has one Rule of type QualityRule
        modelBuilder.Entity<Alert>()
            .HasOne(x => x.Rule)
            .WithMany()
            .HasForeignKey("Rule_Id");


        // Alert has one or more Anomalies of type Anomaly
        modelBuilder.Entity<Anomaly>()
            .HasOne<Alert>()
            .WithMany(parent => parent.Anomalies)
            .HasForeignKey("Alert_Id");

        // Alert has one or more Subscribers of type Subscriber
        modelBuilder.Entity<Subscriber>()
            .HasOne<Alert>()
            .WithMany(parent => parent.Subscribers)
            .HasForeignKey("Alert_Id");


        // Subscriber has one or more Alerts of type Alert
        modelBuilder.Entity<Alert>()
            .HasOne<Subscriber>()
            .WithMany(parent => parent.Alerts)
            .HasForeignKey("Subscriber_Id");


        // BusinessGlossaryTerm has one or more RelatedTerms of type BusinessGlossaryTerm
        modelBuilder.Entity<BusinessGlossaryTerm>()
            .HasOne<BusinessGlossaryTerm>()
            .WithMany(parent => parent.RelatedTerms)
            .HasForeignKey("BusinessGlossaryTerm_Id");

        // BusinessGlossaryTerm has one or more Metrics of type Metric
        modelBuilder.Entity<Metric>()
            .HasOne<BusinessGlossaryTerm>()
            .WithMany(parent => parent.Metrics)
            .HasForeignKey("BusinessGlossaryTerm_Id");

        // BusinessGlossaryTerm has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<BusinessGlossaryTerm>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("BusinessGlossaryTerm_Id");

        // BusinessGlossaryTerm has one or more Dimensions of type Dimension
        modelBuilder.Entity<Dimension>()
            .HasOne<BusinessGlossaryTerm>()
            .WithMany(parent => parent.Dimensions)
            .HasForeignKey("BusinessGlossaryTerm_Id");

        // BusinessGlossaryTerm has one or more Measures of type Measure
        modelBuilder.Entity<Measure>()
            .HasOne<BusinessGlossaryTerm>()
            .WithMany(parent => parent.Measures)
            .HasForeignKey("BusinessGlossaryTerm_Id");


        // RecommendationScenario has one or more Models of type Model_
        modelBuilder.Entity<Model_>()
            .HasOne<RecommendationScenario>()
            .WithMany(parent => parent.Models)
            .HasForeignKey("RecommendationScenario_Id");

        // RecommendationScenario has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<RecommendationScenario>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("RecommendationScenario_Id");

        // RecommendationScenario has one or more Experiments of type Experiment
        modelBuilder.Entity<Experiment>()
            .HasOne<RecommendationScenario>()
            .WithMany(parent => parent.Experiments)
            .HasForeignKey("RecommendationScenario_Id");

        // RecommendationScenario has one or more Alerts of type Alert
        modelBuilder.Entity<Alert>()
            .HasOne<RecommendationScenario>()
            .WithMany(parent => parent.Alerts)
            .HasForeignKey("RecommendationScenario_Id");


        // FraudScenario has one or more Models of type Model_
        modelBuilder.Entity<Model_>()
            .HasOne<FraudScenario>()
            .WithMany(parent => parent.Models)
            .HasForeignKey("FraudScenario_Id");

        // FraudScenario has one or more Datasets of type DataSet
        modelBuilder.Entity<DataSet>()
            .HasOne<FraudScenario>()
            .WithMany(parent => parent.Datasets)
            .HasForeignKey("FraudScenario_Id");

        // FraudScenario has one or more Alerts of type Alert
        modelBuilder.Entity<Alert>()
            .HasOne<FraudScenario>()
            .WithMany(parent => parent.Alerts)
            .HasForeignKey("FraudScenario_Id");

        // FraudScenario has one or more Signals of type FraudSignal
        modelBuilder.Entity<FraudSignal>()
            .HasOne<FraudScenario>()
            .WithMany(parent => parent.Signals)
            .HasForeignKey("FraudScenario_Id");

        // FraudSignal has one Scenario of type FraudScenario
        modelBuilder.Entity<FraudSignal>()
            .HasOne(x => x.Scenario)
            .WithMany()
            .HasForeignKey("Scenario_Id");

        // FraudSignal has one Dataset of type DataSet
        modelBuilder.Entity<FraudSignal>()
            .HasOne(x => x.Dataset)
            .WithMany()
            .HasForeignKey("Dataset_Id");

        // FraudSignal has one ModelVersion of type ModelVersion
        modelBuilder.Entity<FraudSignal>()
            .HasOne(x => x.ModelVersion)
            .WithMany()
            .HasForeignKey("ModelVersion_Id");


    }
}

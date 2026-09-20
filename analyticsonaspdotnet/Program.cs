using analyticsonaspdotnet.Api;
using analyticsonaspdotnet.Persistence;
using analyticsonaspdotnet.Service;

using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddOpenApi();
builder.Services.AddHealthChecks()
    .AddDbContextCheck<ApplicationDbContext>();


var dbEngineEnvironment = builder.Configuration["DB_TYPE"];

string dbEngine;
string dbUserName;
string dbPassword;
string dbName;
string dbHost;
string dbPort;

if (string.IsNullOrWhiteSpace(dbEngineEnvironment))
{
    // Generation-time configuration
    dbEngine = "mysql";
    dbUserName = "postgres";
    dbPassword = "no_password";
    dbName = "testDb";
    dbHost = "localhost";
    dbPort = "5432";
}
else
{
    // Runtime environment configuration
    dbEngine = dbEngineEnvironment;
    dbUserName = builder.Configuration["DB_USER_NAME"]
        ?? throw new InvalidOperationException("DB_USER_NAME is required when DB_ENGINE is provided.");

    dbPassword = builder.Configuration["DB_PASSWORD"]
        ?? throw new InvalidOperationException("DB_PASSWORD is required when DB_ENGINE is provided.");

    dbName = builder.Configuration["DB_NAME"]
        ?? throw new InvalidOperationException("DB_NAME is required when DB_ENGINE is provided.");

    dbHost = builder.Configuration["DB_HOST"]
        ?? throw new InvalidOperationException("DB_HOST is required when DB_ENGINE is provided.");

    dbPort = builder.Configuration["DB_PORT"]
        ?? throw new InvalidOperationException("DB_PORT is required when DB_ENGINE is provided.");
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString =
        $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUserName};Password={dbPassword}";

    if (dbEngine.Equals("mysql", StringComparison.OrdinalIgnoreCase))
    {
        options.UseMySQL(connectionString);
    }
    else if (dbEngine.Equals("mariadb", StringComparison.OrdinalIgnoreCase))
    {
        options.UseMySQL(connectionString);
    }
    else if (dbEngine.Equals("sqlite", StringComparison.OrdinalIgnoreCase))
    {
        options.UseSqlite(connectionString);
    }
    else if (dbEngine.Equals("sqlserver", StringComparison.OrdinalIgnoreCase) ||
             dbEngine.Equals("azuresql", StringComparison.OrdinalIgnoreCase))
    {
        options.UseSqlServer(connectionString);
    }
    else if (dbEngine.Equals("oracle", StringComparison.OrdinalIgnoreCase))
    {
        options.UseOracle(connectionString);
    }
    else if (dbEngine.Equals("mongodb", StringComparison.OrdinalIgnoreCase))
    {
        options.UseMongoDB(connectionString);
    }
    else if (dbEngine.Equals("inmemory", StringComparison.OrdinalIgnoreCase))
    {
        options.UseInMemoryDatabase("analyticsonaspdotnet");
    }
    else if (dbEngine.Equals("cosmosdb", StringComparison.OrdinalIgnoreCase))
    {
        var cosmosEndpoint = builder.Configuration["DB_ENDPOINT"]
            ?? throw new InvalidOperationException(
                "DB_ENDPOINT is required for Cosmos DB.");

        var cosmosKey = builder.Configuration["DB_KEY"]
            ?? throw new InvalidOperationException(
                "DB_KEY is required for Cosmos DB.");

        options.UseCosmos(
            cosmosEndpoint,
            cosmosKey,
            dbName);
    }
    else if (dbEngine.Equals("postgres", StringComparison.OrdinalIgnoreCase))
    {
        options.UseNpgsql(connectionString);
    }
    else
    {
        throw new InvalidOperationException(
            "Unsupported or missing database engine configuration.");
    }
    // etc.
});

builder.Services.AddScoped<IAnalyticsWorkspaceRepository, AnalyticsWorkspaceRepository>();
builder.Services.AddScoped<IDataSourceRepository, DataSourceRepository>();
builder.Services.AddScoped<IDataSetRepository, DataSetRepository>();
builder.Services.AddScoped<IDataPipelineRepository, DataPipelineRepository>();
builder.Services.AddScoped<IDataTaskRepository, DataTaskRepository>();
builder.Services.AddScoped<ISemanticModelRepository, SemanticModelRepository>();
builder.Services.AddScoped<IDimensionRepository, DimensionRepository>();
builder.Services.AddScoped<IMeasureRepository, MeasureRepository>();
builder.Services.AddScoped<IMetricRepository, MetricRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
builder.Services.AddScoped<IVisualizationRepository, VisualizationRepository>();
builder.Services.AddScoped<INotebookRepository, NotebookRepository>();
builder.Services.AddScoped<IBIQueryRepository, BIQueryRepository>();
builder.Services.AddScoped<IExperimentRepository, ExperimentRepository>();
builder.Services.AddScoped<ITrainingRunRepository, TrainingRunRepository>();
builder.Services.AddScoped<IRunMetricRepository, RunMetricRepository>();
builder.Services.AddScoped<IRunParameterRepository, RunParameterRepository>();
builder.Services.AddScoped<IModelRepository, ModelRepository>();
builder.Services.AddScoped<IModelVersionRepository, ModelVersionRepository>();
builder.Services.AddScoped<IEvaluationMetricRepository, EvaluationMetricRepository>();
builder.Services.AddScoped<IFeatureSetRepository, FeatureSetRepository>();
builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();
builder.Services.AddScoped<IInferenceEndpointRepository, InferenceEndpointRepository>();
builder.Services.AddScoped<IPredictionRepository, PredictionRepository>();
builder.Services.AddScoped<IForecastRepository, ForecastRepository>();
builder.Services.AddScoped<ITimeSeriesRepository, TimeSeriesRepository>();
builder.Services.AddScoped<IAnomalyRepository, AnomalyRepository>();
builder.Services.AddScoped<IQualityRuleRepository, QualityRuleRepository>();
builder.Services.AddScoped<IQualityCheckRepository, QualityCheckRepository>();
builder.Services.AddScoped<ILineageNodeRepository, LineageNodeRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IAccessPolicyRepository, AccessPolicyRepository>();
builder.Services.AddScoped<IAlertRepository, AlertRepository>();
builder.Services.AddScoped<ISubscriberRepository, SubscriberRepository>();
builder.Services.AddScoped<IBusinessGlossaryTermRepository, BusinessGlossaryTermRepository>();
builder.Services.AddScoped<IRecommendationScenarioRepository, RecommendationScenarioRepository>();
builder.Services.AddScoped<IFraudScenarioRepository, FraudScenarioRepository>();
builder.Services.AddScoped<IFraudSignalRepository, FraudSignalRepository>();

builder.Services.AddScoped<IAnalyticsWorkspaceService, AnalyticsWorkspaceService>();
builder.Services.AddScoped<IDataSourceService, DataSourceService>();
builder.Services.AddScoped<IDataSetService, DataSetService>();
builder.Services.AddScoped<IDataPipelineService, DataPipelineService>();
builder.Services.AddScoped<IDataTaskService, DataTaskService>();
builder.Services.AddScoped<ISemanticModelService, SemanticModelService>();
builder.Services.AddScoped<IDimensionService, DimensionService>();
builder.Services.AddScoped<IMeasureService, MeasureService>();
builder.Services.AddScoped<IMetricService, MetricService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IVisualizationService, VisualizationService>();
builder.Services.AddScoped<INotebookService, NotebookService>();
builder.Services.AddScoped<IBIQueryService, BIQueryService>();
builder.Services.AddScoped<IExperimentService, ExperimentService>();
builder.Services.AddScoped<ITrainingRunService, TrainingRunService>();
builder.Services.AddScoped<IRunMetricService, RunMetricService>();
builder.Services.AddScoped<IRunParameterService, RunParameterService>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<IModelVersionService, ModelVersionService>();
builder.Services.AddScoped<IEvaluationMetricService, EvaluationMetricService>();
builder.Services.AddScoped<IFeatureSetService, FeatureSetService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<IInferenceEndpointService, InferenceEndpointService>();
builder.Services.AddScoped<IPredictionService, PredictionService>();
builder.Services.AddScoped<IForecastService, ForecastService>();
builder.Services.AddScoped<ITimeSeriesService, TimeSeriesService>();
builder.Services.AddScoped<IAnomalyService, AnomalyService>();
builder.Services.AddScoped<IQualityRuleService, QualityRuleService>();
builder.Services.AddScoped<IQualityCheckService, QualityCheckService>();
builder.Services.AddScoped<ILineageNodeService, LineageNodeService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IAccessPolicyService, AccessPolicyService>();
builder.Services.AddScoped<IAlertService, AlertService>();
builder.Services.AddScoped<ISubscriberService, SubscriberService>();
builder.Services.AddScoped<IBusinessGlossaryTermService, BusinessGlossaryTermService>();
builder.Services.AddScoped<IRecommendationScenarioService, RecommendationScenarioService>();
builder.Services.AddScoped<IFraudScenarioService, FraudScenarioService>();
builder.Services.AddScoped<IFraudSignalService, FraudSignalService>();

var app = builder.Build();

// Health endpoint
app.MapHealthChecks("/health");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    // Testing uses a shared SQLite file; wipe it so unique indexes (e.g. email) don't fail on re-runs.
    if (app.Environment.IsEnvironment("Testing"))
    {
        db.Database.EnsureDeleted();
    }

    // EnsureCreated does not alter an existing schema. If you changed relationships locally,
    // recreate the MySQL database (docker compose down -v && docker compose up -d).
    db.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapAnalyticsWorkspaceEndpoints();
app.MapDataSourceEndpoints();
app.MapDataSetEndpoints();
app.MapDataPipelineEndpoints();
app.MapDataTaskEndpoints();
app.MapSemanticModelEndpoints();
app.MapDimensionEndpoints();
app.MapMeasureEndpoints();
app.MapMetricEndpoints();
app.MapReportEndpoints();
app.MapDashboardEndpoints();
app.MapVisualizationEndpoints();
app.MapNotebookEndpoints();
app.MapBIQueryEndpoints();
app.MapExperimentEndpoints();
app.MapTrainingRunEndpoints();
app.MapRunMetricEndpoints();
app.MapRunParameterEndpoints();
app.MapModelEndpoints();
app.MapModelVersionEndpoints();
app.MapEvaluationMetricEndpoints();
app.MapFeatureSetEndpoints();
app.MapFeatureEndpoints();
app.MapInferenceEndpointEndpoints();
app.MapPredictionEndpoints();
app.MapForecastEndpoints();
app.MapTimeSeriesEndpoints();
app.MapAnomalyEndpoints();
app.MapQualityRuleEndpoints();
app.MapQualityCheckEndpoints();
app.MapLineageNodeEndpoints();
app.MapTagEndpoints();
app.MapAccessPolicyEndpoints();
app.MapAlertEndpoints();
app.MapSubscriberEndpoints();
app.MapBusinessGlossaryTermEndpoints();
app.MapRecommendationScenarioEndpoints();
app.MapFraudScenarioEndpoints();
app.MapFraudSignalEndpoints();

app.Run();

public partial class Program { }


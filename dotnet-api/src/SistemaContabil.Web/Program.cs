using Microsoft.OpenApi.Models;
using SistemaContabil.Application.Extensions;
using SistemaContabil.Infrastructure.Extensions;
using SistemaContabil.Web.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configuração do Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/sistema-contabil-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllers();

// Configuração do Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Sistema Contábil API",
        Version = "v1",
        Description = "API para sistema contábil com Oracle Database",
        Contact = new OpenApiContact
        {
            Name = "FIAP - Sistema Contábil",
            Email = "contato@fiap.com.br"
        }
    });

    // Incluir comentários XML
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

// Configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Configuração de serviços das camadas
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

// Configuração de validação
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Swagger sempre disponível para facilitar testes
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sistema Contábil API v1");
    c.RoutePrefix = "swagger"; // Swagger UI em /swagger
    c.DisplayRequestDuration();
    c.EnableDeepLinking();
    c.EnableFilter();
    c.ShowExtensions();
});

// Middleware de tratamento de erros
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Middleware de logging de requisições
app.UseMiddleware<RequestLoggingMiddleware>();

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Health check endpoint
app.MapGet("/health", () => Results.Ok(new { Status = "Healthy", Timestamp = DateTime.UtcNow }))
    .WithName("HealthCheck")
    .WithTags("Health");

// Test endpoint
app.MapGet("/", () => Results.Ok(new { 
    Message = "Sistema Contábil API está funcionando!", 
    Swagger = "/swagger",
    Health = "/health",
    Timestamp = DateTime.UtcNow 
}))
    .WithName("Root")
    .WithTags("Test");

try
{
    Log.Information("Iniciando Sistema Contábil API");
    Log.Information("Swagger disponível em: http://localhost:5000/swagger");
    Log.Information("Health check disponível em: http://localhost:5000/health");
    Log.Information("Teste de conexão disponível em: http://localhost:5000/api/Test/connection");
    
    // Testar conexão Oracle na inicialização
    Log.Information("Testando conexões Oracle...");
    var workingConnection = await SistemaContabil.Infrastructure.Configuration.ConnectionTester.TestConnectionsAsync();
    
    if (workingConnection != null)
    {
        Log.Information("✅ Conexão Oracle funcionando!");
    }
    else
    {
        Log.Warning("⚠️ Nenhuma conexão Oracle funcionou. Verifique as configurações.");
    }
    
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Aplicação encerrada inesperadamente");
}
finally
{
    Log.CloseAndFlush();
}

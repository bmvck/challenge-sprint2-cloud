# Guia de Desenvolvimento - Sistema Contábil

## 🚀 Início Rápido

### 1. Configuração do Ambiente

```bash
# Clone o repositório
git clone <repository-url>
cd SistemaContabil

# Restaure as dependências
dotnet restore

# Compile o projeto
dotnet build

# Execute a aplicação
cd src/SistemaContabil.Web
dotnet run
```

### 2. Configuração do Banco de Dados

```sql
-- Execute no Oracle SQL Developer:
create-complete-database.sql
```

### 3. Teste a Aplicação

```bash
# Execute o teste completo:
test-application.bat
```

### 4. Acesse a Documentação

- **Swagger UI**: `http://localhost:5000/swagger`
- **Health Check**: `http://localhost:5000/health`
- **Teste de Conexão**: `http://localhost:5000/api/Test/connection`
- **Listagem de Conexões**: `http://localhost:5000/api/Test/connections`

## 🏗️ Arquitetura do Projeto

### Estrutura de Camadas

```
src/
├── SistemaContabil.Domain/          # Camada de Domínio
│   ├── Entities/                   # Entidades de negócio
│   ├── Interfaces/                 # Contratos/Interfaces
│   └── Services/                   # Serviços de domínio
├── SistemaContabil.Application/     # Camada de Aplicação
│   ├── DTOs/                       # Data Transfer Objects
│   ├── Services/                   # Serviços de aplicação
│   ├── Validators/                 # Validações FluentValidation
│   └── Mappings/                    # Mapeamentos AutoMapper
├── SistemaContabil.Infrastructure/  # Camada de Infraestrutura
│   ├── Data/                       # DbContext EF Core
│   ├── Repositories/               # Implementações dos repositórios
│   └── Configuration/               # Configurações
└── SistemaContabil.Web/            # Camada Web
    ├── Controllers/                # Controllers da API
    ├── Middleware/                 # Middlewares customizados
    └── Program.cs                  # Ponto de entrada
```

## 🔧 Padrões de Design

### 1. Repository Pattern
```csharp
public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
```

### 2. Service Layer Pattern
```csharp
public interface ICentroCustoService
{
    Task<CentroCusto> CriarAsync(string nome);
    Task<CentroCusto> AtualizarAsync(int id, string nome);
    Task<bool> RemoverAsync(int id);
}
```

### 3. DTO Pattern
```csharp
public class CentroCustoDto
{
    public int IdCentroCusto { get; set; }
    public string NomeCentroCusto { get; set; } = string.Empty;
}
```

### 4. Dependency Injection
```csharp
// Registro de serviços
services.AddScoped<ICentroCustoService, CentroCustoService>();
services.AddScoped<ICentroCustoRepository, CentroCustoRepository>();
```

## 📝 Convenções de Código

### 1. Nomenclatura

#### Entidades
```csharp
public class CentroCusto
{
    public int IdCentroCusto { get; set; }
    public string NomeCentroCusto { get; set; } = string.Empty;
}
```

#### DTOs
```csharp
public class CentroCustoDto
{
    public int IdCentroCusto { get; set; }
    public string NomeCentroCusto { get; set; } = string.Empty;
}
```

#### Controllers
```csharp
[ApiController]
[Route("api/[controller]")]
public class CentroCustoController : ControllerBase
{
    // Métodos HTTP
}
```

### 2. Tratamento de Erros

```csharp
try
{
    var resultado = await _service.OperacaoAsync();
    return Ok(resultado);
}
catch (ArgumentException ex)
{
    _logger.LogWarning(ex, "Dados inválidos");
    return BadRequest(ex.Message);
}
catch (Exception ex)
{
    _logger.LogError(ex, "Erro interno");
    return StatusCode(500, "Erro interno do servidor");
}
```

### 3. Logging

```csharp
_logger.LogInformation("Operação iniciada para ID {Id}", id);
_logger.LogWarning("Dados inválidos recebidos: {Data}", data);
_logger.LogError(ex, "Erro ao processar operação {Id}", id);
```

## 🧪 Testes

### 1. Testes Unitários

```csharp
[Test]
public async Task CriarCentroCusto_ComNomeValido_DeveRetornarSucesso()
{
    // Arrange
    var nome = "Vendas";
    var expected = new CentroCusto { NomeCentroCusto = nome };
    
    // Act
    var result = await _service.CriarAsync(nome);
    
    // Assert
    Assert.That(result.NomeCentroCusto, Is.EqualTo(nome));
}
```

### 2. Testes de Integração

```csharp
[Test]
public async Task Post_CentroCusto_DeveRetornarCreated()
{
    // Arrange
    var dto = new CriarCentroCustoDto { NomeCentroCusto = "Vendas" };
    
    // Act
    var response = await _client.PostAsJsonAsync("/api/CentroCusto", dto);
    
    // Assert
    Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
}
```

## 🔍 Debugging

### 1. Logs Estruturados

```csharp
// Configuração do Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/sistema-contabil-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
```

### 2. Health Checks

```csharp
app.MapGet("/health", () => Results.Ok(new { 
    Status = "Healthy", 
    Timestamp = DateTime.UtcNow 
}));
```

### 3. Middleware de Logging

```csharp
public class RequestLoggingMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        _logger.LogInformation("Request: {Method} {Path}", 
            context.Request.Method, 
            context.Request.Path);
        
        await next(context);
    }
}
```

## 📦 Dependências

### Principais Pacotes

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.0" />
<PackageReference Include="Oracle.EntityFrameworkCore" Version="8.21.121" />
<PackageReference Include="AutoMapper" Version="12.0.1" />
<PackageReference Include="FluentValidation" Version="11.8.1" />
<PackageReference Include="Serilog.AspNetCore" Version="8.0.0" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="6.5.0" />
```

## 🧪 Scripts de Teste Disponíveis

### 1. Teste Completo da Aplicação
```bash
test-application.bat
```
- Testa conexão Oracle
- Testa health check
- Testa todos os endpoints (GET/POST)
- Valida funcionalidade completa

## 🚀 Deploy

### 1. Build de Produção

```bash
dotnet publish -c Release -o ./publish
```

### 2. Docker (Opcional)

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY ./publish .
ENTRYPOINT ["dotnet", "SistemaContabil.Web.dll"]
```

### 3. Configuração de Produção

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=prod-server:1521/PROD;User Id=prod_user;Password=prod_pass;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  }
}
```

## 📚 Recursos Adicionais

### 1. Documentação da API
- Swagger UI: `/swagger`
- OpenAPI JSON: `/swagger/v1/swagger.json`

### 2. Monitoramento
- Health Check: `/health`
- Logs: `logs/sistema-contabil-{date}.txt`

### 3. Configuração
- `appsettings.json`: Configurações gerais
- `appsettings.Development.json`: Configurações de desenvolvimento
- `appsettings.Production.json`: Configurações de produção

## 🔧 Scripts SQL Disponíveis

### 1. Scripts de Criação
- `create-complete-database.sql` - Criação completa do banco

### 2. Scripts de Verificação
- `verify-database.sql` - Verificação do banco
- Teste de inserção e validação

## 🎯 Status do Projeto

### ✅ Funcionalidades Implementadas
- [x] Estrutura Clean Architecture
- [x] Entidades de domínio
- [x] Repositórios com EF Core
- [x] Controllers da API
- [x] Validações FluentValidation
- [x] Mapeamento AutoMapper
- [x] Logging Serilog
- [x] Swagger UI
- [x] Health Checks
- [x] Conexão Oracle
- [x] Scripts de teste
- [x] Documentação completa

### 🚀 Sistema Funcionando
- ✅ **Conexão Oracle**: Funcionando perfeitamente
- ✅ **Centro de Custo**: CRUD completo
- ✅ **Conta**: CRUD completo  
- ✅ **Registro Contábil**: CRUD completo
- ✅ **Swagger**: Interface funcionando
- ✅ **Logs**: Monitoramento ativo
- ✅ **Health Check**: Disponível
- ✅ **Testes**: Scripts funcionando

# Configuração do Banco de Dados Oracle

## 📋 Pré-requisitos

- Oracle Database XE ou superior
- Acesso ao banco Oracle FIAP (se disponível)
- Credenciais de acesso

## 🔧 Configuração

### 1. String de Conexão

A string de conexão está configurada em `src/SistemaContabil.Infrastructure/Configuration/DatabaseConfiguration.cs`:

```csharp
public static readonly string[] ConnectionStrings = new[]
{
    // Opção 1: Service Name /orcl (FORMATO CORRETO)
    "Data Source=oracle.fiap.com.br:1521/orcl;User Id=rm560088;Password=061005;",
    
    // Opção 2: Service Name /ORCL (maiúsculo)
    "Data Source=oracle.fiap.com.br:1521/ORCL;User Id=rm560088;Password=061005;",
    
    // Opção 3: Service Name /orcl com timeout
    "Data Source=oracle.fiap.com.br:1521/orcl;User Id=rm560088;Password=061005;Connection Timeout=30;",
    
    // Opção 4: Service Name /ORCL com timeout
    "Data Source=oracle.fiap.com.br:1521/ORCL;User Id=rm560088;Password=061005;Connection Timeout=30;",
    
    // Opção 5: Formato TNS (se disponível)
    "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));User Id=rm560088;Password=061005;",
    
    // Opção 6: Formato TNS com ORCL
    "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));User Id=rm560088;Password=061005;"
};
```

### 2. Configuração Local (Desenvolvimento)

Para desenvolvimento local, edite o arquivo `src/SistemaContabil.Web/appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=localhost:1521/XE;User Id=seu_usuario;Password=sua_senha;"
  }
}
```

### 3. Scripts SQL Disponíveis

#### Script Principal (create-complete-database.sql)
Script completo para criação do banco com:
- Criação de tabelas com colunas de auditoria
- Sequences para auto-incremento
- Triggers para auto-incremento e atualização de datas
- Dados de exemplo
- Verificação de integridade

#### Script de Verificação (verify-database.sql)
Script para verificar se o banco foi criado corretamente:
- Verificação de tabelas
- Verificação de constraints
- Verificação de sequences
- Verificação de triggers
- Teste de inserção


### 4. Execução dos Scripts

#### 1. Execute o Script Principal
```sql
-- No Oracle SQL Developer, execute:
create-complete-database.sql
```

#### 2. Verifique se Tudo Foi Criado
```sql
-- Execute para verificar:
verify-database.sql
```

#### 3. Teste a Aplicação
```powershell
# Execute o teste completo:
test-application.bat
```

## 🔍 Troubleshooting

### Erro de Conexão
```
Oracle.ManagedDataAccess.Client.OracleException: ORA-12541: TNS:no listener
```
**Solução**: Verifique se o Oracle está rodando e acessível

### Erro de Autenticação
```
Oracle.ManagedDataAccess.Client.OracleException: ORA-01017: invalid username/password
```
**Solução**: Verifique as credenciais na string de conexão

### Erro de Schema
```
Oracle.ManagedDataAccess.Client.OracleException: ORA-00942: table or view does not exist
```
**Solução**: Execute o script SQL para criar as tabelas

### Erro de Permissão
```
Oracle.ManagedDataAccess.Client.OracleException: ORA-00942: insufficient privileges
```
**Solução**: Verifique se o usuário tem permissões para criar tabelas

### Erro de Conta Bloqueada
```
Oracle.ManagedDataAccess.Client.OracleException: ORA-28000: The account is locked
```
**Solução**: Contate o suporte FIAP para desbloquear a conta ou execute:
```sql
ALTER USER rm560088 ACCOUNT UNLOCK;
```

### Erro de Sintaxe de Conexão
```
ORA-12550: Sessão de Rede: Erro de sintaxe de parse de endereço de conexão
```
**Solução**: Use o formato Service Name (`/orcl`) em vez de SID (`:orcl`)


## 📊 Monitoramento

### Logs de Conexão
Os logs de conexão são registrados pelo Serilog:
- Console: Logs em tempo real
- Arquivo: `logs/sistema-contabil-{date}.txt`

### Health Check
Endpoint para verificar a saúde da aplicação:
```
GET /health
```

Resposta esperada:
```json
{
  "status": "Healthy",
  "timestamp": "2025-01-05T20:45:47.123Z"
}
```

## 🔧 Configurações Avançadas

### Timeout de Conexão
```csharp
oracleOptions.CommandTimeout(30); // 30 segundos
```

### Pool de Conexões
```csharp
// Configuração automática do EF Core
options.UseOracle(ConnectionString, oracleOptions =>
{
    oracleOptions.CommandTimeout(30);
});
```

### Logging de SQL
```csharp
// Apenas em desenvolvimento
options.EnableSensitiveDataLogging();
options.EnableDetailedErrors();
```

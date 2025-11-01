# Sistema Contábil - Oracle FIAP Challenge

## 📋 Visão Geral

Sistema Contábil desenvolvido em .NET 8 com arquitetura Clean Architecture, utilizando Oracle Database como banco de dados principal. O sistema permite o gerenciamento de centros de custo, contas contábeis e registros contábeis com uma API REST completa.

## 🏗️ Arquitetura

### Clean Architecture
- **Domain Layer**: Entidades, interfaces e regras de negócio
- **Application Layer**: DTOs, serviços de aplicação e validações
- **Infrastructure Layer**: Repositórios, Entity Framework Core e Oracle
- **Web Layer**: Controllers, middleware e configurações

### Tecnologias Utilizadas
- **.NET 8** - Framework principal
- **Oracle Database** - Banco de dados
- **Entity Framework Core** - ORM
- **AutoMapper** - Mapeamento de objetos
- **FluentValidation** - Validações
- **Serilog** - Logging
- **Swagger/OpenAPI** - Documentação da API

## 🎯 Requisitos Funcionais

### RF001 - Gerenciamento de Centros de Custo
- **RF001.1**: Criar centro de custo com nome único
- **RF001.2**: Listar todos os centros de custo
- **RF001.3**: Buscar centro de custo por ID
- **RF001.4**: Buscar centros de custo por nome (busca parcial)
- **RF001.5**: Atualizar nome do centro de custo
- **RF001.6**: Remover centro de custo (apenas se não tiver registros)
- **RF001.7**: Listar centros de custo com registros contábeis
- **RF001.8**: Validar se centro de custo pode ser removido

### RF002 - Gerenciamento de Contas Contábeis
- **RF002.1**: Criar conta com nome único e tipo (Débito/Crédito)
- **RF002.2**: Listar todas as contas
- **RF002.3**: Buscar conta por ID
- **RF002.4**: Buscar contas por nome (busca parcial)
- **RF002.5**: Buscar contas por tipo (Débito ou Crédito)
- **RF002.6**: Atualizar nome e tipo da conta
- **RF002.7**: Remover conta (apenas se não tiver registros)
- **RF002.8**: Listar contas com registros contábeis
- **RF002.9**: Validar se conta pode ser removida

### RF003 - Gerenciamento de Registros Contábeis
- **RF003.1**: Criar registro contábil com valor, conta e centro de custo
- **RF003.2**: Listar todos os registros contábeis
- **RF003.3**: Buscar registro contábil por ID
- **RF003.4**: Buscar registros por conta
- **RF003.5**: Buscar registros por centro de custo
- **RF003.6**: Buscar registros por período (data início/fim)
- **RF003.7**: Buscar registros por faixa de valor
- **RF003.8**: Atualizar registro contábil
- **RF003.9**: Remover registro contábil
- **RF003.10**: Calcular total por conta
- **RF003.11**: Calcular total por centro de custo
- **RF003.12**: Calcular total por período

### RF004 - Validações de Negócio
- **RF004.1**: Nome do centro de custo obrigatório e único
- **RF004.2**: Nome da conta obrigatório e único
- **RF004.3**: Tipo da conta deve ser 'D' (Débito) ou 'C' (Crédito)
- **RF004.4**: Valor do registro deve ser maior que zero
- **RF004.5**: Conta e centro de custo devem existir
- **RF004.6**: Não permitir remoção de entidades com registros associados

### RF005 - Relatórios e Consultas
- **RF005.1**: Relatório de registros por conta
- **RF005.2**: Relatório de registros por centro de custo
- **RF005.3**: Relatório de registros por período
- **RF005.4**: Relatório de totais por conta
- **RF005.5**: Relatório de totais por centro de custo
- **RF005.6**: Relatório de totais por período

## 🔧 Requisitos Não Funcionais

### RNF001 - Performance
- **RNF001.1**: Tempo de resposta da API < 2 segundos
- **RNF001.2**: Suporte a 100 usuários simultâneos
- **RNF001.3**: Consultas otimizadas com índices no banco
- **RNF001.4**: Cache de consultas frequentes

### RNF002 - Segurança
- **RNF002.1**: Validação de entrada em todas as APIs
- **RNF002.2**: Sanitização de dados de entrada
- **RNF002.3**: Logs de auditoria para operações críticas
- **RNF002.4**: Tratamento seguro de exceções

### RNF003 - Escalabilidade
- **RNF003.1**: Arquitetura preparada para microserviços
- **RNF003.2**: Separação clara de responsabilidades
- **RNF003.3**: Interface de repositório para troca de banco
- **RNF003.4**: Configuração via appsettings

### RNF004 - Manutenibilidade
- **RNF004.1**: Código documentado e comentado
- **RNF004.2**: Testes unitários (cobertura > 80%)
- **RNF004.3**: Padrões de nomenclatura consistentes
- **RNF004.4**: Separação de concerns

### RNF005 - Disponibilidade
- **RNF005.1**: Health check endpoint
- **RNF005.2**: Logs estruturados para monitoramento
- **RNF005.3**: Tratamento de falhas de conexão
- **RNF005.4**: Retry automático para operações críticas

### RNF006 - Usabilidade
- **RNF006.1**: API RESTful com padrões HTTP
- **RNF006.2**: Documentação Swagger/OpenAPI
- **RNF006.3**: Mensagens de erro claras
- **RNF006.4**: Códigos de status HTTP apropriados

### RNF007 - Integração
- **RNF007.1**: Suporte a CORS para desenvolvimento
- **RNF007.2**: Serialização JSON padronizada
- **RNF007.3**: Versionamento da API
- **RNF007.4**: Middleware de logging de requisições

## 🚀 Como Executar

### Pré-requisitos
- .NET 8 SDK
- Oracle Database (FIAP)
- Oracle SQL Developer (opcional)

### 1. Configuração do Banco
```sql
-- Execute no Oracle SQL Developer:
create-complete-database.sql
```

### 2. Executar a Aplicação
```bash
cd src/SistemaContabil.Web
dotnet run
```

### 3. Testar a Aplicação
```bash
# Execute o teste completo:
test-application.bat
```

## 📚 Endpoints da API

### Centros de Custo
- `GET /api/CentroCusto` - Listar todos
- `GET /api/CentroCusto/{id}` - Buscar por ID
- `POST /api/CentroCusto` - Criar novo
- `PUT /api/CentroCusto/{id}` - Atualizar
- `DELETE /api/CentroCusto/{id}` - Remover

### Contas
- `GET /api/Conta` - Listar todas
- `GET /api/Conta/{id}` - Buscar por ID
- `POST /api/Conta` - Criar nova
- `PUT /api/Conta/{id}` - Atualizar
- `DELETE /api/Conta/{id}` - Remover

### Registros Contábeis
- `GET /api/RegistroContabil` - Listar todos
- `GET /api/RegistroContabil/{id}` - Buscar por ID
- `POST /api/RegistroContabil` - Criar novo
- `PUT /api/RegistroContabil/{id}` - Atualizar
- `DELETE /api/RegistroContabil/{id}` - Remover

## 🔍 URLs Importantes

- **Swagger UI**: http://localhost:5000/swagger
- **Health Check**: http://localhost:5000/health
- **Teste de Conexão**: http://localhost:5000/api/Test/connection

## 📊 Estrutura do Banco

### Tabelas
- **CENTRO_CUSTO**: Centros de custo da empresa
- **CONTA**: Contas contábeis (Débito/Crédito)
- **REGISTRO_CONTABIL**: Registros contábeis

### Relacionamentos
- Registro Contábil → Conta (FK)
- Registro Contábil → Centro de Custo (FK)

## 🛠️ Scripts Disponíveis

### SQL
- `create-complete-database.sql` - Criação completa do banco
- `verify-database.sql` - Verificação do banco

### Testes
- `test-application.bat` - Teste completo da aplicação

## 📈 Monitoramento

### Logs
- Console logging com Serilog
- Arquivo de log rotativo diário
- Logs estruturados em JSON

### Health Checks
- Endpoint `/health` para monitoramento
- Verificação de conexão com banco
- Status da aplicação

## 🔒 Segurança

### Validações
- FluentValidation para DTOs
- Validação de entrada em controllers
- Sanitização de dados

### Logs de Auditoria
- Log de todas as operações CRUD
- Rastreamento de requisições
- Tratamento de exceções

## 📝 Documentação

### Swagger/OpenAPI
- Documentação automática da API
- Interface interativa para testes
- Exemplos de requisições/respostas

### Código
- Comentários XML em todas as classes
- Documentação de métodos públicos
- Exemplos de uso

## 🧪 Testes

### Testes Manuais
- Scripts de teste automatizados
- Validação de endpoints
- Teste de integração com banco

### Testes de Carga
- Suporte a múltiplas requisições
- Validação de performance
- Monitoramento de recursos

## 📋 Checklist de Implementação

### ✅ Concluído
- [x] Estrutura do projeto
- [x] Camada de domínio
- [x] Camada de aplicação
- [x] Camada de infraestrutura
- [x] Camada web
- [x] Configuração do banco
- [x] Documentação da API
- [x] Logs e monitoramento

### 🔄 Em Andamento
- [ ] Testes unitários
- [ ] Testes de integração
- [ ] Documentação adicional


### Padrões de Código
- Clean Architecture
- SOLID principles
- Repository pattern
- Dependency Injection


---

**Sistema Contábil - Oracle FIAP Challenge**  
Desenvolvido com .NET 8 e Clean Architecture

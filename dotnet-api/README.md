# Sistema Contábil - Oracle FIAP Challenge

## 📋 Visão Geral

Sistema Contábil desenvolvido em .NET 8 com arquitetura Clean Architecture, utilizando Oracle Database como banco de dados principal. O sistema permite o gerenciamento completo de centros de custo, contas contábeis, registros contábeis, clientes e vendas, com API REST completa, busca paginada com filtros, HATEOAS e interface web MVC.

**Versão**: 2.0 - Sprint 2 Completa ✅

## 🏗️ Arquitetura

### Clean Architecture
- **Domain Layer**: Entidades, interfaces e regras de negócio
- **Application Layer**: DTOs, serviços de aplicação e validações
- **Infrastructure Layer**: Repositórios, Entity Framework Core e Oracle
- **Web Layer**: Controllers, middleware e configurações

### Tecnologias Utilizadas
- **.NET 8** - Framework principal
- **Oracle Database** - Banco de dados (Host: 140.238.179.84:1521/FREEPDB1)
- **Entity Framework Core** - ORM
- **AutoMapper** - Mapeamento de objetos
- **FluentValidation** - Validações
- **Serilog** - Logging
- **Swagger/OpenAPI** - Documentação da API
- **ASP.NET Core MVC** - Interface web
- **Bootstrap 5** - Framework CSS
- **Minimal API** - Endpoints de busca paginada

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
- **RF002.1**: Criar conta com nome único e tipo (Receita/Despesa)
- **RF002.2**: Listar todas as contas
- **RF002.3**: Buscar conta por ID
- **RF002.4**: Buscar contas por nome (busca parcial)
- **RF002.5**: Buscar contas por tipo (Receita ou Despesa)
- **RF002.6**: Atualizar nome e tipo da conta
- **RF002.7**: Remover conta (apenas se não tiver registros)
- **RF002.8**: Listar contas com registros contábeis
- **RF002.9**: Validar se conta pode ser removida
- **RF002.10**: Associar conta a cliente (opcional)

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

### RF004 - Gerenciamento de Clientes
- **RF004.1**: Criar cliente com CPF/CNPJ e email únicos
- **RF004.2**: Listar todos os clientes
- **RF004.3**: Buscar cliente por ID, CPF/CNPJ ou email
- **RF004.4**: Atualizar dados do cliente
- **RF004.5**: Remover cliente
- **RF004.6**: Ativar/desativar cliente

### RF005 - Gerenciamento de Vendas
- **RF005.1**: Criar venda vinculada a cliente e registro contábil
- **RF005.2**: Listar todas as vendas
- **RF005.3**: Buscar venda por ID
- **RF005.4**: Buscar vendas por cliente
- **RF005.5**: Buscar vendas por registro contábil
- **RF005.6**: Atualizar venda
- **RF005.7**: Remover venda

### RF006 - Busca Paginada e Filtros (Sprint 2)
- **RF006.1**: Busca paginada de centros de custo com filtros
- **RF006.2**: Busca paginada de contas com filtros
- **RF006.3**: Busca paginada de registros contábeis com filtros
- **RF006.4**: Busca paginada de clientes com filtros
- **RF006.5**: Busca paginada de vendas com filtros
- **RF006.6**: Ordenação personalizada em todas as buscas
- **RF006.7**: Suporte a paginação (page, pageSize)

### RF007 - HATEOAS (Sprint 2)
- **RF007.1**: Links HATEOAS em respostas paginadas
- **RF007.2**: Links de navegação (first, prev, next, last)
- **RF007.3**: Links de ação (self, create, update, delete)

### RF008 - Interface Web MVC (Sprint 2)
- **RF008.1**: Interface web completa com Bootstrap 5
- **RF008.2**: CRUD visual para todas as entidades
- **RF008.3**: Validação client-side com jQuery Validation
- **RF008.4**: Layout responsivo e navegação intuitiva

### RF009 - Validações de Negócio
- **RF009.1**: Nome do centro de custo obrigatório e único
- **RF009.2**: Nome da conta obrigatório e único
- **RF009.3**: Tipo da conta deve ser 'R' (Receita) ou 'D' (Despesa)
- **RF009.4**: Valor do registro deve ser maior que zero
- **RF009.5**: Conta e centro de custo devem existir
- **RF009.6**: Não permitir remoção de entidades com registros associados
- **RF009.7**: CPF/CNPJ e email de cliente únicos
- **RF009.8**: Validação de IDs em todas as operações

### RF010 - Relatórios e Consultas
- **RF010.1**: Relatório de registros por conta
- **RF010.2**: Relatório de registros por centro de custo
- **RF010.3**: Relatório de registros por período
- **RF010.4**: Relatório de totais por conta
- **RF010.5**: Relatório de totais por centro de custo
- **RF010.6**: Relatório de totais por período

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

### 1. Configuração do Banco de Dados

**Conexão Oracle:**
- **Host**: 140.238.179.84
- **Porta**: 1521
- **Service Name**: FREEPDB1
- **Usuário**: appuser
- **Senha**: AppPass#2025

Execute o script SQL no Oracle:
```sql
-- Execute o script: challenge_oracle2_fixed.sql
-- Este script cria todas as tabelas, sequências, triggers e índices
```

### 2. Configuração da Aplicação

A conexão do banco já está configurada nos arquivos:
- `src/SistemaContabil.Web/appsettings.json`
- `src/SistemaContabil.Web/appsettings.Development.json`
- `src/SistemaContabil.Infrastructure/Configuration/DatabaseConfiguration.cs`

### 3. Executar a Aplicação

```bash
cd src/SistemaContabil.Web
dotnet restore
dotnet build
dotnet run
```

### 4. Acessar a Aplicação

- **Interface Web MVC**: http://localhost:5000/Home/Index
- **Swagger UI**: http://localhost:5000/swagger
- **Health Check**: http://localhost:5000/health
- **API Root**: http://localhost:5000/api

### 5. Testar a Aplicação

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
- `GET /api/search/centrocusto` - Busca paginada com filtros ⭐ **NOVO**

### Contas Contábeis
- `GET /api/Conta` - Listar todas
- `GET /api/Conta/{id}` - Buscar por ID
- `POST /api/Conta` - Criar nova
- `PUT /api/Conta/{id}` - Atualizar
- `DELETE /api/Conta/{id}` - Remover
- `GET /api/search/conta` - Busca paginada com filtros ⭐ **NOVO**

### Registros Contábeis
- `GET /api/RegistroContabil` - Listar todos
- `GET /api/RegistroContabil/{id}` - Buscar por ID
- `POST /api/RegistroContabil` - Criar novo
- `PUT /api/RegistroContabil/{id}` - Atualizar
- `DELETE /api/RegistroContabil/{id}` - Remover
- `GET /api/search/registrocontabil` - Busca paginada com filtros ⭐ **NOVO**

### Clientes ⭐ **NOVO**
- `GET /api/Cliente` - Listar todos
- `GET /api/Cliente/{id}` - Buscar por ID
- `POST /api/Cliente` - Criar novo
- `PUT /api/Cliente/{id}` - Atualizar
- `DELETE /api/Cliente/{id}` - Remover
- `GET /api/search/cliente` - Busca paginada com filtros

### Vendas ⭐ **NOVO**
- `GET /api/Vendas` - Listar todas
- `GET /api/Vendas/{id}` - Buscar por ID
- `POST /api/Vendas` - Criar nova
- `PUT /api/Vendas/{id}` - Atualizar
- `DELETE /api/Vendas/{id}` - Remover
- `GET /api/search/vendas` - Busca paginada com filtros

## 🔍 Endpoints de Busca Paginada (Minimal API)

Todos os endpoints de busca suportam:
- **Paginação**: `page` (padrão: 1), `pageSize` (padrão: 10, máximo: 100)
- **Ordenação**: `sortBy` (nome do campo), `sortOrder` (asc/desc)
- **Filtros**: Específicos por entidade
- **HATEOAS**: Links de navegação automáticos na resposta

### Exemplos de Uso:

```bash
# Buscar centros de custo paginado
GET /api/search/centrocusto?page=1&pageSize=10&nome=TI&sortBy=nome&sortOrder=asc

# Buscar contas com filtros
GET /api/search/conta?tipo=R&page=1&pageSize=20

# Buscar registros contábeis por período
GET /api/search/registrocontabil?valorMin=100&valorMax=1000&dataInicio=2025-01-01&dataFim=2025-12-31
```

## 🔗 HATEOAS (Hypermedia as the Engine of Application State)

Todas as respostas de busca paginada incluem links HATEOAS:

```json
{
  "items": [...],
  "page": 1,
  "pageSize": 10,
  "totalCount": 50,
  "totalPages": 5,
  "links": {
    "self": "/api/search/conta?page=1&pageSize=10",
    "first": "/api/search/conta?page=1&pageSize=10",
    "prev": null,
    "next": "/api/search/conta?page=2&pageSize=10",
    "last": "/api/search/conta?page=5&pageSize=10",
    "create": "/api/conta"
  }
}
```

## 🌐 Interface Web MVC

A aplicação inclui uma interface web completa com:

### Páginas Disponíveis:
- **Home**: Página inicial com cards de navegação
- **Centros de Custo**: CRUD completo
- **Contas Contábeis**: CRUD completo
- **Registros Contábeis**: CRUD completo (com select lists)
- **Clientes**: CRUD completo ⭐ **NOVO**
- **Vendas**: CRUD completo ⭐ **NOVO**

### Funcionalidades:
- ✅ Layout responsivo com Bootstrap 5
- ✅ Validação client-side
- ✅ Mensagens de sucesso/erro
- ✅ Navegação intuitiva com dropdown menus
- ✅ Formulários com validação em tempo real

## 🔍 URLs Importantes

- **Interface Web MVC**: http://localhost:5000 ⭐ **NOVO**
- **Swagger UI**: http://localhost:5000/swagger
- **Health Check**: http://localhost:5000/health
- **API Root**: http://localhost:5000/api
- **Teste de Conexão**: http://localhost:5000/api/Test/connection

## 🆕 Novidades da Sprint 2

### Busca Paginada
- Endpoints Minimal API para busca avançada
- Filtros dinâmicos por entidade
- Ordenação personalizável
- Paginação eficiente

### HATEOAS
- Links de navegação automáticos
- Descoberta de recursos via hypermedia
- Melhor integração de clientes API

### Interface Web MVC
- Interface completa e responsiva
- CRUD visual para todas as entidades
- Bootstrap 5 com design moderno
- Validação em tempo real

### Novas Entidades
- **Cliente**: Gerenciamento completo de clientes
- **Vendas**: Registro e gerenciamento de vendas
- Relacionamentos com registros contábeis

### Melhorias de API
- ProblemDetails para erros padronizados
- Validações mais robustas
- Documentação Swagger aprimorada
- Códigos HTTP apropriados

## 📊 Estrutura do Banco de Dados

### Tabelas
- **CENTRO_CUSTO**: Centros de custo da empresa
- **CONTA_CONTABIL**: Contas contábeis (Receita/Despesa) ⚠️ **Schema atualizado**
- **REG_CONT**: Registros contábeis ⚠️ **Schema atualizado**
- **CLIENTE**: Clientes do sistema ⭐ **NOVO**
- **VENDAS**: Vendas realizadas ⭐ **NOVO**

### Relacionamentos
- Registro Contábil (REG_CONT) → Conta Contábil (CONTA_CONTABIL) (FK)
- Registro Contábil (REG_CONT) → Centro de Custo (CENTRO_CUSTO) (FK)
- Conta Contábil (CONTA_CONTABIL) → Cliente (CLIENTE) (FK, opcional)
- Vendas → Cliente (FK)
- Vendas → Registro Contábil (FK)

### Sequências
- `centro_custo_seq` - IDs de centros de custo
- `conta_seq` - IDs de contas contábeis
- `reg_cont_seq` - IDs de registros contábeis
- `cliente_seq` - IDs de clientes
- `vendas_seq` - IDs de vendas

### Índices Únicos
- Cliente: CPF/CNPJ único, Email único

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

## 📋 Checklist de Implementação - Sprint 2

### ✅ Sprint 1 - Concluído
- [x] Estrutura do projeto
- [x] Camada de domínio
- [x] Camada de aplicação
- [x] Camada de infraestrutura
- [x] Camada web básica
- [x] Configuração do banco
- [x] Documentação da API
- [x] Logs e monitoramento

### ✅ Sprint 2 - Concluído
- [x] **Atualização do Schema do Banco**
  - [x] Migração para CONTA_CONTABIL e REG_CONT
  - [x] Adição das tabelas CLIENTE e VENDAS
  - [x] Atualização de relacionamentos e sequências
  
- [x] **Entidades e DTOs**
  - [x] Atualização de Conta (Receita/Despesa)
  - [x] Atualização de RegistroContabil
  - [x] Criação de entidades Cliente e Vendas
  - [x] DTOs de busca paginada (PagedResultDto, SearchRequestDto)
  - [x] DTOs de filtro para cada entidade

- [x] **Repositórios e Services**
  - [x] Repositórios de Cliente e Vendas
  - [x] Métodos de busca paginada em todos os repositórios
  - [x] Services de domínio para Cliente e Vendas
  - [x] AppServices para Cliente e Vendas

- [x] **API REST - Controllers**
  - [x] Controllers API para Cliente e Vendas
  - [x] Melhorias com ProblemDetails
  - [x] Validações robustas
  - [x] Documentação Swagger completa

- [x] **Minimal API - Busca Paginada**
  - [x] Endpoints /api/search/{entidade}
  - [x] Suporte a paginação, ordenação e filtros
  - [x] Implementação HATEOAS

- [x] **Frontend MVC**
  - [x] Layout principal com Bootstrap 5
  - [x] Controllers MVC para todas as entidades
  - [x] Views completas (Index, Create, Edit, Details, Delete)
  - [x] Validação client-side
  - [x] Navegação responsiva

- [x] **HATEOAS**
  - [x] Helper para geração de links
  - [x] Links em respostas paginadas
  - [x] Links de navegação (first, prev, next, last)

- [x] **Documentação**
  - [x] README atualizado
  - [x] Documentação de novos endpoints
  - [x] Guia de uso do HATEOAS

### 🔄 Próximos Passos
- [ ] Testes unitários
- [ ] Testes de integração
- [ ] Testes end-to-end do frontend MVC


### Padrões de Código
- Clean Architecture
- SOLID principles
- Repository pattern
- Dependency Injection


---

**Sistema Contábil - Oracle FIAP Challenge**  
Desenvolvido com .NET 8 e Clean Architecture

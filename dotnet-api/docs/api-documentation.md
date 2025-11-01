# Documentação da API - Sistema Contábil

## 📋 Visão Geral

A API do Sistema Contábil fornece endpoints para gerenciar centros de custo, contas e registros contábeis. A API segue os padrões REST e utiliza JSON para troca de dados.

**Base URL**: `http://localhost:5000/api` ou `https://localhost:5001/api`

## 🔐 Autenticação

Atualmente, a API não requer autenticação. Em versões futuras, será implementado JWT Bearer Token.

## 🚀 URLs Importantes

- **Swagger UI**: `http://localhost:5000/swagger`
- **Health Check**: `http://localhost:5000/health`
- **Teste de Conexão**: `http://localhost:5000/api/Test/connection`
- **Listagem de Conexões**: `http://localhost:5000/api/Test/connections`

## 📊 Endpoints

### Centro de Custo

#### Listar Todos os Centros de Custo
```http
GET /api/CentroCusto
```

**Resposta:**
```json
[
  {
    "idCentroCusto": 1,
    "nomeCentroCusto": "Vendas"
  },
  {
    "idCentroCusto": 2,
    "nomeCentroCusto": "Marketing"
  }
]
```

#### Obter Centro de Custo por ID
```http
GET /api/CentroCusto/{id}
```

**Parâmetros:**
- `id` (int): ID do centro de custo

**Resposta (200):**
```json
{
  "idCentroCusto": 1,
  "nomeCentroCusto": "Vendas"
}
```

**Resposta (404):**
```json
{
  "message": "Centro de custo com ID 1 não encontrado"
}
```

#### Criar Centro de Custo
```http
POST /api/CentroCusto
```

**Body:**
```json
{
  "nomeCentroCusto": "Vendas"
}
```

**Resposta (201):**
```json
{
  "idCentroCusto": 1,
  "nomeCentroCusto": "Vendas"
}
```

**Resposta (400):**
```json
{
  "errors": {
    "NomeCentroCusto": ["O nome do centro de custo é obrigatório"]
  }
}
```

#### Atualizar Centro de Custo
```http
PUT /api/CentroCusto/{id}
```

**Body:**
```json
{
  "nomeCentroCusto": "Vendas Atualizado"
}
```

**Resposta (200):**
```json
{
  "idCentroCusto": 1,
  "nomeCentroCusto": "Vendas Atualizado"
}
```

#### Remover Centro de Custo
```http
DELETE /api/CentroCusto/{id}
```

**Resposta (200):**
```json
{
  "message": "Centro de custo removido com sucesso"
}
```

**Resposta (400):**
```json
{
  "message": "Centro de custo não pode ser removido pois possui registros contábeis"
}
```

### Conta

#### Listar Todas as Contas
```http
GET /api/Conta
```

**Resposta:**
```json
[
  {
    "idConta": 1,
    "nomeConta": "Caixa",
    "tipo": "D"
  },
  {
    "idConta": 2,
    "nomeConta": "Bancos",
    "tipo": "D"
  }
]
```

#### Obter Conta por ID
```http
GET /api/Conta/{id}
```

**Resposta (200):**
```json
{
  "idConta": 1,
  "nomeConta": "Caixa",
  "tipo": "D"
}
```

#### Criar Conta
```http
POST /api/Conta
```

**Body:**
```json
{
  "nomeConta": "Caixa",
  "tipo": "D"
}
```

**Resposta (201):**
```json
{
  "idConta": 1,
  "nomeConta": "Caixa",
  "tipo": "D"
}
```

#### Atualizar Conta
```http
PUT /api/Conta/{id}
```

**Body:**
```json
{
  "nomeConta": "Caixa Atualizado",
  "tipo": "D"
}
```

#### Remover Conta
```http
DELETE /api/Conta/{id}
```

### Registro Contábil

#### Listar Todos os Registros
```http
GET /api/RegistroContabil
```

**Resposta:**
```json
[
  {
    "idRegistroContabil": 1,
    "valor": 1000.00,
    "contaIdConta": 1,
    "centroCustoIdCentroCusto": 1
  }
]
```

#### Obter Registro por ID
```http
GET /api/RegistroContabil/{id}
```

#### Criar Registro Contábil
```http
POST /api/RegistroContabil
```

**Body:**
```json
{
  "valor": 1000.00,
  "contaIdConta": 1,
  "centroCustoIdCentroCusto": 1
}
```

**Resposta (201):**
```json
{
  "idRegistroContabil": 1,
  "valor": 1000.00,
  "contaIdConta": 1,
  "centroCustoIdCentroCusto": 1,
  "dataCriacao": "2025-01-05T20:45:47.123Z",
  "dataAtualizacao": "2025-01-05T20:45:47.123Z"
}
```

#### Atualizar Registro Contábil
```http
PUT /api/RegistroContabil/{id}
```

**Body:**
```json
{
  "valor": 1500.00,
  "contaIdConta": 1,
  "centroCustoIdCentroCusto": 1
}
```

#### Remover Registro Contábil
```http
DELETE /api/RegistroContabil/{id}
```

## 🔍 Códigos de Status HTTP

| Código | Descrição |
|--------|-----------|
| 200 | OK - Operação bem-sucedida |
| 201 | Created - Recurso criado com sucesso |
| 400 | Bad Request - Dados inválidos |
| 404 | Not Found - Recurso não encontrado |
| 500 | Internal Server Error - Erro interno do servidor |

## 📝 Validações

### Centro de Custo
- **Nome**: Obrigatório, máximo 70 caracteres
- **Unicidade**: Nome deve ser único

### Conta
- **Nome**: Obrigatório, máximo 70 caracteres
- **Tipo**: Obrigatório, deve ser 'D' (Débito) ou 'C' (Crédito)
- **Unicidade**: Nome deve ser único

### Registro Contábil
- **Valor**: Obrigatório, deve ser maior que zero
- **Conta**: Deve referenciar uma conta existente
- **Centro de Custo**: Deve referenciar um centro de custo existente

## 🧪 Exemplos de Uso

### 1. Criar um Centro de Custo
```bash
curl -X POST "http://localhost:5000/api/CentroCusto" \
  -H "Content-Type: application/json" \
  -d '{"nomeCentroCusto": "Vendas"}'
```

### 2. Criar uma Conta
```bash
curl -X POST "http://localhost:5000/api/Conta" \
  -H "Content-Type: application/json" \
  -d '{"nomeConta": "Caixa", "tipo": "D"}'
```

### 3. Criar um Registro Contábil
```bash
curl -X POST "http://localhost:5000/api/RegistroContabil" \
  -H "Content-Type: application/json" \
  -d '{"valor": 1000.00, "contaIdConta": 1, "centroCustoIdCentroCusto": 1}'
```

### 4. Listar Todos os Registros
```bash
curl -X GET "http://localhost:5000/api/RegistroContabil"
```

## 🔧 Health Check

### Verificar Status da Aplicação
```http
GET /health
```

**Resposta:**
```json
{
  "status": "Healthy",
  "timestamp": "2025-01-05T20:45:47.123Z"
}
```

## 📚 Swagger UI

A documentação interativa da API está disponível em:
- **Desenvolvimento**: `http://localhost:5000/swagger`
- **Produção**: `https://localhost:5001/swagger`

O Swagger UI permite:
- Visualizar todos os endpoints
- Testar endpoints diretamente na interface
- Ver exemplos de requisições e respostas
- Baixar a especificação OpenAPI

## 🔧 Endpoints de Teste

### Teste de Conexão Oracle
```http
GET /api/Test/connection
```

**Resposta:**
```json
{
  "status": "Connected",
  "connectionString": "Data Source=oracle.fiap.com.br:1521/orcl;User Id=rm560088;Password=***;",
  "description": "Service Name /orcl (FORMATO CORRETO)",
  "timestamp": "2025-01-05T20:45:47.123Z"
}
```

### Listagem de Conexões Disponíveis
```http
GET /api/Test/connections
```

**Resposta:**
```json
[
  {
    "connectionString": "Data Source=oracle.fiap.com.br:1521/orcl;User Id=rm560088;Password=***;",
    "description": "Service Name /orcl (FORMATO CORRETO)",
    "isActive": true
  },
  {
    "connectionString": "Data Source=oracle.fiap.com.br:1521/ORCL;User Id=rm560088;Password=***;",
    "description": "Service Name /ORCL (maiúsculo)",
    "isActive": false
  }
]
```

## 🚨 Tratamento de Erros

### Erro de Validação (400)
```json
{
  "errors": {
    "NomeCentroCusto": [
      "O nome do centro de custo é obrigatório",
      "O nome deve ter no máximo 70 caracteres"
    ]
  }
}
```

### Erro de Recurso Não Encontrado (404)
```json
{
  "message": "Centro de custo com ID 999 não encontrado"
}
```

### Erro Interno do Servidor (500)
```json
{
  "message": "Erro interno do servidor"
}
```

## 📊 Limitações

- **Tamanho máximo de requisição**: 1MB
- **Timeout de conexão**: 30 segundos
- **Rate limiting**: Não implementado (versão atual)
- **Paginação**: Não implementada (versão atual)

## 🔄 Versionamento

A API atual é a versão 1.0. O versionamento será implementado em futuras versões através do header `Accept` ou na URL.

**Exemplo futuro:**
```http
GET /api/v2/CentroCusto
Accept: application/vnd.sistemacontabil.v2+json
```

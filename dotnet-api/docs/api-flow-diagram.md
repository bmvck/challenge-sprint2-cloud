# Diagrama de Fluxo da API - Sistema Contábil

## Fluxo de Requisições HTTP

```mermaid
graph TD
    A[Cliente HTTP] --> B[ASP.NET Core Web API]
    B --> C[Middleware Pipeline]
    C --> D[Exception Handling]
    D --> E[Request Logging]
    E --> F[Controller]
    
    F --> G[Application Service]
    G --> H[Domain Service]
    H --> I[Repository]
    I --> J[Entity Framework]
    J --> K[Oracle Database]
    
    K --> L[Resultado]
    L --> M[Entity]
    M --> N[Domain Service]
    N --> O[Application Service]
    O --> P[DTO]
    P --> Q[Controller]
    Q --> R[HTTP Response]
    R --> A
    
    D --> S[Error Response]
    S --> A
```

## Endpoints da API

```mermaid
graph LR
    subgraph "Centro de Custo"
        CC1[GET /api/CentroCusto]
        CC2[GET /api/CentroCusto/{id}]
        CC3[POST /api/CentroCusto]
        CC4[PUT /api/CentroCusto/{id}]
        CC5[DELETE /api/CentroCusto/{id}]
    end
    
    subgraph "Conta"
        C1[GET /api/Conta]
        C2[GET /api/Conta/{id}]
        C3[POST /api/Conta]
        C4[PUT /api/Conta/{id}]
        C5[DELETE /api/Conta/{id}]
    end
    
    subgraph "Registro Contábil"
        R1[GET /api/RegistroContabil]
        R2[GET /api/RegistroContabil/{id}]
        R3[POST /api/RegistroContabil]
        R4[PUT /api/RegistroContabil/{id}]
        R5[DELETE /api/RegistroContabil/{id}]
    end
    
    subgraph "Health Check"
        H1[GET /health]
    end
    
    subgraph "Teste de Conexão"
        T1[GET /api/Test/connection]
        T2[GET /api/Test/connections]
    end
    
    subgraph "Swagger"
        S1[GET /swagger]
        S2[GET /swagger/v1/swagger.json]
    end
```

## Fluxo de Validação

```mermaid
graph TD
    A[Request] --> B[Model Validation]
    B -->|Válido| C[Business Rules]
    B -->|Inválido| D[400 Bad Request]
    
    C -->|Válido| E[Database Operation]
    C -->|Inválido| F[400 Bad Request]
    
    E -->|Sucesso| G[200 OK]
    E -->|Erro| H[500 Internal Server Error]
    E -->|Não Encontrado| I[404 Not Found]
    
    D --> J[Response]
    F --> J
    G --> J
    H --> J
    I --> J
```

## Middleware Pipeline

```mermaid
graph TD
    A[HTTP Request] --> B[Exception Handling Middleware]
    B --> C[Request Logging Middleware]
    C --> D[CORS Middleware]
    D --> E[HTTPS Redirection]
    E --> F[Authorization]
    F --> G[Controllers]
    G --> H[Response]
    H --> I[HTTP Response]
```

## Fluxo de Teste da Aplicação

```mermaid
graph TD
    A[Iniciar Aplicação] --> B[Teste de Conexão Oracle]
    B --> C{Conectado?}
    C -->|Sim| D[Teste Health Check]
    C -->|Não| E[Erro de Conexão]
    
    D --> F[Teste GET Endpoints]
    F --> G[Teste POST Endpoints]
    G --> H[Validação de Dados]
    H --> I[Sistema Funcionando]
    
    E --> J[Verificar Credenciais]
    J --> K[Executar Scripts SQL]
    K --> B
```

## Fluxo de Configuração do Banco

```mermaid
graph TD
    A[Executar create-complete-database.sql] --> B[Criar Tabelas]
    B --> C[Criar Sequences]
    C --> D[Criar Triggers]
    D --> E[Inserir Dados de Exemplo]
    E --> F[Verificar Integridade]
    F --> G[Executar verify-database.sql]
    G --> H[Banco Configurado]
    
    H --> I[Teste da Aplicação]
    I --> J[Sistema Funcionando]
```

# Diagrama de Arquitetura - Sistema Contábil

## Arquitetura em Camadas (Clean Architecture)

```mermaid
graph TB
    subgraph "Web Layer"
        API[ASP.NET Core Web API]
        Controllers[Controllers]
        Middleware[Middleware]
        Swagger[Swagger UI]
    end
    
    subgraph "Application Layer"
        AppServices[Application Services]
        DTOs[DTOs]
        Validators[Validators]
        Mappings[AutoMapper]
    end
    
    subgraph "Domain Layer"
        Entities[Entities]
        Interfaces[Interfaces]
        Services[Domain Services]
        BusinessRules[Business Rules]
    end
    
    subgraph "Infrastructure Layer"
        EF[Entity Framework Core]
        Repositories[Repositories]
        Oracle[Oracle Database]
        Migrations[Migrations]
    end
    
    API --> Controllers
    Controllers --> AppServices
    AppServices --> DTOs
    AppServices --> Validators
    AppServices --> Mappings
    AppServices --> Services
    Services --> Entities
    Services --> Interfaces
    Services --> BusinessRules
    Services --> Repositories
    Repositories --> EF
    EF --> Oracle
    EF --> Migrations
    API --> Swagger
    API --> Middleware
```

## Fluxo de Dados

```mermaid
sequenceDiagram
    participant Client as Cliente
    participant API as Web API
    participant App as Application Service
    participant Domain as Domain Service
    participant Repo as Repository
    participant DB as Oracle Database
    
    Client->>API: HTTP Request
    API->>App: DTO
    App->>Domain: Business Logic
    Domain->>Repo: Data Access
    Repo->>DB: SQL Query
    DB-->>Repo: Result
    Repo-->>Domain: Entity
    Domain-->>App: Processed Entity
    App-->>API: DTO
    API-->>Client: HTTP Response
```

## Modelo de Dados

```mermaid
erDiagram
    CENTRO_CUSTO {
        int id_centro_custo PK
        string nome_centro_custo
    }
    
    CONTA {
        int id_conta PK
        string nome_conta
        char tipo
    }
    
    REGISTRO_CONTABIL {
        int id_registro_contabil PK
        decimal valor
        int conta_id_conta FK
        int centro_custo_id_centro_custo FK
        timestamp data_criacao
        timestamp data_atualizacao
    }
    
    CENTRO_CUSTO ||--o{ REGISTRO_CONTABIL : "tem"
    CONTA ||--o{ REGISTRO_CONTABIL : "tem"
```

## Padrões de Design Utilizados

```mermaid
graph LR
    subgraph "Design Patterns"
        Repository[Repository Pattern]
        Service[Service Layer Pattern]
        DTO[DTO Pattern]
        DI[Dependency Injection]
        CQRS[CQRS Pattern]
        Validator[FluentValidation]
        Mapper[AutoMapper]
    end
    
    subgraph "Architecture Patterns"
        CleanArch[Clean Architecture]
        DDD[Domain Driven Design]
        Layered[Layered Architecture]
    end
    
    Repository --> CleanArch
    Service --> DDD
    DTO --> Layered
    DI --> CleanArch
    CQRS --> DDD
    Validator --> CleanArch
    Mapper --> Layered
```

## Tecnologias e Ferramentas

```mermaid
graph TB
    subgraph "Frontend/API"
        Swagger[Swagger UI]
        Controllers[ASP.NET Core Controllers]
        Middleware[Custom Middleware]
    end
    
    subgraph "Application Layer"
        AutoMapper[AutoMapper]
        FluentValidation[FluentValidation]
        DTOs[DTOs]
    end
    
    subgraph "Domain Layer"
        Entities[Domain Entities]
        Interfaces[Repository Interfaces]
        Services[Domain Services]
    end
    
    subgraph "Infrastructure Layer"
        EF[Entity Framework Core]
        Oracle[Oracle Database]
        Repositories[Repository Implementations]
    end
    
    subgraph "Monitoring & Logging"
        Serilog[Serilog]
        HealthCheck[Health Checks]
        Logs[Structured Logging]
    end
    
    Swagger --> Controllers
    Controllers --> AutoMapper
    Controllers --> FluentValidation
    AutoMapper --> DTOs
    DTOs --> Entities
    Entities --> Interfaces
    Interfaces --> Repositories
    Repositories --> EF
    EF --> Oracle
    Controllers --> Serilog
    Controllers --> HealthCheck
    Serilog --> Logs
```

# Sprint 2 - Cloud (Infra com Docker)

Este repositório contém:
- **Dockerfile** das APIs (Java 17 e .NET 8)
- **docker-compose.yml** para subir todo o ambiente
- Scripts de banco em `db/init/`
- **README** com instruções de execução

## Requisitos
- Docker 24+ e Docker Compose Plugin
- (Opcional) Acesso ao Oracle Container Registry caso use Oracle DB:
  - https://container-registry.oracle.com (accept license em `database/free`)

## Configuração
1. Copie `.env.sample` para `.env` e preencha as variáveis:
   ```bash
   cp .env.sample .env
   # edite os valores de acordo com o banco escolhido





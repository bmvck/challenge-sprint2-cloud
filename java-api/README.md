# Sistema de Gestão Financeira e Contábil

## Descrição

API RESTful desenvolvida em Spring Boot para gerenciamento de dados financeiros e contábeis, incluindo clientes, centros de custo, contas, registros contábeis e vendas.


## Tecnologias Utilizadas

- **Java 17**
- **Spring Boot 3.5.6**
- **Spring Data JPA**
- **Hibernate**
- **Oracle Database** (produção) / **H2 Database** (desenvolvimento)
- **Lombok**
- **Bean Validation**
- **SpringDoc OpenAPI** (Swagger)
- **Maven**

## Arquitetura

A aplicação segue os princípios de:
- **Programação Orientada a Objetos (POO)**
- **Coesão e Desacoplamento**
- **Padrões de Projeto** (Repository, Service Layer, DTO)
- **API RESTful** (Nível 1 - Richardson Maturity Model)

### Estrutura de Pacotes

```
com.fiap.financecontrol/
├── domains/           # Entidades JPA
├── gateways/          # Controllers e Repositories
│   └── dtos/         # DTOs de Request/Response
├── services/         # Lógica de negócio
└── configurations/   # Configurações e Beans
```

## Como Executar a Aplicação

### Pré-requisitos

- Java 17 ou superior
- Maven 3.6 ou superior
- Oracle Database (para ambiente de produção)

### Configuração do Banco de Dados

#### Ambiente Local (H2 - Desenvolvimento)
```bash
# A aplicação usa H2 em memória por padrão
# Acesse: http://localhost:8080/h2-console
# JDBC URL: jdbc:h2:mem:finance-control-db
# Username: sa
# Password: (vazio)
```

#### Ambiente de Desenvolvimento (Oracle FIAP)
```bash
# Configure as variáveis de ambiente:
export DB_USERNAME=rm560088
export DB_PASSWORD=061005

# Execute com profile dev:
mvn spring-boot:run -Dspring-boot.run.profiles=dev
```

**Configuração do Oracle FIAP:**
- **Host**: oracle.fiap.com.br
- **Porta**: 1521
- **SID**: ord
- **Usuário**: rm560088
- **Senha**: 061005

**Antes de executar, certifique-se de:**
1. Executar o script `docs/database/setup-oracle-fiap.sql` no Oracle SQL Developer
2. O script criará as tabelas, sequences, constraints e dados de teste

### Executando a Aplicação

```bash
# Navegue até o diretório do projeto
cd Challenge_Java

# Execute a aplicação (ambiente local com H2)
mvn spring-boot:run

# Execute a aplicação (ambiente dev com Oracle FIAP)
mvn spring-boot:run -Dspring-boot.run.profiles=dev

# Ou compile e execute
mvn clean package
java -jar target/finance-control-0.0.1-SNAPSHOT.jar
```

A aplicação estará disponível em: `http://localhost:8080`

## Documentação da API

### Swagger/OpenAPI
Acesse a documentação interativa da API em:
- **Swagger UI**: http://localhost:8080/swagger-ui.html
- **OpenAPI JSON**: http://localhost:8080/api-docs

### Endpoints Disponíveis

#### Clientes
- `GET /fiap/clientes` - Listar clientes (com paginação e filtros)
- `GET /fiap/clientes/{id}` - Buscar cliente por ID
- `POST /fiap/clientes` - Criar novo cliente
- `PUT /fiap/clientes/{id}` - Atualizar cliente
- `DELETE /fiap/clientes/{id}` - Deletar cliente

#### Centros de Custo
- `GET /fiap/centros-custo` - Listar centros de custo
- `GET /fiap/centros-custo/{id}` - Buscar centro de custo por ID
- `POST /fiap/centros-custo` - Criar novo centro de custo
- `PUT /fiap/centros-custo/{id}` - Atualizar centro de custo
- `DELETE /fiap/centros-custo/{id}` - Deletar centro de custo

#### Contas
- `GET /fiap/contas` - Listar contas (com filtros por tipo)
- `GET /fiap/contas/{id}` - Buscar conta por ID
- `POST /fiap/contas` - Criar nova conta
- `PUT /fiap/contas/{id}` - Atualizar conta
- `DELETE /fiap/contas/{id}` - Deletar conta

#### Registros Contábeis
- `GET /fiap/registros-contabeis` - Listar registros contábeis
- `GET /fiap/registros-contabeis/{id}` - Buscar registro por ID
- `POST /fiap/registros-contabeis` - Criar novo registro
- `PUT /fiap/registros-contabeis/{id}` - Atualizar registro
- `DELETE /fiap/registros-contabeis/{id}` - Deletar registro

#### Vendas
- `GET /fiap/vendas` - Listar vendas
- `GET /fiap/vendas/{id}` - Buscar venda por ID
- `POST /fiap/vendas` - Criar nova venda
- `PUT /fiap/vendas/{id}` - Atualizar venda
- `DELETE /fiap/vendas/{id}` - Deletar venda

### Parâmetros de Paginação

Todos os endpoints de listagem suportam:
- `page` - Número da página (padrão: 0)
- `size` - Tamanho da página (padrão: 10)
- `direction` - Direção da ordenação: ASC ou DESC (padrão: ASC)

### Exemplos de Requisições

#### Criar Cliente
```json
POST /fiap/clientes
{
  "nomeCliente": "João Silva",
  "cpfCnpj": "12345678901",
  "email": "joao@email.com",
  "senha": "senha123",
  "ativo": "S"
}
```

#### Criar Conta
```json
POST /fiap/contas
{
  "nomeConta": "Receita de Vendas",
  "tipo": "R",
  "clienteId": 1
}
```

#### Criar Registro Contábil
```json
POST /fiap/registros-contabeis
{
  "valor": 1500.00,
  "contaId": 1,
  "centroCustoId": 1
}
```

## Diagramas

### Diagrama de Entidade-Relacionamento (DER)
![DER](docs/diagrams/der.png)

### Diagrama de Classes das Entidades
![Diagrama de Classes](docs/diagrams/class-diagram.png)

### Arquitetura da Aplicação
![Arquitetura](docs/diagrams/architecture.png)

## Testes da API

### Collection Postman/Insomnia
Acesse a pasta `docs/api-tests/` para encontrar:
- `postman-collection.json` - Collection completa do Postman
- Todos os endpoints com exemplos de requisições
- Casos de teste para validação

### Executando Testes
```bash
# Executar todos os testes
mvn test

# Executar testes com relatório de cobertura
mvn test jacoco:report
```

### Testes Disponíveis
- `FinanceControlApplicationTests` - Teste de contexto Spring
- `ClienteRepositoryTest` - Testes de repository
- `ClienteControllerTest` - Testes de controller com MockMvc

## Configurações Adicionais

### Profiles Disponíveis
- `local` - H2 Database em memória (padrão)
- `dev` - Oracle Database para desenvolvimento

### Logs
A aplicação gera logs detalhados para:
- Queries SQL (nível DEBUG)
- Operações de CRUD
- Erros e exceções

### Health Check
- **Health**: http://localhost:8080/actuator/health
- **Info**: http://localhost:8080/actuator/info
- **Metrics**: http://localhost:8080/actuator/metrics

## Estrutura do Banco de Dados

### Oracle FIAP
O banco de dados Oracle FIAP deve ser configurado com as seguintes tabelas:
- `CLIENTE` - Dados dos clientes
- `CENTRO_CUSTO` - Centros de custo
- `CONTA` - Contas contábeis
- `REG_CONT` - Registros contábeis
- `VENDAS` - Registro de vendas

**Scripts disponíveis:**
- `docs/database/setup-oracle-fiap.sql` - Script completo para Oracle FIAP (inclui dados de teste)
- `docs/database/challenge_oracle2_fixed.sql` - Script original do challenge

### H2 (Desenvolvimento Local)
Para desenvolvimento local, a aplicação usa H2 em memória que cria automaticamente as tabelas.

## Testando a API

### 1. Verificar se a aplicação está rodando
```bash
# Health check
curl http://localhost:8080/actuator/health

# Swagger UI
# Acesse: http://localhost:8080/swagger-ui.html
```

### 2. Testar Endpoints

#### Criar Cliente
```bash
curl -X POST http://localhost:8080/fiap/clientes \
  -H "Content-Type: application/json" \
  -d '{
    "nomeCliente": "João Silva",
    "cpfCnpj": "12345678901",
    "email": "joao@email.com",
    "senha": "senha123",
    "ativo": "S"
  }'
```

#### Listar Clientes
```bash
curl -X GET "http://localhost:8080/fiap/clientes?page=0&size=10&direction=ASC"
```

#### Criar Centro de Custo
```bash
curl -X POST http://localhost:8080/fiap/centros-custo \
  -H "Content-Type: application/json" \
  -d '{
    "nomeCentroCusto": "Vendas Online"
  }'
```

### 3. Verificar Dados no Banco

#### Oracle FIAP
```sql
-- Verificar clientes
SELECT * FROM CLIENTE ORDER BY id_cliente;

-- Verificar centros de custo
SELECT * FROM CENTRO_CUSTO ORDER BY id_centro_custo;

-- Verificar sequences
SELECT 'CLIENTE_SEQ' as SEQUENCE_NAME, CLIENTE_SEQ.CURRVAL as CURRENT_VALUE FROM DUAL;
```

#### H2 Console
- URL: http://localhost:8080/h2-console
- JDBC URL: `jdbc:h2:mem:finance-control-db`
- Username: `sa`
- Password: (vazio)

## Status do Projeto

✅ **Implementação Completa**
- [x] Estrutura base do projeto Spring Boot
- [x] 5 entidades JPA com relacionamentos
- [x] Repositories com métodos customizados
- [x] DTOs de Request/Response com validações
- [x] Services para operações CRUD
- [x] Controllers REST com paginação
- [x] Tratamento global de exceções
- [x] Documentação completa
- [x] Testes unitários
- [x] Configuração para Oracle FIAP e H2

## Funcionalidades Implementadas

### ✅ Entidades
- **Cliente**: Gestão de clientes com validações de CPF/CNPJ e email únicos
- **CentroCusto**: Centros de custo para organização contábil
- **Conta**: Contas contábeis (Receita/Despesa) com relacionamento opcional com cliente
- **RegistroContabil**: Lançamentos contábeis com auditoria automática
- **Vendas**: Registro de vendas vinculadas a clientes e registros contábeis

### ✅ API RESTful
- **Nível 1 Richardson Maturity Model**
- **Paginação** em todos os endpoints de listagem
- **Filtros** por nome, tipo, data, valor
- **Validações** Bean Validation
- **Status HTTP** apropriados (200, 201, 204, 400, 404, 409, 500)

### ✅ Arquitetura
- **POO**: Encapsulamento, herança, polimorfismo
- **Coesão**: Cada classe com responsabilidade única
- **Desacoplamento**: Controllers → Services → Repositories
- **Padrões**: Repository, Service Layer, DTO, Strategy

## Contribuição

Este é um projeto acadêmico do curso de Engenharia de Software da FIAP.

## Licença

Este projeto está sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.

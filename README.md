# 👋 Sobre o Autor

O autor, [Otávio Villas Boas Simoncini Carmanini](https://www.linkedin.com/in/otaviovillasboassimoncinicarmanini/), buscou criar esse repositório para reproduzir os conhecimentos adquiridos ao longo do seu processo de desenvolvimento, assim como, aplicar discussões e trade-off's discutidos em mentorias coordenadas por [Marcelo Castelo Branco](https://www.linkedin.com/in/marcelocastelobranco/). Vale lembrar, que esse repositório, busca esclarecer o máximo de questões possíveis que podem ocorrer acerca do projeto de desenvolvimento, de modo que tenha um **caráter analítico** quanto a modelagem dos dados, a componentização dos microsserviços, o uso de certos padrões e suas relações com requisitos funcionais e não funcionais.

Desse modo, ao longo dessa wiki, buscarei colocar diferentes pontos de vistas e soluções para o mesmo problema, assim como, obter dados factuais para a escolha de certos processos de não funcionais.


# 📌 Objetivo do Projeto

O **objetivo** desse projeto é aplicar os principais conceitos utilizados em conjunto a arquitetura de microsserviços, como forma de compreender e visar os reais motivos para utilização de cada padrão a fim de entender quais são suas consequências e o que elas tem de oferecer de melhor. Vale ressaltar, que a ideia é explicar **O que**, o **Porquê**, a **Finalidade** e a **Consequência**.

# ⚙️ Como rodar o projeto

## Pré-Requisitos
- .NET 7 SDK Instalado.
- Docker instalado.
- Conhecimento básicos de Docker e C#/.NET

## Executando

Para rodar o projeto, primeramente, é necessário `que você clone o projeto na sua máquina para assim conseguir rodar as dependências externas e as aplicações:

```
git clone https://github.com/otaviovb/ovb.demos.ecommerce
```

Após rodar o projeto, entre na pasta da solução:

```
cd OVB.Demos.Ecommerce
```

Com a pasta da solução em aberto, comece executando o **Docker Compose** para implantação das dependências necessárias:

```
docker compose up -d
```

Nesse momento é necessário a definição dos appsettings.json para cada microsserviço/workerservice/apigateway:

Microsservice Account: OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc
```json
{
  "Infrascructure": {
    "Messenger": {
      "RabbitMQ": {
        "Hostname": "localhost",
        "Virtualhost": "/",
        "Username": "guest",
        "Password": "guest",
        "Port": "5672",
        "ClientProviderName": "OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc"
      }
    },
    "Databases": {
      "EntityFrameworkCore": {
        "PostgreeSQL": {
          "ConnectionString": "User Id=admin;Password=1234;Server=localhost;Port=5432;Database=ovbdemosecommerceaccountmanagement",
          "MigrationsAssembly": "OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure",
          "ServiceName": "Microsserviço de Conta - PostgreeSQL",
          "ServiceDescription": "Serviço para acesso e armazenamento de dados.",
          "ServiceVersion": "15.2.0"
        }
      }
    }
  }
}
```

Agora é possível que você rode cada microsserviço/apigateway/workerservice:

```
dotnet run --project "src/Account/OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc"
```

```
dotnet run --project "src/ApiGateway/OVB.Demos.Ecommerce.Microsservices.ApiGateway.WebApi"
```

# 🧑‍🤝‍🧑 Autor

[Otávio Villas Boas Simoncini Carmanini](https://www.linkedin.com/in/otaviovillasboassimoncinicarmanini/)

## Tecnologias Utilizadas
- ASP. NET Core 7
- .NET 7
- Entity Framework Core 7
- Postgree SQL
- Postgree Admin
- Open Telemetry
- Jaeger
- Prometheus
- RabbitMq
- Docker/Docker-Compose
- gRPC

## Conceitos Aplicados
- MultTenant
- Repository Pattern
- Adapter Pattern
- Notification Pattern
- Builder Pattern
- Unit Of Work Pattern
- Singleton Pattern
- Command Handler Pattern
- Command Pattern
- Database Transactions
- Microsservices Architecture
- Architecture in Layers
- Rich Domain
- Orchestration Services
- Choreography Services
- SOLID Principles
- Dependency Injection
- Async Operations
- Continuous Deployment/Continuous Integration
- Data Pagination
- Api Versioning
- Messenger
- Health Checks
- Eventual Consistency
- Command Query Responsability Segregation (CQRS)
- Retry Pattern
- Resilience Policies
- Circuit Breaker Pattern
- Protobuf Binary Serialization (Faster than JsonSerializer or other libraries)
- Worker Services
- gRPC Communication Services
- Observability: Trace
- Observability: Metrics
- Open Telemetry Collector Agent
- Api Gateway
- Domain Driven Design
- Unit Tests
- Integration Test

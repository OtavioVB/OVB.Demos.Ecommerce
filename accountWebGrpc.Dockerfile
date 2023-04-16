#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5200

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Account/OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc/OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc.csproj", "src/Account/OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc/"]
COPY ["src/Account/OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application/OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.csproj", "src/Account/OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application/"]
COPY ["Libraries/OVB.Demos.Ecommerce.Libraries.Domain.Serializator/OVB.Demos.Ecommerce.Libraries.Domain.Serializator.csproj", "Libraries/OVB.Demos.Ecommerce.Libraries.Domain.Serializator/"]
COPY ["Libraries/OVB.Demos.Ecommerce.Libraries.Infrascructure.CircuitBreaker/OVB.Demos.Ecommerce.Libraries.Infrascructure.CircuitBreaker.csproj", "Libraries/OVB.Demos.Ecommerce.Libraries.Infrascructure.CircuitBreaker/"]
COPY ["src/Account/OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure/OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.csproj", "src/Account/OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure/"]
COPY ["Libraries/OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks/OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks.csproj", "Libraries/OVB.Demos.Ecommerce.Libraries.Infrascructure.HealthChecks/"]
COPY ["Libraries/OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ/OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.csproj", "Libraries/OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ/"]
COPY ["Libraries/OVB.Demos.Ecommerce.Libraries.Infrascructure.RetryPattern/OVB.Demos.Ecommerce.Libraries.Infrascructure.RetryPattern.csproj", "Libraries/OVB.Demos.Ecommerce.Libraries.Infrascructure.RetryPattern/"]
COPY ["src/Account/OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain/OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.csproj", "src/Account/OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain/"]
COPY ["Libraries/OVB.Demos.Ecommerce.Libraries.Domain/OVB.Demos.Ecommerce.Libraries.Domain.csproj", "Libraries/OVB.Demos.Ecommerce.Libraries.Domain/"]
RUN dotnet restore "src/Account/OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc/OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc.csproj"
COPY . .
WORKDIR "/src/src/Account/OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc"
RUN dotnet build "OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc.dll"]
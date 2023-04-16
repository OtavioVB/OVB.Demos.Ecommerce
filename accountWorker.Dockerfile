#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Account/OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker/OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.csproj", "src/Account/OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker/"]
COPY ["Libraries/OVB.Demos.Ecommerce.Libraries.Domain.Serializator/OVB.Demos.Ecommerce.Libraries.Domain.Serializator.csproj", "Libraries/OVB.Demos.Ecommerce.Libraries.Domain.Serializator/"]
COPY ["Libraries/OVB.Demos.Ecommerce.Libraries.Domain/OVB.Demos.Ecommerce.Libraries.Domain.csproj", "Libraries/OVB.Demos.Ecommerce.Libraries.Domain/"]
COPY ["Libraries/OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ/OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.csproj", "Libraries/OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ/"]
COPY ["src/Account/OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain/OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.csproj", "src/Account/OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain/"]
RUN dotnet restore "src/Account/OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker/OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.csproj"
COPY . .
WORKDIR "/src/src/Account/OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker"
RUN dotnet build "OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.dll"]
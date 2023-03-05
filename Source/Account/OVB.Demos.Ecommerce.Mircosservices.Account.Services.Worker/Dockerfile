FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app-worker

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src-worker
COPY ["Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.Services.Worker.csproj", "Source/Account/OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker/"]
COPY ["Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter/OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter.csproj", "Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter/"]
COPY ["Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Domain.Serialization/OVB.Demos.Ecommerce.Microsservices.Base.Domain.Serialization.csproj", "Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Domain.Serialization/"]
COPY ["Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability/OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.csproj", "Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability/"]
COPY ["Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ/OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.csproj", "Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ/"]
COPY ["Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.Domain.Protobuffer/OVB.Demos.Ecommerce.Microsservices.Account.Domain.Protobuffer.csproj", "Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.Domain.Protobuffer/"]
COPY ["Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.Domain/OVB.Demos.Ecommerce.Microsservices.Account.Domain.csproj", "Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.Domain/"]
COPY ["Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification/OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.csproj", "Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification/"]
COPY ["Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Domain/OVB.Demos.Ecommerce.Microsservices.Base.Domain.csproj", "Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Domain/"]
RUN dotnet restore "Source/Account/OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker/OVB.Demos.Ecommerce.Microsservices.Account.Services.Worker.csproj"
COPY . .
WORKDIR "/src-worker/Source/Account/OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker"
RUN dotnet build "OVB.Demos.Ecommerce.Microsservices.Account.Services.Worker.csproj" -c Release -o /app-worker/build

FROM build AS publish
RUN dotnet publish "OVB.Demos.Ecommerce.Microsservices.Account.Services.Worker.csproj" -c Release -o /app-worker/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app-worker
COPY --from=publish /app-worker/publish .
ENTRYPOINT ["dotnet", "OVB.Demos.Ecommerce.Microsservices.Account.Services.Worker.dll"]
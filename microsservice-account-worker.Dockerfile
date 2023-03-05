FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /Source
COPY ["./Source/Account/OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker/OVB.Demos.Ecommerce.Microsservices.Account.Services.Worker.csproj", "Source/Account/OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker/"]
COPY ["./Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter/OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter.csproj", "Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter/"]
COPY ["./Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Domain.Serialization/OVB.Demos.Ecommerce.Microsservices.Base.Domain.Serialization.csproj", "Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Domain.Serialization/"]
COPY ["./Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability/OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.csproj", "Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability/"]
COPY ["./Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ/OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.csproj", "Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ/"]
COPY ["./Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.Domain.Protobuffer/OVB.Demos.Ecommerce.Microsservices.Account.Domain.Protobuffer.csproj", "Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.Domain.Protobuffer/"]
COPY ["./Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.Domain/OVB.Demos.Ecommerce.Microsservices.Account.Domain.csproj", "Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.Domain/"]
COPY ["./Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification/OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.csproj", "Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification/"]
COPY ["./Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Domain/OVB.Demos.Ecommerce.Microsservices.Base.Domain.csproj", "Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Domain/"]
RUN dotnet restore "Source/Account/OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker/OVB.Demos.Ecommerce.Microsservices.Account.Services.Worker.csproj"
COPY . .
RUN dotnet build "Source/Account/OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker/OVB.Demos.Ecommerce.Microsservices.Account.Services.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Source/Account/OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker/OVB.Demos.Ecommerce.Microsservices.Account.Services.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OVB.Demos.Ecommerce.Microsservices.Account.Services.Worker.dll"]
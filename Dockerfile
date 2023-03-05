FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 81
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /Source
COPY ["./Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.WebGrpc/OVB.Demos.Ecommerce.Microsservices.Account.WebGrpc.csproj", "Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.WebGrpc/"]
COPY ["./Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability/OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.csproj", "Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability/"]
COPY ["./Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ/OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ.csproj", "Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.RabbitMQ/"]
COPY ["./Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry/OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.csproj", "Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry/"]
COPY ["./Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.Application.Services/OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.csproj", "Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.Application.Services/"]
COPY ["./Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter/OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter.csproj", "Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter/"]
COPY ["./Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Domain.Serialization/OVB.Demos.Ecommerce.Microsservices.Base.Domain.Serialization.csproj", "Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Domain.Serialization/"]
COPY ["./Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.Domain.Protobuffer/OVB.Demos.Ecommerce.Microsservices.Account.Domain.Protobuffer.csproj", "Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.Domain.Protobuffer/"]
COPY ["./Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.Domain/OVB.Demos.Ecommerce.Microsservices.Account.Domain.csproj", "Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.Domain/"]
COPY ["./Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification/OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.csproj", "Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification/"]
COPY ["./Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Domain/OVB.Demos.Ecommerce.Microsservices.Base.Domain.csproj", "Source/Base/OVB.Demos.Ecommerce.Microsservices.Base.Domain/"]
COPY ["./Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data/OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.csproj", "Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data/"]
COPY ["./Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.UnitOfWork/OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.UnitOfWork.csproj", "Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.UnitOfWork/"]
RUN dotnet restore "Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.WebGrpc/OVB.Demos.Ecommerce.Microsservices.Account.WebGrpc.csproj"
COPY . .
RUN dotnet build "Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.WebGrpc/OVB.Demos.Ecommerce.Microsservices.Account.WebGrpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Source/Account/OVB.Demos.Ecommerce.Microsservices.Account.WebGrpc/OVB.Demos.Ecommerce.Microsservices.Account.WebGrpc.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OVB.Demos.Ecommerce.Microsservices.Account.WebGrpc.dll"]
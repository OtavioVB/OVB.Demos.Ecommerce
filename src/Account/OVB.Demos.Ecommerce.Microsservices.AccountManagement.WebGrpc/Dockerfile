#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Account/OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc/OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc.csproj", "src/Account/OVB.Demos.Ecommerce.Microsservices.AccountManagement.WebGrpc/"]
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
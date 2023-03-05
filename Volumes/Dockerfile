FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /Source
COPY ["../Source/Account/OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker/OVB.Demos.Ecommerce.Microsservices.Account.Services.Worker.csproj", "Source/Account/OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker/"]
RUN dotnet restore "/Source/Account/OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker/OVB.Demos.Ecommerce.Microsservices.Account.Services.Worker.csproj"
COPY . .
RUN dotnet build "/Source/Account/OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker/OVB.Demos.Ecommerce.Microsservices.Account.Services.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OVB.Demos.Ecommerce.Microsservices.Account.Services.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OVB.Demos.Ecommerce.Microsservices.Account.Services.Worker.dll"]
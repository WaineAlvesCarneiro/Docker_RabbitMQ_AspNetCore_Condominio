FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CondominioSaaS.Worker/CondominioSaaS.Worker.csproj", "CondominioSaaS.Worker/"]
COPY ["CondominioSaaS.Domain/CondominioSaaS.Domain.csproj", "CondominioSaaS.Domain/"]
COPY ["CondominioSaaS.Infrastructure/CondominioSaaS.Infrastructure.csproj", "CondominioSaaS.Infrastructure/"]
COPY ["CondominioSaaS.Application/CondominioSaaS.Application.csproj", "CondominioSaaS.Application/"]
RUN dotnet restore "./CondominioSaaS.Worker/CondominioSaaS.Worker.csproj"
COPY . .
WORKDIR "/src/CondominioSaaS.Worker"
RUN dotnet build "./CondominioSaaS.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CondominioSaaS.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CondominioSaaS.Worker.dll"]
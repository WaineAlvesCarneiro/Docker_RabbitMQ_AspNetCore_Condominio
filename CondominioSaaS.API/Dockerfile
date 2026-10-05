FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8081

RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["CondominioSaaS.API/CondominioSaaS.API.csproj", "CondominioSaaS.API/"]
COPY ["CondominioSaaS.Application/CondominioSaaS.Application.csproj", "CondominioSaaS.Application/"]
COPY ["CondominioSaaS.Domain/CondominioSaaS.Domain.csproj", "CondominioSaaS.Domain/"]
COPY ["CondominioSaaS.Configurations/CondominioSaaS.Configurations.csproj", "CondominioSaaS.Configurations/"]
COPY ["CondominioSaaS.Infrastructure/CondominioSaaS.Infrastructure.csproj", "CondominioSaaS.Infrastructure/"]

RUN dotnet restore "./CondominioSaaS.API/CondominioSaaS.API.csproj"
COPY . .
WORKDIR "/src/CondominioSaaS.API"
RUN dotnet build "./CondominioSaaS.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CondominioSaaS.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:8081

ENTRYPOINT ["dotnet", "CondominioSaaS.API.dll"]

HEALTHCHECK --interval=30s --timeout=10s --start-period=120s --retries=3 \
  CMD curl -f http://localhost:8081/health || exit 1
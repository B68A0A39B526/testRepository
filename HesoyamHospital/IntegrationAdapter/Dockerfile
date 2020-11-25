FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS integration-build

WORKDIR /app

COPY IntegrationAdapter/*.csproj IntegrationAdapter/

COPY Backend/*.csproj Backend/

WORKDIR /app/IntegrationAdapter

RUN dotnet restore IntegrationAdapter.csproj

WORKDIR /app

COPY IntegrationAdapter/. /IntegrationAdapter

COPY Backend/. Backend/
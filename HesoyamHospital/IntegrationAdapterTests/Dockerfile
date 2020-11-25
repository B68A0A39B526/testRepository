FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS integration-build

WORKDIR /app

COPY IntegrationAdapter/*.csproj IntegrationAdapter/

COPY IntegrationAdapterTests/*.csproj IntegrationAdapterTests/

COPY Backend/*.csproj Backend/

WORKDIR /app/IntegrationAdapterTests

RUN dotnet restore IntegrationAdapterTests.csproj

WORKDIR /app

COPY IntegrationAdapter/. /IntegrationAdapter

COPY IntegrationAdapterTests/. /IntegrationAdapterTests

COPY Backend/. Backend/

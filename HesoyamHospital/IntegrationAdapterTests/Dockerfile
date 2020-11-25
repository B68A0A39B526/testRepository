FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS integration-build

WORKDIR /app/IntegrationAdapter

COPY ./IntegrationAdapter/IntegrationAdapter.csproj .

WORKDIR /app/IntegrationAdapterTests

COPY ./IntegrationAdapterTests/IntegrationAdapterTests.csproj .

WORKDIR /app/Backend

COPY ./Backend/Backend.csproj .

WORKDIR /app/IntegrationAdapterTests

RUN dotnet restore IntegrationAdapterTests.csproj

WORKDIR /app/IntegrationAdapter

COPY ./IntegrationAdapter/. .

WORKDIR /app/IntegrationAdapterTests

COPY ./IntegrationAdapterTests/. .

WORKDIR /app/Backend

COPY ./Backend/. .

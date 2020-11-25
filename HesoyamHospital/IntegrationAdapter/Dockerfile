FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS integration-build

WORKDIR /app/IntegrationAdapter

COPY ./IntegrationAdapter/IntegrationAdapter.csproj .

WORKDIR /app/Backend

COPY ./Backend/Backend.csproj .

WORKDIR /app/IntegrationAdapter

RUN dotnet restore IntegrationAdapter.csproj

WORKDIR /app/IntegrationAdapter

COPY ./IntegrationAdapter/. .

WORKDIR /app/Backend

COPY ./Backend/. .

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS integration-build

WORKDIR /app/IntegrationAdapter

COPY IntegrationAdapter.csproj .

WORKDIR /app/Backend

COPY ../Backend/Backend.csproj .

WORKDIR /app/IntegrationAdapter

RUN dotnet restore IntegrationAdapter.csproj

WORKDIR /app/IntegrationAdapter

COPY . .

WORKDIR /app/Backend

COPY ../Backend/. .

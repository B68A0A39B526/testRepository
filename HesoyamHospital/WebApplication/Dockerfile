FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS web-build

WORKDIR /app

COPY WebApplication/*.csproj WebApplication/

COPY Backend/*.csproj Backend/

WORKDIR /app/WebApplication

RUN dotnet restore WebApplication.csproj

WORKDIR /app

COPY WebApplication/. /WebApplication

COPY Backend/. Backend/
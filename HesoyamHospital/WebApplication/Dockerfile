FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS web-build

WORKDIR /app/WebApplication

COPY ./WebApplication/WebApplication.csproj .

WORKDIR /app/Backend

COPY ./Backend/Backend.csproj .

WORKDIR /app/WebApplication

RUN dotnet restore WebApplication.csproj

WORKDIR /app/WebApplication

COPY ./WebApplication/. .

WORKDIR /app/Backend

COPY ./Backend/. .

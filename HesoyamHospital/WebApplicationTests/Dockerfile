FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS web-build

WORKDIR /app/WebApplication

COPY ./WebApplication/*.csproj .

WORKDIR /app/Backend

COPY ./Backend/*.csproj .

WORKDIR /app/WebApplicationTests

COPY ./WebApplicationTests/*.csproj .

WORKDIR /app/WebApplicationTests

RUN dotnet restore WebApplicationTests.csproj

WORKDIR /app/WebApplication

COPY ./WebApplication/. .

WORKDIR /app/Backend

COPY ./Backend/. .

WORKDIR /app/WebApplicationTests

COPY ./WebApplicationTests/. .


FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS web-build

WORKDIR /app

COPY WebApplication/*.csproj WebApplication/

COPY Backend/*.csproj Backend/

COPY WebApplicationTests/*.csproj WebApplicationTests/

WORKDIR /app/WebApplicationTests

RUN dotnet restore WebApplicationTests.csproj

WORKDIR /app

COPY WebApplication/. /WebApplication

COPY Backend/. Backend/

COPY WebApplicationTests/. WebApplicationTests/


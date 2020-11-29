# FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS web-build

# WORKDIR /app/WebApplication

# COPY ./WebApplication/WebApplication.csproj .

# WORKDIR /app/Backend

# COPY ./Backend/Backend.csproj .

# WORKDIR /app/WebApplicationTests

# COPY ./WebApplicationTests/WebApplicationTests.csproj .

# WORKDIR /app/WebApplicationTests

# RUN dotnet restore WebApplicationTests.csproj

# WORKDIR /app/WebApplication

# COPY ./WebApplication/. .

# WORKDIR /app/Backend

# COPY ./Backend/. .

# WORKDIR /app/WebApplicationTests

# COPY ./WebApplicationTests/. .

# FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS dependency-build

# WORKDIR /app/WebApplication

# COPY ./WebApplication/bin/Release/netcoreapp3.1/ ./WebApplication
# COPY ./WebApplication ./WebApplication

# COPY ./WebApplicationTests/bin/Release/netcoreapp3.1/ ./WebApplicationTests
# COPY ./WebApplicationTests ./WebApplicationTests

FROM node:10-alpine as build

RUN mkdir -p /app

WORKDIR /app

COPY ./web-application-front/package.json .

RUN npm install

COPY ./web-application-front .

RUN npm run build --prod


FROM nginx:1.17.1-alpine

COPY --from=build /app/docs /usr/share/nginx/html

EXPOSE 80
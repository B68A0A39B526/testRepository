FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS web-build

WORKDIR /app/WebApplication

COPY ./WebApplication/. .

WORKDIR /app/Backend

COPY ./Backend/. .

WORKDIR /app/WebApplication

RUN dotnet build WebApplication.csproj

WORKDIR /app/WebApplication

RUN dotnet publish WebApplication.csproj -c Release -o out




FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.5

WORKDIR /app

COPY --from=web-build /app/WebApplication/out .

EXPOSE 5000

#RUN useradd -u 1000 john

#USER john

ENTRYPOINT ["dotnet", "WebApplication.dll"]

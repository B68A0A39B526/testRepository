FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine

WORKDIR /app

COPY ./IntegrationAdapter/bin/Release/netcoreapp3.1/ .
COPY ./IntegrationAdapter .

ENTRYPOINT [ "dotnet", "IntegrationAdapter.dll" ]
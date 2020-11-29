FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine

WORKDIR /app

COPY ./IntegrationAdapterTests/bin/Release/netcoreapp3.1/ .
COPY ./IntegrationAdapterTests .

ENTRYPOINT [ "dotnet", "IntegrationAdapterTests.dll" ]

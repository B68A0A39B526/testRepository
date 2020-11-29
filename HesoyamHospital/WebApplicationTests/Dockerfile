FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine

COPY ./WebApplicationTests/bin/Release/netcoreapp3.1/ .
COPY ./WebApplicationTests .


ENTRYPOINT [ "dotnet", "IntegrationAdapterTests.dll" ]
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.5

WORKDIR /app

COPY ./Backend/bin/Release/netcoreapp3.1/ .
COPY ./Backend .

EXPOSE 5000

#RUN useradd -u 1000 john

#USER john

ENTRYPOINT ["dotnet", "Backend.dll"]


FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build-env

WORKDIR /app

COPY ./Backend/Backend.csproj .

RUN dotnet restore Backend.csproj

COPY ./Backend/. .

RUN dotnet publish Backend.csproj -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.5

WORKDIR /app

COPY --from=build-env /app/out .

EXPOSE 80

#RUN useradd -u 1000 john

#USER john

ENTRYPOINT ["dotnet", "Backend.dll"]


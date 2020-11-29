FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.5

# RUN groupadd -g 1024 appuser && \
#     useradd -r -u 1024 -g appuser appuser

# USER appuser

WORKDIR /app

COPY ./WebApplication/bin/Release/netcoreapp3.1/ .
COPY ./WebApplication .

EXPOSE 80



ENTRYPOINT ["dotnet", "WebApplication.dll"]
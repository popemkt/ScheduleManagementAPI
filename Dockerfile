FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY /src/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet ColdSchedulesAPI.dll
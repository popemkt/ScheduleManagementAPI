# NuGet restore
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY . .

RUN dotnet restore

# publish
FROM build AS publish
WORKDIR /src
RUN dotnet publish ColdSchedules.sln -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet ColdSchedulesAPI.dll
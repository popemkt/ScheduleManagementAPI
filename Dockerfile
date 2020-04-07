# NuGet restore
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY . .
# COPY Colors.UnitTests/*.csproj Colors.UnitTests/
# COPY Colors.API/*.csproj Colors.API/
RUN dotnet restore

# publish
FROM build AS publish
WORKDIR /src
RUN dotnet publish ColdSchedules.sln -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
ENTRYPOINT ["dotnet", "ColdSchedulesAPI.dll"]
# heroku uses the following
# CMD ASPNETCORE_URLS=http://*:$PORT dotnet Colors.API.dll
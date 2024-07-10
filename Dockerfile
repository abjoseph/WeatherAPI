# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src/WeatherApi

# copy csproj and restore as distinct layers
COPY src/**/*.csproj ./
RUN dotnet restore --force --force-evaluate -v d

# copy everything else and build app
COPY src/WeatherApi/. ./
RUN dotnet publish -c release -o app  --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /src/WeatherApi/app ./

EXPOSE 3000

ENTRYPOINT ["dotnet", "WeatherApi.dll", "--urls", "http://0.0.0.0:3000"]

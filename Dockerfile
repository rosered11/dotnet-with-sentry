# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

WORKDIR /app

COPY . .

RUN dotnet tool restore
RUN dotnet restore

RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0

# Expose port for Heroku
ENV ASPNETCORE_URLS=http://+:$PORT

WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "Dotnet.With.Sentry.dll"]
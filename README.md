# dotnet-with-sentry

# Recommend

If you create new project, and use paket. You should convert nuget to paket config also.

## These script you maybe use

- `dotnet new tool-manifest`
- `dotnet tool install paket`
- `dotnet paket init`
- `dotnet paket convert-from-nuget`
- `dotnet paket add {your_nuget} -i`

## Paket on container
If you run paket on container, you must to run `dotnet tool restore` also.

# Reference 

- https://www.youtube.com/watch?v=6ga1nu0BgCs
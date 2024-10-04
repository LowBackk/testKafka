#Use the official .NET SDK image from Microsoft (Linux-based)
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY . .

# Restore dependencies and build the project
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Use the runtime image for Linux
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app

COPY --from=build-env /app/out .

# Expose port if needed (for a web API or other service)
EXPOSE 80

ENTRYPOINT ["dotnet", "YourApp.dll"]
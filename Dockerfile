# Use the official Microsoft .NET SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy the entire solution
COPY . .

# Restore the specific project
RUN dotnet restore "src/RainfallApi.Host/RainfallApi.Host.csproj"

# Build the project
WORKDIR "/app/src/RainfallApi.Host"
RUN dotnet build "RainfallApi.Host.csproj" -c Release -o /app/build

# Publish the project
FROM build-env AS publish
RUN dotnet publish "RainfallApi.Host.csproj" -c Release -o /app/publish

# Generate the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RainfallApi.Host.dll"]

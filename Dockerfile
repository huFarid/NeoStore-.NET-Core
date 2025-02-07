# Use the official .NET 8.0 SDK image for building the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["NeoStore.csproj", "./"]
RUN dotnet restore

# Copy everything else and build the application
COPY . .
RUN dotnet build -c Release -o /app/build

# Publish the application
RUN dotnet publish -c Release -o /app/publish

# Use the official ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the published app from the build stage
COPY --from=build /app/publish .

# Expose the port 
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "NeoStore.dll"]

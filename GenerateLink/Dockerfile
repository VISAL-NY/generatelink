cd #See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
# Use the ASP.NET runtime image as the base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GenerateLink/GenerateLink.csproj", "GenerateLink/"]
RUN dotnet restore "GenerateLink/GenerateLink.csproj"
COPY . .
WORKDIR "/src/GenerateLink"
RUN dotnet build "GenerateLink.csproj" -c Release -o /app/build

# Publish the app to the /app/publish directory
FROM build AS publish
RUN dotnet publish "GenerateLink.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Create the final image using the base runtime image
FROM base AS final
WORKDIR /app

# Copy the published app files
COPY --from=publish /app/publish .

# Copy the appsettings.json file to the app directory
COPY ["GenerateLink/appsettings.json", "/app/appsettings.json"]

# Set the entry point to run the application
ENTRYPOINT ["dotnet", "GenerateLink.dll"]




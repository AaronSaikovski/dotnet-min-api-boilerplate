# Use the official .NET Core SDK as a parent image
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build-env
WORKDIR /app

# Copy the project file and restore any dependencies (use .csproj for the project name)
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . ./

# Publish the application
RUN dotnet publish -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy-chiseled as runtime
EXPOSE 8080
WORKDIR /app
COPY --from=build-env /app/out .

#change this to your dll name
ENTRYPOINT ["dotnet", "dotnet-minapi-boilerplate.dll"]
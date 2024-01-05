# Use the official .NET Core SDK as a parent image
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build-env
#FROM mcr.microsoft.com/dotnet/sdk:8.0.100-bookworm-slim AS build-build-env

WORKDIR /app

# Copy the project file and restore any dependencies (use .csproj for the project name)
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . ./

# Publish the application
RUN dotnet publish -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine as runtime
WORKDIR /app
COPY --from=build-env /app/out .

# Expose the port your application will run on
EXPOSE 8080/tcp

#change this to your dll name
ENTRYPOINT ["dotnet", "dotnet-minapi-boilerplate.dll"]
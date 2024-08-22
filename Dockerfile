# Use the official .NET Core SDK as a parent image
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-jammy AS build-env
WORKDIR /app

# Copy the project file and restore any dependencies
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

# Set environment to production
ENV ASPNETCORE_ENVIRONMENT=Production

# Use the appropriate entry point for a .NET application
ENTRYPOINT ["./dotnet-minapi-boilerplate"]
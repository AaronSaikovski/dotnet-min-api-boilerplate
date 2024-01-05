# dotnet-minapi-boilerplate

A `.Net 8.0` Minimal WebApi boilerplate starter project. Includes Swagger, Serilog and Docker support. This is designed to be as bare bones as possible to get you started with minimal APIs in .Net 8.0.
The goal of this project is to be an way to kick start your .Net 8.0 WebApi projects to get you going quicker. The goal is to be as lean and trimmed as possible to make things easy when building Web APIs in .Net 8.0.

# How to get started

- Use this template(github) or clone/download to your local machine.
- Download the latest .Net 8 SDK.
- Use your favourite IDE - Visual Studio/Code/JetBrains Rider.

## Standalone

1. You can simply run in debug mode locally to test things out `dotnet run`.
   The intention is to keep this as simple and as lean as possible.

## Docker

1. Run `docker-compose up` in the root directory, or, in visual studio, set the docker-compose project as startup and run. This should start the application.

- For docker-compose, you should run this command on the root folder: `dotnet dev-certs https -ep https/aspnetapp.pfx -p yourpassword`
     Replace "yourpassword" with something else in this command and the docker-compose.override.yml file.
     This creates the https certificate.

2. Visit https://localhost:7289/swagger/index.html to access the APIs's swagger description.

# This project contains:

- SwaggerUI
- Serilog
- Minimal API (.Net 8.0)
- CI (Github Actions)
- Unit tests
- Container support with [docker](Dockerfile) and [docker-compose](docker-compose.yml)
- NuGet Central package management (CPM)

# Project Structure

1. endpoints

   - This folder is where you set your endpoints via routes - refer to SampleEndpoints.cs for some examples of this.

2. extensions

   - This folder is where the services and middleware are registered with the Web API.

3. middleware

   - This folder is where the middleware handlers are for supporting API key validation. Looks for a header value `XApiKey` to be set. Please dont save API keys in your project!

4. common

   - This folder contains the config and logger helper services in their own subfolders.
   - config - reads from the `appsettings.Development.json` and `appsettings.json` files based on current build configuration - Debug vs. release
   - logger - provides the shared serilog logging module that provides detailed logging services to the API. The logging settings are set in the `appsettings.json` and `appsettings.Development.json`

5. Program.cs (root folder) 
   
   - This is the main entry point for the API and is pretty self explanatory. There is minimal code in here for maintainability purposes. There are base level service healthchecks that are setup in here as part of the API startup process.

# Adopting to your project

1. Remove/Rename all `dotnet_minapi_boilerplate` references and rename to your project needs.
2. Rename solution, projects, namespaces, to suit.
3. Change the dockerfile and docker-compose.yml to your new csproj/folder names.

# Known issues

1. There are no unit tests and these will come in the next release.
2. There is no JWT or Auth support and this will come in a future release.
   
  Please report any issues [here](https://github.com/AaronSaikovski/dotnet-min-api-boilerplate/issues).

# Future developments

1. API Versioning support.
2. OpenTelemetry integration.
3. Auth and Authorisation support.
4. Database support for MS SQL - Dapper or Entity Framework.
5. Ahead of Time (AOT) native compilation support.

# If you like it, give it a Star

If this template was useful for you, or if you learned something, please give it a Star! :star:

# Thanks

This project was influenced by https://github.com/yanpitangui/dotnet-api-boilerplate/ and https://github.com/lkurzyniec/netcore-boilerplate and https://github.com/EduardoPires/EquinoxProject.

# About

This boilerplate/template was developed by Aaron Saikovski under the [MIT license](LICENSE).

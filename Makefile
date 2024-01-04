.DEFAULT_GOAL := help
.PHONY: clean build run release test test-watch rebuild-docker restart-docker log log-watch install-tools help 

clean: ## cleans the solution
	dotnet clean
	rm -rf ./bin/*

build: ## builds the solution
	dotnet build

run: ## runs the solution
	dotnet run

release: ## releases the app
	dotnet restore
	dotnet publish -c Release -r win-x64
	dotnet publish -c Release -r win-arm64
	dotnet publish -c Release -r linux-x64
	dotnet publish -c Release -r linux-arm64
	dotnet publish -c Release -r linux-musl-arm64
	dotnet publish -c Release -r osx-arm64	

test: ## runs all tests in solution
	dotnet test ./test/test.csproj

test-xunit: ## runs all tests in solution usint dotnet-xunit tool
	cd test && dotnet xunit -fxversion 2.1.5

test-watch: ## starts the file watcher and runs all tests in solution every time any file changes
	dotnet watch -p ./test/test.csproj test --no-restore 

test-xunit-watch: ## starts the file watcher and runs all tests in solution usint dotnet-xunit tool every time any file changes
	cd test && dotnet watch xunit -fxversion 2.1.5

rebuild-docker: ## rebuilds and restarts docker containers
	docker-compose down
	docker-compose build --no-cache
	docker-compose up -d

restart-docker: ## restarts docker containers
	docker-compose down
	docker-compose up -d

log: ## shows sut docker logs
	docker logs sut --tail 50

log-watch: ## watches sut docker logs
	docker logs sut --tail 50 -f

install-tools: ## installs required dev tools
	dotnet tool install -g FluentMigrator.DotNet.Cli

help:
	@grep -E '^[a-zA-Z_-]+:.*?## .*$$' $(MAKEFILE_LIST) | awk 'BEGIN {FS = ":.*?## "}; {printf "\033[36m%-30s\033[0m %s\n", $$1, $$2}'
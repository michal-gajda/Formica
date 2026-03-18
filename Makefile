build:
	dotnet build --configuration Release src/WebApi/Formica.WebApi.csproj

run:
	dotnet run --project src/WebApi/Formica.WebApi.csproj --configuration Release

test:
	dotnet test --configuration Release tests/WebUI.E2ETests/Formica.WebUI.E2ETests.csproj

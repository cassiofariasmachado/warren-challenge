FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

HEALTHCHECK --interval=3s --timeout=5s --retries=5 CMD [ "curl --fail http://localhost:80/health || exit" ]

COPY Warren.Banking.sln Warren.Banking.sln
COPY src/Warren.Banking.Api/*.csproj src/Warren.Banking.Api/
COPY src/Warren.Banking.Core/*.csproj src/Warren.Banking.Core/
COPY src/Warren.Banking.Infra/*.csproj src/Warren.Banking.Infra/
COPY test/Warren.Banking.Core.Test/*.csproj test/Warren.Banking.Core.Test/
COPY Warren.Banking.sln Warren.Banking.sln

RUN dotnet restore

COPY src ./src
COPY test ./test
RUN dotnet publish -c Release -o publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Warren.Banking.Api.dll"]
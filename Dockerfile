FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY CrediAuto.API/*.csproj ./CrediAuto.API/
RUN dotnet restore ./CrediAuto.API/CrediAuto.API.csproj

COPY CrediAuto.API/. ./CrediAuto.API/
WORKDIR /src/CrediAuto.API
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["sh", "-c", "ASPNETCORE_URLS=http://+:$PORT dotnet CrediAuto.API.dll"]

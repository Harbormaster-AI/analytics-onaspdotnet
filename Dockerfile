FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY analyticsonaspdotnet/Api.csproj analyticsonaspdotnet/
RUN dotnet restore analyticsonaspdotnet/Api.csproj

COPY analyticsonaspdotnet/ analyticsonaspdotnet/

RUN dotnet publish analyticsonaspdotnet/Api.csproj \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Api.dll"]
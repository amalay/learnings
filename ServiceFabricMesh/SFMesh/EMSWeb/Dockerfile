FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 20000

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY EMSWeb/EMSWeb.csproj EMSWeb/
RUN dotnet restore EMSWeb/EMSWeb.csproj
COPY . .
WORKDIR /src/EMSWeb
RUN dotnet build EMSWeb.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish EMSWeb.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EMSWeb.dll"]
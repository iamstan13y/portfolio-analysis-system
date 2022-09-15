FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./Sources/Analysis.API/Analysis.API.csproj", "Sources/Analysis.API/"]
COPY ["./Sources/ModelLibrary/ModelLibrary.csproj", "Sources/ModelLibrary/"]
RUN dotnet restore "./Sources/Analysis.API/Analysis.API.csproj"
COPY . .
WORKDIR "./src/Sources/Analysis.API"
RUN dotnet build "Analysis.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Analysis.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Analysis.API.dll"]
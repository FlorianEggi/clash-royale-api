#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Clash-royale-api-backend/Clash-royale-api-backend.csproj", "Clash-royale-api-backend/"]
RUN dotnet restore "Clash-royale-api-backend/Clash-royale-api-backend.csproj"
COPY . .
WORKDIR "/src/Clash-royale-api-backend"
RUN dotnet build "Clash-royale-api-backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Clash-royale-api-backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Clash-royale-api-backend.dll"]
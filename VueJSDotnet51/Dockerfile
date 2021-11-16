# FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
# WORKDIR /app

# FROM node:lts-buster-slim AS node_base
# FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
# COPY --from=node_base . .

# WORKDIR /src
# COPY ["VueJSDotnet51/VueJSDotnet51.csproj", "VueJSDotnet51/"]
# RUN dotnet restore "VueJSDotnet51/VueJSDotnet51.csproj"
# WORKDIR "/src/VueJSDotnet51/"
# COPY "VueJSDotnet51/." .

# ENV NODE_ENV=production
# RUN npm ci
# RUN npm run build
# RUN dotnet build "VueJSDotnet51.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "VueJSDotnet51.csproj" -c Release -o /app/publish

# FROM base AS final
# EXPOSE 8080
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "VueJSDotnet51.dll"]


  # Only working via command line
  # syntax=docker/dockerfile:1
  FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
  # mcr.microsoft.com/dotnet/aspnet:5.0
  # mcr.microsoft.com/dotnet/core/aspnet:3.1
  COPY bin/Release/netcoreapp3.1/publish/ App/
  WORKDIR /App
  ENTRYPOINT ["dotnet", "VueJSDotnet51.dll"]
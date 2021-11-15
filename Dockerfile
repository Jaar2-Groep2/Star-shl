#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM node:16
ENV NODE_ENV=production
WORKDIR /usr/src/app
COPY package*.json ./
RUN npm install --production
COPY . .


FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["VueJSDotnet51/VueJSDotnet51.csproj", "VueJSDotnet51/"]
RUN dotnet restore "VueJSDotnet51/VueJSDotnet51.csproj"
COPY . .
WORKDIR "/src/VueJSDotnet51"
RUN dotnet build "VueJSDotnet51.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VueJSDotnet51.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VueJSDotnet51.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base



WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build

RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_16.x | bash -
RUN apt-get install -y nodejs

# Install NodeJs
# RUN apt-get update && \
# apt-get install -y wget && \
# apt-get install -y gnupg2 && \
# wget -qO- https://deb.nodesource.com/setup_16.x | bash - && \
# apt-get install -y build-essential nodejs
# End Install

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
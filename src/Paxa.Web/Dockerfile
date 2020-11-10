#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base

RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_15.x | bash - && \
    apt-get install -y build-essential nodejs

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Paxa.Web/Paxa.Web.csproj", "src/Paxa.Web/"]
RUN dotnet restore "src/Paxa.Web/Paxa.Web.csproj"
COPY . .
WORKDIR "/src/src/Paxa.Web"
RUN dotnet build "Paxa.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Paxa.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Paxa.Web.dll"]

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["tibber-robot-api/tibber-robot-api.csproj", "tibber-robot-api/"]
RUN dotnet restore "tibber-robot-api/tibber-robot-api.csproj"
COPY . .
WORKDIR "/src/tibber-robot-api"
RUN dotnet build "tibber-robot-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "tibber-robot-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "tibber-robot-api.dll"]

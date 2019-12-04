FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["CityInfo.API/CityInfo.API.csproj", "CityInfo.API/"]
RUN dotnet restore "CityInfo.API/CityInfo.API.csproj"
COPY . .
WORKDIR "/src/CityInfo.API"
RUN dotnet build "CityInfo.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CityInfo.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CityInfo.API.dll"]
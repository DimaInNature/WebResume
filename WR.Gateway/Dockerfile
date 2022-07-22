#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WR.Gateway/WR.Gateway.csproj", "WR.Gateway/"]
RUN dotnet restore "WR.Gateway/WR.Gateway.csproj"
COPY . .
WORKDIR "/src/WR.Gateway"
RUN dotnet build "WR.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WR.Gateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WR.Gateway.dll"]
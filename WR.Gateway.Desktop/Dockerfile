#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WR.Gateway.Desktop/WR.Gateway.Desktop.csproj", "WR.Gateway.Desktop/"]
RUN dotnet restore "WR.Gateway.Desktop/WR.Gateway.Desktop.csproj"
COPY . .
WORKDIR "/src/WR.Gateway.Desktop"
RUN dotnet build "WR.Gateway.Desktop.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WR.Gateway.Desktop.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WR.Gateway.Desktop.dll"]
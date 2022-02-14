#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CarX/CarX.csproj", "CarX/"]
RUN dotnet restore "CarX/CarX.csproj"
COPY . .
WORKDIR "/src/CarX"
RUN dotnet build "CarX.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarX.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarX.dll"]
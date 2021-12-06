#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["YhtTicket.CatalogApi/YhtTicket.CatalogApi.csproj", "YhtTicket.CatalogApi/"]
RUN dotnet restore "YhtTicket.CatalogApi/YhtTicket.CatalogApi.csproj"
COPY . .
WORKDIR "/src/YhtTicket.CatalogApi"
RUN dotnet build "YhtTicket.CatalogApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YhtTicket.CatalogApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YhtTicket.CatalogApi.dll"]
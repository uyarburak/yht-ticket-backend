#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["YhtTicket.AlertApi/YhtTicket.AlertApi.csproj", "YhtTicket.AlertApi/"]
RUN dotnet restore "YhtTicket.AlertApi/YhtTicket.AlertApi.csproj"
COPY . .
WORKDIR "/src/YhtTicket.AlertApi"
RUN dotnet build "YhtTicket.AlertApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YhtTicket.AlertApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YhtTicket.AlertApi.dll"]
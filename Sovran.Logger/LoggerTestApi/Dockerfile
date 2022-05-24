#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LoggerTestApi/LoggerTestApi.csproj", "LoggerTestApi/"]
RUN dotnet restore "LoggerTestApi/LoggerTestApi.csproj"
COPY . .
WORKDIR "/src/LoggerTestApi"
RUN dotnet build "LoggerTestApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LoggerTestApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LoggerTestApi.dll"]
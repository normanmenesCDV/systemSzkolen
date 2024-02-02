FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Web/WebAppService.csproj", "Web/"]
RUN dotnet restore "Web/WebAppService.csproj"
COPY . .
WORKDIR "/src/Web"
RUN dotnet build "WebAppService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAppService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAppService.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Modules/WorkManagement/TodoTracker.WorkManagement.API/TodoTracker.WorkManagement.API.csproj", "src/Modules/WorkManagement/TodoTracker.WorkManagement.API/"]
COPY ["src/TodoTracker.Shared/TodoTracker.Shared.csproj", "src/TodoTracker.Shared/"]
RUN dotnet restore "src/Modules/WorkManagement/TodoTracker.WorkManagement.API/TodoTracker.WorkManagement.API.csproj"
COPY . .
WORKDIR "/src/src/Modules/WorkManagement/TodoTracker.WorkManagement.API"
RUN dotnet build "TodoTracker.WorkManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TodoTracker.WorkManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoTracker.WorkManagement.API.dll"]

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["RobotsWebStore/RobotsWebStore.csproj", "RobotsWebStore/"]
COPY ["RobotStoreDataModel/RobotStoreDataLayer.csproj", "RobotStoreDataModel/"]
RUN dotnet restore "RobotsWebStore/RobotsWebStore.csproj"
COPY . .
WORKDIR "/src/RobotsWebStore"
RUN dotnet build "RobotsWebStore.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "RobotsWebStore.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RobotsWebStore.dll"]
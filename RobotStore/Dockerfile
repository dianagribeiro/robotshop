FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ./RobotStoreDataModel/RobotStoreDataLayer.csproj ./RobotStoreDataModel/
COPY ./RobotsWebStore/RobotsWebStore.csproj ./RobotsWebStore/
RUN dotnet restore RobotsWebStore/RobotsWebStore.csproj

COPY . ./
WORKDIR /src/RobotsWebStore

RUN apt-get update -yq && apt-get upgrade -yq && apt-get install -yq curl git nano
RUN curl -sL https://deb.nodesource.com/setup_10.x | bash - && apt-get install -yq nodejs build-essential
RUN npm install -g npm
RUN npm install
RUN dotnet build RobotsWebStore.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish RobotsWebStore.csproj -c Release -o /app

# Build runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RobotsWebStore.dll"]

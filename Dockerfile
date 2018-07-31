FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
# COPY *.csproj ./
# RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet restore SJ90.DesktopAPI.API/*.csproj
RUN dotnet publish SJ90.DesktopAPI.API/*.csproj -c Release -o out /property:PublishWithAspNetCoreTargetManifest=false

# Build runtime image
FROM microsoft/dotnet:2.1.0-runtime
WORKDIR /app
COPY --from=build-env /app/SJ90.DesktopAPI.API/out .
ENTRYPOINT ["dotnet", "SJ90.DesktopAPI.API.dll"]

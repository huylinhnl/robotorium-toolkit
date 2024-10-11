FROM bintray.az.unix.corp:5000/base-images-docker-all/dotnet-80-ubi8:latest AS base
WORKDIR /app

FROM bintray.az.unix.corp:5000/base-images-docker-all/dotnet-80-ubi8:latest AS build
user root
WORKDIR /src
COPY . /src
RUN dotnet restore "RoboToolkit.csproj"

RUN dotnet build "RoboToolkit.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RoboToolkit.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# USER 1001
ENTRYPOINT ["dotnet", "RoboToolkit.dll"]
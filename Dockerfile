FROM registry.access.redhat.com/ubi8/dotnet-80@sha256:9e5f145f1dcdd0953b2d23b85ced6d89e347f7d68ae17b833f4ce1e789edd11c AS base
WORKDIR /app

FROM registry.access.redhat.com/ubi8/dotnet-80@sha256:9e5f145f1dcdd0953b2d23b85ced6d89e347f7d68ae17b833f4ce1e789edd11c AS build
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
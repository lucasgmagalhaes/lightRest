FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["perf/Request.Api/Request.Api.csproj", "perf/Request.Api/"]
COPY ["perf/Benchmark.Common/Benchmark.Common.csproj", "perf/Benchmark.Common/"]
RUN dotnet restore "perf/Request.Api/Request.Api.csproj"
COPY . .
WORKDIR "/src/perf/Request.Api"
RUN dotnet build "Request.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Request.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Request.Api.dll"]
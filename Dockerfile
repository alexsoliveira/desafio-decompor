FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["back-end/src/Desafio.Decompor.Api/", "Desafio.Decompor.Api/"]
COPY ["back-end/src/Desafio.Decompor.Business/", "Desafio.Decompor.Business/"]
RUN dotnet restore "Desafio.Decompor.Api/Desafio.Decompor.Api.csproj"
COPY . .
WORKDIR /src/Desafio.Decompor.Api
RUN dotnet build "Desafio.Decompor.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Desafio.Decompor.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Desafio.Decompor.Api.dll", "--environment=Development"]

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Prosolve.MicroService.Identity.API/Prosolve.MicroService.Identity.API.csproj", "Prosolve.MicroService.Identity.API/"]
RUN dotnet restore "Prosolve.MicroService.Identity.API/Prosolve.MicroService.Identity.API.csproj"
COPY . .
WORKDIR "/src/Prosolve.MicroService.Identity.API"
RUN dotnet build "Prosolve.MicroService.Identity.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Prosolve.MicroService.Identity.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Prosolve.MicroService.Identity.API.dll"]
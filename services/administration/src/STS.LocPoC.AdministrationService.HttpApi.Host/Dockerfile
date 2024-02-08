FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS=http://+:80;https://+:443

FROM sts/locpoc-base:1.0 AS build
WORKDIR /src

COPY . .
WORKDIR "/src/services/administration/src/STS.LocPoC.AdministrationService.HttpApi.Host"
RUN dotnet publish -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "STS.LocPoC.AdministrationService.HttpApi.Host.dll"]
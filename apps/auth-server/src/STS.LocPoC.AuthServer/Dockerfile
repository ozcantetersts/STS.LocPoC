FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS=http://+:80;https://+:443

FROM sts/locpoc-base:1.0 AS build
WORKDIR /src

COPY . .
WORKDIR "/src/apps/auth-server/src/STS.LocPoC.AuthServer"
RUN dotnet publish -c Release -o /app
RUN dotnet dev-certs https -v -ep /app/openiddict.pfx -p fc4c825b-2c26-451a-9341-421fc9ce5796

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "STS.LocPoC.AuthServer.dll"]
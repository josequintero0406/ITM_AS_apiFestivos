FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5289
EXPOSE 5289
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
# RUN apt-get update && apt-get install -y libgssapi-krb5-2
RUN dotnet publish -c Release --property:PublishDir=/app
FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "apiFestivos.Presentacion.dll"]
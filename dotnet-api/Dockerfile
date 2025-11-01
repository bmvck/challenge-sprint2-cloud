# ===================== build =====================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ./src/SistemaContabil.Application/*.csproj ./SistemaContabil.Application/
COPY ./src/SistemaContabil.Domain/*.csproj ./SistemaContabil.Domain/
COPY ./src/SistemaContabil.Infrastructure/*.csproj ./SistemaContabil.Infrastructure/
COPY ./src/SistemaContabil.Web/*.csproj ./SistemaContabil.Web/

RUN dotnet restore ./SistemaContabil.Web/SistemaContabil.Web.csproj

COPY ./src ./ 
RUN dotnet publish ./SistemaContabil.Web/SistemaContabil.Web.csproj -c Release -o /out --no-restore

# ===================== runtime =====================
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "SistemaContabil.Web.dll"]

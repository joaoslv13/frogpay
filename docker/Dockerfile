# Define a imagem base para o runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ENV ASPNETCORE_URLS http://*:80

ENV ASPNETCORE_ENVIRONMENT=Development

EXPOSE 80
EXPOSE 443

WORKDIR /app


# Define a imagem para o SDK e constrói a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["../src/FrogPay.Api/FrogPay.Api.csproj", "FrogPay.Api/"]
RUN dotnet restore "FrogPay.Api/FrogPay.Api.csproj"
COPY ../src .
WORKDIR "/src/FrogPay.Api"
RUN dotnet build "FrogPay.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FrogPay.Api.csproj" -c Release -o /app/publish

# Gera a imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FrogPay.Api.dll"]
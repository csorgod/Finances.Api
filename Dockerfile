FROM microsoft/dotnet:2.2-sdk-alpine AS base
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000

FROM microsoft/dotnet:2.2-sdk-alpine AS builder
ARG Configuration=Release
WORKDIR /src
COPY Finances.Api/Finances.Api.csproj Finances.Api/
COPY Finances.Common/Finances.Common.csproj Finances.Common/
COPY Finances.Core/Finances.Core.csproj Finances.Core/
COPY Finances.Infrastructure/Finances.Infrastructure.csproj Finances.Infrastructure/
COPY Finances.Common/Finances.Common.csproj Finances.Common/
WORKDIR /src/Finances.Api
RUN dotnet restore
COPY . .
RUN dotnet build -c $Configuration -o /app

FROM builder AS publish
ARG Configuration=Release
RUN dotnet publish -c $Configuration -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Finances.Api.dll"]

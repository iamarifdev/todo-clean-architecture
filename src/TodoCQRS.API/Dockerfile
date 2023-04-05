FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/TodoCQRS.API/TodoCQRS.API.csproj", "src/TodoCQRS.API/"]
COPY ["src/TodoCQRS.Application/TodoCQRS.Application.csproj", "src/TodoCQRS.Application/"]
COPY ["src/TodoCQRS.Domain/TodoCQRS.Domain.csproj", "src/TodoCQRS.Domain/"]
COPY ["src/TodoCQRS.Infrastructure/TodoCQRS.Infrastructure.csproj", "src/TodoCQRS.Infrastructure/"]

RUN dotnet restore "src/TodoCQRS.API/TodoCQRS.API.csproj"
COPY . .
WORKDIR "/src/src/TodoCQRS.API"
RUN dotnet build "TodoCQRS.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TodoCQRS.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 443
EXPOSE 80
ENTRYPOINT ["dotnet", "TodoCQRS.API.dll"]

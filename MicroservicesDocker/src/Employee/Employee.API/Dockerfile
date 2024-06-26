#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Employee/Employee.API/Employee.API.csproj", "src/Employee/Employee.API/"]
COPY ["src/Employee/Employee.Application/Employee.Application.csproj", "src/Employee/Employee.Application/"]
COPY ["src/Employee/Employee.Domain/Employee.Domain.csproj", "src/Employee/Employee.Domain/"]
COPY ["src/Employee/Employee.Infrastructure/Employee.Infrastructure.csproj", "src/Employee/Employee.Infrastructure/"]
RUN dotnet restore "./src/Employee/Employee.API/Employee.API.csproj"
COPY . .
WORKDIR "/src/src/Employee/Employee.API"
RUN dotnet build "./Employee.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Employee.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Employee.API.dll"]
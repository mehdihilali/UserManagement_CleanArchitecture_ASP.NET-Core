# Stage 1 : Build
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src

COPY UserManagementSystem.API/*.csproj UserManagementSystem.API/
COPY UserManagementSystem.Application/*.csproj UserManagementSystem.Application/
COPY UserManagementSystem.Domain/*.csproj UserManagementSystem.Domain/
COPY UserManagementSystem.Infrastructure/*.csproj UserManagementSystem.Infrastructure/

RUN dotnet restore UserManagementSystem.API/UserManagementSystem.API.csproj

COPY . .
WORKDIR /src/UserManagementSystem.API
RUN dotnet publish -c Release -o /app/publish

# Stage 2 : Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080

ENTRYPOINT ["dotnet", "UserManagementSystem.API.dll"]
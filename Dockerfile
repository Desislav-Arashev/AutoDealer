# AutoDealer Dockerfile
# .NET Framework 4.7 MVC Application

# Use the ASP.NET base image for .NET Framework
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2022 AS base
WORKDIR /app

# Build stage
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8-windowsservercore-ltsc2022 AS build
WORKDIR /src

# Copy solution and project files
COPY ["TelerikAcademy.AutoDealer/TelerikAcademy.AutoDealer.csproj", "TelerikAcademy.AutoDealer/"]
COPY ["TelerikAcademy.AutoDealer.sln", "./"]

# Restore NuGet packages
RUN nuget restore TelerikAcademy.AutoDealer.sln

# Copy the rest of the source code
COPY . .

# Build the application in Release mode
WORKDIR /src/TelerikAcademy.AutoDealer
RUN msbuild TelerikAcademy.AutoDealer.csproj /p:Configuration=Release /p:Platform="Any CPU" /p:OutputPath=/app/build

# Publish stage
FROM build AS publish
RUN msbuild TelerikAcademy.AutoDealer.csproj /p:Configuration=Release /p:Platform="Any CPU" /p:OutputPath=/app/publish /t:Publish

# Final stage - runtime image
FROM base AS final
WORKDIR /inetpub/wwwroot

# Copy published application
COPY --from=publish /app/publish/ .

# Expose port 80
EXPOSE 80

# IIS is already configured in the base image

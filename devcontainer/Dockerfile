# Set the base image for the container
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base

# Install necessary dependencies for the project
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    curl \
    git \
    unzip \
    && rm -rf /var/lib/apt/lists/*

# Set the working directory
WORKDIR /workspace

# Copy the project files into the container
COPY . .

# Restore the project dependencies
RUN dotnet restore

# Build the project
RUN dotnet build --no-restore

# Set the entrypoint for the container
ENTRYPOINT ["dotnet", "run"]

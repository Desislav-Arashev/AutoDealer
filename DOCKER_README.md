# AutoDealer

MVC project for managing car listings.

## Docker Setup

This project now includes Docker support for easy deployment and development.

### Prerequisites

- Docker Desktop for Windows (with Windows containers enabled)
- Or Docker with Windows container support

### Quick Start

1. **Build and run with Docker Compose:**
   ```bash
   docker-compose up --build
   ```

2. **Access the application:**
   - Web app: http://localhost:8080
   - SQL Server: localhost:1433

3. **Run database migrations:**
   ```bash
   # Connect to the SQL Server container and run Update-Database
   # Or use Entity Framework migrations from Visual Studio/VS Code
   ```

### Manual Docker Build

1. **Build the image:**
   ```bash
   docker build -t autodealer .
   ```

2. **Run the container:**
   ```bash
   docker run -d -p 8080:80 --name autodealer autodealer
   ```

### Environment Variables

- `ConnectionStrings__DefaultConnection` - SQL Server connection string

### Notes

- This is a Windows container image (required for .NET Framework 4.7)
- Make sure Docker Desktop is set to use Windows containers
- The SQL Server container uses SQL Server 2022 Express

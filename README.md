# Learning Management System (LMS)

This repository contains a modular Learning Management System built with ASP.NET Core 8.0. The solution is organized into multiple projects for API, Application, Domain, and Infrastructure layers, following clean architecture principles.

## Projects

- **LMS.API**: Entry point for the application, contains controllers and middleware.
- **LMS.Application**: Application logic, commands, queries, DTOs, and dependency injection.
- **LMS.Domain**: Domain entities, value objects, enums, and interfaces.
- **LMS.Infrastructure**: Data persistence, migrations, and repository implementations.

## Getting Started

1. **Clone the repository**
   ```
   git clone <repository-url>
   ```
2. **Open the solution**
   Open `LMS.sln` in Visual Studio 2022 or later.
3. **Configure the database**
   - Update the connection string in `LMS.API/appsettings.json` as needed.
   - Run migrations to set up the database.
4. **Run the application**
   - Set `LMS.API` as the startup project.
   - Press F5 or use `dotnet run` in the `LMS.API` directory.

## Folder Structure

- `LMS.API/Controllers` - API endpoints
- `LMS.Application/Students` - Student-related commands, queries, and DTOs
- `LMS.Domain/Entities` - Core domain models
- `LMS.Infrastructure/Persistence` - Database context and repositories

## Requirements

- .NET 8.0 SDK
- SQL Server (or update for your preferred database)

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License

[MIT](LICENSE)

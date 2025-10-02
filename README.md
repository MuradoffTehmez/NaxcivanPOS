# NaxcivanPOS

NaxcivanPOS is a Point of Sale (POS) system developed for small and medium businesses in Nakhchivan, Azerbaijan. The system is built using .NET 8 with a multi-layered architecture following SOLID principles and clean code practices.

## Architecture

The application follows a multi-layered architecture:

- **Entities**: Contains data models (Mehsul, Satis)
- **Data**: Data access layer with Entity Framework Core, Repository and Unit of Work patterns
- **Business**: Business logic layer with service classes
- **Presentation**: WinForms UI layer with MaterialSkin.2 design

## Technology Stack

- .NET 8
- C# 12
- WinForms with MaterialSkin.2
- Entity Framework Core (Code-First)
- SQL Server LocalDB
- MVP Pattern
- Repository & UnitOfWork Pattern
- Dependency Injection

## Faza 1 Features (Completed)

- Product management (Add, edit, delete, view)
- Simple sales process
- Basic cashier operations
- Material design UI

## Getting Started

1. Make sure you have .NET 8 SDK installed
2. Run the application:
   ```bash
   dotnet run --project NaxcivanPOS.Presentation
   ```

Or use the batch file:
```
start_app.bat
```

## Project Structure

```
NaxcivanPOS/
├── NaxcivanPOS.Entities/     # Data models
├── NaxcivanPOS.Data/         # Data access layer
├── NaxcivanPOS.Business/     # Business logic
├── NaxcivanPOS.Presentation/ # UI layer
└── Plan/                     # Project documentation
```

## Coding Standards

All code follows the coding standards specified in `Plan/CODING-STANDARDS.md`, including:
- Naming conventions in Azerbaijani
- SOLID principles
- Clean code practices
- Security considerations
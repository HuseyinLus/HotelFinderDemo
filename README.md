🏨 HotelFinder API
📖 Overview
HotelFinder API is a backend project developed with ASP.NET Core using a Layered Architecture.
It focuses on scalability, maintainability, and clean design, providing CRUD operations and secure user authentication.

🛠️ Technologies Used
Technology	Purpose
.NET 6/7	Backend services framework
Entity Framework	ORM & Database operations
SQL Server	Relational database
Swagger	Interactive API documentation
JWT Authentication	Secure user login & token management
Dependency Injection	Loose coupling & testability
🏗️ Architecture
The project follows a Layered Architecture:

Domain Layer → Entities & Business logic
Data Access Layer → EF Core, repositories, migrations
Application Layer → Service logic & interfaces
Presentation Layer → Controllers & API endpoints
This ensures:

Separation of concerns
Easy maintainability
Testability & scalability
🔐 Authentication & Authorization
Implemented with JWT (JSON Web Tokens)
Supports role-based authorization (e.g., Admin, User)
Secure token handling with refresh tokens


🚀 Features
✅ CRUD operations for Hotels & Users
✅ Authentication & Authorization
✅ Repository & Unit of Work Pattern
✅ Swagger UI for API testing
✅ Configurable with appsettings.json


📂 Project Structure
HotelFinder/
│── Domain/               # Entities & Core business logic
│── DataAccess/           # EF Core, Migrations, Repositories
│── Application/          # Service interfaces & implementations
│── API/                  # Controllers & Presentation layer
│── appsettings.json      # Configuration (excluded from Git)

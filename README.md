# HotelFinder Backend API 🏨

A **cleanly architected ASP.NET Core Web API** project that demonstrates modern backend development practices, including **Layered Architecture, SOLID principles, Dependency Injection, JWT-based Authentication & Authorization, and EF Core with Migrations**.  

This project provides **full CRUD operations** for managing hotels, user registration, login, and secure token-based authentication with refresh tokens.

---

## 🔑 Key Features

- **Layered Architecture**  
  - Domain Layer: Entities, business rules  
  - Data Access Layer: EF Core with Migrations  
  - Service Layer: Business logic & interfaces  
  - API Layer: Controllers with RESTful endpoints  

- **SOLID Principles** applied throughout the project.  
- **Dependency Injection (DI)** for loose coupling and testability.  
- **JWT Authentication & Role-Based Authorization** (with refresh tokens).  
- **Swagger/OpenAPI** integrated for easy API exploration.  
- **Entity Framework Core** for database access with code-first migrations.  
- **Secure Configuration** using `appsettings.json` (sensitive values excluded from version control).  

---

## 📂 Project Structure
HotelFinder/
│
├── Domain/ # Entities and core business models
│ └── Entities/
│
├── DataAccess/ # EF Core, DbContext, and Migrations
│ └── Migrations/
│
├── Services/ # Business logic and service interfaces
│
├── API/ # Controllers, DTOs, Middleware
│
├── HotelFinder.sln # Solution file
└── README.md # Project documentation



---

## ⚙️ Technologies Used

- **C#** (ASP.NET Core 6)
- **Entity Framework Core** (Code First with Migrations)
- **SQL Server** as primary database
- **JWT (JSON Web Tokens)** for authentication
- **Swagger** for API documentation
- **Dependency Injection** for decoupled services
- **Layered Architecture + SOLID** design patterns



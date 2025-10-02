🏨 HotelFinder API

A scalable and maintainable backend API for hotel management, built with ASP.NET Core, following Clean Architecture and SOLID principles.
The project provides secure CRUD operations with JWT-based authentication & authorization, making it suitable for enterprise-level applications.


🚀 Features

🔐 Authentication & Authorization – Role-based access using JWT tokens

🏗 Clean & Layered Architecture – Separation of concerns (Core, Application, Infrastructure, Presentation)

🗂 Entity Framework Core – ORM with SQL Server integration

📖 Swagger UI – Built-in API documentation & testing

🏢 Repository & Unit of Work Pattern – Clean and efficient data persistence

📦 Scalability – Easily extensible for future modules (reservations, bookings, users, etc.)


🛠️ Technologies Used

.NET 6/7 – Backend framework

ASP.NET Core Web API – RESTful services

Entity Framework Core – Database ORM

SQL Server – Relational database

JWT Tokens – Authentication & Authorization

Swagger / OpenAPI – API documentation


🏛️ Architecture

The project is structured using Layered / Onion Architecture:

Core → Domain entities & business rules

Application → Interfaces, DTOs, and service logic

Infrastructure → Database access, migrations, repositories

Presentation → API controllers & request handling

This ensures separation of concerns, testability, and scalability.


📐 Principles Followed

SOLID principles (SRP, OCP, LSP, ISP, DIP)

Dependency Injection throughout the solution

Repository & Unit of Work Pattern for clean data handling

Clean Code Practices for readability & maintainability

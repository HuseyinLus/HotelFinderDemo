<img width="1301" height="456" alt="HotelFinderSCreenshot1231242" src="https://github.com/user-attachments/assets/7b0e7f17-dfbb-4d26-a678-4e3ce9438422" />
<img width="1304" height="633" alt="HotelFinderSS112" src="https://github.com/user-attachments/assets/61a8a551-8fb1-42c8-b9b9-7c478a9416b1" />
<img width="945" height="602" alt="HotelFinderSS123123" src="https://github.com/user-attachments/assets/b041d5ae-dd3f-4b41-ae64-ddeb7d05dc44" />
<img width="515" height="232" alt="HotelFinderSS12314134" src="https://github.com/user-attachments/assets/963af3e7-71c4-4222-b052-c147a936efc4" />
<img width="1077" height="592" alt="HotelFinderSS13241212" src="https://github.com/user-attachments/assets/9c63a7b7-a7ee-454d-b1e4-4ea97d6b7a99" />



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

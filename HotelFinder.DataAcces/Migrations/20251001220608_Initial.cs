using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelFinder.DataAcces.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Hotels')
                CREATE TABLE Hotels(
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Name NVARCHAR(50) NOT NULL,
                    City NVARCHAR(50) NOT NULL,
                    Country NVARCHAR(50) NOT NULL
                );

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Logins')
                CREATE TABLE Logins(
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    UserId INT NOT NULL,
                    UserName NVARCHAR(50) NOT NULL,
                    Password NVARCHAR(50) NOT NULL
                );

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Registers')
                CREATE TABLE Registers(
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Name NVARCHAR(50) NOT NULL,
                    LastName NVARCHAR(50) NOT NULL,
                    Username NVARCHAR(50) NOT NULL,
                    Password NVARCHAR(50) NOT NULL,
                    Email NVARCHAR(40) NOT NULL,
                    Location NVARCHAR(50) NOT NULL,
                    Role NVARCHAR(20) NOT NULL
                );

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'RefreshTokens')
                CREATE TABLE RefreshTokens(
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Token NVARCHAR(MAX) NULL,
                    Expires DATETIME2 NOT NULL,
                    UserId INT NOT NULL,
                    IsRevoked BIT NOT NULL,
                    CreatedAt DATETIME2 NOT NULL,
                    CONSTRAINT FK_RefreshTokens_Registers FOREIGN KEY(UserId) REFERENCES Registers(Id) ON DELETE CASCADE
                );
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                IF OBJECT_ID('RefreshTokens', 'U') IS NOT NULL DROP TABLE RefreshTokens;
                IF OBJECT_ID('Hotels', 'U') IS NOT NULL DROP TABLE Hotels;
                IF OBJECT_ID('Logins', 'U') IS NOT NULL DROP TABLE Logins;
                IF OBJECT_ID('Registers', 'U') IS NOT NULL DROP TABLE Registers;
            ");
        }
    }
}

-- Schema.sql
-- Lab 2: Merging Login/Register and Employee CRUD into One App
-- Database: dbCompanyApp

USE master;
GO

IF DB_ID(N'dbCompanyApp') IS NULL
BEGIN
    CREATE DATABASE dbCompanyApp;
END
GO

USE dbCompanyApp;
GO

IF OBJECT_ID(N'dbo.Users', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Users
    (
        UserID INT IDENTITY(1,1) NOT NULL
            CONSTRAINT PK_Users PRIMARY KEY,
        Username NVARCHAR(50) NOT NULL
            CONSTRAINT UQ_Users_Username UNIQUE,
        Password NVARCHAR(200) NOT NULL,
        CreatedAt DATETIME NOT NULL
            CONSTRAINT DF_Users_CreatedAt DEFAULT GETDATE()
    );
END
GO

IF OBJECT_ID(N'dbo.Emp_details', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Emp_details
    (
        EmpId NVARCHAR(50) NOT NULL
            CONSTRAINT PK_Emp_details PRIMARY KEY,
        EmpName NVARCHAR(100) NOT NULL,
        EmpAge INT NOT NULL,
        EmpContact NVARCHAR(20) NULL,
        EmpGender NVARCHAR(10) NULL,
        CreatedBy INT NULL,
        CONSTRAINT FK_Emp_CreatedBy
            FOREIGN KEY (CreatedBy)
            REFERENCES dbo.Users(UserID)
    );
END
GO

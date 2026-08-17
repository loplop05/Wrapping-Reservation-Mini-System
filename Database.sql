-- Library Book Wrapping Reservation System Database Schema
-- Run this script in SQL Server to create the database and tables

CREATE DATABASE LibraryBookWrapping;
GO

USE LibraryBookWrapping;
GO

-- Customers Table
CREATE TABLE Customers
(
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    Phone NVARCHAR(20) NOT NULL UNIQUE,
    Name NVARCHAR(100) NOT NULL
);
GO

-- Orders Table
CREATE TABLE Orders
(
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT NOT NULL,
    BooksQty INT NOT NULL,
    OtherPurchasesAmount DECIMAL(10,2) NOT NULL DEFAULT 0,
    TotalBill DECIMAL(10,2) NOT NULL,
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
    Status NVARCHAR(20) NOT NULL DEFAULT 'Pending',

    CONSTRAINT FK_Orders_Customers
        FOREIGN KEY (CustomerID)
        REFERENCES Customers(CustomerID),

    CONSTRAINT CK_Orders_BooksQty
        CHECK (BooksQty > 0),

    CONSTRAINT CK_Orders_OtherPurchases
        CHECK (OtherPurchasesAmount >= 0),

    CONSTRAINT CK_Orders_TotalBill
        CHECK (TotalBill >= 0)
);
GO

-- Insert sample data for testing (optional)
-- INSERT INTO Customers (Phone, Name) VALUES ('0791234567', 'Ahmad');
-- INSERT INTO Orders (CustomerID, BooksQty, OtherPurchasesAmount, TotalBill, Status) 
-- VALUES (1, 5, 3.50, 8.50, 'Pending');
-- GO

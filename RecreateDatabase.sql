-- Complete Database Recreation Script
-- This will DROP and RECREATE the entire database (ALL DATA WILL BE LOST!)
-- Run this in SQL Server Management Studio

-- Drop the database if it exists
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'InventoryDB')
BEGIN
    ALTER DATABASE InventoryDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE InventoryDB;
    PRINT 'Database InventoryDB dropped successfully!';
END
ELSE
BEGIN
    PRINT 'Database InventoryDB does not exist, will create new one.';
END
GO

-- Create the database
CREATE DATABASE InventoryDB;
GO

PRINT 'Database InventoryDB created successfully!';
GO

-- Use the database
USE InventoryDB;
GO

-- Create Customers Table
CREATE TABLE Customers
(
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    Phone NVARCHAR(20) NOT NULL UNIQUE,
    Name NVARCHAR(100) NOT NULL
);
GO

PRINT 'Customers table created successfully!';
GO

-- Create Orders Table
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

PRINT 'Orders table created successfully!';
GO

-- Insert sample data for testing (optional - you can remove this)
INSERT INTO Customers (Phone, Name) VALUES ('0791234567', 'Ahmad');
INSERT INTO Customers (Phone, Name) VALUES ('0799876543', 'Fatima');
GO

INSERT INTO Orders (CustomerID, BooksQty, OtherPurchasesAmount, TotalBill, Status) 
VALUES (1, 5, 3.50, 8.50, 'Pending');
GO

PRINT 'Sample data inserted successfully!';
GO

-- Verify the database structure
PRINT '=== Database Structure Verification ===';
PRINT 'Tables in InventoryDB:';
SELECT TABLE_NAME 
FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_NAME;
GO

PRINT 'Customers table columns:';
SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Customers'
ORDER BY ORDINAL_POSITION;
GO

PRINT 'Orders table columns:';
SELECT COLUMN_NAME, DATA_TYPE, NUMERIC_PRECISION, NUMERIC_SCALE, IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Orders'
ORDER BY ORDINAL_POSITION;
GO

PRINT 'Sample data in Customers:';
SELECT * FROM Customers;
GO

PRINT 'Sample data in Orders:';
SELECT o.OrderID, c.Name AS CustomerName, c.Phone, o.BooksQty, o.OtherPurchasesAmount, o.TotalBill, o.OrderDate, o.Status
FROM Orders o 
INNER JOIN Customers c ON o.CustomerID = c.CustomerID;
GO

PRINT '=== Database Recreation Complete ===';
GO

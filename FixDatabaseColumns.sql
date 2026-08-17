-- Script to fix missing columns in the database
-- Run this in SQL Server Management Studio

USE InventoryDB;
GO

-- Check current columns in Customers table
PRINT 'Current columns in Customers table:';
SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Customers'
ORDER BY ORDINAL_POSITION;
GO

-- Add Phone column if it doesn't exist
IF NOT EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'Customers' AND COLUMN_NAME = 'Phone'
)
BEGIN
    PRINT 'Adding Phone column to Customers table...';
    ALTER TABLE Customers ADD Phone NVARCHAR(20);
    
    -- Make Phone NOT NULL if there are no existing rows, otherwise add as NULL first
    -- Then update and make NOT NULL
    DECLARE @rowCount INT;
    SELECT @rowCount = COUNT(*) FROM Customers;
    
    IF @rowCount = 0
    BEGIN
        ALTER TABLE Customers ALTER COLUMN Phone NVARCHAR(20) NOT NULL;
        PRINT 'Phone column added as NOT NULL';
    END
    ELSE
    BEGIN
        PRINT 'Phone column added as NULL (existing data present)';
        PRINT 'Please update existing records with phone numbers, then run:';
        PRINT 'ALTER TABLE Customers ALTER COLUMN Phone NVARCHAR(20) NOT NULL;';
    END
END
ELSE
BEGIN
    PRINT 'Phone column already exists';
END
GO

-- Add UNIQUE constraint to Phone if it doesn't exist
IF NOT EXISTS (
    SELECT * FROM sys.indexes 
    WHERE name = 'UQ_Customers_Phone' AND object_id = OBJECT_ID('Customers')
)
BEGIN
    PRINT 'Adding UNIQUE constraint to Phone column...';
    
    -- First make sure Phone is NOT NULL
    ALTER TABLE Customers ALTER COLUMN Phone NVARCHAR(20) NOT NULL;
    
    -- Then add unique constraint
    ALTER TABLE Customers ADD CONSTRAINT UQ_Customers_Phone UNIQUE (Phone);
    PRINT 'UNIQUE constraint added to Phone column';
END
ELSE
BEGIN
    PRINT 'UNIQUE constraint on Phone already exists';
END
GO

-- Check current columns in Orders table
PRINT 'Current columns in Orders table:';
SELECT COLUMN_NAME, DATA_TYPE, NUMERIC_PRECISION, NUMERIC_SCALE
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Orders'
ORDER BY ORDINAL_POSITION;
GO

-- Add missing columns to Orders table if they don't exist
-- BooksQty
IF NOT EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'Orders' AND COLUMN_NAME = 'BooksQty'
)
BEGIN
    PRINT 'Adding BooksQty column to Orders table...';
    ALTER TABLE Orders ADD BooksQty INT NOT NULL DEFAULT 1;
END
ELSE
BEGIN
    PRINT 'BooksQty column already exists';
END
GO

-- OtherPurchasesAmount
IF NOT EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'Orders' AND COLUMN_NAME = 'OtherPurchasesAmount'
)
BEGIN
    PRINT 'Adding OtherPurchasesAmount column to Orders table...';
    ALTER TABLE Orders ADD OtherPurchasesAmount DECIMAL(10,2) NOT NULL DEFAULT 0;
END
ELSE
BEGIN
    PRINT 'OtherPurchasesAmount column already exists';
END
GO

-- TotalBill
IF NOT EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'Orders' AND COLUMN_NAME = 'TotalBill'
)
BEGIN
    PRINT 'Adding TotalBill column to Orders table...';
    ALTER TABLE Orders ADD TotalBill DECIMAL(10,2) NOT NULL DEFAULT 0;
END
ELSE
BEGIN
    PRINT 'TotalBill column already exists';
END
GO

-- OrderDate
IF NOT EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'Orders' AND COLUMN_NAME = 'OrderDate'
)
BEGIN
    PRINT 'Adding OrderDate column to Orders table...';
    ALTER TABLE Orders ADD OrderDate DATETIME NOT NULL DEFAULT GETDATE();
END
ELSE
BEGIN
    PRINT 'OrderDate column already exists';
END
GO

-- Status
IF NOT EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'Orders' AND COLUMN_NAME = 'Status'
)
BEGIN
    PRINT 'Adding Status column to Orders table...';
    ALTER TABLE Orders ADD Status NVARCHAR(20) NOT NULL DEFAULT 'Pending';
END
ELSE
BEGIN
    PRINT 'Status column already exists';
END
GO

-- Add Foreign Key constraint if it doesn't exist
IF NOT EXISTS (
    SELECT * FROM sys.foreign_keys 
    WHERE name = 'FK_Orders_Customers' AND parent_object_id = OBJECT_ID('Orders')
)
BEGIN
    PRINT 'Adding Foreign Key constraint...';
    ALTER TABLE Orders 
    ADD CONSTRAINT FK_Orders_Customers 
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID);
    PRINT 'Foreign Key constraint added';
END
ELSE
BEGIN
    PRINT 'Foreign Key constraint already exists';
END
GO

PRINT 'Database column fix completed!';
GO

-- Final verification
PRINT 'Final Customers table structure:';
SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Customers'
ORDER BY ORDINAL_POSITION;
GO

PRINT 'Final Orders table structure:';
SELECT COLUMN_NAME, DATA_TYPE, NUMERIC_PRECISION, NUMERIC_SCALE, IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Orders'
ORDER BY ORDINAL_POSITION;
GO

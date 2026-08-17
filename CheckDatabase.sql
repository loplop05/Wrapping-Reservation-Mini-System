-- Diagnostic script to check database structure
-- Run this in SQL Server Management Studio

USE InventoryDB;
GO

-- Check if Customers table exists and show its columns
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Customers')
BEGIN
    PRINT 'Customers table exists. Columns:';
    SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH 
    FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'Customers'
    ORDER BY ORDINAL_POSITION;
END
ELSE
BEGIN
    PRINT 'Customers table does NOT exist';
END
GO

-- Check if Orders table exists and show its columns
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Orders')
BEGIN
    PRINT 'Orders table exists. Columns:';
    SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE
    FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'Orders'
    ORDER BY ORDINAL_POSITION;
END
ELSE
BEGIN
    PRINT 'Orders table does NOT exist';
END
GO

-- Show all tables in the database
PRINT 'All tables in InventoryDB:';
SELECT TABLE_NAME 
FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_NAME;
GO

-- Simple script to add Phone column to Customers table
-- Run this in SQL Server Management Studio

USE InventoryDB;
GO

-- Add Phone column (simple approach)
ALTER TABLE Customers ADD Phone NVARCHAR(20) NULL;
GO

-- Update existing customers with dummy phone numbers if needed
-- (Remove this block if you don't have existing data)
UPDATE Customers SET Phone = '0000000000' WHERE Phone IS NULL;
GO

-- Make Phone NOT NULL
ALTER TABLE Customers ALTER COLUMN Phone NVARCHAR(20) NOT NULL;
GO

-- Add UNIQUE constraint
ALTER TABLE Customers ADD CONSTRAINT UQ_Customers_Phone UNIQUE (Phone);
GO

PRINT 'Phone column added successfully!';
GO

-- Verify
SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Customers' 
ORDER BY ORDINAL_POSITION;
GO

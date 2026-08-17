-- Remove UNIQUE constraint from Phone column to allow multiple reservations per customer
-- Run this in SQL Server Management Studio

USE InventoryDB;
GO

-- Drop the UNIQUE constraint if it exists
IF EXISTS (
    SELECT * FROM sys.key_constraints 
    WHERE name = 'UQ_Customers_Phone' AND parent_object_id = OBJECT_ID('Customers')
)
BEGIN
    PRINT 'Removing UNIQUE constraint from Phone column...';
    ALTER TABLE Customers DROP CONSTRAINT UQ_Customers_Phone;
    PRINT 'UNIQUE constraint removed successfully!';
END
ELSE
BEGIN
    PRINT 'UNIQUE constraint on Phone does not exist';
END
GO

-- Verify the change
PRINT '=== Updated Customers Table Structure ===';
SELECT COLUMN_NAME, IS_NULLABLE 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Customers'
ORDER BY ORDINAL_POSITION;
GO

PRINT '=== Constraints on Customers Table ===';
SELECT 
    tc.CONSTRAINT_NAME,
    tc.CONSTRAINT_TYPE,
    ccu.COLUMN_NAME
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc
LEFT JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ccu 
    ON tc.CONSTRAINT_NAME = ccu.CONSTRAINT_NAME
WHERE tc.TABLE_NAME = 'Customers'
ORDER BY tc.CONSTRAINT_TYPE, tc.CONSTRAINT_NAME;
GO

PRINT 'Multiple reservations per customer are now allowed!';
GO

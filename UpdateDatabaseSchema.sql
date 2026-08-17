-- Update database schema to add PaymentMethod column
-- Run this in SQL Server Management Studio

USE InventoryDB;
GO

-- Add PaymentMethod column to Orders table if it doesn't exist
IF NOT EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'Orders' AND COLUMN_NAME = 'PaymentMethod'
)
BEGIN
    PRINT 'Adding PaymentMethod column to Orders table...';
    ALTER TABLE Orders ADD PaymentMethod NVARCHAR(20) NOT NULL DEFAULT 'Cash';
    PRINT 'PaymentMethod column added successfully!';
END
ELSE
BEGIN
    PRINT 'PaymentMethod column already exists';
END
GO

-- Update existing records to have PaymentMethod (if they don't have it)
UPDATE Orders SET PaymentMethod = 'Cash' WHERE PaymentMethod IS NULL;
GO

-- Add check constraint for PaymentMethod (optional - ensures only valid values)
IF NOT EXISTS (
    SELECT * FROM sys.check_constraints 
    WHERE name = 'CK_Orders_PaymentMethod' AND parent_object_id = OBJECT_ID('Orders')
)
BEGIN
    PRINT 'Adding check constraint for PaymentMethod...';
    ALTER TABLE Orders 
    ADD CONSTRAINT CK_Orders_PaymentMethod 
    CHECK (PaymentMethod IN ('Cash', 'Visa'));
    PRINT 'Check constraint added successfully!';
END
ELSE
BEGIN
    PRINT 'Check constraint for PaymentMethod already exists';
END
GO

-- Verify the update
PRINT '=== Updated Orders Table Structure ===';
SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE, COLUMN_DEFAULT
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Orders'
ORDER BY ORDINAL_POSITION;
GO

PRINT 'Schema update completed!';
GO

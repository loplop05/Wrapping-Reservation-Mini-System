-- Run this once in SQL Server Management Studio against the WrappingReservation database.
-- It is safe to run more than once.

IF DB_ID(N'WrappingReservation') IS NULL
BEGIN
    THROW 50020, 'Database WrappingReservation does not exist.', 1;
END
GO

USE WrappingReservation;
GO

IF OBJECT_ID(N'dbo.Orders', N'U') IS NULL
BEGIN
    THROW 50021, 'Table dbo.Orders does not exist in WrappingReservation.', 1;
END
GO

IF COL_LENGTH(N'dbo.Orders', N'PaymentMethod') IS NULL
BEGIN
    ALTER TABLE dbo.Orders
        ADD PaymentMethod NVARCHAR(20) NOT NULL
            CONSTRAINT DF_Orders_PaymentMethod DEFAULT (N'Cash');

    PRINT 'PaymentMethod column added to dbo.Orders. Existing orders were assigned Cash.';
END
ELSE
BEGIN
    PRINT 'PaymentMethod column already exists. No changes were required.';
END
GO

IF NOT EXISTS
(
    SELECT 1
    FROM sys.check_constraints
    WHERE name = N'CK_Orders_PaymentMethod'
      AND parent_object_id = OBJECT_ID(N'dbo.Orders')
)
BEGIN
    ALTER TABLE dbo.Orders
        ADD CONSTRAINT CK_Orders_PaymentMethod
        CHECK (PaymentMethod IN (N'Cash', N'Visa'));
END
GO

SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = N'Orders'
  AND COLUMN_NAME = N'PaymentMethod';
GO

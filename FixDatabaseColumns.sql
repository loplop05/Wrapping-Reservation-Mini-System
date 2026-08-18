-- Upgrade an existing WrappingReservation database to the current schema.
-- Run this script in SQL Server Management Studio.

IF DB_ID(N'WrappingReservation') IS NULL
BEGIN
    THROW 50000, 'Database WrappingReservation does not exist. Run Database.sql first.', 1;
END
GO

USE WrappingReservation;
GO

IF OBJECT_ID(N'dbo.Customers', N'U') IS NULL
BEGIN
    THROW 50001, 'Customers table does not exist. Run Database.sql first.', 1;
END
GO

IF COL_LENGTH(N'dbo.Customers', N'Phone') IS NULL
BEGIN
    ALTER TABLE dbo.Customers ADD Phone NVARCHAR(20) NULL;
    PRINT 'Added Customers.Phone as nullable. Populate existing rows before enforcing uniqueness.';
END
GO

IF COL_LENGTH(N'dbo.Orders', N'BooksQty') IS NULL
    ALTER TABLE dbo.Orders ADD BooksQty INT NOT NULL CONSTRAINT DF_Orders_BooksQty DEFAULT (1);
GO

IF COL_LENGTH(N'dbo.Orders', N'OtherPurchasesAmount') IS NULL
    ALTER TABLE dbo.Orders ADD OtherPurchasesAmount DECIMAL(10,2) NOT NULL CONSTRAINT DF_Orders_OtherPurchasesAmount DEFAULT (0);
GO

IF COL_LENGTH(N'dbo.Orders', N'TotalBill') IS NULL
    ALTER TABLE dbo.Orders ADD TotalBill DECIMAL(10,2) NOT NULL CONSTRAINT DF_Orders_TotalBill DEFAULT (0);
GO

IF COL_LENGTH(N'dbo.Orders', N'OrderDate') IS NULL
    ALTER TABLE dbo.Orders ADD OrderDate DATETIME NOT NULL CONSTRAINT DF_Orders_OrderDate DEFAULT (GETDATE());
GO

IF COL_LENGTH(N'dbo.Orders', N'Status') IS NULL
    ALTER TABLE dbo.Orders ADD Status NVARCHAR(20) NOT NULL CONSTRAINT DF_Orders_Status DEFAULT (N'Pending');
GO

IF COL_LENGTH(N'dbo.Orders', N'PaymentMethod') IS NULL
    ALTER TABLE dbo.Orders ADD PaymentMethod NVARCHAR(20) NOT NULL CONSTRAINT DF_Orders_PaymentMethod DEFAULT (N'Cash');
GO

IF NOT EXISTS
(
    SELECT 1
    FROM sys.foreign_keys
    WHERE name = N'FK_Orders_Customers'
      AND parent_object_id = OBJECT_ID(N'dbo.Orders')
)
BEGIN
    ALTER TABLE dbo.Orders
        ADD CONSTRAINT FK_Orders_Customers
        FOREIGN KEY (CustomerID) REFERENCES dbo.Customers(CustomerID);
END
GO

IF NOT EXISTS
(
    SELECT 1
    FROM sys.check_constraints
    WHERE name = N'CK_Orders_BooksQty'
      AND parent_object_id = OBJECT_ID(N'dbo.Orders')
)
    ALTER TABLE dbo.Orders ADD CONSTRAINT CK_Orders_BooksQty CHECK (BooksQty > 0);
GO

IF NOT EXISTS
(
    SELECT 1
    FROM sys.check_constraints
    WHERE name = N'CK_Orders_OtherPurchases'
      AND parent_object_id = OBJECT_ID(N'dbo.Orders')
)
    ALTER TABLE dbo.Orders ADD CONSTRAINT CK_Orders_OtherPurchases CHECK (OtherPurchasesAmount >= 0);
GO

IF NOT EXISTS
(
    SELECT 1
    FROM sys.check_constraints
    WHERE name = N'CK_Orders_TotalBill'
      AND parent_object_id = OBJECT_ID(N'dbo.Orders')
)
    ALTER TABLE dbo.Orders ADD CONSTRAINT CK_Orders_TotalBill CHECK (TotalBill >= 0);
GO

IF NOT EXISTS
(
    SELECT 1
    FROM sys.check_constraints
    WHERE name = N'CK_Orders_Status'
      AND parent_object_id = OBJECT_ID(N'dbo.Orders')
)
    ALTER TABLE dbo.Orders ADD CONSTRAINT CK_Orders_Status CHECK (Status IN (N'Pending', N'Ready', N'Completed', N'Cancelled'));
GO

IF NOT EXISTS
(
    SELECT 1
    FROM sys.check_constraints
    WHERE name = N'CK_Orders_PaymentMethod'
      AND parent_object_id = OBJECT_ID(N'dbo.Orders')
)
    ALTER TABLE dbo.Orders ADD CONSTRAINT CK_Orders_PaymentMethod CHECK (PaymentMethod IN (N'Cash', N'Visa'));
GO

IF NOT EXISTS
(
    SELECT 1
    FROM sys.indexes
    WHERE name = N'UQ_Customers_Phone'
      AND object_id = OBJECT_ID(N'dbo.Customers')
)
BEGIN
    IF EXISTS (SELECT 1 FROM dbo.Customers WHERE Phone IS NULL)
        PRINT 'UQ_Customers_Phone was not added because existing customers still have NULL phone numbers.';
    ELSE IF EXISTS (SELECT Phone FROM dbo.Customers GROUP BY Phone HAVING COUNT(*) > 1)
        PRINT 'UQ_Customers_Phone was not added because duplicate phone numbers exist.';
    ELSE
    BEGIN
        ALTER TABLE dbo.Customers ALTER COLUMN Phone NVARCHAR(20) NOT NULL;
        ALTER TABLE dbo.Customers ADD CONSTRAINT UQ_Customers_Phone UNIQUE (Phone);
    END
END
GO

PRINT 'WrappingReservation database upgrade completed.';
GO



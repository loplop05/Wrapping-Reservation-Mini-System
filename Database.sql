IF DB_ID(N'WrappingReservation') IS NULL
BEGIN
    CREATE DATABASE WrappingReservation;
END
GO

USE WrappingReservation;
GO

IF OBJECT_ID(N'dbo.Customers', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Customers
    (
        CustomerID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Customers PRIMARY KEY,
        Phone NVARCHAR(20) NOT NULL CONSTRAINT UQ_Customers_Phone UNIQUE,
        Name NVARCHAR(100) NOT NULL
    );
END
GO

IF OBJECT_ID(N'dbo.Orders', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Orders
    (
        OrderID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Orders PRIMARY KEY,
        CustomerID INT NOT NULL,
        BooksQty INT NOT NULL CONSTRAINT CK_Orders_BooksQty CHECK (BooksQty > 0),
        OtherPurchasesAmount DECIMAL(10,2) NOT NULL CONSTRAINT DF_Orders_OtherPurchasesAmount DEFAULT (0),
        TotalBill DECIMAL(10,2) NOT NULL CONSTRAINT CK_Orders_TotalBill CHECK (TotalBill >= 0),
        OrderDate DATETIME NOT NULL CONSTRAINT DF_Orders_OrderDate DEFAULT (GETDATE()),
        Status NVARCHAR(20) NOT NULL CONSTRAINT DF_Orders_Status DEFAULT (N'Pending'),
        PaymentMethod NVARCHAR(20) NOT NULL CONSTRAINT DF_Orders_PaymentMethod DEFAULT (N'Cash'),
        CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerID) REFERENCES dbo.Customers(CustomerID),
        CONSTRAINT CK_Orders_OtherPurchases CHECK (OtherPurchasesAmount >= 0),
        CONSTRAINT CK_Orders_Status CHECK (Status IN (N'Pending', N'Ready', N'Completed', N'Cancelled')),
        CONSTRAINT CK_Orders_PaymentMethod CHECK (PaymentMethod IN (N'Cash', N'Visa'))
    );
END
GO

PRINT 'WrappingReservation database is ready.';
GO



-- Drop existing tables if they exist (this will delete any data!)
USE InventoryDB;
GO

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Orders')
    DROP TABLE Orders;
GO

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Customers')
    DROP TABLE Customers;
GO

-- Create Customers Table
CREATE TABLE Customers
(
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    Phone NVARCHAR(20) NOT NULL UNIQUE,
    Name NVARCHAR(100) NOT NULL
);
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

PRINT 'Tables created successfully!';
GO

-- Verify the tables were created
SELECT TABLE_NAME 
FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_TYPE = 'BASE TABLE'
AND TABLE_NAME IN ('Customers', 'Orders')
ORDER BY TABLE_NAME;
GO

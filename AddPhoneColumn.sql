-- Upgrade an existing Customers table with the required Phone column.
-- Prefer FixDatabaseColumns.sql for the complete application migration.

IF DB_ID(N'WrappingReservation') IS NULL
BEGIN
    THROW 50010, 'Database WrappingReservation does not exist. Run Database.sql first.', 1;
END
GO

USE WrappingReservation;
GO

IF COL_LENGTH(N'dbo.Customers', N'Phone') IS NULL
BEGIN
    ALTER TABLE dbo.Customers ADD Phone NVARCHAR(20) NULL;
    PRINT 'Phone column added as nullable. Populate existing rows before enforcing uniqueness.';
END
ELSE
BEGIN
    PRINT 'Phone column already exists.';
END
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
        PRINT 'Unique constraint was not added because NULL phone numbers remain.';
    ELSE IF EXISTS (SELECT Phone FROM dbo.Customers GROUP BY Phone HAVING COUNT(*) > 1)
        PRINT 'Unique constraint was not added because duplicate phone numbers exist.';
    ELSE
    BEGIN
        ALTER TABLE dbo.Customers ALTER COLUMN Phone NVARCHAR(20) NOT NULL;
        ALTER TABLE dbo.Customers ADD CONSTRAINT UQ_Customers_Phone UNIQUE (Phone);
        PRINT 'Phone column is now required and unique.';
    END
END
GO



-- Create the POS database
CREATE DATABASE AdlawPOSDB;
GO

-- Select the POS database
USE AdlawPOSDB;
GO

-- Store the product categories
CREATE TABLE Categories
(
    CategoryID int IDENTITY(1, 1) PRIMARY KEY,
    CategoryName nvarchar(50) NOT NULL UNIQUE
);
GO

-- Add the default categories
INSERT INTO Categories (CategoryName)
VALUES
    ('Coffee'),
    ('Matcha'),
    ('Non Coffee'),
    ('Refresher');
GO

-- Store administrator accounts
CREATE TABLE UserAccounts
(
    UserID int IDENTITY(1, 1) PRIMARY KEY,
    Username nvarchar(50) NOT NULL UNIQUE,
    PasswordHash char(64) NOT NULL,
    DisplayName nvarchar(100) NOT NULL,
    Role nvarchar(20) NOT NULL,
    IsActive bit NOT NULL DEFAULT (1)
);
GO

-- Add the default administrator account (password: admin123)
INSERT INTO UserAccounts
    (Username, PasswordHash, DisplayName, Role, IsActive)
VALUES
    ('admin',
     '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9',
     'Adlaw Administrator', 'Admin', 1);
GO

-- Store all product records
CREATE TABLE Products
(
    ProductID int IDENTITY(1, 1) PRIMARY KEY,
    ItemCode nvarchar(50) NOT NULL UNIQUE,
    ItemName nvarchar(150) NOT NULL,
    CategoryID int NOT NULL,
    Price decimal(18, 2) NOT NULL,
    Stock int NOT NULL,
    ImagePath nvarchar(500) NULL,
    IsDeleted bit NOT NULL DEFAULT (0),

    CONSTRAINT FK_Products_Categories
        FOREIGN KEY (CategoryID)
        REFERENCES Categories(CategoryID),

    CONSTRAINT CK_Products_Price
        CHECK (Price > 0),

    CONSTRAINT CK_Products_Stock
        CHECK (Stock >= 0)
);
GO

-- Store completed sales
CREATE TABLE Sales
(
    SaleID int IDENTITY(1, 1) PRIMARY KEY,
    SaleDate datetime NOT NULL DEFAULT (GETDATE()),
    TotalAmount decimal(18, 2) NOT NULL
);
GO

-- Store the product sold in each sale
CREATE TABLE SaleItems
(
    SaleItemID int IDENTITY(1, 1) PRIMARY KEY,
    SaleID int NOT NULL,
    ProductID int NULL,
    ItemCode nvarchar(50) NOT NULL,
    ItemName nvarchar(150) NOT NULL,
    Quantity int NOT NULL,
    UnitPrice decimal(18, 2) NOT NULL,
    Subtotal decimal(18, 2) NOT NULL,

    CONSTRAINT FK_SaleItems_Sales
        FOREIGN KEY (SaleID)
        REFERENCES Sales(SaleID),

    CONSTRAINT FK_SaleItems_Products
        FOREIGN KEY (ProductID)
        REFERENCES Products(ProductID)
        ON DELETE SET NULL,

    CONSTRAINT CK_SaleItems_Quantity
        CHECK (Quantity > 0)
);
GO

-- Retrieve all active products
-- Authenticate an active user account
CREATE PROCEDURE Adlaw_Authenticate
    @Username nvarchar(50),
    @PasswordHash char(64)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT UserID, Username, DisplayName, Role
    FROM UserAccounts
    WHERE Username = @Username
      AND PasswordHash = @PasswordHash
      AND IsActive = 1;
END;
GO

-- Retrieve all active products
CREATE PROCEDURE Adlaw_RetrieveProducts
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ProductID, ItemCode, ItemName, CategoryID,
           Price, Stock, ImagePath, IsDeleted
    FROM Products
    WHERE IsDeleted = 0;
END;
GO

-- Search active products by item name
CREATE PROCEDURE Adlaw_SearchProducts
    @ItemName nvarchar(150)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ProductID, ItemCode, ItemName, CategoryID,
           Price, Stock, ImagePath, IsDeleted
    FROM Products
    WHERE IsDeleted = 0
      AND ItemName LIKE '%' + @ItemName + '%';
END;
GO

-- Retrieve all soft-deleted products
CREATE PROCEDURE Adlaw_RetrieveDeletedProducts
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ProductID, ItemCode, ItemName, CategoryID,
           Price, Stock, ImagePath, IsDeleted
    FROM Products
    WHERE IsDeleted = 1;
END;
GO

-- Add a new product
CREATE PROCEDURE Adlaw_AddProduct
    @ItemName nvarchar(150),
    @CategoryID int,
    @Price decimal(18, 2),
    @Stock int,
    @ImagePath nvarchar(500)
AS
BEGIN
    SET NOCOUNT ON;

    -- Use a temporary unique code until the identity value is available
    INSERT INTO Products
        (ItemCode, ItemName, CategoryID, Price, Stock, ImagePath, IsDeleted)
    VALUES
        (CONCAT('TEMP-', CONVERT(nvarchar(36), NEWID())),
         @ItemName, @CategoryID, @Price, @Stock, @ImagePath, 0);

    DECLARE @NewProductID int = CONVERT(int, SCOPE_IDENTITY());

    -- Replace the temporary code with the final automatic item code
    UPDATE Products
    SET ItemCode = CONCAT('PRD-', RIGHT(CONCAT('000000', @NewProductID), 6))
    WHERE ProductID = @NewProductID;

    RETURN @@ROWCOUNT;
END;
GO

-- Update an active product
CREATE PROCEDURE Adlaw_UpdateProduct
    @ProductID int,
    @ItemCode nvarchar(50),
    @ItemName nvarchar(150),
    @CategoryID int,
    @Price decimal(18, 2),
    @Stock int,
    @ImagePath nvarchar(500)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Products
    SET ItemCode = @ItemCode,
        ItemName = @ItemName,
        CategoryID = @CategoryID,
        Price = @Price,
        Stock = @Stock,
        ImagePath = @ImagePath
    WHERE ProductID = @ProductID
      AND IsDeleted = 0;

    RETURN @@ROWCOUNT;
END;
GO

-- Mark a product as deleted
CREATE PROCEDURE Adlaw_SoftDeleteProduct
    @ProductID int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Products
    SET IsDeleted = 1
    WHERE ProductID = @ProductID
      AND IsDeleted = 0;

    RETURN @@ROWCOUNT;
END;
GO

-- Restore a soft-deleted product
CREATE PROCEDURE Adlaw_RestoreProduct
    @ProductID int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Products
    SET IsDeleted = 0
    WHERE ProductID = @ProductID
      AND IsDeleted = 1;

    RETURN @@ROWCOUNT;
END;
GO

-- Permanently delete a soft-deleted product
CREATE PROCEDURE Adlaw_HardDeleteProduct
    @ProductID int
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Products
    WHERE ProductID = @ProductID
      AND IsDeleted = 1;

    RETURN @@ROWCOUNT;
END;
GO

-- Create a sale and reduce the product stock
CREATE PROCEDURE Adlaw_CreateSale
    @ProductID int,
    @Quantity int
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @UnitPrice decimal(18, 2);
    DECLARE @ItemCode nvarchar(50);
    DECLARE @ItemName nvarchar(150);
    DECLARE @SaleID int;
    DECLARE @SoldProduct TABLE
    (
        UnitPrice decimal(18, 2),
        ItemCode nvarchar(50),
        ItemName nvarchar(150)
    );

    BEGIN TRANSACTION;

    -- Lock and reduce stock only when enough quantity remains
    UPDATE Products
    SET Stock = Stock - @Quantity
    OUTPUT inserted.Price, inserted.ItemCode, inserted.ItemName
        INTO @SoldProduct (UnitPrice, ItemCode, ItemName)
    WHERE ProductID = @ProductID
      AND IsDeleted = 0
      AND @Quantity > 0
      AND Stock >= @Quantity;

    SELECT @UnitPrice = Price,
           @ItemCode = ItemCode,
           @ItemName = ItemName
    FROM @SoldProduct;

    INSERT INTO Sales (TotalAmount)
    SELECT @UnitPrice * @Quantity
    FROM @SoldProduct;

    SET @SaleID = SCOPE_IDENTITY();

    INSERT INTO SaleItems
        (SaleID, ProductID, ItemCode, ItemName,
         Quantity, UnitPrice, Subtotal)
    SELECT @SaleID, @ProductID, @ItemCode, @ItemName,
           @Quantity, @UnitPrice, @UnitPrice * @Quantity
    FROM @SoldProduct;

    COMMIT TRANSACTION;

    RETURN COALESCE(@SaleID, 0);
END;
GO

-- Create one sale header for a customer cart
CREATE PROCEDURE Adlaw_CreateSaleHeader
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Sales (TotalAmount)
    VALUES (0);

    RETURN CONVERT(int, SCOPE_IDENTITY());
END;
GO

-- Add one cart item and reduce its product stock
CREATE PROCEDURE Adlaw_AddSaleItem
    @SaleID int,
    @ProductID int,
    @Quantity int
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @SoldProduct TABLE
    (
        ProductID int,
        ItemCode nvarchar(50),
        ItemName nvarchar(150),
        UnitPrice decimal(18, 2)
    );

    UPDATE Products
    SET Stock = Stock - @Quantity
    OUTPUT inserted.ProductID, inserted.ItemCode,
           inserted.ItemName, inserted.Price
        INTO @SoldProduct
    WHERE ProductID = @ProductID
      AND IsDeleted = 0
      AND @Quantity > 0
      AND Stock >= @Quantity;

    INSERT INTO SaleItems
        (SaleID, ProductID, ItemCode, ItemName,
         Quantity, UnitPrice, Subtotal)
    SELECT @SaleID, ProductID, ItemCode, ItemName,
           @Quantity, UnitPrice, UnitPrice * @Quantity
    FROM @SoldProduct;

    UPDATE Sales
    SET TotalAmount = TotalAmount +
        COALESCE((SELECT UnitPrice * @Quantity FROM @SoldProduct), 0)
    WHERE SaleID = @SaleID;

    DECLARE @AddedItemCount int;
    SELECT @AddedItemCount = COUNT(*) FROM @SoldProduct;

    RETURN @AddedItemCount;
END;
GO

-- Retrieve the sales history
CREATE PROCEDURE Adlaw_RetrieveSales
AS
BEGIN
    SET NOCOUNT ON;

    SELECT S.SaleID, S.SaleDate, SI.ItemCode, SI.ItemName,
           SI.Quantity, SI.UnitPrice, SI.Subtotal
    FROM Sales S
    INNER JOIN SaleItems SI ON S.SaleID = SI.SaleID;
END;
GO

-- Retrieve the current product inventory
CREATE PROCEDURE Adlaw_RetrieveInventory
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ProductID, ItemCode, ItemName, Stock
    FROM Products
    WHERE IsDeleted = 0;
END;
GO

-- Add stock to an active product
CREATE PROCEDURE Adlaw_RestockProduct
    @ProductID int,
    @Quantity int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Products
    SET Stock = Stock + @Quantity
    WHERE ProductID = @ProductID
      AND IsDeleted = 0;

    RETURN @@ROWCOUNT;
END;
GO

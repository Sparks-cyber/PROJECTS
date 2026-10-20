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
    CategoryName varchar(50) NOT NULL UNIQUE
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
    Username varchar(50) NOT NULL UNIQUE,
    PasswordHash char(64) NOT NULL,
    DisplayName varchar(100) NOT NULL,
    Role varchar(20) NOT NULL,
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
    ItemCode varchar(50) UNIQUE,
    ItemName varchar(150) NOT NULL,
    CategoryID int NOT NULL,
    Price decimal(18, 2) NOT NULL,
    Stock int NOT NULL,
    ImagePath varchar(500) NULL,
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

-- Add the default products
INSERT INTO Products
    (ItemCode, ItemName, CategoryID, Price, Stock, ImagePath, IsDeleted)
VALUES
    ('PRD-1', 'Adlaw Latte', 1, 95.00, 20, 'ProductImages\COFFEE_Adlaw Latte.png', 0),
    ('PRD-2', 'Americano', 1, 75.00, 20, 'ProductImages\COFFEE_americano.png', 0),
    ('PRD-3', 'Biscoff Latte', 1, 110.00, 20, 'ProductImages\COFFEE_biscoff latte.png', 0),
    ('PRD-4', 'Caramel Coffee', 1, 100.00, 20, 'ProductImages\COFFEE_caramel.png', 0),
    ('PRD-5', 'Choco Chip Coffee', 1, 105.00, 20, 'ProductImages\COFFEE_choco chip.png', 0),
    ('PRD-6', 'Cloud 9 Coffee', 1, 105.00, 20, 'ProductImages\COFFEE_cloud 9.png', 0),
    ('PRD-7', 'Nutty Vanilla', 1, 105.00, 20, 'ProductImages\COFFEE_nutty vanilla.png', 0),
    ('PRD-8', 'Salted Caramel', 1, 105.00, 20, 'ProductImages\COFFEE_salted caramel.png', 0),
    ('PRD-9', 'Spanish Latte', 1, 100.00, 20, 'ProductImages\COFFEE_spanish.png', 0),
    ('PRD-10', 'Spiced Caramel', 1, 105.00, 20, 'ProductImages\COFFEE_spiced caramel.png', 0),
    ('PRD-11', 'White Mocha', 1, 105.00, 20, 'ProductImages\COFFEE_white mocha.png', 0),
    ('PRD-12', 'Matcha Bean', 2, 110.00, 20, 'ProductImages\MATCHA_matcha bean.png', 0),
    ('PRD-13', 'Matcha Berry', 2, 115.00, 20, 'ProductImages\MATCHA_matcha berry.png', 0),
    ('PRD-14', 'Matcha Cloud', 2, 110.00, 20, 'ProductImages\MATCHA_matcha cloud.png', 0),
    ('PRD-15', 'Matcha Milk', 2, 100.00, 20, 'ProductImages\MATCHA_matcha milk.png', 0),
    ('PRD-16', 'Salted Matcha', 2, 110.00, 20, 'ProductImages\MATCHA_salted matcha.png', 0),
    ('PRD-17', 'Berry Choco', 3, 105.00, 20, 'ProductImages\NON_COFFEE_berry choco.png', 0),
    ('PRD-18', 'Biscoff Milk', 3, 105.00, 20, 'ProductImages\NON_COFFEE_biscoff milk.png', 0),
    ('PRD-19', 'Blueberry Milk', 3, 100.00, 20, 'ProductImages\NON_COFFEE_blueberry.png', 0),
    ('PRD-20', 'Dark Chocolate', 3, 105.00, 20, 'ProductImages\NON_COFFEE_dark chocolate.png', 0),
    ('PRD-21', 'Strawberry Milk', 3, 100.00, 20, 'ProductImages\NON_COFFEE_strawberry.png', 0),
    ('PRD-22', 'Ube Milk', 3, 100.00, 20, 'ProductImages\NON_COFFEE_ube.png', 0),
    ('PRD-23', 'Green Refresher', 4, 85.00, 20, 'ProductImages\REFRESHER_GREEN.png', 0),
    ('PRD-24', 'Pink Refresher', 4, 85.00, 20, 'ProductImages\REFRESHER_PINK.png', 0),
    ('PRD-25', 'Purple Refresher', 4, 85.00, 20, 'ProductImages\REFRESHER_PURPLE.png', 0);
GO

-- Store completed sales
CREATE TABLE Sales
(
    SaleID int IDENTITY(1, 1) PRIMARY KEY,
    SaleDate datetime NOT NULL DEFAULT (GETDATE()),
    TotalAmount decimal(18, 2) NOT NULL,
    PaymentMethod varchar(20) NOT NULL
);
GO

-- Store the product sold in each sale
CREATE TABLE SaleItems
(
    SaleItemID int IDENTITY(1, 1) PRIMARY KEY,
    SaleID int NOT NULL,
    ProductID int NULL,
    ItemCode varchar(50) NOT NULL,
    ItemName varchar(150) NOT NULL,
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

-- Authenticate an active user account
CREATE PROCEDURE Adlaw_Authenticate
    @Username varchar(50),
    @PasswordHash char(64)
AS
BEGIN
    -- Match the username and hashed password
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
    -- Return products that are not deleted
    SELECT ProductID, ItemCode, ItemName, CategoryID,
           Price, Stock, ImagePath, IsDeleted
    FROM Products
    WHERE IsDeleted = 0;
END;
GO

-- Search active products by item name
CREATE PROCEDURE Adlaw_SearchProducts
    @ItemName varchar(150)
AS
BEGIN
    -- Find active products with a matching name
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
    -- Return products marked as deleted
    SELECT ProductID, ItemCode, ItemName, CategoryID,
           Price, Stock, ImagePath, IsDeleted
    FROM Products
    WHERE IsDeleted = 1;
END;
GO

-- Add a new product
CREATE PROCEDURE Adlaw_AddProduct
    @ItemName varchar(150),
    @CategoryID int,
    @Price decimal(18, 2),
    @Stock int,
    @ImagePath varchar(500)
AS
BEGIN
    -- Add the product without an item code
    INSERT INTO Products
        (ItemName, CategoryID, Price, Stock, ImagePath, IsDeleted)
    VALUES
        (@ItemName, @CategoryID, @Price, @Stock, @ImagePath, 0);

    -- Create the item code from the new product ID
    UPDATE Products
    SET ItemCode = 'PRD-' + CAST(ProductID AS varchar(10))
    WHERE ProductID = SCOPE_IDENTITY();

END;
GO

-- Update an active product
CREATE PROCEDURE Adlaw_UpdateProduct
    @ProductID int,
    @ItemCode varchar(50),
    @ItemName varchar(150),
    @CategoryID int,
    @Price decimal(18, 2),
    @Stock int,
    @ImagePath varchar(500)
AS
BEGIN
    -- Save the edited product details
    UPDATE Products
    SET ItemCode = @ItemCode,
        ItemName = @ItemName,
        CategoryID = @CategoryID,
        Price = @Price,
        Stock = @Stock,
        ImagePath = @ImagePath
    WHERE ProductID = @ProductID
      AND IsDeleted = 0;

END;
GO

-- Mark a product as deleted
CREATE PROCEDURE Adlaw_SoftDeleteProduct
    @ProductID int
AS
BEGIN
    -- Hide the product from active lists
    UPDATE Products
    SET IsDeleted = 1
    WHERE ProductID = @ProductID
      AND IsDeleted = 0;

END;
GO

-- Restore a soft-deleted product
CREATE PROCEDURE Adlaw_RestoreProduct
    @ProductID int
AS
BEGIN
    -- Return the product to active lists
    UPDATE Products
    SET IsDeleted = 0
    WHERE ProductID = @ProductID
      AND IsDeleted = 1;

END;
GO

-- Permanently delete a soft-deleted product
CREATE PROCEDURE Adlaw_HardDeleteProduct
    @ProductID int
AS
BEGIN
    -- Remove an already deleted product permanently
    DELETE FROM Products
    WHERE ProductID = @ProductID
      AND IsDeleted = 1;

END;
GO

-- Create one sale header for a customer cart
CREATE PROCEDURE Adlaw_CreateSaleHeader
    @PaymentMethod varchar(20)
AS
BEGIN
    -- Start an empty sale for the customer cart
    INSERT INTO Sales (TotalAmount, PaymentMethod)
    VALUES (0, @PaymentMethod);

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
    -- Save the item when enough stock is available
    INSERT INTO SaleItems
        (SaleID, ProductID, ItemCode, ItemName,
         Quantity, UnitPrice, Subtotal)
    SELECT @SaleID, ProductID, ItemCode, ItemName,
           @Quantity, Price, Price * @Quantity
    FROM Products
    WHERE ProductID = @ProductID
      AND IsDeleted = 0
      AND @Quantity > 0
      AND Stock >= @Quantity;

    -- Reduce the stock of the saved item
    UPDATE Products
    SET Stock = Stock - @Quantity
    WHERE ProductID = @ProductID
      AND EXISTS
          (SELECT SaleItemID
           FROM SaleItems
           WHERE SaleID = @SaleID
             AND ProductID = @ProductID);

    -- Recalculate the complete sale total
    UPDATE Sales
    SET TotalAmount =
        (SELECT SUM(Subtotal)
         FROM SaleItems
         WHERE SaleID = @SaleID)
    WHERE SaleID = @SaleID;

    RETURN
        (SELECT COUNT(*)
         FROM SaleItems
         WHERE SaleID = @SaleID
           AND ProductID = @ProductID);
END;
GO

-- Retrieve the sales history
CREATE PROCEDURE Adlaw_RetrieveSales
AS
BEGIN
    -- Return every saved sale item
    SELECT S.SaleID, S.SaleDate, S.PaymentMethod,
           SI.ItemCode, SI.ItemName,
           SI.Quantity, SI.UnitPrice, SI.Subtotal
    FROM Sales S
    INNER JOIN SaleItems SI ON S.SaleID = SI.SaleID;
END;
GO

-- Retrieve the current product inventory
CREATE PROCEDURE Adlaw_RetrieveInventory
AS
BEGIN
    -- Return stock for every active product
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
    -- Increase the selected product stock
    UPDATE Products
    SET Stock = Stock + @Quantity
    WHERE ProductID = @ProductID
      AND IsDeleted = 0;

END;
GO

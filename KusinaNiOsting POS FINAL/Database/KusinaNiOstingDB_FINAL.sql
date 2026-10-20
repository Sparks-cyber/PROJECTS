

CREATE DATABASE KusinaNiOstingDB;

GO

USE KusinaNiOstingDB;

GO

CREATE TABLE Users (
    UserID      INT IDENTITY(1,1) PRIMARY KEY,
    FullName    VARCHAR(100) NOT NULL,
    Username    VARCHAR(50) NOT NULL UNIQUE,
    Password    VARCHAR(64) NOT NULL,
    Role        VARCHAR(30) NOT NULL DEFAULT 'Admin',
    IsActive    BIT NOT NULL DEFAULT 1,
    CreatedAt   DATETIME NOT NULL DEFAULT GETDATE()
);

GO

CREATE TABLE Categories (
    CategoryID      INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName    VARCHAR(60) NOT NULL UNIQUE
);

GO

CREATE TABLE Suppliers (
    SupplierID          INT IDENTITY(1,1) PRIMARY KEY,
    SupplierCode        VARCHAR(20) NOT NULL UNIQUE,
    SupplierName        VARCHAR(100) NOT NULL,
    ContactNo           VARCHAR(30) NULL,
    Supplies            VARCHAR(150) NULL,
    LastDeliveryDate    DATE NULL,
    IsActive            BIT NOT NULL DEFAULT 1
);

GO

CREATE TABLE MenuItems (
    MenuItemID      INT IDENTITY(1,1) PRIMARY KEY,
    ItemCode        VARCHAR(20) NOT NULL UNIQUE,
    ItemName        VARCHAR(100) NOT NULL,
    CategoryID      INT NOT NULL,
    SupplierID      INT NULL,
    Price           DECIMAL(10,2) NOT NULL CHECK (Price >= 0),
    Stock           INT NOT NULL DEFAULT 0 CHECK (Stock >= 0),
    ReorderLevel    INT NOT NULL DEFAULT 5 CHECK (ReorderLevel >= 0),
    IsActive        BIT NOT NULL DEFAULT 1,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
);

GO

CREATE TABLE ProductImages (
    ProductImageID INT IDENTITY(1,1) PRIMARY KEY,
    MenuItemID     INT NOT NULL,
    ImagePath      VARCHAR(500) NOT NULL,
    IsPrimary      BIT NOT NULL DEFAULT 1,
    FOREIGN KEY (MenuItemID) REFERENCES MenuItems(MenuItemID)
);

GO

CREATE TABLE Sales (
    SaleID          INT IDENTITY(1,1) PRIMARY KEY,
    TransactionNo   VARCHAR(30) NOT NULL UNIQUE,
    SaleDate        DATETIME NOT NULL DEFAULT GETDATE(),
    UserID          INT NOT NULL,
    PaymentMethod   VARCHAR(20) NOT NULL DEFAULT 'Cash',
    Subtotal        DECIMAL(12,2) NOT NULL,
    TotalAmount     DECIMAL(12,2) NOT NULL,
    CashReceived    DECIMAL(12,2) NOT NULL,
    ChangeAmount    DECIMAL(12,2) NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

GO

CREATE TABLE SaleItems (
    SaleItemID  INT IDENTITY(1,1) PRIMARY KEY,
    SaleID      INT NOT NULL,
    MenuItemID  INT NOT NULL,
    Quantity    INT NOT NULL CHECK (Quantity > 0),
    UnitPrice   DECIMAL(10,2) NOT NULL,
    Subtotal    DECIMAL(12,2) NOT NULL,
    FOREIGN KEY (SaleID) REFERENCES Sales(SaleID),
    FOREIGN KEY (MenuItemID) REFERENCES MenuItems(MenuItemID)
);

GO

CREATE TABLE InventoryLogs (
    InventoryLogID INT IDENTITY(1,1) PRIMARY KEY,
    MenuItemID     INT NOT NULL,
    QuantityChange INT NOT NULL,
    PreviousStock  INT NOT NULL,
    NewStock       INT NOT NULL,
    Reason         VARCHAR(100) NULL,
    LogDate        DATETIME NOT NULL DEFAULT GETDATE(),
    UserID         INT NULL,
    FOREIGN KEY (MenuItemID) REFERENCES MenuItems(MenuItemID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

GO

CREATE TABLE StoreSettings (
    SettingID       INT IDENTITY(1,1) PRIMARY KEY,
    StoreName       VARCHAR(100) NOT NULL,
    ReceiptFooter   VARCHAR(200) NULL,
    PrintReceipt    BIT NOT NULL DEFAULT 1,
    LowStockAlerts  BIT NOT NULL DEFAULT 1,
    SoundEffects    BIT NOT NULL DEFAULT 0
);

GO

-- STARTING DATA
INSERT INTO Users (FullName, Username, Password, Role, IsActive)
VALUES ('Administrator', 'admin', '9D39DD891B174041B3488557421FAE0F8D551E1F612725717D820BDBB111530F', 'Admin', 1);

INSERT INTO Categories (CategoryName)
VALUES ('Noodles'), ('Rice & Egg'), ('Canned Goods'), ('Drinks');

INSERT INTO Suppliers (SupplierCode, SupplierName, ContactNo, Supplies, LastDeliveryDate, IsActive)
VALUES
('S-001', 'Local Grocery Supplier', '0912 000 1001', 'Noodles and canned goods', GETDATE(), 1),
('S-002', 'Local Egg Supplier', '0912 000 1002', 'Eggs', GETDATE(), 1),
('S-003', 'Rice Supplier', '0912 000 1003', 'Rice', GETDATE(), 1),
('S-004', 'Beverage Supplier', '0912 000 1004', 'Softdrinks and water', GETDATE(), 1);

INSERT INTO MenuItems (ItemCode, ItemName, CategoryID, SupplierID, Price, Stock, ReorderLevel, IsActive)
VALUES
('N-001', 'Lucky Me Beef na Beef',                  1, 1, 25.00, 20, 5, 1),
('N-002', 'Lucky Me Beef na Beef + Egg',            1, 1, 35.00, 18, 5, 1),
('N-003', 'Lucky Me Chicken na Chicken',             1, 1, 25.00, 20, 5, 1),
('N-004', 'Lucky Me Chicken na Chicken + Egg',       1, 1, 35.00, 18, 5, 1),
('N-005', 'Lucky Me Spicy Labuyo Pork',              1, 1, 25.00, 20, 5, 1),
('N-006', 'Lucky Me Spicy Labuyo Pork + Egg',        1, 1, 35.00, 18, 5, 1),
('N-007', 'Pancit Canton Kalamansi',                 1, 1, 30.00, 25, 5, 1),
('N-008', 'Pancit Canton Chilimansi',                1, 1, 30.00, 25, 5, 1),
('N-009', 'Pancit Canton Sweet & Spicy',             1, 1, 30.00, 25, 5, 1),
('N-010', 'Pancit Canton Extra Hot Chili',           1, 1, 30.00, 25, 5, 1),
('C-001', 'Century Tuna Flakes in Oil',              3,  1, 42.00, 14, 5, 1),
('C-002', 'Tuna Flakes Rice with Egg',               2, 1, 79.00, 12, 5, 1),
('C-003', 'Century Tuna Hot & Spicy',                3,  1, 44.00, 13, 5, 1),
('C-004', 'Hot Tuna Rice with Egg',                  2, 1, 82.00, 10, 5, 1),
('C-005', 'Holiday Carne Norte',                     3,  1, 48.00, 12, 5, 1),
('C-006', 'Carne Norte Rice with Egg',               2, 1, 82.00,  9, 5, 1),
('C-007', 'Holiday Corned Beef',                     3,  1, 52.00, 11, 5, 1),
('C-008', 'Corned Beef Rice with Egg',               2, 1, 85.00,  9, 5, 1),
('B-001', 'Holiday Beef Loaf',                       3,  1, 48.00, 14, 5, 1),
('B-002', 'Holiday Spicy Hot Beef Loaf',             3,  1, 50.00, 12, 5, 1),
('B-003', 'Holiday Beef Loaf with Egg',              2, 1, 75.00, 10, 5, 1),
('B-004', 'Spicy Hot Beef Loaf with Egg',            2, 1, 79.00,  8, 5, 1),
('R-001', 'Steamed White Rice',                      2, 3,    15.00, 40,10, 1),
('D-001', 'Coca-Cola 500ml',                         4,  4,30.00, 25, 5, 1),
('D-002', 'Royal Tru-Orange 250ml',                  4,  4,20.00, 25, 5, 1),
('D-003', 'Sprite Lemon-Lime',                       4,  4,25.00, 25, 5, 1),
('D-004', 'Mountain Dew',                            4,  4,25.00, 25, 5, 1),
('D-005', 'Nature''s Spring Water 2000ml',           4,  4,35.00, 20, 5, 1);

-- Product images
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\lucky_me_beef_na_beef.png', 1 FROM MenuItems WHERE ItemCode='N-001';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\lucky_me_beef_na_beef_with_egg.png', 1 FROM MenuItems WHERE ItemCode='N-002';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\lucky_me_chicken_na_chicken.png', 1 FROM MenuItems WHERE ItemCode='N-003';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\lucky_me_chicken_na_chicken_with_egg.png', 1 FROM MenuItems WHERE ItemCode='N-004';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\lucky_me_chicken_na_chicken_with_egg_alt.png', 0 FROM MenuItems WHERE ItemCode='N-004';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\lucky_me_spicy_labuyo_pork.png', 1 FROM MenuItems WHERE ItemCode='N-005';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\lucky_me_spicy_labuyo_pork_with_egg.png', 1 FROM MenuItems WHERE ItemCode='N-006';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\lucky_me_pancit_canton_kalamansi.png', 1 FROM MenuItems WHERE ItemCode='N-007';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\lucky_me_pancit_canton_chilimansi.png', 1 FROM MenuItems WHERE ItemCode='N-008';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\lucky_me_pancit_canton_sweet_spicy.png', 1 FROM MenuItems WHERE ItemCode='N-009';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\lucky_me_pancit_canton_extra_hot_chili.png', 1 FROM MenuItems WHERE ItemCode='N-010';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\century_tuna_flakes_in_oil.png', 1 FROM MenuItems WHERE ItemCode='C-001';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\century_tuna_flakes_in_oil_with_egg.png', 1 FROM MenuItems WHERE ItemCode='C-002';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\century_tuna_hot_and_spicy.png', 1 FROM MenuItems WHERE ItemCode='C-003';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\century_tuna_hot_and_spicy_with_egg.png', 1 FROM MenuItems WHERE ItemCode='C-004';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\holiday_carne_norte.png', 1 FROM MenuItems WHERE ItemCode='C-005';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\holiday_carne_norte_with_egg.png', 1 FROM MenuItems WHERE ItemCode='C-006';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\holiday_corned_beef.png', 1 FROM MenuItems WHERE ItemCode='C-007';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\holiday_corned_beef_with_egg.png', 1 FROM MenuItems WHERE ItemCode='C-008';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\holiday_beef_loaf.png', 1 FROM MenuItems WHERE ItemCode='B-001';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\holiday_spicy_hot_beef_loaf.png', 1 FROM MenuItems WHERE ItemCode='B-002';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\holiday_beef_loaf_with_egg.png', 1 FROM MenuItems WHERE ItemCode='B-003';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\holiday_spicy_hot_beef_loaf_with_egg.png', 1 FROM MenuItems WHERE ItemCode='B-004';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\steamed_white_rice.png', 1 FROM MenuItems WHERE ItemCode='R-001';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\coca_cola_500ml.png', 1 FROM MenuItems WHERE ItemCode='D-001';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\royal_tru_orange_250ml.png', 1 FROM MenuItems WHERE ItemCode='D-002';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\sprite_lemon_lime.png', 1 FROM MenuItems WHERE ItemCode='D-003';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\mountain_dew.png', 1 FROM MenuItems WHERE ItemCode='D-004';
INSERT INTO ProductImages (MenuItemID, ImagePath, IsPrimary)
SELECT MenuItemID, 'Images\Products\natures_spring_water_2000ml.png', 1 FROM MenuItems WHERE ItemCode='D-005';

INSERT INTO StoreSettings (StoreName, ReceiptFooter, PrintReceipt, LowStockAlerts, SoundEffects)
VALUES ('Kusina ni Osting', 'Kaon kay gamiton', 1, 1, 0);

GO

-- STORED PROCEDURES

-- RETRIEVE PRODUCTS
CREATE PROCEDURE GetMenuItems
AS
SELECT M.MenuItemID, M.ItemCode, M.ItemName, C.CategoryName, M.Price, M.Stock,
       M.ReorderLevel, M.IsActive, P.ImagePath
FROM MenuItems M
INNER JOIN Categories C ON M.CategoryID = C.CategoryID
LEFT JOIN ProductImages P ON M.MenuItemID = P.MenuItemID AND P.IsPrimary = 1
ORDER BY M.IsActive DESC, M.ItemName;

GO

-- SET PRODUCT STATUS (SOFT DELETE / RESTORE)
CREATE PROCEDURE SetProductStatus
    @MenuItemID INT,
    @IsActive BIT
AS
UPDATE MenuItems
SET IsActive = @IsActive
WHERE MenuItemID = @MenuItemID;

GO

-- HARD DELETE PRODUCT
CREATE PROCEDURE HardDeleteMenuItem
    @MenuItemID INT
AS
-- Delete the product records.
-- The foreign key prevents deletion when the product has sales history.
DELETE FROM ProductImages WHERE MenuItemID = @MenuItemID;
DELETE FROM InventoryLogs WHERE MenuItemID = @MenuItemID;
DELETE FROM MenuItems WHERE MenuItemID = @MenuItemID;

GO

-- LAB ACTIVITY 1 - POS (AUTHENTICATION)
-- LOGIN
CREATE PROCEDURE GetUserByUsername
    @Username VARCHAR(50)
AS
SELECT U.UserID, U.FullName, U.Username, U.Password, U.Role, U.IsActive, U.CreatedAt
FROM Users U
WHERE U.Username=@Username;

GO

-- LOW STOCK
CREATE PROCEDURE GetLowStockItems
AS
SELECT M.MenuItemID, M.ItemCode, M.ItemName, M.Stock, M.ReorderLevel
FROM MenuItems M
WHERE M.IsActive=1 AND M.Stock<=M.ReorderLevel
ORDER BY M.Stock ASC;

GO

-- RECENT TRANSACTIONS
CREATE PROCEDURE GetRecentTransactions
AS
SELECT TOP 20 S.SaleID, S.TransactionNo, S.SaleDate, S.TotalAmount, S.PaymentMethod, U.FullName AS Cashier
FROM Sales S
INNER JOIN Users U ON S.UserID=U.UserID
ORDER BY S.SaleDate DESC;

GO

-- LOGIN TEST
-- Username: admin
-- Password: admin123
-- Password is stored as SHA-256 hash in Users.Password.

-- SEARCH PRODUCTS
CREATE PROCEDURE SearchProducts
    @Search VARCHAR(100),
    @Sort INT
AS
SELECT
    M.MenuItemID,
    M.ItemCode,
    M.ItemName,
    C.CategoryName,
    M.Price,
    M.Stock,
    M.ReorderLevel,
    M.IsActive,
    P.ImagePath
FROM MenuItems M
INNER JOIN Categories C ON M.CategoryID = C.CategoryID
LEFT JOIN ProductImages P ON M.MenuItemID = P.MenuItemID AND P.IsPrimary = 1
WHERE M.ItemCode LIKE '%' + @Search + '%'
   OR M.ItemName LIKE '%' + @Search + '%'
   OR C.CategoryName LIKE '%' + @Search + '%'
ORDER BY
    CASE WHEN @Sort = 0 THEN M.ItemName END ASC,
    CASE WHEN @Sort = 1 THEN M.ItemName END DESC,
    CASE WHEN @Sort = 2 THEN M.Price END ASC,
    CASE WHEN @Sort = 3 THEN M.Price END DESC,
    CASE WHEN @Sort = 4 THEN M.Stock END ASC,
    CASE WHEN @Sort = 5 THEN M.Stock END DESC,
    CASE WHEN @Sort = 6 THEN M.IsActive END DESC,
    CASE WHEN @Sort = 7 THEN M.IsActive END ASC;

GO

-- LOAD CATEGORIES
CREATE PROCEDURE LoadCategories
AS
SELECT
    C.CategoryID AS ID,
    C.CategoryName AS Name
FROM Categories C
ORDER BY C.CategoryName;

GO

-- LOAD SUPPLIERS
CREATE PROCEDURE LoadSuppliers
AS
SELECT
    S.SupplierID AS ID,
    S.SupplierName AS Name
FROM Suppliers S
WHERE S.IsActive = 1
ORDER BY S.SupplierName;

GO

-- GET PRODUCT
CREATE PROCEDURE GetProduct
    @MenuItemID INT
AS
SELECT
    M.MenuItemID,
    M.ItemCode,
    M.ItemName,
    M.CategoryID,
    M.SupplierID,
    M.Price,
    M.Stock,
    M.ReorderLevel,
    M.IsActive,
    P.ImagePath
FROM MenuItems M
LEFT JOIN ProductImages P ON M.MenuItemID = P.MenuItemID AND P.IsPrimary = 1
WHERE M.MenuItemID = @MenuItemID;

GO

-- ADD PRODUCT
CREATE PROCEDURE AddProduct
    @ItemCode VARCHAR(20),
    @ItemName VARCHAR(100),
    @CategoryID INT,
    @SupplierID INT,
    @Price DECIMAL(10,2),
    @Stock INT,
    @ReorderLevel INT,
    @IsActive BIT,
    @ImagePath VARCHAR(500)
AS
INSERT INTO MenuItems
(ItemCode, ItemName, CategoryID, SupplierID, Price, Stock, ReorderLevel, IsActive)
VALUES
(@ItemCode, @ItemName, @CategoryID, @SupplierID, @Price, @Stock, @ReorderLevel, @IsActive);

-- Save the image using the ID of the product that was just added.
INSERT INTO ProductImages
(MenuItemID, ImagePath, IsPrimary)
VALUES
(SCOPE_IDENTITY(), @ImagePath, 1);

GO

-- UPDATE PRODUCT
CREATE PROCEDURE UpdateProduct
    @MenuItemID INT,
    @ItemCode VARCHAR(20),
    @ItemName VARCHAR(100),
    @CategoryID INT,
    @SupplierID INT,
    @Price DECIMAL(10,2),
    @Stock INT,
    @ReorderLevel INT,
    @ImagePath VARCHAR(500)
AS
UPDATE MenuItems
SET
    ItemCode = @ItemCode,
    ItemName = @ItemName,
    CategoryID = @CategoryID,
    SupplierID = @SupplierID,
    Price = @Price,
    Stock = @Stock,
    ReorderLevel = @ReorderLevel
WHERE MenuItemID = @MenuItemID;

UPDATE ProductImages
SET ImagePath = @ImagePath
WHERE MenuItemID = @MenuItemID AND IsPrimary = 1;

GO

-- AUTHENTICATION
CREATE PROCEDURE LoginUser
    @Username VARCHAR(50),
    @Password VARCHAR(64)
AS
SELECT
    U.UserID,
    U.FullName,
    U.Role
FROM Users U
WHERE U.Username = @Username
AND U.Password = @Password
AND U.IsActive = 1
AND U.Role = 'Admin';

GO

-- SEARCH SUPPLIERS
CREATE PROCEDURE SearchSuppliers
    @Search VARCHAR(100),
    @Sort INT
AS
SELECT SupplierID, SupplierCode, SupplierName, ContactNo,
       Supplies, LastDeliveryDate, IsActive
FROM Suppliers
WHERE SupplierCode LIKE '%' + @Search + '%'
   OR SupplierName LIKE '%' + @Search + '%'
   OR Supplies LIKE '%' + @Search + '%'
ORDER BY
    CASE WHEN @Sort = 0 THEN SupplierName END ASC,
    CASE WHEN @Sort = 1 THEN SupplierName END DESC,
    CASE WHEN @Sort = 2 THEN LastDeliveryDate END DESC,
    CASE WHEN @Sort = 3 THEN LastDeliveryDate END ASC;
GO

-- GET ONE SUPPLIER
CREATE PROCEDURE GetSupplier
    @SupplierID INT
AS
SELECT SupplierID, SupplierCode, SupplierName, ContactNo,
       Supplies, LastDeliveryDate, IsActive
FROM Suppliers
WHERE SupplierID = @SupplierID;
GO

-- ADD SUPPLIER
CREATE PROCEDURE AddSupplier
    @SupplierCode VARCHAR(20),
    @SupplierName VARCHAR(100),
    @ContactNo VARCHAR(30),
    @Supplies VARCHAR(150),
    @LastDeliveryDate DATE,
    @IsActive BIT
AS
INSERT INTO Suppliers
    (SupplierCode, SupplierName, ContactNo, Supplies, LastDeliveryDate, IsActive)
VALUES
    (@SupplierCode, @SupplierName, @ContactNo, @Supplies, @LastDeliveryDate, @IsActive);
GO

-- UPDATE SUPPLIER
CREATE PROCEDURE UpdateSupplier
    @SupplierID INT,
    @SupplierCode VARCHAR(20),
    @SupplierName VARCHAR(100),
    @ContactNo VARCHAR(30),
    @Supplies VARCHAR(150),
    @LastDeliveryDate DATE,
    @IsActive BIT
AS
UPDATE Suppliers
SET SupplierCode = @SupplierCode,
    SupplierName = @SupplierName,
    ContactNo = @ContactNo,
    Supplies = @Supplies,
    LastDeliveryDate = @LastDeliveryDate,
    IsActive = @IsActive
WHERE SupplierID = @SupplierID;
GO

-- DEACTIVATE SUPPLIER
CREATE PROCEDURE DeactivateSupplier
    @SupplierID INT
AS
UPDATE Suppliers
SET IsActive = 0
WHERE SupplierID = @SupplierID;
GO

-- LOAD INVENTORY
CREATE PROCEDURE SP_LoadInventory
    @Search VARCHAR(100), @Sort INT
AS
SELECT M.MenuItemID, M.ItemName, M.Stock, M.ReorderLevel,
       S.SupplierName,
       '' AS StockStatus
FROM MenuItems M
LEFT JOIN Suppliers S ON M.SupplierID = S.SupplierID
WHERE M.IsActive = 1
  AND (@Search = '' OR M.ItemName LIKE '%' + @Search + '%'
       OR S.SupplierName LIKE '%' + @Search + '%')
ORDER BY
    CASE WHEN @Sort = 0 THEN M.Stock END ASC,
    CASE WHEN @Sort = 1 THEN M.Stock END DESC,
    CASE WHEN @Sort = 2 THEN M.ItemName END ASC,
    CASE WHEN @Sort = 3 THEN M.ItemName END DESC,
    CASE WHEN @Sort = 4 THEN S.SupplierName END ASC;
GO

-- LOAD SALES
CREATE PROCEDURE SP_LoadSales
    @Search VARCHAR(100), @Sort INT
AS
SELECT TOP 100 S.SaleID, S.TransactionNo, S.SaleDate, S.TotalAmount,
       S.PaymentMethod, U.FullName AS Cashier,
       (SELECT ISNULL(SUM(SI.Quantity), 0) FROM SaleItems SI
        WHERE SI.SaleID = S.SaleID) AS ItemCount
FROM Sales S
INNER JOIN Users U ON S.UserID = U.UserID
WHERE @Search = '' OR S.TransactionNo LIKE '%' + @Search + '%'
   OR S.PaymentMethod LIKE '%' + @Search + '%'
ORDER BY
    CASE WHEN @Sort = 0 THEN S.SaleDate END DESC,
    CASE WHEN @Sort = 1 THEN S.SaleDate END ASC,
    CASE WHEN @Sort = 2 THEN S.TotalAmount END DESC,
    CASE WHEN @Sort = 3 THEN S.TotalAmount END ASC;
GO

-- ADJUST PRODUCT STOCK
CREATE PROCEDURE AdjustStock
    @MenuItemID INT,
    @QuantityChange INT,
    @Reason VARCHAR(100),
    @UserID INT
AS
INSERT INTO InventoryLogs
    (MenuItemID, QuantityChange, PreviousStock, NewStock, Reason, LogDate, UserID)
SELECT MenuItemID, @QuantityChange, Stock, Stock + @QuantityChange,
       @Reason, GETDATE(), @UserID
FROM MenuItems
WHERE MenuItemID = @MenuItemID;

UPDATE MenuItems
SET Stock = Stock + @QuantityChange
WHERE MenuItemID = @MenuItemID;
GO

-- CREATE SALE HEADER
CREATE PROCEDURE CreateSale
    @TransactionNo VARCHAR(30),
    @SaleDate DATETIME,
    @UserID INT,
    @PaymentMethod VARCHAR(20),
    @Subtotal DECIMAL(12, 2),
    @TotalAmount DECIMAL(12, 2),
    @CashReceived DECIMAL(12, 2),
    @ChangeAmount DECIMAL(12, 2)
AS
INSERT INTO Sales
    (TransactionNo, SaleDate, UserID, PaymentMethod, Subtotal,
     TotalAmount, CashReceived, ChangeAmount)
VALUES
    (@TransactionNo, @SaleDate, @UserID, @PaymentMethod, @Subtotal,
     @TotalAmount, @CashReceived, @ChangeAmount);

SELECT CONVERT(INT, SCOPE_IDENTITY()) AS SaleID;
GO

-- ADD SALE ITEM AND DEDUCT STOCK
CREATE PROCEDURE AddSaleItem
    @SaleID INT,
    @MenuItemID INT,
    @Quantity INT,
    @UnitPrice DECIMAL(10, 2),
    @Subtotal DECIMAL(12, 2),
    @UserID INT
AS
INSERT INTO SaleItems
    (SaleID, MenuItemID, Quantity, UnitPrice, Subtotal)
VALUES
    (@SaleID, @MenuItemID, @Quantity, @UnitPrice, @Subtotal);

INSERT INTO InventoryLogs
    (MenuItemID, QuantityChange, PreviousStock, NewStock, Reason, LogDate, UserID)
SELECT MenuItemID, -@Quantity, Stock, Stock - @Quantity,
       'Sale', GETDATE(), @UserID
FROM MenuItems
WHERE MenuItemID = @MenuItemID;

UPDATE MenuItems
SET Stock = Stock - @Quantity
WHERE MenuItemID = @MenuItemID;
GO

-- SAVE STORE SETTINGS
CREATE PROCEDURE SaveSettings
    @StoreName VARCHAR(100),
    @ReceiptFooter VARCHAR(200),
    @PrintReceipt BIT,
    @LowStockAlerts BIT,
    @SoundEffects BIT
AS
UPDATE StoreSettings
SET StoreName = @StoreName,
    ReceiptFooter = @ReceiptFooter,
    PrintReceipt = @PrintReceipt,
    LowStockAlerts = @LowStockAlerts,
    SoundEffects = @SoundEffects;
GO

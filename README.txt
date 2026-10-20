ADLAW POS - PROJECT GUIDE
=========================

NOTE ABOUT LINE NUMBERS
-----------------------
The line numbers below match the current project version. They may move when code
is added or removed. Search the method or procedure name if a line number changes.


1. HOW TO OPEN AND RUN
----------------------
1. Open GROUP-PROJECT.sln using Visual Studio on Windows.
2. Make sure SQL Server is running.
3. Create the database by running AdlawPOS.sql when installing for the first time.
4. Check the database connection in GROUP-PROJECT/App.config, lines 5-11.
5. Select Build > Rebuild Solution.
6. Press Start.

The program starts at LandingForm.
File: GROUP-PROJECT/Program.cs, line 16

Default administrator account:
Username: admin
Password: admin123


2. APPLICATION FLOW
-------------------
LandingForm
  |- ORDER NOW      -> CustomerOrderForm
  |- ADMIN LOGIN    -> LoginForm
                         |- Successful login -> Products admin dashboard
                                                  |- Inventory menu
                                                  |- Sales Report menu
                                                  |- Products menu


3. FORMS AND THEIR PURPOSE
--------------------------

A. LandingForm
File: GROUP-PROJECT/LandingForm.cs

- OrderNow, line 10
  Opens the customer ordering screen.

- AdminLogin, line 17
  Opens the administrator login screen.


B. LoginForm
File: GROUP-PROJECT/LoginForm.cs

- btnlogin_Click, line 47
  Gets the username and password, hashes the password, calls the login stored
  procedure, checks the Admin role, and opens the admin dashboard.

- Stored procedure call: Adlaw_Authenticate, line 66
- Password show/hide: lines 27 and 37
- Enter key login: line 102


C. Products
File: GROUP-PROJECT/Products.cs

This is the main administrator form. Inventory and Sales Report are displayed
inside its main content panel.

- Load products: Retrieve, line 49
- Search products: Search, line 57
- Add product event: button2_Click, line 98
- Open Inventory inside the panel: Dashboard_Click, line 128
- Open Sales Report inside the panel: NewOrder_Click, line 135
- Return to Products: ProductsMenu_Click, line 142
- Status filter: StatusChanged, line 217
- Build product table: SetupGrid, line 272
- Display product rows: DisplayProducts, line 446
- Edit selected product: EditSelectedProduct, line 526
- Set Available/Unavailable: ChangeSelectedStatus, line 539
- Hard delete: HardDeleteSelectedProduct, line 555

Stored procedures used by Products:

- Adlaw_RetrieveProducts: lines 53 and 85
- Adlaw_SearchProducts: line 91
- Adlaw_AddProduct: line 109
- Adlaw_RetrieveDeletedProducts: lines 63 and 238
- Adlaw_UpdateProduct: line 589
- Adlaw_HardDeleteProduct: line 618
- Adlaw_SoftDeleteProduct: line 623
- Adlaw_RestoreProduct: line 630


D. AddProductForm
File: GROUP-PROJECT/AddProductForm.cs

- Select product image: btnBrowse_Click, line 92
- Validate and save entered details: btnAdd_Click, line 114
- Cancel: btnCancel_Click, line 188

This form only collects and validates product information. Products.cs calls the
stored procedure after this form returns DialogResult.OK.


E. InventoryForm
File: GROUP-PROJECT/InventoryForm.cs

This form displays product images and stock quantities. It is used only for stock
monitoring and restocking.

- Load inventory: InventoryForm_Load, line 28
- Retrieve and display inventory: RefreshInventory, line 41
- Create inventory columns: SetupImageColumn, line 102
- Show selected product stock: ProductChanged, line 168
- Restock button: RestockProduct, line 182

Stored procedures used by Inventory:

- Adlaw_RetrieveInventory: line 43
- Adlaw_RetrieveProducts: line 44, used to obtain product image paths
- Adlaw_RestockProduct: line 195


F. SalesForm
File: GROUP-PROJECT/SalesForm.cs

This is the administrator sales report. It displays completed orders, items sold,
and total revenue.

- Load report: SalesForm_Load, line 24
- Refresh button: RefreshReport, line 30
- Retrieve and calculate sales summary: LoadSalesReport, line 36
- Stored procedure call: Adlaw_RetrieveSales, line 40


G. CustomerOrderForm
File: GROUP-PROJECT/CustomerOrderForm.cs

This is the customer menu and cart screen.

- Load menu: CustomerOrderForm_Load, line 35
- Search menu: SearchMenu, line 41
- Retrieve menu products: LoadMenu, line 47
- Display product menu: DisplayMenu, line 87
- Add selected product to cart: AddToCart, line 182
- Decrease quantity: DecreaseCartQuantity, line 235
- Increase quantity: IncreaseCartQuantity, line 258
- Remove cart item: RemoveCartItem, line 289
- Calculate total: UpdateTotals, line 320
- Checkout and save order: Checkout, line 325

Stored procedures used by CustomerOrderForm:

- Adlaw_RetrieveProducts: line 54
- Adlaw_SearchProducts: line 58
- Adlaw_CreateSaleHeader: line 353
- Adlaw_AddSaleItem: line 356


H. PaymentForm
File: GROUP-PROJECT/PaymentForm.cs

- Change payment method: PaymentMethodChanged, line 27
- Change cash amount: AmountChanged, line 33
- Update payment display: UpdatePaymentDetails, line 39
- Calculate change: UpdateChange, line 56
- Confirm payment: CompletePayment, line 67
- Cancel payment: CancelPayment, line 83


I. ReceiptForm
File: GROUP-PROJECT/ReceiptForm.cs

- Displays the completed transaction receipt.
- CloseReceipt, line 19


4. LINQ-TO-SQL DATA CONTEXT
---------------------------
File: GROUP-PROJECT/AdlawData.cs

AdlawDataContext is the single database connection class. Forms call these mapped
methods instead of writing SQL queries inside the form.

- Adlaw_Authenticate: line 62
- Adlaw_RetrieveProducts: line 75
- Adlaw_SearchProducts: line 84
- Adlaw_AddProduct: line 95
- Adlaw_UpdateProduct: line 114
- Adlaw_SoftDeleteProduct: line 137
- Adlaw_RestoreProduct: line 147
- Adlaw_HardDeleteProduct: line 157
- Adlaw_RetrieveDeletedProducts: line 167
- Adlaw_CreateSaleHeader: line 176
- Adlaw_AddSaleItem: line 186
- Adlaw_RetrieveSales: line 198
- Adlaw_RetrieveInventory: line 207
- Adlaw_RestockProduct: line 216

The matching DBML definitions are in GROUP-PROJECT/AdlawData.dbml.


5. SQL STORED PROCEDURES
------------------------
File: AdlawPOS.sql

- Adlaw_Authenticate: line 139
  Checks the username and hashed password.

- Adlaw_RetrieveProducts: line 154
  Returns all available products.

- Adlaw_SearchProducts: line 166
  Searches available products by name.

- Adlaw_RetrieveDeletedProducts: line 180
  Returns unavailable or soft-deleted products.

- Adlaw_AddProduct: line 192
  Inserts a new product and creates its item code.

- Adlaw_UpdateProduct: line 215
  Updates product information.

- Adlaw_SoftDeleteProduct: line 240
  Sets a product as unavailable using IsDeleted = 1.

- Adlaw_RestoreProduct: line 254
  Sets an unavailable product back to available.

- Adlaw_HardDeleteProduct: line 268
  Permanently deletes an unavailable product.

- Adlaw_CreateSaleHeader: line 281
  Creates one sale record and returns its SaleID.

- Adlaw_AddSaleItem: line 294
  Adds a cart item to a sale and subtracts its stock.

- Adlaw_RetrieveSales: line 339
  Returns completed sale details for the Sales Report.

- Adlaw_RetrieveInventory: line 352
  Returns active products and their current stock.

- Adlaw_RestockProduct: line 363
  Adds stock to an active product.


6. SOFT DELETE AND HARD DELETE
------------------------------

SET UNAVAILABLE is the soft-delete function. The product stays in the database,
but customers cannot see or order it.

SET AVAILABLE restores the product.

HARD DELETE permanently removes an unavailable product. Use it only when the
record is no longer needed.


7. WHEN TO RUN THE SQL FILE AGAIN
---------------------------------

Do not run AdlawPOS.sql again for normal C# design or form changes.

Run it only for a new database installation. Because the script creates the full
database, running it again on an existing AdlawPOSDB may produce database/table
already exists errors.


CREATE DATABASE SmartShop
GO
USE SmartShop
GO
-- Product
CREATE TABLE Categories (
    ID VARCHAR(20) PRIMARY KEY,
    CategoryName NVARCHAR(50) NOT NULL
);
GO
CREATE TABLE Products (
    ID VARCHAR(20) PRIMARY KEY,
    CategoryID VARCHAR(20) NOT NULL,
    ImageUrl VARCHAR(256) NOT NULL,
    ProductName NVARCHAR(50) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    Quantity INT NOT NULL,
    ProductDescription NVARCHAR(256),
    CONSTRAINT fk_products_category_id FOREIGN KEY (CategoryID) REFERENCES Categories(ID)
);
GO

-- User
CREATE TABLE UserRole (
    ID VARCHAR(20) PRIMARY KEY,
    RoleName NVARCHAR(20) NOT NULL,
);
GO
CREATE TABLE Users (
    ID VARCHAR(20) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Username VARCHAR(50) NOT NULL,
    PasswordHash VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Phone VARCHAR(10) NOT NULL,
    WalletBalance DECIMAL(18, 2) NOT NULL,
    RoleID VARCHAR(20) NOT NULL,
    CONSTRAINT unique_username UNIQUE (Username),
    CONSTRAINT unique_email UNIQUE (Email),
    CONSTRAINT unique_phone UNIQUE (Phone),
    CONSTRAINT fk_users_role_id FOREIGN KEY (RoleID) REFERENCES UserRole(ID)
);
GO
CREATE TABLE UserAddress (
    ID VARCHAR(20) PRIMARY KEY,
    UserID VARCHAR(20) NOT NULl,
    AddressDetails NVARCHAR(256) NOT NULL,
    CONSTRAINT fk_address_user_id FOREIGN KEY (UserID) REFERENCES Users(ID)
);
GO

CREATE TABLE CartItems (
    ID VARCHAR(20) PRIMARY KEY,
    UserID VARCHAR(20) NOT NULL,
    ProductID VARCHAR(20) NOT NULL,
    Quantity int NOT NULL,
    CONSTRAINT fk_carts_user_id FOREIGN KEY (UserID) REFERENCES Users(ID),
    CONSTRAINT fk_cart_items_product_id FOREIGN KEY (ProductID) REFERENCES Products(ID)
);
GO

-- Order
CREATE TABLE OrderStatus (
    ID VARCHAR(20) PRIMARY KEY,
    StatusName NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE Orders (
    ID VARCHAR(20) PRIMARY KEY,
    UserID VARCHAR(20) NOT NULL,
    StatusID VARCHAR(20) NOT NULL,
    OrderDate DATETIME NOT NULL,
    CONSTRAINT fk_orders_user_id FOREIGN KEY (UserID) REFERENCES Users(ID),
    CONSTRAINT fk_orders_status_id FOREIGN KEY (StatusID) REFERENCES OrderStatus(ID)
);
GO

CREATE TABLE OrderItems (
    ID VARCHAR(20) PRIMARY KEY,
    OrderID VARCHAR(20) NOT NULL,
    ProductID VARCHAR(20) NOT NULL,
    Quantity INT NOT NULL,
    CONSTRAINT fk_order_items_order_id FOREIGN KEY (OrderID) REFERENCES Orders(ID),
    CONSTRAINT fk_order_items_product_id FOREIGN KEY (ProductID) REFERENCES Products(ID)
);
GO

--Add data Categorise
INSERT INTO Categories (ID, CategoryName)
VALUES ('CTG0001', 'Electronics'),
       ('CTG0002', 'Clothing'),
       ('CTG0003', 'Home and Garden'),
       ('CTG0004', 'Beauty and Health'),
       ('CTG0005', 'Sports and Outdoors');
--add data to Products 
INSERT INTO Products (ID, CategoryID, ImageUrl, ProductName, Price, Quantity, ProductDescription)
VALUES ('PRO0001', 'CTG0001', 'https://example.com/electronics/1.jpg', 'Smartphone', 500.00, 10, 'The latest smartphone model'),
       ('PRO0002', 'CTG0001', 'https://example.com/electronics/2.jpg', 'Laptop', 1200.00, 5, 'Powerful and versatile laptop'),
       ('PRO0003', 'CTG0002', 'https://example.com/clothing/1.jpg', 'T-Shirt', 20.00, 50, 'Comfortable and stylish t-shirt'),
       ('PRO0004', 'CTG0002', 'https://example.com/clothing/2.jpg', 'Jeans', 50.00, 20, 'High-quality denim jeans'),
       ('PRO0005', 'CTG0003', 'https://example.com/home-garden/1.jpg', 'Bedding Set', 100.00, 8, 'Luxurious and comfortable bedding set'), 
       ('PRO0006', 'CTG0003', 'https://www.example.com/product6.jpg', 'Garden Tools', 30, 40, 'A set of essential garden tools for any gardener.'), 
       ('PRO0007', 'CTG0004', 'https://www.example.com/product7.jpg', 'Skincare Set', 100, 15, 'A set of high-quality skincare products that will leave your skin feeling soft and smooth.'),
       ('PRO0008', 'CTG0004', 'https://www.example.com/product8.jpg', 'Hair Dryer', 50, 25, 'A powerful hair dryer that will quickly dry your hair.'),
       ('PRO0009', 'CTG0005', 'https://www.example.com/product9.jpg', 'Bicycle', 300, 10, 'A high-quality bicycle for outdoor adventures.'),
       ('PRO0010', 'CTG0005', 'https://www.example.com/product10.jpg', 'Running Shoes', 80, 35, 'A comfortable and durable pair of running shoes that will help you go the distance.');
-- Add data to UserRole table
INSERT INTO UserRole (ID, RoleName)
VALUES ('ROLE0001', 'Admin'),
('ROLE0002', 'Customer');

-- Add data to Users table
INSERT INTO Users (ID, FirstName, LastName, Username, PasswordHash, Email, Phone, WalletBalance, RoleID)
VALUES ('USR0001', 'John', 'Doe', 'johndoe', 'hash123', 'johndoe@example.com', '1234567890', 500.00, 'ROLE0002'),
('USR0002', 'Jane', 'Doe', 'janedoe', 'hash456', 'janedoe@example.com', '0987654321', 200.00, 'ROLE0002'),
('USR0003','Bob',' Johnson', 'bobjohnson','789','bob.johnson@example.com', '0111111111',300.00,'ROLE0002' ),
('USR0004','Sarah','Lee','sarahlee','987','sarah.lee@example.com','0222222222',400.00,'ROLE0002'),
('USR0005','Michael','Jordan','michaeljordan','654','mjordan23@example.com','0333333333',700.00,'ROLE0002');

-- Add data to UserAddress table
INSERT INTO UserAddress (ID, UserID, AddressDetails)
VALUES ('URA0001', 'USR0001', '123 Main St, Anytown, USA'),
('URA0002', 'USR0002', '456 Elm St, Anytown, USA'),
('URA0003', 'USR0003', '789 Oak St, Chicago, USA'),
('URA0004', 'USR0004', '2468 Maple Ave, Toronto, Canada'),
('URA0005', 'USR0005', '135 King St, Melbourne, Australia');


-- Add data to CartItems table
INSERT INTO CartItems (ID, UserID, ProductID, Quantity)
VALUES 
    ('CAI0001', 'USR0001', 'PRO0001', 1),
    ('CAI0002', 'USR0001', 'PRO0003', 1),
    ('CAI0003', 'USR0001', 'PRO0003', 3),
    ('CAI0004', 'USR0001', 'PRO0006', 1),
    ('CAI0005', 'USR0001', 'PRO0004', 4);
--Add data to OrderStatus
INSERT INTO OrderStatus (ID, StatusName)
VALUES
('ORS0001', 'Đang xử lý'),
('ORS0002', 'Hủy');
--Add data to Orders
INSERT INTO Orders (ID, UserID, StatusID, OrderDate)
VALUES
('OR0001', 'USR0001', 'ORS0001', '2023-04-28 15:30:00'),
('OR0002', 'USR0002', 'ORS0001', '2023-04-27 10:15:00'),
('OR0003', 'USR0003', 'ORS0001', '2023-04-26 08:45:00');
--Add data to OrderItems
INSERT INTO OrderItems (ID, OrderID, ProductID, Quantity)
VALUES
('ORI0001', 'OR0001', 'PRO0001', 1),
('ORI0002', 'OR0002', 'PRO0003', 1),
('ORI0003', 'OR0003', 'PRO0004', 4);
GO
------------------------------------------------------

--function: calculate total each order item
CREATE FUNCTION fn_CalculateTotalOrderItem(@OrdItemID NVARCHAR(20))
    RETURNS DECIMAL(18, 2)
BEGIN
    DECLARE @ItemPrice DECIMAL(18, 2) = 0
    DECLARE @ProdID NVARCHAR(20)

    -- get product of item
    SELECT @ProdID = ProductID
    FROM OrderItems
    WHERE ID = @OrdItemID

    SELECT @ItemPrice = Price
    FROM Products
    WHERE ID = @ProdID

    SELECT @ItemPrice = @ItemPrice + Quantity
    FROM OrderItems
    WHERE OrderID = @OrdItemID

    RETURN @ItemPrice
END;
GO
----------------------------------------------------------

--function: Calculate total price of order
CREATE FUNCTION fn_CalculateTotalOrder(@OrderID nvarchar(20))
    RETURNS DECIMAL(18, 2)
BEGIN
    DECLARE @Total DECIMAL(18, 2) = 0;

    SELECT @Total = SUM(dbo.fn_CalculateTotalOrderItem(ID) * Quantity)
    FROM OrderItems
    WHERE OrderID = @OrderID;

    RETURN @Total;
END;
GO
----------------------------------------------------------

--Stored Procedure: get order date
CREATE PROCEDURE sp_GetOrdersByDateRange
    @startDate DATETIME,
    @endDate DATETIME
AS
BEGIN
    SELECT *
    FROM Orders
    WHERE OrderDate BETWEEN @startDate AND @endDate 
       OR OrderDate = @startDate 
       OR OrderDate = @endDate
END
GO
--EXEC sp_GetOrdersByDateRange '2023-01-25', '2023-04-27'
--DROP PROCEDURE sp_GetOrdersByDateRange

-----------------------------
--Stored Procedure: Add Catagory

CREATE PROCEDURE sp_AddCategory
    @CategoryID VARCHAR(20),
    @CategoryName NVARCHAR(50)
AS
BEGIN
    INSERT INTO Categories (ID, CategoryName)
    VALUES (@CategoryID, @CategoryName)
END
GO
--Stored Procedure: Update Catagory

CREATE PROCEDURE sp_UpdateCategory
    @CategoryID VARCHAR(20),
    @NewCategoryName NVARCHAR(50)
AS
BEGIN
    UPDATE Categories
    SET CategoryName = @NewCategoryName
    WHERE ID = @CategoryID
END
GO
--Stored Procedure: Delete Catagory

CREATE PROCEDURE sp_DeleteCategory
    @CategoryID VARCHAR(20)
AS
BEGIN
    DELETE FROM Categories
    WHERE ID = @CategoryID
END
GO
---------------------------------------------------------
--Stored Procedure: Add Product

CREATE PROCEDURE sp_AddProduct
    @ProductID VARCHAR(20),
    @CategoryID VARCHAR(20),
    @ImageUrl VARCHAR(256),
    @ProductName NVARCHAR(50),
    @Price DECIMAL(18, 2),
    @Quantity INT,
    @ProductDescription NVARCHAR(256)
AS
BEGIN
    INSERT INTO Products (ID, CategoryID, ImageUrl, ProductName, Price, Quantity, ProductDescription)
    VALUES (@ProductID, @CategoryID, @ImageUrl, @ProductName, @Price, @Quantity, @ProductDescription)
END
GO
--Stored Procedure: Update Product

CREATE PROCEDURE sp_UpdateProduct
    @ProductID VARCHAR(20),
    @NewCategoryID VARCHAR(20),
    @NewImageUrl VARCHAR(256),
    @NewProductName NVARCHAR(50),
    @NewPrice DECIMAL(18, 2),
    @NewQuantity INT,
    @NewProductDescription NVARCHAR(256)
AS
BEGIN
    UPDATE Products
    SET CategoryID = @NewCategoryID,
        ImageUrl = @NewImageUrl,
        ProductName = @NewProductName,
        Price = @NewPrice,
        Quantity = @NewQuantity,
        ProductDescription = @NewProductDescription
    WHERE ID = @ProductID
END
GO
--Stored Procedure: Search Product

CREATE PROCEDURE sp_Ser_Prod_By_ID
    @ID varchar(20)
AS
BEGIN
    SELECT * 
    FROM Products
    WHERE ID = @ID
END
GO
--Stored Procedure: Delete Product

CREATE PROCEDURE sp_DeleteProduct
    @ProductID VARCHAR(20)
AS
BEGIN
    DELETE FROM Products
    WHERE ID = @ProductID
END
GO
----------------------------------------------------------
--Stored Proceduce: Add UserRole

CREATE PROCEDURE sp_AddUserRole
    @RoleID VARCHAR(20),
    @RoleName NVARCHAR(20)
AS
BEGIN
    INSERT INTO UserRole (ID, RoleName)
    VALUES (@RoleID, @RoleName)
END
GO
--Stored Proceduce: Update UserRole

CREATE PROCEDURE sp_UpdateUserRole
    @RoleID VARCHAR(20),
    @NewRoleName NVARCHAR(20)
AS
BEGIN
    UPDATE UserRole
    SET RoleName = @NewRoleName
    WHERE ID = @RoleID
END
GO
--Stored Proceduce: Delete UserRole

CREATE PROCEDURE sp_DeleteUserRole
    @RoleID VARCHAR(20)
AS
BEGIN
    DELETE FROM UserRole
    WHERE ID = @RoleID
END
GO
--Stored Procedure: Search UserRole

CREATE PROCEDURE sp_Ser_UserR_By_ID
    @ID varchar(20)
AS
BEGIN
    SELECT * 
    FROM UserRole
    WHERE ID = @ID
END
GO
----------------------------------------------------------
--Stored Procedure: Add User

CREATE PROCEDURE sp_AddUser
    @UserID VARCHAR(20),
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Username VARCHAR(50),
    @PasswordHash VARCHAR(50),
    @Email VARCHAR(100),
    @Phone VARCHAR(10),
    @WalletBalance DECIMAL(18, 2),
    @RoleID VARCHAR(20)
AS
BEGIN
    INSERT INTO Users (ID, FirstName, LastName, Username, PasswordHash, Email, Phone, WalletBalance, RoleID)
    VALUES (@UserID, @FirstName, @LastName, @Username, @PasswordHash, @Email, @Phone, @WalletBalance, @RoleID)
END
GO

--Stored Procedure: Update User

CREATE PROCEDURE sp_UpdateUser
    @UserID VARCHAR(20),
    @NewFirstName NVARCHAR(50),
    @NewLastName NVARCHAR(50),
    @NewUsername VARCHAR(50),
    @NewPasswordHash VARCHAR(50),
    @NewEmail VARCHAR(100),
    @NewPhone VARCHAR(10),
    @NewWalletBalance DECIMAL(18, 2),
    @NewRoleID VARCHAR(20)
AS
BEGIN
    UPDATE Users
    SET FirstName = @NewFirstName,
        LastName = @NewLastName,
        Username = @NewUsername,
        PasswordHash = @NewPasswordHash,
        Email = @NewEmail,
        Phone = @NewPhone,
        WalletBalance = @NewWalletBalance,
        RoleID = @NewRoleID
    WHERE ID = @UserID
END
GO

--Stored Procedure: Delete User

CREATE PROCEDURE sp_DeleteUser
    @UserID VARCHAR(20)
AS
BEGIN
	DELETE FROM UserAddress
    WHERE UserID = @UserID
    DELETE FROM Users
    WHERE ID = @UserID
END
GO
--Stored Procedure: Search UserRole

CREATE PROCEDURE sp_Ser_User_By_ID
    @ID varchar(20)
AS
BEGIN
    SELECT * 
    FROM Users
    WHERE ID = @ID
END
GO
----------------------------------------------------------
--Stored Procedure: Add UserAddress

CREATE PROCEDURE sp_AddUserAddress
    @AddressID VARCHAR(20),
    @UserID VARCHAR(20),
    @AddressDetails NVARCHAR(256)
AS
BEGIN
    INSERT INTO UserAddress (ID, UserID, AddressDetails)
    VALUES (@AddressID, @UserID, @AddressDetails)
END
GO
--Stored Procedure: Update UserAddress

CREATE PROCEDURE sp_UpdateUserAddress
    @AddressID VARCHAR(20),
    @NewUserID VARCHAR(20),
    @NewAddressDetails NVARCHAR(256)
AS
BEGIN
    UPDATE UserAddress
    SET UserID = @NewUserID,
        AddressDetails = @NewAddressDetails
    WHERE ID = @AddressID
END
GO
--Stored Procedure: Delete UserAddress

CREATE PROCEDURE sp_DeleteUserAddress
    @AddressID VARCHAR(20)
AS
BEGIN
    DELETE FROM UserAddress
    WHERE ID = @AddressID
END
GO
--Stored Procedure: Search UserAddress

CREATE PROCEDURE sp_Ser_UserA_By_ID
    @ID varchar(20)
AS
BEGIN
    SELECT * 
    FROM UserAddress
    WHERE ID = @ID
END
GO
----------------------------------------------------------

--Stored Procedure: Add CartItem
CREATE PROCEDURE sp_AddCartItem
    @CartItemID VARCHAR(20),
    @UserID VARCHAR(20),
    @ProductID VARCHAR(20),
    @Quantity INT
AS
BEGIN
    INSERT INTO CartItems (ID, UserID, ProductID, Quantity)
    VALUES (@CartItemID, @UserID, @ProductID, @Quantity)
END
GO
--Stored Procedure: Update CartItem

CREATE PROCEDURE sp_UpdateCartItem
    @CartItemID VARCHAR(20),
    @New@UserID VARCHAR(20),
    @NewProductID VARCHAR(20),
    @NewQuantity INT
AS
BEGIN
    UPDATE CartItems
    SET UserID = @New@UserID,
        ProductID = @NewProductID,
        Quantity = @NewQuantity
    WHERE ID = @CartItemID
END
GO
--Stored Procedure: Delete CartItem

CREATE PROCEDURE sp_DeleteCartItem
    @CartItemID VARCHAR(20)
AS
BEGIN
    DELETE FROM CartItems
    WHERE ID = @CartItemID
END
GO
--Stored Procedure: Search CartItems

CREATE PROCEDURE sp_Ser_CartItems_By_ID
    @ID varchar(20)
AS
BEGIN
    SELECT * 
    FROM CartItems
    WHERE ID = @ID
END
GO
----------------------------------------------------------
--Stored Procedure: Add OrderStatus

CREATE PROCEDURE sp_AddOrderStatus
    @StatusID VARCHAR(20),
    @StatusName NVARCHAR(50)
AS
BEGIN
    INSERT INTO OrderStatus (ID, StatusName)
    VALUES (@StatusID, @StatusName)
END
GO
--Stored Procedure: Update OrderStatus

CREATE PROCEDURE sp_UpdateOrderStatus
    @StatusID VARCHAR(20),
    @NewStatusName NVARCHAR(50)
AS
BEGIN
    UPDATE OrderStatus
    SET StatusName = @NewStatusName
    WHERE ID = @StatusID
END
GO
--Stored Procedure: Delete OrderStatus

CREATE PROCEDURE sp_DeleteOrderStatus
    @StatusID VARCHAR(20)
AS
BEGIN
    DELETE FROM OrderStatus
    WHERE ID = @StatusID
END
GO
--Stored Procedure: Search OrderStatus

CREATE PROCEDURE sp_Ser_OrderStatus_By_ID
    @ID varchar(20)
AS
BEGIN
    SELECT * 
    FROM OrderStatus
    WHERE ID = @ID
END
GO
----------------------------------------------------------
--Stored Procedure: Add Order

CREATE PROCEDURE sp_AddOrder
    @OrderID VARCHAR(20),
    @UserID VARCHAR(20),
    @StatusID VARCHAR(20),
    @OrderDate DATETIME
AS
BEGIN
    INSERT INTO Orders (ID, UserID, StatusID, OrderDate)
    VALUES (@OrderID, @UserID, @StatusID, @OrderDate)
END
GO
--Stored Procedure: Update Order

CREATE PROCEDURE sp_UpdateOrder
    @OrderID VARCHAR(20),
    @NewUserID VARCHAR(20),
    @NewStatusID VARCHAR(20),
    @NewOrderDate DATETIME
AS
BEGIN
    UPDATE Orders
    SET UserID = @NewUserID,
        StatusID = @NewStatusID,
        OrderDate = @NewOrderDate
    WHERE ID = @OrderID
END
GO
--Stored Procedure: Delete Order

CREATE PROCEDURE sp_DeleteOrder
    @OrderID VARCHAR(20)
AS
BEGIN
	DELETE FROM OrderItems
    WHERE OrderID = @OrderID
    DELETE FROM Orders
    WHERE ID = @OrderID
END
GO
--Stored Procedure: Search Order

CREATE PROCEDURE sp_Ser_Order_By_ID
    @ID varchar(20)
AS
BEGIN
    SELECT * 
    FROM Orders
    WHERE ID = @ID
END
GO
----------------------------------------------------------
--Stored Procedure: Add OrderItem

CREATE PROCEDURE sp_AddOrderItem
    @OrderItemID VARCHAR(20),
    @OrderID VARCHAR(20),
    @ProductID VARCHAR(20),
    @Quantity INT
AS
BEGIN
    INSERT INTO OrderItems (ID, OrderID, ProductID, Quantity)
    VALUES (@OrderItemID, @OrderID, @ProductID, @Quantity)
END
GO
--Stored Procedure: Update OrderItem

CREATE PROCEDURE sp_UpdateOrderItem
    @OrderItemID VARCHAR(20),
    @NewOrderID VARCHAR(20),
    @NewProductID VARCHAR(20),
    @NewQuantity INT
AS
BEGIN
    UPDATE OrderItems
    SET OrderID = @NewOrderID,
        ProductID = @NewProductID,
        Quantity = @NewQuantity
    WHERE ID = @OrderItemID
END
GO
--Stored Procedure: Delete OrderItem

CREATE PROCEDURE sp_DeleteOrderItem
    @OrderItemID VARCHAR(20)
AS
BEGIN
    DELETE FROM OrderItems
    WHERE ID = @OrderItemID
END
GO
--Stored Procedure: Search OrderItems

CREATE PROCEDURE sp_Ser_OrderItem_By_ID
    @ID varchar(20)
AS
BEGIN
    SELECT * 
    FROM OrderItems
    WHERE ID = @ID
END
GO
----------------------------------------------------------

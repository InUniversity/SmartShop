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
    WalletBalance DECIMAL(10, 2) NOT NULL,
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

-- store current cart of user
-- set with trigger at User
CREATE TABLE Carts (
    ID VARCHAR(20) PRIMARY KEY,
    UserID VARCHAR(20) NOT NULL,
    TotalPrice DECIMAL(10, 2) NOT NULL,
    UpdateAt SMALLDATETIME NOT NULL,
    CONSTRAINT fk_carts_user_id FOREIGN KEY (UserID) REFERENCES Users(ID)
);
GO

CREATE TABLE CartItems (
    ID VARCHAR(20) PRIMARY KEY,
    CartID VARCHAR(20) NOT NULL,
    ProductID VARCHAR(20) NOT NULL,
    Quantity int NOT NULL,
    CONSTRAINT fk_cart_items_cart_id FOREIGN KEY (CartID) REFERENCES Carts(ID),
    CONSTRAINT fk_cart_items_product_id FOREIGN KEY (ProductID) REFERENCES Products(ID)
);

-- Order
CREATE TABLE OrderStatus (
    ID VARCHAR(20) PRIMARY KEY,
    StatusName NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE Orders (
    ID VARCHAR(20) PRIMARY KEY,
    UserID VARCHAR(20) NOT NULL,
    OrderStatusID VARCHAR(20) NOT NULL,
    OrderDate DATETIME NOT NULL,
    TotalPrice DECIMAL(18, 2) NOT NULL,
    CONSTRAINT fk_orders_user_id FOREIGN KEY (UserID) REFERENCES Users(ID),
    CONSTRAINT fk_orders_status_id FOREIGN KEY (OrderStatusID) REFERENCES OrderStatus(ID)
);
GO

CREATE TABLE OrderItems (
    ID VARCHAR(20) PRIMARY KEY,
    OrderID VARCHAR(20) NOT NULL,
    ProductID VARCHAR(20) NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    CONSTRAINT fk_order_items_order_id FOREIGN KEY (OrderID) REFERENCES Orders(ID),
    CONSTRAINT fk_order_items_product_id FOREIGN KEY (ProductID) REFERENCES Products(ID)
);
GO

--Add data Categorise
INSERT INTO Categories (ID, CategoryName)
VALUES ('CATE0001', 'Electronics'),
       ('CATE0002', 'Clothing'),
       ('CATE0003', 'Home and Garden'),
       ('CATE0004', 'Beauty and Health'),
       ('CATE0005', 'Sports and Outdoors');
--add data to Products 
INSERT INTO Products (ID, CategoryID, ImageUrl, ProductName, Price, Quantity, ProductDescription)
VALUES ('PRO0001', 'CATE0001', 'https://example.com/electronics/1.jpg', 'Smartphone', 500.00, 10, 'The latest smartphone model'),
       ('PRO0002', 'CATE0001', 'https://example.com/electronics/2.jpg', 'Laptop', 1200.00, 5, 'Powerful and versatile laptop'),
       ('PRO0003', 'CATE0002', 'https://example.com/clothing/1.jpg', 'T-Shirt', 20.00, 50, 'Comfortable and stylish t-shirt'),
       ('PRO0004', 'CATE0002', 'https://example.com/clothing/2.jpg', 'Jeans', 50.00, 20, 'High-quality denim jeans'),
       ('PRO0005', 'CATE0003', 'https://example.com/home-garden/1.jpg', 'Bedding Set', 100.00, 8, 'Luxurious and comfortable bedding set'),
	('PRO0006', 'CATE0003', 'https://www.example.com/product6.jpg', 'Garden Tools', 30, 40, 'A set of essential garden tools for any gardener.'),
	('PRO0007', 'CATE0004', 'https://www.example.com/product7.jpg', 'Skincare Set', 100, 15, 'A set of high-quality skincare products that will leave your skin feeling soft and smooth.'),
       ('PRO0008', 'CATE0004', 'https://www.example.com/product8.jpg', 'Hair Dryer', 50, 25, 'A powerful hair dryer that will quickly dry your hair.'),
       ('PRO0009', 'CATE0005', 'https://www.example.com/product9.jpg', 'Bicycle', 300, 10, 'A high-quality bicycle for outdoor adventures.'),
       ('PRO0010', 'CATE0005', 'https://www.example.com/product10.jpg', 'Running Shoes', 80, 35, 'A comfortable and durable pair of running shoes that will help you go the distance.');
-- Add data to UserRole table
INSERT INTO UserRole (ID, RoleName)
VALUES ('ROLE0001', 'Admin'),
('ROLE0002', 'Customer');

-- Add data to Users table
INSERT INTO Users (ID, FirstName, LastName, Username, PasswordHash, Email, Phone, WalletBalance, RoleID)
VALUES ('USER0001', 'John', 'Doe', 'johndoe', 'hash123', 'johndoe@example.com', '1234567890', 500.00, 'ROLE0002'),
('USER0002', 'Jane', 'Doe', 'janedoe', 'hash456', 'janedoe@example.com', '0987654321', 200.00, 'ROLE0002'),
('USER0003','Bob',' Johnson', 'bobjohnson','789','bob.johnson@example.com', '0111111111',300.00,'ROLE0002' ),
('USER0004','Sarah','Lee','sarahlee','987','sarah.lee@example.com','0222222222',400.00,'ROLE0002'),
('USER0005','Michael','Jordan','michaeljordan','654','mjordan23@example.com','0333333333',700.00,'ROLE0002');

-- Add data to UserAddress table
INSERT INTO UserAddress (ID, UserID, AddressDetails)
VALUES ('USERA0001', 'USER0001', '123 Main St, Anytown, USA'),
('USERA0002', 'USER0002', '456 Elm St, Anytown, USA'),
('USERA0003', 'USER0003', '789 Oak St, Chicago, USA'),
('USERA0004', 'USER0004', '2468 Maple Ave, Toronto, Canada'),
('USERA0005', 'USER0005', '135 King St, Melbourne, Australia');


-- Add data to Carts table
INSERT INTO Carts (ID, UserID, TotalPrice, UpdateAt)
VALUES ('CART0001', 'USER0001', 500.00, '2023-04-27 14:30:00');
INSERT INTO Carts (ID, UserID, TotalPrice, UpdateAt)
VALUES ('CART0002', 'USER0002', 20.00, '2023-04-27 14:45:00');
INSERT INTO Carts (ID, UserID, TotalPrice, UpdateAt)
VALUES ('CART0003', 'USER0003', 290.00, '2023-04-27 15:00:00');
-- Add data to CartItems table
INSERT INTO CartItems (ID, CartID, ProductID, Quantity)
VALUES ('CARTITEM0001', 'CART0001', 'PRO0001', 1);
INSERT INTO CartItems (ID, CartID, ProductID, Quantity)
VALUES ('CARTITEM0002', 'CART0002', 'PRO0003', 1);
INSERT INTO CartItems (ID, CartID, ProductID, Quantity)
VALUES ('CARTITEM0003', 'CART0003', 'PRO0003', 3);
INSERT INTO CartItems (ID, CartID, ProductID, Quantity)
VALUES ('CARTITEM0004', 'CART0003', 'PRO0006', 1);
INSERT INTO CartItems (ID, CartID, ProductID, Quantity)
VALUES ('CARTITEM0005', 'CART0003', 'PRO0004', 4);
--Add data to OrderStatus
INSERT INTO OrderStatus (ID, StatusName)
VALUES
('ORDERS0001', 'Đang xử lý'),
('ORDERS0002', 'Hủy');
--Add data to Orders
INSERT INTO Orders (ID, UserID, OrderStatusID, OrderDate, TotalPrice)
VALUES
('ORDER0001', 'USER0001', 'ORDERS0001', '2023-04-28 15:30:00', 500.00),
('ORDER0002', 'USER0002', 'ORDERS0001', '2023-04-27 10:15:00', 20.00),
('ORDER0003', 'USER0003', 'ORDERS0001', '2023-04-26 08:45:00', 200.00);
--Add data to OrderItems
INSERT INTO OrderItems (ID, OrderID, ProductID, Quantity, Price)
VALUES
('ORDERITEM0001', 'ORDER0001', 'PRO0001', 1, 500.00),
('ORDERITEM0002', 'ORDER0002', 'PRO0003', 1, 20.00),
('ORDERITEM0003', 'ORDER0003', 'PRO0004', 4, 50.00);

----------------------------------
--Trigger Order

CREATE TRIGGER tr_OrderCreated
ON Orders
AFTER INSERT
AS
BEGIN
  DECLARE @UserID VARCHAR(20), @TotalPrice DECIMAL(18,2), @Balance DECIMAL(10,2)

  -- Get User ID and Total Price of the order
  SELECT @UserID = i.UserID, @TotalPrice = i.TotalPrice
  FROM inserted i

  -- Get Balance of the user
  SELECT @Balance = u.WalletBalance
  FROM Users u
  WHERE u.ID = @UserID

  -- Check if user has enough balance to pay for the order
  IF @Balance >= @TotalPrice
  BEGIN
    -- Subtract Total Price from User's Wallet Balance
    UPDATE Users
    SET WalletBalance = WalletBalance - @TotalPrice
    WHERE ID = @UserID
  END
  ELSE
  BEGIN

    -- Raise an Error to Inform User about Insufficient Balance
    RAISERROR ('Your Wallet Balance is Insufficient to Place this Order. Please Top-up your Wallet and try again.', 16, 1)
  END
END
--Trigger cancel
CREATE TRIGGER tr_Order_Cancel
ON Orders
AFTER UPDATE
AS
BEGIN
    IF UPDATE(OrderStatusID)
    BEGIN
        DECLARE @OrderId VARCHAR(20);
        DECLARE @UserId VARCHAR(20);
        DECLARE @TotalPrice DECIMAL(18, 2);
        
        SELECT @OrderId = i.ID, @UserId = i.UserID, @TotalPrice = i.TotalPrice
        FROM inserted i
        --NNER JOIN deleted d ON i.ID = d.ID
        WHERE i.OrderStatusID = 2
        
        IF @OrderId IS NOT NULL AND @UserId IS NOT NULL AND @TotalPrice IS NOT NULL
        BEGIN
            UPDATE Users
            SET WalletBalance = WalletBalance + @TotalPrice
            WHERE ID = @UserId;
        END
    END
END

------------------------------------------------------
--Stored Proceduce: get order date

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

--EXEC sp_GetOrdersByDateRange '2023-01-25', '2023-04-27'
--DROP PROCEDURE sp_GetOrdersByDateRange

-----------------------------
--Stored Proceduce: Add Catagory

CREATE PROCEDURE sp_AddCategory
    @CategoryID VARCHAR(20),
    @CategoryName NVARCHAR(50)
AS
BEGIN
    INSERT INTO Categories (ID, CategoryName)
    VALUES (@CategoryID, @CategoryName)
END

--Stored Proceduce: Update Catagory

CREATE PROCEDURE sp_UpdateCategory
    @CategoryID VARCHAR(20),
    @NewCategoryName NVARCHAR(50)
AS
BEGIN
    UPDATE Categories
    SET CategoryName = @NewCategoryName
    WHERE ID = @CategoryID
END

--Stored Proceduce: Delete Catagory

CREATE PROCEDURE sp_DeleteCategory
    @CategoryID VARCHAR(20)
AS
BEGIN
    DELETE FROM Categories
    WHERE ID = @CategoryID
END
---------------------------------------------------------
--Stored Proceduce: Add Product

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

--Stored Proceduce: Update Product

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

--Stored Proceduce: Delete Product

CREATE PROCEDURE sp_DeleteProduct
    @ProductID VARCHAR(20)
AS
BEGIN
    DELETE FROM Products
    WHERE ID = @ProductID
END

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

--Stored Proceduce: Delete UserRole

CREATE PROCEDURE sp_DeleteUserRole
    @RoleID VARCHAR(20)
AS
BEGIN
    DELETE FROM UserRole
    WHERE ID = @RoleID
END

----------------------------------------------------------
--Stored Proceduce: Add User

CREATE PROCEDURE sp_AddUser
    @UserID VARCHAR(20),
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Username VARCHAR(50),
    @PasswordHash VARCHAR(50),
    @Email VARCHAR(100),
    @Phone VARCHAR(10),
    @WalletBalance DECIMAL(10, 2),
    @RoleID VARCHAR(20)
AS
BEGIN
    INSERT INTO Users (ID, FirstName, LastName, Username, PasswordHash, Email, Phone, WalletBalance, RoleID)
    VALUES (@UserID, @FirstName, @LastName, @Username, @PasswordHash, @Email, @Phone, @WalletBalance, @RoleID)
END


--Stored Proceduce: Update User

CREATE PROCEDURE sp_UpdateUser
    @UserID VARCHAR(20),
    @NewFirstName NVARCHAR(50),
    @NewLastName NVARCHAR(50),
    @NewUsername VARCHAR(50),
    @NewPasswordHash VARCHAR(50),
    @NewEmail VARCHAR(100),
    @NewPhone VARCHAR(10),
    @NewWalletBalance DECIMAL(10, 2),
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


--Stored Proceduce: Delete User

CREATE PROCEDURE sp_DeleteUser
    @UserID VARCHAR(20)
AS
BEGIN
    DELETE FROM Users
    WHERE ID = @UserID
END

----------------------------------------------------------
--Stored Proceduce: Add UserAddress

CREATE PROCEDURE sp_AddUserAddress
    @AddressID VARCHAR(20),
    @UserID VARCHAR(20),
    @AddressDetails NVARCHAR(256)
AS
BEGIN
    INSERT INTO UserAddress (ID, UserID, AddressDetails)
    VALUES (@AddressID, @UserID, @AddressDetails)
END

--Stored Proceduce: Update UserAddress

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

--Stored Proceduce: Delete UserAddress

CREATE PROCEDURE sp_DeleteUserAddress
    @AddressID VARCHAR(20)
AS
BEGIN
    DELETE FROM UserAddress
    WHERE ID = @AddressID
END

----------------------------------------------------------
--Stored Proceduce: Add Cart

CREATE PROCEDURE sp_AddCart
    @CartID VARCHAR(20),
    @UserID VARCHAR(20),
    @TotalPrice DECIMAL(10, 2),
    @UpdateAt SMALLDATETIME
AS
BEGIN
    INSERT INTO Carts (ID, UserID, TotalPrice, UpdateAt)
    VALUES (@CartID, @UserID, @TotalPrice, @UpdateAt)
END

--Stored Proceduce: Update Cart

CREATE PROCEDURE sp_UpdateCart
    @CartID VARCHAR(20),
    @NewUserID VARCHAR(20),
    @NewTotalPrice DECIMAL(10, 2),
    @NewUpdateAt SMALLDATETIME
AS
BEGIN
    UPDATE Carts
    SET UserID = @NewUserID,
        TotalPrice = @NewTotalPrice,
        UpdateAt = @NewUpdateAt
    WHERE ID = @CartID
END

--Stored Proceduce: Delete Cart

CREATE PROCEDURE sp_DeleteCart
    @CartID VARCHAR(20)
AS
BEGIN
    DELETE FROM Carts
    WHERE ID = @CartID
END

----------------------------------------------------------
--Stored Proceduce: Add CartItem

CREATE PROCEDURE sp_AddCartItem
    @CartItemID VARCHAR(20),
    @CartID VARCHAR(20),
    @ProductID VARCHAR(20),
    @Quantity INT
AS
BEGIN
    INSERT INTO CartItems (ID, CartID, ProductID, Quantity)
    VALUES (@CartItemID, @CartID, @ProductID, @Quantity)
END

--Stored Proceduce: Update CartItem

CREATE PROCEDURE sp_UpdateCartItem
    @CartItemID VARCHAR(20),
    @NewCartID VARCHAR(20),
    @NewProductID VARCHAR(20),
    @NewQuantity INT
AS
BEGIN
    UPDATE CartItems
    SET CartID = @NewCartID,
        ProductID = @NewProductID,
        Quantity = @NewQuantity
    WHERE ID = @CartItemID
END

--Stored Proceduce: Delete CartItem

CREATE PROCEDURE sp_DeleteCartItem
    @CartItemID VARCHAR(20)
AS
BEGIN
    DELETE FROM CartItems
    WHERE ID = @CartItemID
END

----------------------------------------------------------
--Stored Proceduce: Add OrderStatus

CREATE PROCEDURE sp_AddOrderStatus
    @StatusID VARCHAR(20),
    @StatusName NVARCHAR(50)
AS
BEGIN
    INSERT INTO OrderStatus (ID, StatusName)
    VALUES (@StatusID, @StatusName)
END

--Stored Proceduce: Update OrderStatus

CREATE PROCEDURE sp_UpdateOrderStatus
    @StatusID VARCHAR(20),
    @NewStatusName NVARCHAR(50)
AS
BEGIN
    UPDATE OrderStatus
    SET StatusName = @NewStatusName
    WHERE ID = @StatusID
END

--Stored Proceduce: Delete OrderStatus

CREATE PROCEDURE sp_DeleteOrderStatus
    @StatusID VARCHAR(20)
AS
BEGIN
    DELETE FROM OrderStatus
    WHERE ID = @StatusID
END

----------------------------------------------------------
--Stored Proceduce: Add Order

CREATE PROCEDURE sp_AddOrder
    @OrderID VARCHAR(20),
    @UserID VARCHAR(20),
    @OrderStatusID VARCHAR(20),
    @OrderDate DATETIME,
    @TotalPrice DECIMAL(18, 2)
AS
BEGIN
    INSERT INTO Orders (ID, UserID, OrderStatusID, OrderDate, TotalPrice)
    VALUES (@OrderID, @UserID, @OrderStatusID, @OrderDate, @TotalPrice)
END

--Stored Proceduce: Update Order

CREATE PROCEDURE sp_UpdateOrder
    @OrderID VARCHAR(20),
    @NewUserID VARCHAR(20),
    @NewOrderStatusID VARCHAR(20),
    @NewOrderDate DATETIME,
    @NewTotalPrice DECIMAL(18, 2)
AS
BEGIN
    UPDATE Orders
    SET UserID = @NewUserID,
        OrderStatusID = @NewOrderStatusID,
        OrderDate = @NewOrderDate,
        TotalPrice = @NewTotalPrice
    WHERE ID = @OrderID
END

--Stored Proceduce: Delete Order

CREATE PROCEDURE sp_DeleteOrder
    @OrderID VARCHAR(20)
AS
BEGIN
    DELETE FROM Orders
    WHERE ID = @OrderID
END

----------------------------------------------------------
--Stored Proceduce: Add OrderItem

CREATE PROCEDURE sp_AddOrderItem
    @OrderItemID VARCHAR(20),
    @OrderID VARCHAR(20),
    @ProductID VARCHAR(20),
    @Quantity INT,
    @Price DECIMAL(18, 2)
AS
BEGIN
    INSERT INTO OrderItems (ID, OrderID, ProductID, Quantity, Price)
    VALUES (@OrderItemID, @OrderID, @ProductID, @Quantity, @Price)
END

--Stored Proceduce: Update OrderItem

CREATE PROCEDURE sp_UpdateOrderItem
    @OrderItemID VARCHAR(20),
    @NewOrderID VARCHAR(20),
    @NewProductID VARCHAR(20),
    @NewQuantity INT,
    @NewPrice DECIMAL(18, 2)
AS
BEGIN
    UPDATE OrderItems
    SET OrderID = @NewOrderID,
        ProductID = @NewProductID,
        Quantity = @NewQuantity,
        Price = @NewPrice
    WHERE ID = @OrderItemID
END

--Stored Proceduce: Delete OrderItem

CREATE PROCEDURE sp_DeleteOrderItem
    @OrderItemID VARCHAR(20)
AS
BEGIN
    DELETE FROM OrderItems
    WHERE ID = @OrderItemID
END
----------------------------------------------------------


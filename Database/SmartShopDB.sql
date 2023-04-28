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
VALUES ('1', 'Electronics'),
       ('2', 'Clothing'),
       ('3', 'Home and Garden'),
       ('4', 'Beauty and Health'),
       ('5', 'Sports and Outdoors');
--add data to Products 
INSERT INTO Products (ID, CategoryID, ImageUrl, ProductName, Price, Quantity, ProductDescription)
VALUES ('1', '1', 'https://example.com/electronics/1.jpg', 'Smartphone', 500.00, 10, 'The latest smartphone model'),
       ('2', '1', 'https://example.com/electronics/2.jpg', 'Laptop', 1200.00, 5, 'Powerful and versatile laptop'),
       ('3', '2', 'https://example.com/clothing/1.jpg', 'T-Shirt', 20.00, 50, 'Comfortable and stylish t-shirt'),
       ('4', '2', 'https://example.com/clothing/2.jpg', 'Jeans', 50.00, 20, 'High-quality denim jeans'),
       ('5', '3', 'https://example.com/home-garden/1.jpg', 'Bedding Set', 100.00, 8, 'Luxurious and comfortable bedding set'),
	   ('6', '3', 'https://www.example.com/product6.jpg', 'Garden Tools', 30, 40, 'A set of essential garden tools for any gardener.'),
	   ('7', '4', 'https://www.example.com/product7.jpg', 'Skincare Set', 100, 15, 'A set of high-quality skincare products that will leave your skin feeling soft and smooth.'),
       ('8', '4', 'https://www.example.com/product8.jpg', 'Hair Dryer', 50, 25, 'A powerful hair dryer that will quickly dry your hair.'),
       ('9', '5', 'https://www.example.com/product9.jpg', 'Bicycle', 300, 10, 'A high-quality bicycle for outdoor adventures.'),
       ('10', '5', 'https://www.example.com/product10.jpg', 'Running Shoes', 80, 35, 'A comfortable and durable pair of running shoes that will help you go the distance.');
-- Add data to UserRole table
INSERT INTO UserRole (ID, RoleName)
VALUES ('1', 'Admin'),
('2', 'Customer');

-- Add data to Users table
INSERT INTO Users (ID, FirstName, LastName, Username, PasswordHash, Email, Phone, WalletBalance, RoleID)
VALUES ('1', 'John', 'Doe', 'johndoe', 'hash123', 'johndoe@example.com', '1234567890', 500.00, '2'),
('2', 'Jane', 'Doe', 'janedoe', 'hash456', 'janedoe@example.com', '0987654321', 200.00, '2'),
('3','Bob',' Johnson', 'bobjohnson','789','bob.johnson@example.com', '0111111111',300.00,'2' ),
('4','Sarah','Lee','sarahlee','987','sarah.lee@example.com','0222222222',400.00,'2'),
('5','Michael','Jordan','michaeljordan','654','mjordan23@example.com','0333333333',700.00,'2');

-- Add data to UserAddress table
INSERT INTO UserAddress (ID, UserID, AddressDetails)
VALUES ('1', '1', '123 Main St, Anytown, USA'),
('2', '2', '456 Elm St, Anytown, USA'),
('3', '3', '789 Oak St, Chicago, USA'),
('4', '4', '2468 Maple Ave, Toronto, Canada'),
('5', '5', '135 King St, Melbourne, Australia');


-- Add data to Carts table
INSERT INTO Carts (ID, UserID, TotalPrice, UpdateAt)
VALUES ('CART0001', '1', 500.00, '2023-04-27 14:30:00');
INSERT INTO Carts (ID, UserID, TotalPrice, UpdateAt)
VALUES ('CART0002', '2', 20.00, '2023-04-27 14:45:00');
INSERT INTO Carts (ID, UserID, TotalPrice, UpdateAt)
VALUES ('CART0003', '3', 290.00, '2023-04-27 15:00:00');
-- Add data to CartItems table
INSERT INTO CartItems (ID, CartID, ProductID, Quantity)
VALUES ('CARTITEM0001', 'CART0001', '1', 1);
INSERT INTO CartItems (ID, CartID, ProductID, Quantity)
VALUES ('CARTITEM0002', 'CART0002', '3', 1);
INSERT INTO CartItems (ID, CartID, ProductID, Quantity)
VALUES ('CARTITEM0003', 'CART0003', '3', 3);
INSERT INTO CartItems (ID, CartID, ProductID, Quantity)
VALUES ('CARTITEM0004', 'CART0003', '6', 1);
INSERT INTO CartItems (ID, CartID, ProductID, Quantity)
VALUES ('CARTITEM0005', 'CART0003', '4', 4);
--Add data to OrderStatus
INSERT INTO OrderStatus (ID, StatusName)
VALUES
('1', 'Đang xử lý'),
('2', 'Hủy');
--Add data to Orders
INSERT INTO Orders (ID, UserID, OrderStatusID, OrderDate, TotalPrice)
VALUES
('1', '1', '1', '2023-04-28 15:30:00', 500.00),
('2', '2', '1', '2023-04-27 10:15:00', 20.00),
('3', '3', '1', '2023-04-26 08:45:00', 200.00);
--Add data to OrderItems
INSERT INTO OrderItems (ID, OrderID, ProductID, Quantity, Price)
VALUES
('1', '1', '1', 1, 500.00),
('2', '2', '3', 1, 20.00),
('3', '3', '4', 4, 50.00);

----------------------------------
--Trigger Order

CREATE TRIGGER trg_OrderCreated
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

CREATE PROCEDURE GetOrdersByDateRange
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

--EXEC GetOrdersByDateRange '2023-01-25', '2023-04-27'
--DROP PROCEDURE GetOrdersByDateRange

-----------------------------

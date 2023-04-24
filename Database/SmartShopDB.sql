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
    ProductID VARCHAR(20) NOT NULL,
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

--Tao Bang
CREATE TABLE Category (
    ID VARCHAR(20) PRIMARY KEY,
    CategoryName NVARCHAR(50) NOT NULL
);

CREATE TABLE Product (
    ProductID VARCHAR(20) PRIMARY KEY,
    ProductName NVARCHAR(50) NOT NULL,
    CategoryID VARCHAR(20) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    Quantity INT NOT NULL,
    ProductDescription NVARCHAR(256),
    CONSTRAINT fk_category FOREIGN KEY (CategoryID) REFERENCES Category(ID)
);

CREATE TABLE Customer (
    UserID VARCHAR(50) PRIMARY KEY,
    Username VARCHAR(50) NOT NULL,
    UserPassword VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Phone VARCHAR(20),
    UserAddress NVARCHAR(50),
    CONSTRAINT unique_username UNIQUE (Username),
    CONSTRAINT unique_email UNIQUE (Email)
);

CREATE TABLE Payment (
    PaymentID VARCHAR(50) PRIMARY KEY,
    PaymentType VARCHAR(50) NOT NULL,
    PaymentDescription TEXT
);

CREATE TABLE Order_ (
    OrderID VARCHAR(50) PRIMARY KEY,
    UserID VARCHAR(50) NOT NULL,
    OrderDate DATETIME NOT NULL,
    TotalPrice DECIMAL(18, 2) NOT NULL,
    PaymentID VARCHAR(50) NOT NULL,
    ProductID VARCHAR(50) NOT NULL,
    CONSTRAINT fk_user FOREIGN KEY (UserID) REFERENCES User_(UserID),
    CONSTRAINT fk_payment FOREIGN KEY (PaymentID) REFERENCES Payment(PaymentID)
);

CREATE TABLE Order_Item (
    OrderItemID VARCHAR(50) PRIMARY KEY,
    OrderID VARCHAR(50) NOT NULL,
    ProductID VARCHAR(50) NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    CONSTRAINT fk_order FOREIGN KEY (OrderID) REFERENCES Order_(OrderID),
    CONSTRAINT fk_product FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

--Them User
INSERT INTO User_ (UserID, Username, Password, Email,Phone,Address)
VALUES ('01', 'dieu', 123, 'dieu@gmail.com','0111111111','Dak Nong');

INSERT INTO User_ (UserID, Username, Password, Email,Phone,Address)
VALUES ('02', 'An', 123, 'an@gmail.com','0222222222','Dong Nai');

INSERT INTO User_ (UserID, Username, Password, Email,Phone,Address)
VALUES ('03', 'tan', 123, 'tan@gmail.com','0333333333','Tra Vinh');

INSERT INTO User_ (UserID, Username, Password, Email,Phone,Address)
VALUES ('04', 'hung', 123, 'hung@gmail.com','0444444444','Nghe An');

--select * from User_
--DELETE FROM User_ WHERE UserID=2;

--Them Category

INSERT INTO Category(ID,CategoryName)
VALUES ('01', 'Ghe');

INSERT INTO Category(ID,CategoryName)
VALUES ('02', 'Ban');

INSERT INTO Category(ID,CategoryName)
VALUES ('03', 'Dien Thoai');

--select * from Category

--Them Product
INSERT INTO Product (ProductID, ProductName, CategoryID, Price,Quantity,ProductDescription)
VALUES ('01', 'Ghe Sofa', '01', 500000, 10 ,'De phong khach');

INSERT INTO Product (ProductID, ProductName, CategoryID, Price,Quantity,ProductDescription)
VALUES ('02', 'Ghe nhua', '01', 20000, 50 ,'Ngoi chao co');

INSERT INTO Product (ProductID, ProductName, CategoryID, Price,Quantity,ProductDescription)
VALUES ('03', 'Ban lam viec', '02', 100000, 5 ,'De van phong');
 
INSERT INTO Product (ProductID, ProductName, CategoryID, Price,Quantity,ProductDescription)
VALUES ('04', 'Ban an', '02', 700000, 4 ,'De an com');

INSERT INTO Product (ProductID, ProductName, CategoryID, Price,Quantity,ProductDescription)
VALUES ('05', 'Ban phong khach', '02', 1500000, 6 ,'Tiep khach...');

INSERT INTO Product (ProductID, ProductName, CategoryID, Price,Quantity,ProductDescription)
VALUES ('07', 'Iphone 14 ProMax', '03', 20000000, 13 ,'Nghe,goi,nhan tin,internet,..');

INSERT INTO Product (ProductID, ProductName, CategoryID, Price,Quantity,ProductDescription)
VALUES ('08', 'Iphone 11 ProMax', '03', 7000000, 7 ,'Nghe,goi,nhan tin,internet,..');

INSERT INTO Product (ProductID, ProductName, CategoryID, Price,Quantity,ProductDescription)
VALUES ('09', 'Samsung S23 Ultra', '03', 25000000, 3 ,'Nghe,goi,nhan tin,internet,..');

--select * from Product
--DELETE FROM Product WHERE ProductID=1 ;

--



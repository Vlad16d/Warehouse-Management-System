USE WarehouseDB;

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Quantity INT NOT NULL,
    ExpiryDate DATE NOT NULL,
    UserId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

select * from Users

select * from Products

delete Products where UserId='5'
delete Users where Id='5'

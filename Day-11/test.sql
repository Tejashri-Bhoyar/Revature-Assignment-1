USE CrmDb;


-- Drop Orders table first because it references Customers
IF OBJECT_ID('Orders', 'U') IS NOT NULL
    DROP TABLE Orders;

-- Now drop Customers
IF OBJECT_ID('Customers', 'U') IS NOT NULL
    DROP TABLE Customers;

-- Recreate Customers
CREATE TABLE Customers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Age INT NOT NULL
);

-- Recreate Orders
CREATE TABLE Orders (
    OrderId INT PRIMARY KEY,
    Product NVARCHAR(100) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(Id)
);

-- Insert sample data
INSERT INTO Customers (Id, Name, Age)
VALUES 
(1, 'John', 30),
(2, 'Alice', 25),
(3, 'Bob', 40),
(4, 'Charlie', 35);


-- Check table
SELECT * FROM Customers;



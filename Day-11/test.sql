use CrmDb;

IF OBJECT_ID('Customers', 'U') IS NOT NULL
    DROP TABLE Customers;


CREATE TABLE Customers (
    Id INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Age INT NOT NULL
);


INSERT INTO Customers (Id, Name, Age)
VALUES 
(1, 'John', 30),
(2, 'Alice', 25),
(3, 'Bob', 40),
(4, 'Charlie', 35);


SELECT * FROM Customers;






USE Sample

IF OBJECT_ID('tblProduct', 'U') IS NOT NULL
    DROP TABLE tblProduct;

CREATE TABLE tblProduct (
    ProductId INT PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Quantity INT NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE()
);


INSERT INTO tblProduct (ProductId, ProductName, Price, Quantity)
VALUES
(1, 'Laptop', 55000, 10),
(2, 'Mouse', 500, 50),
(3, 'Keyboard', 1500, 30);


SELECT * FROM tblProduct;
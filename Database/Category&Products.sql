CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(255) NOT NULL,
    CategoryDescription NVARCHAR(MAX) 
);
CREATE TABLE Suppliers (
    SupplierID INT PRIMARY KEY IDENTITY(1,1),
    SupplierName NVARCHAR(255) NOT NULL,
    ContactInfo NVARCHAR(255) NOT NULL,
	 SupplierEmail NVARCHAR(255) NOT NULL,
    SupplierAddress NVARCHAR(255) NOT NULL
);
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(255) NOT NULL,
    ProductDescription NVARCHAR(MAX),
	ProductArabicName NVARCHAR(255),
	ProductImage NVARCHAR(MAX),
    ProductPrice DECIMAL(18, 2) NOT NULL,
    CategoryID INT FOREIGN KEY REFERENCES Categories(CategoryID),
    SupplierID INT FOREIGN KEY REFERENCES Suppliers(SupplierID)
);



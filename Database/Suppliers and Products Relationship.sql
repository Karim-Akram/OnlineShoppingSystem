-- Suppliers and Products Relationship
CREATE TABLE SupplierProducts (
    SupplierProductID INT PRIMARY KEY IDENTITY(1,1),
    SupplierID INT FOREIGN KEY REFERENCES Suppliers(SupplierID),
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
   
);

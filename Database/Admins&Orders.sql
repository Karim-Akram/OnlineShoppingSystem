-- Users Table
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    UserName NVARCHAR(255) NOT NULL,
    Password NVARCHAR(255) NOT NULL, -- Hashed or encrypted
    UserType NVARCHAR(50) NOT NULL, -- 'Admin' or 'Customer'
    
);

-- Admins Table
CREATE TABLE Admins (
    AdminID INT PRIMARY KEY FOREIGN KEY REFERENCES Users(UserID),
    AdminRole NVARCHAR(50) NOT NULL, -- 'SuperAdmin', 'Moderator', etc.
   
);

-- Customers Table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY FOREIGN KEY REFERENCES Users(UserID),
    Email NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255) NOT NULL,
 
);

-- Orders Table
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    OrderDate DATETIME NOT NULL,
   
);

-- OrderItems Table (to establish the relationship between Orders and Products)
CREATE TABLE OrderItems (
    OrderItemID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
    Quantity INT NOT NULL,
  
);

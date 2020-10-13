DROP TABLE IF EXISTS Products, Categories;

CREATE TABLE Categories(
	CategoryId INT GENERATED ALWAYS AS IDENTITY,
	CategoryName VARCHAR(50) UNIQUE,
	PRIMARY KEY (CategoryId)
);

CREATE TABLE Products(
	ProductId INT GENERATED ALWAYS AS IDENTITY,
	ProductName VARCHAR(50) NOT NULL,
	Price DECIMAL(8,2) NOT NULL,
	CategoryId INT,
	PRIMARY KEY (ProductId),
	FOREIGN KEY (CategoryId)
		REFERENCES Categories(CategoryId)
);


INSERT INTO Categories (CategoryName) VALUES ('Salgados');
INSERT INTO Categories (CategoryName) VALUES ('Doces');
INSERT INTO Categories (CategoryName) VALUES ('Bebidas');

INSERT INTO Products (ProductName, Price, CategoryId)
	VALUES ('Pastel', 2.50, 1);
INSERT INTO Products (ProductName, Price, CategoryId) 
	VALUES ('Coxinha', 3.50, 1);
	
INSERT INTO Products (ProductName, Price, CategoryId) 
	VALUES ('Brigadeiro', 1.50, 2);
INSERT INTO Products (ProductName, Price, CategoryId) 
	VALUES ('Bolo de Maracujá', 5.00, 2);
	
	
INSERT INTO Products (ProductName, Price, CategoryId) 
	VALUES ('Suco de Limão', 2.00, 3);
INSERT INTO Products (ProductName, Price, CategoryId) 
	VALUES ('Coca-Cola', 5.00, 3);
CREATE TABLE [Role]
(
	RoleId INT IDENTITY(1,1) PRIMARY KEY,
	RoleName VARCHAR(32) NOT NULL
)
go
CREATE TABLE [User]
(
	UserId INT IDENTITY(1,1) PRIMARY KEY,
	RoleId INT NOT NULL FOREIGN KEY (RoleId) REFERENCES [Role](RoleId),
	Username VARCHAR(32) NOT NULL,
	[Password] VARCHAR(32) NOT NULL,
	[Name] VARCHAR(32) NOT NULL,
	Gender VARCHAR(32) NOT NULL,
	PhoneNumber VARCHAR(32) NOT NULL,
	[Address] VARCHAR(32) NOT NULL,
)
GO
CREATE TABLE Medicine
(
	MedicineId  INT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(32) NOT NULL,
	[Description] VARCHAR(32) NOT NULL,
	Stock VARCHAR(32) NOT NULL,
	Price VARCHAR(32) NOT NULL,
)
GO
CREATE TABLE Cart
(
	UserId INT,
	MedicineId  INT,
	Quantity INT NOT NULL,
	PRIMARY KEY (UserId, MedicineId),
	FOREIGN KEY (UserId) REFERENCES [User](UserId),
	FOREIGN KEY (MedicineId) REFERENCES Medicine(MedicineId),
)
GO
CREATE TABLE HeaderTransaction
(
	TransactionId INT IDENTITY(1, 1) PRIMARY KEY,
	UserId  INT,
	TransactionDate DATE NOT NULL,
	FOREIGN KEY (UserId) REFERENCES [User](UserId),
)
GO
CREATE TABLE DetailTransaction
(
	TransactionId INT,
	MedicineId  INT,
	Quantity INT NOT NULL,
	PRIMARY KEY (TransactionId, MedicineId),
	FOREIGN KEY (TransactionId) REFERENCES HeaderTransaction(TransactionId),
	FOREIGN KEY (MedicineId) REFERENCES Medicine(MedicineId),
)
INSERT INTO [Role] VALUES
('Administrator'),
('Member')
GO


SELECT * FROM [Role]

INSERT INTO [User] VALUES
(1, 'Putud', 'Putud123#', 'Putud', 'Male', '08123', 'Jakarta'),
(2, 'Budi', 'Budi123#', 'BudiMan', 'Male', '08123', 'Bekasi')

SELECT 
	UserId,
	UserName,
	[Password],
	[Name],
	PhoneNumber,
	[Address],
	RoleName
FROM [User] JOIN [Role] ON [Role].RoleId = [User].UserId

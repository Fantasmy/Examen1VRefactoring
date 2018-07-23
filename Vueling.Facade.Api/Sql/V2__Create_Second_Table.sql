USE ExamenVueling
GO    
IF OBJECT_ID(N'ExamenVueling.dbo.Policies', N'U') IS NULL
BEGIN
	-- Create table
CREATE TABLE dbo.Policies (
	id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	amountInsured decimal NOT NULL,
	email [NVARCHAR](50) NOT NULL,
	inceptionDate DateTime NOT NULL,
	installmentPayment bit NOT NULL,
	clientId UNIQUEIDENTIFIER NOT NULL,    
    FOREIGN KEY (clientId) REFERENCES Clients (id)
    ON DELETE CASCADE    
    ON UPDATE CASCADE    
);
END
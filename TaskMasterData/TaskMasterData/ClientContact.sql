CREATE TABLE [dbo].[ClientContact]
(
	[ContactID] INT IDENTITY (1, 1) NOT NULL,
	[FK_ClientID] INT NOT NULL,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[EmailAddress] VARCHAR(50) NULL,
	[ContactNumber] VARCHAR(50) NULL,
	PRIMARY KEY CLUSTERED ([ContactID] ASC), 
    CONSTRAINT [FK_ClientContact_Client] FOREIGN KEY ([FK_ClientID]) 
		REFERENCES [Client]([ClientID]) ON DELETE CASCADE

)

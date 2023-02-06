CREATE TABLE [dbo].[Client]
(
	[ClientID] INT IDENTITY (1, 1) NOT NULL,
	[CompanyName] VARCHAR(50) NOT NULL,
	[EmailAddress] VARCHAR(50) NULL,
	[ContactNumber] VARCHAR(50) NULL,
	PRIMARY KEY CLUSTERED ([ClientID] ASC)
)

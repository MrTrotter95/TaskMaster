CREATE TABLE [dbo].[Projects]
(
	[ProjectID] INT IDENTITY (1, 1) NOT NULL,
	[FK_ClientID] INT NOT NULL,
	[FK_StatusID] INT NOT NULL,
	[ProjectName] VARCHAR(50),
	[CreationDate] TIMESTAMP,
	PRIMARY KEY CLUSTERED ([ProjectID] ASC), 
    CONSTRAINT [FK_Projects_Client] FOREIGN KEY ([FK_ClientID]) 
		REFERENCES [Client]([ClientID]) ON DELETE CASCADE, 
    CONSTRAINT [FK_Projects_ProjectStatus] FOREIGN KEY ([FK_StatusID]) 
		REFERENCES [ProjectStatus]([StatusID]) ON DELETE CASCADE,


)

CREATE TABLE [dbo].[ProjectFields]
(
	[FieldID] INT IDENTITY (1, 1) NOT NULL,
	[FK_ProjectID] INT NOT NULL,
	[FieldValue] VARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED ([FieldID] ASC), 
    CONSTRAINT [FK_ProjectFields_Projects] FOREIGN KEY ([FK_ProjectID]) 
		REFERENCES [Projects]([ProjectID]) ON DELETE CASCADE,
)

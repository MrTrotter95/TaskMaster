CREATE TABLE [dbo].[ProjectFIeldsType]
(
	[FieldTypeID] INT IDENTITY (1, 1) NOT NULL,
	[FK_FieldID] INT NOT NULL,
	[FieldTypeValue] VARCHAR(50) NOT NULL
	PRIMARY KEY CLUSTERED ([FieldTypeID] ASC), 
    CONSTRAINT [FK_ProjectFIeldsType_ProjectFields] FOREIGN KEY ([FK_FieldID]) 
		REFERENCES [ProjectFields]([FieldID]) ON DELETE CASCADE, 
)

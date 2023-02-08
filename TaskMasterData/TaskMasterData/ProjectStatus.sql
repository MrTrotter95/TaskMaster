CREATE TABLE [dbo].[ProjectStatus]
(
	[StatusID] INT IDENTITY (1, 1) NOT NULL,
	[StatusValue] VARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED ([StatusID] ASC)
)

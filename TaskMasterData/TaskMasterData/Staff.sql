﻿CREATE TABLE [dbo].[Staff]
(
	[StaffID] INT IDENTITY (1, 1) NOT NULL,
	[FK_StaffRoleID] INT NOT NULL,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[ContactNumber] VARCHAR(50) NOT NULL,
	[EmailAddress] VARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED ([StaffID] ASC), 
    CONSTRAINT [FK_Staff_StaffRoles] FOREIGN KEY ([FK_StaffRoleID]) 
		REFERENCES [StaffRoles]([StaffRoleID]) ON DELETE CASCADE
)

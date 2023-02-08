CREATE TABLE [dbo].[AssignedProjects]
(
	[AssignedProjectsID] INT IDENTITY (1, 1) NOT NULL,
	[FK_StaffID] INT NOT NULL,
	[FK_ProjectID] INT NOT NULL
	PRIMARY KEY CLUSTERED ([AssignedProjectsID] ASC), 
    CONSTRAINT [FK_AssignedProjects_Staff] FOREIGN KEY ([FK_StaffID]) 
		REFERENCES [Staff]([StaffID]) ON DELETE CASCADE, 
    CONSTRAINT [FK_AssignedProjects_Projects] FOREIGN KEY ([FK_ProjectID]) 
		REFERENCES [Projects]([ProjectID]) ON DELETE CASCADE 
)

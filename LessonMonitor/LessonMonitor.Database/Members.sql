﻿CREATE TABLE [dbo].[Members]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NewSequentialID(), 
    [NickName] NVARCHAR(20) NOT NULL, 
    [FullName] NVARCHAR(100) NULL, 
    [GithubProfile] NVARCHAR(50) NULL
)

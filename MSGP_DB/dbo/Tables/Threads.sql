﻿CREATE TABLE [dbo].[Threads]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CompanyID] INT NOT NULL FOREIGN KEY REFERENCES Companies(ID),
	[ThreadName] NVARCHAR(100) NOT NULL, 
    [DateTime] DATETIME NOT NULL, 
    [CommentsAmount] TINYINT NOT NULL, 
    [IPAddress] VARCHAR(15) NULL, 
    [Author] VARCHAR(25) NOT NULL, 
    [Hyperlink] NVARCHAR(100) NOT NULL
)
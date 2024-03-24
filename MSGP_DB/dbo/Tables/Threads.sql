CREATE TABLE [dbo].[Threads]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CompanyID] INT NOT NULL FOREIGN KEY REFERENCES Companies(ID),
	[ThreadName] NVARCHAR(100) NOT NULL, 
    [DateTime] DATETIME NULL, 
    [CommentsAmount] TINYINT NOT NULL, 
    [IPAddress] VARCHAR(15) NULL, 
    [Author] NVARCHAR(25) NOT NULL, 
    [Hyperlink] NVARCHAR(100) NOT NULL
)
CREATE TABLE [dbo].[Companies]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CompanyName] NVARCHAR(30) NOT NULL, 
    [Ranking] SMALLINT NULL,
)

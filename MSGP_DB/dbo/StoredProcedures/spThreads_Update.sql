CREATE PROCEDURE [dbo].[spThreads_Update]
@ID int,
@CompanyID int,
@ThreadName nvarchar(100),
@DateTime datetime,
@CommentsAmount tinyint,
@IPAddress varchar(15),
@Author nvarchar(25),
@Hyperlink nvarchar(100)
AS

BEGIN

UPDATE Threads
SET CompanyID=@CompanyID, ThreadName=@ThreadName, DateTime=@DateTime, 
CommentsAmount=@CommentsAmount, IPAddress=@IPAddress, Author=@Author, Hyperlink=@Hyperlink
WHERE ID=@ID;

END


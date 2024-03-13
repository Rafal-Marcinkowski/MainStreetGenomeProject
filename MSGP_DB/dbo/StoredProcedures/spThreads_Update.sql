CREATE PROCEDURE [dbo].[spThreads_Update]
@ID int,
@CompanyID int,
@ThreadName nvarchar(100),
@DateTime datetime,
@CommentsAmount tinyint,
@IPAddress varchar(15),
@Author varchar(25)
AS

BEGIN

UPDATE Threads
SET CompanyID=@CompanyID, ThreadName=@ThreadName, DateTime=@DateTime, CommentsAmount=@CommentsAmount, IPAddress=@IPAddress, Author=@Author
WHERE ID=@ID;

END


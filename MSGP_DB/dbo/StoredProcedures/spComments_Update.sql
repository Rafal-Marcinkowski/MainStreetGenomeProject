CREATE PROCEDURE [dbo].[spComments_Update]
@ID int,
@ThreadID int,
@CommentText nvarchar(250),
@IPAddress varchar(15),
@DateTime datetime,
@Author nvarchar(25)
AS

BEGIN

UPDATE Comments
SET ThreadID=@ThreadID, CommentText=@CommentText, IPAddress=@IPAddress, DateTime=@DateTime, Author=@Author
WHERE ID=@ID;

END

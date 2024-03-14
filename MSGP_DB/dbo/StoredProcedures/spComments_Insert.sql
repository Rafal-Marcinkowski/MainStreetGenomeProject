CREATE PROCEDURE [dbo].[spComments_Insert]
@ThreadID int,
@CommentText nvarchar(250),
@IPAddress varchar(15),
@DateTime datetime,
@Author varchar(25)
AS

BEGIN

INSERT INTO Comments(ThreadID, CommentText, IPAddress, DateTime, Author)
VALUES(@ThreadID, @CommentText, @IPAddress, @DateTime, @Author);

END

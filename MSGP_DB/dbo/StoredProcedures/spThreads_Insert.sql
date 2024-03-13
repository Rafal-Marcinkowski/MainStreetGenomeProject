CREATE PROCEDURE [dbo].[spThreads_Insert]
@CompanyID int,
@ThreadName nvarchar(100),
@DateTime datetime,
@CommentsAmount tinyint,
@IPAddress varchar(15),
@Author varchar(25)
AS

BEGIN

INSERT INTO Threads
VALUES(@CompanyID, @ThreadName, @DateTime, @CommentsAmount, @IPAddress, @Author);

END

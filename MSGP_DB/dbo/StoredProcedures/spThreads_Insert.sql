CREATE PROCEDURE [dbo].[spThreads_Insert]
@CompanyID int,
@ThreadName nvarchar(100),
@DateTime datetime,
@CommentsAmount tinyint,
@IPAddress varchar(15),
@Author nvarchar(25),
@Hyperlink nvarchar(100)
AS

BEGIN

INSERT INTO Threads(CompanyID, ThreadName, DateTime, CommentsAmount, IPAddress, Author, Hyperlink)
VALUES(@CompanyID, @ThreadName, @DateTime, @CommentsAmount, @IPAddress, @Author, @Hyperlink);

END

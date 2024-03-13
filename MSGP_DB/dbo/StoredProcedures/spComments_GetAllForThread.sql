CREATE PROCEDURE [dbo].[spComments_GetAllForThread]
@ThreadID int
AS
BEGIN

SELECT * FROM Comments
WHERE ThreadID=@ThreadID

END

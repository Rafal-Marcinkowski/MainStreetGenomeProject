CREATE PROCEDURE [dbo].[spComments_Delete]
@ID int
AS
BEGIN

DELETE FROM Comments
WHERE ID=@ID

END

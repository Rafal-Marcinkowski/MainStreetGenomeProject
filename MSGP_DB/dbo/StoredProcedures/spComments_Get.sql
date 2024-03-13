CREATE PROCEDURE [dbo].[spComments_Get]
	@ID int
AS
BEGIN

SELECT * FROM Comments
WHERE ID=@ID;

END
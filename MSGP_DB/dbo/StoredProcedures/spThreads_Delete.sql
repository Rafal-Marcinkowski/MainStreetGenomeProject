CREATE PROCEDURE [dbo].[spThreads_Delete]
	@ID int
AS
BEGIN
    DELETE FROM Companies
	WHERE ID=@ID;
END

CREATE PROCEDURE [dbo].[spThreads_Delete]
	@ID int
AS
BEGIN
    DELETE FROM Threads
	WHERE ID=@ID;
END

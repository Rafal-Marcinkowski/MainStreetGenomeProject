CREATE PROCEDURE [dbo].[spThreads_Get]
	@ID int
AS
BEGIN
    SELECT * FROM Threads 
	WHERE ID=@ID;
END

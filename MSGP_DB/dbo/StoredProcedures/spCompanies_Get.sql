CREATE PROCEDURE [dbo].[spCompanies_Get]
	@ID int
AS
BEGIN
    SELECT * FROM Companies 
	WHERE ID=@ID;
END

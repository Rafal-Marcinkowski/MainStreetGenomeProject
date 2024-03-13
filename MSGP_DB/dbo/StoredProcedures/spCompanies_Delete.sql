CREATE PROCEDURE [dbo].[spCompanies_Delete]
	@ID int
AS
BEGIN
    DELETE FROM Companies
	WHERE ID=@ID;
END


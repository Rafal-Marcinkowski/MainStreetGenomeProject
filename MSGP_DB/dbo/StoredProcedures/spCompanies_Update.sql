CREATE PROCEDURE [dbo].[spCompanies_Update]
@ID int,
@CompanyName nvarchar(50),
@Ranking smallint
AS

BEGIN

UPDATE Companies
SET CompanyName=@CompanyName, Ranking=@Ranking
WHERE ID=@ID;

END

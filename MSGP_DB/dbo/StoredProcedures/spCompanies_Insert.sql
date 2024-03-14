CREATE PROCEDURE [dbo].[spCompanies_Insert]
@CompanyName nvarchar(50),
@Ranking smallint
AS

BEGIN

INSERT INTO Companies(CompanyName, Ranking)
VALUES(@CompanyName, @Ranking);

END


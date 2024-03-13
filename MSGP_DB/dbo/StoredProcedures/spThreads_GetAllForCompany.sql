CREATE PROCEDURE [dbo].[spThreads_GetAllForCompany]
@CompanyID int
AS
BEGIN

SELECT * FROM Threads
WHERE CompanyID=@CompanyID

END

/*-- =============================================
-- Author : Eddie
-- Create date : 2017/11/30 16:19
-- Last update : 2017/11/30 16:47
-- Description : Search Procedure FOR HSBC
-- ============================================= */
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_HSBC_Exist]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_HSBC_Exist]
GO


CREATE  PROCEDURE [dbo].[s_Get_HSBC_Exist]
    @valdate nvarchar(20),
	@cltno nvarchar(20),
	@curcy nvarchar(20),
	@amt decimal(10, 2),
	@tran_type nvarchar(20),
	@chq_date nvarchar(20)
AS
BEGIN
    Set NOCOUNT ON;
    Set XACT_ABORT ON;

    BEGIN TRAN

	  SELECT accno 
	     FROM hsbc 
	  WHERE
	     vdate = @valdate 
	     AND accno = @cltno 
	     AND ccy = @curcy 
	     AND amount = @amt 
	     AND ctype = @tran_type 
	     AND cdate = @chq_date  

    COMMIT TRANSACTION  
    
    IF(@@ERROR <> 0)  
		ROLLBACK TRANSACTION
    
END
GO



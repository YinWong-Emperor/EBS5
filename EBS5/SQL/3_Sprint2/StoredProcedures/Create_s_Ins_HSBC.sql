/*-- =============================================
-- Author : Eddie
-- Create date : 2017/11/30 16:19
-- Last update : 2017/11/30 16:47
-- Description : Search Procedure FOR HSBC
-- ============================================= */
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Ins_HSBC]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Ins_HSBC]
GO


CREATE  PROCEDURE [dbo].[s_Ins_HSBC]
    @valdate nvarchar(20),
	@cltno nvarchar(20),
	@curcy nvarchar(20),
	@amt decimal(14, 2),
	@tran_type nvarchar(20),
	@chq_date nvarchar(20),
	@description nvarchar(1000),
	@user nvarchar(20)
AS
BEGIN
    Set NOCOUNT ON;
    Set XACT_ABORT ON;

    BEGIN TRAN

		  INSERT INTO hsbc
		    (vdate, 
			 accno, 
			 ccy, 
			 amount, 
			 ctype, 
			 cdate, 
			 [description], 
			 create_user) 
		  VALUES 
		    (@valdate, 
			 @cltno, 
			 @curcy, 
			 @amt, 
			 @tran_type, 
			 @chq_date, 
			 @description, 
			 @user)

    COMMIT TRANSACTION  
    
    IF(@@ERROR <> 0)  
		ROLLBACK TRANSACTION
    
END
GO



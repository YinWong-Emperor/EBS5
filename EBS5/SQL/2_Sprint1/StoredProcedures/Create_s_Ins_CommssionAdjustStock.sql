SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Ins_CommssionAdjustStock]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Ins_CommssionAdjustStock]
GO




/*-- =============================================
-- Author : Eddie
-- Create date : 2017/11/06 16:19
-- Last update : 2017/11/06 10:47
-- Description : Add Procedure FOR CommssionAdjustStock
-- ============================================= */
CREATE PROCEDURE [dbo].[s_Ins_CommssionAdjustStock]
	@adjYear nvarchar(10),
    @adjMonth nvarchar(10),
    @clientCode nvarchar(20)
AS
BEGIN
    Set NOCOUNT ON;
    Set XACT_ABORT ON;

    BEGIN TRAN

	  INSERT INTO MonthCommAdj
	     (accno, 
		  adjDate, 
		  adj) 
	   VALUES 
	     (@clientCode, 
		  @adjYear+@adjMonth+'01', 
		  0)

    COMMIT TRANSACTION  
	SELECT 1
  
    IF(@@ERROR <> 0) 
	    BEGIN 
		ROLLBACK TRANSACTION
		SELECT 0
		END

END
GO


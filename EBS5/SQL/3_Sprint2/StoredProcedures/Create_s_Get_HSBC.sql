/*-- =============================================
-- Author : Eddie
-- Create date : 2017/11/30 16:19
-- Last update : 2017/11/30 16:47
-- Description : Search Procedure FOR HSBC
-- ============================================= */
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_HSBC]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_HSBC]
GO


CREATE PROCEDURE [dbo].[s_Get_HSBC]
    @g2bsDB nvarchar(100),
	@g2bfDB nvarchar(100)
AS
BEGIN
    Set NOCOUNT ON;
    Set XACT_ABORT ON;

    BEGIN TRAN

	  CREATE TABLE #tmpclts
	     (vdate nvarchar(10), 
		  clienttype nvarchar(10), 
		  accno nvarchar(10), 
		  ccy nvarchar(3), 
		  amount numeric(14,2), 
		  ctype nvarchar(10), 
		  cdate nvarchar(10))
	  CREATE TABLE #tmpcltf
	     (vdate nvarchar(10), 
		  clienttype nvarchar(10), 
		  accno nvarchar(10), 
		  ccy nvarchar(3), 
		  amount numeric(14,2), 
		  ctype nvarchar(10), 
		  cdate nvarchar(10))

	  
	  DECLARE @sqlStr  VARCHAR(1000)
	  SET @sqlStr = 'SELECT 
	                    accno, 
						[type] 
					 FROM ' + @g2bsDB + '.dbo.client_master clm, ' + 
					    @g2bsDB + '.dbo.client_master_s clms 
					 WHERE
					    clm.aid = clms.aid '

      INSERT INTO #tmpclts (accno, ctype) EXEC (@sqlStr)
	  
	  SET @sqlStr = 'SELECT 
	                    accno, [type] 
					 FROM ' + @g2bfDB + '.dbo.client_master clm, ' + 
					    @g2bfDB + '.dbo.client_master_f clmf 
					 WHERE
					    clm.aid = clmf.aid '

	  INSERT INTO #tmpcltf (accno, ctype) EXEC (@sqlStr)

	  SELECT accno, ctype FROM #tmpclts
	  SELECT accno, ctype FROM #tmpcltf


	  IF OBJECT_ID('DBO.#tmpclts') IS NOT NULL
		BEGIN
		   DROP TABLE #tmpclts
		END
	  IF OBJECT_ID('DBO.#tmpcltf') IS NOT NULL
		BEGIN
		   DROP TABLE #tmpcltf
		END

    COMMIT TRANSACTION  
    
    IF(@@ERROR <> 0)  
		ROLLBACK TRANSACTION
    
END
GO

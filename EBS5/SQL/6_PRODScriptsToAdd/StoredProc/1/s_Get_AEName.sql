USE [ESL]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_AEName]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_AEName]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[s_Get_AEName]
	@g2sbDB nvarchar(100),
    @aeCode nvarchar(20)
AS
BEGIN
    Set NOCOUNT ON;
    Set XACT_ABORT ON;

	  --DECLARE @sqlStr nvarchar(1000)
	  --SET @sqlStr = 'SELECT name 
	  --               FROM ' +@g2sbDB+ '.dbo.ae_master  
			--		 WHERE aeno=''' + @aeCode + '''' 
	  
	  --EXEC (@sqlStr)

	  SELECT	name = CASE ISNULL(ae_name,'') WHEN '' THEN ISNULL(ae_name_s,'') ELSE ae_name END
	  FROM		[dbo].[draft_comm_ae_master]
	  WHERE		ae_no = @aeCode

END

GO



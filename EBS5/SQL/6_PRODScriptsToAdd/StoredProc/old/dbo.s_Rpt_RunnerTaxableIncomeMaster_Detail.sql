USE [ESL]
GO
DROP PROCEDURE [dbo].[s_Rpt_RunnerTaxableIncomeMaster_Detail]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*-- =============================================
-- Author : DoraemonYu
-- Create date : 2017/02/06 19:40
-- Last update : 2017/02/06 19:40
-- ============================================= */
Create PROCEDURE [dbo].[s_Rpt_RunnerTaxableIncomeMaster_Detail]
	@ReportType as tinyint	= 1,					-- Report Type				1=Taxable Income  2=Withheld Remuneration
	@RecordOption as tinyint	=1,					-- Record Option			1=All	2=Range
	@RangeFrom as varchar(5)	= '',
	@RangeTo as varchar(5)		= '',
	@Member as varchar(1)		= ''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	
	-- get db name
	DECLARE @database_name nvarchar(100)
	SELECT @database_name = [CIfChrDataBase] FROM [DB_Information] WHERE [CIfChrServerType] = 'GL'

	-- exec	
	DECLARE @sqlStr  NVARCHAR(4000)
	SET @sqlStr = N'
WITH FULL_descr as (
	SELECT	 [TYPE_ID]
			,[COMPANY]
			 ,CASE WHEN len(replace([COMPANY],'' '','''')) > 0 THEN (replace([DESCPT],'' '','''') + [TMPDASH] + [COMPANY])  else [DESCPT] END as [DESCPT]
	FROM ' + @database_name + N'.[dbo].[GLRUNTAXDESC]
)

SELECT			(details.[RUN_CODE] + details.[RUN_MEMBER]) as GroupID,
				details.[RUN_CODE], 
				details.[RUN_MEMBER], 
                details.[TXN_MONTH], 
				details.[TXN_YEAR], 
				details.[ITEM], 
				details.[AMOUNT], 
                details.[DESCPT] as Description, 
				details.[TAXTYPE], 
				details.[TYPE_ID],
				descr.[DESCPT], 
                descr.[COMPANY]
FROM			' + @database_name + N'.[dbo].[GLRUNTAXDETAILS] as details LEFT OUTER JOIN FULL_descr as descr
			ON	details.[TYPE_ID] = descr.[TYPE_ID]
WHERE			
'

			--筛选部分
			--## Report Type
			IF @ReportType = 1		--Taxable Income
				SET @sqlStr = @sqlStr + N'( details.[Type_ID] < 100 AND details.[Type_ID] != 16 AND details.[Type_ID] !=17 ) '
			ELSE					--Withheld Remuneration
				SET @sqlStr = @sqlStr + N'( details.[Type_ID] > 100 OR details.[Type_ID] = 16 OR details.[Type_ID] = 17 ) '

			--## Record Option
			IF @RecordOption = 2
				BEGIN

				SET @sqlStr = @sqlStr + N' AND	 details.[RUN_MEMBER] = ''' + @Member + N''' AND 
												 details.[RUN_CODE] >= ''' + @RangeFrom + N''' AND
												 details.[RUN_CODE] <= ''' + @RangeTo + N'''
										 '

				END
			

			--排序部分
			SET @sqlStr = @sqlStr + N' ORDER BY		details.[RUN_CODE], details.[TAXTYPE], details.[TYPE_ID] '

	PRINT @sqlStr
	EXEC sp_executesql @sqlStr

END

GO



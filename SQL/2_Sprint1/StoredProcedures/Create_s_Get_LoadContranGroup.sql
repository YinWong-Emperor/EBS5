
/****** Object:  StoredProcedure [dbo].[s_Get_LoadContranGroup]    Script Date: 2017/10/26 10:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*-- =============================================
-- Author : HugoLaw
-- Create date : 2017/10/26 16:19
-- Last update : 2017/10/26 10:47
-- Description : Search Procedure FOR CRCDebitBalance
-- ============================================= */

IF OBJECT_ID('[dbo].[s_Get_LoadContranGroup]') > 0
BEGIN
	DROP PROCEDURE [dbo].[s_Get_LoadContranGroup]
END
GO

CREATE PROCEDURE [dbo].[s_Get_LoadContranGroup]
AS
BEGIN
	SELECT DISTINCT list_name FROM contran order by list_name
END
GO

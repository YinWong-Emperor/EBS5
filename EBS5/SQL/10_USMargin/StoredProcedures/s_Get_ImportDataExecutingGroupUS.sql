USE [ESL]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[s_Get_ImportDataExecutingGroupUS]
AS
BEGIN	
	
	SELECT TOP 1
		[group]
	FROM import_data_history_US WITH (NOLOCK)
	ORDER BY id DESC
END

GO
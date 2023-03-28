USE [ESL]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[s_Get_ImportDataProgressUS]
	@group varchar(100),
	@stepId int
AS
BEGIN	
	SELECT
		doneTB.DoneCount,
		id,
		[group],
		current_step,
		totle_step,
		message,
		create_user,
		create_date
	FROM (
		SELECT COUNT(1) DoneCount
		FROM import_data_history_US WITH (NOLOCK)
		WHERE [group] = @group
	) doneTB	-- 为了处理事务取消的情况，每次查一个已经完成的数量，如果完成数量减少，证明操作取消
	LEFT JOIN 
	(
		SELECT 
			id,
			[group],
			current_step,
			totle_step,
			message,
			create_user,
			create_date
		FROM 
		import_data_history_US WITH (NOLOCK) 
		WHERE 
			id > @stepId
			AND [group] = @group
	) AS dh 
	ON 1=1
	ORDER BY id
END

GO
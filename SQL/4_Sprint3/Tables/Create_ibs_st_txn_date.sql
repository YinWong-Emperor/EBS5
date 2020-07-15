IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ibs_st_txn_date]') AND type in (N'U'))
    DROP TABLE [dbo].[ibs_st_txn_date]
GO

CREATE TABLE [dbo].[ibs_st_txn_date](
	t2_date datetime not null
)

GO

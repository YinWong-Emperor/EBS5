IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ibs_cac_cup]') AND type in (N'U'))
    DROP TABLE [dbo].[ibs_cac_cup]
GO

CREATE TABLE [dbo].[ibs_cac_cup](
	clt_code VARCHAR(20) NOT NULL,
	amt NUMERIC(16,4) NOT NULL,
	amt_type VARCHAR(20) NOT NULL
)

GO

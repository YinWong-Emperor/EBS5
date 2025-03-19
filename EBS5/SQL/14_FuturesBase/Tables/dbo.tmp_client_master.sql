USE [ESL]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tmp_client_master](
	[accno] [char](20) NOT NULL,
	[nature_s] [varchar](11) NOT NULL,
	[gender_s] [varchar](6) NOT NULL,
	[name_1] [nvarchar](60) NULL,
	[name_1_c] [nvarchar](60) NULL,
	[aeno] [char](20) NULL,
	[br_id] [char](40) NULL,
	[phone_1] [char](20) NULL,
	[phone_2] [char](20) NULL,
	[phone_3] [char](100) NULL,
	[fax] [char](20) NULL,
	[email] [char](50) NULL,
	[addr_1] [nvarchar](40) NULL,
	[addr_2] [nvarchar](40) NULL,
	[addr_3] [nvarchar](40) NULL,
	[addr_4] [nvarchar](40) NULL,
	[bank_code_1] [char](40) NULL,
	[date_open] [datetime] NULL,
	[credit_lmt] [money] NULL,
	[pstat] [char](1) NULL,
	[suspend_field] [varchar](3) NOT NULL,
	[suspend_code] [varchar](40) NULL,
	[date_close] [datetime] NULL,
	[mail_status] [varchar](13) NOT NULL,
	[category] [char](20) NOT NULL,
	[relationship] [char](100) NOT NULL,
	[relationstaff] [varchar](100) NOT NULL,
	[relationae] [char](20) NOT NULL,
	[int_code] [char](10) NULL,
	[nd_addr_1] [nvarchar](40) NOT NULL,
	[nd_addr_2] [nvarchar](40) NOT NULL,
	[nd_addr_3] [nvarchar](40) NOT NULL,
	[nd_addr_4] [nvarchar](40) NOT NULL,
	[Last_Tran_Date] [datetime] NULL,
	[ae_name] [char](40) NOT NULL,
	[ae_email] [char](40) NULL,
	[branch_name] [varchar](60) NOT NULL,
	[client_type] [varchar](10) NOT NULL,
	[aid] [char](10) NULL,
	[notes] [char](255) NOT NULL
) ON [PRIMARY]

GO



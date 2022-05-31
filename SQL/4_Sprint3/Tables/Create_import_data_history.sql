IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[import_data_history]') AND type in (N'U'))
    DROP TABLE [dbo].[import_data_history]
GO

CREATE TABLE [dbo].[import_data_history](
	[id] int IDENTITY(1,1) NOT NULL,
	[group] varchar(100) not null,
	current_step int not null,
	totle_step int not null,
	message varchar(4000) not null,
	effect_count int not null default(0),
	error varchar(max) not null default(''),
	create_user varchar(30) not null,
	create_date datetime not null,
	PRIMARY KEY CLUSTERED 
	(
		[id] ASC
	)
) ON [PRIMARY]

GO

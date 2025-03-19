IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[uq_exchangerate]') AND TYPE IN (N'UQ'))
	ALTER TABLE [exchangerate] DROP CONSTRAINT uq_exchangerate
GO

/*-- =============================================
-- Author : DavidYang
-- Create date : 2017/10/19 16:19
-- Last update : 2017/10/20 10:47
-- Description : Update Procedure FOR ChequePrinting
-- ============================================= */
ALTER TABLE [exchangerate]
ADD CONSTRAINT  uq_exchangerate UNIQUE(system_type,currency_in,currency_out,tdate)

GO

/*
-- step 1) Check the duplicate data using script:
select * 
from [exchangerate] x
where exists(
	select 1 from (
		select * from (
			select system_type, currency_in, currency_out, tdate, count(1) num 
			from [exchangerate] 
			group by system_type, currency_in, currency_out, tdate
		) a 
		where a.num > 1
	) b 
	where b.system_type = x.system_type
		and b.currency_in = x.currency_in
		and ((b.currency_out is null and x.currency_out is null) or b.currency_out = x.currency_out)
		and b.tdate = x.tdate
)  
order by lupdtdate -- tdate, currency_in, currency_out

--step 2) Confirm each duplicate record with users(you can use "lupdtdate": xxxx-xx-xx or "exid" to list each duplicate record), which data is incorrect :

select * 
from [exchangerate] x
where exists(
	select 1 from (
		select * from (
			select system_type, currency_in, currency_out, tdate, count(1) num 
			from [exchangerate] 
			group by system_type, currency_in, currency_out, tdate
		) a 
		where a.num > 1
	) b 
	where b.system_type = x.system_type
		and b.currency_in = x.currency_in
		and ((b.currency_out is null and x.currency_out is null) or b.currency_out = x.currency_out)
		and b.tdate = x.tdate
) and lupdtdate = 'xxxx-xx-xx xx:xx:xx.xxx'

--step 3) Delete the confirmed data with script using "lupdtdate" or "exid"( xxxx-xx-xx is the confirmed date to do delete script):

delete 
from [exchangerate]
where exists(
	select 1 from (
		select * from (
			select system_type, currency_in, currency_out, tdate, count(1) num 
			from [exchangerate] 
			group by system_type, currency_in, currency_out, tdate
		) a 
		where a.num > 1
	) b 
	where b.system_type = [exchangerate].system_type
		and b.currency_in = [exchangerate].currency_in
		and ((b.currency_out is null and [exchangerate].currency_out is null) or b.currency_out = [exchangerate].currency_out)
		and b.tdate = [exchangerate].tdate
) and lupdtdate = 'xxxx-xx-xx xx:xx:xx.xxx'

--step 4) Execute the "alter" script to add unique key:
ALTER TABLE [exchangerate]
ADD CONSTRAINT  uq_exchangerate UNIQUE(system_type,currency_in,currency_out,tdate)

GO
*/
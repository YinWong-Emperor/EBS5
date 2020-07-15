use ESL 
GO

BEGIN TRAN
		
--UAT F:\DB\Data\appBackup\
--PREPROD F:\DB_Backup\appBackup\'

UPDATE a
SET a.misc_desc = 'F:\DB_Backup\appBackup\'  
FROM [misc_master] a
WHERE [misc_type] = 'RunnerTaxable' AND [misc_code] = 'backuppath'		

UPDATE a
SET a.misc_desc = 'F:\DB_Backup\appBackup\'  
FROM [misc_master] a
WHERE [misc_type] = 'ImportData' AND [misc_code] = 'backuppath'

COMMIT



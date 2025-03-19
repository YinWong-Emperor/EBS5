  --select [ReportSchID],[ReportSchName],[Title],[TemplateName],[EmailSubject],[EmailTemplate],[EmailSender],[EmailList],[PreviousTradeDate],[CurrentTradeDate],[NextTradeDate], [ReportSchType], [ReportType], [DBType] from dbo.ReportSchedule order by [CurrentTradeDate], [ReportSchID], [ReportSchName] asc

  BEGIN TRAN
  UPDATE ESL.dbo.ReportSchedule 
  SET EmailSubject = '[EBS5] ' + EmailSubject
  --ROLLBACK
  COMMIT

Imports System.Data.SqlClient

Public Class FrmImportLiqData

    Dim cls As New ClsImportLiqData
    Dim ebsDate As Date = Nothing
    Dim g2bDate As Date = Nothing

    Private Sub runFnc(ByVal fncName As String)

        Me.ListBox1.Items.Add(fncName)
        GSubWriteEventLog(fncName, "C:\")
        Me.ListBox1.SelectedIndex() = Me.ListBox1.Items.Count - 1
        Application.DoEvents()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim MyTrans As SqlTransaction = Nothing
        Dim totalproc As Integer = 35
        Dim dsLTD As DataSet
        Dim lrunningfnc As String = ""

        Try
            ' initialize progress bar 
            Me.ProgressBar1.Value = 0
            'Set start import time
            runFnc("Start to import")
            cls.lFncCreateImportMark("C:\")

            'backup before import data
            runFnc("Backup current database")
            GFncBackup(GStrBPath)
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc

            'import data table from G2BS and G2BF retrieval database and store to local temp. table. Linked server table cannot insert to local table 
            'directly within transaction because of the restriction of SQL 2000 server + Server 2003
            runFnc("Importing Last Trade Date")
            cls.lFncImportLastTradeDate()
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Importing Client Balance")
            Call cls.lFncImportTestBal()
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Importing Client Transaction")
            Call cls.lFncImportStStkTxnLst()
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Importing Client Trade Amount")
            Call cls.lFncImportTestTrade()
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Importing Client Portfolio")
            Call cls.lFncImportTestPort()
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Importing Client Status")
            Call cls.lFncImportTestStatus()
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Importing Suspend Stock")
            Call cls.lFncImportSuspendStock()
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Importing Fund Movement")
            Call cls.lFncImportFundMovement()
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Importing Client Portfolio Detail")
            Call cls.lFncImportStCltPortfolio()
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Importing Client Commission And Interest")
            Call cls.lFncImportSCommissionAndInterest()
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Importing Store Balance")
            Call cls.lFncImportStoreBalance()
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Importing Stock Concentration")
            Call cls.lFncImportStockConcentration()
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Importing AE Master")
            Call cls.lFncImportAEMaster()
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Importing Client Last Trade Date")
            Call cls.lFncImportCltLastTradeDate()
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc

            runFnc("Importing Exchange Rate")
            Call cls.lFncImportExchangeRate()
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc

            'Start a local transaction
            MyTrans = GSCnLiqConn.BeginTransaction

            'update local table with temp. table
            runFnc("Updating Last Trade Date")
            cls.lFncUpdateIBSStTxnDate(MyTrans)
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Updating Originally Client Balance")
            cls.lFncUpdateTestbal(MyTrans)
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Updating Client Status")
            cls.lFncUpdateTestStatus(MyTrans)
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Updating Suspend Stock")
            cls.lFncUpdateSuspendStock(MyTrans)
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Updating Client Commission And Interest")
            cls.lFncUpdateSCommissionAndInterest(MyTrans)
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Updating Client Portfolio")
            cls.lFncUpdateStCltPortfolio(MyTrans)
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Updating Store Balance")
            'cls.lFncUpdateStoreBalance(MyTrans)
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Updating Stock Concentration")
            'cls.lFncUpdateStockConcentration(MyTrans)
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Updating T2 Trade Date")
            cls.lFncUpdateStSysTxnDate(MyTrans)
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Updating Client Master")
            cls.lFncUpdateStCltMast(MyTrans)
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Updating Client Balance Margin Call")
            cls.lFncUpdateStCltBalMargCall(MyTrans)
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            'New function for new liquidation list
            runFnc("Updating New Client Liquidation List")
            cls.lFncUpdateNewStCltLiqList(MyTrans)
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Updating Liquidation Client")
            cls.lFncUpdateStCltLiqList(MyTrans)
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Updating Client Liquidation List")
            cls.lFncUpdateStCltMastLiq(MyTrans)
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Updating Client Liquidation List Feedback")
            cls.lFncUpdateStCltMastLiqFb(MyTrans)
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Updating AE Master")
            cls.lFncUpdateAEMaster(MyTrans)
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc
            runFnc("Updating Client Turnover and Last Trade Date")
            cls.lFncUpdateCltTurnover(MyTrans, ebsDate, g2bDate)
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc

            runFnc("Cleanup temp tables")
            cls.lFncFinish(MyTrans)
            Me.ProgressBar1.Value = ProgressBar1.Value + ProgressBar1.Maximum / totalproc

            MyTrans.Commit()
            MyTrans = Nothing

            'change current trade date
            dsLTD = cls.lFncGetEBS3LastTradeDate()
            If dsLTD.Tables(0).Rows.Count > 0 Then
                If (dsLTD.Tables(0).Rows(0).Item("procflag") = True) Then
                    Me.lbllaststatus1.Text = "Current Trade Date  : " & dsLTD.Tables(0).Rows(0).Item("tradedate")
                    Me.btnSave.Enabled = True
                Else
                    Me.lbllaststatus1.Text = "Current Trade Date  : " & dsLTD.Tables(0).Rows(0).Item("tradedate") & " X "
                    Me.btnSave.Enabled = False
                End If
            Else
                GSubWriteErrLog("EBS3 Last Trade Date not found")
            End If

            cls.lFncDeleteImportMark("C:\")
            runFnc("Import Completed")
            Me.ProgressBar1.Value = ProgressBar1.Maximum
            Me.btnSave.Enabled = False

        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try


    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub FrmImportLiqData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dsLTD As DataSet
        'Dim ebsDate As Date

        'change current trade date
        dsLTD = cls.lFncGetEBS3LastTradeDate()
        If dsLTD.Tables(0).Rows.Count > 0 Then
            ebsDate = dsLTD.Tables(0).Rows(0).Item("tradedate")
            GDteTradeDate = ebsDate
            If (dsLTD.Tables(0).Rows(0).Item("procflag") = True) Then
                Me.lbllaststatus1.Text = "Current Trade Date  : " & Format(ebsDate, "yyyy/MM/dd")
                Me.btnSave.Enabled = True
            Else
                Me.lbllaststatus1.Text = "Current Trade Date  : " & Format(ebsDate, "yyyy/MM/dd") & " X "
                Me.btnSave.Enabled = False
            End If
        Else
            GSubWriteErrLog("Cannot get EBS3 Last Trade Date")
        End If

        'check whether the local database last trade date is later than G2B last trade date
        dsLTD = cls.lFncGetG2BLastTradeDate()
        If dsLTD.Tables(0).Rows.Count > 0 Then
            g2bDate = dsLTD.Tables(0).Rows(0).Item("trade_date")
            Me.lbllaststatus2.Text = "Next Trade Date     : " & Format(g2bDate, "yyyy/MM/dd")
            If dsLTD.Tables(0).Rows(0).Item("trade_date") <= ebsDate Then
                Me.btnSave.Enabled = False
            End If
        Else
            GSubWriteErrLog("Cannot get G2B Last Trade Date")
        End If

    End Sub

End Class

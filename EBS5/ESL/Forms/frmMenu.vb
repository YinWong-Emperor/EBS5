Imports System.Windows.Forms
Imports System.Reflection

Public Class frmMenu

    Dim strSCMenu(7) As String
    Dim ClsLogin As New clsLogin
    Dim ClsUM As New ClsUserMnt

    Private Sub ShowNewForm(ByVal ChildForm As System.Windows.Forms.Form)
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        'Set Manual Mode
        ChildForm.StartPosition = FormStartPosition.Manual

        'Suspend
        Me.SuspendLayout()

        Try
            'show firstly
            ChildForm.Show()

            'Then,Set Location & Active form
            Dim size As System.Drawing.Size = Screen.FromControl(Me).WorkingArea.Size
            ChildForm.Location = New Point((size.Width - ChildForm.Width) / 2, (size.Height - ChildForm.Height) / 2)
            ChildForm.Activate()
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
        End Try

        'Resume
        Me.ResumeLayout()

    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private Sub frmMenu_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Not GSCnMaster Is Nothing Then
            If GSCnMaster.State = ConnectionState.Open Then
                GSCnMaster.Close()
                GSCnMaster.Dispose()
            End If
        End If

        If Not GSCnSqlConn Is Nothing Then
            If GSCnSqlConn.State = ConnectionState.Open Then
                GSCnSqlConn.Close()
                GSCnSqlConn.Dispose()
            End If
        End If

        If Not GSCnPriceConn Is Nothing Then
            If GSCnPriceConn.State = ConnectionState.Open Then
                GSCnPriceConn.Close()
                GSCnPriceConn.Dispose()
            End If
        End If

        Global.System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub UserMaintenanceToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UserMaintenanceToolStripMenuItem.Click

        ShowNewForm(FrmUserMain)

    End Sub

    Private Sub ExitToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem2.Click
        Global.System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub UserChangePasswordToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UserChangePasswordToolStripMenuItem.Click

        ShowNewForm(FrmChgPwd)

    End Sub

    Private Sub frmMenu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.MdiChildren.Length > 0 Then
            e.Cancel = True
        Else
            If GSubShowYNConfirm("Confirm Exit?", MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub frmMenu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                System.Windows.Forms.Application.Exit()
        End Select
    End Sub

    Private Sub frmMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strShortCut As String = ""
        Dim strUAT As String = ""

        g_rbranch = g_branch_name
        TimChecking.Enabled = True
        ClsUM.SetMenuRight(Me.MenuStrip1)
        Me.KeyPreview = True
        'Me.Text = "ESL (" & g_branch_name & ")" & Space(5) & "Ver (" & System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString & ")" & Space(5) & _
        '            "Trade Date:" & Format(g_tdate, "dd/MM/yyyy") & "  [" & g_day_night & "]"

        If GIsUAT Then strUAT = " - UAT"

        'Me.Text = "ESL (" & g_branch_name & ")" & Space(5) & "Ver (" & Assembly.GetExecutingAssembly.GetName.Version.ToString & strUAT & ")"
        Me.Text = "EBS5 (" & g_branch_name & ")" & Space(5) & "Ver (" & Assembly.GetExecutingAssembly.GetName.Version.ToString & strUAT & ")"

        lsubGenSCMenu()
        For i As Integer = 1 To strSCMenu.GetUpperBound(0)
            If ClsUM.GetRights(GStrloginID, strSCMenu(i)) = True Then
                Select Case i
                    Case 1
                        strShortCut &= "(F1)-Trading Order" & Space(5)
                    Case 2
                        strShortCut &= "(F2)-Position" & Space(5)
                    Case 3
                        strShortCut &= "(F3)-Margin" & Space(5)
                    Case 4
                        strShortCut &= "(F4)-Currency" & Space(5)
                    Case 5
                        strShortCut &= "(F5)-Dayend" & Space(5)
                    Case 6
                        strShortCut &= "(F6)-Closing Price" & Space(5)
                    Case 7
                        strShortCut &= "(F7)-Gross Position" & Space(5)
                End Select
            End If
        Next

        ToolStripStatusLabel.Text = strShortCut
        lblUAT.Visible = GIsUAT
    End Sub

    Private Sub lsubGenSCMenu()
        strSCMenu(1) = "TradingOrderToolStripMenuItem"
        strSCMenu(2) = "PositionToolStripMenuItem"
        strSCMenu(3) = "MarginToolStripMenuItem"
        strSCMenu(4) = "USBaseToolStripMenuItem"
        strSCMenu(5) = "DayendToolStripMenuItem"
        strSCMenu(6) = "ToolStripMenuItem3"
        strSCMenu(7) = "GeneralPositionToolStripMenuItem"
    End Sub

    'Private Sub setToolBar()
    '    Dim lstrSQL As String = ""
    '    Dim dtsMenu As DataSet

    '    lsubGenSCMenu()
    '    lstrSQL = "Select * from Menu_Access Where MnAUserID = '" & GStrloginID & "' "
    '    dtsMenu = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '    If dtsMenu.Tables(0).Rows.Count > 0 Then
    '        With dtsMenu.Tables(0)
    '            For i As Integer = 1 To strSCMenu.Length - 1
    '                If .Select("MnAMenuCode = '" & strSCMenu(i) & "'").Length > 0 Then
    '                    toolbarMenu.Items("ToolStripButton" & CStr(i)).Enabled = True
    '                Else
    '                    toolbarMenu.Items("ToolStripButton" & CStr(i)).Enabled = False
    '                End If
    '            Next
    '        End With
    '    End If

    'End Sub



    Private Sub DayendToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        showDayend()
    End Sub

    Private Sub showDayend()
        ShowNewForm(FrmDayEnd)
    End Sub

    Private Sub TimChecking_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimChecking.Tick

        'If GFncGetTDate() <> g_tdate Then
        '    TimChecking.Enabled = False
        '    modCommon.GSubShowWarn(modCommon.GFncGetSysMsg(34))
        '    End
        'Else
        '    'Dim DtrDayEnd As SqlDataReader
        '    Dim DtsDayEnd As New DataSet
        '    DtsDayEnd = GFncRtnDS(GSCnSqlConn, "Select * from [Date]")
        '    'DtrDayEnd.Read()
        '    If DtsDayEnd.Tables(0).Rows(0).Item("D_DAY_NIG") <> "D" And DtsDayEnd.Tables(0).Rows(0).Item("D_DAY_NIG") <> "N" Then
        '        TimChecking.Enabled = False
        '        modCommon.GSubShowWarn(modCommon.GFncGetSysMsg(20))
        '        End
        '    End If
        'End If

    End Sub

    Private Sub DatabaseBackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatabaseBackupToolStripMenuItem.Click

        ShowNewForm(FrmDataBackup)

    End Sub

    Private Sub DatabaseRestoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatabaseRestoreToolStripMenuItem.Click

        ShowNewForm(FrmDataRestore)

    End Sub

    Private Sub TitleVerticalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TitleVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        showDayend()
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub AccessControlToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccessControlToolStripMenuItem.Click
        ShowNewForm(FrmMenuAccess)
    End Sub

    Private Sub AccountListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountListingToolStripMenuItem.Click
        ShowNewForm(FrmRptAccLst)
    End Sub

    Private Sub LiquToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquToolStripMenuItem.Click
        ShowNewForm(FrmLiqMst)
    End Sub

    Private Sub LiquidaionFeedBackListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquidaionFeedBackListingToolStripMenuItem.Click
        ShowNewForm(FrmLiqFBMst)
    End Sub

    Private Sub ImportDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportDataToolStripMenuItem.Click
        ShowNewForm(FrmImportLiqData)
    End Sub

    Private Sub TradingHistToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TradingHistToolStripMenuItem.Click
        ShowNewForm(FrmTradeHist)
    End Sub

    Private Sub ClienToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClienToolStripMenuItem.Click
        ShowNewForm(FrmAccStat)
    End Sub

    Private Sub ClientsOfMostCommissionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientsOfMostCommissionToolStripMenuItem.Click
        ShowNewForm(FrmTopComm)
    End Sub

    Private Sub AccountByCommRateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountByCommRateToolStripMenuItem.Click
        ShowNewForm(FrmAccCommRate)
    End Sub

    Private Sub AccountByInterestClassToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountByInterestClassToolStripMenuItem.Click
        ShowNewForm(FrmAccIntCls)
    End Sub

    Private Sub DailyNetTradeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DailyNetTradeToolStripMenuItem.Click
        ShowNewForm(FrmDailyNetTrade)
    End Sub

    Private Sub ExportStockConcentrationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportStockConcentrationToolStripMenuItem.Click
        ShowNewForm(FrmExptStockCon)
    End Sub

    Private Sub InputClientProfileDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputClientProfileDataToolStripMenuItem.Click
        ShowNewForm(FrmClientProfile)
    End Sub

    Private Sub InputToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputToolStripMenuItem.Click
        ShowNewForm(FrmCorporateProfile)
    End Sub

    Private Sub ClientProfileReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientProfileReportToolStripMenuItem.Click
        ShowNewForm(FrmClientProfileRpt)
    End Sub

    Private Sub MonthToDateReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthToDateReportToolStripMenuItem.Click
        ShowNewForm(FrmMonthToDate)
    End Sub

    Private Sub ExportClientListStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportClientListStockToolStripMenuItem.Click

        Dim cls As New ClsExportClient

        If cls.lFncExportClientStock() Then
            GSubShowInfo(GFncGetSysMsg(28))
        End If

    End Sub

    Private Sub ExportClientListFuturesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportClientListFuturesToolStripMenuItem.Click

        Dim cls As New ClsExportClient

        If cls.lFncExportClientFutures() Then
            GSubShowInfo(GFncGetSysMsg(28))
        End If

    End Sub
    Private Sub ExportClientListForSanctionStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportClientListForSanctionStockToolStripMenuItem.Click
        Dim cls As New ClsExportClient

        If cls.lFncExportClientStockSanction() Then
            GSubShowInfo(GFncGetSysMsg(28))
        End If
    End Sub

    Private Sub ExportClientListForSanctionFuturesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportClientListForSanctionFuturesToolStripMenuItem.Click
        Dim cls As New ClsExportClient

        If cls.lFncExportClientFuturesSanction() Then
            GSubShowInfo(GFncGetSysMsg(28))
        End If
    End Sub
    Private Sub ExportCreditLimitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportCreditLimitToolStripMenuItem.Click

        Dim cls As New ClsExportClient

        If cls.lFncExportCreditLimitStock() Then
            GSubShowInfo(GFncGetSysMsg(28))
        End If

    End Sub

    Private Sub SuspendStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuspendStockToolStripMenuItem.Click
        ShowNewForm(FrmSuspendStock)
    End Sub

    Private Sub SuspendStockClientToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuspendStockClientToolStripMenuItem.Click
        ShowNewForm(FrmSuspendStockClient)
    End Sub

    Private Sub CalculateCheckDigitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculateCheckDigitToolStripMenuItem.Click
        ShowNewForm(FrmCalCheckDigit)
    End Sub

    Private Sub DormantAccountListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DormantAccountListToolStripMenuItem.Click
        ShowNewForm(FrmDormantAcc)
    End Sub

    Private Sub DailyIPOAdjustmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DailyIPOAdjustmentToolStripMenuItem.Click
        ShowNewForm(FrmDailyIPOAdj)
    End Sub

    Private Sub MonthlyCommAdjustmentStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyCommAdjustmentStockToolStripMenuItem.Click
        ShowNewForm(FrmCommAdjS)
    End Sub

    Private Sub CommissionAdjustmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommissionAdjustmentToolStripMenuItem.Click
        ShowNewForm(FrmCommAdjF)
    End Sub

    Private Sub InterestAdjustmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InterestAdjustmentToolStripMenuItem.Click
        ShowNewForm(FrmIntAdjS)
    End Sub

    Private Sub ExportClientBalanceListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportClientBalanceListToolStripMenuItem.Click
        ShowNewForm(FrmExptClientBal)
    End Sub

    Private Sub ClientBalanceSummaryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientBalanceSummaryReportToolStripMenuItem.Click
        ShowNewForm(FrmCltBalSum)
    End Sub

    Private Sub ActiveAccountReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActiveAccountReportToolStripMenuItem.Click
        ShowNewForm(FrmActiveAccount)
    End Sub

    Private Sub PasswordNotificationFuturesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasswordNotificationFuturesToolStripMenuItem.Click
        ShowNewForm(FrmPwdNotifyF)
    End Sub

    Private Sub ExortClientMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExortClientMasterToolStripMenuItem.Click
        ShowNewForm(FrmClientMaster)
    End Sub

    Private Sub ExportClientMasterCustomToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExportClientMasterCustomToolStripMenuItem.Click
        ShowNewForm(FrmClientMasterCustom)
    End Sub

    Private Sub InternetTradeReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InternetTradeReportToolStripMenuItem.Click
        ShowNewForm(FrmITrade)
    End Sub

    Private Sub CRCConnTranReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRCConnTranReportToolStripMenuItem.Click
        ShowNewForm(FrmCRCConnTran)
    End Sub

    Private Sub MarginCallReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarginCallReportToolStripMenuItem.Click
        ShowNewForm(FrmRptMarginCall)
    End Sub

    Private Sub ExportStockMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportStockMasterToolStripMenuItem.Click
        ShowNewForm(FrmExportStockMaster)
    End Sub
    Private Sub AccountMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountMasterToolStripMenuItem.Click
        ShowNewForm(FrmFatcaAccMaster)
    End Sub

    Private Sub MarginClientStockHoldingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarginClientStockHoldingsToolStripMenuItem.Click
        ShowNewForm(FrmStockHolding)
    End Sub

    Private Sub LoadNewEdgeFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadNewEdgeFileToolStripMenuItem.Click
        ShowNewForm(FrmLoadNewedge)
    End Sub

    Private Sub NewedgeImportedStatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewedgeImportedStatusToolStripMenuItem.Click
        ShowNewForm(FrmNewedgeLoadStatus)
    End Sub

    Private Sub NewedgeCommodityMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewedgeCommodityMToolStripMenuItem.Click
        ShowNewForm(FrmNewedgeCommodMain)
    End Sub

    Private Sub NewedgeTradeMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewedgeTradeMasterToolStripMenuItem.Click
        ShowNewForm(FrmNewedgeTradeMain)
    End Sub

    Private Sub NewedgeDiffReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewedgeDiffReportToolStripMenuItem.Click
        ShowNewForm(FrmNewedgeDiffRpt)
    End Sub

    Private Sub FuturesOpenPositionAlertMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FuturesOpenPositionAlertMasterToolStripMenuItem.Click
        ShowNewForm(FrmFuturesOPAlertMaster)
    End Sub

    Private Sub SendPasswordEmailSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendPasswordEmailSToolStripMenuItem.Click
        ShowNewForm(FrmPwdNotifyS)
    End Sub

    Private Sub LogReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogReportToolStripMenuItem.Click
        ShowNewForm(FrmRptLog)
    End Sub

    Private Sub AutoReportMaintainenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoReportMaintainenceToolStripMenuItem.Click
        ShowNewForm(FrmAutoMailMain)
    End Sub

    Private Sub ACSecuritiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACSecuritiesToolStripMenuItem.Click
        ShowNewForm(FrmCommRateTblSACC)
    End Sub

    Private Sub AESecuritiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AESecuritiesToolStripMenuItem.Click
        ShowNewForm(FrmCommRateTblSAE)
    End Sub

    Private Sub ACGroupSecToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACGroupSecToolStripMenuItem.Click
        ShowNewForm(FrmCommRateTblSAgp)
    End Sub

    Private Sub ManagerSecuritiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManagerSecuritiesToolStripMenuItem.Click
        ShowNewForm(FrmCommRateTblSMan)
    End Sub

    Private Sub ManagerGroupSecuritiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManagerGroupSecuritiesToolStripMenuItem.Click
        ShowNewForm(FrmCommRateTblSMgp)
    End Sub

    Private Sub ACFuturesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACFuturesToolStripMenuItem.Click
        ShowNewForm(FrmCommRatetblFutAcc)
    End Sub

    Private Sub AEFuturesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AEFuturesToolStripMenuItem.Click
        ShowNewForm(FrmCommRatetblFutAE)
    End Sub

    Private Sub ACGroupFuturesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACGroupFuturesToolStripMenuItem.Click
        ShowNewForm(FrmCommRatetblFAgp)
    End Sub

    Private Sub ManagerFuturesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManagerFuturesToolStripMenuItem.Click
        ShowNewForm(FrmCommRatetblFMan)
    End Sub

    Private Sub IncentiveAndBonusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncentiveAndBonusToolStripMenuItem.Click
        ShowNewForm(FrmCommRateTblOtherAE)
    End Sub

    Private Sub ManagerGroupFuturesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManagerGroupFuturesToolStripMenuItem.Click
        ShowNewForm(FrmCommRatetblMgp)
    End Sub

    Private Sub GlobalRateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GlobalRateToolStripMenuItem.Click
        ShowNewForm(FrmCommRateGlobal)
    End Sub

    Private Sub AdjustmentSecuritiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdjustmentSecuritiesToolStripMenuItem.Click
        ShowNewForm(FrmTransAdjS)
    End Sub

    Private Sub AdjustmentFuturesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdjustmentFuturesToolStripMenuItem.Click
        ShowNewForm(FrmTransAdjF)
    End Sub

    Private Sub AdjustmentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdjustmentReportToolStripMenuItem.Click
        ShowNewForm(FrmRptTransDiff)
    End Sub

    Private Sub TransactionReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransactionReportToolStripMenuItem.Click
        ShowNewForm(FrmRptTransAdj)
    End Sub

    Private Sub CommissionGenerationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommissionGenerationToolStripMenuItem.Click
        ShowNewForm(frmCommAE)
    End Sub

    Private Sub CommissionAdjustmentToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommissionAdjustmentToolStripMenuItem1.Click
        ShowNewForm(FrmCommAeCommAdj)
    End Sub

    Private Sub AECommissionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AECommissionToolStripMenuItem.Click
        ShowNewForm(FrmRptAeComm)
    End Sub

    Private Sub AECommissionAdjustmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AECommissionAdjustmentToolStripMenuItem.Click
        ShowNewForm(FrmRptCommCommAdj)
    End Sub

    Private Sub AECommissionDetailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AECommissionDetailToolStripMenuItem.Click
        ShowNewForm(FrmRptCommAEDetail)
    End Sub

    Private Sub AECommissionSchemeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AECommissionSchemeToolStripMenuItem.Click
        ShowNewForm(FrmRptCommScheme)
    End Sub

    Private Sub AERebateDifferenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AERebateDifferenceToolStripMenuItem.Click
        ShowNewForm(FrmRptCommCompareRebate)
    End Sub

    Private Sub ACMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACMasterToolStripMenuItem.Click
        ShowNewForm(FrmCommAccMasterS)
    End Sub

    Private Sub AEMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AEMasterToolStripMenuItem.Click
        ShowNewForm(FrmCommAEMaster)
    End Sub

    Private Sub AEGroupMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AEGroupMasterToolStripMenuItem.Click
        ShowNewForm(FrmCommGroupMasterS)
    End Sub

    Private Sub ManagerMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManagerMasterToolStripMenuItem.Click
        ShowNewForm(FrmCommMgrMaster)
    End Sub

    Private Sub ProductGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductGroupToolStripMenuItem.Click
        ShowNewForm(FrmCommProd)
    End Sub

    Private Sub CopySchemeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopySchemeToolStripMenuItem.Click
        ShowNewForm(FrmCommScheme)
    End Sub

    Private Sub CopyRateFromAFEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyRateFromAFEToolStripMenuItem.Click
        ShowNewForm(FrmCommCopyRate)
    End Sub

    Private Sub ChangeMonthToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeMonthToolStripMenuItem.Click
        ShowNewForm(FrmCommMonth)
    End Sub

    Private Sub ImportCommDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportCommDataToolStripMenuItem.Click
        ShowNewForm(FrmImportFuturesComm)
    End Sub

    Private Sub MarginCallConcentrationReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarginCallConcentrationReportToolStripMenuItem.Click
        ShowNewForm(FrmRptDebitBalCon)
    End Sub

    Private Sub LiquidationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquidationToolStripMenuItem.Click
        ShowNewForm(FrmLiqList)
    End Sub

    Private Sub MarginCallReportNewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarginCallReportNewToolStripMenuItem.Click
        ShowNewForm(FrmRptMrgCall)
    End Sub

    Private Sub CreditLimitReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditLimitReportToolStripMenuItem.Click
        ShowNewForm(FrmCrLmtRpt)
    End Sub

    Private Sub FeeClassMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FeeClassMasterToolStripMenuItem.Click
        ShowNewForm(FrmFeeClsMaster)
    End Sub

    Private Sub AutoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoToolStripMenuItem.Click
        ShowNewForm(FrmHSBCAutopay)
    End Sub

    Private Sub OTRptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OTRptToolStripMenuItem.Click
        ShowNewForm(FrmRptOverTrade)
    End Sub

    Private Sub GroupAEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupAEToolStripMenuItem.Click
        ShowNewForm(FrmCommGroupAE)
    End Sub

    Private Sub AccountTradePatternFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountTradePatternFToolStripMenuItem.Click
        ShowNewForm(FrmAccTradePattern)
    End Sub

    Private Sub AESpecialSecuritiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AESpecialSecuritiesToolStripMenuItem.Click
        ShowNewForm(FrmCommRateTblSSpecial)
    End Sub

    Private Sub FuturesPLReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FuturesPLReportToolStripMenuItem.Click
        ShowNewForm(FrmRptFutPL)
    End Sub

    Private Sub PPSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PPSToolStripMenuItem.Click
        ShowNewForm(FrmPPS)
    End Sub


    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        ShowNewForm(FrmStressTest)
    End Sub

    Private Sub CouponPlansToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CouponPlansToolStripMenuItem.Click
        ShowNewForm(frmCouponPlan)
    End Sub

    Private Sub AlertTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlertTypeToolStripMenuItem.Click
        ShowNewForm(frmCouponAlertType)
    End Sub

    Private Sub AlertEmailListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlertEmailListToolStripMenuItem.Click
        ShowNewForm(frmCouponEmailList)
    End Sub

    Private Sub CToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CToolStripMenuItem.Click
        ShowNewForm(frmCoupons)
    End Sub

    Private Sub ExchangeRateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExchangeRateToolStripMenuItem.Click
        ShowNewForm(frmExchangeRate)
    End Sub

    Private Sub ConnectedTransactionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectedTransactionToolStripMenuItem.Click
        ShowNewForm(frmConTransMaintenance)
    End Sub
    Private Sub ConnectedTransactionFixedExRateToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ConnectedTransactionFixedExRateToolStripMenuItem.Click
        ShowNewForm(frmConTransMaintenanceFixedExRate)
    End Sub

    Private Sub CCTReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CCTReportToolStripMenuItem.Click
        ShowNewForm(frmRptCCT)
    End Sub

    Private Sub CommissionLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommissionLogToolStripMenuItem.Click
        ShowNewForm(FrmCmmLog)
    End Sub

    Private Sub RepledgeStockToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepledgeStockToolStripMenuItem.Click
        ShowNewForm(frmBankList)
    End Sub

    Private Sub NewedgeProductMappingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewedgeProductMappingToolStripMenuItem.Click
        ShowNewForm(frmProductMapping)
    End Sub

    Private Sub NewedgeOpenPositionReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewedgeOpenPositionReportToolStripMenuItem.Click
        ShowNewForm(frmNewedgeOpenPos)
    End Sub

    Private Sub AutoMatchReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoMatchReportToolStripMenuItem.Click
        ShowNewForm(frmNewedgeTrans)
    End Sub

    Private Sub NewedgeAutoMatchReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewedgeAutoMatchReportToolStripMenuItem.Click
        ShowNewForm(frmNewedgeAutoMatch)
    End Sub

    Private Sub NewedgeFloatingAndPLReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewedgeFloatingAndPLReportToolStripMenuItem.Click
        ShowNewForm(frmNewedgeFloatingPL)
    End Sub

    Private Sub ApproveCommissionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApproveCommissionsToolStripMenuItem.Click
        ShowNewForm(frmCommApprove)
    End Sub

    Private Sub CommissionApprovedHistroyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommissionApprovedHistroyToolStripMenuItem.Click
        ShowNewForm(frmCommApproveHis)
    End Sub

    Private Sub AECommissionSecuritiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AECommSecurToolS.Click
        ShowNewForm(FrmRptCommRebateSecur)
    End Sub

    Private Sub CommissionReportByAEToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommissionReportByAEToolStripMenuItem1.Click
        ShowNewForm(FrmRptComm)
    End Sub

    Private Sub AdjustmentReportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdjustmentReportToolStripMenuItem1.Click
        ShowNewForm(FrmRptAdj)
    End Sub

    Private Sub AEDetailTS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AEDetailTS.Click
        ShowNewForm(FrmRptAEDetail)
    End Sub

    Private Sub TradeHistoryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TradeHistoryReportToolStripMenuItem.Click
        ShowNewForm(FrmRptTradeHistory)
    End Sub

    Private Sub CIESAlertTS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CIESAlertTS.Click
        ShowNewForm(FrmCIESAlertMaster)
    End Sub

    Private Sub LargeCashDepositLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LargeCashDepositLogToolStripMenuItem.Click
        ShowNewForm(frmRptLargeCashDepositLog)
    End Sub

    Private Sub ClientTurnoverTS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientTurnoverTS.Click
        ShowNewForm(FrmRptClientTurnover)
    End Sub

    Private Sub ExternalAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExternalAccountTS.Click
        ShowNewForm(FrmRptExternalAC)
    End Sub

    Private Sub OPAdjustmentTS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPAdjustmentTS.Click
        ShowNewForm(FrmFuturesStatementOPAdj)
    End Sub

    Private Sub CPAdjustmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CPAdjustmentToolStripMenuItem.Click
        ShowNewForm(FrmFuturesStatementCPAdj)
    End Sub

    Private Sub LHAdjustmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowNewForm(FrmFuturesStatementLHAdj)
    End Sub

    Private Sub TradeHistoryAdjustmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TradeHistoryAdjustmentToolStripMenuItem.Click
        ShowNewForm(FrmFuturesStatementTHAdj)
    End Sub

    Private Sub ExportClientMasterMailTS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportClientMasterMailTS.Click
        ShowNewForm(FrmClientMasterMail)
    End Sub

    Private Sub AdjustmentReportToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdjustmentReportToolStripMenuItem2.Click
        ShowNewForm(FrmRptFuturesStatementAdj)
    End Sub

    Private Sub PLAdjustmentMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PLAdjustmentMenuItem.Click
        ShowNewForm(FrmPLAdj)
    End Sub

    Private Sub CIESPerformanceReportToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CIESPerformanceReportToolStripMenuItem.Click
        ShowNewForm(FrmCIESPerformance)
    End Sub

    Private Sub CIESPerformanceLetterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CIESPerformanceLetterToolStripMenuItem.Click
        ShowNewForm(FrmCIESPerformanceLetter)
    End Sub

    Private Sub StockMonitorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockMonitorToolStripMenuItem.Click
        ShowNewForm(FrmRptStockMonitor)
    End Sub

    Private Sub HSIMaintanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HSIMaintanceToolStripMenuItem.Click
        ShowNewForm(frmHSIMaintance)
    End Sub

    Private Sub StockHoldingSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockHoldingSummaryToolStripMenuItem.Click
        ShowNewForm(FrmRptStockHldgSummary)
    End Sub

    Private Sub AutoStatementMaintainenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoStatementMaintainenceToolStripMenuItem.Click
        ShowNewForm(FrmAutoMailStatementMain)
    End Sub

    Private Sub StockHoldingSummaryMaintanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockHoldingSummaryMaintanceToolStripMenuItem.Click
        ShowNewForm(FrmStockHldgSummaryMain)
    End Sub

    Private Sub CIESMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CIESMaintenanceToolStripMenuItem.Click
        ShowNewForm(FrmCIESMaintenance)
    End Sub

    Private Sub OpenPositionCheckingReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenPositionCheckingReportToolStripMenuItem.Click
        ShowNewForm(frmRptOPChecking)
    End Sub

    Private Sub StockToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockToolStripMenuItem1.Click
        ShowNewForm(FrmStockOptionsAlertMaster)
    End Sub

    Private Sub ClientOptinoutMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientOptinoutMasterToolStripMenuItem.Click
        ShowNewForm(FrmClientOptInOut)
    End Sub

    Private Sub OptedOutClientListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptedOutClientListToolStripMenuItem.Click
        ShowNewForm(FrmRptOptedOutClientList)
    End Sub

    Private Sub NotOptedOutClientListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotOptedOutClientListToolStripMenuItem.Click
        ShowNewForm(FrmRptNotOptedOutClientList)
    End Sub

    Private Sub NotOptedOutClientListEmailOnlyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotOptedOutClientListemailOnlyToolStripMenuItem.Click
        ShowNewForm(frmRptNotOptedOutEmailList)
    End Sub


    Private Sub FATCAAccountListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FATCAAccountListToolStripMenuItem.Click
        ShowNewForm(FrmRptFatcaAccountList)
    End Sub

    Private Sub ForeignMarketReportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ForeignMarketReportToolStripMenuItem.Click
        ShowNewForm(FrmRptForeignMarket)
    End Sub

    Private Sub IRSToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles IRSToolStripMenuItem.Click
        ShowNewForm(frmIRS)
    End Sub

    Private Sub EmailAlertRecipientListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmailAlertRecipientListToolStripMenuItem.Click
        ShowNewForm(FrmEmailAlertRecipientList)
    End Sub

    Private Sub ImportFATCAInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportFATCAInfoToolStripMenuItem.Click
        ShowNewForm(FrmImportFATCAInfo)
    End Sub

    Private Sub FutureProductMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FutureProductMasterMenuItem.Click
        ShowNewForm(frmFutureProductMaster)
    End Sub

    Private Sub CRCDebitBalanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CRCDebitBalanceToolStripMenuItem.Click
        ShowNewForm(frmCRCDebitBalance)
    End Sub

    Private Sub ChequePrintingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChequePrintingMenuItem.Click
        ShowNewForm(FrmChequePrinting)
    End Sub

    Private Sub HSBCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HSBCToolStripMenuItem.Click
        ShowNewForm(FrmHSBC)
    End Sub

    Private Sub ImportDataNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportDataNewToolStripMenuItem.Click
        ShowNewForm(FrmImportData)
    End Sub

    Private Sub ImportDataUSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportDataUSToolStripMenuItem.Click
        ShowNewForm(FrmImportDataUS)
    End Sub

    Private Sub RunnerTaxableIncomeMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunnerTaxableIncomeMasterToolStripMenuItem.Click
        ShowNewForm(FrmRunnerTaxableIncomeMaster)
    End Sub

    Private Sub ImportCRSInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportCRSInfoToolStripMenuItem.Click
        ShowNewForm(FrmImportCRSInfo)
    End Sub

    Private Sub ImportCRSAccountInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportCRSAccountInfoToolStripMenuItem.Click
        ShowNewForm(FrmImportCRSAccountInfo)
    End Sub

    Private Sub ImportCRSCountryInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportCRSCountryInfoToolStripMenuItem.Click
        ShowNewForm(FrmImportCRSCountryInfo)
    End Sub

	Private Sub CRSXMLGenerationToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles CRSXMLGenerationToolStripMenuItem.Click
        ShowNewForm(frmCRS)
    End Sub

    Private Sub CRSMasterMaintenceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CRSMasterMaintenceToolStripMenuItem.Click
        ShowNewForm(frmCRSMasterMain)
    End Sub

    Private Sub TradingActivityParameterMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TradingActivityParameterMaintenanceToolStripMenuItem.Click
        ShowNewForm(frmITAM)
    End Sub

    Private Sub IPCountryMappingDataImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IPCountryMappingDataImportToolStripMenuItem.Click
        ShowNewForm(frmIP)
    End Sub

    Private Sub showImpTradingActivityForm(ByVal ImpMod As String)
        frmImpFutureAndStock.Close()
        frmImpFutureAndStock.FrmMod = ImpMod
        Dim cls = New clsITA
        frmImpFutureAndStock.TDate = cls.FncGetRefPeriod(False)
        If frmImpFutureAndStock.TDate = Format(DateTime.MinValue, "MM/yyyy") Then
            GSubShowWarn("Referencing period has not been defined!")
        Else
            ShowNewForm(frmImpFutureAndStock)
        End If
    End Sub

    Private Sub FuturesTradingActivityImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FuturesTradingActivityImportToolStripMenuItem.Click
        showImpTradingActivityForm("F")
    End Sub

    Private Sub StockOptionsTradingActivityImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockOptionsTradingActivityImportToolStripMenuItem.Click
        showImpTradingActivityForm("O")
    End Sub

    Private Sub FuturesTradingActivityAlertReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FuturesTradingActivityAlertReportsToolStripMenuItem.Click
        frmRptTradingActAlert.Close()
        frmRptTradingActAlert.FrmMod = "F"
        ShowNewForm(frmRptTradingActAlert)
    End Sub

    Private Sub StockOptionsTradingActivityAlertReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockOptionsTradingActivityAlertReportsToolStripMenuItem.Click
        frmRptTradingActAlert.Close()
        frmRptTradingActAlert.FrmMod = "O"
        ShowNewForm(frmRptTradingActAlert)
    End Sub

    Private Sub ClientBalanceSummaryReportUSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientBalanceSummaryReportUSToolStripMenuItem.Click
        ShowNewForm(FrmCltBalSumUS)
    End Sub

    Private Sub MarginCallConcentrationReportUSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarginCallConcentrationReportUSToolStripMenuItem.Click
        ShowNewForm(FrmRptDebitBalConUS)
    End Sub

    Private Sub MarginCallReportUSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarginCallReportUSToolStripMenuItem.Click
        ShowNewForm(FrmRptMrgCallUS)
    End Sub

    Private Sub MarginClientStockHoldingsUSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarginClientStockHoldingsUSToolStripMenuItem.Click
        ShowNewForm(FrmStockHoldingUS)
    End Sub

    Private Sub StressTestReportUSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StressTestReportUSToolStripMenuItem.Click
        ShowNewForm(FrmStressTestUS)
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub EditReportDateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditReportDateToolStripMenuItem.Click
        ShowNewForm(FrmEditReportDate)
    End Sub
End Class

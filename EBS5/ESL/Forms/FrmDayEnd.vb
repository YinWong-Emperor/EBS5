Imports System.Data.SqlClient

Public Class FrmDayEnd

    'Dim clsde As New ClsDayEnd
    'Dim lblnErrFlag As Boolean
    'Dim frmmu As frmMenu

    'Private Sub FrmDayEnd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    '    If e.KeyChar = ChrW(Keys.Escape) Then
    '        Me.Close()
    '    End If
    'End Sub

    'Private Sub FrmDayEnd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    GsubDayEnd(False)
    '    frmmu = MdiParent
    '    Me.lsubShowProcessing(False)
    'End Sub

    'Public Sub GsubDayEnd(ByVal lblnerr As Boolean)

    '    Me.ListBox1.Items.Clear()
    '    If lblnerr Then
    '        Me.ListBox1.Items.Add("  Warning :")
    '        Me.ListBox1.Items.Add("  DAYEND automatic recovery :")
    '        Me.ListBox1.Items.Add("  Error occured during the previous dayend !!!")
    '        Me.ListBox1.Items.Add("  Data files will be overwrited with last backup")
    '    Else
    '        Me.ListBox1.Items.Add("  Make sure :")
    '        Me.ListBox1.Items.Add("  All the neccessary reports have been printed")
    '        Me.ListBox1.Items.Add("  cross checked")
    '    End If

    '    Me.MyTextbox2.Enabled = True
    '    lblnErrFlag = lblnerr
    '    Me.MyTextbox2.Focus()

    'End Sub

    'Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    '    Me.Close()
    'End Sub

    'Private Sub MyTextbox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyTextbox2.KeyDown
    '    Dim lintResult As Integer

    '    If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.LineFeed Then
    '        If UCase(Me.MyTextbox2.Text.Trim) = "N" Then
    '            Me.Close()
    '        End If
    '        If UCase(Me.MyTextbox2.Text.Trim) = "Y" Then
    '            Dim frmcp As New frmChkPwd
    '            frmcp.Text = "Confirm to start DayEnd "
    '            If frmcp.ShowDialog() = Windows.Forms.DialogResult.Yes Then
    '                lintResult = lfncstartdayend()
    '                Select Case lintResult
    '                    Case 62
    '                        GSubShowInfo(GFncGetSysMsg(62) & "   (" & Format(g_tdate, "dd/MM/yyyy") & ") ")
    '                        End
    '                    Case 64 Or 20
    '                        GSubShowInfo(GFncGetSysMsg(lintResult))
    '                    Case 108
    '                        GSubShowInfo(GFncGetSysMsg(lintResult))
    '                    Case Else
    '                        GSubShowInfo(GFncGetSysMsg(lintResult))
    '                        End
    '                End Select
    '            Else
    '                GSubShowInfo(GFncGetSysMsg(61))
    '            End If
    '        Else
    '            Me.MyTextbox2.Text = ""
    '        End If
    '        Me.lsubShowProcessing(False)

    '        frmmu.TimChecking.Enabled = True
    '    End If
    'End Sub

    'Private Sub lsubFieldControl(ByVal lblnFlag As Boolean)
    '    Me.MyTextbox2.Enabled = lblnFlag
    '    Me.btnCancel.Enabled = lblnFlag
    '    Me.btnSave.Enabled = lblnFlag
    'End Sub

    'Private Function lfncstartdayend() As Integer
    '    Dim ldtsDate As DataSet
    '    Dim ldtwdate As DataRow
    '    Dim lstnTrans As SqlTransaction
    '    'Dim frmmu As frmMenu

    '    If Not clsde.GfncCheckDayEnd() Then
    '        Return 20
    '    End If

    '    If Not clsde.GfncCheckClosingPrice Then
    '        Return 108
    '    End If

    '    'frmmu = MdiParent
    '    frmmu.TimChecking.Enabled = False

    '    If Not clsde.GfncUpdateFlag("B") Then
    '        Return 73
    '    End If

    '    Me.lsubFieldControl(False)
    '    Me.lsubShowProcessing(True)
    '    Me.ListBox1.Items.Clear()
    '    Me.ListBox1.Items.Add("Step 1) Backup Database")
    '    Application.DoEvents()
    '    Dim lstrResult As String = clsde.GfncBackupDB()
    '    If lstrResult <> "OK" And lstrResult <> "SUCCESS" Then
    '        Me.lsubFieldControl(True)
    '        Return 64
    '    End If

    '    If Not clsde.GfncUpdateFlag("E") Then
    '        Return 73
    '    End If

    '    lstnTrans = GSCnSqlConn.BeginTransaction("DayEnd")
    '    Try
    '        ldtsDate = clsde.GfncGetTDate(lstnTrans)
    '        If ldtsDate.Tables(0).Rows.Count <= 0 Then
    '            lstnTrans.Rollback("DayEnd")
    '            Return 73
    '        End If
    '        ldtwdate = ldtsDate.Tables(0).Rows(0)
    '        g_tdate = ldtwdate("d_tdate")

    '        'dayend margin call
    '        Me.ListBox1.Items.Add("Step 2) Dayend Margin Call Listing")
    '        Application.DoEvents()
    '        Dim cls As New ClsReports
    '        cls.MARGIN_CALL_REPORT(True, lstnTrans)

    '        Me.ListBox1.Items.Add("Step 3) Consolidating A/C")
    '        Application.DoEvents()
    '        If Not lfncStartConsolac(lstnTrans) Then
    '            lstnTrans.Rollback("DayEnd")
    '            Return 73
    '        End If
    '        Me.ListBox1.Items.Add("Step 4) Updating order file")
    '        Application.DoEvents()
    '        If Not IsEmptyDate(ldtwdate("d_int_date")) Then
    '            If Not lfncStartUpdateOrd(lstnTrans, ldtwdate("d_int_date")) Then
    '                lstnTrans.Rollback("DayEnd")
    '                Return 73
    '            End If
    '        End If
    '        Me.ListBox1.Items.Add("Step 5) Deleting liquidated orders")
    '        Application.DoEvents()
    '        If Not lfncStartDeleteOrd(lstnTrans) Then
    '            lstnTrans.Rollback("DayEnd")
    '            Return 73
    '        End If
    '        Me.ListBox1.Items.Add("Step 6) Updating monthly accumlate values")
    '        Application.DoEvents()
    '        If Not lfncStartUpdatemon(lstnTrans, ldtwdate) Then
    '            lstnTrans.Rollback("DayEnd")
    '            Return 73
    '        End If

    '        lstnTrans.Commit()

    '    Catch ex As Exception
    '        lstnTrans.Rollback("DayEnd")
    '        clsde.GfncUpdateFlag("D")
    '        GSubWriteErrLog("clsDayEnd: " & ex.Message)
    '        Return 73
    '    End Try

    '    Return 62

    'End Function

    'Private Function lfncStartUpdatemon(ByRef lstnTrans As SqlTransaction, ByVal ldtwdate As DataRow) As Boolean
    '    Dim lstrSQL As String

    '    clsde.GFncUpdateMonthly(lstnTrans, ldtwdate("d_tdate"))

    '    g_eus = clsde.GfncGetTClosePrice("EUS", lstnTrans)
    '    g_jpn = clsde.GfncGetTClosePrice("JPN", lstnTrans)
    '    g_gbn = clsde.GfncGetTClosePrice("GBN", lstnTrans)
    '    g_swz = clsde.GfncGetTClosePrice("SWZ", lstnTrans)
    '    g_aus = clsde.GfncGetTClosePrice("AUS", lstnTrans)

    '    lstrSQL = "   update date set  D_L_INT_CU = case when d_int_date is null then d_l_int_cu else d_int_date end, " & _
    '                          " D_L_INT_CA = D_TDATE, " & _
    '                          " D_INT_DATE = null, " & _
    '                          " D_L_TDATE  = D_TDATE, " & _
    '                          " D_M_COUNT  = 0, " & _
    '                          " D_DAY_NIG  = ' ' , " & _
    '                          " D_EUS = " & g_eus & ", " & _
    '                          " D_JPN = " & g_jpn & ", " & _
    '                          " D_GBN = " & g_gbn & ", " & _
    '                          " D_SWZ = " & g_swz & ", " & _
    '                          " D_AUS = " & g_aus

    '    If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL) > 0 Then
    '        Return True
    '    Else
    '        Return False
    '    End If



    'End Function

    'Private Function lfncStartDeleteOrd(ByRef lstnTrans As SqlTransaction) As Boolean
    '    Dim lstrSQL As String

    '    lstrSQL = " delete from [order] where D_STATE = '" & O_Liq & "' OR D_LOTS = 0 OR D_NEW_LIQ = 'L' "
    '    GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL)

    '    Return True

    'End Function

    'Private Function lfncStartUpdateOrd(ByRef lstnTrans As SqlTransaction, ByVal ldteint As Date) As Boolean
    '    Dim lstrSQL As String

    '    lstrSQL = " update [order] set d_int_date = '" & Format(ldteint, "yyyy/MM/dd") & "' " & _
    '                    " where d_svl_date <= '" & Format(ldteint, "yyyy/MM/dd") & "' "
    '    GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL)
    '    Return True

    'End Function

    'Private Function lfncStartConsolac(ByRef lstnTrans As SqlTransaction) As Boolean
    '    Dim ldtsAcc As DataSet
    '    Dim ldtcAcc As DataRowCollection
    '    Dim ldtwAcc As DataRow
    '    Dim ldtsNL As DataSet
    '    Dim ldtaNL As DataRow()
    '    Dim lstrSQL As String

    '    Dim ldecfloating As Decimal = 0.0            ' && Floating value

    '    Dim ldect_in As Decimal = 0.0             '&& Daily accumulate figures
    '    Dim ldect_out As Decimal = 0.0
    '    Dim ldecm_in As Decimal = 0.0
    '    Dim ldecm_out As Decimal = 0.0
    '    Dim ldecg_in As Decimal = 0.0
    '    Dim ldecg_out As Decimal = 0.0
    '    Dim ldecother As Decimal = 0.0
    '    Dim ldecpl As Decimal = 0.0
    '    Dim ldect_pl As Decimal = 0.0
    '    Dim ldectfloat As Decimal = 0.0
    '    Dim ldecNlots As Decimal = 0.0
    '    Dim ldecLlots As Decimal = 0.0

    '    '** Begin 2004/0206
    '    Dim ldectbufloat As Decimal = 0.0
    '    Dim ldectfxfloat As Decimal = 0.0
    '    '** End 2004/0206

    '    Dim ldtsOrder As DataSet
    '    Dim ldtsOp As DataSet
    '    Dim ldtsCurr As DataSet
    '    Dim ldtsDate As DataSet

    '    modcal.Prepare_Dataset_for_Cal(ldtsAcc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate, lstnTrans)

    '    Dim ldtsTerms As DataSet = clsde.lFunGetAllTerms(lstnTrans)
    '    Dim ldtsSales As DataSet = clsde.lFunGetAllSales(lstnTrans)

    '    If Not clsde.GfncPrepareDaily(lstnTrans) Then
    '        Return False
    '    End If

    '    Dim ldtsTConfig As DataSet = clsde.lFunGetTermsConfig(lstnTrans)
    '    ldtsNL = clsde.GfncACNLCount(lstnTrans)
    '    'ldtsAcc = clsde.GfncAccLst(lstnTrans)
    '    If ldtsAcc.Tables(0).Rows.Count <= 0 Then
    '        GSubShowInfo(GFncGetSysMsg(25))
    '        Return False
    '    End If
    '    ldtcAcc = ldtsAcc.Tables(0).Rows
    '    For Each ldtwAcc In ldtcAcc
    '        Me.Label2.Text = "A/C " & ldtwAcc("d_ano")
    '        'Me.ListBox1.Items.Add("A/C " & ldtwAcc("d_ano"))
    '        'Me.ListBox1.SelectedIndex() = Me.ListBox1.Items.Count - 1
    '        Application.DoEvents()

    '        Dim ldtaSales As DataRow()

    '        ldtaSales = ldtsSales.Tables(0).Select(" d_sno = '" & ldtwAcc("d_sno") & "' ")
    '        If ldtaSales.Length > 0 Then
    '            ldtwAcc("d_sgroup") = ldtaSales(0).Item("d_sgroup")
    '        End If

    '        If (Math.Abs(ldtwAcc("D_TRAN")) <> 0) Then
    '            If (ldtwAcc("D_TRAN") > 0) Then
    '                ldecm_in += ldtwAcc("D_MARG_IN") - ldtwAcc("D_TRAN")
    '                ldecm_out += ldtwAcc("D_MARG_OUT")
    '                ldect_in += ldtwAcc("D_TRAN")

    '                lstrSQL = " update account set D_BF_M_IN = D_BF_M_IN + D_MARG_IN - D_TRAN, " & _
    '                            " D_BF_M_OUT = D_BF_M_OUT + D_MARG_OUT  " & _
    '                            " where d_ano = '" & ldtwAcc("d_ano") & "' "
    '                If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL) <= 0 Then
    '                    Return False
    '                End If

    '            Else
    '                ldecm_in += ldtwAcc("D_MARG_IN")
    '                ldecm_out += (ldtwAcc("D_MARG_OUT") - Math.Abs(ldtwAcc("D_TRAN")))
    '                ldect_out += ldtwAcc("D_TRAN")

    '                lstrSQL = " update account set D_BF_M_IN = D_BF_M_IN + D_MARG_IN, " & _
    '                                               " D_BF_M_OUT = D_BF_M_OUT + D_MARG_OUT - ABS(D_TRAN) " & _
    '                                               " where d_ano = '" & ldtwAcc("d_ano") & "' "
    '                If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL) <= 0 Then
    '                    Return False
    '                End If

    '            End If
    '        Else
    '            ldecm_in += ldtwAcc("D_MARG_IN")
    '            ldecm_out += ldtwAcc("D_MARG_OUT")

    '            lstrSQL = " update account set D_BF_M_IN = D_BF_M_IN + D_MARG_IN, " & _
    '                               " D_BF_M_OUT = D_BF_M_OUT + D_MARG_OUT" & _
    '                               " where d_ano = '" & ldtwAcc("d_ano") & "' "
    '            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL) <= 0 Then
    '                Return False
    '            End If

    '        End If

    '        ldecg_in += ldtwAcc("D_GOLD_IN")
    '        ldecg_out += ldtwAcc("D_GOLD_OUT")

    '        define_trading_terms(ldtwAcc("D_ANO"), lstnTrans, ldtsAcc, ldtsTerms)
    '        GET_AC_STATUS(ldtwAcc("D_ANO"), "N", "Y", Nothing, lstnTrans, False, ldtsAcc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate)

    '        lstrSQL = " update account set D_PR_BAL =  D_PR_BAL + D_MARG_IN - D_MARG_OUT " & _
    '                  " + " & ag_status(AC_PL) & "  + " & ag_status(AC_INTEREST) & _
    '                  " + " & ag_status(AC_COMM) & " + " & ag_status(AC_STORAGE) & " , " & _
    '                " D_BF_STO = D_BF_STO + " & ag_status(AC_STORAGE) & " , " & _
    '             " D_BF_COMM  = D_BF_COMM  + " & ag_status(AC_COMM) & " ,  " & _
    '             " D_BF_INT   = D_BF_INT   + " & ag_status(AC_INTEREST) & " , " & _
    '             " D_BF_PL    = D_BF_PL    + " & ag_status(AC_PL) & " , " & _
    '             " D_G_PR_BAL = D_G_PR_BAL + D_GOLD_IN - D_GOLD_OUT,  " & _
    '             " D_BF_BCOMM = D_BF_BCOMM + " & ag_status(AC_BU_COMM) & ", " & _
    '             " D_BF_FCOMM = D_BF_FCOMM + " & ag_status(AC_FX_COMM) & ", " & _
    '             " D_BF_BINT  = D_BF_BINT  + " & ag_status(AC_BU_INT) & ", " & _
    '             " D_BF_FINT  = D_BF_FINT  + " & ag_status(AC_FX_INT) & ", " & _
    '             " D_BF_BPL   = D_BF_BPL   + " & ag_status(AC_BU_PL) & ", " & _
    '             " D_BF_FPL   = D_BF_FPL   + " & ag_status(AC_FX_PL) & ", " & _
    '             " D_MARG_IN  = 0, D_MARG_OUT = 0, D_GOLD_IN  = 0, D_GOLD_OUT = 0, " & _
    '             " D_ADJ_COMM = 0, D_ADJ_INT  = 0, D_ADJ_STO  = 0, D_ADJ_PL   = 0, D_TRAN = 0, " & _
    '              " D_ADJ_MAR_OUT = 0, D_ADJ_MAR_IN  = 0 " & _
    '             " where d_ano = '" & ldtwAcc("d_ano") & "' "
    '        If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL) <= 0 Then
    '            Return False
    '        End If

    '        ldectfloat += ag_status(AC_FLOATING)
    '        '** Begin 2004/0206
    '        ldectbufloat += ag_status(AC_BU_FLOAT)
    '        ldectfxfloat += ag_status(AC_FX_FLOAT)
    '        '** End 2004/0206

    '        Dim ldecDint As Decimal = ag_status(AC_INTEREST)
    '        Dim ldecDcomm As Decimal = ag_status(AC_COMM)
    '        Dim ldecDPL As Decimal = ag_status(AC_PL)
    '        Dim ldecDSto As Decimal = ag_status(AC_STORAGE)
    '        Dim ldecDEquity As Decimal = ag_status(AC_EQUITY)
    '        Dim ldecDGValue As Decimal = ag_status(AC_GOLD_VALUE)
    '        Dim ldecDFloating As Decimal = ag_status(AC_FLOATING)

    '        ldecpl = 0
    '        If Not CAL_TODAY_PL(lstnTrans, ldtwAcc, ldtsOrder, ldtsCurr, ldtsDate, ldtsTConfig, ldecpl) Then
    '            Return False
    '        End If
    '        If ag_status(AC_PL) <> 0 Then
    '            ldect_pl += ag_status(AC_PL)
    '            ' ldecpl = CAL_TODAY_PL(lstnTrans, ldtwAcc, ldtsOrder, ldtsCurr, ldtsDate, ldtsTConfig)
    '            lstrSQL = " insert into profit (d_ano, d_tdate, d_act_pl, d_daily_pl) values " & _
    '                    " ('" & ldtwAcc("d_ano") & "', '" & Format(g_tdate, "yyyy/MM/dd") & _
    '                    "', " & ag_status(AC_PL) & "," & ldecpl & " ) "
    '            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL) <= 0 Then
    '                Return False
    '            End If

    '        End If

    '        ldecNlots = 0
    '        ldecLlots = 0
    '        ldtaNL = Nothing
    '        ldtaNL = ldtsNL.Tables(0).Select(" d_ano = '" & ldtwAcc("d_ano") & "' and d_new_liq = 'N' ")
    '        If ldtaNL.Length > 0 Then
    '            ldecNlots = ldtaNL(0).Item("tot_lots")
    '        End If
    '        ldtaNL = Nothing
    '        ldtaNL = ldtsNL.Tables(0).Select(" d_ano = '" & ldtwAcc("d_ano") & "' and d_new_liq = 'L' ")
    '        If ldtaNL.Length > 0 Then
    '            ldecLlots = ldtaNL(0).Item("tot_lots")
    '        End If
    '        If Not clsde.GfncUPDDaily(ldtwAcc, ldecpl, ldecNlots, ldecLlots, ldecDPL, ldecDint, _
    '        ldecDSto, ldecDcomm, ldecDEquity, ldecDGValue, ldecDFloating, lstnTrans) Then
    '            Return False
    '        End If

    '    Next
    '    lstrSQL = " select * into #tmp_accum from accum where d_tdate = '" & Format(g_l_tdate, "yyyy/MM/dd") & "' "
    '    If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL) <= 0 Then
    '        Return False
    '    End If

    '    lstrSQL = " update #tmp_accum set D_TDATE = '" & Format(g_tdate, "yyyy/MM/dd") & "', " & _
    '                             " D_M_T_IN = D_M_T_IN + " & ldect_in & " , " & _
    '                              " D_M_T_OUT = D_M_T_OUT  + " & ldect_out & " , " & _
    '                              " D_PL_HK  =  " & ldectfloat & " , " & _
    '                              " D_PL_BHK = " & ldectbufloat & " , " & _
    '                              " D_PL_FHK = " & ldectfxfloat
    '    If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL) <= 0 Then
    '        Return False
    '    End If

    '    lstrSQL = " insert into accum select * from #tmp_accum "
    '    If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL) <= 0 Then
    '        Return False
    '    End If

    '    lstrSQL = " drop table #tmp_accum "
    '    GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL)


    '    If Not clsde.GfncUpdOrdPos(lstnTrans) Then
    '        Return False
    '    End If

    '    Return True

    'End Function

    ''Private Function CAL_TODAY_PL(ByRef lstnTrans As SqlTransaction, ByVal ldtwAcc As DataRow, _
    ''  ByVal ldtsOrder As DataSet, ByVal ldtsCurr As DataSet, ByVal ldtsDate As DataSet, _
    ''  ByVal ldtsTConfig As DataSet, ByRef ldecPL As Decimal) As Boolean

    ''    Dim lstrop_no As String
    ''    Dim lint As Integer
    ''    Dim lintOP As Integer
    ''    Dim ldtaOrder As DataRow()
    ''    Dim ldtwOrder As DataRow

    ''    ldtaOrder = ldtsOrder.Tables(0).Select(" d_ano = '" & ldtwAcc("d_ano") & "' ")

    ''    If ldtaOrder.Length > 0 Then
    ''        For lint = 0 To ldtaOrder.Length - 1
    ''            afill(ag_order, 0, O_ORDER_SIZE)
    ''            ldtwOrder = ldtaOrder(lint)
    ''            If ldtwOrder("D_STATE") = O_New And ldtwOrder("D_NEW_LIQ") = "N" Then
    ''                GATHER_ORD(ldtwOrder, ldtwAcc, "N", lstnTrans, ldtsCurr)
    ''                CAL_ORDER_PROFIT("O", g_int_date, lstnTrans, ldtsDate, ldtsCurr, True)
    ''                If ldtwOrder("d_lots") > 0 Then
    ''                    If Not clsde.GfuncInsertEOrder("OPEN", ldtwOrder, ldtwAcc, ldtsTConfig, lstnTrans) Then
    ''                        Return False
    ''                    End If
    ''                End If
    ''                If ldtwOrder("d_o_date") = g_tdate Then
    ''                    If Not clsde.GfuncInsertEOrder("NEW", ldtwOrder, ldtwAcc, ldtsTConfig, lstnTrans) Then
    ''                        Return False
    ''                    End If
    ''                End If
    ''            End If

    ''            If ldtwOrder("D_STATE") = O_New And ldtwOrder("D_NEW_LIQ") = "L" Then
    ''                '&& clear the order array
    ''                lstrop_no = ldtwOrder("D_ORD_NO") '&& liq. order number

    ''                GATHER_ORD(ldtwOrder, ldtwAcc, "L", lstnTrans, ldtsCurr)           '&& find liq. order information
    ''                If Not clsde.GfuncInsertEOrder("LIQ", ldtwOrder, ldtwAcc, ldtsTConfig, lstnTrans) Then
    ''                    Return False
    ''                End If

    ''                Dim ldtaOP As DataRow()
    ''                Dim ldtwOP As DataRow = Nothing
    ''                ldtaOP = ldtsOrder.Tables(0).Select(" d_op_no = '" & lstrop_no & "' ")
    ''                For lintOP = 0 To ldtaOP.Length - 1
    ''                    ldtwOP = ldtaOP(lintOP)
    ''                    GATHER_ORD(ldtwOP, ldtwAcc, "O", lstnTrans, ldtsCurr)      '&& find original order information
    ''                    '&& calculate actual order profit
    ''                    CAL_ORDER_PROFIT("L", g_int_date, lstnTrans, ldtsDate, ldtsCurr, True)
    ''                    If Not clsde.GfuncInsertEOrder("OP", ldtwOP, ldtwAcc, ldtsTConfig, lstnTrans) Then
    ''                        Return False
    ''                    End If
    ''                    If ldtwOP("D_STATE") = O_Liq And ldtwOP("D_O_DATE") = g_tdate Then
    ''                        ldecPL += ag_order(O_PL)
    ''                    End If
    ''                Next
    ''            End If
    ''        Next
    ''    End If

    ''    Return True

    ''End Function

    'Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
    '    pbarPrint.Visible = blnShow
    '    lblProcess.Visible = blnShow
    '    Me.btnCancel.Visible = Not blnShow
    '    Me.btnSave.Visible = False
    '    Me.MyTextbox2.Enabled = Not blnShow
    'End Sub

    
End Class

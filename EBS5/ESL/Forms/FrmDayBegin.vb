Imports System
Imports System.Data.SqlClient

Public Class FrmDayBegin

    'Dim data As New ClsDayBegin
    'Dim ldtscurr As DataSet

    'Private Sub MyMaskedTextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyMaskedTextBox1.LostFocus
    '    'Dim lstrDate As String = lfncCheckDate(Me.MyMaskedTextBox1.Text)
    '    'If lstrDate <> "" Then
    '    '    g_tdate = lstrDate
    '    '    Me.MyTextbox1.Text = "[ " & Format(g_tdate, "ddd  dd  MMM  yyyy") & " ]"
    '    'Else
    '    '    GSubShowWarn(GFncGetSysMsg(68))
    '    '    Me.MyTextbox1.Text = "dd/mm/yyyy"
    '    '    Me.MyMaskedTextBox1.Focus()
    '    'End If
    'End Sub

    'Private Sub MyMaskedTextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyMaskedTextBox2.LostFocus
    '    'Dim lstrDate As String = lfncCheckDate(Me.MyMaskedTextBox2.Text)
    '    'If lstrDate <> "" Then
    '    '    g_int_date = lstrDate
    '    '    Me.MyTextbox2.Text = "[ " & Format(g_int_date, "ddd  dd  MMM  yyyy") & " ]"
    '    'Else
    '    '    GSubShowWarn(GFncGetSysMsg(68))
    '    '    Me.MyTextbox2.Text = "dd/mm/yyyy"
    '    '    Me.MyMaskedTextBox2.Focus()
    '    'End If

    'End Sub

    'Private Function lfncCheckDate(ByVal lstrinput As String) As String
    '    Dim lstrdate As String = ""
    '    If Val(Microsoft.VisualBasic.Right(lstrinput, 4)) <= 1900 Then
    '        Return ""
    '    End If

    '    If Val(Microsoft.VisualBasic.Mid(lstrinput, 4, 2)) > 12 Or Val(Microsoft.VisualBasic.Mid(lstrinput, 4, 2)) <= 0 Then
    '        Return ""
    '    End If

    '    lstrdate = "#" & Microsoft.VisualBasic.Right(lstrinput, 4) & "/" & _
    '                            Microsoft.VisualBasic.Mid(lstrinput, 4, 2) & "/" & _
    '                            Microsoft.VisualBasic.Left(lstrinput, 2) & "#"
    '    If IsDate(lstrdate) Then
    '        Return lstrdate
    '    Else
    '        Return ""
    '    End If

    'End Function

    'Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
    '    If Me.ComboBox1.Text <> "N" And Me.ComboBox1.Text <> "Y" Then
    '        Me.ComboBox1.Text = "N"
    '    End If
    '    If Me.ComboBox1.Text = "Y" Then
    '        Me.MyMaskedTextBox2.Enabled = True
    '        Me.MyTextbox2.Text = "dd/mm/yyyy"
    '    Else
    '        Me.MyMaskedTextBox2.Enabled = False
    '        Me.MyMaskedTextBox2.Text = ""
    '        Me.MyTextbox2.Text = ""
    '        g_int_date = Nothing
    '    End If
    'End Sub

    'Private Sub FrmDayBegin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    '    If e.KeyCode = Keys.Escape Then
    '        If Me.TabControl1.SelectedIndex = 0 Then
    '            Me.DialogResult = Windows.Forms.DialogResult.Cancel
    '            Me.MyMaskedTextBox2.Text = Format(Today, "dd/MM/yyyy")
    '            Me.MyMaskedTextBox1.Text = Format(Today, "dd/MM/yyyy")
    '            Me.Close()
    '        Else
    '            If GSubShowYNConfirm(GFncGetSysMsg(70)) = Windows.Forms.DialogResult.Yes Then
    '                Me.TabControl1.SelectTab(0)
    '            End If
    '        End If
    '    End If
    'End Sub

    'Private Sub FrmDayBegin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    Me.MyMaskedTextBox2.Enabled = False
    '    Me.MyMaskedTextBox1.Text = ""
    '    Me.MyMaskedTextBox2.Text = ""
    '    Me.MyTextbox1.Text = "dd/mm/yyyy"
    '    Me.MyTextbox2.Text = ""
    '    g_tdate = Nothing
    '    g_int_date = Nothing
    '    Me.TabControl1.SelectTab(0)
    '    ComboBox1.SelectedIndex = 1
    '    Me.MyMaskedTextBox1.Focus()
    'End Sub

    'Private Sub date_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles date_ok.Click
    '    '    Me.DialogResult = Windows.Forms.DialogResult.OK
    '    If lfncChkValid() = True Then
    '        If GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes Then
    '            Me.TabControl1.SelectTab(1)
    '        End If
    '    End If
    'End Sub

    'Private Sub date_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles date_cancel.Click
    '    Me.DialogResult = Windows.Forms.DialogResult.Cancel
    '    Me.Close()
    'End Sub

    'Private Sub TabControl1_Selected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected

    '    If e.TabPageIndex = 1 Then
    '        ldtscurr = Nothing
    '        ldtscurr = data.GfncGetTCurrency("currency")
    '        Me.DataGridView1.DataSource = ldtscurr
    '        Me.DataGridView1.DataMember = "currency"
    '        Me.lblTDate.Text = "Trade Date = " & Format(g_tdate, "ddd  dd  MMM  yyyy")

    '        For i As Integer = 0 To DataGridView1.RowCount - 1
    '            Me.DataGridView1.Rows(i).Cells(1).Value = g_tdate
    '            Me.DataGridView1.Rows(i).Cells("vdatestr").Value = Format(Me.DataGridView1.Rows(i).Cells("valuedate").Value, "ddd  dd  MMM  yyyy")
    '        Next i

    '        Me.DataGridView1.Focus()
    '    Else
    '        Me.MyMaskedTextBox1.Focus()
    '    End If
    'End Sub

    'Private Function lfncChkValid() As Boolean

    '    If Not IsDate(MyMaskedTextBox1.Text) Then
    '        GSubShowWarn(GFncGetSysMsg(68))
    '        MyMaskedTextBox1.Focus()
    '        Return False
    '    End If

    '    If ComboBox1.Text = "Y" Then
    '        If Not IsDate(MyMaskedTextBox2.Text) Then
    '            GSubShowWarn(GFncGetSysMsg(68))
    '            MyMaskedTextBox2.Focus()
    '            Return False
    '        End If
    '    End If

    '    Return True
    'End Function

    'Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
    '    If IsDate(Me.DataGridView1.Rows(Me.DataGridView1.CurrentCell.RowIndex).Cells("valuedate").Value) Then
    '        Me.DataGridView1.Rows(Me.DataGridView1.CurrentCell.RowIndex).Cells("vdatestr").Value = Format(Me.DataGridView1.Rows(Me.DataGridView1.CurrentCell.RowIndex).Cells("valuedate").Value, "ddd  dd  MMM  yyyy")
    '    Else
    '        Me.DataGridView1.Rows(Me.DataGridView1.CurrentCell.RowIndex).Cells("vdatestr").Value = ""
    '    End If
    'End Sub

    'Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
    '    If IsDBNull(Me.DataGridView1.Rows(Me.DataGridView1.CurrentCell.RowIndex).Cells("valuedate").Value) Then
    '        If Me.DataGridView1.CurrentCell.RowIndex <> 0 Then
    '            Me.DataGridView1.Rows(Me.DataGridView1.CurrentCell.RowIndex).Cells("valuedate").Value = Me.DataGridView1.Rows(Me.DataGridView1.CurrentCell.RowIndex - 1).Cells("valuedate").Value
    '        Else
    '            Me.DataGridView1.Rows(0).Cells(1).Value = g_tdate
    '        End If
    '        Me.DataGridView1.Rows(Me.DataGridView1.CurrentCell.RowIndex).Cells("vdatestr").Value = Format(Me.DataGridView1.Rows(Me.DataGridView1.CurrentCell.RowIndex).Cells("valuedate").Value, "ddd  dd  MMM  yyyy")
    '    End If
    'End Sub

    'Private Sub DataGridView1_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellLeave
    '    If IsDBNull(Me.DataGridView1.Rows(Me.DataGridView1.CurrentCell.RowIndex).Cells("valuedate").Value) Then
    '        If Me.DataGridView1.CurrentCell.RowIndex <> 0 Then
    '            Me.DataGridView1.Rows(Me.DataGridView1.CurrentCell.RowIndex).Cells("valuedate").Value = Me.DataGridView1.Rows(Me.DataGridView1.CurrentCell.RowIndex - 1).Cells("valuedate").Value
    '        Else
    '            Me.DataGridView1.Rows(0).Cells(1).Value = g_tdate
    '        End If
    '        Me.DataGridView1.Rows(Me.DataGridView1.CurrentCell.RowIndex).Cells("vdatestr").Value = Format(Me.DataGridView1.Rows(Me.DataGridView1.CurrentCell.RowIndex).Cells("valuedate").Value, "ddd  dd  MMM  yyyy")
    '    End If

    'End Sub

    'Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
    '    GSubShowWarn(GFncGetSysMsg(68))
    '    Me.DataGridView1.Rows(Me.DataGridView1.CurrentCell.RowIndex).Cells("vdatestr").Value = ""
    'End Sub

    'Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
    '    If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Return Then
    '        If Me.DataGridView1.CurrentCell.RowIndex = Me.DataGridView1.Rows.Count - 1 Then
    '            If GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes Then
    '                Me.lsubStartProccess()
    '            End If
    '        End If
    '    End If
    'End Sub

    'Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged

    '    If Me.DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("currency").Selected = True Then
    '        Me.DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("valuedate").Selected = True
    '    End If
    '    If Me.DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("vdatestr").Selected = True Then
    '        Me.DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("valuedate").Selected = True
    '    End If
    'End Sub

    'Private Sub lsubStartProccess()
    '    Dim lstnTrans As SqlTransaction
    '    Dim lstrSQL As String = ""

    '    Dim lstrResult As String = data.GfncBackupDB()
    '    If lstrResult <> "OK" Then
    '        GSubShowInfo(GFncGetSysMsg(64))
    '        Return
    '    End If
    '    lstnTrans = GSCnSqlConn.BeginTransaction("DayBegin")
    '    Try
    '        Windows.Forms.Cursor.Current = Cursors.WaitCursor

    '        Dim ldtwCurrency As DataRow
    '        Dim ldtcCurrency As DataRowCollection
    '        ldtcCurrency = ldtscurr.Tables(0).Rows
    '        For Each ldtwCurrency In ldtcCurrency
    '            lstrSQL = "update currency set d_val_date = '" & Format(ldtwCurrency("d_vdate"), "yyyy/MM/dd") & "' " & _
    '                        " where d_currency = '" & Trim(ldtwCurrency("d_currency")) & "' "
    '            GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL)
    '        Next

    '        Dim ldtsDate As DataSet
    '        Dim ldtwDate As DataRow
    '        ldtsDate = data.GfncGetTDate(lstnTrans)
    '        ldtwDate = ldtsDate.Tables(0).Rows(0)
    '        If Not (Month(ldtwDate("D_L_TDATE")) = Month(g_tdate) And _
    '                             Year(ldtwDate("D_L_TDATE")) = Year(g_tdate)) Then
    '            lsubMonthEnd(lstnTrans, ldtwDate("D_L_TDATE"))
    '        End If

    '        lstrSQL = "update [date] set d_l_tdate = d_tdate "
    '        GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL)

    '        lstrSQL = "update [date] set d_l_int_cu = d_int_date, d_l_int_ca = d_tdate where d_int_date is not null "
    '        GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL)

    '        lstrSQL = "update [date] set d_day_nig = 'D', d_tdate = '" & Format(g_tdate, "yyyy/MM/dd") & "' "
    '        If Me.ComboBox1.Text = "Y" Then
    '            lstrSQL &= ", d_int_date = '" & Format(g_int_date, "yyyy/MM/dd") & "' "
    '        Else
    '            lstrSQL &= ", d_int_date = null "
    '        End If
    '        GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL)

    '        lstnTrans.Commit()
    '        Windows.Forms.Cursor.Current = Cursors.Default

    '    Catch ex As Exception
    '        lstnTrans.Rollback("DayBegin")
    '        Windows.Forms.Cursor.Current = Cursors.Default
    '        GSubWriteErrLog("clsDayBegin: " & ex.Message)
    '    End Try

    '    Me.DialogResult = Windows.Forms.DialogResult.OK
    '    Me.Close()
    'End Sub

    'Private Sub lsubMonthEnd(ByRef lstnTrans As SqlTransaction, ByVal ldteLDate As Date)
    '    Dim lstrSQL As String = ""

    '    lstrSQL = " delete from " & GStrMonthlyDB.Trim & ".dbo.m_account where d_bcode = '" & GStrBCode & "'  and " & _
    '                " d_month = '" & Format(g_tdate, "yyyyMM") & "' "
    '    GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL)
    '    lstrSQL = " delete from " & GStrMonthlyDB.Trim & ".dbo.m_sales where d_bcode = '" & GStrBCode & "'  and " & _
    '                        " d_month = '" & Format(g_tdate, "yyyyMM") & "' "
    '    GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL)

    '    lstrSQL = " INSERT INTO " & GStrMonthlyDB.Trim & ".dbo.M_ACCOUNT " & _
    '             " (D_BCODE ,D_MONTHEND_DATE,D_ANO,D_SNO,D_SGROUP,D_SNAME,D_3RD_PAR,D_ADDR1 " & _
    '             " ,D_ADDR2,D_ADDR3,D_ADDR4,D_HAND,D_PHONE,D_PHONE2,D_DATE_OP,D_MARG_IN,D_MARG_OUT " & _
    '             " ,D_PR_BAL,D_GOLD_IN,D_GOLD_OUT,D_G_PR_BAL,D_REMARK,D_BF_STO,D_BF_M_IN,D_BF_M_OUT " & _
    '             " ,D_BF_COMM,D_BF_BCOMM,D_BF_FCOMM,D_BF_INT,D_BF_BINT,D_BF_FINT,D_BF_PL,D_BF_BPL " & _
    '             " ,D_BF_FPL,D_ADJ_COMM,D_ADJ_INT,D_ADJ_STO,D_ADJ_PL,D_TRAN,D_STATUS,D_HALF " & _
    '             " ,D_OSTORAGE,D_STORAGE,D_OCOMM,D_OMAR,D_OPAIR,D_OCUT,D_OMMAR,D_FREE_M,D_FREE_L " & _
    '             " ,D_FREE_A,D_FREE_K,D_FREE_T,D_COM_NEW,D_COM_LIQ,D_DIS,D_PM_EQ,D_PM_BAL,D_PM_MARG " & _
    '             " ,D_PM_MAIN,D_PIN_NO,D_PIN_NO2,D_C_DATE,D_C_TIME,D_BF_EQ,D_AC_COL,D_AC_COL2 " & _
    '             " ,D_AC_CFLAG,D_AC_CREMK,D_BAD_DATE,D_BAD_IND,D_B0_DATE,D_B0_IND,D_B0_MARK " & _
    '             " ,D_BCHEQUE,D_CBF_PL,D_CBF_COMM,C_CBF_INT,D_STD_IND,D_AE,D_VISA,D_CHKD_INT " & _
    '             " ,D_DINT,D_ORDER,D_STAT_TYPE,D_SPLIT_ORD,D_ID_NO1,D_ID_CHKDIG1,D_PASS_NO1 " & _
    '             " ,D_ID_NO2,D_ID_CHKDIG2,D_PASS_NO2,D_DNAME2,D_ID_NO3,D_ID_CHKDIG3,D_PASS_NO3 " & _
    '             " ,D_SNAME3,D_HKG_NEW,D_HKG_LIQ,D_LLG_NEW,D_LLG_LIQ,D_LLS_NEW,D_LLS_LIQ " & _
    '             " ,D_ENABLE_COM,D_ID,D_CBASE,D_HKG_PMAR,D_LLG_PMAR,D_LLS_PMAR,D_ENABLE_MAR " & _
    '             " ,D_HKG_DMAR,D_LLG_DMAR,D_LLS_DMAR,D_HKG_NMAR,D_LLG_NMAR,D_LLS_NMAR,D_ENABLE_GOLD " & _
    '             " ,D_GOLD_PER,D_ENABLE_STO,D_STO_CHAR,D_INCLUDE_INT,D_ENABLE_HKG_INT,D_HKG_LINT " & _
    '             " ,D_HKG_SINT,D_ENABLE_LLS_INT,D_LLS_LINT,D_LLS_SINT,D_SHOW_N2,D_SHOW_N3 " & _
    '             " ,START_DATE,CLOSE_DATE,MONTHLY_FEE,FEE_TYPE,FEE_REMARK,D_BF_SF_FEE,D_ENABLE_O_COM " & _
    '             " ,D_LLG_O_NEW,D_LLG_O_LIQ,D_LLG_O_EXR,D_LLG_O_EXP,D_LLS_O_NEW,D_LLS_O_LIQ,D_LLS_O_EXR " & _
    '             " ,D_LLS_O_EXP,D_HKG_O_NEW,D_HKG_O_LIQ,D_HKG_O_EXR,D_HKG_O_EXP,D_CREDIT_DATE,D_CREDIT_LINE " & _
    '             " ,D_BF_P_IN,D_BF_P_OUT,D_BF_P_REC,D_BF_P_PAY,D_BF_O_COMM,D_BF_O_PL,D_CBF_O_COMM,D_CBF_O_PL " & _
    '             " ,D_ADJ_O_COMM,D_ADJ_O_PL,D_PM_O_MARG,D_PM_O_MAIN,D_PREV_BRCH,D_TRF_DATE,D_TEL_PIN " & _
    '             " ,D_BF_MCALL,D_TEL_ID,lstupdusr,lstupddte,D_ADJ_MAR_IN,D_ADJ_MAR_OUT,D_OWEMAR,D_MONTH) " & _
    '              " select '" & GStrBCode & "' as D_BCODE , '" & Format(ldteLDate, "yyyy/MM/dd") & "' as D_MONTHEND_DATE, " & _
    '               " D_ANO,D_SNO,D_SGROUP,D_SNAME,D_3RD_PAR,D_ADDR1 " & _
    '             " ,D_ADDR2,D_ADDR3,D_ADDR4,D_HAND,D_PHONE,D_PHONE2,D_DATE_OP,D_MARG_IN,D_MARG_OUT " & _
    '             " ,D_PR_BAL,D_GOLD_IN,D_GOLD_OUT,D_G_PR_BAL,D_REMARK,D_BF_STO,D_BF_M_IN,D_BF_M_OUT " & _
    '             " ,D_BF_COMM,D_BF_BCOMM,D_BF_FCOMM,D_BF_INT,D_BF_BINT,D_BF_FINT,D_BF_PL,D_BF_BPL " & _
    '             " ,D_BF_FPL,D_ADJ_COMM,D_ADJ_INT,D_ADJ_STO,D_ADJ_PL,D_TRAN,D_STATUS,D_HALF " & _
    '             " ,D_OSTORAGE,D_STORAGE,D_OCOMM,D_OMAR,D_OPAIR,D_OCUT,D_OMMAR,D_FREE_M,D_FREE_L " & _
    '             " ,D_FREE_A,D_FREE_K,D_FREE_T,D_COM_NEW,D_COM_LIQ,D_DIS,D_PM_EQ,D_PM_BAL,D_PM_MARG " & _
    '             " ,D_PM_MAIN,D_PIN_NO,D_PIN_NO2,D_C_DATE,D_C_TIME,D_BF_EQ,D_AC_COL,D_AC_COL2 " & _
    '             " ,D_AC_CFLAG,D_AC_CREMK,D_BAD_DATE,D_BAD_IND,D_B0_DATE,D_B0_IND,D_B0_MARK " & _
    '             " ,D_BCHEQUE,D_CBF_PL,D_CBF_COMM,C_CBF_INT,D_STD_IND,D_AE,D_VISA,D_CHKD_INT " & _
    '             " ,D_DINT,D_ORDER,D_STAT_TYPE,D_SPLIT_ORD,D_ID_NO1,D_ID_CHKDIG1,D_PASS_NO1 " & _
    '             " ,D_ID_NO2,D_ID_CHKDIG2,D_PASS_NO2,D_DNAME2,D_ID_NO3,D_ID_CHKDIG3,D_PASS_NO3 " & _
    '             " ,D_SNAME3,D_HKG_NEW,D_HKG_LIQ,D_LLG_NEW,D_LLG_LIQ,D_LLS_NEW,D_LLS_LIQ " & _
    '             " ,D_ENABLE_COM,D_ID,D_CBASE,D_HKG_PMAR,D_LLG_PMAR,D_LLS_PMAR,D_ENABLE_MAR " & _
    '             " ,D_HKG_DMAR,D_LLG_DMAR,D_LLS_DMAR,D_HKG_NMAR,D_LLG_NMAR,D_LLS_NMAR,D_ENABLE_GOLD " & _
    '             " ,D_GOLD_PER,D_ENABLE_STO,D_STO_CHAR,D_INCLUDE_INT,D_ENABLE_HKG_INT,D_HKG_LINT " & _
    '             " ,D_HKG_SINT,D_ENABLE_LLS_INT,D_LLS_LINT,D_LLS_SINT,D_SHOW_N2,D_SHOW_N3 " & _
    '             " ,START_DATE,CLOSE_DATE,MONTHLY_FEE,FEE_TYPE,FEE_REMARK,D_BF_SF_FEE,D_ENABLE_O_COM " & _
    '             " ,D_LLG_O_NEW,D_LLG_O_LIQ,D_LLG_O_EXR,D_LLG_O_EXP,D_LLS_O_NEW,D_LLS_O_LIQ,D_LLS_O_EXR " & _
    '             " ,D_LLS_O_EXP,D_HKG_O_NEW,D_HKG_O_LIQ,D_HKG_O_EXR,D_HKG_O_EXP,D_CREDIT_DATE,D_CREDIT_LINE " & _
    '             " ,D_BF_P_IN,D_BF_P_OUT,D_BF_P_REC,D_BF_P_PAY,D_BF_O_COMM,D_BF_O_PL,D_CBF_O_COMM,D_CBF_O_PL " & _
    '             " ,D_ADJ_O_COMM,D_ADJ_O_PL,D_PM_O_MARG,D_PM_O_MAIN,D_PREV_BRCH,D_TRF_DATE,D_TEL_PIN " & _
    '             " ,D_BF_MCALL,D_TEL_ID, '" & GStrloginID & "' as lstupdusr,getdate() as lstupddte, " & _
    '             " D_ADJ_MAR_IN,D_ADJ_MAR_OUT,D_OWEMAR, '" & Format(g_tdate, "yyyyMM") & "' as  D_MONTH from account "
    '    GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL)

    '    lstrSQL = " INSERT INTO " & GStrMonthlyDB.Trim & ".dbo.M_SALES " & _
    '                "(D_BCODE,D_MONTH" & _
    '                ",D_SNO,D_TITLE,D_SGROUP,D_SNAME,D_ADD1" & _
    '                ",D_ADD2,D_ADD3,D_ADD4,D_PHONE,D_REMARK " & _
    '                ",D_EMP_DATE,lstupdusr,lstupddte) " & _
    '                " select '" & GStrBCode & "' as D_BCODE , " & _
    '                " '" & Format(g_tdate, "yyyyMM") & "' as  D_MONTH " & _
    '                ",D_SNO,D_TITLE,D_SGROUP,D_SNAME,D_ADD1" & _
    '                ",D_ADD2,D_ADD3,D_ADD4,D_PHONE,D_REMARK " & _
    '                ",D_EMP_DATE, '" & GStrloginID & "' as lstupdusr,getdate() as lstupddte " & _
    '                " from sales "
    '    GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL)


    '    lstrSQL = "update account set  " & _
    '            " D_BF_STO   = 0, " & _
    '          " d_BF_M_IN  = 0, " & _
    '          " d_BF_M_OUT = 0, " & _
    '          " d_BF_COMM  = 0, " & _
    '          " d_BF_INT   = 0, " & _
    '          " d_BF_PL    = 0, " & _
    '          " d_BF_FCOMM = 0, " & _
    '          " d_BF_FINT  = 0, " & _
    '          " d_BF_FPL   = 0, " & _
    '          " d_BF_BCOMM = 0, " & _
    '          " d_BF_BINT  = 0, " & _
    '          " d_BF_BPL = 0"
    '    GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL)

    '    lstrSQL = "update accum set  " & _
    '            " D_M_PR_BAL = " & data.GfncGetTPRBalance(lstnTrans) & ", " & _
    '              " D_PL_US    = D_PL_HK , " & _
    '              " D_M_T_IN   = 0,        " & _
    '              " D_M_T_OUT  = 0,        " & _
    '              " D_PL_BUS   = D_PL_BHK, " & _
    '                " D_PL_FUS = D_PL_FHK " & _
    '                " where d_tdate in (select d_tdate from [date] ) "
    '    GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL)


    '    ' lstrSQL = " delete from accum where D_TDATE < '" & Format(DateAdd(DateInterval.Month, -31, g_tdate), "yyyy/MM/dd") & "' "
    '    ' GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL)
    '    'lstrSQL = " delete from margin where D_TDATE < '" & Format(DateAdd(DateInterval.Month, -180, g_tdate), "yyyy/MM/dd") & "' "
    '    'GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL)
    '    'lstrSQL = " delete from profit where D_TDATE < '" & Format(DateAdd(DateInterval.Month, -180, g_tdate), "yyyy/MM/dd") & "' "
    '    'GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL)

    'End Sub

    'Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
    '    If GSubShowYNConfirm(GFncGetSysMsg(70)) = Windows.Forms.DialogResult.Yes Then
    '        Me.TabControl1.SelectTab(0)
    '    End If
    'End Sub

    'Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    '    If GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes Then
    '        Me.lsubStartProccess()
    '    End If
    'End Sub

    'Private Sub MyMaskedTextBox1_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles MyMaskedTextBox1.MaskInputRejected

    'End Sub

    'Private Sub MyMaskedTextBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyMaskedTextBox1.Validating
    '    Dim lstrDate As String = lfncCheckDate(Me.MyMaskedTextBox1.Text)
    '    If lstrDate <> "" Then
    '        g_tdate = CDate(MyMaskedTextBox1.Text)
    '        Me.MyTextbox1.Text = "[ " & Format(g_tdate, "ddd  dd  MMM  yyyy") & " ]"
    '    Else
    '        e.Cancel = True
    '        GSubShowWarn(GFncGetSysMsg(68))
    '        Me.MyTextbox1.Text = "dd/mm/yyyy"
    '    End If
    'End Sub

    'Private Sub MyMaskedTextBox2_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles MyMaskedTextBox2.MaskInputRejected

    'End Sub

    'Private Sub MyMaskedTextBox2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyMaskedTextBox2.Validating
    '    Dim lstrDate As String = lfncCheckDate(Me.MyMaskedTextBox2.Text)
    '    If lstrDate <> "" Then
    '        g_int_date = CDate(MyMaskedTextBox2.Text)
    '        Me.MyTextbox2.Text = "[ " & Format(g_int_date, "ddd  dd  MMM  yyyy") & " ]"
    '    Else
    '        e.Cancel = True
    '        GSubShowWarn(GFncGetSysMsg(68))
    '        Me.MyTextbox2.Text = "dd/mm/yyyy"
    '    End If
    'End Sub
End Class

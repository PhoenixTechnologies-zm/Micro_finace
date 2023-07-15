Imports System.Data.SqlClient

Public Class frmAccessLoan
    Private clientClass As New clsClient
    Public Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtSearchAcctNumber.Clear()
        txtAcctName.Clear()
        txtAcctNumber.Clear()
        combLoanType.Enabled = False
        NumericUpDown1.Enabled = False
        txtAmountRequested.Enabled = False

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        clientClass.searchClient(txtSearchAcctNumber.Text.Trim)
        txtAcctName.Text = clientClass.Names
        txtAcctNumber.Text = clientClass.num
        clientClass.clientSearch2(txtSearchAcctNumber.Text, PictureBox3, PictureBox2)
    End Sub

    Private Sub frmAccessLoan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clientClass.callLoanName(combLoanType)
    End Sub

    Private Sub txtAcctName_TextChanged(sender As Object, e As EventArgs) Handles txtAcctName.TextChanged
        If txtAcctName.Text.Length > 0 Then
            txtAmountRequested.ReadOnly = False
            NumericUpDown1.Enabled = True
            combLoanType.Enabled = True
            btnReset.Enabled = True
            btnNext.Enabled = True
        Else
            txtAmountRequested.ResetText()
            txtAmountRequested.ReadOnly = True
            NumericUpDown1.Enabled = False
            combLoanType.Enabled = False
            btnReset.Enabled = False
            btnNext.Enabled = False
        End If
    End Sub

    Private Sub combLoanType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combLoanType.SelectedIndexChanged
        clientClass.loanVal(combLoanType)
        txtTaxName.Text = clientClass.taxName
        txtTax.Text = clientClass.taxValue
        txtInterestRate.Text = clientClass.RatesVal
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        ValidateAmt(txtAmountRequested)
        If err.GetError(txtAmountRequested).Length <> 0 Then
            err.SetError(txtAmountRequested, "input not numeric")
        Else

            'CONTINUE IF EVERYTHING GOES WELL
            CLIENTStillOwes(txtAcctNumber.Text.Trim)
            'If stillOwes = True Then
            '    Exit Sub
            'Else

            '    clientClass.CalcInterest(CDbl(txtInterestRate.Text), CDbl(txtTax.Text), CDbl(txtAmountRequested.Text), NumericUpDown1)
            '    txtMonthlyRepay.Text = MonthlyRepay
            '    Dim mess = MessageBox.Show("Continue", "Confirm - Ezee Micro finance", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK
            '    If mess Then

            '        frmGurantor.txtClientName.Text = txtAcctNumber.Text.Trim()
            '        frmGurantor.amtRequest = CDbl(txtAmountRequested.Text)
            '        frmGurantor.AcctNames = txtAcctName.Text.Trim
            '        frmGurantor.CombLoanTypes = combLoanType.SelectedItem
            '        frmGurantor.loInterestes = CDbl(txtInterestRate.Text)
            '        frmGurantor.taxNam = txtTaxName.Text
            '        frmGurantor.taxVals = CDbl(txtTax.Text)
            '        'frmGurantor.LoaDate = dtpLoanAccess.Value.Date.ToShortDateString
            '        'frmGurantor.Tim = dtpLoanAccess.Value.ToShortTimeString
            '        frmGurantor.durationn = dtpLoanAccess.Value.AddYears(NumericUpDown1.Value)

            '        frmGurantor.ShowDialog()
            '    End If

            'End If
        End If



    End Sub

    Private Sub txtMonthlyRepay_TextChanged(sender As Object, e As EventArgs) Handles txtMonthlyRepay.TextChanged

    End Sub

    Private Sub txtAmountRequested_TextChanged(sender As Object, e As EventArgs) Handles txtAmountRequested.TextChanged, txtAmountRequested.Leave
        ValidateAmt(DirectCast(sender, Control))
    End Sub


    'VALIDATE AMOUNT
    Private Sub ValidateAmt(ctrl As Control)
        Dim AmtInput As Double
        If (Double.TryParse(txtAmountRequested.Text, AmtInput) = False) Then
            err.SetIconAlignment(txtAmountRequested, ErrorIconAlignment.BottomLeft)
            err.SetError(txtAmountRequested, "input not numeric")
            Return
        Else
            err.SetError(txtAmountRequested, String.Empty)
        End If

    End Sub


    Public Sub CLIENTStillOwes(AcctNum As String)


        Dim dblAmt As Double
        Try
            dbconnection()

            Try
                sql = "SELECT currBalance FROM LoanBalance where AccNo = '" & AcctNum & "'"

                cmd = New SqlCommand(sql, con)
                reader = cmd.ExecuteReader()
                If reader.Read() Then


                    dblAmt = CDbl(reader("currBalance"))
                    Loops = 1
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            'IF CUSTOMER IS FOUND
            If Loops > 0 Then

                ' IF CUSTOMER STILL OWES
                If dblAmt > 0.0 Then
                    'stillOwes = True
                    MsgBox("Account number: " & AcctNum & ", Still owes " & "GH₵ " & dblAmt, MsgBoxStyle.Exclamation)
                    Return
                Else

                    clientClass.CalcInterest(CDbl(txtInterestRate.Text), CDbl(txtTax.Text), CDbl(txtAmountRequested.Text), NumericUpDown1)
                    txtMonthlyRepay.Text = MonthlyRepay
                    Dim mess = MessageBox.Show("Continue", "Confirm - Ezee Micro finance", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK
                    If mess Then

                        frmGurantor.txtClientName.Text = txtAcctNumber.Text.Trim()
                        frmGurantor.amtRequest = CDbl(txtAmountRequested.Text)
                        frmGurantor.AcctNames = txtAcctName.Text.Trim
                        frmGurantor.CombLoanTypes = combLoanType.SelectedItem
                        frmGurantor.loInterestes = CDbl(txtInterestRate.Text)
                        frmGurantor.taxNam = txtTaxName.Text
                        frmGurantor.taxVals = CDbl(txtTax.Text)
                        'frmGurantor.LoaDate = dtpLoanAccess.Value.Date.ToShortDateString
                        'frmGurantor.Tim = dtpLoanAccess.Value.ToShortTimeString
                        frmGurantor.durationn = dtpLoanAccess.Value.AddYears(NumericUpDown1.Value)

                        frmGurantor.ShowDialog()
                    End If



                End If
                'CLIENT NOT FOUND IN LOAN TABLE
            Else
                Dim num As Double
                Dim int As Integer
                dbconnection()

                Try
                    sql = "SELECT AccNo FROM acctBalance where AccNo = '" & AcctNum & "'"

                    cmd = New SqlCommand(sql, con)
                    reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        num = Double.Parse(reader("AccNo"))
                        int = 1
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try


                'CLIENT IS FOUNT IN ACCOUNT TABLE
                If int > 0 Then

                    clientClass.CalcInterest(CDbl(txtInterestRate.Text), CDbl(txtTax.Text), CDbl(txtAmountRequested.Text), NumericUpDown1)
                    txtMonthlyRepay.Text = MonthlyRepay
                    Dim mess = MessageBox.Show("Continue", "Confirm - Ezee Micro finance", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK
                    If mess Then

                        frmGurantor.txtClientName.Text = txtAcctNumber.Text.Trim()
                        frmGurantor.amtRequest = CDbl(txtAmountRequested.Text)
                        frmGurantor.AcctNames = txtAcctName.Text.Trim
                        frmGurantor.CombLoanTypes = combLoanType.SelectedItem
                        frmGurantor.loInterestes = CDbl(txtInterestRate.Text)
                        frmGurantor.taxNam = txtTaxName.Text
                        frmGurantor.taxVals = CDbl(txtTax.Text)
                        'frmGurantor.LoaDate = dtpLoanAccess.Value.Date.ToShortDateString
                        'frmGurantor.Tim = dtpLoanAccess.Value.ToShortTimeString
                        frmGurantor.durationn = dtpLoanAccess.Value.AddYears(NumericUpDown1.Value)

                        frmGurantor.ShowDialog()
                    End If

                Else


                End If

                

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try

    End Sub

End Class
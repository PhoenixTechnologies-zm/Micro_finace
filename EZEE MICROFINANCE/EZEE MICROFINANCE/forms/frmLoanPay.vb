
Imports System.Data.SqlClient
Public Class frmLoanPay
    Private SelectClass As New clsSelect
    Private clientclass As New clsClient
    Private insertClass As New clsInsert
    Public Uname As String
    Private Sub btnSettle_Click(sender As Object, e As EventArgs) Handles btnSettle.Click
        validatePayName(txtPaymentBy)
        validateContact(txtPaymentContact)
        validateAmt(txtAmount)
        With err
            If .GetError(txtPaymentBy).Length <> 0 Then
                .SetError(txtPaymentBy, "Please enter depositor name")
            ElseIf .GetError(txtPaymentContact).Length <> 0 Then
                .SetError(txtPaymentContact, "Please enter depositor contact number")
            ElseIf .GetError(txtAmount).Length <> 0 Then
                .SetError(txtAmount, "Please enter valid amount")
            Else
                deposite()
            End If
        End With
    End Sub

    'check balance
    Public Sub CheckLoanInDataBase(AccNum As String)

        Try
            dbconnection()
            sql = "SELECT * FROM  LoanBalance WHERE AccNo ='" & AccNum & "'"

            cmd = New SqlCommand(sql, con)

            reader = cmd.ExecuteReader
            'THE FOLLOWING VARIABLE IS HOLD TRUE IF USER FOUND, AND FALSE IF USER IS NOT FOUND
            Dim custFound As Boolean = False
            'THE FOLLOWING VARIABLE WILL HOLD THE USER FIRSTNAME AND LASTNAME IF FOUND
            Dim loanAmt As Double = Nothing


            'IF FOUND
            While reader.Read
                custFound = True
                loanAmt = CType(reader("currBalance"), Double)

            End While

            'CHECKING THE RESULT
            If (custFound = True) Then
                txtAmtOwe.Text = String.Format("{0:n3}", loanAmt)

                If txtAmtOwe.Text = 0 Then
                    'CHECK IF CUSTOMER OWES NOTHING IF TRUE ALERT AND CLOSE CONNECTION
                    MsgBox(txtAcctName.Text & " has fully pay the loan", MsgBoxStyle.Information)
                    Exit Sub

                    'IF CUSTOMER OWES CONTINUE WITH THE TRANSACTION
                Else
                    'SUBSTRACT THE AMOUNT PAID FROM THE AMOUNT
                    'AND ASSIGN THE RESULT TO THE BALANCE

                    txtBalace.Text = String.Format("{0:n3}", CType(txtAmtOwe.Text, Double) - CType(txtAmount.Text, Double))
                    Dim CustChange As Decimal = Math.Abs(CDec(txtBalace.Text))
                    If CDbl(txtBalace.Text) < 0.0 Then
                        txtBalace.Text = 0
                        If (MessageBox.Show("Do you want to continue with the transaction" & Environment.NewLine & "Change of : " & "GH₵ " & CustChange, "CONFIRM TRANSACTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                            Call UpdateBalance()
                            Call UpdateGuarantorBalance()
                            clientclass.LoanTransaction(txtreceipt.Text.Trim, txtAcctNum.Text.Trim, txtAcctName.Text.Trim, DateTimePicker1.Value, DateTimePicker1, txtAmount.Text - CustChange, txtPaymentBy.Text, txtPaymentContact.Text, Uname)
                            insertClass.Loanreceipt(LoanReceiptCode)
                            PrintDocument1.Print()
                            clearAll()

                        End If

                    ElseIf CDbl(txtBalace.Text >= 0) Then
                        If (MessageBox.Show("Do you want to continue with the transaction", "CONFIRM TRANSACTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                            Call UpdateBalance()
                            Call UpdateGuarantorBalance()
                            clientclass.LoanTransaction(txtreceipt.Text.Trim, txtAcctNum.Text.Trim, txtAcctName.Text.Trim, DateTimePicker1.Value, DateTimePicker1, txtAmount.Text, txtPaymentBy.Text, txtPaymentContact.Text, Uname)
                            insertClass.Loanreceipt(LoanReceiptCode)
                            PrintDocument1.Print()
                        End If

                    End If

                End If

            Else
                MsgBox("Sorry, account name or account number not found", MsgBoxStyle.Exclamation, "UNKNOWN CUSTOMER")
                Return
            End If

        Catch ex As Exception
            MsgBox(" Checkloan" & ex.Message)
            Return
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub deposite()
        Call CheckLoanInDataBase(txtAcctNum.Text.Trim)
    End Sub


    'UPdate Balance
    Private Sub UpdateBalance()
        Dim UpLoanstr As String
        Try

            dbconnection()
            UpLoanstr = "update LoanBalance set currBalance = '" & CType(txtBalace.Text, Double) & "' where AccNo = '" & txtAcctNum.Text & "'"
            cmd = New SqlCommand(UpLoanstr, con)
            Try
                cmd.ExecuteNonQuery()

                MsgBox("Payment updated successfully", MsgBoxStyle.Information)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                cmd.Dispose()
                con.Close()
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    ' UPDATE CLIENT LOAN IN GUARANTOR TABLE
    'UPdate Balance
    Private Sub UpdateGuarantorBalance()
        Dim UpLoanstr As String
        Try

            dbconnection()
            UpLoanstr = "update Gurantor set amt = '" & CType(txtBalace.Text, Double) & "' where AccNo = '" & txtAcctNum.Text & "'"
            cmd = New SqlCommand(UpLoanstr, con)
            Try
                cmd.ExecuteNonQuery()

                MsgBox(" guarantor Payment updated successfully", MsgBoxStyle.Information)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                cmd.Dispose()
                con.Close()
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub








    'PRINT RECEIPT
    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim pFont As Font
        Dim Mydate As New DateTime
        Dim StartXpos As Integer = 0
        Dim StartYpos As Integer = 0
        Dim offset As Integer = 40

        Mydate = Date.Now()
        pFont = New Font("Comic Sans MS", 9)
        e.Graphics.DrawString("EZEE MICROFINANCE" & Environment.NewLine, pFont, Brushes.Black, StartXpos, StartYpos)
        e.Graphics.DrawString("P.O.BOX 1 EAST-LEGON" & Environment.NewLine, New Font("Comic Sans MS", 9), Brushes.Black, 0, 30)
        e.Graphics.DrawString(Mydate.ToString("F") & Environment.NewLine, New Font("Comic Sans MS", 9), Brushes.Black, 0, 50)

        e.Graphics.DrawString("Depositor Name: " & txtPaymentBy.Text.PadRight(30) & Environment.NewLine, New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 70 + offset)
        e.Graphics.DrawString("Depositor Contact  : " & txtPaymentContact.Text.PadRight(30) & Environment.NewLine, New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 90 + offset)

        e.Graphics.DrawString("AccountName  : " & txtAcctName.Text.PadRight(30) & Environment.NewLine, New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 110 + offset)

        e.Graphics.DrawString("AccountNumber : " & txtAcctNum.Text.PadRight(30) & Environment.NewLine, New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 130 + offset)

        e.Graphics.DrawString("Amount Owed  : " & txtAmtOwe.Text, New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 150 + offset)

        e.Graphics.DrawString("Amount Payed : " & txtAmount.Text.PadRight(30) & Environment.NewLine, New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 170 + offset)

        e.Graphics.DrawString("Outstanding Balance : " & txtBalace.Text.PadRight(30) & Environment.NewLine, New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 190 + offset)
        e.Graphics.DrawString("Thank you for your visit. You were served by " & Uname & Environment.NewLine, New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 210 + offset)

    End Sub

    Private Sub frmLoanPay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clearAll()


    End Sub

    Private Sub clearAll()
        txtreceipt.Text = "Lnum-" & SelectClass.getLoanReceipt()
    End Sub

    Private Sub txtPaymentContact_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPaymentContact.KeyPress
        If Not IsNumeric(e.KeyChar) AndAlso
          e.KeyChar <> ControlChars.Back AndAlso
          e.KeyChar <> Chr(Keys.Delete) Then
            e.Handled = True

        ElseIf e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub


    ' Contact
    Private Sub validateContact(ctrl As Control)
        If txtPaymentContact.Text.Trim.Length >= 10 Then
            err.SetError(txtPaymentContact, String.Empty)
        Else
            err.SetIconAlignment(txtPaymentContact, ErrorIconAlignment.BottomLeft)
            err.SetError(txtPaymentContact, "Please enter depositor contact number")
            txtPaymentContact.Focus()
        End If
    End Sub

    'Payment BY
    Private Sub validatePayName(ctrl As Control)
        If txtPaymentBy.Text.Trim = "" Then
            err.SetIconAlignment(txtPaymentBy, ErrorIconAlignment.BottomLeft)
            err.SetError(txtPaymentBy, "Please enter depositor name")
            txtPaymentBy.Focus()
        Else
            err.SetError(txtPaymentBy, String.Empty)
        End If

    End Sub


    Private Sub validateAmt(ctrl As Control)
        Dim pay As Double
        If Double.TryParse(txtAmount.Text, pay) Then
            err.SetError(txtAmount, String.Empty)
        Else
            err.SetIconAlignment(txtAmount, ErrorIconAlignment.BottomLeft)
            err.SetError(txtAmount, "Please enter valid amount")
            txtAmount.Focus()
        End If

    End Sub

    Private Sub txtPaymentContact_TextChanged(sender As Object, e As EventArgs) Handles txtPaymentContact.TextChanged, txtPaymentContact.Leave
        validateContact(DirectCast(sender, Control))
    End Sub

    Private Sub txtPaymentBy_TextChanged(sender As Object, e As EventArgs) Handles txtPaymentBy.TextChanged, txtPaymentBy.Leave
        validatePayName(DirectCast(sender, Control))
    End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged, txtAmount.Leave
        validateAmt(DirectCast(sender, Control))
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If txtAcctNum.Text.Trim.Length > 0 Then
            If CheckBox1.Checked = True Then
                SelectClass.SubAcctName(txtAcctNum.Text)
                txtAcctName.Text = SelectClass.getAcctName

            End If
        End If
    End Sub
End Class
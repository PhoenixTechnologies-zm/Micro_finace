
Imports System.Data.SqlClient
Public Class frmTransactions
    Private insertClass As New clsInsert
    Private SelectClass As New clsSelect
    Private Sub btnSettle_Click(sender As Object, e As EventArgs) Handles btnSettle.Click
        ValAcctname(txtAccountName)
        ValAmt(txtdepositeOrwithdraw)
        ValDepositor(txtDepositorName)
        ValdepositorContact(txtDepositorContact)
        With err
            If .GetError(txtAccountName).Length <> 0 Then
                .SetIconAlignment(txtAccountName, ErrorIconAlignment.MiddleLeft)
                .SetError(txtAccountName, "Please enter a value")
            ElseIf (.GetError(txtdepositeOrwithdraw).Length <> 0) Then
                .SetIconAlignment(txtdepositeOrwithdraw, ErrorIconAlignment.MiddleLeft)
                .SetError(txtdepositeOrwithdraw, "Please enter number")
            ElseIf (.GetError(txtDepositorName).Length <> 0) Then
                .SetIconAlignment(txtDepositorName, ErrorIconAlignment.MiddleLeft)
                .SetError(txtDepositorName, "Please enter value")
            ElseIf (.GetError(txtDepositorContact).Length <> 0) Then
                .SetIconAlignment(txtDepositorContact, ErrorIconAlignment.BottomLeft)
                .SetError(txtDepositorContact, "Please enter contact")
            Else

                CheckAccountInNoneLoanTables(txtAccountName.Text, txtAccountNumber.Text)
            End If
        End With



    End Sub

    'CHECK ACCOUNT
    Public Sub CheckAccountInNoneLoanTables(accountName As String, accountNum As String)

        'THE FOLLOWING VARIABLE IS HOLD TRUE IF USER FOUND, AND FALSE IF USER IS NOT FOUND
        Dim custFound As Boolean = False
        Dim AmountHad As Double = Nothing

        Try
            dbconnection()
            Dim sql As String = "SELECT * FROM acctBalance WHERE AccNo ='" & accountNum & "'AND AccName = '" & accountName & "'"
            cmd = New SqlCommand(sql, con)
            reader = cmd.ExecuteReader

            'THE FOLLOWING VARIABLE WILL HOLD THE CUSTOMER  IF FOUND

            'IF FOUND
            While reader.Read
                custFound = True
                'GET AMOUNT IN TABLE
                AmountHad = CType(reader("OutBalance"), Double)
            End While

            'CUSTOMER IS FOUND
            If (custFound = True) Then
                MsgBox("Client found")
                'STORE THE VALUE IN THE AMOUNT-HAD-TEXTBOX
                txtBalance.Text = 0
                txtAmountHad.Text = String.Format("{0:n3}", AmountHad)

                If combTransMode.SelectedIndex = 0 Then
                    'IF DEPOSITE
                    txtBalance.Text = CType(txtAmountHad.Text, Double) + CType(txtdepositeOrwithdraw.Text, Double)

                    updateNoneLoanTables(txtAccountName.Text, txtAccountNumber.Text, CDbl(txtBalance.Text))
                   
                End If
                'IF CUSTOMER NOT FOUND
            Else
                MsgBox("Invalid Account name or account number", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox("Check Account" & ex.Message)
            Return
        Finally
            con.Close()
        End Try

    End Sub


    'PERFORM WITHDRAWAL OR DEPOSITE
    Private Sub updateNoneLoanTables(AcctName As String, AcctNumber As String, AmountStored As Double)

        'HAVE A LOOK AT YOUR BALANCE
        'THEN CONTINUE

        If MsgBox("Carry on with the Transaction", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            'for daily deposit transaction
            Call Deposites(txtReceipt.Text, txtAccountNumber.Text, txtAccountName.Text, txtDepositorName.Text, txtDepositorContact.Text, dtpTransactionDate.Value.Date, dtpTransactionDate, txtdepositeOrwithdraw.Text, combTransMode.SelectedItem, txtBalance.Text, frmMain.yourName.Text.Trim)
            insertClass.Nonereceipt(ReceiptCode)
            PrintDocument1.Print()
            Call clearAll()

            Try
                dbconnection()
                Dim UpdatesNoneLoanTables As String = "UPDATE acctBalance SET OutBalance = '" & AmountStored & "' WHERE AccName = '" & AcctName & "'AND AccNo = '" & AcctNumber & "'"
                cmd = New SqlCommand(UpdatesNoneLoanTables, con)
                cmd.ExecuteNonQuery()
                MsgBox("Update deposit made successfully", MsgBoxStyle.Information)
            Catch ex As Exception
                MsgBox("Update " & ex.ToString)
            Finally
                Connection_Close()
            End Try
        End If

    End Sub



    'PERFORM INSERTION INTO DAILY TRANSACTION
    Public Sub Deposites(ReceiptNo As String, AccNo As String, AccName As String, WDName As String, WDContact As String, TransDate As Date, TransTime As DateTimePicker, Amts As Double, TransType As String, AmtBalance As Double, TransBy As String)
        Try
            dbconnection()
            sql = "INSERT INTO  DailyTransaction(ReceiptNo, AccNo, AccName, WDName, WDContact, TransDate, TransTime, Amts, TransType,AmtBalance, TransBy) VALUES(@ReceiptNo,@AccNo,@AccName,@WDName,@WDContact,@TransDate,@TransTime,@Amts,@TransType,@AmtBalance,@TransBy)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@ReceiptNo", ReceiptNo.Trim)
            cmd.Parameters.AddWithValue("@AccNo", AccNo.Trim)

            cmd.Parameters.AddWithValue("@AccName", AccName.Trim)
            cmd.Parameters.AddWithValue("@WDName", WDName.Trim)
            cmd.Parameters.AddWithValue("@WDContact", WDContact.Trim)
            cmd.Parameters.AddWithValue("@TransDate", TransDate.Date)
            cmd.Parameters.AddWithValue("@TransTime", TransTime.Value.ToShortTimeString)
            cmd.Parameters.AddWithValue("@Amts", Amts)
            cmd.Parameters.AddWithValue("@TransType", TransType)
            cmd.Parameters.AddWithValue("@AmtBalance", AmtBalance)
            cmd.Parameters.AddWithValue("@TransBy", TransBy.Trim)

            cmd.ExecuteNonQuery()
            MsgBox("Transaction sucessfully taken", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox("Deposite " & ex.ToString)
        Finally
            Connection_Close()
        End Try

    End Sub


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

        e.Graphics.DrawString("Transaction By  : " & txtDepositorName.Text.PadRight(30) & Environment.NewLine, New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 70 + offset)

        e.Graphics.DrawString("Contact : " & txtDepositorContact.Text.PadRight(30) & Environment.NewLine, New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 90 + offset)

        e.Graphics.DrawString("AccountName  : " & txtAccountName.Text.PadRight(30) & Environment.NewLine, New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 110 + offset)

        e.Graphics.DrawString("AccountNumber : " & txtAccountNumber.Text.PadRight(30) & Environment.NewLine, New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 130 + offset)

        e.Graphics.DrawString("Transactional Type  : " & combTransMode.SelectedItem.ToString(), New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 150 + offset)

        e.Graphics.DrawString("Amount  : " & "GH₵ " & txtdepositeOrwithdraw.Text.PadRight(30) & Environment.NewLine, New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 170 + offset)

        e.Graphics.DrawString("Balance  : " & "GH₵ " & txtBalance.Text.PadRight(30) & Environment.NewLine, New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 190 + offset)
        e.Graphics.DrawString("Thank you for your visit. You were served by " & "empcode" & Environment.NewLine, New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 210 + offset)



    End Sub

    Private Sub frmTransactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clearAll()
    End Sub

    Private Sub clearAll()
        txtAccountName.ResetText()
        txtAccountNumber.ResetText()
        txtdepositeOrwithdraw.ResetText()
        txtAmountHad.ResetText()
        txtBalance.ResetText()
        dtpTransactionDate.Value = Today
        combTransMode.SelectedIndex = 0
        txtReceipt.Text = "NL-" & SelectClass.getNoneReceipt()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If txtAccountNumber.Text.Trim.Length > 0 Then
            If CheckBox1.Checked = True Then
                SelectClass.getAcctHolder(txtAccountNumber.Text)
                txtAccountName.Text = HolderName

            End If
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Public Sub updatesTransaction(AcctName As String, AcctNumber As String, AmountStored As Double)
       
        'HAVE A LOOK AT YOUR BALANCE
        'THEN CONTINUE

            Try
                dbconnection()
                Dim UpdatesNoneLoanTables As String = "UPDATE acctBalance SET OutBalance = '" & AmountStored & "' WHERE AccName = '" & AcctName & "'AND AccNo = '" & AcctNumber & "'"
                cmd = New SqlCommand(UpdatesNoneLoanTables, con)
                cmd.ExecuteNonQuery()
                MsgBox("Update deposit made successfully", MsgBoxStyle.Information)
            Catch ex As Exception
                MsgBox("Update " & ex.ToString)
            Finally
                Connection_Close()
            End Try


    End Sub

    Private Sub combTransMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combTransMode.SelectedIndexChanged

    End Sub



    Private Sub ValDepositor(ctrl As Control)
        If txtDepositorName.Text.Trim.Length > 0 Then
            err.SetError(txtDepositorName, String.Empty)
        Else
            err.SetIconAlignment(txtDepositorName, ErrorIconAlignment.MiddleLeft)
            err.SetError(txtDepositorName, "Please enter value")

        End If
    End Sub

    Private Sub ValdepositorContact(ctrl As Control)
        If txtDepositorContact.Text.Trim.Length >= 10 Then
            err.SetError(txtDepositorContact, String.Empty)
        Else
            err.SetIconAlignment(txtDepositorContact, ErrorIconAlignment.BottomLeft)
            err.SetError(txtDepositorContact, "Please enter contact")

        End If
    End Sub


    Private Sub ValAcctname(ctrl As Control)
        If txtAccountName.Text.Trim.Length > 0 Then
            err.SetError(txtAccountName, String.Empty)
        Else
            err.SetIconAlignment(txtAccountName, ErrorIconAlignment.MiddleLeft)
            err.SetError(txtAccountName, "Please enter a value")
            Return
        End If
    End Sub

    Private Sub ValAmt(ctrl As Control)
        Dim amt As Double
        If (Double.TryParse(txtdepositeOrwithdraw.Text, amt) = False) Then
            err.SetIconAlignment(txtdepositeOrwithdraw, ErrorIconAlignment.MiddleLeft)
            err.SetError(txtdepositeOrwithdraw, "Please enter number")
        Else
            err.SetError(txtdepositeOrwithdraw, String.Empty)
        End If
    End Sub

    Private Sub txtDepositorName_TextChanged(sender As Object, e As EventArgs) Handles txtDepositorName.TextChanged, txtDepositorName.Leave
        ValDepositor(DirectCast(sender, Control))
    End Sub

    Private Sub txtDepositorContact_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDepositorContact.KeyPress
        If Not IsNumeric(e.KeyChar) AndAlso
            e.KeyChar <> ControlChars.Back AndAlso
            e.KeyChar <> Chr(Keys.Delete) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDepositorContact_TextChanged(sender As Object, e As EventArgs) Handles txtDepositorContact.TextChanged, txtDepositorContact.Leave
        ValdepositorContact(DirectCast(sender, Control))
    End Sub

    Private Sub txtAccountName_TextChanged(sender As Object, e As EventArgs) Handles txtAccountName.TextChanged, txtAccountName.Leave
        ValAcctname(DirectCast(sender, Control))
    End Sub

    Private Sub txtAccountNumber_TextChanged(sender As Object, e As EventArgs) Handles txtAccountNumber.TextChanged

    End Sub

    Private Sub txtdepositeOrwithdraw_TextChanged(sender As Object, e As EventArgs) Handles txtdepositeOrwithdraw.TextChanged, txtdepositeOrwithdraw.Leave
        ValAmt(DirectCast(sender, Control))
    End Sub
End Class
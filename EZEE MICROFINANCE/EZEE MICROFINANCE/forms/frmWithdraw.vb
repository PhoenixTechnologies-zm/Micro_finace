Imports System.Data.SqlClient
Public Class frmWithdraw

    Private err As New ErrorProvider
    Private clientClass As New clsClient
    Private insertClass As New clsInsert
    Private receipt As String = ""
    Private SelectClass As New clsSelect
    Public withdrawDateTime As New DateTimePicker
    Public getUname As String
    'IF WITHDRAW
    Dim Balance As Double = 0
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not IsNumeric(e.KeyChar) AndAlso
            e.KeyChar <> ControlChars.Back AndAlso
            e.KeyChar <> Chr(Keys.Delete) Then
            e.Handled = True
            MsgBox(e.KeyChar & " is not numeric", MsgBoxStyle.Exclamation)
        ElseIf e.KeyChar = "." Then
            e.Handled = True
            MsgBox(e.KeyChar & " is not numeric", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        validateAcctNum(DirectCast(sender, Control))
        If TextBox1.Text.Trim.Length = 10 Then
            Call searchFromClient(TextBox1.Text.Trim)
            ' txtAcctName.Text = clientClass.Names
            clientClass.clientSearch2(TextBox1.Text.Trim, PictureBox1, PictureBox2)
        End If
    End Sub

    'SELECT CLIENT BY WAY OF FILTER
    Public Sub searchFromClient(acct As String)
        Try
            'open connection
            dbconnection()
            sql = "SELECT AccName from AcctDetails WHERE AccNo = '" & acct & "'"
            cmd = New SqlCommand(sql, con)
            reader = cmd.ExecuteReader()

            If reader.Read Then
                txtAcctName.Text = reader("AccName")

            Else
                txtAcctName.Text = ""

                MsgBox("Unknown Account number!", MsgBoxStyle.Exclamation)

            End If

        Catch ex As Exception
            MsgBox(ex.Message & Environment.NewLine & "Please contact the developer")

        Finally
            Connection_Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub txtAmt_TextChanged(sender As Object, e As EventArgs) Handles txtAmt.TextChanged, txtAmt.Leave
        validateAmt(DirectCast(sender, Control))

    End Sub

    Private Sub txtAcctName_TextChanged(sender As Object, e As EventArgs) Handles txtAcctName.TextChanged
        If txtAcctName.Text = Nothing Then
            txtAmt.Clear()
            txtAmt.ReadOnly = True
        Else
            txtAmt.ReadOnly = False

        End If
    End Sub

    Private Sub txtWithdrawer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtWithdrawer.KeyPress

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        validateAmt(txtAmt)
        validateAcctNum(TextBox1)
        validatePerson(txtWithdrawer)
        validatePhone(txtPhone)
        If err.GetError(TextBox1).Length <> 0 Then
            err.SetError(TextBox1, "Account number must be 10 digits long")
            Return
        ElseIf err.GetError(txtAmt).Length <> 0 Then
            err.SetError(txtAmt, "Input not a number")
            Return
        ElseIf err.GetError(txtWithdrawer).Length <> 0 Then
            err.SetError(txtWithdrawer, "please field can't be empty")
            Return
        ElseIf err.GetError(txtPhone).Length <> 0 Then
            err.SetError(txtPhone, "Please field can't be empty")
            Return
        End If
        CheckAccountInNoneLoanTables(txtAcctName.Text, TextBox1.Text)
    End Sub

    Private Sub CheckAccountInNoneLoanTables(accountName As String, accountNum As String)

        'THE FOLLOWING VARIABLE IS HOLD TRUE IF USER FOUND, AND FALSE IF USER IS NOT FOUND
        Dim custFound As Boolean = False
        Dim AmountHad As Double = Nothing

        Try
            dbconnection()
            Dim sql As String = "SELECT* FROM acctBalance WHERE AccNo ='" & accountNum & "'AND AccName = '" & accountName & "'"
            cmd = New SqlCommand(sql, con)
            reader = cmd.ExecuteReader

            'THE FOLLOWING VARIABLE WILL HOLD THE CUSTOMER  IF FOUND

            'IF FOUND
            While reader.Read
                custFound = True
                'GET AMOUNT IN TABLE
                AmountHad = CType(reader("OutBalance"), Double)
            End While


            'IF AMOUNT WITHDRAW IS GREATER THAN 
            'WHAT IS STORED
            'REJECT
            If CType(txtAmt.Text, Double) > CType(AmountHad, Double) Then
                MsgBox("Sorry your deposit is less than what you are withdrawing", MsgBoxStyle.Exclamation)
                Exit Sub
                ' IF AMOUNT WITHDRAW IS LESS THAN
                'AMOUNT STORED
            Else
                'IF WITHDRAW
                Balance = CType(AmountHad, Double) - CType(txtAmt.Text, Double)

                receipt = "NL-" & SelectClass.getNoneReceipt()

                updateNoneLoanTables(txtAcctName.Text, TextBox1.Text.Trim, CDbl(Balance))
                insertClass.Nonereceipt(ReceiptCode)
                MsgBox("Receipt Number " & receipt)
                PrintDocument1.Print()
                Call clearAll()

            End If
        Catch ex As Exception
            MsgBox("Check Account number" & ex.Message)
            Return
        Finally
            Connection_Close()
        End Try

    End Sub


    'PERFORM WITHDRAWAL 
    Private Sub updateNoneLoanTables(AcctName As String, AcctNumber As String, AmountStored As Double)

        'HAVE A LOOK AT YOUR BALANCE
        'THEN CONTINUE

        If MsgBox("Carry on with the Transaction", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            'for daily deposit transaction

            Try
                dbconnection()
                Dim UpdatesNoneLoanTables As String = "UPDATE acctBalance SET OutBalance = '" & Balance & "' WHERE AccName = '" & AcctName & "'AND AccNo = '" & AcctNumber & "'"
                cmd = New SqlCommand(UpdatesNoneLoanTables, con)
                cmd.ExecuteNonQuery()

                Call insertClass.Deposites(receipt, TextBox1.Text, txtAcctName.Text, txtWithdrawer.Text.Trim, txtPhone.Text.Trim, DateTimePicker1, DateTimePicker1, txtAmt.Text, "Withdraw", Balance, frmMain.yourName.Text.Trim)

                '  MsgBox("Update deposit made successfully", MsgBoxStyle.Information)
            Catch ex As Exception
                MsgBox("Update " & ex.ToString)
            Finally
                Connection_Close()
            End Try
        End If

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

        e.Graphics.DrawString("receipt  : " & "NL-" & receipt & Environment.NewLine, New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 70 + offset)

        e.Graphics.DrawString("Transaction By  : " & txtWithdrawer.Text.PadRight(30) & Environment.NewLine, New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 90 + offset)

        e.Graphics.DrawString("Contact : " & txtPhone.Text.PadRight(30) & Environment.NewLine, New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 110 + offset)

        e.Graphics.DrawString("AccountName  : " & txtAcctName.Text.PadRight(30) & Environment.NewLine, New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 130 + offset)

        e.Graphics.DrawString("AccountNumber : " & TextBox1.Text.PadRight(30) & Environment.NewLine, New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 150 + offset)

        e.Graphics.DrawString("Transactional Type  : " & "Withdraw", New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 170 + offset)

        e.Graphics.DrawString("Amount  : " & "GH₵ " & txtAmt.Text.PadRight(30) & Environment.NewLine, New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 190 + offset)

        e.Graphics.DrawString("Balance  : " & "GH₵ " & Balance.ToString.PadRight(30) & Environment.NewLine, New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 210 + offset)
        e.Graphics.DrawString("Thank you for your visit. You were served by " & frmMain.yourName.Text & Environment.NewLine, New Font("Comic Sans MS", 9), New SolidBrush(Color.Black), 0, 230 + offset)

    End Sub

    Private Sub txtPhone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhone.KeyPress
        If Not IsNumeric(e.KeyChar) AndAlso
         e.KeyChar <> ControlChars.Back AndAlso
         e.KeyChar <> Chr(Keys.Delete) Then
            e.Handled = True
            MsgBox(e.KeyChar & " is not numeric", MsgBoxStyle.Exclamation)
        ElseIf e.KeyChar = "." Then
            e.Handled = True
            MsgBox(e.KeyChar & " is not numeric", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub frmWithdraw_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub validateAmt(ctrl As Control)

        If Not txtAmt.Text.Trim.Length > 0 Or Not IsNumeric(txtAmt.Text) Then
            err.SetIconAlignment(txtAmt, ErrorIconAlignment.MiddleLeft)
            err.SetError(txtAmt, "Input not a number")
            Return
        Else
            err.SetError(txtAmt, String.Empty)
        End If
      
    End Sub

    Private Sub validateAcctNum(ctrl As Control)
        If Not TextBox1.Text.Trim.Length > 9 Then
            err.SetIconAlignment(TextBox1, ErrorIconAlignment.MiddleLeft)
            err.SetError(TextBox1, "Account number must be 10 digits long")
            Return
        Else
            err.SetError(TextBox1, String.Empty)
        End If
    End Sub

    Private Sub validatePerson(ctrl As Control)
        If txtWithdrawer.Text.Trim.Length > 0 Then
            err.SetError(txtWithdrawer, String.Empty)
        Else
            err.SetIconAlignment(txtWithdrawer, ErrorIconAlignment.MiddleLeft)
            err.SetError(txtWithdrawer, "Please field can't be empty")
            Return
        End If
    End Sub


    Private Sub validatePhone(ctrl As Control)
        If Not txtPhone.Text.Trim.Length = 10 Then
            err.SetIconAlignment(txtPhone, ErrorIconAlignment.MiddleLeft)
            err.SetError(txtPhone, "Please field can't be empty")
            Return
        Else
            err.SetError(txtPhone, String.Empty)
        End If
    End Sub


    Private Sub clearAll()
        TextBox1.Clear()
        txtAcctName.Clear()
        txtWithdrawer.Clear()
        txtPhone.Clear()
        txtAmt.Clear()
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        validateAcctNum(DirectCast(sender, Control))
    End Sub

    Private Sub txtPhone_TextChanged(sender As Object, e As EventArgs) Handles txtPhone.TextChanged, txtPhone.Leave
        validatePhone(DirectCast(sender, Control))
    End Sub

    Private Sub txtWithdrawer_TextChanged(sender As Object, e As EventArgs) Handles txtWithdrawer.TextChanged, txtWithdrawer.Leave
        validatePerson(DirectCast(sender, Control))
    End Sub
End Class

Imports System.Data.SqlClient
Imports System.IO
Public Class frmGurantor
    Private SelectClass As New clsSelect
    Private insertClass As New clsInsert
    Private gurantorClass As New clsGurantor
    Private clientClass As New clsClient
    Private recpt As String
    Public EmpName As String


    'VALUES WAS UNABLE TO GET FROM GLOBAL SCOPE
    'SO WE WILL USE THIS VARIABLES TO PULL THEM
    Public amtRequest As Double
    Public AcctNames As String
    Public CombLoanTypes As String
    Public loInterestes As Double
    Public taxNam As String
    Public taxVals As Double
    Public LoaDate As New DateTimePicker
    Public Tim As New DateTime
    Public durationn As Date


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        LoaDate.Value = Now.Date
        Tim = Now.ToShortTimeString
        validateFname(txtGFirstname)
        validateLname(txtGLastname)
        validateDOB(DateTimePicker1)
        validatephone(txtPhone)
        validateOccupation(txtOccupation)
        validateWorkplace(txtWorkPlace)
        validateResidence(txtResidenceAddress)



        With err
            If .GetError(txtGFirstname).Length <> 0 Then
                .SetError(txtGFirstname, "Please enter first name")
            ElseIf .GetError(txtGLastname).Length <> 0 Then
                .SetError(txtGLastname, "Please enter last name")
            ElseIf .GetError(DateTimePicker1).Length <> 0 Then
                .SetError(DateTimePicker1, "Valid age must be 18yrs or above")
            ElseIf .GetError(txtPhone).Length <> 0 Then
                .SetError(txtPhone, "Please enter contact number")
            ElseIf .GetError(txtOccupation).Length <> 0 Then
                .SetError(txtOccupation, "Please enter occupation")
            ElseIf .GetError(txtWorkPlace).Length <> 0 Then
                .SetError(txtWorkPlace, "Please enter place of work")
            ElseIf .GetError(txtResidenceAddress).Length <> 0 Then
                .SetError(txtResidenceAddress, "Please enter place residence")
            Else

                Try
                    'MsgBox(recpt)
                    SelectClass.checkAmtInNoneLoanTable(txtClientName.Text, AcctNames)


                    clientClass.InsertToLoanTable(txtClientName.Text, AcctNames, amtRequest, CombLoanTypes, loInterestes, taxNam, taxVals, Total, LoaDate.Value, Tim, durationn, txtPhone.Text, kUser)


                    Deposite(recpt, txtClientName.Text, AcctNames, "Access Loan", "0301234567", LoaDate.Value, Tim, amtRequest, "Loan Deposit", (amtRequest + SelectClass.balans), kUser)

                    updatesTransactions(AcctNames, txtClientName.Text, (amtRequest + SelectClass.balans))

                    clientClass.InsertToLoanBalance(txtClientName.Text, Total)
                    Dim rept As String = SelectClass.getNoneReceipt()
                    ' gurantorClass.AddGurantor(txtClientName.Text.Trim, Total, txtGFirstname.Text.Trim.ToUpper, txtGLastname.Text.Trim.ToUpper, comboGender.SelectedItem, DateTimePicker1.Value, txtPhone.Text.Trim, txtOccupation.Text.Trim.ToUpper, txtWorkPlace.Text.Trim.ToUpper, comboNationality.SelectedItem, txtResidenceAddress.Text.Trim.ToUpper, comRelated.SelectedItem, PictureBox1)
                    SearchGuarantor(txtClientName.Text.Trim())
                    insertClass.Nonereceipt(rept)

                    btnCancel_Click(sender, e)
                    Me.Close()
                    frmAccessLoan.btnReset_Click(sender, e)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End With
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SelectClass.ImageUpload(PictureBox1)
    End Sub

    Private Sub frmGurantor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clearAll()
        'txtClientName.Text = frmAccessLoan.txtAcctNumber.Text.Trim
    End Sub

    Private Sub txtGFirstname_TextChanged(sender As Object, e As EventArgs) Handles txtGFirstname.TextChanged, txtGFirstname.Leave
        validateFname(DirectCast(sender, Control))

    End Sub

    Private Sub txtGLastname_TextChanged(sender As Object, e As EventArgs) Handles txtGLastname.TextChanged, txtGLastname.Leave
        validateLname(DirectCast(sender, Control))
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged, DateTimePicker1.Leave
        validateDOB(DirectCast(sender, Control))
    End Sub

    Private Sub txtPhone_TextChanged(sender As Object, e As EventArgs) Handles txtPhone.TextChanged, txtPhone.Leave
        validatephone(DirectCast(sender, Control))
    End Sub

    Private Sub txtOccupation_TextChanged(sender As Object, e As EventArgs) Handles txtOccupation.TextChanged, txtOccupation.Leave
        validateOccupation(DirectCast(sender, Control))
    End Sub

    Private Sub txtWorkPlace_TextChanged(sender As Object, e As EventArgs) Handles txtWorkPlace.TextChanged, txtWorkPlace.Leave
        validateWorkplace(DirectCast(sender, Control))
    End Sub

    Private Sub txtResidenceAddress_TextChanged(sender As Object, e As EventArgs) Handles txtResidenceAddress.TextChanged, txtResidenceAddress.Leave
        validateResidence(DirectCast(sender, Control))
    End Sub

    Private Sub txtPhone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhone.KeyPress
        If Not IsNumeric(e.KeyChar) AndAlso
          e.KeyChar <> ControlChars.Back AndAlso
          e.KeyChar <> Chr(Keys.Delete) Then
            e.Handled = True

        ElseIf e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub




    'firstname
    Private Sub validateFname(ctrl As Control)
        If txtGFirstname.Text.Trim = "" Then
            err.SetIconAlignment(txtGFirstname, ErrorIconAlignment.BottomLeft)
            err.SetError(txtGFirstname, "Please enter first name")
            txtGFirstname.Focus()
        Else
            err.SetError(txtGFirstname, String.Empty)
        End If
    End Sub

    'lastname
    Private Sub validateLname(ctrl As Control)
        If txtGLastname.Text.Trim = "" Then
            err.SetIconAlignment(txtGLastname, ErrorIconAlignment.BottomLeft)
            err.SetError(txtGLastname, "Please enter last name")
            txtGLastname.Focus()
        Else
            err.SetError(txtGLastname, String.Empty)
        End If
    End Sub

    'DOB
    Private Sub validateDOB(ctrl As Control)
        setDOB = Now
        CalcDOB = (CType(setDOB.Date.Year, Integer) - CType(DateTimePicker1.Value.Year, Integer))
        If CalcDOB < 18 Then
            err.SetIconAlignment(DateTimePicker1, ErrorIconAlignment.BottomLeft)
            err.SetError(DateTimePicker1, "Valid age must be 18yrs or above")
            DateTimePicker1.Focus()
        Else
            err.SetError(DateTimePicker1, String.Empty)
        End If
    End Sub

    'gurantor Contact
    Private Sub validatephone(ctrl As Control)
        If txtPhone.Text.Trim.Length >= 10 Then
            err.SetError(txtPhone, String.Empty)
        Else
            err.SetIconAlignment(txtPhone, ErrorIconAlignment.BottomLeft)
            err.SetError(txtPhone, "Please enter contact number")
            txtPhone.Focus()
        End If


    End Sub

    'occupation
    Private Sub validateOccupation(ctrl As Control)
        If txtOccupation.Text.Trim = "" Then
            err.SetIconAlignment(txtOccupation, ErrorIconAlignment.BottomLeft)
            err.SetError(txtOccupation, "Please enter occupation")
            txtOccupation.Focus()
        Else
            err.SetError(txtOccupation, String.Empty)
        End If

    End Sub


    'workplace

    Private Sub validateWorkplace(ctrl As Control)
        If txtWorkPlace.Text.Trim = "" Then
            err.SetIconAlignment(txtWorkPlace, ErrorIconAlignment.BottomLeft)
            err.SetError(txtWorkPlace, "Please enter place of work")
            txtWorkPlace.Focus()
        Else
            err.SetError(txtWorkPlace, String.Empty)
        End If

    End Sub

    'residence

    Private Sub validateResidence(ctrl As Control)
        If txtResidenceAddress.Text.Trim = "" Then
            err.SetIconAlignment(txtResidenceAddress, ErrorIconAlignment.BottomLeft)
            err.SetError(txtResidenceAddress, "Please enter place residence")
            txtResidenceAddress.Focus()
        Else
            err.SetError(txtResidenceAddress, String.Empty)
        End If

    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        clearAll()
    End Sub

    'PERFORM INSERTION INTO DAILY TRANSACTION
    Private Sub Deposite(ReceiptNo As String, AccNo As String, AccName As String, WDName As String, WDContact As String, TransDate As String, TransTime As String, Amts As Double, TransType As String, AmtBalance As Double, TransBy As String)
        Try
            dbconnection()
            sql = "INSERT INTO  DailyTransaction(ReceiptNo, AccNo, AccName, WDName, WDContact, TransDate, TransTime, Amts, TransType,AmtBalance, TransBy) VALUES(@ReceiptNo,@AccNo,@AccName,@WDName,@WDContact,@TransDate,@TransTime,@Amts,@TransType,@AmtBalance,@TransBy)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@ReceiptNo", ReceiptNo.Trim)
            cmd.Parameters.AddWithValue("@AccNo", AccNo.Trim)

            cmd.Parameters.AddWithValue("@AccName", AccName.Trim)
            cmd.Parameters.AddWithValue("@WDName", WDName.Trim)
            cmd.Parameters.AddWithValue("@WDContact", WDContact.Trim)
            cmd.Parameters.AddWithValue("@TransDate", TransDate)
            cmd.Parameters.AddWithValue("@TransTime", TransTime)
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


    Private Sub updatesTransactions(AcctName As String, AcctNumber As String, AmountStored As Double)

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

    'THE LOGIC BEHIND THIS SUP IS THAT
    'ONCE THE SEARCH FIND AN ALREADY EXISTING GUARANTOR
    'THE DETAILS WILL BE UPDATED
    'BUT WHEN THE SEARCH IS NOT FOUND THE NEW GUARANTOR DETAILS WILL BE INSERTED

    Private Sub SearchGuarantor(num As String)
        Dim i As Integer
        Try
            dbconnection()
            sql = "SELECT AccNo FROM Gurantor where AccNo = '" & num.Trim() & "'"
            cmd = New SqlCommand(sql, con)
            reader = cmd.ExecuteReader()
            If reader.Read Then
                i = 1
            End If
            If i > 0 Then
                updateguarantor()
            Else
                'perform insertion
                gurantorClass.AddGurantor(txtClientName.Text.Trim, Total, txtGFirstname.Text.Trim.ToUpper, txtGLastname.Text.Trim.ToUpper, comboGender.SelectedItem, DateTimePicker1.Value, txtPhone.Text.Trim, txtOccupation.Text.Trim.ToUpper, txtWorkPlace.Text.Trim.ToUpper, comboNationality.SelectedItem, txtResidenceAddress.Text.Trim.ToUpper, comRelated.SelectedItem, PictureBox1)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try

    End Sub

    'UPDATE GUARANTOR DETAILS
    Private Sub updateguarantor()
        Try
            dbconnection()
            Dim updateString As String = " update Gurantor set amt=@amt, Gfname=@Gfname, Glname=@Glname, Ggender=@Ggender, GDOB=@GDOB, GPhone=@GPhone, GOccupation=@GOccupation, GWorkplace=@GWorkplace, Gnationality=@Gnationality, GResidence=@GResidence, GRelateAs=@GRelateAs, GPhoto=@GPhoto where AccNo = '" & txtClientName.Text.Trim() & "'"
            cmd = New SqlCommand(updateString, con)
            cmd.Parameters.AddWithValue("@amt", Total)
            cmd.Parameters.AddWithValue("@Gfname", txtGFirstname.Text.Trim.ToUpper())
            cmd.Parameters.AddWithValue("@Glname", txtGLastname.Text.Trim.ToUpper())
            cmd.Parameters.AddWithValue("@Ggender", comboGender.SelectedItem)
            cmd.Parameters.AddWithValue("@GDOB", DateTimePicker1.Value.Date)
            cmd.Parameters.AddWithValue("GPhone", txtPhone.Text.Trim())
            cmd.Parameters.AddWithValue("@GOccupation", txtOccupation.Text.Trim.ToUpper())
            cmd.Parameters.AddWithValue("@GWorkplace", txtWorkPlace.Text.Trim.ToUpper())
            cmd.Parameters.AddWithValue("@Gnationality", comboNationality.SelectedItem)
            cmd.Parameters.AddWithValue("@GResidence", txtResidenceAddress.Text.Trim.ToUpper())
            cmd.Parameters.AddWithValue("@GRelateAs", comRelated.SelectedItem.ToUpper)


            'ADDING PHOTO AND SIGNATURE

            Dim pp As New MemoryStream()
            PictureBox1.Image.Save(pp, PictureBox1.Image.RawFormat)
            Dim pdata As Byte() = pp.GetBuffer()
            Dim ppic As New SqlParameter("@GPhoto", SqlDbType.Image)
            ppic.Value = pdata
            cmd.Parameters.Add(ppic)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Guarantor recorded with update", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try

    End Sub


#Region "set to default"

    Private Sub clearAll()
        txtGFirstname.ResetText()
        txtGLastname.ResetText()
        comboGender.SelectedIndex = 0
        DateTimePicker1.Value = Now
        txtPhone.ResetText()
        txtOccupation.ResetText()
        txtWorkPlace.ResetText()
        comboNationality.SelectedIndex = 0
        txtResidenceAddress.ResetText()
        comboNationality.SelectedIndex = 0
        PictureBox1.Image = My.Resources.PlaceHolder
        recpt = "NL-" & SelectClass.getNoneReceipt()
        comRelated.SelectedIndex = 0
        'clear error provider icon
        With err
            .SetError(txtGFirstname, String.Empty)
            .SetError(txtGLastname, String.Empty)
            .SetError(DateTimePicker1, String.Empty)
            .SetError(txtPhone, String.Empty)
            .SetError(txtOccupation, String.Empty)
            .SetError(txtWorkPlace, String.Empty)
            .SetError(txtResidenceAddress, String.Empty)
        End With

    End Sub

#End Region





End Class
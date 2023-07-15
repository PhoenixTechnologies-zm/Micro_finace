Imports System.Data.SqlClient
Imports System.IO

Public Class clsSelect
    Inherits clsEmployee
    Public getAcctName As String
    Public balans As Double
    Public yourNameIs As String
    Public Sub ImageUpload(ByVal pic As PictureBox)
        Dim openFileDialog As New OpenFileDialog
        'openFileDialog.InitialDirectory = "C:\Pictures"
        openFileDialog.Filter = "Image Files|*.gif;*.jpg;*.png;*.bmp"
        openFileDialog.ShowDialog()
        If openFileDialog.FileName <> "" Then
            pic.Image = Image.FromFile(openFileDialog.FileName)
        End If
    End Sub


    'GET ORDERED ACCT NUMBER
    Public Function getAcctNum() As String
        Try
            dbconnection()


            sql = "SELECT AccNo FROM GenAcctNo where Id = (SELECT MAX(Id) FROM GenAcctNo )"

            cmd = New SqlClient.SqlCommand(sql, con)
            reader = cmd.ExecuteReader
            While reader.Read
                getAcct = CDbl(reader("AccNo")) + 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try

        Return getAcct
    End Function


    'GEN EMPLOYEE CODE
    Public Function getEmpNum() As String
        Try
            dbconnection()


            sql = "SELECT EmpcodesGen FROM GenempCodes where Id = (SELECT MAX(Id) FROM GenempCodes )"

            cmd = New SqlClient.SqlCommand(sql, con)
            reader = cmd.ExecuteReader
            While reader.Read
                getCode = CDbl(reader("EmpcodesGen")) + 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try

        Return getCode
    End Function


    'GET ID
    Public Sub getID(mycombo As ComboBox)
        Try
            dbconnection()
            sql = "SELECT IDTypes FROM IDType"
            cmd = New SqlClient.SqlCommand(sql, con)
            reader = cmd.ExecuteReader
            While reader.Read
                With mycombo
                    .Items.Add(reader("IDTypes"))
                    .SelectedIndex = 0
                End With
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try
    End Sub

    'check username exists
    Public Sub chkUsers(ByVal username As String)
        Try

            dbconnection()

            sql = "SELECT username FROM users WHERE username = '" & username.Trim & "'"
            cmd = New SqlCommand(sql, con)
            reader = cmd.ExecuteReader
            While reader.Read
                iterat = 1
            End While
            If iterat > 0 Then
                MessageBox.Show("Username already exist", "USER EXIST", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ANNOUNCEMENT", MessageBoxButtons.OK)
        Finally
            Connection_Close()
        End Try

    End Sub

    'SELECT USERS
    Public Sub callAllUsers(com As ComboBox)

        Try
            dbconnection()
            sql = "SELECT Uname FROM Users"
            cmd = New SqlCommand(sql, con)
            reader = cmd.ExecuteReader()
            While reader.Read()
                com.Items.Add(reader("Uname"))

            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try
    End Sub

    ' call empcode

    Public Sub callEmpcode()

        Try
            dbconnection()
            sql = "SELECT Empcode FROM Users WHERE Uname = '" + logUser.Text + "'"
            con.Open()
            cmd = New SqlCommand(sql, con)
            reader = cmd.ExecuteReader
            While reader.Read()
                logUcode = reader("Empcode")
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
    End Sub

    'SELECT ADMINS AND EMPCODE

    Public Sub callAllAdmins(com As ListBox)

        Try
            dbconnection()
            sql = "SELECT Uname, Empcode FROM ADMINS"
            cmd = New SqlCommand(sql, con)
            reader = cmd.ExecuteReader()
            While reader.Read()
                com.Items.Add(reader("Uname"))
            End While
            com.SelectedIndex = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try
    End Sub


    'SELECT ADMINS FROM ADMIN TABLE
    Public Sub callAdminsNames(com As ComboBox)

        Try
            dbconnection()
            sql = "SELECT Uname FROM ADMINS"
            cmd = New SqlCommand(sql, con)
            reader = cmd.ExecuteReader()
            While reader.Read()
                com.Items.Add(reader("Uname"))
            End While
            com.SelectedIndex = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try
    End Sub



    'PULL ID
    Public Sub callIDType(names As ComboBox)
        Dim sqlSelect As String = "SELECT IDTypes FROM IDType"
        Try
            dbconnection()
            cmd = New SqlCommand(sqlSelect, con)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                With names
                    .Items.Add(reader("IDTypes"))
                    .Sorted = True
                    .SelectedIndex = 0
                End With
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
    End Sub

    'PULL DEPARTMENT
    Public Sub callDepartments(deptName As ComboBox)
        Dim sqlSelect As String = "SELECT deptName FROM Departments"
        Try
            dbconnection()
            cmd = New SqlCommand(sqlSelect, con)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                With deptName
                    .Items.Add(reader("deptName"))
                    .Sorted = True
                    .SelectedIndex = 0
                End With
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
    End Sub

    'LOAN RECEIPT
    Public Function getLoanReceipt() As String
        Try
            dbconnection()

            sql = "SELECT RecodesGen FROM GenLoanReceipt where Id = (SELECT MAX(Id) FROM GenLoanReceipt )"

            cmd = New SqlClient.SqlCommand(sql, con)
            reader = cmd.ExecuteReader
            While reader.Read
                LoanReceiptCode = CDbl(reader("RecodesGen")) + 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try
        Return LoanReceiptCode
    End Function


    'GET ACCOUNT NAME
    Public Sub SubAcctName(num As String)
        Try
            dbconnection()
            sql = "SELECT AccName FROM Loans where AccNo = '" & num & "'"
            cmd = New SqlCommand(sql, con)
            reader = cmd.ExecuteReader()
            If reader.Read Then
                getAcctName = reader("AccName")

            Else
                getAcctName = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try

    End Sub


    'LOAN RECEIPT
    Public Function getNoneReceipt() As String
        Try
            dbconnection()

            sql = "SELECT RecodesGen FROM Genreceipt where Id = (SELECT MAX(Id) FROM Genreceipt)"

            cmd = New SqlClient.SqlCommand(sql, con)
            reader = cmd.ExecuteReader
            While reader.Read
                ReceiptCode = CDbl(reader("RecodesGen")) + 1
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try
        Return ReceiptCode
    End Function


    'GET ACCOUNT NAME
    Public Sub getAcctHolder(num As String)
        Try
            dbconnection()
            sql = "SELECT AccName FROM AcctDetails where AccNo = '" & num & "'"
            cmd = New SqlCommand(sql, con)
            reader = cmd.ExecuteReader()
            If reader.Read Then
                HolderName = reader("AccName")

            Else
                HolderName = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try

    End Sub


    'PULL AMOUNT FROM ACCOUNT BALANCE
    Public Sub checkAmtInNoneLoanTable(accountNum As String, accountName As String)
        Try
            'THE FOLLOWING VARIABLE IS HOLD TRUE IF USER FOUND, AND FALSE IF USER IS NOT FOUND
            Dim custFound As Boolean = False
            Dim AmountHad As Double = Nothing
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

            'CUSTOMER IS FOUND
            If (custFound = True) Then
                'MsgBox("Client found")
                'STORE THE VALUE IN THE AMOUNT-HAD-TEXTBOX
                balans = AmountHad
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    'TRACK USERS
    Public Sub getNameOfEmployee(COD As String)

        Try
            dbconnection()
            sql = "SELECT EmpSurname FROM Employee WHERE EmpCode= '" & COD & "'"
            cmd = New SqlCommand(sql, con)
            reader = cmd.ExecuteReader()
            If reader.Read Then
                yourNameIs = reader("EmpSurname")
            Else
                yourNameIs = ""
            End If
        Catch ex As Exception

        Finally
            Connection_Close()
        End Try
    End Sub


    

End Class

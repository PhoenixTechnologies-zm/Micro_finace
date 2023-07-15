
Imports System.Data.SqlClient
Imports System.IO
Public Class clsInsert
    Public Sub insertToGenAcctNo(Num As String)
        Try
            dbconnection()
            sql = "INSERT INTO GenAcctNo(AccNo) VALUES(@AccNo)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@AccNo", Num)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Taken back to Coding", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Connection_Close()
        End Try

    End Sub


    Public Sub insertToGenEmpNo(Num As String)
        Try
            dbconnection()
            sql = "INSERT INTO GenempCodes(EmpcodesGen) VALUES(@EmpcodesGen)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@EmpcodesGen", Num)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Taken back to Coding", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Connection_Close()
        End Try

    End Sub

    Public Sub insertToIDType(IDType As String)
        Try
            dbconnection()
            sql = "INSERT INTO IDType(IDTypes) VALUES(@IDTypes)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@IDTypes", IDType)
            cmd.ExecuteNonQuery()
            MsgBox("ID successfully created", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        Finally
            Connection_Close()
        End Try

    End Sub


    Public Sub insertToRateTable(Rname As String, Rvalue As Double, TaxName As String, Rtax As Double)
        Try
            dbconnection()
            sql = "INSERT INTO Rates (RateName,RateValue,TaxName,TaxValue) VALUES(@RateName,@RateValue,@TaxName,@TaxValue)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@RateName", Rname.Trim)
            cmd.Parameters.AddWithValue("@RateValue", Rvalue)
            cmd.Parameters.AddWithValue("@TaxName", TaxName)
            cmd.Parameters.AddWithValue("@TaxValue", Rtax)
            cmd.ExecuteNonQuery()
            MsgBox("Rates successfully created", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message & "Contact the developer", MsgBoxStyle.Exclamation)
        Finally
            Connection_Close()
        End Try
    End Sub

    'LOAN RCEIPT
    Public Sub Loanreceipt(rNum As String)

        Try
            dbconnection()
            sql = "INSERT INTO GenLoanReceipt(RecodesGen) VALUES(@RecodesGen)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@RecodesGen", rNum)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Taken back to Coding", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Connection_Close()
        End Try

    End Sub

    'NONE RCEIPT
    Public Sub Nonereceipt(rNum As String)

        Try
            dbconnection()
            sql = "INSERT INTO Genreceipt(RecodesGen) VALUES(@RecodesGen)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@RecodesGen", rNum)
            cmd.ExecuteNonQuery()
            'MessageBox.Show("Taken back to Coding", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Connection_Close()
        End Try

    End Sub

    'to back-up database
    Public Sub dbBackup(ByVal path As String)
        Try
            dbconnection()
            Dim strPath As String = path & "\EzeeDB.bak"

            'CREATE DIRECTORY IF NOT EXIST

            If Not Directory.Exists(path) Then
                Directory.CreateDirectory(path)

                Dim sql As String = "BACKUP DATABASE EzeeDB TO DISK = @path WITH NAME = 'EzeeDB-Full Database Backup'"
                Dim cm As New SqlCommand(sql, con)
                cm.Parameters.AddWithValue("@path", strPath)
                cm.ExecuteNonQuery()
                MsgBox("Database successfully backed-up to specified location", MsgBoxStyle.Information)

            Else
                Dim sql As String = "BACKUP DATABASE EzeeDB TO DISK = @path WITH NAME = 'EzeeDB-Full Database Backup'"
                Dim cm As New SqlCommand(sql, con)
                cm.Parameters.AddWithValue("@path", strPath)
                cm.ExecuteNonQuery()
                MsgBox("Database successfully backed-up to specified location", MsgBoxStyle.Information)

            End If
        Catch ex As Exception
            MsgBox(ex.Message & Environment.NewLine & "Please contact the developer", MsgBoxStyle.Exclamation)
        Finally
            Connection_Close()
        End Try

    End Sub


    'to restore database
    Public Sub dbRes(ByVal filePath As String)
        Try
            dbconnection()
            Dim sql As String = "RESTORE DATABASE EzeeDB FROM DISK = @path WITH FILE = 3"
            Dim cm As New SqlCommand(sql, con)
            cm.Parameters.AddWithValue("@path", filePath)
            cm.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message & Environment.NewLine & "Please contact the developer", MsgBoxStyle.Exclamation)
        Finally
            Connection_Close()
        End Try
    End Sub


    'PERFORM INSERTION INTO DAILY TRANSACTION
    Public Sub Deposites(ReceiptNo As String, AccNo As String, AccName As String, WDName As String, WDContact As String, TransDate As DateTimePicker, TransTime As DateTimePicker, Amts As Double, TransType As String, AmtBalance As Double, TransBy As String)
        Try
            dbconnection()
            sql = "INSERT INTO  DailyTransaction(ReceiptNo, AccNo, AccName, WDName, WDContact, TransDate, TransTime, Amts, TransType,AmtBalance, TransBy) VALUES(@ReceiptNo,@AccNo,@AccName,@WDName,@WDContact,@TransDate,@TransTime,@Amts,@TransType,@AmtBalance,@TransBy)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@ReceiptNo", ReceiptNo.Trim)
            cmd.Parameters.AddWithValue("@AccNo", AccNo.Trim)

            cmd.Parameters.AddWithValue("@AccName", AccName.Trim)
            cmd.Parameters.AddWithValue("@WDName", WDName.Trim)
            cmd.Parameters.AddWithValue("@WDContact", WDContact.Trim)
            cmd.Parameters.AddWithValue("@TransDate", TransDate.Value.Date)
            cmd.Parameters.AddWithValue("@TransTime", TransTime.Value.ToShortTimeString)
            cmd.Parameters.AddWithValue("@Amts", Amts)
            cmd.Parameters.AddWithValue("@TransType", TransType)
            cmd.Parameters.AddWithValue("@AmtBalance", AmtBalance)
            cmd.Parameters.AddWithValue("@TransBy", TransBy.Trim)

            cmd.ExecuteNonQuery()
            ' MsgBox("Transaction sucessfully taken", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox("Deposite " & ex.ToString)
        Finally
            Connection_Close()
        End Try

    End Sub

End Class

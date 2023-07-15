Public Class viewDailyTransactions

    Private Sub viewDailyTransactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            dbconnection()
            sql = "SELECT ReceiptNo as [RECEIPT NUMBER], AccNo AS [ACCOUNT NUMBER], AccName AS [ACCOUNT NAME], WDName AS [TRANSATION MADE BY], WDContact AS [CONTACT], TransDate AS [TRANSACTION DATE], TransTime AS[TRANSACTION TIME], Amts [AMOUNT GH₵], TransType AS [OPERATION TYPE], AmtBalance AS [OUTSTANDING BALANCE], TransBy AS [EMPLOYEE ID] FROM DailyTransaction"
            cmd = New SqlClient.SqlCommand(sql, con)
            dataAdapter = New SqlClient.SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()

            '---fill the dataset---
            dataAdapter.Fill(ds, sql)


            '---bind to the DataGridView control---
            DataGridView1.DataSource = ds
            '---set the table in the dataset to display---
            DataGridView1.DataMember = sql
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text.Trim.Length > 0 Then
            Try
                dbconnection()
                sql = "SELECT ReceiptNo as [RECEIPT NUMBER], AccNo AS [ACCOUNT NUMBER], AccName AS [ACCOUNT NAME], WDName AS [TRANSATION MADE BY], WDContact AS [CONTACT], TransDate AS [TRANSACTION DATE], TransTime AS[TRANSACTION TIME], Amts [AMOUNT GH₵], TransType AS [OPERATION TYPE], AmtBalance AS [OUTSTANDING BALANCE], TransBy AS [EMPLOYEE ID] FROM DailyTransaction where ReceiptNo='" & TextBox1.Text.Trim() & "'"
                cmd = New SqlClient.SqlCommand(sql, con)
                dataAdapter = New SqlClient.SqlDataAdapter(cmd)
                Dim ds As DataSet = New DataSet()

                '---fill the dataset---
                dataAdapter.Fill(ds, sql)


                '---bind to the DataGridView control---
                DataGridView1.DataSource = ds
                '---set the table in the dataset to display---
                DataGridView1.DataMember = sql
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()
            End Try

        End If
    End Sub
End Class
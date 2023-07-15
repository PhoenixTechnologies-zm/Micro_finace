Public Class viewLoanPayment

    Private Sub viewLoanPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            dbconnection()
            sql = "SELECT ReceiptNo AS [RECEIPT NUMBER], AccNo AS [ACCOUNT NUMBER], AccName AS [ACCOUNT NAME], PayDate AS [PAYMENT DATE], PayTime AS [PAYMENT TIME], AmtPaid AS [AMOUNT PAID], TransBy AS [PAYMENT BY], TransContact AS [CONTACT], EmpCode AS [EMPLOYEE ID] FROM LoanPayment"
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
End Class
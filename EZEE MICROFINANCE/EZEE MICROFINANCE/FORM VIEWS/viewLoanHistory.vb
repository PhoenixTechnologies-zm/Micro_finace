Public Class viewLoanHistory

    Private Sub viewLoanHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dbconnection()
            sql = "SELECT AccNo  AS [ACCOUNT NUMBER], AccName AS [ACCOUNT NAME], LoanAmt AS [AMOUNT REQUESTED FOR GH₵], RateName AS [RATE TYPE], RateValue AS [RATE VALUE %], TaxName AS [TAX], TaxValue AS [TAX VALUE %], TotalPay AS [TOTAL REPAYMENT GH₵], LoanTakenDate AS [LOAN ACCESS DATE], LoanTakenTime AS [LOAN ACCESS TIME], Durations AS [REPAYMENT ENDS ON], GurantorContact AS [GURANTOR CONTACT], EmpCode AS [EMPLOYEE ID] FROM Loans"
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
Imports System.Data.SqlClient
Public Class viewRatings

    Private Sub viewRatings_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Try

            dbconnection()
            sql = "SELECT RateName as [RATE], RateValue AS [INTEREST RATE %],TaxName AS [TAX],TaxValue AS [TAX VALUE %] FROM Rates"
            cmd = New SqlCommand(sql, con)
            dataAdapter = New SqlDataAdapter(cmd)
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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class
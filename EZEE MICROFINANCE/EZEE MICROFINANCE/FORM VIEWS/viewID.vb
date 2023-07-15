Imports System.Data.SqlClient
Public Class viewID

    Private Sub viewID_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            dbconnection()
            sql = "SELECT ID AS NO,IDTypes as [ID TYPES] FROM IDType"
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
End Class
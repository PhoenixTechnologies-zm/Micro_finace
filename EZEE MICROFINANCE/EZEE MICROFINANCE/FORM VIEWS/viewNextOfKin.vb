Imports System.Data.SqlClient
Public Class viewNextOfKin

    Private Sub viewNextOfKin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            dbconnection()
            sql = "SELECT AccNo as [CLIENT ACCOUNT NO], NTKinFullName AS [FULLNAME],NTKinGender AS [GENDER],NTKinDOB AS [DATE OF BIRTH],NTKinContact AS CONTACTS FROM NextOfKin"
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class
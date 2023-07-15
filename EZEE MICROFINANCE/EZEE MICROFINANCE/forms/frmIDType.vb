Imports System.Data.SqlClient
Public Class frmIDType
    Private insertClass As New clsInsert



    'Occupation
    Private Sub validateID(ctrl As Control)
        If txtIDType.Text.Trim = "" Then
            err.SetIconAlignment(txtIDType, ErrorIconAlignment.BottomLeft)
            err.SetError(txtIDType, "Please ID to create")
            txtIDType.Focus()
        Else
            err.SetError(txtIDType, String.Empty)
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        validateID(txtIDType)
        If err.GetError(txtIDType).Length <> 0 Then
            err.SetError(txtIDType, "Please ID to create")
        Else
            checkIDExist()

        End If

    End Sub

    Private Sub txtIDType_TextChanged(sender As Object, e As EventArgs) Handles txtIDType.TextChanged, txtIDType.Leave
        validateID(DirectCast(sender, Control))

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub


    Private Sub checkIDExist()
        Dim i As Integer
        Try
            dbconnection()
            sql = "Select IDTypes from IDType where IDTypes='" & txtIDType.Text.Trim().ToUpper() & "'"
            cmd = New SqlCommand(sql, con)
            reader = cmd.ExecuteReader()
            While reader.Read()
                i = 1
            End While
            If i > 0 Then
                MessageBox.Show("ID already exist", "Ezee Microfinance", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                insertClass.insertToIDType(txtIDType.Text.ToUpper())
                txtIDType.Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try
    End Sub
End Class
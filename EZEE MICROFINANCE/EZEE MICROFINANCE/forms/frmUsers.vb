
Imports System.Data.SqlClient
Public Class frmUsers
    Private selectClass As New clsSelect
    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged, txtPassword.Leave
        validatePassword(DirectCast(sender, Control))
    End Sub

    Private Sub validatePassword(ctrl As Control)
        If txtPassword.Text.Trim = "" Then
            err.SetIconAlignment(txtPassword, ErrorIconAlignment.BottomLeft)
            err.SetError(txtPassword, "Please enter password")
            txtPassword.Focus()
        Else
            err.SetError(txtPassword, String.Empty)
        End If
    End Sub

    Private Sub validateUname(ctrl As Control)
        If TextBox1.Text.Trim = "" Then
            err.SetIconAlignment(TextBox1, ErrorIconAlignment.BottomLeft)
            err.SetError(TextBox1, "Please enter username")
            TextBox1.Focus()
        Else
            err.SetError(TextBox1, String.Empty)
        End If
    End Sub


    Private Sub btnGO_Click(sender As Object, e As EventArgs) Handles btnGO.Click
        validateUname(TextBox1)
        validatePassword(txtPassword)
        If err.GetError(TextBox1).Length <> 0 Then
            err.SetError(TextBox1, "Please enter username")
        ElseIf err.GetError(txtPassword).Length <> 0 Then
            err.SetError(txtPassword, "Please enter password")
        Else
            ValInput()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub frmUsers_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        End
    End Sub

    Private Sub ValInput()
        Dim valLevels As String = ""
        dbconnection()
        Try

            sql = "Select EmpCode,Uname,pwd,Priviledges from Users where Uname='" & TextBox1.Text.Trim & "' and pwd='" & txtPassword.Text.Trim & "'"

            cmd = New SqlCommand(sql, con)
            reader = cmd.ExecuteReader()
            While reader.Read()
                i = 1
                EMPLOCODE = reader("EmpCode")
                valLevels = reader("Priviledges")
            End While
            If i > 0 Then

                selectClass.getNameOfEmployee(EMPLOCODE)
                frmMain.yourName.Text = selectClass.yourNameIs
                Me.Hide()

                If valLevels.ToUpper = "USERS" Then
                    frmMain.FileToolStripMenuItem.Enabled = False
                    frmMain.BackupRestoreToolStripMenuItem.Enabled = False
                    frmMain.AccessLoanToolStripMenuItem.Enabled = False
                End If
                kUser = TextBox1.Text.Trim()
                frmMain.Show()



            Else
                ShowError()

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged, TextBox1.Leave

        validateUname(DirectCast(sender, Control))
    End Sub

    Private Sub frmUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Threading.Thread.Sleep(5000)
    End Sub


    Private Sub ShowError()
        loginError.Visible = True
        For i As Integer = 0 To 3
            If loginError.Visible = False Then
                loginError.Visible = True
            ElseIf loginError.Visible = True Then
                loginError.Visible = False
            End If
            Me.Refresh()
            System.Threading.Thread.Sleep(500)
        Next
    End Sub
End Class
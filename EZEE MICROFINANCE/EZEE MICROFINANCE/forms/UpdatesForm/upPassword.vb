Imports System.Data.SqlClient
Public Class upPassword
    Private updateClass As New clsUpdates
    Private err As New ErrorProvider
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            txtPassword.PasswordChar = ""
            txtConfirmPassword.PasswordChar = ""
            txtNewPassword.PasswordChar = ""
        Else
            txtPassword.PasswordChar = "#"
            txtConfirmPassword.PasswordChar = "#"
            txtNewPassword.PasswordChar = "#"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        valEmpCode(txtEmpCode)
        valUsername(txtUsername)
        valPassword(txtPassword)
        valNewPassword(txtNewPassword)
        valConfirmPassword(txtConfirmPassword)
        With err
            If .GetError(txtEmpCode).Length <> 0 Then
                .SetError(txtEmpCode, "Field can't be empty")
            ElseIf .GetError(txtUsername).Length <> 0 Then
                .SetError(txtUsername, "Field can't be empty")
            ElseIf .GetError(txtPassword).Length <> 0 Then
                .SetError(txtPassword, "Field can't be empty")
            ElseIf .GetError(txtNewPassword).Length <> 0 Then
                .SetError(txtNewPassword, "Field can't be empty")
            ElseIf .GetError(txtConfirmPassword).Length <> 0 Then
                .SetError(txtConfirmPassword, "Field can't be empty")
            Else
                If txtNewPassword.Text = txtConfirmPassword.Text Then
                    Call SelectUserDetails()
                Else
                    MsgBox("New Password and Confirm Password mismatch", MsgBoxStyle.Exclamation)
                End If
            End If

        End With

    End Sub

    'SELECT USER DETAILS BEFORE UPDATE
    Private Sub SelectUserDetails()
        Dim Found As Boolean = False
        Try
            dbconnection()
            sql = "SELECT EmpCode, Uname, pwd from Users Where EmpCode ='" & txtEmpCode.Text.Trim & "' AND Uname='" & txtUsername.Text.Trim & "' AND pwd ='" & txtPassword.Text.Trim & "'"
            cmd = New SqlClient.SqlCommand(sql, con)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            If reader.Read Then
                txtEmpCode.Text = reader("EmpCode")
                txtUsername.Text = reader("Uname")
                txtPassword.Text = reader("pwd")
                Found = True
            Else
                MsgBox("Invalid Employee number/Username/Password", MsgBoxStyle.Exclamation)
            End If
            'USER DETAILS ARE VALID
            'THEN PERFORM THE NECESSARY UPDATES
            If (Found = True) Then
                updateClass.updatePassword(txtEmpCode.Text.Trim, txtUsername.Text.Trim, txtPassword.Text.Trim, txtNewPassword.Text.Trim)
                clearAll()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Connection_Close()
        End Try

    End Sub


    'EMPCODE
    Private Sub valEmpCode(ctrl As Control)
        If Not txtEmpCode.Text.Length > 0 Then
            err.SetIconAlignment(txtEmpCode, ErrorIconAlignment.MiddleLeft)
            err.SetError(txtEmpCode, "Field can't be empty")
        Else
            err.SetError(txtEmpCode, String.Empty)
        End If
    End Sub

    'USERNAME
    Private Sub valUsername(ctrl As Control)
        If Not txtUsername.Text.Length > 0 Then
            err.SetIconAlignment(txtUsername, ErrorIconAlignment.MiddleLeft)
            err.SetError(txtUsername, "Field can't be empty")
        Else
            err.SetError(txtUsername, String.Empty)
        End If
    End Sub

    'PASSWORD
    Private Sub valPassword(ctrl As Control)
        If Not txtPassword.Text.Length > 0 Then
            err.SetIconAlignment(txtPassword, ErrorIconAlignment.MiddleLeft)
            err.SetError(txtPassword, "Field can't be empty")
        Else
            err.SetError(txtPassword, String.Empty)
        End If
    End Sub

    'NEW PASSWORD
    Private Sub valNewPassword(ctrl As Control)
        If Not txtNewPassword.Text.Length > 0 Then
            err.SetIconAlignment(txtNewPassword, ErrorIconAlignment.MiddleLeft)
            err.SetError(txtNewPassword, "Field can't be empty")
        Else
            err.SetError(txtNewPassword, String.Empty)
        End If
    End Sub

    'CONFIRM PASSWORD

    Private Sub valConfirmPassword(ctrl As Control)
        If Not txtConfirmPassword.Text.Length > 0 Then
            err.SetIconAlignment(txtConfirmPassword, ErrorIconAlignment.MiddleLeft)
            err.SetError(txtConfirmPassword, "Field can't be empty")
        Else
            err.SetError(txtConfirmPassword, String.Empty)
        End If
    End Sub

    Private Sub txtEmpCode_TextChanged(sender As Object, e As EventArgs) Handles txtEmpCode.TextChanged, txtEmpCode.Leave
        valEmpCode(DirectCast(sender, Control))
    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged, txtUsername.Leave
        valUsername(DirectCast(sender, Control))
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged, txtPassword.Leave
        valPassword(DirectCast(sender, Control))
    End Sub

    Private Sub txtNewPassword_TextChanged(sender As Object, e As EventArgs) Handles txtNewPassword.TextChanged, txtNewPassword.Leave
        valNewPassword(DirectCast(sender, Control))
    End Sub

    Private Sub txtConfirmPassword_TextChanged(sender As Object, e As EventArgs) Handles txtConfirmPassword.TextChanged, txtConfirmPassword.Leave
        valConfirmPassword(DirectCast(sender, Control))
    End Sub


    Private Sub clearAll()
        txtEmpCode.Clear()
        txtUsername.Clear()
        txtPassword.Clear()
        txtNewPassword.Clear()
        txtConfirmPassword.Clear()
        CheckBox1.Checked = False
        With err
            .SetError(txtEmpCode, String.Empty)
            .SetError(txtUsername, String.Empty)
            .SetError(txtPassword, String.Empty)
            .SetError(txtNewPassword, String.Empty)
            .SetError(txtConfirmPassword, String.Empty)
        End With
    End Sub

    Private Sub upPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clearAll()
    End Sub
End Class
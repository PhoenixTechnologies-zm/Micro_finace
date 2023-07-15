
Imports System.Data.SqlClient
Public Class frmCreateAppUsers
    Private employeeClass As New clsEmployee
    Private getcode As String
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        clearAll()

        employeeClass.SelectEmployee(txtEmpCode.Text)
        txtGetEmpName.Text = employeeClass.Names
        txtGetDepartment.Text = employeeClass.Dept
        txtGetPosition.Text = employeeClass.Positions
        getcode = employeeClass.theEmployeecode
        employeeClass.callEmployee(txtEmpCode.Text, pictImage)
    End Sub

    'SET CONTROLS TO DEFAULT TEXT
    Private Sub clearAll()



        'SET CONTROLS  PROPERTY TO READONLY 
        txtGetEmpName.ReadOnly = True
        txtGetDepartment.ReadOnly = True
        txtGetPosition.ReadOnly = True
        cboPriviledgeType.Enabled = False
        txtEmpCode.TabIndex = 0
        txtEmpCode.Focus()
        getcode = String.Empty


        txtGetEmpName.ResetText()
        txtGetDepartment.ResetText()
        txtGetPosition.ResetText()
        cboPriviledgeType.SelectedIndex = 0
        txtGetDepartment.ResetText()
        txtGetPosition.ResetText()
        txtGetEmpName.ResetText()
        pictImage.Image = Nothing

        err.SetError(txtUsername, String.Empty)
        err.SetError(txtPassword, String.Empty)
        err.SetError(txtConfirmPassword, String.Empty)
    End Sub


    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmCreateAppUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clearAll()

    End Sub

    Private Sub txtGetEmpName_TextChanged(sender As Object, e As EventArgs) Handles txtGetEmpName.TextChanged
        If txtGetEmpName.Text.Trim.Length > 0 Then
            txtUsername.ReadOnly = False
            cboPriviledgeType.Enabled = True
            txtPassword.ReadOnly = False
            txtConfirmPassword.ReadOnly = False
        Else
            txtUsername.ResetText()
            txtPassword.ResetText()
            txtConfirmPassword.ResetText()
            cboPriviledgeType.SelectedIndex = 0

            txtUsername.ReadOnly = True
            cboPriviledgeType.Enabled = False
            txtPassword.ReadOnly = True
            txtConfirmPassword.ReadOnly = True

        End If
    End Sub


    'INSERT TO USER ACCOUNT SPECIFIED
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtGetEmpName.Text.Length > 0 Then
            validateUsername(txtUsername)
            validatePassword(txtPassword)
            validateConfirmPassword(txtConfirmPassword)
            With err
                If .GetError(txtUsername).Length <> 0 Then
                    .SetError(txtUsername, "Please enter login name")
                ElseIf .GetError(txtPassword).Length <> 0 Then
                    .SetError(txtPassword, "Please enter password")
                ElseIf .GetError(txtConfirmPassword).Length <> 0 Then
                    .SetError(txtConfirmPassword, "Please repeat password")
                Else
                    If txtPassword.Text <> txtConfirmPassword.Text Then
                        MsgBox("Password mismatch", MsgBoxStyle.Exclamation)
                        Exit Sub
                    Else
                        Call SelectUser()
                    End If

                End If

            End With
        Else
            MsgBox("Employee Identity not found", MsgBoxStyle.Exclamation)
            Return
        End If


    End Sub

    Private Sub txtUsername_TextChanged_1(sender As Object, e As EventArgs) Handles txtUsername.TextChanged, txtUsername.Leave
        validateUsername(DirectCast(sender, Control))
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged, txtPassword.Leave
        validatePassword(DirectCast(sender, Control))
    End Sub

    Private Sub txtConfirmPassword_TextChanged(sender As Object, e As EventArgs) Handles txtConfirmPassword.TextChanged, txtConfirmPassword.Leave
        validateConfirmPassword(DirectCast(sender, Control))
    End Sub


    ' Username
    Private Sub validateUsername(ctrl As Control)
        If txtUsername.Text.Trim = String.Empty Then
            err.SetIconAlignment(txtUsername, ErrorIconAlignment.BottomLeft)
            err.SetError(txtUsername, "Please enter login name")

        Else
            err.SetError(txtUsername, String.Empty)
        End If
    End Sub

    'Password
    Private Sub validatePassword(ctrl As Control)
        If txtPassword.Text.Trim = String.Empty Then
            err.SetIconAlignment(txtPassword, ErrorIconAlignment.BottomLeft)
            err.SetError(txtPassword, "Please enter password")

        Else
            err.SetError(txtPassword, String.Empty)
        End If
    End Sub

    'Confirm Password
    Private Sub validateConfirmPassword(ctrl As Control)
        If txtConfirmPassword.Text.Trim = String.Empty Then
            err.SetIconAlignment(txtConfirmPassword, ErrorIconAlignment.BottomLeft)
            err.SetError(txtConfirmPassword, "Please repeat password")

        Else
            err.SetError(txtConfirmPassword, String.Empty)
        End If
    End Sub


    'CHECK USER EXIST BEFORE ADDING
    'IF IT EXIST THEN IGNORE
    Public Sub SelectUser()
        Dim i As Integer
        Try
            dbconnection()
            sql = "SELECT Empcode FROM Users where Empcode = '" & txtEmpCode.Text.Trim() & "'"
            cmd = New SqlCommand(sql, con)
            reader = cmd.ExecuteReader()
            While reader.Read()
                i = 1
            End While
            If i > 0 Then
                MsgBox("User already exist", MsgBoxStyle.Exclamation)
                Exit Sub
            Else
                employeeClass.insertToUserTable(txtEmpCode.Text.Trim, txtUsername.Text.Trim(), txtPassword.Text.Trim(), cboPriviledgeType.SelectedItem.ToString())

                'RESET AFTER SAVING 
                clearAll()
                txtEmpCode.ResetText()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try
    End Sub

  
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            txtPassword.PasswordChar = ""
            txtConfirmPassword.PasswordChar = ""
        Else
            txtPassword.PasswordChar = "#"
            txtConfirmPassword.PasswordChar = "#"
        End If
    End Sub
End Class
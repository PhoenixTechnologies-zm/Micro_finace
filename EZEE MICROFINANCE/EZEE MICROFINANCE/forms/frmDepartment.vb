Imports System.Data.SqlClient

Public Class frmDepartment
    Private employeeClass As New clsEmployee
    Private Sub trxtDeptName_TextChanged(sender As Object, e As EventArgs) Handles trxtDeptName.TextChanged, trxtDeptName.Leave
        validatDeptName(DirectCast(sender, Control))

    End Sub

    Private Sub validatDeptName(ctrl As Control)
        If trxtDeptName.Text.Trim = "" Then
            err.SetIconAlignment(trxtDeptName, ErrorIconAlignment.BottomLeft)
            err.SetError(trxtDeptName, "Please enter department name")
            trxtDeptName.Focus()
        Else
            err.SetError(trxtDeptName, String.Empty)
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAddDepartment_Click(sender As Object, e As EventArgs) Handles btnAddDepartment.Click
        validatDeptName(trxtDeptName)
        If err.GetError(trxtDeptName).Length <> 0 Then
            err.SetError(trxtDeptName, "Please enter department name")
        Else
            SelecDepartment()
        End If
    End Sub


    'CHECK DEPARTMENT EXIST BEFORE ADDING
    'IF IT EXIST THEN IGNORE
    Public Sub SelecDepartment()
        Dim i As Integer
        Try
            dbconnection()
            sql = "SELECT deptName FROM Departments where deptName = '" & trxtDeptName.Text.Trim() & "'"
            cmd = New SqlCommand(sql, con)
            reader = cmd.ExecuteReader()

            'LOOP THROUGH  FIELD DATA 
            While reader.Read()
                i = 1
            End While

            ' CHECK
            If i > 0 Then
                MsgBox("Department already exist", MsgBoxStyle.Exclamation)
                Exit Sub
            Else
                'RESET AFTER SAVING 
                employeeClass.insertIntoDepartments(trxtDeptName.Text.ToUpper)
                trxtDeptName.Clear()


            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try
    End Sub
End Class
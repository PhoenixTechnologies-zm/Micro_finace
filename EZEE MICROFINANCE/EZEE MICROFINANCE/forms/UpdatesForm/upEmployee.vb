Imports System.Data.SqlClient
Imports System.IO
Public Class upEmployee
    Dim selectClass As New clsSelect
    Dim updateClass As New clsUpdates
    Dim gend As String = ""
    'PULL OUT DETAILS BY WAY OF FILTER
    Private Sub txtEmpCode_TextChanged(sender As Object, e As EventArgs) Handles txtEmpCode.TextChanged

        If txtEmpCode.Text.Length > 0 Then
            Try

                dbconnection()
                sql = "SELECT EmpSurname, EmpFirstName, EmpOthername, EmpDateOfBirth, EmpGender, EmpNationationality, EmpDept, EmpPosition, EmpContact, EmpMaritalStatus, EmpSpouseName, EmpEmail, ResAddress, RefName, RefContact, RefRelate,Photo from Employee WHERE EmpCode = '" + txtEmpCode.Text.Trim() + "'"
                cmd = New SqlCommand(sql, con)
                reader = cmd.ExecuteReader()

                If reader.Read Then
                    txtLname.Text = reader("EmpSurname")
                    txtFname.Text = reader("EmpFirstName")
                    txtOname.Text = reader("EmpOthername")
                    dob.Text = reader("EmpDateOfBirth")
                    'gender
                    gend = reader("EmpGender")
                    If (gend.ToUpper = "MALE") Then
                        radmale.Checked = True
                    ElseIf (gend.ToUpper = "FEMALE") Then
                        radFemale.Checked = True
                    End If

                    cboNationality.Text = reader("EmpNationationality")
                    cboDept.Text = reader("EmpDept")
                    txtPosition.Text = reader("EmpPosition")
                    mskContact.Text = reader("EmpContact")
                    cboMStatus.Text = reader("EmpMaritalStatus")
                    txtSpouseName.Text = reader("EmpSpouseName")
                    txtEmail.Text = reader("EmpEmail")
                    txtResAddress.Text = reader("ResAddress")
                    txtRefName.Text = reader("RefName")
                    txtRefContact.Text = reader("RefContact")
                    cboRefRelate.Text = reader("RefRelate")

                    'cast the picture data as byte()
                    data = DirectCast(reader("Photo"), Byte())
                    Dim ms As New MemoryStream(data)
                    picImage.Image = Image.FromStream(ms)
                Else
                    ClearAll()

                End If


            Catch ex As Exception
                MsgBox(ex.Message & Environment.NewLine & "Please contact the developer")

            Finally
                Connection_Close()
            End Try
        End If
    End Sub
           
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If picImage.Image Is Nothing Then
            MsgBox("Unknown employee", MsgBoxStyle.Exclamation)
            Return
        End If

        If radmale.Checked = True Then
            gend = radmale.Text.ToUpper
        ElseIf radFemale.Checked = True Then
            gend = radFemale.Text.ToUpper
        End If
        updateClass.updateEmployee(txtEmpCode.Text.Trim, txtLname.Text, txtFname.Text, txtOname.Text, dob, gend, cboNationality, cboDept, txtPosition.Text, mskContact.Text, cboMStatus, txtSpouseName.Text, txtEmail.Text, txtResAddress.Text, txtRefName.Text, txtRefContact.Text, cboRefRelate, picImage)
        ClearAll()
        txtEmpCode.Text = ""
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub upEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SelectClass.callDepartments(cboDept)
    End Sub


    Private Sub btnGetImage_Click(sender As Object, e As EventArgs) Handles btnGetImage.Click
        selectClass.ImageUpload(picImage)
    End Sub

    Private Sub ClearAll()
        cboNationality.SelectedIndex = 0

        txtLname.Text = ""
        txtOname.Text = ""
        txtFname.Text = ""
        dob.Value = Today.Date
        cboDept.SelectedIndex = 0
        txtPosition.Text = ""
        mskContact.Text = ""
        cboMStatus.SelectedIndex = 0
        txtSpouseName.Text = ""
        txtEmail.Text = ""
        txtResAddress.Text = ""
        txtRefName.Text = ""
        txtRefContact.Text = ""
        cboRefRelate.SelectedIndex = 0
        picImage.Image = Nothing
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ClearAll()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
Public Class frmEmployee
    Private SelectClass As New clsSelect
    Private employeeClass As New clsEmployee
    Private insertClass As New clsInsert
    'Lastname
    Private Sub validateLname(ctrl As Control)
        If txtLname.Text.Trim = "" Then
            err.SetIconAlignment(txtLname, ErrorIconAlignment.BottomLeft)
            err.SetError(txtLname, "Please enter last name")
            txtLname.Focus()
        Else
            err.SetError(txtLname, String.Empty)
        End If
    End Sub

    'Email
    Private Sub validateEmail(ctrl As Control)
        If txtEmail.Text.Trim <> "" Then
            If txtEmail.Text.Contains("@") And txtEmail.Text.Contains(".") Then
                err.SetError(txtEmail, String.Empty)
            Else

                err.SetIconAlignment(txtEmail, ErrorIconAlignment.BottomLeft)
                err.SetError(txtEmail, "Please email must contain @ and .")
                txtEmail.Focus()
            End If

        Else
            err.SetError(txtEmail, String.Empty)
        End If
    End Sub

    'Fname
    Private Sub validateFname(ctrl As Control)
        If txtFname.Text.Trim = "" Then
            err.SetIconAlignment(txtFname, ErrorIconAlignment.BottomLeft)
            err.SetError(txtFname, "Please enter first name")
            txtFname.Focus()
        Else
            err.SetError(txtFname, String.Empty)
        End If
    End Sub

    ' Contact
    Private Sub validateContact(ctrl As Control)
        If mskContact.Text.Trim.Length >= 10 Then
            err.SetError(mskContact, String.Empty)
        Else
            err.SetIconAlignment(mskContact, ErrorIconAlignment.BottomLeft)
            err.SetError(mskContact, "Please enter contact number")
            mskContact.Focus()
        End If

    End Sub

    'Spouse Name
    Private Sub validateSpouseName(ctrl As Control)

        If cboMStatus.SelectedIndex = 1 Then

            If txtSpouseName.Text.Trim = "" Then
                err.SetIconAlignment(txtSpouseName, ErrorIconAlignment.BottomLeft)
                err.SetError(txtSpouseName, "Please enter spouse name")

            Else
                err.SetError(txtSpouseName, String.Empty)
            End If
        Else


        End If

    End Sub

    'Residence
    Private Sub validateResidence(ctrl As Control)
        If txtResAddress.Text.Trim = "" Then
            err.SetIconAlignment(txtResAddress, ErrorIconAlignment.TopLeft)
            err.SetError(txtResAddress, "Please enter residence address")
            txtResAddress.Focus()
        Else
            err.SetError(txtResAddress, String.Empty)
        End If
    End Sub

    'POSITION
    Private Sub validatePosition(ctrl As Control)
        If txtPosition.Text.Trim = "" Then
            err.SetIconAlignment(txtPosition, ErrorIconAlignment.TopLeft)
            err.SetError(txtPosition, "Please enter job position")

        Else
            err.SetError(txtPosition, String.Empty)
        End If
    End Sub

    'Next of Referee Name
    Private Sub validateRefName(ctrl As Control)
        If txtRefName.Text.Trim = "" Then
            err.SetIconAlignment(txtRefName, ErrorIconAlignment.BottomLeft)
            err.SetError(txtRefName, "Please enter referee name")
            txtRefName.Focus()
        Else
            err.SetError(txtRefName, String.Empty)
        End If


    End Sub

    ' Referee Number
    Private Sub validateRefNum(ctrl As Control)
        If txtRefContact.Text.Trim.Length >= 10 Then
            err.SetError(txtRefContact, String.Empty)
        Else
            err.SetIconAlignment(txtRefContact, ErrorIconAlignment.BottomLeft)
            err.SetError(txtRefContact, "Please enter referee contact")
            txtRefContact.Focus()
        End If

    End Sub


    'DOB
    Private Sub validateDOB(ctrl As Control)
        setDOB = Now
        CalcDOB = (CType(setDOB.Date.Year, Integer) - CType(dob.Value.Year, Integer))
        If CalcDOB < 18 Then
            err.SetIconAlignment(dob, ErrorIconAlignment.BottomLeft)
            err.SetError(dob, "Valid age must be 18yrs or above")
            dob.Focus()
        Else
            err.SetError(dob, String.Empty)
        End If
    End Sub


    Private Sub frmEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SelectClass.callDepartments(cboDept)
        clearAll()
    End Sub

    Private Sub mskContact_TextChanged(sender As Object, e As EventArgs) Handles mskContact.TextChanged, mskContact.Leave
        validateContact(DirectCast(sender, Control))
    End Sub

    Private Sub mskContact_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskContact.KeyPress
        If Not IsNumeric(e.KeyChar) AndAlso
          e.KeyChar <> ControlChars.Back AndAlso
          e.KeyChar <> Chr(Keys.Delete) Then
            e.Handled = True

        ElseIf e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtLname_TextChanged(sender As Object, e As EventArgs) Handles txtLname.TextChanged, txtLname.Leave
        validateLname(DirectCast(sender, Control))

    End Sub

    Private Sub txtSpouseName_TextChanged(sender As Object, e As EventArgs) Handles txtSpouseName.TextChanged, txtSpouseName.Leave
        validateSpouseName(DirectCast(sender, Control))
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        validateLname(txtLname)
        validateFname(txtFname)
        validateDOB(dob)
        validateEmail(txtEmail)
        validateContact(mskContact)
        validateSpouseName(txtSpouseName)
        validateResidence(txtResAddress)
        validateRefName(txtRefName)
        validateRefNum(txtRefContact)
        validatePosition(txtPosition)
        With err
            If .GetError(txtLname).Length <> 0 Then
                .SetError(txtLname, "Please enter last name")
            ElseIf .GetError(txtFname).Length <> 0 Then
                .SetError(txtFname, "Please enter first name")
            ElseIf .GetError(dob).Length <> 0 Then
                .SetError(dob, "Valid age must be 18yrs and above")
            ElseIf .GetError(txtEmail).Length <> 0 Then
                .SetError(txtEmail, "Please email must contain @ and .")
            ElseIf .GetError(mskContact).Length <> 0 Then
                .SetError(mskContact, "Please enter contact number")
            ElseIf .GetError(txtSpouseName).Length <> 0 Then
                .SetError(txtSpouseName, "Please enter spouse name")
            ElseIf .GetError(txtResAddress).Length <> 0 Then
                .SetError(txtResAddress, "Please enter residence address")
            ElseIf .GetError(txtRefName).Length <> 0 Then
                .SetError(txtRefName, "Please enter referee name")
            ElseIf .GetError(txtRefContact).Length <> 0 Then
                .SetError(txtRefContact, "Please enter referee contact")
            ElseIf .GetError(txtPosition).Length <> 0 Then
                .SetError(txtPosition, "Please enter job position")
            Else
                If radmale.Checked = True Then
                    gender = "male"
                ElseIf radFemale.Checked = True Then
                    gender = "female"
                End If

                'GET DATE VALUE FOR NOW
                empDateJoin = DateTime.Now.ToString("d")


                Try
                    employeeClass.AddEmployee(txtEmpCode.Text, txtLname.Text.ToUpper(), txtFname.Text.ToUpper(), txtOname.Text.ToUpper(), dob.Value, gender.ToUpper(), cboNationality.SelectedItem.ToUpper(), cboDept.SelectedItem.ToUpper(), txtPosition.Text.ToUpper(), empDateJoin, mskContact.Text, cboMStatus.SelectedItem.Toupper(), txtSpouseName.Text.ToUpper(), txtEmail.Text.ToLower(), txtResAddress.Text, txtRefName.Text.ToUpper(), txtRefContact.Text, cboRefRelate.SelectedItem.toupper(), picImage)
                    insertClass.insertToGenEmpNo(getCode)

                    clearAll()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End With

       

    End Sub

    Private Sub txtOname_TextChanged(sender As Object, e As EventArgs) Handles txtOname.TextChanged

    End Sub

    Private Sub dob_ValueChanged(sender As Object, e As EventArgs) Handles dob.ValueChanged, dob.Leave
        validateDOB(DirectCast(sender, Control))
    End Sub

    Private Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged, txtEmail.Leave
        validateEmail(DirectCast(sender, Control))

    End Sub

    Private Sub txtResAddress_TextChanged(sender As Object, e As EventArgs) Handles txtResAddress.TextChanged, txtResAddress.Leave
        validateResidence(DirectCast(sender, Control))
    End Sub

    Private Sub txtRefName_TextChanged(sender As Object, e As EventArgs) Handles txtRefName.TextChanged, txtRefName.Leave
        validateRefName(DirectCast(sender, Control))
    End Sub

    Private Sub txtRefContact_TextChanged(sender As Object, e As EventArgs) Handles txtRefContact.TextChanged, txtRefContact.Leave
        validateRefNum(DirectCast(sender, Control))
    End Sub

    Private Sub txtFname_TextChanged(sender As Object, e As EventArgs) Handles txtFname.TextChanged, txtFname.Leave
        validateFname(DirectCast(sender, Control))
    End Sub

    Private Sub txtRefContact_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRefContact.KeyPress
        If Not IsNumeric(e.KeyChar) AndAlso
        e.KeyChar <> ControlChars.Back AndAlso
        e.KeyChar <> Chr(Keys.Delete) Then
            e.Handled = True

        ElseIf e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub cboMStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMStatus.SelectedIndexChanged
        If cboMStatus.SelectedIndex = 1 Then

            txtSpouseName.ReadOnly = False
        Else
            err.SetError(txtSpouseName, String.Empty)
            txtSpouseName.ResetText()
            txtSpouseName.ReadOnly = True
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        clearAll()

    End Sub

    Private Sub clearAll()
        txtLname.ResetText()
        txtFname.ResetText()
        txtSpouseName.ResetText()
        dob.Value = Now
        radmale.Checked = True
        txtEmail.ResetText()
        mskContact.ResetText()
        txtResAddress.ResetText()
        txtRefName.ResetText()
        txtRefContact.ResetText()
        cboRefRelate.SelectedIndex = 0
        cboMStatus.SelectedIndex = 0
        cboNationality.SelectedIndex = 0
        picImage.Image = My.Resources.PlaceHolder
        txtOname.ResetText()
        txtPosition.ResetText()
        txtEmpCode.Text = "Ezee-" & SelectClass.getEmpNum()
        err.SetError(dob, String.Empty)
        err.SetError(txtLname, String.Empty)
        err.SetError(txtFname, String.Empty)
        err.SetError(mskContact, String.Empty)
        err.SetError(txtEmail, String.Empty)
        err.SetError(txtSpouseName, String.Empty)
        err.SetError(txtResAddress, String.Empty)
        err.SetError(txtRefName, String.Empty)
        err.SetError(txtRefContact, String.Empty)
        err.SetError(txtPosition, String.Empty)
        txtLname.Focus()
    End Sub

    Private Sub btnGetImage_Click(sender As Object, e As EventArgs) Handles btnGetImage.Click
        SelectClass.ImageUpload(picImage)
    End Sub

    Private Sub txtPosition_TextChanged(sender As Object, e As EventArgs) Handles txtPosition.TextChanged, txtPosition.Leave
        validatePosition(DirectCast(sender, Control))
    End Sub
End Class

Public Class frmClient

    Private SelectClass As New clsSelect
    Private clientClass As New clsClient
    Private insertClass As New clsInsert
    Private Sub btnGetSignature_Click(sender As Object, e As EventArgs) Handles btnGetSignature.Click
        SelectClass.ImageUpload(picSignature)
    End Sub

    Private Sub btnGetImage_Click(sender As Object, e As EventArgs) Handles btnGetImage.Click
        SelectClass.ImageUpload(picClientImage)
    End Sub

    Private Sub txtLname_TextChanged(sender As Object, e As EventArgs) Handles txtLname.TextChanged, txtLname.Leave
        validateLname(DirectCast(sender, Control))
    End Sub

    Private Sub txtFname_TextChanged(sender As Object, e As EventArgs) Handles txtFname.TextChanged, txtFname.Leave
        validateFname(DirectCast(sender, Control))
    End Sub

    Private Sub Oname_TextChanged(sender As Object, e As EventArgs) Handles Oname.TextChanged

    End Sub

    Private Sub txtSpouseName_TextChanged(sender As Object, e As EventArgs) Handles txtSpouseName.TextChanged, txtSpouseName.Leave
        validateSpouseName(DirectCast(sender, Control))
    End Sub

    Private Sub txtOccupation_TextChanged(sender As Object, e As EventArgs) Handles txtOccupation.TextChanged, txtOccupation.Leave
        validateOccupation(DirectCast(sender, Control))
    End Sub

    Private Sub txtworkPlace_TextChanged(sender As Object, e As EventArgs) Handles txtworkPlace.TextChanged, txtworkPlace.Leave
        validatePlaceOfWork(DirectCast(sender, Control))
    End Sub

    Private Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged, txtEmail.Leave
        validateEmail(DirectCast(sender, Control))
    End Sub

    Private Sub txtIDNum_TextChanged(sender As Object, e As EventArgs) Handles txtIDNum.TextChanged, txtEmail.Leave
        validateIDNum(DirectCast(sender, Control))
    End Sub

    Private Sub txtNkinFullName_TextChanged(sender As Object, e As EventArgs) Handles txtNkinFullName.TextChanged, txtNkinFullName.Leave
        validateNKName(DirectCast(sender, Control))
    End Sub

    Private Sub ClearAll()
        selectAcctNum = New clsSelect()
        txtAcctNum.Text = "123" & selectAcctNum.getAcctNum()
        SelectClass.getID(cboIDType)
        rdMale.Checked = True
        cboMaritalstatus.SelectedIndex = 0
        cboAccountType.SelectedIndex = 0
        cboNKinGender.SelectedIndex = 0
        txtFname.ResetText()
        txtLname.ResetText()
        Oname.ResetText()
        dob.Value = Now
        txtOccupation.ResetText()
        txtworkPlace.ResetText()
        mskPhone.ResetText()
        txtEmail.ResetText()
        cboIDType.SelectedIndex = 0
        txtIDNum.ResetText()
        cboAccountType.SelectedIndex = 0
        txtResidence.ResetText()
        picClientImage.Image = My.Resources.PlaceHolder
        picSignature.Image = My.Resources.editing
        txtNkinFullName.ResetText()
        dobNKin.Value = Now
        mskNtkContact.ResetText()
        txtLname.Focus()
        'INITIALIZE ERROR PROVIDER TO EMPTY STRING

        err.SetError(dob, String.Empty)
        err.SetError(txtLname, String.Empty)
        err.SetError(txtFname, String.Empty)
        err.SetError(mskPhone, String.Empty)
        err.SetError(txtEmail, String.Empty)
        err.SetError(txtSpouseName, String.Empty)
        err.SetError(txtResidence, String.Empty)
        err.SetError(txtNkinFullName, String.Empty)
        err.SetError(mskNtkContact, String.Empty)
        err.SetError(txtOccupation, String.Empty)
        err.SetError(txtworkPlace, String.Empty)
        err.SetError(txtIDNum, String.Empty)



    End Sub


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


    'Occupation
    Private Sub validateOccupation(ctrl As Control)
        If txtOccupation.Text.Trim = "" Then
            err.SetIconAlignment(txtOccupation, ErrorIconAlignment.BottomLeft)
            err.SetError(txtOccupation, "Please enter occupation")
            txtOccupation.Focus()
        Else
            err.SetError(txtOccupation, String.Empty)
        End If
    End Sub

    'Place of work
    Private Sub validatePlaceOfWork(ctrl As Control)
        If txtworkPlace.Text.Trim = "" Then
            err.SetIconAlignment(txtworkPlace, ErrorIconAlignment.BottomLeft)
            err.SetError(txtworkPlace, "Please enter Place of work")
            txtworkPlace.Focus()
        Else
            err.SetError(txtworkPlace, String.Empty)
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

    'Client Contact
    Private Sub validateClientContact(ctrl As Control)
        If mskPhone.Text.Trim.Length >= 10 Then
            err.SetError(mskPhone, String.Empty)
        Else
            err.SetIconAlignment(mskPhone, ErrorIconAlignment.BottomLeft)
            err.SetError(mskPhone, "Please enter client contact number")
            mskPhone.Focus()
        End If


    End Sub

    'Spouse Name
    Private Sub validateSpouseName(ctrl As Control)
        If cboMaritalstatus.SelectedIndex = 1 Then
            If txtSpouseName.Text.Trim = "" Then
                err.SetIconAlignment(txtSpouseName, ErrorIconAlignment.BottomLeft)
                err.SetError(txtSpouseName, "Please enter spouse name")
                txtSpouseName.Focus()
            Else
                err.SetError(txtSpouseName, String.Empty)
            End If
        End If

    End Sub

    'Residence
    Private Sub validateResidence(ctrl As Control)
        If txtResidence.Text.Trim = "" Then
            err.SetIconAlignment(txtResidence, ErrorIconAlignment.TopLeft)
            err.SetError(txtResidence, "Please enter residence address")
            txtResidence.Focus()
        Else
            err.SetError(txtResidence, String.Empty)
        End If
    End Sub


    'ID Number
    Private Sub validateIDNum(ctrl As Control)
        If txtIDNum.Text.Trim = "" Then
            err.SetIconAlignment(txtIDNum, ErrorIconAlignment.BottomLeft)
            err.SetError(txtIDNum, "Please enter valid Id number")
            txtIDNum.Focus()
        Else
            err.SetError(txtIDNum, String.Empty)
        End If
    End Sub

    'Next of Kin Name
    Private Sub validateNKName(ctrl As Control)
        If txtNkinFullName.Text.Trim = "" Then
            err.SetIconAlignment(txtNkinFullName, ErrorIconAlignment.BottomLeft)
            err.SetError(txtNkinFullName, "Please enter next-of-kin name")
            txtNkinFullName.Focus()
        Else
            err.SetError(txtNkinFullName, String.Empty)
        End If


    End Sub

    'Next of Kin Number
    Private Sub validateNKNum(ctrl As Control)
        If mskNtkContact.Text.Trim.Length >= 10 Then
            err.SetError(mskNtkContact, String.Empty)
        Else
            err.SetIconAlignment(mskNtkContact, ErrorIconAlignment.BottomLeft)
            err.SetError(mskNtkContact, "Please enter next-of-kin contact number")
            mskNtkContact.Focus()
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ClearAll()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        'IF USER IGNORE ERROR MESSAGE AND CLICK SUBMIT
        'RETURN FALSE  AND CAUSE HIM TO ENTER VALUE

        validateLname(txtLname)
        validateFname(txtFname)
        validateDOB(dob)
        validateSpouseName(txtSpouseName)
        validateOccupation(txtOccupation)
        validatePlaceOfWork(txtworkPlace)
        validateClientContact(mskPhone)
        validateEmail(txtEmail)
        validateIDNum(txtIDNum)
        validateResidence(txtResidence)
        validateNKName(txtNkinFullName)
        validateNKNum(mskNtkContact)

        With err
            If .GetError(txtLname).Length <> 0 Then
                .SetError(txtLname, "Please enter last name")
            ElseIf .GetError(txtFname).Length <> 0 Then
                .SetError(txtFname, "Please enter first name")
            ElseIf .GetError(dob).Length <> 0 Then
                .SetError(dob, "Valid age must be 18yrs and above")
            ElseIf .GetError(txtSpouseName).Length <> 0 Then
                .SetError(txtSpouseName, "Please enter spouse name")
            ElseIf .GetError(txtOccupation).Length <> 0 Then
                .SetError(txtOccupation, "Please enter occupation")
            ElseIf .GetError(txtworkPlace).Length <> 0 Then
                .SetError(txtworkPlace, "Please enter Place of work")
            ElseIf .GetError(mskPhone).Length <> 0 Then
                .SetError(mskPhone, "Please enter client contact number")
            ElseIf .GetError(txtEmail).Length <> 0 Then
                .SetError(txtEmail, "Please email must contain @ and .")
            ElseIf .GetError(txtIDNum).Length <> 0 Then
                .SetError(txtIDNum, "Please enter valid Id number")
            ElseIf .GetError(txtResidence).Length <> 0 Then
                .SetError(txtResidence, "Please enter residence address")
            ElseIf .GetError(txtNkinFullName).Length <> 0 Then
                .SetError(txtNkinFullName, "Please enter next-of-kin name")
            ElseIf .GetError(mskNtkContact).Length <> 0 Then
                .SetError(mskNtkContact, "Please enter next-of-kin contact number")
            Else

                ' MsgBox("GOOD")

                'CLIENT HAS SELECTED GENDER
                If rdMale.Checked = True Then
                    gender = "male"
                ElseIf rdFmale.Checked = True Then
                    gender = "female"
                End If

                'INSERT TO DATABASE TABLE
                clientDateJoin = DateTime.Now.ToString("d")
                clientFullname = txtLname.Text & " " & txtFname.Text & " " & Oname.Text
                clientClass.AddClients(txtAcctNum.Text, txtLname.Text.ToUpper(), txtFname.Text.ToUpper, Oname.Text.ToUpper(), gender.ToUpper(), dob.Value, cboMaritalstatus.SelectedItem.ToUpper(), txtSpouseName.Text.ToUpper(), txtOccupation.Text.ToUpper(), txtworkPlace.Text.ToUpper(), mskPhone.Text, txtEmail.Text.ToLower(), cboIDType.SelectedItem.ToUpper(), txtIDNum.Text, txtResidence.Text, clientDateJoin, picClientImage, picSignature)
                clientClass.createAccount(txtAcctNum.Text, clientFullname.ToUpper(), cboAccountType.SelectedItem.ToUpper(), picClientImage, picSignature)
                clientClass.AddNextOfKin(txtAcctNum.Text, txtNkinFullName.Text.ToUpper(), cboNKinGender.SelectedItem.ToUpper(), dobNKin.Value, mskNtkContact.Text)
                clientClass.CreateAcctHolder(txtAcctNum.Text, clientFullname.ToUpper(), CDbl(0.0))
                insertClass.insertToGenAcctNo(getAcct)
                ClearAll()
            End If
        End With

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Private Sub txtResidence_TextChanged(sender As Object, e As EventArgs) Handles txtResidence.TextChanged, txtResidence.Leave
        validateResidence(DirectCast(sender, Control))

    End Sub

    Private Sub dob_ValueChanged(sender As Object, e As EventArgs) Handles dob.ValueChanged, dob.Leave
        validateDOB(DirectCast(sender, Control))
    End Sub

    Private Sub mskNtkContact_TextChanged(sender As Object, e As EventArgs) Handles mskNtkContact.TextChanged, mskNtkContact.Leave
        validateNKNum(DirectCast(sender, Control))
    End Sub

    Private Sub mskPhone_TextChanged(sender As Object, e As EventArgs) Handles mskPhone.TextChanged, mskPhone.Leave
        validateClientContact(DirectCast(sender, Control))
    End Sub

    'ACCEPT INTEGER VALUES,DELETE,BACKSPACE ONLY
    Private Sub mskPhone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskPhone.KeyPress
        If Not IsNumeric(e.KeyChar) AndAlso
            e.KeyChar <> ControlChars.Back AndAlso
            e.KeyChar <> Chr(Keys.Delete) Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = True
        End If

    End Sub

    Private Sub mskNtkContact_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskNtkContact.KeyPress
        If Not IsNumeric(e.KeyChar) AndAlso
            e.KeyChar <> ControlChars.Back AndAlso
            e.KeyChar <> Chr(Keys.Delete) Then
            e.Handled = True

        ElseIf e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub
   
    Private Sub frmClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClearAll()
    End Sub

    Private Sub cboMaritalstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMaritalstatus.SelectedIndexChanged
        If cboMaritalstatus.SelectedIndex = 1 Then
            txtSpouseName.ReadOnly = False
        Else
            txtSpouseName.ResetText()
            txtSpouseName.ReadOnly = True
        End If
    End Sub
End Class
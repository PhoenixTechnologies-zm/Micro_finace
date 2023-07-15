
Imports System.Data.SqlClient
Imports System.IO
Public Class clsUpdates

    Public Sub updateEmployee(EmpCode As String, EmpSurname As String, EmpFirstName As String, EmpOthername As String, EmpDateOfBirth As DateTimePicker, EmpGender As String, EmpNationationality As ComboBox, EmpDept As ComboBox, EmpPosition As String, EmpContact As String, EmpMaritalStatus As ComboBox, EmpSpouseName As String, EmpEmail As String, ResAddress As String, RefName As String, RefContact As String, RefRelate As ComboBox, Photo As PictureBox)

        Try
            dbconnection()
            sql = "UPDATE Employee SET EmpSurname=@EmpSurname, EmpFirstName=@EmpFirstName, EmpOthername=@EmpOthername, EmpDateOfBirth=@EmpDateOfBirth, EmpGender=@EmpGender, EmpNationationality=@EmpNationationality, EmpDept=@EmpDept, EmpPosition=@EmpPosition, EmpContact=@EmpContact, EmpMaritalStatus=@EmpMaritalStatus, EmpSpouseName=@EmpSpouseName, EmpEmail=@EmpEmail, ResAddress=@ResAddress, RefName=@RefName, RefContact=@RefContact, RefRelate=@RefRelate, Photo=@Photo WHERE EmpCode='" & EmpCode.Trim & "'"

            cmd = New SqlClient.SqlCommand(sql, con)


            cmd.Parameters.AddWithValue("@EmpSurname", EmpSurname.Trim.ToUpper)
            cmd.Parameters.AddWithValue("@EmpFirstName", EmpFirstName.Trim.ToUpper)
            cmd.Parameters.AddWithValue("@EmpOthername", EmpOthername.Trim.ToUpper)
            cmd.Parameters.AddWithValue("@EmpDateOfBirth", EmpDateOfBirth.Value.Date)
            cmd.Parameters.AddWithValue("@EmpGender", EmpGender.Trim)
            cmd.Parameters.AddWithValue("@EmpNationationality", EmpNationationality.SelectedItem.ToString)
            cmd.Parameters.AddWithValue("@EmpDept", EmpDept.SelectedItem.ToString)
            cmd.Parameters.AddWithValue("@EmpPosition", EmpPosition.Trim)


            cmd.Parameters.AddWithValue("@EmpContact", EmpContact.Trim)
            cmd.Parameters.AddWithValue("@EmpMaritalStatus", EmpMaritalStatus.SelectedItem.ToString)
            cmd.Parameters.AddWithValue("@EmpSpouseName", EmpSpouseName.Trim.ToUpper)
            cmd.Parameters.AddWithValue("@EmpEmail", EmpEmail.Trim)
            cmd.Parameters.AddWithValue("@ResAddress", ResAddress.Trim)
            cmd.Parameters.AddWithValue("@RefName", RefName.Trim.ToUpper)
            cmd.Parameters.AddWithValue("@RefContact", RefContact)
            cmd.Parameters.AddWithValue("@RefRelate", RefRelate.SelectedItem.ToString)


            'ADDING PHOTO AND SIGNATURE

            Dim pp As New MemoryStream()
            Photo.Image.Save(pp, Photo.Image.RawFormat)
            Dim pdata As Byte() = pp.GetBuffer()
            Dim ppic As New SqlParameter("@Photo", SqlDbType.Image)
            ppic.Value = pdata
            cmd.Parameters.Add(ppic)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Employee  account updated successfully", "UPDATES - Ezee Microfinanace", MessageBoxButtons.OK, MessageBoxIcon.Information)

            
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Connection_Close()
        End Try

    End Sub

    Public Sub updatePassword(EmpCode As String, Uname As String, oldPasswords As String, NewPassword As String)

        Try
            dbconnection()
            sql = "UPDATE Users SET pwd=@pwd WHERE Empcode='" & EmpCode & "' AND Uname='" & Uname & "'And pwd='" & oldPasswords & "'"
            cmd = New SqlClient.SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@pwd", NewPassword.Trim)
            cmd.ExecuteNonQuery()
            MsgBox("Password Updated Successfully", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Connection_Close()
        End Try
    End Sub

    Public Sub updateClient(AccNo As String, ClientLname As String, ClientFname As String, ClientOname As String, ClientGender As String, ClientDOB As Date, ClientMaritalStatus As String, ClientSpouseName As String, ClientOccupation As String, ClientCompanyName As String, ClientPhoneNo As String, ClientEmail As String, ClientIDType As String, ClientIDNo As String, ClientResidence As String, ClientPhoto As PictureBox, ClientSignature As PictureBox)
        Try
            dbconnection()
            sql = "UPDATE Clients SET  ClientLname=@ClientLname, ClientFname=@ClientFname, ClientOname=@ClientOname, ClientGender=@ClientGender, ClientDOB=@ClientDOB, ClientMaritalStatus=@ClientMaritalStatus, ClientSpouseName=@ClientSpouseName, ClientOccupation=@ClientOccupation, ClientWorkplace=@ClientWorkplace, ClientPhoneNo=@ClientPhoneNo, ClientEmail=@ClientEmail, ClientIDType=@ClientIDType, ClientIDNo=@ClientIDNo, ClientResidence=@ClientResidence , ClientPhoto=@ClientPhoto, ClientSignature=@ClientSignature WHERE AccNo ='" & AccNo.Trim & "'"

            cmd = New SqlClient.SqlCommand(sql, con)

            cmd.Parameters.AddWithValue("@ClientLname", ClientLname.Trim)
            cmd.Parameters.AddWithValue("@ClientFname", ClientFname.Trim)
            cmd.Parameters.AddWithValue("@ClientOname", ClientOname.Trim)
            cmd.Parameters.AddWithValue("@ClientGender", ClientGender.Trim)
            cmd.Parameters.AddWithValue("@ClientDOB", ClientDOB)
            cmd.Parameters.AddWithValue("@ClientMaritalStatus", ClientMaritalStatus.Trim)
            cmd.Parameters.AddWithValue("@ClientSpouseName", ClientSpouseName.Trim)
            cmd.Parameters.AddWithValue("@ClientOccupation", ClientOccupation.Trim)
            cmd.Parameters.AddWithValue("@ClientWorkplace", ClientCompanyName.Trim)
            cmd.Parameters.AddWithValue("@ClientPhoneNo", ClientPhoneNo.Trim)
            cmd.Parameters.AddWithValue("@ClientEmail", ClientEmail.Trim)
            cmd.Parameters.AddWithValue("@ClientIDType", ClientIDType.Trim)
            cmd.Parameters.AddWithValue("@ClientIDNo", ClientIDNo.Trim)
            cmd.Parameters.AddWithValue("@ClientResidence", ClientResidence.Trim)

            'ADDING PHOTO AND SIGNATURE

            Dim pp As New MemoryStream()
            ClientPhoto.Image.Save(pp, ClientPhoto.Image.RawFormat)
            Dim pdata As Byte() = pp.GetBuffer()
            Dim ppic As New SqlParameter("@ClientPhoto", SqlDbType.Image)
            ppic.Value = pdata
            cmd.Parameters.Add(ppic)

            Dim ss As New MemoryStream()
            ClientSignature.Image.Save(ss, ClientSignature.Image.RawFormat)
            Dim sdata As Byte() = ss.GetBuffer()
            Dim spic As New SqlParameter("@ClientSignature", SqlDbType.Image)
            spic.Value = sdata
            cmd.Parameters.Add(spic)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Client  account updated successfully", "UPDATE CLIENT", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try

    End Sub

    Public Sub updateAcctDetails(AccNo As String, AccName As String, AcctType As String, ClientPhoto As PictureBox, ClientSignature As PictureBox)
        Try
            dbconnection()
            Dim sqlStatement As String = "UPDATE AcctDetails SET AccName=@AccName,AcctType=@AcctType, ClientPhoto=@ClientPhoto,ClientSignature=@ClientSignature WHERE AccNo='" & AccNo.Trim & "'"
            cmd = New SqlCommand(sqlStatement, con)
            cmd.Parameters.AddWithValue("@AccName", AccName.Trim)
            cmd.Parameters.AddWithValue("@acctType ", AcctType.Trim)

            'ADDING PHOTO AND SIGNATURE

            Dim pp As New MemoryStream()
            ClientPhoto.Image.Save(pp, ClientPhoto.Image.RawFormat)
            Dim pdata As Byte() = pp.GetBuffer()
            Dim ppic As New SqlParameter("@ClientPhoto", SqlDbType.Image)
            ppic.Value = pdata
            cmd.Parameters.Add(ppic)

            Dim ss As New MemoryStream()
            ClientSignature.Image.Save(ss, ClientSignature.Image.RawFormat)
            Dim sdata As Byte() = ss.GetBuffer()
            Dim spic As New SqlParameter("@ClientSignature", SqlDbType.Image)
            spic.Value = sdata
            cmd.Parameters.Add(spic)
            cmd.ExecuteNonQuery()
            ' MsgBox("Account successfully created")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try

    End Sub


    Public Sub updateNextOfKin(AccNo As String, NTKinFullName As String, NTKinGender As String, NTKinDOB As Date, NTKinContact As String)

        Try
            dbconnection()
            Dim sqlStatement As String = "UPDATE NextOfKin SET NTKinFullName=@NTKinFullName, NTKinGender=@NTKinGender, NTKinDOB=@NTKinDOB, NTKinContact=@NTKinContact WHERE AccNo='" & AccNo.Trim & "'"
            cmd = New SqlCommand(sqlStatement, con)
            cmd.Parameters.AddWithValue("@NTKinFullName", NTKinFullName.Trim)
            cmd.Parameters.AddWithValue("@NTKinGender", NTKinGender.Trim)
            cmd.Parameters.AddWithValue("@NTKinDOB", NTKinDOB)
            cmd.Parameters.AddWithValue("@NTKinContact", NTKinContact.Trim)
            cmd.ExecuteNonQuery()
            ' MsgBox("Next-of-kin successfully  created")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try

    End Sub
End Class

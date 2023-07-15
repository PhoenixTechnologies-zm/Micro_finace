
Imports System.Data.SqlClient
Imports System.IO
Public Class clsEmployee

    Public Names As String
    Public Dept As String
    Public Positions As String
    Public theEmployeecode As String

    Public Sub AddEmployee(EmpCode As String, EmpSurname As String, EmpFirstName As String, EmpOthername As String, EmpDateOfBirth As Date, EmpGender As String, EmpNationationality As String, EmpDept As String, EmpPosition As String, EmpDateJoin As Date, EmpContact As String, EmpMaritalStatus As String, EmpSpouseName As String, EmpEmail As String, ResAddress As String, RefName As String, RefContact As String, RefRelate As String, Photo As PictureBox)

        Try
            dbconnection()
            sql = "INSERT INTO Employee(EmpCode, EmpSurname, EmpFirstName, EmpOthername, EmpDateOfBirth, EmpGender, EmpNationationality, EmpDept, EmpPosition, EmpDateJoin, EmpContact, EmpMaritalStatus, EmpSpouseName, EmpEmail, ResAddress, RefName, RefContact, RefRelate, Photo) VALUES(@EmpCode, @EmpSurname, @EmpFirstName, @EmpOthername, @EmpDateOfBirth, @EmpGender, @EmpNationationality, @EmpDept, @EmpPosition, @EmpDateJoin, @EmpContact, @EmpMaritalStatus, @EmpSpouseName, @EmpEmail, @ResAddress, @RefName, @RefContact, @RefRelate, @Photo)"

            cmd = New SqlClient.SqlCommand(sql, con)

            cmd.Parameters.AddWithValue("@EmpCode", EmpCode)
            cmd.Parameters.AddWithValue("@EmpSurname", EmpSurname.Trim)
            cmd.Parameters.AddWithValue("@EmpFirstName", EmpFirstName.Trim)
            cmd.Parameters.AddWithValue("@EmpOthername", EmpOthername.Trim)
            cmd.Parameters.AddWithValue("@EmpDateOfBirth", EmpDateOfBirth)
            cmd.Parameters.AddWithValue("@EmpGender", EmpGender.Trim)
            cmd.Parameters.AddWithValue("@EmpNationationality", EmpNationationality.Trim)
            cmd.Parameters.AddWithValue("@EmpDept", EmpDept.Trim)
            cmd.Parameters.AddWithValue("@EmpPosition", EmpPosition.Trim)
            cmd.Parameters.AddWithValue("@EmpDateJoin", EmpDateJoin)

            cmd.Parameters.AddWithValue("@EmpContact", EmpContact.Trim)
            cmd.Parameters.AddWithValue("@EmpMaritalStatus", EmpMaritalStatus.Trim)
            cmd.Parameters.AddWithValue("@EmpSpouseName", EmpSpouseName.Trim)
            cmd.Parameters.AddWithValue("@EmpEmail", EmpEmail.Trim)
            cmd.Parameters.AddWithValue("@ResAddress", ResAddress.Trim)
            cmd.Parameters.AddWithValue("@RefName", RefName.Trim)
            cmd.Parameters.AddWithValue("@RefContact", RefContact)
            cmd.Parameters.AddWithValue("@RefRelate", RefRelate)


            'ADDING PHOTO AND SIGNATURE

            Dim pp As New MemoryStream()
            Photo.Image.Save(pp, Photo.Image.RawFormat)
            Dim pdata As Byte() = pp.GetBuffer()
            Dim ppic As New SqlParameter("@Photo", SqlDbType.Image)
            ppic.Value = pdata
            cmd.Parameters.Add(ppic)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Employee  account created successfully", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try

    End Sub

    'SELECT EMPLOYEE BY WAY OF FILTER
    Public Sub SelectEmployee(empCode As String)
        Try
            '
            dbconnection()
            sql = "SELECT EmpSurname + ' ' + EmpFirstName As Fullname, EmpDept, EmpPosition from Employee WHERE EmpCode = '" + empCode + "'"
            cmd = New SqlCommand(sql, con)
            reader = cmd.ExecuteReader()

            If reader.Read Then
                Names = reader("Fullname")
                Dept = reader("EmpDept")
                Positions = reader("EmpPosition")
                theEmployeecode = empCode
            Else
                Names = ""
                Dept = ""
                Positions = ""
                theEmployeecode = ""
                MsgBox("Unknown user code!", MsgBoxStyle.Exclamation)

            End If


        Catch ex As Exception
            MsgBox(ex.Message & Environment.NewLine & "Please contact the developer")

        Finally
            Connection_Close()
        End Try
    End Sub

    Public Sub callEmployee(empCode As String, Photo As PictureBox)

        Try
            dbconnection()
            Dim se As String = "select  Photo from Employee WHERE EmpCode = '" + empCode + "'"
            cmd = New SqlCommand(se, con)
            reader = cmd.ExecuteReader()

            If reader.Read() Then
                'cast the picture data as byte()
                data = DirectCast(reader("Photo"), Byte())
                Dim ms As New MemoryStream(data)
                Photo.Image = Image.FromStream(ms)
            Else
                Photo.Image = Nothing
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try
    End Sub

    'INSERT TO USER TABLE
    Public Sub insertToUserTable(empcode As String, Uname As String, Passwords As String, Priviledges As String)

        Try
            dbconnection()
            sql = "INSERT INTO Users(EmpCode,Uname,pwd,Priviledges)VALUES(@EmpCode,@Uname,@pwd,@Priviledges)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@EmpCode", empcode)
            cmd.Parameters.AddWithValue("@Uname", Uname)
            cmd.Parameters.AddWithValue("@pwd", Passwords)
            cmd.Parameters.AddWithValue("@Priviledges", Priviledges)
            cmd.ExecuteNonQuery()
            MsgBox("Data successfully created", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            Connection_Close()
        End Try
    End Sub

    'INSERT INTO DEPARTMENT

    Public Sub insertIntoDepartments(deptName As String)
        Try
            dbconnection()
            sql = "INSERT INTO Departments(deptName)VALUES(@deptName)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@deptName", deptName.Trim)
            cmd.ExecuteNonQuery()
            MsgBox("Department sucessfully added", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            Connection_Close()
        End Try

    End Sub

End Class

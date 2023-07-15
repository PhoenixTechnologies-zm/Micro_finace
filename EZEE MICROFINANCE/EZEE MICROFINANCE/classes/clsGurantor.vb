
Imports System.Data.SqlClient
Imports System.IO
Public Class clsGurantor


    Public Sub AddGurantor(AccNo As String, amt As Double, Gfname As String, Glname As String, Ggender As String, GDOB As Date, GPhone As String, GOccupation As String, GWorkplace As String, Gnationality As String, GResidence As String, GRelateAs As String, GPhoto As PictureBox)


        'Try
        'dbconnection()
        'sql = "SELECT AccNo FROM Gurantor WHERE AccNo = '" & AccNo & "'"
        'cmd = New SqlCommand(sql, con)
        'reader = cmd.ExecuteReader
        'While reader.Read
        '    iterat = 1
        'End While

        'If iterat > 0 Then

        '    Try
        '        dbconnection()
        '        sql = "UPDATE Gurantor SET AccNo = @AccNo, Gfname = @Gfname, Glname=@Glname, Ggender= @Ggender, GDOB =@GDOB, GPhone=@GPhone, GOccupation=@GOccupation, GWorkplace=@GWorkplace, Gnationality=@Gnationality, GResidence = @GResidence, GRelateAs=@GRelateAs, GPhoto=@GPhoto WHERE AccNo  = @AccNo"
        '        cmd = New SqlCommand(sql, con)
        '        cmd.Parameters.AddWithValue("@AccNo", AccNo.Trim)
        '        cmd.Parameters.AddWithValue("@Gfname", Gfname.Trim)
        '        cmd.Parameters.AddWithValue("@Glname", Glname.Trim)
        '        cmd.Parameters.AddWithValue("@Ggender", Ggender)
        '        cmd.Parameters.AddWithValue("@GDOB", GDOB)
        '        cmd.Parameters.AddWithValue("@GPhone", GPhone)
        '        cmd.Parameters.AddWithValue("@GOccupation", GOccupation)
        '        cmd.Parameters.AddWithValue("@GWorkplace", GWorkplace.Trim)
        '        cmd.Parameters.AddWithValue("@Gnationality", Gnationality)
        '        cmd.Parameters.AddWithValue("@GResidence", GResidence.Trim)
        '        cmd.Parameters.AddWithValue("@GRelateAs", GRelateAs)

        '        Dim pp As New MemoryStream()
        '        GPhoto.Image.Save(pp, GPhoto.Image.RawFormat)
        '        Dim pdata As Byte() = pp.GetBuffer()
        '        Dim ppic As New SqlParameter("@GPhoto", SqlDbType.Image)
        '        ppic.Value = pdata
        '        cmd.ExecuteNonQuery()
        '        MessageBox.Show("Guarantor account created successfully", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information)

        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    Finally
        '        Connection_Close()
        '    End Try
        'Else
        Try
            dbconnection()
            sql = "INSERT INTO Gurantor(AccNo,amt, Gfname , Glname, Ggender , GDOB, GPhone, GOccupation, GWorkplace, Gnationality, GResidence, GRelateAs, GPhoto) VALUES(@AccNo,@amt ,@Gfname ,@Glname,@Ggender , @GDOB, @GPhone, @GOccupation, @GWorkplace, @Gnationality, @GResidence, @GRelateAs, @GPhoto)"

            cmd = New SqlClient.SqlCommand(sql, con)

            cmd.Parameters.AddWithValue("@AccNo ", AccNo.Trim)
            cmd.Parameters.AddWithValue("@amt", amt)
            cmd.Parameters.AddWithValue("@Gfname", Gfname.Trim)
            cmd.Parameters.AddWithValue("@Glname", Glname.Trim)
            cmd.Parameters.AddWithValue("@Ggender", Ggender.Trim.ToUpper)
            cmd.Parameters.AddWithValue("@GDOB", GDOB)
            cmd.Parameters.AddWithValue("GPhone", GPhone.Trim)
            cmd.Parameters.AddWithValue("@GOccupation", GOccupation.Trim)
            cmd.Parameters.AddWithValue("@GWorkplace", GWorkplace.Trim)
            cmd.Parameters.AddWithValue("@Gnationality", Gnationality.Trim.ToUpper)
            cmd.Parameters.AddWithValue("@GResidence", GResidence.Trim)
            cmd.Parameters.AddWithValue("@GRelateAs", GRelateAs.Trim.ToUpper)


            'ADDING PHOTO AND SIGNATURE

            Dim pp As New MemoryStream()
            GPhoto.Image.Save(pp, GPhoto.Image.RawFormat)
            Dim pdata As Byte() = pp.GetBuffer()
            Dim ppic As New SqlParameter("@GPhoto", SqlDbType.Image)
            ppic.Value = pdata
            cmd.Parameters.Add(ppic)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Guarantor account created successfully", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            Connection_Close()
        End Try




    End Sub


    Public Sub SerachGuarantor(num As String)
        Dim i As Integer
        Try

            dbconnection()
            sql = "SELECT * FROM Gurantor where AccNo = '" & num.Trim() & "'"
            cmd = New SqlCommand(sql, con)
            reader = cmd.ExecuteReader()
            While reader.Read
                i = 1
            End While
            If i > 0 Then
                'update the guarantor
            Else
                'perform insertion
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try

    End Sub


End Class

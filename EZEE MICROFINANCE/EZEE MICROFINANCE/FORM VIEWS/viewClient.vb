
Imports System.Data.SqlClient
Imports System.IO
Public Class viewClient
    Dim counter As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" And IsNumeric(TextBox1.Text.Trim) Then
            Try

                dbconnection()
                sql = "SELECT AccNo AS [ACCOUNT NUMBER], ClientLname + ' ' +  ClientFname + ' ' + ClientOname  AS [FULLNAME], ClientGender AS GENDER, ClientDOB AS [DATE OF BIRTH], ClientMaritalStatus AS [MARITAL STATUS], ClientSpouseName AS [SPOUSE NAME], ClientOccupation AS [OCCUPATION], ClientWorkplace AS [WORK PLACE], ClientPhoneNo AS [CONTACT], ClientEmail AS [EMAIL], ClientIDType AS [ID TYPE],ClientIDNo AS [ID NUMBER], ClientResidence AS [RESIDENCE ADDRESS], ClientYearJoin AS [ACCOUNT REGISTERED ON] FROM Clients WHERE  AccNo ='" & TextBox1.Text & "'"

                cmd = New SqlCommand(sql, con)
                dataAdapter = New SqlDataAdapter(cmd)
                Dim ds As DataSet = New DataSet()

                '---fill the dataset---
                dataAdapter.Fill(ds, sql)


                '---bind to the DataGridView control---
                DataGridView1.DataSource = ds
                '---set the table in the dataset to display---
                DataGridView1.DataMember = sql

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Connection_Close()
            End Try



        ElseIf TextBox1.Text.Trim <> "" And Char.IsLetter(TextBox1.Text) Then
            Try

                dbconnection()
                sql = "SELECT AccNo AS [ACCOUNT NUMBER], ClientLname + ' ' +  ClientFname + ' ' + ClientOname  AS [FULLNAME], ClientGender AS GENDER, ClientDOB AS [DATE OF BIRTH], ClientMaritalStatus AS [MARITAL STATUS], ClientSpouseName AS [SPOUSE NAME], ClientOccupation AS [OCCUPATION], ClientWorkplace AS [WORK PLACE], ClientPhoneNo AS [CONTACT], ClientEmail AS [EMAIL], ClientIDType AS [ID TYPE],ClientIDNo AS [ID NUMBER], ClientResidence AS [RESIDENCE ADDRESS], ClientYearJoin AS [ACCOUNT REGISTERED ON] FROM Clients WHERE  ClientLname LIKE'%" & TextBox1.Text & "%'"

                cmd = New SqlCommand(sql, con)
                dataAdapter = New SqlDataAdapter(cmd)
                Dim ds As DataSet = New DataSet()

                '---fill the dataset---
                dataAdapter.Fill(ds, sql)

                '---bind to the DataGridView control---
                DataGridView1.DataSource = ds
                '---set the table in the dataset to display---
                DataGridView1.DataMember = sql

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Connection_Close()
            End Try
        Else
            MsgBox("UNKNOWN ACCOUNT NAME OR NUMBER", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub viewClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pullRecordsFromClientTable()
        ''TextBox2.Text = counter
        TextBox2.Text = DataGridView1.RowCount.ToString()
    End Sub

    

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        'FF IS A MANIPULATION FROM DATA GRIDE
        Try

            txtAcctName.Text = DataGridView1(1, DataGridView1.CurrentRow.Index).Value
            txtAcctNumber.Text = DataGridView1(0, DataGridView1.CurrentRow.Index).Value

        Catch ex As Exception
            MsgBox("Empty row selected")
        End Try
    End Sub


    Private Sub countClient()

        Try
            dbconnection()
            sql = "select COUNT(ClientLname) from Clients"
            cmd = New SqlCommand(sql, con)
            reader = cmd.ExecuteReader
            While reader.Read
                counter += reader("COUNT(ClientLname)")
            End While
        Catch ex As Exception

        Finally
            Connection_Close()
        End Try

    End Sub

    Private Sub txtAcctNumber_TextChanged(sender As Object, e As EventArgs) Handles txtAcctNumber.TextChanged
        If txtAcctNumber.Text.Trim = "" Then
            Exit Sub
        Else
            Try
                dbconnection()
                sql = "SELECT ClientPhoto,ClientSignature FROM Clients WHERE AccNo='" & txtAcctNumber.Text.Trim & "'"
                cmd = New SqlClient.SqlCommand(sql, con)
                reader = cmd.ExecuteReader

                If reader.Read Then
                    'cast the picture data as byte()
                    data = DirectCast(reader("ClientPhoto"), Byte())
                    Dim ms As New MemoryStream(data)
                    PictureBox1.Image = Image.FromStream(ms)


                    'cast the picture data as byte()
                    data = DirectCast(reader("ClientSignature"), Byte())
                    Dim ss As New MemoryStream(data)

                    PictureBox2.Image = Image.FromStream(ss)



                End If

            Catch ex As Exception

        Finally
            Connection_Close()
        End Try
        End If
    End Sub


    'PULL ITEMS FROM DATABASE TABLE
    Private Sub pullRecordsFromClientTable()
        Try

            dbconnection()
            sql = "SELECT AccNo AS [ACCOUNT NUMBER], ClientLname + ' ' +  ClientFname + ' ' + ClientOname  AS [FULLNAME], ClientGender AS GENDER, ClientDOB AS [DATE OF BIRTH], ClientMaritalStatus AS [MARITAL STATUS], ClientSpouseName AS [SPOUSE NAME], ClientOccupation AS [OCCUPATION], ClientWorkplace AS [WORK PLACE], ClientPhoneNo AS [CONTACT], ClientEmail AS [EMAIL], ClientIDType AS [ID TYPE],ClientIDNo AS [ID NUMBER], ClientResidence AS [RESIDENCE ADDRESS], ClientYearJoin AS [ACCOUNT REGISTERED ON] FROM Clients"


            cmd = New SqlCommand(sql, con)
            dataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()

            '---fill the dataset---
            dataAdapter.Fill(ds, sql)


            '---bind to the DataGridView control---
            DataGridView1.DataSource = ds
            '---set the table in the dataset to display---
            DataGridView1.DataMember = sql
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try



        'FF IS A MANIPULATION FROM DATA GRIDE
        Try

            txtAcctName.Text = DataGridView1(1, DataGridView1.CurrentRow.Index).Value
            txtAcctNumber.Text = DataGridView1(0, DataGridView1.CurrentRow.Index).Value
            TextBox3.Text = DataGridView1(8, DataGridView1.CurrentRow.Index).Value
        Catch ex As Exception
            MsgBox("Empty row selected")
        End Try




    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        DataGridView1.Refresh()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try

            txtAcctName.Text = DataGridView1(1, DataGridView1.CurrentRow.Index).Value
            txtAcctNumber.Text = DataGridView1(0, DataGridView1.CurrentRow.Index).Value
            TextBox3.Text = DataGridView1(8, DataGridView1.CurrentRow.Index).Value
        Catch ex As Exception
            MsgBox("Empty row selected")
        End Try
    End Sub
End Class
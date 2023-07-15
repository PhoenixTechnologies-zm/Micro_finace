
Imports System.Data.SqlClient
Imports System.IO
Public Class viewEmployees

    Dim thecode As String = ""
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub viewEmployees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dbconnection()
            sql = "SELECT EmpCode AS CODE, EmpSurname + ' ' + EmpFirstName + ' ' + EmpOthername AS [FULL  NAME], EmpDateOfBirth AS [DATE OF BIRTH], EmpGender AS GENDER, EmpNationationality AS NATIONALITY, EmpDept AS DEPARTMENT, EmpPosition AS POSITION, EmpDateJoin AS [JOIN COMPANY ON], EmpContact AS CONTACT,EmpMaritalStatus AS [MARITAL STATUS], EmpSpouseName AS [SPOUSE NAME], EmpEmail AS EMAIL, ResAddress AS [RESIDENCE ADDRESS], RefName AS [REFEREE NAME],RefContact AS [REFEREE CONTACT], RefRelate AS [REFEREE RELATE AS] FROM Employee"
            cmd = New SqlCommand(sql, con)
            dataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()

            '---fill the dataset---
            dataAdapter.Fill(ds, sql)


            '---bind to the DataGridView control---
            DataGridView1.DataSource = ds
            '---set the table in the dataset to display---
            DataGridView1.DataMember = sql

            'SET RECORDS TO TEXTBOXES
            txtAcctName.Text = DataGridView1(1, DataGridView1.CurrentRow.Index).Value
            txtAcctNumber.Text = DataGridView1(5, DataGridView1.CurrentRow.Index).Value
            txtPhone.Text = DataGridView1(8, DataGridView1.CurrentRow.Index).Value

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try
        lblTotalEmployee.Text = DataGridView1.RowCount



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Trim = "" Then
            Exit Sub
        End If
        Try
            dbconnection()
            sql = "SELECT EmpCode AS CODE, EmpSurname + ' ' + EmpFirstName + ' ' + EmpOthername AS [FULL  NAME], EmpDateOfBirth AS [DATE OF BIRTH], EmpGender AS GENDER, EmpNationationality AS NATIONALITY, EmpDept AS DEPARTMENT, EmpPosition AS POSITION, EmpDateJoin AS [JOIN COMPANY ON], EmpContact AS CONTACT,EmpMaritalStatus AS [MARITAL STATUS], EmpSpouseName AS [SPOUSE NAME], EmpEmail AS EMAIL, ResAddress AS [RESIDENCE ADDRESS], RefName AS [REFEREE NAME],RefContact AS [REFEREE CONTACT], RefRelate AS [REFEREE RELATE AS] FROM Employee WHERE EmpCode='" & TextBox1.Text & "'"
            cmd = New SqlCommand(sql, con)
            dataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()

            '---fill the dataset---
            If dataAdapter.Fill(ds, sql) Then

          

                '---bind to the DataGridView control---
                DataGridView1.DataSource = ds
                '---set the table in the dataset to display---
                DataGridView1.DataMember = sql

                txtAcctName.Text = DataGridView1(1, DataGridView1.CurrentRow.Index).Value
                txtAcctNumber.Text = DataGridView1(5, DataGridView1.CurrentRow.Index).Value
                txtPhone.Text = DataGridView1(8, DataGridView1.CurrentRow.Index).Value

                MessageBox.Show("Record found", "EZEE MICROFINANCE", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("Record not found", "EZEE MICROFINANCE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                PictureBox1.Image = Nothing
                txtAcctName.Text = ""
                txtAcctNumber.Text = ""
                txtPhone.Text = ""
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Connection_Close()
        End Try


    End Sub

    Private Sub txtPhone_TextChanged(sender As Object, e As EventArgs) Handles txtPhone.TextChanged
       
        Try

            dbconnection()
            sql = "select Photo from Employee where  EmpContact = '" & txtPhone.Text.Trim & "'"
            cmd = New SqlClient.SqlCommand(sql, con)
            reader = cmd.ExecuteReader

            If reader.Read Then
                'cast the picture data as byte()
                data = DirectCast(reader("Photo"), Byte())
                Dim ms As New MemoryStream(data)
                PictureBox1.Image = Image.FromStream(ms)

            End If

        Catch ex As Exception

        Finally
            Connection_Close()
        End Try
    End Sub

  

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        'FF IS A MANIPULATION FROM DATA GRIDE
        Try

            txtAcctName.Text = DataGridView1(1, DataGridView1.CurrentRow.Index).Value
            txtAcctNumber.Text = DataGridView1(5, DataGridView1.CurrentRow.Index).Value
            txtPhone.Text = DataGridView1(8, DataGridView1.CurrentRow.Index).Value
        Catch ex As Exception
            MsgBox("Empty row selected")
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'FF IS A MANIPULATION FROM DATA GRIDE
        Try

            txtAcctName.Text = DataGridView1(1, DataGridView1.CurrentRow.Index).Value
            txtAcctNumber.Text = DataGridView1(5, DataGridView1.CurrentRow.Index).Value
            txtPhone.Text = DataGridView1(8, DataGridView1.CurrentRow.Index).Value
        Catch ex As Exception
            MsgBox("Empty row selected")
        End Try
    End Sub
End Class
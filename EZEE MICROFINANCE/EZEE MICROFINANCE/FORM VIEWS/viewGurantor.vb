Imports System.Data.SqlClient
Imports System.IO
Public Class viewGurantor

    Private Sub viewGurantor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            dbconnection()
            sql = "SELECT AccNo AS [ACCOUNT NUMBER], amt AS [OUTSTANDING BALANCE (GH₵)], Gfname + ' ' +  Glname AS [FULLNAME], Ggender AS GENDER, GDOB AS [ DATE OF BIRTH], GPhone AS CONTACT, GOccupation AS OCCUPATION, GWorkplace AS [WORK PALCE], Gnationality AS NATIONALITY, GResidence AS [RESIDENCE ADDRESS], GRelateAs AS [RELATED TO CLIENT AS] FROM Gurantor"

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
        Label5.Text = DataGridView1.RowCount
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
       


        'FF IS A MANIPULATION FROM DATA GRIDE
        Try

            txtAcctName.Text = DataGridView1(2, DataGridView1.CurrentRow.Index).Value
            txtAcctNumber.Text = DataGridView1(5, DataGridView1.CurrentRow.Index).Value

        Catch ex As Exception
            MsgBox("Empty row selected")
        End Try
    End Sub

    Private Sub txtAcctNumber_TextChanged(sender As Object, e As EventArgs) Handles txtAcctNumber.TextChanged
        Try

            dbconnection()
            sql = "select GPhoto from Gurantor where GPhone = '" & txtAcctNumber.Text.Trim & "'"
            cmd = New SqlClient.SqlCommand(sql, con)
            reader = cmd.ExecuteReader

            If reader.Read Then
                'cast the picture data as byte()
                data = DirectCast(reader("GPhoto"), Byte())
                Dim ms As New MemoryStream(data)
                PictureBox1.Image = Image.FromStream(ms)

            End If

        Catch ex As Exception

        Finally
            Connection_Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Trim = "" Then
            Exit Sub
        End If
        Try
            dbconnection()
            Dim cm As New SqlCommand("SELECT AccNo AS [ACCOUNT NUMBER], amt AS [OUTSTANDING BALANCE (GH₵)], Gfname + ' ' +  Glname AS [FULLNAME], Ggender AS GENDER, GDOB AS [ DATE OF BIRTH], GPhone AS CONTACT, GOccupation AS OCCUPATION, GWorkplace AS [WORK PALCE], Gnationality AS NATIONALITY, GResidence AS [RESIDENCE ADDRESS], GRelateAs AS [RELATED TO CLIENT AS] FROM Gurantor where AccNo = '" & TextBox1.Text & "'", con)

            'CREATE AN INSTANCE OF SQLDATAadapter
            Dim Adpt As New SqlDataAdapter(cm)

            Dim ds As New DataSet()
            If (Adpt.Fill(ds, sql)) Then
                DataGridView1.DataSource = ds.Tables(0)
                Try

                    txtAcctName.Text = DataGridView1(2, DataGridView1.CurrentRow.Index).Value
                    txtAcctNumber.Text = DataGridView1(5, DataGridView1.CurrentRow.Index).Value

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                MessageBox.Show("Record found")
            Else
                MessageBox.Show("Record not found")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Connection_Close()
        End Try
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'FF IS A MANIPULATION FROM DATA GRIDE

        If (e.RowIndex >= 0) Then
            Try

                txtAcctName.Text = DataGridView1(2, DataGridView1.CurrentRow.Index).Value
                txtAcctNumber.Text = DataGridView1(5, DataGridView1.CurrentRow.Index).Value

            Catch ex As Exception
                MsgBox("Empty row selected")
            End Try
        End If


    End Sub
End Class
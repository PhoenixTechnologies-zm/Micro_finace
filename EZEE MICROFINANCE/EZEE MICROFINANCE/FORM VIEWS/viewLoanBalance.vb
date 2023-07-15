Imports System.IO
Class viewLoanBalance
    Private clientClass As New clsClient

    Private Sub viewLoanBalance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dbconnection()
            sql = "SELECT LoanID as ID, AccNo AS [ACCOUNT NUMBER], currBalance AS [OUTSTANDING BALANCE] FROM LoanBalance"
            cmd = New SqlClient.SqlCommand(sql, con)
            dataAdapter = New SqlClient.SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()

            '---fill the dataset---
            dataAdapter.Fill(ds, sql)


            '---bind to the DataGridView control---
            DataGridView1.DataSource = ds
            '---set the table in the dataset to display---
            DataGridView1.DataMember = sql

            'ASSIGN VALUES TO TEXTBOXES
            Try

                txtAcctNum.Text = DataGridView1(1, DataGridView1.CurrentRow.Index).Value
                txtBalance.Text = DataGridView1(2, DataGridView1.CurrentRow.Index).Value

            Catch ex As Exception

            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtAcctName.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtAcctNum.TextChanged
        pullData()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        'FF IS A MANIPULATION FROM DATA GRIDE
        Try

            txtAcctNum.Text = DataGridView1(1, DataGridView1.CurrentRow.Index).Value
            txtBalance.Text = DataGridView1(2, DataGridView1.CurrentRow.Index).Value

        Catch ex As Exception
            MsgBox("Empty row selected")
        End Try
    End Sub

    'SUBS THAT PULL DATA FROM AS WELL AS IMAGES
    Private Sub pullData()
        If txtAcctNum.Text.Trim = "" Then
            Exit Sub
        Else
            Try
                dbconnection()
                sql = "SELECT ClientPhoto,ClientSignature FROM Clients WHERE AccNo='" & txtAcctNum.Text.Trim & "'"
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

                clientClass.searchAcctBalance(txtAcctNum.Text.Trim)
                txtAcctName.Text = actName

                'FF IS A MANIPULATION FROM DATA GRIDE
                Try

                    txtAcctNum.Text = DataGridView1(1, DataGridView1.CurrentRow.Index).Value
                    txtBalance.Text = DataGridView1(2, DataGridView1.CurrentRow.Index).Value

                Catch ex As Exception

                End Try
            Catch ex As Exception

            Finally
                Connection_Close()
            End Try
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'FF IS A MANIPULATION FROM DATA GRIDE
        Try

            txtAcctNum.Text = DataGridView1(1, DataGridView1.CurrentRow.Index).Value
            txtBalance.Text = DataGridView1(2, DataGridView1.CurrentRow.Index).Value

        Catch ex As Exception
            MsgBox("Empty row selected")
        End Try
    End Sub
End Class
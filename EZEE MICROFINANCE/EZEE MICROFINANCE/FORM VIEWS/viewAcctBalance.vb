Public Class viewAcctBalance
    Private clientClass As New clsClient
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        validateAcct(txtSearchAcctNumber)
        If err.GetError(txtSearchAcctNumber).Length <> 0 Then
            err.SetError(txtSearchAcctNumber, "Please enter numeric account")
        Else
            clientClass.searchAcctBalance(txtSearchAcctNumber.Text.Trim)
            txtAccNumber.Text = actNum
            txtAcctName.Text = actName
            txtBalance.Text = "GH₵ " & actBalance
            clientClass.clientSearch2(txtSearchAcctNumber.Text, PictureBox3, PictureBox2)
        End If
    End Sub

    Private Sub txtSearchAcctNumber_TextChanged(sender As Object, e As EventArgs) Handles txtSearchAcctNumber.TextChanged, txtSearchAcctNumber.Leave
        validateAcct(DirectCast(sender, Control))
    End Sub

    'Account
    Private Sub validateAcct(ctrl As Control)
        If txtSearchAcctNumber.Text.Trim = "" Or Not IsNumeric(txtSearchAcctNumber.Text) Then
            err.SetIconAlignment(txtSearchAcctNumber, ErrorIconAlignment.TopLeft)
            err.SetError(txtSearchAcctNumber, "Please enter numeric account")

        Else
            err.SetError(txtSearchAcctNumber, String.Empty)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub viewAcctBalance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dbconnection()
            sql = "SELECT AccNo  AS [ACCOUNT NUMBER], AccName AS [ACCOUNT NAME], OutBalance AS [OUTSTANDING BALANCE GH₵ ] FROM acctBalance"

            cmd = New SqlClient.SqlCommand(sql, con)
            dataAdapter = New SqlClient.SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()

            '---fill the dataset---
            dataAdapter.Fill(ds, sql)


            '---bind to the DataGridView control---
            DataGridView1.DataSource = ds
            '---set the table in the dataset to display---
            DataGridView1.DataMember = sql

            'FF IS A MANIPULATION FROM DATA GRIDE
            Try

                txtAccNumber.Text = DataGridView1(0, DataGridView1.CurrentRow.Index).Value
                txtAcctName.Text = DataGridView1(1, DataGridView1.CurrentRow.Index).Value
                txtBalance.Text = "GH₵ " & DataGridView1(2, DataGridView1.CurrentRow.Index).Value

            Catch ex As Exception

            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

   
    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        ''FF IS A MANIPULATION FROM DATA GRIDE
        'Try

        '    txtAccNumber.Text = DataGridView1(0, DataGridView1.CurrentRow.Index).Value
        '    txtAcctName.Text = DataGridView1(1, DataGridView1.CurrentRow.Index).Value
        '    txtBalance.Text = "GH₵ " & DataGridView1(2, DataGridView1.CurrentRow.Index).Value

        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub txtAccNumber_TextChanged(sender As Object, e As EventArgs) Handles txtAccNumber.TextChanged
        clientClass.clientSearch2(txtAccNumber.Text, PictureBox3, PictureBox2)

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'FF IS A MANIPULATION FROM DATA GRIDE
        Try

            txtAccNumber.Text = DataGridView1(0, DataGridView1.CurrentRow.Index).Value
            txtAcctName.Text = DataGridView1(1, DataGridView1.CurrentRow.Index).Value
            txtBalance.Text = "GH₵ " & DataGridView1(2, DataGridView1.CurrentRow.Index).Value

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
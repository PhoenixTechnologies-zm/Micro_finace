Public Class frmRestoreDB
    Private insertClass As New clsInsert
    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        If txtLocation.Text = "" Then
            MessageBox.Show("Please browse for file to restore")
            btnBrowse.Focus()
        Else
            insertClass.dbRes(txtLocation.Text)
        End If
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim openFileDialog As New OpenFileDialog
        openFileDialog.ShowDialog()
        If openFileDialog.FileName <> "" Then
            txtLocation.Text = openFileDialog.FileName
        End If
    End Sub
End Class
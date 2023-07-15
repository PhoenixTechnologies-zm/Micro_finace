Public Class frmBackup
    Private insertClass As New clsInsert
    Private Sub btnBackUp_Click(sender As Object, e As EventArgs) Handles btnBackUp.Click
        If txtLocation.Text = "" Then
            MessageBox.Show("Please browse for location you would want to save back-up file")
            btnBrowse.Focus()
        Else
            insertClass.dbBackup(txtLocation.Text)

        End If
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim openFolderDialog As New FolderBrowserDialog
        openFolderDialog.Description = "Select back-up path"
        openFolderDialog.RootFolder = Environment.SpecialFolder.MyComputer
        openFolderDialog.ShowNewFolderButton = False

        Dim dlgResult As DialogResult = openFolderDialog.ShowDialog()

        If dlgResult = Windows.Forms.DialogResult.OK Then
            txtLocation.Text = openFolderDialog.SelectedPath
        End If
    End Sub
End Class
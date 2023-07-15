Public Class frmSplashScreen

    Private Sub frmSplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Label1.Text = "Ezee Microfinance © 2016 - " & LoadDate.Value.Date.Year

    End Sub
End Class
Public Class frmSetRate
    Private insertClass As New clsInsert
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtRate.TextChanged, txtRate.Leave
        validateRateName(DirectCast(sender, Control))
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtValue.TextChanged, txtValue.Leave
        validatRateValue(DirectCast(sender, Control))
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles txtTax.TextChanged, txtTax.Leave
        validateTax(DirectCast(sender, Control))
    End Sub



    Private Sub validateRateName(ctrl As Control)
        If txtRate.Text.Trim = "" Then
            err.SetIconAlignment(txtRate, ErrorIconAlignment.BottomLeft)
            err.SetError(txtRate, "Please enter rates")
            txtRate.Focus()
        Else
            err.SetError(txtRate, String.Empty)
        End If
    End Sub


    Private Sub validatRateValue(ctrl As Control)
        If ((txtValue.Text.Trim = "" Or txtRate.Text.Trim <> "") And Not IsNumeric(txtValue.Text)) Then
            err.SetIconAlignment(txtValue, ErrorIconAlignment.BottomLeft)
            err.SetError(txtValue, "Please enter rates value")
            txtValue.Focus()
        Else
            err.SetError(txtValue, String.Empty)
        End If
    End Sub


    Private Sub validateTaxName(ctrl As Control)
        If txtTaxName.Text.Trim = "" Then
            err.SetIconAlignment(txtTaxName, ErrorIconAlignment.BottomLeft)
            err.SetError(txtTaxName, "Please enter tax name")
            txtTaxName.Focus()
        Else
            err.SetError(txtTaxName, String.Empty)
        End If
    End Sub


    Private Sub validateTax(ctrl As Control)
        If ((txtTax.Text.Trim = "" Or txtTax.Text.Trim <> "") And Not IsNumeric(txtTax.Text)) Then
            err.SetIconAlignment(txtTax, ErrorIconAlignment.BottomLeft)
            err.SetError(txtTax, "Please enter tax value")
            txtTax.Focus()
        Else
            err.SetError(txtTax, String.Empty)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        validateRateName(txtRate)
        validatRateValue(txtValue)
        validateTaxName(txtTaxName)
        validateTax(txtValue)
        With err
            If .GetError(txtRate).Length <> 0 Then
                .SetError(txtRate, "Please enter rates")
            ElseIf .GetError(txtValue).Length <> 0 Then
                .SetError(txtTax, "Please enter rate value")
            ElseIf .GetError(txtTaxName).Length <> 0 Then
                .SetError(txtRate, "Please enter tax name")
            ElseIf .GetError(txtTax).Length <> 0 Then
                .SetError(txtTax, "Please enter tax value")
            Else
                insertClass.insertToRateTable(txtRate.Text.ToUpper(), txtValue.Text, txtTaxName.Text.ToUpper(), txtTax.Text)
                clearAll()
            End If
        End With
    End Sub

    Private Sub clearAll()
        txtRate.ResetText()
        txtValue.ResetText()
        txtTax.ResetText()
        txtTaxName.ResetText()
        With err
            .SetError(txtRate, String.Empty)
            .SetError(txtValue, String.Empty)
            .SetError(txtTax, String.Empty)
            .SetError(txtTaxName, String.Empty)
        End With

    End Sub

    Private Sub frmSetRate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clearAll()
    End Sub

    Private Sub txtTaxName_TextChanged(sender As Object, e As EventArgs) Handles txtTaxName.TextChanged, txtTaxName.Leave
        validateTaxName(DirectCast(sender, Control))

    End Sub
End Class
Module modConnect

    'OPEN CONNECTION BY METHOD CALL
    Public Sub dbconnection()
        con = New System.Data.SqlClient.SqlConnection(dbPath)
        Try
            con.Open()

        Catch ex As Exception
            MsgBox("Can not open connection !", MsgBoxStyle.Exclamation)
        End Try
    End Sub


    'CLOSE CONNECTION BY METHOD CALL
    Public Sub Connection_Close()
        con.Close()
    End Sub

    Public Sub formConnectDB()
        con = New System.Data.SqlClient.SqlConnection(dbPath)
        Try
            con.Open()

        Catch ex As Exception
            MsgBox("Can not open connection !")
            End
        Finally
            con.Close()
        End Try
    End Sub
End Module

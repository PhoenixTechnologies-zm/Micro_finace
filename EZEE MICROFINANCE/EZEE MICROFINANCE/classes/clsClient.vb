
Imports System.Data.SqlClient
Imports System.IO
Public Class clsClient

    Public Names As String
    Public num As String
    Public taxName As String
    Public taxValue As Double
    Public RatesVal As Double

    Public Rval As Double
    Public Tval As Double

    Public Sub AddClients(AccNo As String, ClientLname As String, ClientFname As String, ClientOname As String, ClientGender As String, ClientDOB As Date, ClientMaritalStatus As String, ClientSpouseName As String, ClientOccupation As String, ClientCompanyName As String, ClientPhoneNo As String, ClientEmail As String, ClientIDType As String, ClientIDNo As String, ClientResidence As String, ClientYearJoin As Date, ClientPhoto As PictureBox, ClientSignature As PictureBox)

        Try
            dbconnection()
            sql = "INSERT INTO Clients(AccNo, ClientLname, ClientFname, ClientOname , ClientGender, ClientDOB, ClientMaritalStatus, ClientSpouseName, ClientOccupation, ClientWorkplace, ClientPhoneNo, ClientEmail, ClientIDType, ClientIDNo, ClientResidence,ClientYearJoin , ClientPhoto, ClientSignature) VALUES(@AccNo,@ClientLname,@ClientFname,@ClientOname ,@ClientGender,@ClientDOB,@ClientMaritalStatus,@ClientSpouseName,@ClientOccupation,@ClientWorkplace,@ClientPhoneNo,@ClientEmail,@ClientIDType,@ClientIDNo,@ClientResidence,@ClientYearJoin ,@ClientPhoto,@ClientSignature)"

            cmd = New SqlClient.SqlCommand(sql, con)

            cmd.Parameters.AddWithValue("@AccNo ", AccNo.Trim)
            cmd.Parameters.AddWithValue("@ClientLname", ClientLname.Trim)
            cmd.Parameters.AddWithValue("@ClientFname", ClientFname.Trim)
            cmd.Parameters.AddWithValue("@ClientOname", ClientOname.Trim)
            cmd.Parameters.AddWithValue("@ClientGender", ClientGender.Trim)
            cmd.Parameters.AddWithValue("@ClientDOB", ClientDOB)
            cmd.Parameters.AddWithValue("@ClientMaritalStatus", ClientMaritalStatus.Trim)
            cmd.Parameters.AddWithValue("@ClientSpouseName", ClientSpouseName.Trim)
            cmd.Parameters.AddWithValue("@ClientOccupation", ClientOccupation.Trim)
            cmd.Parameters.AddWithValue("@ClientWorkplace", ClientCompanyName.Trim)
            cmd.Parameters.AddWithValue("@ClientPhoneNo", ClientPhoneNo.Trim)
            cmd.Parameters.AddWithValue("@ClientEmail", ClientEmail.Trim)
            cmd.Parameters.AddWithValue("@ClientIDType", ClientIDType.Trim)
            cmd.Parameters.AddWithValue("@ClientIDNo", ClientIDNo.Trim)
            cmd.Parameters.AddWithValue("@ClientResidence", ClientResidence.Trim)
            cmd.Parameters.AddWithValue("@ClientYearJoin", ClientYearJoin)

            'ADDING PHOTO AND SIGNATURE

            Dim pp As New MemoryStream()
            ClientPhoto.Image.Save(pp, ClientPhoto.Image.RawFormat)
            Dim pdata As Byte() = pp.GetBuffer()
            Dim ppic As New SqlParameter("@ClientPhoto", SqlDbType.Image)
            ppic.Value = pdata
            cmd.Parameters.Add(ppic)

            Dim ss As New MemoryStream()
            ClientSignature.Image.Save(ss, ClientSignature.Image.RawFormat)
            Dim sdata As Byte() = ss.GetBuffer()
            Dim spic As New SqlParameter("@ClientSignature", SqlDbType.Image)
            spic.Value = sdata
            cmd.Parameters.Add(spic)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Client  account created successfully", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try

    End Sub

    '================
    ' NEXT OF KIN  ||
    '================
    Public Sub AddNextOfKin(AccNo As String, NTKinFullName As String, NTKinGender As String, NTKinDOB As Date, NTKinContact As String)

        '' yet
        Try
            dbconnection()
            Dim sqlStatement As String = "INSERT INTO NextOfKin(AccNo, NTKinFullName, NTKinGender,NTKinDOB,NTKinContact) VALUES(@AccNo,@NTKinFullName,@NTKinGender,@NTKinDOB,@NTKinContact)"
            cmd = New SqlCommand(sqlStatement, con)
            cmd.Parameters.AddWithValue("@AccNo", AccNo.Trim)
            cmd.Parameters.AddWithValue("@NTKinFullName", NTKinFullName.Trim)
            cmd.Parameters.AddWithValue("@NTKinGender", NTKinGender.Trim)
            cmd.Parameters.AddWithValue("@NTKinDOB", NTKinDOB)
            cmd.Parameters.AddWithValue("@NTKinContact", NTKinContact.Trim)
            cmd.ExecuteNonQuery()
            MsgBox("Next-of-kin successfully  created")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try

    End Sub


    '====================
    ' ACCOUNT TABLE    ||
    '====================


    Public Sub CreateAcctHolder(num As String, names As String, amt As Double)
        Try
            dbconnection()
            sql = "insert into acctBalance(AccNo,AccName,OutBalance) values(@AccNo, @AccName, @OutBalance)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@AccNo", num.Trim)
            cmd.Parameters.AddWithValue("@AccName", names.Trim)
            cmd.Parameters.AddWithValue("@OutBalance", amt)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try

    End Sub






    Public Sub createAccount(AccNo As String, AccName As String, AcctType As String, ClientPhoto As PictureBox, ClientSignature As PictureBox)

        Try
            dbconnection()
            Dim sqlStatement As String = "INSERT INTO AcctDetails(AccNo,AccName,AcctType, ClientPhoto,ClientSignature) VALUES(@AccNo,@AccName,@AcctType,@ClientPhoto,@ClientSignature)"
            cmd = New SqlCommand(sqlStatement, con)
            cmd.Parameters.AddWithValue("@AccNo", AccNo.Trim)
            cmd.Parameters.AddWithValue("@AccName", AccName.Trim)
            cmd.Parameters.AddWithValue("@acctType ", AcctType.Trim)

            'ADDING PHOTO AND SIGNATURE

            Dim pp As New MemoryStream()
            ClientPhoto.Image.Save(pp, ClientPhoto.Image.RawFormat)
            Dim pdata As Byte() = pp.GetBuffer()
            Dim ppic As New SqlParameter("@ClientPhoto", SqlDbType.Image)
            ppic.Value = pdata
            cmd.Parameters.Add(ppic)

            Dim ss As New MemoryStream()
            ClientSignature.Image.Save(ss, ClientSignature.Image.RawFormat)
            Dim sdata As Byte() = ss.GetBuffer()
            Dim spic As New SqlParameter("@ClientSignature", SqlDbType.Image)
            spic.Value = sdata
            cmd.Parameters.Add(spic)
            cmd.ExecuteNonQuery()
            MsgBox("Account successfully created")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try

    End Sub


    'SELECT CLIENT BY WAY OF FILTER
    Public Sub searchClient(acct As String)
        Try
            'open connection
            dbconnection()
            sql = "SELECT AccName,AccNo from AcctDetails WHERE AccNo = '" & acct & "'"
            cmd = New SqlCommand(sql, con)
            reader = cmd.ExecuteReader()

            If reader.Read Then
                Names = reader("AccName")
                num = reader("AccNo")
            Else
                Names = ""
                num = ""
                frmAccessLoan.txtMonthlyRepay.Text = ""
                MsgBox("Unknown Account number!", MsgBoxStyle.Exclamation)

            End If

        Catch ex As Exception
            MsgBox(ex.Message & Environment.NewLine & "Please contact the developer")

        Finally
            Connection_Close()
        End Try
    End Sub


    Public Sub clientSearch2(acct As String, signatures As PictureBox, Photos As PictureBox)

        Try
            dbconnection()
            Dim se As String = "SELECT  ClientPhoto, ClientSignature from AcctDetails WHERE AccNo = '" & acct & "'"
            cmd = New SqlCommand(se, con)
            reader = cmd.ExecuteReader()

            If reader.Read() Then
                'cast the picture data as byte()
                data = DirectCast(reader("ClientPhoto"), Byte())
                Dim ms As New MemoryStream(data)
                Photos.Image = Image.FromStream(ms)

                'cast the picture data as byte()
                data = DirectCast(reader("ClientSignature"), Byte())
                Dim ss As New MemoryStream(data)
                signatures.Image = Image.FromStream(ss)
            Else
                Photos.Image = Nothing
                signatures.Image = Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try
    End Sub


    'GET LOANS CORESPONDING VALUES

    Public Sub loanVal(comloan As ComboBox)

        Try

            dbconnection()
            sql = "SELECT RateValue,TaxName,TaxValue FROM Rates WHERE RateName = '" + comloan.Text & "'"
            cmd = New SqlCommand(sql, con)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                RatesVal = String.Format("{0:n2}", reader("RateValue"))
                taxName = reader("TaxName")
                taxValue = String.Format("{0:n2}", reader("TaxValue"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            Connection_Close()
        End Try
    End Sub


    'GET LOAN NAME
    Public Sub callLoanName(combLoanType As ComboBox)

        Try
            dbconnection()
            sql = "SELECT RateName FROM Rates"
            cmd = New SqlCommand(sql, con)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                With combLoanType
                    .Items.Add(reader("RateName"))
                    .SelectedIndex = 0
                End With
            End While

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            Connection_Close()
        End Try
    End Sub


   

    Public Sub CalcInterest(intRate As Double, Tax As Double, Amt As Double, yrNum As NumericUpDown)
       

        'GET THE DECIMAL VALUE OF RATE
        Rates = intRate / 100
        taxRate = Tax / 100
        Principal = Amt
        Times = (yrNum.Value * 12) ' CONVERT THE YEARS TO MONTH

        'VALUES
        Rval = String.Format("{0:n3}", (Rates * Principal))
        Tval = String.Format("{0:n3}", (taxRate * Principal))


        'Interests = Principal * Rates * yrNum.Value * taxRate
        Interests = Rval + Tval + Principal


        '+ Principal
        Total = Interests

        'SPREAD THE AMOUNT OVER THE PERIOD
        MonthlyRepay = String.Format("{0:n3}", (Total) / Times)

    End Sub


    Public Sub InsertToLoanTable(AccNo As String, AccName As String, LoanAmt As Double, RateName As String, RateValue As Double, TaxName As String, TaxValue As Double, TotalPay As Double, LoanTakenDate As String, LoanTakenTime As String, Durations As Date, GurantorContact As String, Empcode As String)
        Try

            dbconnection()
            sql = "INSERT INTO Loans(AccNo,AccName, LoanAmt,RateName,RateValue,TaxName,TaxValue,TotalPay,LoanTakenDate,LoanTakenTime,Durations,GurantorContact,Empcode) VALUES(@AccNo,@AccName, @LoanAmt,@RateName,@RateValue,@TaxName,@TaxValue,@TotalPay,@LoanTakenDate,@LoanTakenTime,@Durations,@GurantorContact,@Empcode)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@AccNo", AccNo.Trim)
            cmd.Parameters.AddWithValue("@AccName", AccName.Trim)
            cmd.Parameters.AddWithValue("@LoanAmt", LoanAmt)
            cmd.Parameters.AddWithValue("@RateName", RateName.Trim)
            cmd.Parameters.AddWithValue("@RateValue", RateValue)
            cmd.Parameters.AddWithValue("@TaxName", TaxName.Trim)
            cmd.Parameters.AddWithValue("@TaxValue", TaxValue)
            cmd.Parameters.AddWithValue("@TotalPay", TotalPay)
            cmd.Parameters.AddWithValue("@LoanTakenDate", LoanTakenDate)
            cmd.Parameters.AddWithValue("@LoanTakenTime", LoanTakenTime)
            cmd.Parameters.AddWithValue("@Durations", Durations)
            cmd.Parameters.AddWithValue("@GurantorContact", GurantorContact.Trim)
            cmd.Parameters.AddWithValue("@Empcode", Empcode.Trim)
            cmd.ExecuteNonQuery()
            MsgBox("Loan access executed successfully", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try
    End Sub



    Public Sub InsertToLoanBalance(AccNo As String, currBalance As Double)
        Try
            dbconnection()

            sql = "SELECT currBalance FROM LoanBalance where AccNo = '" & AccNo & "'"
            cmd = New SqlCommand(sql, con)
            reader = cmd.ExecuteReader
            While reader.Read()
                Loops = 1
            End While

            'found
            If Loops > 0 Then
                Try
                    dbconnection()
                    Dim UpdatesNoneLoanTables As String = "UPDATE LoanBalance SET currBalance = '" & currBalance & "' WHERE AccNo = '" & AccNo & "'"
                    cmd = New SqlCommand(UpdatesNoneLoanTables, con)
                    cmd.ExecuteNonQuery()
                    MsgBox("Update  made successfully", MsgBoxStyle.Information)
                Catch ex As Exception
                    MsgBox("Update " & ex.ToString)
                Finally
                    Connection_Close()
                End Try

                'CUSTOMER HAS NEVER TAKEN LOAN
            Else

                Try
                    dbconnection()
                    sql = "INSERT INTO LoanBalance(AccNo, currBalance) VALUES(@AccNo, @currBalance)"
                    cmd = New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@AccNo", AccNo.Trim)
                    cmd.Parameters.AddWithValue("@currBalance", currBalance)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    Connection_Close()
                End Try

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try
       




    End Sub


    'TAKEN TRACK OF LOAN REPAYMENT
    Public Sub LoanTransaction(ReceiptNo As String, AccNo As String, AccName As String, PayDate As Date, PayTime As DateTimePicker, AmtPaid As Double, TransBy As String, TransContact As String, EmpCode As String)
        Try
            dbconnection()
            sql = "INSERT INTO LoanPayment(ReceiptNo, AccNo, AccName, PayDate, PayTime, AmtPaid, TransBy, TransContact, EmpCode) VALUES(@ReceiptNo,@AccNo,@AccName,@PayDat,@PayTime,@AmtPaid,@TransBy,@TransContact,@EmpCode)"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@ReceiptNo", ReceiptNo.Trim)
            cmd.Parameters.AddWithValue("@AccNo", AccNo.Trim)
            cmd.Parameters.AddWithValue("@AccName", AccName.Trim)
            cmd.Parameters.AddWithValue("@PayDat", PayDate)
            cmd.Parameters.AddWithValue("@PayTime", PayTime.Value.ToShortTimeString)
            cmd.Parameters.AddWithValue("@AmtPaid", AmtPaid)
            cmd.Parameters.AddWithValue("@TransBy", TransBy.Trim)

            cmd.Parameters.AddWithValue("@TransContact", TransContact.Trim)
            cmd.Parameters.AddWithValue("@EmpCode", EmpCode.Trim)
            cmd.ExecuteNonQuery()
            MsgBox("Payment sucessfully taken", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try

    End Sub



    Public Sub searchAcctBalance(acctNo As String)

        Try
            dbconnection()
            sql = "select * from acctBalance Where AccNo = '" & acctNo & "'"
            cmd = New SqlCommand(sql, con)
            reader = cmd.ExecuteReader
            If reader.Read Then

                actName = reader("AccName")
                actNum = reader("AccNo")
                actBalance = CDbl(reader("OutBalance"))
            Else
                actName = ""
                actNum = ""
                actBalance = 0
                MsgBox("Unknown Account number!", MsgBoxStyle.Exclamation)

            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub searchLoanBalance(acctNo As String)
        Try
            dbconnection()
            sql = "select * from LoanBalance Where AccNo = '" & acctNo & "'"
            cmd = New SqlCommand(sql, con)
            reader = cmd.ExecuteReader
            While reader.Read
                iterat = 1
            End While

            If iterat > 0 Then

                Try
                    'SEARCH FOR ACCT NAME AND USE CONCARTENATE IT TO ACCT NUMBER
                    sql = "select AccName from AcctBalance Where AccNo = '" & acctNo & "'"
                    cmd = New SqlCommand(sql, con)
                    reader = cmd.ExecuteReader
                    If reader.Read Then
                        actName = reader("AccName")
                        acctNo = reader("AccNo")
                        actBalance = reader("currBalance")
                    Else
                        actName = ""
                        actNum = ""
                        actBalance = 0
                    End If
                    MsgBox("Unknown Account number!", MsgBoxStyle.Exclamation)

                Catch ex As Exception


                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Connection_Close()
        End Try


    End Sub
End Class

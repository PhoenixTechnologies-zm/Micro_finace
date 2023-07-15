
Imports System.IO
Public Class frmMain
    Dim bakup As New frmBackup
    Dim restor As New frmRestoreDB
    Public Clocks As New DateTime

    Private Sub BackupDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupDatabaseToolStripMenuItem.Click
        Try
            dbconnection()
            'CREATE DIRECTORY IF NOT EXIST
            If Not Directory.Exists("C:\Temp_Ezee") Then
                Directory.CreateDirectory("C:\Temp_Ezee")
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "BACKUP DATABASE EzeeDB TO DISK = 'C:\Temp_Ezee\EzeeDB.BAK'"
                cmd.Connection = con
                cmd.ExecuteNonQuery()
                MessageBox.Show("database backup successfully to C:\Temp_Ezee\EzeeDB.BAK", "Backup Database - Ezee Microfinance", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "BACKUP DATABASE EzeeDB TO DISK = 'C:\Temp_Ezee\EzeeDB.BAK'"
                cmd.Connection = con
                cmd.ExecuteNonQuery()
                MessageBox.Show("database backup successfully to C:\Temp_Ezee\EzeeDB.BAK", "Backup Database - Ezee Microfinance", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message & Environment.NewLine & "Please contact the developer", " Database Backup Error -Ezee Microfinance", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Finally
            Connection_Close()
        End Try

    End Sub

    Private Sub RestoreDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'restor.MdiParent = Me
        'restor.Show()
    End Sub

    Private Sub DailyTransactionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DailyTransactionToolStripMenuItem.Click
        Dim dailys As New rtDailyTrans
        dailys.MdiParent = Me
        dailys.Show()
    End Sub

    Private Sub EmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeToolStripMenuItem.Click
        Dim employe As New frmEmployee
        employe.MdiParent = Me
        employe.Show()
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        Dim cretusr As New frmCreateAppUsers
        cretusr.MdiParent = Me
        cretusr.Show()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Clocks = DateTime.Now
        ydate.Text = Clocks.ToString("F")

    End Sub

    Private Sub ToolStripStatusLabel6_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel6.Click
        Try
            Process.Start("mailto:agbenuwisdoms@gmail.com")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim Users As New frmUsers

        Users.Show()
    End Sub

    Private Sub RatingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RatingToolStripMenuItem.Click
        Dim rating As New frmSetRate
        rating.MdiParent = Me
        rating.Show()
    End Sub

    Private Sub AddClientToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddClientToolStripMenuItem.Click
        Dim clientsform As New frmClient
        clientsform.MdiParent = Me
        clientsform.Show()
    End Sub

    Private Sub AccessLoanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccessLoanToolStripMenuItem.Click
        Dim accessloan As New frmAccessLoan
        frmGurantor.EmpName = Me.yourName.Text
        accessloan.MdiParent = Me
        accessloan.Show()
    End Sub

    Private Sub PayLoanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PayLoanToolStripMenuItem.Click


        Dim payLoan As New frmLoanPay
        payLoan.Uname = Me.yourName.Text.Trim()
        payLoan.MdiParent = Me
        payLoan.Show()
    End Sub

    Private Sub DepositWithdrawToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DepositWithdrawToolStripMenuItem.Click
        Dim Transactions As New frmTransactions
        Transactions.MdiParent = Me
        Transactions.Show()
    End Sub

    Private Sub IDTypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IDTypeToolStripMenuItem.Click
        Dim idType As New frmIDType
        idType.MdiParent = Me
        idType.Show()
    End Sub

    Private Sub WithdrawToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WithdrawToolStripMenuItem.Click
        Dim wdraw As New frmWithdraw

        wdraw.MdiParent = Me
        wdraw.Show()

    End Sub

    Private Sub UpdateClientInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateClientInfoToolStripMenuItem.Click
        Dim upClients As New upClient
        upClients.MdiParent = Me
        upClients.Show()
    End Sub

    Private Sub UpdateEmployeeInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateEmployeeInfoToolStripMenuItem.Click
        Dim upEmployees As New upEmployee
        upEmployees.MdiParent = Me
        upEmployees.Show()
    End Sub

    Private Sub UpdatePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdatePasswordToolStripMenuItem.Click
        Dim updatePass As New upPassword
        updatePass.MdiParent = Me
        updatePass.Show()
    End Sub

    Private Sub RatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RatesToolStripMenuItem.Click
        Dim viewRates As New viewRatings
        viewRates.MdiParent = Me
        viewRates.Show()
    End Sub

    Private Sub ViewDepartmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDepartmentToolStripMenuItem.Click
        Dim viewDepts As New viewDept
        viewDepts.MdiParent = Me
        viewDepts.Show()
    End Sub

    Private Sub EmployeeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EmployeeToolStripMenuItem1.Click
        Dim viewEmp As New viewEmployees
        viewEmp.MdiParent = Me
        viewEmp.Show()
    End Sub

    Private Sub ViewClientToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewClientToolStripMenuItem.Click
        Dim vClient As New viewClient
        vClient.MdiParent = Me
        vClient.Show()

    End Sub

    Private Sub ViewGuarantorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewGuarantorToolStripMenuItem.Click
        Dim vGuarantor As New viewGurantor
        vGuarantor.MdiParent = Me
        vGuarantor.Show()
    End Sub

    Private Sub ViewNextOfKinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewNextOfKinToolStripMenuItem.Click
        Dim vNextOfKin As New viewNextOfKin
        vNextOfKin.MdiParent = Me
        vNextOfKin.Show()
    End Sub

    Private Sub ViewDailyTransactionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDailyTransactionToolStripMenuItem.Click
        Dim vDailyTrans As New viewDailyTransactions
        vDailyTrans.MdiParent = Me
        vDailyTrans.Show()
    End Sub

    Private Sub ViewAccountBalanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewAccountBalanceToolStripMenuItem.Click
        Dim vAccountBalance As New viewAcctBalance
        vAccountBalance.MdiParent = Me
        vAccountBalance.Show()

    End Sub

    Private Sub ViewRatingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewRatingToolStripMenuItem.Click
        Dim vRatings As New viewRatings
        vRatings.MdiParent = Me
        vRatings.Show()
    End Sub

    Private Sub ViewLoanBalanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewLoanBalanceToolStripMenuItem.Click
        Dim vLoanBalance As New viewLoanBalance
        vLoanBalance.MdiParent = Me
        vLoanBalance.Show()
    End Sub

    Private Sub ViewLoanHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewLoanHistoryToolStripMenuItem.Click
        Dim vLoanHistory As New viewLoanHistory
        vLoanHistory.MdiParent = Me
        vLoanHistory.Show()
    End Sub

    Private Sub ViewLoanBalanceToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Dim vLoanBalance As New viewLoanBalance
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim helps As New frmHelp
        helps.MdiParent = Me
        helps.Show()


    End Sub

    Private Sub DepartmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DepartmentToolStripMenuItem.Click
        Dim dept As New frmDepartment
        dept.MdiParent = Me
        dept.Show()

    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click

        Me.Close()
    End Sub
End Class
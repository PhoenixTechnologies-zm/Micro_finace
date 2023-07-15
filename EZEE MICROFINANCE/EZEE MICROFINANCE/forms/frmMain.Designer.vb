<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateEmployeeInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdatePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DepartmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RatingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IDTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewDepartmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddClientToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateClientInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewClientToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewGuarantorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewNextOfKinToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccessLoanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PayLoanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DepositWithdrawToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WithdrawToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewsToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewDailyTransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewAccountBalanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewRatingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewLoanBalanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewLoanHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DailyTransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackupRestoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackupDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.yourName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ydate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.CreateNewToolStripMenuItem, Me.TransToolStripMenuItem, Me.ReportToolStripMenuItem, Me.BackupRestoreToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(811, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.ViewsToolStripMenuItem, Me.LogoutToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmployeeToolStripMenuItem, Me.UserToolStripMenuItem, Me.DepartmentToolStripMenuItem, Me.RatingToolStripMenuItem, Me.IDTypeToolStripMenuItem})
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.NewToolStripMenuItem.Text = "Add New"
        '
        'EmployeeToolStripMenuItem
        '
        Me.EmployeeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateEmployeeInfoToolStripMenuItem})
        Me.EmployeeToolStripMenuItem.Name = "EmployeeToolStripMenuItem"
        Me.EmployeeToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.EmployeeToolStripMenuItem.Text = "Employee"
        '
        'UpdateEmployeeInfoToolStripMenuItem
        '
        Me.UpdateEmployeeInfoToolStripMenuItem.Name = "UpdateEmployeeInfoToolStripMenuItem"
        Me.UpdateEmployeeInfoToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.UpdateEmployeeInfoToolStripMenuItem.Text = "Update Employee Info."
        '
        'UserToolStripMenuItem
        '
        Me.UserToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdatePasswordToolStripMenuItem})
        Me.UserToolStripMenuItem.Name = "UserToolStripMenuItem"
        Me.UserToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.UserToolStripMenuItem.Text = "User"
        '
        'UpdatePasswordToolStripMenuItem
        '
        Me.UpdatePasswordToolStripMenuItem.Name = "UpdatePasswordToolStripMenuItem"
        Me.UpdatePasswordToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.UpdatePasswordToolStripMenuItem.Text = "Update Password"
        '
        'DepartmentToolStripMenuItem
        '
        Me.DepartmentToolStripMenuItem.Name = "DepartmentToolStripMenuItem"
        Me.DepartmentToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.DepartmentToolStripMenuItem.Text = "Department"
        '
        'RatingToolStripMenuItem
        '
        Me.RatingToolStripMenuItem.Name = "RatingToolStripMenuItem"
        Me.RatingToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.RatingToolStripMenuItem.Text = "Rating"
        '
        'IDTypeToolStripMenuItem
        '
        Me.IDTypeToolStripMenuItem.Name = "IDTypeToolStripMenuItem"
        Me.IDTypeToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.IDTypeToolStripMenuItem.Text = "ID-Type"
        '
        'ViewsToolStripMenuItem
        '
        Me.ViewsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RatesToolStripMenuItem, Me.ViewDepartmentToolStripMenuItem, Me.EmployeeToolStripMenuItem1})
        Me.ViewsToolStripMenuItem.Name = "ViewsToolStripMenuItem"
        Me.ViewsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ViewsToolStripMenuItem.Text = "Views"
        '
        'RatesToolStripMenuItem
        '
        Me.RatesToolStripMenuItem.Name = "RatesToolStripMenuItem"
        Me.RatesToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.RatesToolStripMenuItem.Text = "View Rates"
        '
        'ViewDepartmentToolStripMenuItem
        '
        Me.ViewDepartmentToolStripMenuItem.Name = "ViewDepartmentToolStripMenuItem"
        Me.ViewDepartmentToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ViewDepartmentToolStripMenuItem.Text = "View Department"
        '
        'EmployeeToolStripMenuItem1
        '
        Me.EmployeeToolStripMenuItem1.Name = "EmployeeToolStripMenuItem1"
        Me.EmployeeToolStripMenuItem1.Size = New System.Drawing.Size(165, 22)
        Me.EmployeeToolStripMenuItem1.Text = "View Employee"
        '
        'CreateNewToolStripMenuItem
        '
        Me.CreateNewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddClientToolStripMenuItem, Me.ViewsToolStripMenuItem1})
        Me.CreateNewToolStripMenuItem.Name = "CreateNewToolStripMenuItem"
        Me.CreateNewToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.CreateNewToolStripMenuItem.Text = "Client"
        '
        'AddClientToolStripMenuItem
        '
        Me.AddClientToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateClientInfoToolStripMenuItem})
        Me.AddClientToolStripMenuItem.Name = "AddClientToolStripMenuItem"
        Me.AddClientToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.AddClientToolStripMenuItem.Text = "Add  Client"
        '
        'UpdateClientInfoToolStripMenuItem
        '
        Me.UpdateClientInfoToolStripMenuItem.Name = "UpdateClientInfoToolStripMenuItem"
        Me.UpdateClientInfoToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.UpdateClientInfoToolStripMenuItem.Text = "Update Client Info."
        '
        'ViewsToolStripMenuItem1
        '
        Me.ViewsToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewClientToolStripMenuItem, Me.ViewGuarantorToolStripMenuItem, Me.ViewNextOfKinToolStripMenuItem})
        Me.ViewsToolStripMenuItem1.Name = "ViewsToolStripMenuItem1"
        Me.ViewsToolStripMenuItem1.Size = New System.Drawing.Size(133, 22)
        Me.ViewsToolStripMenuItem1.Text = "Views"
        '
        'ViewClientToolStripMenuItem
        '
        Me.ViewClientToolStripMenuItem.Name = "ViewClientToolStripMenuItem"
        Me.ViewClientToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ViewClientToolStripMenuItem.Text = "View Client"
        '
        'ViewGuarantorToolStripMenuItem
        '
        Me.ViewGuarantorToolStripMenuItem.Name = "ViewGuarantorToolStripMenuItem"
        Me.ViewGuarantorToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ViewGuarantorToolStripMenuItem.Text = "View Guarantor"
        '
        'ViewNextOfKinToolStripMenuItem
        '
        Me.ViewNextOfKinToolStripMenuItem.Name = "ViewNextOfKinToolStripMenuItem"
        Me.ViewNextOfKinToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ViewNextOfKinToolStripMenuItem.Text = "View Next-Of-Kin"
        '
        'TransToolStripMenuItem
        '
        Me.TransToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AccessLoanToolStripMenuItem, Me.PaymentToolStripMenuItem, Me.WithdrawToolStripMenuItem, Me.ViewsToolStripMenuItem2})
        Me.TransToolStripMenuItem.Name = "TransToolStripMenuItem"
        Me.TransToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
        Me.TransToolStripMenuItem.Text = "Transactions"
        '
        'AccessLoanToolStripMenuItem
        '
        Me.AccessLoanToolStripMenuItem.Name = "AccessLoanToolStripMenuItem"
        Me.AccessLoanToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.AccessLoanToolStripMenuItem.Text = "Access Loan"
        '
        'PaymentToolStripMenuItem
        '
        Me.PaymentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PayLoanToolStripMenuItem, Me.DepositWithdrawToolStripMenuItem})
        Me.PaymentToolStripMenuItem.Name = "PaymentToolStripMenuItem"
        Me.PaymentToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.PaymentToolStripMenuItem.Text = "Payment"
        '
        'PayLoanToolStripMenuItem
        '
        Me.PayLoanToolStripMenuItem.Name = "PayLoanToolStripMenuItem"
        Me.PayLoanToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.PayLoanToolStripMenuItem.Text = "Pay Loan"
        '
        'DepositWithdrawToolStripMenuItem
        '
        Me.DepositWithdrawToolStripMenuItem.Name = "DepositWithdrawToolStripMenuItem"
        Me.DepositWithdrawToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.DepositWithdrawToolStripMenuItem.Text = "Deposit"
        '
        'WithdrawToolStripMenuItem
        '
        Me.WithdrawToolStripMenuItem.Name = "WithdrawToolStripMenuItem"
        Me.WithdrawToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.WithdrawToolStripMenuItem.Text = "Withdraw"
        '
        'ViewsToolStripMenuItem2
        '
        Me.ViewsToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDailyTransactionToolStripMenuItem, Me.ViewAccountBalanceToolStripMenuItem, Me.ViewRatingToolStripMenuItem, Me.ViewLoanBalanceToolStripMenuItem, Me.ViewLoanHistoryToolStripMenuItem})
        Me.ViewsToolStripMenuItem2.Name = "ViewsToolStripMenuItem2"
        Me.ViewsToolStripMenuItem2.Size = New System.Drawing.Size(139, 22)
        Me.ViewsToolStripMenuItem2.Text = "Views"
        '
        'ViewDailyTransactionToolStripMenuItem
        '
        Me.ViewDailyTransactionToolStripMenuItem.Name = "ViewDailyTransactionToolStripMenuItem"
        Me.ViewDailyTransactionToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ViewDailyTransactionToolStripMenuItem.Text = "view Daily Transaction"
        '
        'ViewAccountBalanceToolStripMenuItem
        '
        Me.ViewAccountBalanceToolStripMenuItem.Name = "ViewAccountBalanceToolStripMenuItem"
        Me.ViewAccountBalanceToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ViewAccountBalanceToolStripMenuItem.Text = "view Account Balance"
        '
        'ViewRatingToolStripMenuItem
        '
        Me.ViewRatingToolStripMenuItem.Name = "ViewRatingToolStripMenuItem"
        Me.ViewRatingToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ViewRatingToolStripMenuItem.Text = "view Rating"
        '
        'ViewLoanBalanceToolStripMenuItem
        '
        Me.ViewLoanBalanceToolStripMenuItem.Name = "ViewLoanBalanceToolStripMenuItem"
        Me.ViewLoanBalanceToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ViewLoanBalanceToolStripMenuItem.Text = "view Loan Balance"
        '
        'ViewLoanHistoryToolStripMenuItem
        '
        Me.ViewLoanHistoryToolStripMenuItem.Name = "ViewLoanHistoryToolStripMenuItem"
        Me.ViewLoanHistoryToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ViewLoanHistoryToolStripMenuItem.Text = "view Loan History"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DailyTransactionToolStripMenuItem})
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.ReportToolStripMenuItem.Text = "Report"
        '
        'DailyTransactionToolStripMenuItem
        '
        Me.DailyTransactionToolStripMenuItem.Name = "DailyTransactionToolStripMenuItem"
        Me.DailyTransactionToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.DailyTransactionToolStripMenuItem.Text = "Daily Transaction"
        '
        'BackupRestoreToolStripMenuItem
        '
        Me.BackupRestoreToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BackupDatabaseToolStripMenuItem})
        Me.BackupRestoreToolStripMenuItem.Name = "BackupRestoreToolStripMenuItem"
        Me.BackupRestoreToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.BackupRestoreToolStripMenuItem.Text = "Back-up"
        '
        'BackupDatabaseToolStripMenuItem
        '
        Me.BackupDatabaseToolStripMenuItem.Name = "BackupDatabaseToolStripMenuItem"
        Me.BackupDatabaseToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.BackupDatabaseToolStripMenuItem.Text = "Backup Database"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.yourName, Me.ToolStripStatusLabel3, Me.ydate, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel6})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 432)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(811, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(67, 17)
        Me.ToolStripStatusLabel1.Text = "Username:"
        '
        'yourName
        '
        Me.yourName.Name = "yourName"
        Me.yourName.Size = New System.Drawing.Size(62, 17)
        Me.yourName.Text = "getUname"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(88, 17)
        Me.ToolStripStatusLabel3.Text = "Working Date:"
        '
        'ydate
        '
        Me.ydate.Name = "ydate"
        Me.ydate.Size = New System.Drawing.Size(30, 17)
        Me.ydate.Text = "date"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(74, 17)
        Me.ToolStripStatusLabel2.Text = "Property of:"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(103, 17)
        Me.ToolStripStatusLabel4.Text = "Ezee Microfinance"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(88, 17)
        Me.ToolStripStatusLabel5.Text = "Developed By:"
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.Image = Global.EZEE_MICROFINANCE.My.Resources.Resources.Users_icon
        Me.ToolStripStatusLabel6.IsLink = True
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(65, 17)
        Me.ToolStripStatusLabel6.Text = "wisdom"
        '
        'Timer1
        '
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.EZEE_MICROFINANCE.My.Resources.Resources.software
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(811, 454)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EZEE MICROFINACE SYSTEMS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateNewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackupRestoreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackupDatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DailyTransactionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmployeeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DepartmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents yourName As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ydate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents AddClientToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RatingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaymentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PayLoanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DepositWithdrawToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IDTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WithdrawToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateClientInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateEmployeeInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdatePasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewDepartmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmployeeToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewClientToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewGuarantorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewNextOfKinToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewsToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewDailyTransactionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewAccountBalanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewRatingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewLoanBalanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewLoanHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents AccessLoanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As ToolStripMenuItem
End Class

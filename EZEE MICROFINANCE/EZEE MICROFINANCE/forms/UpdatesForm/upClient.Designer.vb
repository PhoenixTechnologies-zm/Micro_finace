<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class upClient
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
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboAccountType = New System.Windows.Forms.ComboBox()
        Me.mskPhone = New System.Windows.Forms.TextBox()
        Me.txtworkPlace = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.rdMale = New System.Windows.Forms.RadioButton()
        Me.rdFmale = New System.Windows.Forms.RadioButton()
        Me.txtSpouseName = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboMaritalstatus = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Oname = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGetImage = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnGetSignature = New System.Windows.Forms.Button()
        Me.picSignature = New System.Windows.Forms.PictureBox()
        Me.picClientImage = New System.Windows.Forms.PictureBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.mskNtkContact = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboNKinGender = New System.Windows.Forms.ComboBox()
        Me.dobNKin = New System.Windows.Forms.DateTimePicker()
        Me.txtNkinFullName = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtResidence = New System.Windows.Forms.TextBox()
        Me.txtIDNum = New System.Windows.Forms.TextBox()
        Me.cboIDType = New System.Windows.Forms.ComboBox()
        Me.txtOccupation = New System.Windows.Forms.TextBox()
        Me.dob = New System.Windows.Forms.DateTimePicker()
        Me.txtLname = New System.Windows.Forms.TextBox()
        Me.txtFname = New System.Windows.Forms.TextBox()
        Me.txtAcctNum = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.pictFormImage = New System.Windows.Forms.PictureBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.picSignature, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picClientImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.pictFormImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(19, 273)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(91, 16)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "Account Type"
        '
        'cboAccountType
        '
        Me.cboAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountType.FormattingEnabled = True
        Me.cboAccountType.Items.AddRange(New Object() {"SAVINGS"})
        Me.cboAccountType.Location = New System.Drawing.Point(115, 273)
        Me.cboAccountType.Name = "cboAccountType"
        Me.cboAccountType.Size = New System.Drawing.Size(129, 23)
        Me.cboAccountType.TabIndex = 15
        '
        'mskPhone
        '
        Me.mskPhone.Location = New System.Drawing.Point(115, 208)
        Me.mskPhone.MaxLength = 10
        Me.mskPhone.Name = "mskPhone"
        Me.mskPhone.Size = New System.Drawing.Size(131, 21)
        Me.mskPhone.TabIndex = 11
        '
        'txtworkPlace
        '
        Me.txtworkPlace.Location = New System.Drawing.Point(380, 172)
        Me.txtworkPlace.MaxLength = 50
        Me.txtworkPlace.Name = "txtworkPlace"
        Me.txtworkPlace.Size = New System.Drawing.Size(135, 21)
        Me.txtworkPlace.TabIndex = 10
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(19, 98)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(48, 15)
        Me.Label19.TabIndex = 34
        Me.Label19.Text = "Gender"
        '
        'rdMale
        '
        Me.rdMale.AutoSize = True
        Me.rdMale.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdMale.Location = New System.Drawing.Point(115, 94)
        Me.rdMale.Name = "rdMale"
        Me.rdMale.Size = New System.Drawing.Size(53, 19)
        Me.rdMale.TabIndex = 4
        Me.rdMale.TabStop = True
        Me.rdMale.Text = "Male"
        Me.rdMale.UseVisualStyleBackColor = True
        '
        'rdFmale
        '
        Me.rdFmale.AutoSize = True
        Me.rdFmale.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdFmale.Location = New System.Drawing.Point(179, 94)
        Me.rdFmale.Name = "rdFmale"
        Me.rdFmale.Size = New System.Drawing.Size(67, 19)
        Me.rdFmale.TabIndex = 5
        Me.rdFmale.TabStop = True
        Me.rdFmale.Text = "Female"
        Me.rdFmale.UseVisualStyleBackColor = True
        '
        'txtSpouseName
        '
        Me.txtSpouseName.Location = New System.Drawing.Point(378, 139)
        Me.txtSpouseName.MaxLength = 50
        Me.txtSpouseName.Name = "txtSpouseName"
        Me.txtSpouseName.ReadOnly = True
        Me.txtSpouseName.Size = New System.Drawing.Size(137, 21)
        Me.txtSpouseName.TabIndex = 8
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(270, 137)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(86, 15)
        Me.Label18.TabIndex = 30
        Me.Label18.Text = "Spouse Name"
        '
        'cboMaritalstatus
        '
        Me.cboMaritalstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMaritalstatus.FormattingEnabled = True
        Me.cboMaritalstatus.ItemHeight = 15
        Me.cboMaritalstatus.Items.AddRange(New Object() {"SINGLE", "MARRIED", "DIVORCED", "WIDOW"})
        Me.cboMaritalstatus.Location = New System.Drawing.Point(115, 137)
        Me.cboMaritalstatus.Name = "cboMaritalstatus"
        Me.cboMaritalstatus.Size = New System.Drawing.Size(131, 23)
        Me.cboMaritalstatus.TabIndex = 7
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(17, 137)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 15)
        Me.Label17.TabIndex = 28
        Me.Label17.Text = "Maritals Status"
        '
        'Oname
        '
        Me.Oname.Location = New System.Drawing.Point(351, 65)
        Me.Oname.MaxLength = 50
        Me.Oname.Name = "Oname"
        Me.Oname.Size = New System.Drawing.Size(164, 21)
        Me.Oname.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(264, 65)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 15)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "Other Name"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(262, 211)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 15)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Email"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(17, 323)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 15)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Residence"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(262, 243)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 15)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "ID No."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(19, 243)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 15)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "ID Type"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(17, 206)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 15)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Phone No."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(17, 172)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 15)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Occupation"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(262, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 15)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Date Of Birth"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Last Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(17, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "First Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 15)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Account No."
        '
        'btnGetImage
        '
        Me.btnGetImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGetImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGetImage.Location = New System.Drawing.Point(168, 157)
        Me.btnGetImage.Name = "btnGetImage"
        Me.btnGetImage.Size = New System.Drawing.Size(75, 23)
        Me.btnGetImage.TabIndex = 18
        Me.btnGetImage.Text = "Browse"
        Me.btnGetImage.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.cboAccountType)
        Me.GroupBox1.Controls.Add(Me.mskPhone)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtworkPlace)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.rdMale)
        Me.GroupBox1.Controls.Add(Me.rdFmale)
        Me.GroupBox1.Controls.Add(Me.txtSpouseName)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.cboMaritalstatus)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Oname)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.txtEmail)
        Me.GroupBox1.Controls.Add(Me.txtResidence)
        Me.GroupBox1.Controls.Add(Me.txtIDNum)
        Me.GroupBox1.Controls.Add(Me.cboIDType)
        Me.GroupBox1.Controls.Add(Me.txtOccupation)
        Me.GroupBox1.Controls.Add(Me.dob)
        Me.GroupBox1.Controls.Add(Me.txtLname)
        Me.GroupBox1.Controls.Add(Me.txtFname)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(10, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(802, 394)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " "
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(262, 172)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(109, 15)
        Me.Label20.TabIndex = 36
        Me.Label20.Text = "Name of Company"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox4.Controls.Add(Me.GroupBox2)
        Me.GroupBox4.Controls.Add(Me.btnGetImage)
        Me.GroupBox4.Controls.Add(Me.picClientImage)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(530, 20)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(263, 195)
        Me.GroupBox4.TabIndex = 14
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Client Image"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnGetSignature)
        Me.GroupBox2.Controls.Add(Me.picSignature)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(112, 120)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Signature"
        '
        'btnGetSignature
        '
        Me.btnGetSignature.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGetSignature.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGetSignature.Location = New System.Drawing.Point(23, 90)
        Me.btnGetSignature.Name = "btnGetSignature"
        Me.btnGetSignature.Size = New System.Drawing.Size(75, 23)
        Me.btnGetSignature.TabIndex = 17
        Me.btnGetSignature.Text = "Browse"
        Me.btnGetSignature.UseVisualStyleBackColor = True
        '
        'picSignature
        '
        Me.picSignature.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picSignature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picSignature.Image = Global.EZEE_MICROFINANCE.My.Resources.Resources.editing
        Me.picSignature.Location = New System.Drawing.Point(6, 15)
        Me.picSignature.Name = "picSignature"
        Me.picSignature.Size = New System.Drawing.Size(100, 60)
        Me.picSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSignature.TabIndex = 12
        Me.picSignature.TabStop = False
        '
        'picClientImage
        '
        Me.picClientImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picClientImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picClientImage.Image = Global.EZEE_MICROFINANCE.My.Resources.Resources.PlaceHolder
        Me.picClientImage.Location = New System.Drawing.Point(142, 20)
        Me.picClientImage.Name = "picClientImage"
        Me.picClientImage.Size = New System.Drawing.Size(120, 120)
        Me.picClientImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picClientImage.TabIndex = 13
        Me.picClientImage.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox3.Controls.Add(Me.mskNtkContact)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.cboNKinGender)
        Me.GroupBox3.Controls.Add(Me.dobNKin)
        Me.GroupBox3.Controls.Add(Me.txtNkinFullName)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(521, 243)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(272, 136)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Next Of Kin"
        '
        'mskNtkContact
        '
        Me.mskNtkContact.Location = New System.Drawing.Point(105, 102)
        Me.mskNtkContact.MaxLength = 10
        Me.mskNtkContact.Name = "mskNtkContact"
        Me.mskNtkContact.Size = New System.Drawing.Size(161, 21)
        Me.mskNtkContact.TabIndex = 22
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 102)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 15)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "Contact"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(12, 69)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 15)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Gender"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(12, 43)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 15)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Date Of Birth"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 15)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Full  Name"
        '
        'cboNKinGender
        '
        Me.cboNKinGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNKinGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNKinGender.FormattingEnabled = True
        Me.cboNKinGender.Items.AddRange(New Object() {"MALE", "FEMALE"})
        Me.cboNKinGender.Location = New System.Drawing.Point(105, 70)
        Me.cboNKinGender.Name = "cboNKinGender"
        Me.cboNKinGender.Size = New System.Drawing.Size(161, 23)
        Me.cboNKinGender.TabIndex = 21
        '
        'dobNKin
        '
        Me.dobNKin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dobNKin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dobNKin.Location = New System.Drawing.Point(105, 43)
        Me.dobNKin.Name = "dobNKin"
        Me.dobNKin.Size = New System.Drawing.Size(161, 21)
        Me.dobNKin.TabIndex = 20
        '
        'txtNkinFullName
        '
        Me.txtNkinFullName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNkinFullName.Location = New System.Drawing.Point(105, 16)
        Me.txtNkinFullName.MaxLength = 50
        Me.txtNkinFullName.Name = "txtNkinFullName"
        Me.txtNkinFullName.Size = New System.Drawing.Size(161, 21)
        Me.txtNkinFullName.TabIndex = 19
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(322, 208)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(193, 21)
        Me.txtEmail.TabIndex = 12
        '
        'txtResidence
        '
        Me.txtResidence.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResidence.Location = New System.Drawing.Point(113, 302)
        Me.txtResidence.MaxLength = 50
        Me.txtResidence.Multiline = True
        Me.txtResidence.Name = "txtResidence"
        Me.txtResidence.Size = New System.Drawing.Size(402, 74)
        Me.txtResidence.TabIndex = 16
        '
        'txtIDNum
        '
        Me.txtIDNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDNum.Location = New System.Drawing.Point(322, 243)
        Me.txtIDNum.Name = "txtIDNum"
        Me.txtIDNum.Size = New System.Drawing.Size(193, 21)
        Me.txtIDNum.TabIndex = 14
        '
        'cboIDType
        '
        Me.cboIDType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIDType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboIDType.FormattingEnabled = True
        Me.cboIDType.Location = New System.Drawing.Point(113, 243)
        Me.cboIDType.Name = "cboIDType"
        Me.cboIDType.Size = New System.Drawing.Size(131, 23)
        Me.cboIDType.Sorted = True
        Me.cboIDType.TabIndex = 13
        '
        'txtOccupation
        '
        Me.txtOccupation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOccupation.Location = New System.Drawing.Point(115, 172)
        Me.txtOccupation.MaxLength = 50
        Me.txtOccupation.Name = "txtOccupation"
        Me.txtOccupation.Size = New System.Drawing.Size(131, 21)
        Me.txtOccupation.TabIndex = 9
        '
        'dob
        '
        Me.dob.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dob.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dob.Location = New System.Drawing.Point(378, 98)
        Me.dob.Name = "dob"
        Me.dob.Size = New System.Drawing.Size(137, 21)
        Me.dob.TabIndex = 6
        '
        'txtLname
        '
        Me.txtLname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLname.Location = New System.Drawing.Point(113, 20)
        Me.txtLname.MaxLength = 50
        Me.txtLname.Name = "txtLname"
        Me.txtLname.Size = New System.Drawing.Size(164, 21)
        Me.txtLname.TabIndex = 1
        '
        'txtFname
        '
        Me.txtFname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFname.Location = New System.Drawing.Point(115, 65)
        Me.txtFname.MaxLength = 50
        Me.txtFname.Name = "txtFname"
        Me.txtFname.Size = New System.Drawing.Size(131, 21)
        Me.txtFname.TabIndex = 2
        '
        'txtAcctNum
        '
        Me.txtAcctNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAcctNum.Location = New System.Drawing.Point(81, 21)
        Me.txtAcctNum.MaxLength = 10
        Me.txtAcctNum.Name = "txtAcctNum"
        Me.txtAcctNum.Size = New System.Drawing.Size(131, 21)
        Me.txtAcctNum.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Location = New System.Drawing.Point(531, 485)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(117, 38)
        Me.btnClose.TabIndex = 24
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.ForeColor = System.Drawing.Color.Black
        Me.btnSubmit.Location = New System.Drawing.Point(125, 485)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(117, 38)
        Me.btnSubmit.TabIndex = 23
        Me.btnSubmit.Text = "Submit "
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'pictFormImage
        '
        Me.pictFormImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pictFormImage.Location = New System.Drawing.Point(349, 5)
        Me.pictFormImage.Name = "pictFormImage"
        Me.pictFormImage.Size = New System.Drawing.Size(449, 76)
        Me.pictFormImage.TabIndex = 25
        Me.pictFormImage.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Button1)
        Me.GroupBox5.Controls.Add(Me.txtAcctNum)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(12, 26)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(319, 51)
        Me.GroupBox5.TabIndex = 26
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Enter Account Number"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(224, 21)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 23)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'upClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(822, 533)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pictFormImage)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSubmit)
        Me.MaximizeBox = False
        Me.Name = "upClient"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search And Update Client Details"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.picSignature, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picClientImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.pictFormImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboAccountType As System.Windows.Forms.ComboBox
    Friend WithEvents mskPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtworkPlace As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents rdMale As System.Windows.Forms.RadioButton
    Friend WithEvents rdFmale As System.Windows.Forms.RadioButton
    Friend WithEvents txtSpouseName As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboMaritalstatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Oname As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGetImage As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGetSignature As System.Windows.Forms.Button
    Friend WithEvents picSignature As System.Windows.Forms.PictureBox
    Friend WithEvents picClientImage As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents mskNtkContact As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboNKinGender As System.Windows.Forms.ComboBox
    Friend WithEvents dobNKin As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNkinFullName As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtResidence As System.Windows.Forms.TextBox
    Friend WithEvents txtIDNum As System.Windows.Forms.TextBox
    Friend WithEvents cboIDType As System.Windows.Forms.ComboBox
    Friend WithEvents txtOccupation As System.Windows.Forms.TextBox
    Friend WithEvents dob As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtLname As System.Windows.Forms.TextBox
    Friend WithEvents txtFname As System.Windows.Forms.TextBox
    Friend WithEvents txtAcctNum As System.Windows.Forms.TextBox
    Friend WithEvents pictFormImage As System.Windows.Forms.PictureBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class

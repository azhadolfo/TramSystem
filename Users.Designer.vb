<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Users
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Users))
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        txtEmpno = New TextBox()
        chkAdmin = New CheckBox()
        txtEmpname = New TextBox()
        Label2 = New Label()
        txtPassword = New TextBox()
        Label3 = New Label()
        txtConfirm = New TextBox()
        Label4 = New Label()
        Label5 = New Label()
        chkFast = New CheckBox()
        chkEdit = New CheckBox()
        chkUsers = New CheckBox()
        chktugboat = New CheckBox()
        chkReport = New CheckBox()
        btnView = New Button()
        btnSave = New Button()
        btnClose = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.mmsi
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.Dock = DockStyle.Top
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(385, 71)
        PictureBox1.TabIndex = 11
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 99)
        Label1.Name = "Label1"
        Label1.Size = New Size(73, 15)
        Label1.TabIndex = 12
        Label1.Text = "Employee ID"
        ' 
        ' txtEmpno
        ' 
        txtEmpno.Location = New Point(129, 96)
        txtEmpno.MaxLength = 4
        txtEmpno.Name = "txtEmpno"
        txtEmpno.Size = New Size(62, 23)
        txtEmpno.TabIndex = 13
        ' 
        ' chkAdmin
        ' 
        chkAdmin.AutoSize = True
        chkAdmin.Location = New Point(197, 98)
        chkAdmin.Name = "chkAdmin"
        chkAdmin.Size = New Size(65, 19)
        chkAdmin.TabIndex = 14
        chkAdmin.Text = "ADMIN"
        chkAdmin.UseVisualStyleBackColor = True
        ' 
        ' txtEmpname
        ' 
        txtEmpname.Location = New Point(129, 125)
        txtEmpname.Name = "txtEmpname"
        txtEmpname.Size = New Size(133, 23)
        txtEmpname.TabIndex = 16
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 128)
        Label2.Name = "Label2"
        Label2.Size = New Size(94, 15)
        Label2.TabIndex = 15
        Label2.Text = "Employee Name"
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(129, 154)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(133, 23)
        txtPassword.TabIndex = 18
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 157)
        Label3.Name = "Label3"
        Label3.Size = New Size(57, 15)
        Label3.TabIndex = 17
        Label3.Text = "Password"
        ' 
        ' txtConfirm
        ' 
        txtConfirm.Location = New Point(129, 183)
        txtConfirm.Name = "txtConfirm"
        txtConfirm.Size = New Size(133, 23)
        txtConfirm.TabIndex = 20
        txtConfirm.UseSystemPasswordChar = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(12, 183)
        Label4.Name = "Label4"
        Label4.Size = New Size(104, 15)
        Label4.TabIndex = 19
        Label4.Text = "Confirm Password"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(12, 226)
        Label5.Name = "Label5"
        Label5.Size = New Size(76, 15)
        Label5.TabIndex = 21
        Label5.Text = "Allow Access"
        ' 
        ' chkFast
        ' 
        chkFast.AutoSize = True
        chkFast.Location = New Point(129, 225)
        chkFast.Name = "chkFast"
        chkFast.Size = New Size(71, 19)
        chkFast.TabIndex = 22
        chkFast.Text = "Get Data"
        chkFast.UseVisualStyleBackColor = True
        ' 
        ' chkEdit
        ' 
        chkEdit.AutoSize = True
        chkEdit.Location = New Point(129, 250)
        chkEdit.Name = "chkEdit"
        chkEdit.Size = New Size(46, 19)
        chkEdit.TabIndex = 23
        chkEdit.Text = "Edit"
        chkEdit.UseVisualStyleBackColor = True
        ' 
        ' chkUsers
        ' 
        chkUsers.AutoSize = True
        chkUsers.Location = New Point(129, 299)
        chkUsers.Name = "chkUsers"
        chkUsers.Size = New Size(54, 19)
        chkUsers.TabIndex = 25
        chkUsers.Text = "Users"
        chkUsers.UseVisualStyleBackColor = True
        ' 
        ' chktugboat
        ' 
        chktugboat.AutoSize = True
        chktugboat.Location = New Point(129, 274)
        chktugboat.Name = "chktugboat"
        chktugboat.Size = New Size(70, 19)
        chktugboat.TabIndex = 24
        chktugboat.Text = "Tugboat"
        chktugboat.UseVisualStyleBackColor = True
        ' 
        ' chkReport
        ' 
        chkReport.AutoSize = True
        chkReport.Location = New Point(129, 323)
        chkReport.Name = "chkReport"
        chkReport.Size = New Size(89, 19)
        chkReport.TabIndex = 26
        chkReport.Text = "Print Report"
        chkReport.UseVisualStyleBackColor = True
        ' 
        ' btnView
        ' 
        btnView.Location = New Point(24, 388)
        btnView.Name = "btnView"
        btnView.Size = New Size(75, 23)
        btnView.TabIndex = 27
        btnView.Text = "VIEW"
        btnView.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(116, 388)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(75, 23)
        btnSave.TabIndex = 28
        btnSave.Text = "SAVE"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(289, 388)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(75, 23)
        btnClose.TabIndex = 29
        btnClose.Text = "CLOSE"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' Users
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLightLight
        ClientSize = New Size(385, 423)
        Controls.Add(btnClose)
        Controls.Add(btnSave)
        Controls.Add(btnView)
        Controls.Add(chkReport)
        Controls.Add(chkUsers)
        Controls.Add(chktugboat)
        Controls.Add(chkEdit)
        Controls.Add(chkFast)
        Controls.Add(Label5)
        Controls.Add(txtConfirm)
        Controls.Add(Label4)
        Controls.Add(txtPassword)
        Controls.Add(Label3)
        Controls.Add(txtEmpname)
        Controls.Add(Label2)
        Controls.Add(chkAdmin)
        Controls.Add(txtEmpno)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Users"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Users"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtEmpno As TextBox
    Friend WithEvents chkAdmin As CheckBox
    Friend WithEvents txtEmpname As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtConfirm As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents chkFast As CheckBox
    Friend WithEvents chkEdit As CheckBox
    Friend WithEvents chkUsers As CheckBox
    Friend WithEvents chktugboat As CheckBox
    Friend WithEvents chkReport As CheckBox
    Friend WithEvents btnView As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnClose As Button
End Class

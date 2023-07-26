<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TugboatForm
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(TugboatForm))
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        txtNum = New TextBox()
        txtName = New TextBox()
        txtAcquired = New TextBox()
        txtDate = New TextBox()
        txtAmount = New TextBox()
        GroupBox1 = New GroupBox()
        lblSearch = New Label()
        btnClose = New Button()
        btnCancel = New Button()
        btnSave = New Button()
        btnSearch = New Button()
        btnEdit = New Button()
        btnNew = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.mmsi
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.Dock = DockStyle.Top
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(540, 71)
        PictureBox1.TabIndex = 3
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(38, 126)
        Label1.Name = "Label1"
        Label1.Size = New Size(98, 15)
        Label1.TabIndex = 4
        Label1.Text = "Tugboat Number"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(38, 161)
        Label2.Name = "Label2"
        Label2.Size = New Size(39, 15)
        Label2.TabIndex = 5
        Label2.Text = "Name"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(38, 195)
        Label3.Name = "Label3"
        Label3.Size = New Size(79, 15)
        Label3.TabIndex = 6
        Label3.Text = "Acquire From"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(38, 231)
        Label4.Name = "Label4"
        Label4.Size = New Size(82, 15)
        Label4.TabIndex = 7
        Label4.Text = "Date Acquired"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(38, 261)
        Label5.Name = "Label5"
        Label5.Size = New Size(31, 15)
        Label5.TabIndex = 8
        Label5.Text = "Cost"
        ' 
        ' txtNum
        ' 
        txtNum.Enabled = False
        txtNum.Location = New Point(142, 123)
        txtNum.Name = "txtNum"
        txtNum.Size = New Size(100, 23)
        txtNum.TabIndex = 9
        ' 
        ' txtName
        ' 
        txtName.Enabled = False
        txtName.Location = New Point(142, 158)
        txtName.Name = "txtName"
        txtName.Size = New Size(249, 23)
        txtName.TabIndex = 10
        ' 
        ' txtAcquired
        ' 
        txtAcquired.Enabled = False
        txtAcquired.Location = New Point(142, 192)
        txtAcquired.Name = "txtAcquired"
        txtAcquired.Size = New Size(249, 23)
        txtAcquired.TabIndex = 11
        ' 
        ' txtDate
        ' 
        txtDate.Enabled = False
        txtDate.Location = New Point(142, 223)
        txtDate.Name = "txtDate"
        txtDate.Size = New Size(118, 23)
        txtDate.TabIndex = 12
        ' 
        ' txtAmount
        ' 
        txtAmount.Enabled = False
        txtAmount.Location = New Point(142, 253)
        txtAmount.Name = "txtAmount"
        txtAmount.Size = New Size(118, 23)
        txtAmount.TabIndex = 13
        txtAmount.TextAlign = HorizontalAlignment.Right
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(lblSearch)
        GroupBox1.FlatStyle = FlatStyle.Popup
        GroupBox1.Font = New Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point)
        GroupBox1.Location = New Point(12, 87)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(516, 210)
        GroupBox1.TabIndex = 14
        GroupBox1.TabStop = False
        ' 
        ' lblSearch
        ' 
        lblSearch.AutoSize = True
        lblSearch.Font = New Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point)
        lblSearch.ForeColor = Color.Red
        lblSearch.Location = New Point(236, 39)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(126, 13)
        lblSearch.TabIndex = 0
        lblSearch.Text = "* Search tugboat number"
        lblSearch.Visible = False
        ' 
        ' btnClose
        ' 
        btnClose.FlatStyle = FlatStyle.System
        btnClose.Location = New Point(435, 320)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(75, 23)
        btnClose.TabIndex = 20
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Enabled = False
        btnCancel.FlatStyle = FlatStyle.System
        btnCancel.Location = New Point(354, 320)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(75, 23)
        btnCancel.TabIndex = 19
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.Enabled = False
        btnSave.FlatStyle = FlatStyle.System
        btnSave.Location = New Point(273, 320)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(75, 23)
        btnSave.TabIndex = 18
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' btnSearch
        ' 
        btnSearch.FlatStyle = FlatStyle.System
        btnSearch.Location = New Point(192, 320)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(75, 23)
        btnSearch.TabIndex = 17
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' btnEdit
        ' 
        btnEdit.Enabled = False
        btnEdit.FlatStyle = FlatStyle.System
        btnEdit.Location = New Point(111, 320)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(75, 23)
        btnEdit.TabIndex = 16
        btnEdit.Text = "Edit"
        btnEdit.UseVisualStyleBackColor = True
        ' 
        ' btnNew
        ' 
        btnNew.FlatStyle = FlatStyle.System
        btnNew.Location = New Point(30, 320)
        btnNew.Name = "btnNew"
        btnNew.Size = New Size(75, 23)
        btnNew.TabIndex = 15
        btnNew.Text = "New"
        btnNew.UseVisualStyleBackColor = True
        ' 
        ' TugboatForm
        ' 
        AcceptButton = btnClose
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLightLight
        CancelButton = btnClose
        ClientSize = New Size(540, 370)
        ControlBox = False
        Controls.Add(btnClose)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        Controls.Add(btnSearch)
        Controls.Add(btnEdit)
        Controls.Add(btnNew)
        Controls.Add(txtAmount)
        Controls.Add(txtDate)
        Controls.Add(txtAcquired)
        Controls.Add(txtName)
        Controls.Add(txtNum)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        Controls.Add(GroupBox1)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "TugboatForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "TugboatForm"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNum As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtAcquired As TextBox
    Friend WithEvents txtDate As TextBox
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnClose As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnNew As Button
    Friend WithEvents lblSearch As Label
End Class

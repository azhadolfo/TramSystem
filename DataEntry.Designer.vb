<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataEntry
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(DataEntry))
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        btnSearch = New GroupBox()
        txtDate = New TextBox()
        txtTugboatname = New TextBox()
        txtRef = New TextBox()
        txtSupplier = New TextBox()
        txtParticulars = New TextBox()
        txtRemarks = New RichTextBox()
        btnSave = New Button()
        btnDelete = New Button()
        btnUpdate = New Button()
        lblRecs = New Label()
        btnClose = New Button()
        Panel1 = New Panel()
        txtSearch = New TextBox()
        btnLast = New Button()
        btnNext = New Button()
        btnPrev = New Button()
        btnTop = New Button()
        Label18 = New Label()
        Label17 = New Label()
        cboTugboat = New ComboBox()
        Label16 = New Label()
        Label13 = New Label()
        Label14 = New Label()
        Label15 = New Label()
        DataGridView1 = New DataGridView()
        Label10 = New Label()
        Label9 = New Label()
        txtAmount = New TextBox()
        txtCheckdate = New TextBox()
        Label5 = New Label()
        txtParticular = New RichTextBox()
        txtPayee = New TextBox()
        Label7 = New Label()
        txtCheckno = New TextBox()
        Label6 = New Label()
        txtVoucherno = New TextBox()
        txtVoucherdate = New TextBox()
        Label4 = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        btnSearch.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.mmsi
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.Location = New Point(12, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(163, 71)
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label1.AutoSize = True
        Label1.Font = New Font("Times New Roman", 25F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(227, 31)
        Label1.Name = "Label1"
        Label1.Size = New Size(300, 39)
        Label1.TabIndex = 3
        Label1.Text = "TUGBOAT REPAIR"
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label2.AutoSize = True
        Label2.Font = New Font("Times New Roman", 9F, FontStyle.Italic, GraphicsUnit.Point)
        Label2.Location = New Point(525, 42)
        Label2.Name = "Label2"
        Label2.Size = New Size(31, 15)
        Label2.TabIndex = 4
        Label2.Text = "AND"
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Label3.AutoSize = True
        Label3.Font = New Font("Times New Roman", 25F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(552, 31)
        Label3.Name = "Label3"
        Label3.Size = New Size(267, 39)
        Label3.TabIndex = 5
        Label3.Text = "MAINTENANCE"
        ' 
        ' btnSearch
        ' 
        btnSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        btnSearch.BackColor = SystemColors.ButtonFace
        btnSearch.Controls.Add(txtDate)
        btnSearch.Controls.Add(txtTugboatname)
        btnSearch.Controls.Add(txtRef)
        btnSearch.Controls.Add(txtSupplier)
        btnSearch.Controls.Add(txtParticulars)
        btnSearch.Controls.Add(txtRemarks)
        btnSearch.Controls.Add(btnSave)
        btnSearch.Controls.Add(btnDelete)
        btnSearch.Controls.Add(btnUpdate)
        btnSearch.Controls.Add(lblRecs)
        btnSearch.Controls.Add(btnClose)
        btnSearch.Controls.Add(Panel1)
        btnSearch.Controls.Add(txtSearch)
        btnSearch.Controls.Add(btnLast)
        btnSearch.Controls.Add(btnNext)
        btnSearch.Controls.Add(btnPrev)
        btnSearch.Controls.Add(btnTop)
        btnSearch.Controls.Add(Label18)
        btnSearch.Controls.Add(Label17)
        btnSearch.Controls.Add(cboTugboat)
        btnSearch.Controls.Add(Label16)
        btnSearch.Controls.Add(Label13)
        btnSearch.Controls.Add(Label14)
        btnSearch.Controls.Add(Label15)
        btnSearch.Controls.Add(DataGridView1)
        btnSearch.Controls.Add(Label10)
        btnSearch.Controls.Add(Label9)
        btnSearch.Controls.Add(txtAmount)
        btnSearch.Controls.Add(txtCheckdate)
        btnSearch.Controls.Add(Label5)
        btnSearch.Controls.Add(txtParticular)
        btnSearch.Controls.Add(txtPayee)
        btnSearch.Controls.Add(Label7)
        btnSearch.Controls.Add(txtCheckno)
        btnSearch.Controls.Add(Label6)
        btnSearch.Controls.Add(txtVoucherno)
        btnSearch.Controls.Add(txtVoucherdate)
        btnSearch.Controls.Add(Label4)
        btnSearch.Cursor = Cursors.Hand
        btnSearch.Location = New Point(35, 99)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(860, 678)
        btnSearch.TabIndex = 6
        btnSearch.TabStop = False
        ' 
        ' txtDate
        ' 
        txtDate.Location = New Point(101, 433)
        txtDate.Name = "txtDate"
        txtDate.Size = New Size(100, 23)
        txtDate.TabIndex = 1
        ' 
        ' txtTugboatname
        ' 
        txtTugboatname.Location = New Point(165, 465)
        txtTugboatname.Name = "txtTugboatname"
        txtTugboatname.ReadOnly = True
        txtTugboatname.Size = New Size(239, 23)
        txtTugboatname.TabIndex = 2
        ' 
        ' txtRef
        ' 
        txtRef.Location = New Point(101, 494)
        txtRef.Name = "txtRef"
        txtRef.Size = New Size(303, 23)
        txtRef.TabIndex = 3
        ' 
        ' txtSupplier
        ' 
        txtSupplier.Location = New Point(101, 523)
        txtSupplier.Name = "txtSupplier"
        txtSupplier.Size = New Size(303, 23)
        txtSupplier.TabIndex = 4
        ' 
        ' txtParticulars
        ' 
        txtParticulars.Location = New Point(101, 552)
        txtParticulars.Name = "txtParticulars"
        txtParticulars.Size = New Size(303, 23)
        txtParticulars.TabIndex = 5
        ' 
        ' txtRemarks
        ' 
        txtRemarks.Location = New Point(101, 581)
        txtRemarks.Name = "txtRemarks"
        txtRemarks.Size = New Size(303, 59)
        txtRemarks.TabIndex = 6
        txtRemarks.Text = ""
        ' 
        ' btnSave
        ' 
        btnSave.FlatStyle = FlatStyle.System
        btnSave.Location = New Point(651, 451)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(133, 40)
        btnSave.TabIndex = 7
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.FlatStyle = FlatStyle.System
        btnDelete.Location = New Point(651, 497)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(133, 40)
        btnDelete.TabIndex = 8
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnUpdate
        ' 
        btnUpdate.FlatStyle = FlatStyle.System
        btnUpdate.Location = New Point(651, 543)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(133, 40)
        btnUpdate.TabIndex = 9
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = True
        ' 
        ' lblRecs
        ' 
        lblRecs.AutoSize = True
        lblRecs.Location = New Point(784, 208)
        lblRecs.Name = "lblRecs"
        lblRecs.Size = New Size(0, 15)
        lblRecs.TabIndex = 46
        ' 
        ' btnClose
        ' 
        btnClose.FlatStyle = FlatStyle.System
        btnClose.Location = New Point(651, 589)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(133, 40)
        btnClose.TabIndex = 10
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), Image)
        Panel1.BackgroundImageLayout = ImageLayout.Zoom
        Panel1.Location = New Point(783, 27)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(33, 23)
        Panel1.TabIndex = 45
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(628, 27)
        txtSearch.Name = "txtSearch"
        txtSearch.PlaceholderText = "Input voucher number"
        txtSearch.Size = New Size(149, 23)
        txtSearch.TabIndex = 44
        ' 
        ' btnLast
        ' 
        btnLast.BackgroundImage = My.Resources.Resources.right_arrow
        btnLast.BackgroundImageLayout = ImageLayout.Zoom
        btnLast.Location = New Point(773, 63)
        btnLast.Name = "btnLast"
        btnLast.Size = New Size(43, 23)
        btnLast.TabIndex = 42
        btnLast.UseVisualStyleBackColor = True
        ' 
        ' btnNext
        ' 
        btnNext.BackgroundImage = My.Resources.Resources._next
        btnNext.BackgroundImageLayout = ImageLayout.Zoom
        btnNext.Location = New Point(726, 63)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(43, 23)
        btnNext.TabIndex = 41
        btnNext.UseVisualStyleBackColor = True
        ' 
        ' btnPrev
        ' 
        btnPrev.BackgroundImage = My.Resources.Resources.left
        btnPrev.BackgroundImageLayout = ImageLayout.Zoom
        btnPrev.Location = New Point(677, 63)
        btnPrev.Name = "btnPrev"
        btnPrev.Size = New Size(43, 23)
        btnPrev.TabIndex = 40
        btnPrev.UseVisualStyleBackColor = True
        ' 
        ' btnTop
        ' 
        btnTop.BackColor = SystemColors.ButtonFace
        btnTop.BackgroundImage = My.Resources.Resources.left_arrow
        btnTop.BackgroundImageLayout = ImageLayout.Zoom
        btnTop.Location = New Point(628, 63)
        btnTop.Name = "btnTop"
        btnTop.Size = New Size(43, 23)
        btnTop.TabIndex = 39
        btnTop.UseVisualStyleBackColor = True
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Location = New Point(34, 584)
        Label18.Name = "Label18"
        Label18.Size = New Size(52, 15)
        Label18.TabIndex = 35
        Label18.Text = "Remarks"
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Location = New Point(34, 555)
        Label17.Name = "Label17"
        Label17.Size = New Size(62, 15)
        Label17.TabIndex = 33
        Label17.Text = "Particulars"
        ' 
        ' cboTugboat
        ' 
        cboTugboat.DropDownStyle = ComboBoxStyle.DropDownList
        cboTugboat.FormattingEnabled = True
        cboTugboat.Items.AddRange(New Object() {"001", "002", "003", "004", "005"})
        cboTugboat.Location = New Point(101, 465)
        cboTugboat.Name = "cboTugboat"
        cboTugboat.Size = New Size(58, 23)
        cboTugboat.TabIndex = 2
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Location = New Point(34, 526)
        Label16.Name = "Label16"
        Label16.Size = New Size(50, 15)
        Label16.TabIndex = 30
        Label16.Text = "Supplier"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(34, 497)
        Label13.Name = "Label13"
        Label13.Size = New Size(63, 15)
        Label13.TabIndex = 7
        Label13.Text = "Referrence"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(34, 468)
        Label14.Name = "Label14"
        Label14.Size = New Size(51, 15)
        Label14.TabIndex = 18
        Label14.Text = "Tugboat"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Location = New Point(34, 436)
        Label15.Name = "Label15"
        Label15.Size = New Size(34, 15)
        Label15.TabIndex = 15
        Label15.Text = "Date "
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.BackgroundColor = SystemColors.ControlLightLight
        DataGridView1.BorderStyle = BorderStyle.Fixed3D
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Info
        DataGridViewCellStyle1.Font = New Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.False
        DataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        DataGridView1.GridColor = SystemColors.ButtonFace
        DataGridView1.Location = New Point(34, 236)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowTemplate.Height = 25
        DataGridView1.Size = New Size(801, 150)
        DataGridView1.TabIndex = 20
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(564, 164)
        Label10.Name = "Label10"
        Label10.Size = New Size(51, 15)
        Label10.TabIndex = 12
        Label10.Text = "Amount"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(564, 135)
        Label9.Name = "Label9"
        Label9.Size = New Size(67, 15)
        Label9.TabIndex = 13
        Label9.Text = "Check Date"
        ' 
        ' txtAmount
        ' 
        txtAmount.Cursor = Cursors.No
        txtAmount.Location = New Point(651, 161)
        txtAmount.Name = "txtAmount"
        txtAmount.ReadOnly = True
        txtAmount.Size = New Size(165, 23)
        txtAmount.TabIndex = 20
        ' 
        ' txtCheckdate
        ' 
        txtCheckdate.Cursor = Cursors.No
        txtCheckdate.Location = New Point(651, 132)
        txtCheckdate.Name = "txtCheckdate"
        txtCheckdate.ReadOnly = True
        txtCheckdate.Size = New Size(165, 23)
        txtCheckdate.TabIndex = 20
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(564, 103)
        Label5.Name = "Label5"
        Label5.Size = New Size(50, 15)
        Label5.TabIndex = 10
        Label5.Text = "Check #"
        ' 
        ' txtParticular
        ' 
        txtParticular.Cursor = Cursors.No
        txtParticular.Location = New Point(101, 88)
        txtParticular.Name = "txtParticular"
        txtParticular.ReadOnly = True
        txtParticular.Size = New Size(303, 96)
        txtParticular.TabIndex = 20
        txtParticular.Text = ""
        ' 
        ' txtPayee
        ' 
        txtPayee.Cursor = Cursors.No
        txtPayee.Location = New Point(101, 59)
        txtPayee.Name = "txtPayee"
        txtPayee.ReadOnly = True
        txtPayee.Size = New Size(303, 23)
        txtPayee.TabIndex = 20
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(34, 91)
        Label7.Name = "Label7"
        Label7.Size = New Size(62, 15)
        Label7.TabIndex = 6
        Label7.Text = "Particulars"
        ' 
        ' txtCheckno
        ' 
        txtCheckno.Cursor = Cursors.No
        txtCheckno.Location = New Point(651, 100)
        txtCheckno.Name = "txtCheckno"
        txtCheckno.ReadOnly = True
        txtCheckno.Size = New Size(165, 23)
        txtCheckno.TabIndex = 20
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(34, 62)
        Label6.Name = "Label6"
        Label6.Size = New Size(38, 15)
        Label6.TabIndex = 4
        Label6.Text = "Payee"
        ' 
        ' txtVoucherno
        ' 
        txtVoucherno.Cursor = Cursors.No
        txtVoucherno.Location = New Point(207, 27)
        txtVoucherno.Name = "txtVoucherno"
        txtVoucherno.ReadOnly = True
        txtVoucherno.Size = New Size(100, 23)
        txtVoucherno.TabIndex = 20
        ' 
        ' txtVoucherdate
        ' 
        txtVoucherdate.Cursor = Cursors.No
        txtVoucherdate.Location = New Point(101, 27)
        txtVoucherdate.Name = "txtVoucherdate"
        txtVoucherdate.ReadOnly = True
        txtVoucherdate.Size = New Size(100, 23)
        txtVoucherdate.TabIndex = 20
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(34, 30)
        Label4.Name = "Label4"
        Label4.Size = New Size(64, 15)
        Label4.TabIndex = 0
        Label4.Text = "Date / CV#"
        ' 
        ' DataEntry
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLightLight
        ClientSize = New Size(924, 789)
        Controls.Add(btnSearch)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "DataEntry"
        StartPosition = FormStartPosition.CenterScreen
        Text = "DataEntry"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        btnSearch.ResumeLayout(False)
        btnSearch.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnSearch As GroupBox
    Friend WithEvents txtCheckno As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtPayee As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtVoucherno As TextBox
    Friend WithEvents txtVoucherdate As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtParticular As RichTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents txtCheckdate As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtTugboatname As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtDate As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents cboTugboat As ComboBox
    Friend WithEvents txtSupplier As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtRef As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtRemarks As RichTextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtParticulars As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnLast As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents btnPrev As Button
    Friend WithEvents btnTop As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents lblRecs As Label
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportForm
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(ReportForm))
        PictureBox1 = New PictureBox()
        Label2 = New Label()
        GroupBox1 = New GroupBox()
        btnPrint = New Button()
        btnClose = New Button()
        txtName = New TextBox()
        cboTugboat = New ComboBox()
        Label3 = New Label()
        cboReport = New ComboBox()
        Label1 = New Label()
        DataGridView1 = New DataGridView()
        btnReport = New Button()
        PrintDocument1 = New Printing.PrintDocument()
        PrintPreviewDialog1 = New PrintPreviewDialog()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.mmsi
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.Dock = DockStyle.Top
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(546, 71)
        PictureBox1.TabIndex = 3
        PictureBox1.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Times New Roman", 25F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(12, 98)
        Label2.Name = "Label2"
        Label2.Size = New Size(166, 39)
        Label2.TabIndex = 5
        Label2.Text = "REPORTS"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(btnPrint)
        GroupBox1.Controls.Add(btnClose)
        GroupBox1.Controls.Add(txtName)
        GroupBox1.Controls.Add(cboTugboat)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(cboReport)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Location = New Point(12, 132)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(522, 190)
        GroupBox1.TabIndex = 6
        GroupBox1.TabStop = False
        ' 
        ' btnPrint
        ' 
        btnPrint.Location = New Point(217, 127)
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(127, 32)
        btnPrint.TabIndex = 6
        btnPrint.Text = "GENERATE EXCEL"
        btnPrint.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(350, 127)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(86, 32)
        btnClose.TabIndex = 5
        btnClose.Text = "CLOSE"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(174, 73)
        txtName.Name = "txtName"
        txtName.ReadOnly = True
        txtName.Size = New Size(262, 23)
        txtName.TabIndex = 4
        ' 
        ' cboTugboat
        ' 
        cboTugboat.DropDownStyle = ComboBoxStyle.DropDownList
        cboTugboat.FormattingEnabled = True
        cboTugboat.Location = New Point(107, 73)
        cboTugboat.Name = "cboTugboat"
        cboTugboat.Size = New Size(59, 23)
        cboTugboat.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(50, 76)
        Label3.Name = "Label3"
        Label3.Size = New Size(51, 15)
        Label3.TabIndex = 2
        Label3.Text = "Tugboat"
        ' 
        ' cboReport
        ' 
        cboReport.DropDownStyle = ComboBoxStyle.DropDownList
        cboReport.FormattingEnabled = True
        cboReport.Location = New Point(107, 33)
        cboReport.Name = "cboReport"
        cboReport.Size = New Size(329, 23)
        cboReport.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(50, 36)
        Label1.Name = "Label1"
        Label1.Size = New Size(42, 15)
        Label1.TabIndex = 0
        Label1.Text = "Report"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(13, 132)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowTemplate.Height = 25
        DataGridView1.Size = New Size(1364, 354)
        DataGridView1.TabIndex = 8
        DataGridView1.Visible = False
        ' 
        ' btnReport
        ' 
        btnReport.Location = New Point(407, 106)
        btnReport.Name = "btnReport"
        btnReport.Size = New Size(127, 32)
        btnReport.TabIndex = 7
        btnReport.Text = "PRINT"
        btnReport.UseVisualStyleBackColor = True
        ' 
        ' PrintDocument1
        ' 
        ' 
        ' PrintPreviewDialog1
        ' 
        PrintPreviewDialog1.AutoScrollMargin = New Size(0, 0)
        PrintPreviewDialog1.AutoScrollMinSize = New Size(0, 0)
        PrintPreviewDialog1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        PrintPreviewDialog1.ClientSize = New Size(400, 300)
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.Enabled = True
        PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), Icon)
        PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        PrintPreviewDialog1.Visible = False
        ' 
        ' ReportForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLightLight
        ClientSize = New Size(546, 331)
        Controls.Add(btnReport)
        Controls.Add(GroupBox1)
        Controls.Add(Label2)
        Controls.Add(PictureBox1)
        Controls.Add(DataGridView1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "ReportForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ReportForm"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboTugboat As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboReport As ComboBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents btnClose As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnReport As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
End Class

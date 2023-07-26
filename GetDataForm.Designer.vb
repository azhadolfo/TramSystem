<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GetDataForm
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
        dtDateFrom = New DateTimePicker()
        btnGetData = New Button()
        DataGridView1 = New DataGridView()
        Label1 = New Label()
        Label2 = New Label()
        dtDateTo = New DateTimePicker()
        PictureBox1 = New PictureBox()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dtDateFrom
        ' 
        dtDateFrom.Location = New Point(190, 110)
        dtDateFrom.Name = "dtDateFrom"
        dtDateFrom.Size = New Size(200, 23)
        dtDateFrom.TabIndex = 3
        ' 
        ' btnGetData
        ' 
        btnGetData.BackColor = Color.MediumSeaGreen
        btnGetData.Location = New Point(346, 149)
        btnGetData.Name = "btnGetData"
        btnGetData.Size = New Size(122, 23)
        btnGetData.TabIndex = 5
        btnGetData.Text = "GET DATA"
        btnGetData.UseVisualStyleBackColor = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(12, 178)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowTemplate.Height = 25
        DataGridView1.Size = New Size(776, 260)
        DataGridView1.TabIndex = 6
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(114, 116)
        Label1.Name = "Label1"
        Label1.Size = New Size(70, 15)
        Label1.TabIndex = 7
        Label1.Text = "DATE FROM"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(401, 116)
        Label2.Name = "Label2"
        Label2.Size = New Size(21, 15)
        Label2.TabIndex = 8
        Label2.Text = "TO"
        ' 
        ' dtDateTo
        ' 
        dtDateTo.Location = New Point(428, 110)
        dtDateTo.Name = "dtDateTo"
        dtDateTo.Size = New Size(200, 23)
        dtDateTo.TabIndex = 9
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.mmsi
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.Location = New Point(12, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(163, 71)
        PictureBox1.TabIndex = 10
        PictureBox1.TabStop = False
        ' 
        ' GetDataForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLightLight
        ClientSize = New Size(800, 450)
        Controls.Add(PictureBox1)
        Controls.Add(dtDateTo)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(DataGridView1)
        Controls.Add(btnGetData)
        Controls.Add(dtDateFrom)
        Name = "GetDataForm"
        Text = "GetDataForm"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents dtDateFrom As DateTimePicker
    Friend WithEvents btnGetData As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtDateTo As DateTimePicker
    Friend WithEvents PictureBox1 As PictureBox
End Class

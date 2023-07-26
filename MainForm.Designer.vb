<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(MainForm))
        btnGetData = New PictureBox()
        btnDataEntry = New PictureBox()
        btnFile = New PictureBox()
        btnClose = New PictureBox()
        Label1 = New Label()
        Label2 = New Label()
        btnReport = New Label()
        Label4 = New Label()
        PictureBox1 = New PictureBox()
        Label5 = New Label()
        btnUsers = New PictureBox()
        TUGBOAT = New Label()
        btnTugBoat = New PictureBox()
        Button1 = New Button()
        CType(btnGetData, ComponentModel.ISupportInitialize).BeginInit()
        CType(btnDataEntry, ComponentModel.ISupportInitialize).BeginInit()
        CType(btnFile, ComponentModel.ISupportInitialize).BeginInit()
        CType(btnClose, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(btnUsers, ComponentModel.ISupportInitialize).BeginInit()
        CType(btnTugBoat, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnGetData
        ' 
        btnGetData.BackgroundImage = My.Resources.Resources.copy
        resources.ApplyResources(btnGetData, "btnGetData")
        btnGetData.Name = "btnGetData"
        btnGetData.TabStop = False
        ' 
        ' btnDataEntry
        ' 
        btnDataEntry.BackgroundImage = My.Resources.Resources.dataentry3
        resources.ApplyResources(btnDataEntry, "btnDataEntry")
        btnDataEntry.Name = "btnDataEntry"
        btnDataEntry.TabStop = False
        ' 
        ' btnFile
        ' 
        btnFile.BackgroundImage = My.Resources.Resources.dataentry2
        resources.ApplyResources(btnFile, "btnFile")
        btnFile.Name = "btnFile"
        btnFile.TabStop = False
        ' 
        ' btnClose
        ' 
        btnClose.BackgroundImage = My.Resources.Resources.close
        resources.ApplyResources(btnClose, "btnClose")
        btnClose.Name = "btnClose"
        btnClose.TabStop = False
        ' 
        ' Label1
        ' 
        resources.ApplyResources(Label1, "Label1")
        Label1.Name = "Label1"
        ' 
        ' Label2
        ' 
        resources.ApplyResources(Label2, "Label2")
        Label2.Name = "Label2"
        ' 
        ' btnReport
        ' 
        resources.ApplyResources(btnReport, "btnReport")
        btnReport.Name = "btnReport"
        ' 
        ' Label4
        ' 
        resources.ApplyResources(Label4, "Label4")
        Label4.Name = "Label4"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.mmsi
        resources.ApplyResources(PictureBox1, "PictureBox1")
        PictureBox1.Name = "PictureBox1"
        PictureBox1.TabStop = False
        ' 
        ' Label5
        ' 
        resources.ApplyResources(Label5, "Label5")
        Label5.Name = "Label5"
        ' 
        ' btnUsers
        ' 
        btnUsers.BackgroundImage = My.Resources.Resources.dataentry2
        resources.ApplyResources(btnUsers, "btnUsers")
        btnUsers.Name = "btnUsers"
        btnUsers.TabStop = False
        ' 
        ' TUGBOAT
        ' 
        resources.ApplyResources(TUGBOAT, "TUGBOAT")
        TUGBOAT.Name = "TUGBOAT"
        ' 
        ' btnTugBoat
        ' 
        btnTugBoat.BackgroundImage = My.Resources.Resources.dataentry2
        resources.ApplyResources(btnTugBoat, "btnTugBoat")
        btnTugBoat.Name = "btnTugBoat"
        btnTugBoat.TabStop = False
        ' 
        ' Button1
        ' 
        resources.ApplyResources(Button1, "Button1")
        Button1.Name = "Button1"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' MainForm
        ' 
        resources.ApplyResources(Me, "$this")
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLightLight
        ControlBox = False
        Controls.Add(btnClose)
        Controls.Add(Button1)
        Controls.Add(TUGBOAT)
        Controls.Add(btnTugBoat)
        Controls.Add(Label5)
        Controls.Add(btnUsers)
        Controls.Add(PictureBox1)
        Controls.Add(Label4)
        Controls.Add(btnReport)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(btnFile)
        Controls.Add(btnDataEntry)
        Controls.Add(btnGetData)
        Cursor = Cursors.Hand
        FormBorderStyle = FormBorderStyle.Fixed3D
        Name = "MainForm"
        ShowInTaskbar = False
        CType(btnGetData, ComponentModel.ISupportInitialize).EndInit()
        CType(btnDataEntry, ComponentModel.ISupportInitialize).EndInit()
        CType(btnFile, ComponentModel.ISupportInitialize).EndInit()
        CType(btnClose, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(btnUsers, ComponentModel.ISupportInitialize).EndInit()
        CType(btnTugBoat, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents btnGetData As PictureBox
    Friend WithEvents btnDataEntry As PictureBox
    Friend WithEvents btnFile As PictureBox
    Friend WithEvents btnClose As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnReport As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnUsers As PictureBox
    Friend WithEvents TUGBOAT As Label
    Friend WithEvents btnTugBoat As PictureBox
    Friend WithEvents Button1 As Button
End Class

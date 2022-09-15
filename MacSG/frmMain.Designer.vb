<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnGenAll = New System.Windows.Forms.Button()
        Me.btnKillVLC = New System.Windows.Forms.Button()
        Me.btnMoveResize = New System.Windows.Forms.Button()
        Me.stream1Group = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPronouns1 = New System.Windows.Forms.TextBox()
        Me.btnReplay1 = New System.Windows.Forms.Button()
        Me.updStream1 = New System.Windows.Forms.NumericUpDown()
        Me.trkbrStream1 = New System.Windows.Forms.TrackBar()
        Me.txtStream1 = New System.Windows.Forms.TextBox()
        Me.btnStream1Gen = New System.Windows.Forms.Button()
        Me.stream2Group = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPronouns2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnReplay2 = New System.Windows.Forms.Button()
        Me.updStream2 = New System.Windows.Forms.NumericUpDown()
        Me.txtStream2 = New System.Windows.Forms.TextBox()
        Me.trkbrStream2 = New System.Windows.Forms.TrackBar()
        Me.btnStream2Gen = New System.Windows.Forms.Button()
        Me.stream3Group = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPronouns3 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.updStream3 = New System.Windows.Forms.NumericUpDown()
        Me.btnReplay3 = New System.Windows.Forms.Button()
        Me.txtStream3 = New System.Windows.Forms.TextBox()
        Me.trkbrStream3 = New System.Windows.Forms.TrackBar()
        Me.btnStream3Gen = New System.Windows.Forms.Button()
        Me.stream4Group = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPronouns4 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnReplay4 = New System.Windows.Forms.Button()
        Me.updStream4 = New System.Windows.Forms.NumericUpDown()
        Me.txtStream4 = New System.Windows.Forms.TextBox()
        Me.trkbrStream4 = New System.Windows.Forms.TrackBar()
        Me.btnStream4Gen = New System.Windows.Forms.Button()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.fileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiSelectAutocompleteFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiEditAutocompleteFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiChangeVLCWindowSize = New System.Windows.Forms.ToolStripMenuItem()
        Me.InstallMacsgHandlerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiOpenAppData = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiCombineNamesPronouns = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiCondorSchedule = New System.Windows.Forms.ToolStripMenuItem()
        Me.StreamlinkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiEditStreamlinkConfig = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiResetStreamlinkPath = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.statusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stream1Group.SuspendLayout()
        CType(Me.updStream1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkbrStream1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stream2Group.SuspendLayout()
        CType(Me.updStream2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkbrStream2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stream3Group.SuspendLayout()
        CType(Me.updStream3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkbrStream3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stream4Group.SuspendLayout()
        CType(Me.updStream4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkbrStream4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGenAll
        '
        Me.btnGenAll.Location = New System.Drawing.Point(310, 69)
        Me.btnGenAll.Name = "btnGenAll"
        Me.btnGenAll.Size = New System.Drawing.Size(101, 29)
        Me.btnGenAll.TabIndex = 17
        Me.btnGenAll.Text = "Generate all"
        Me.btnGenAll.UseVisualStyleBackColor = True
        '
        'btnKillVLC
        '
        Me.btnKillVLC.Location = New System.Drawing.Point(310, 103)
        Me.btnKillVLC.Name = "btnKillVLC"
        Me.btnKillVLC.Size = New System.Drawing.Size(101, 29)
        Me.btnKillVLC.TabIndex = 16
        Me.btnKillVLC.Text = "Close all windows"
        Me.btnKillVLC.UseVisualStyleBackColor = True
        '
        'btnMoveResize
        '
        Me.btnMoveResize.Location = New System.Drawing.Point(310, 34)
        Me.btnMoveResize.Name = "btnMoveResize"
        Me.btnMoveResize.Size = New System.Drawing.Size(101, 29)
        Me.btnMoveResize.TabIndex = 15
        Me.btnMoveResize.Text = "Move and Resize"
        Me.btnMoveResize.UseVisualStyleBackColor = True
        '
        'stream1Group
        '
        Me.stream1Group.Controls.Add(Me.Label2)
        Me.stream1Group.Controls.Add(Me.Label1)
        Me.stream1Group.Controls.Add(Me.txtPronouns1)
        Me.stream1Group.Controls.Add(Me.btnReplay1)
        Me.stream1Group.Controls.Add(Me.updStream1)
        Me.stream1Group.Controls.Add(Me.trkbrStream1)
        Me.stream1Group.Controls.Add(Me.txtStream1)
        Me.stream1Group.Controls.Add(Me.btnStream1Gen)
        Me.stream1Group.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stream1Group.Location = New System.Drawing.Point(12, 27)
        Me.stream1Group.Name = "stream1Group"
        Me.stream1Group.Size = New System.Drawing.Size(292, 69)
        Me.stream1Group.TabIndex = 11
        Me.stream1Group.TabStop = False
        Me.stream1Group.Text = "Stream 1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Pronouns"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Username"
        '
        'txtPronouns1
        '
        Me.txtPronouns1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtPronouns1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPronouns1.Location = New System.Drawing.Point(63, 42)
        Me.txtPronouns1.Name = "txtPronouns1"
        Me.txtPronouns1.Size = New System.Drawing.Size(67, 20)
        Me.txtPronouns1.TabIndex = 23
        Me.txtPronouns1.WordWrap = False
        '
        'btnReplay1
        '
        Me.btnReplay1.Location = New System.Drawing.Point(200, 43)
        Me.btnReplay1.Name = "btnReplay1"
        Me.btnReplay1.Size = New System.Drawing.Size(20, 21)
        Me.btnReplay1.TabIndex = 22
        Me.btnReplay1.Text = "R"
        Me.btnReplay1.UseVisualStyleBackColor = True
        '
        'updStream1
        '
        Me.updStream1.Location = New System.Drawing.Point(236, 44)
        Me.updStream1.Name = "updStream1"
        Me.updStream1.Size = New System.Drawing.Size(39, 20)
        Me.updStream1.TabIndex = 8
        '
        'trkbrStream1
        '
        Me.trkbrStream1.Enabled = False
        Me.trkbrStream1.LargeChange = 1
        Me.trkbrStream1.Location = New System.Drawing.Point(226, 13)
        Me.trkbrStream1.Maximum = 4
        Me.trkbrStream1.Minimum = 1
        Me.trkbrStream1.Name = "trkbrStream1"
        Me.trkbrStream1.Size = New System.Drawing.Size(60, 45)
        Me.trkbrStream1.TabIndex = 3
        Me.trkbrStream1.TabStop = False
        Me.trkbrStream1.Value = 4
        '
        'txtStream1
        '
        Me.txtStream1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtStream1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtStream1.Location = New System.Drawing.Point(63, 16)
        Me.txtStream1.Name = "txtStream1"
        Me.txtStream1.Size = New System.Drawing.Size(157, 20)
        Me.txtStream1.TabIndex = 0
        '
        'btnStream1Gen
        '
        Me.btnStream1Gen.Location = New System.Drawing.Point(136, 43)
        Me.btnStream1Gen.Name = "btnStream1Gen"
        Me.btnStream1Gen.Size = New System.Drawing.Size(60, 21)
        Me.btnStream1Gen.TabIndex = 1
        Me.btnStream1Gen.Text = "Generate"
        Me.btnStream1Gen.UseVisualStyleBackColor = True
        '
        'stream2Group
        '
        Me.stream2Group.Controls.Add(Me.Label3)
        Me.stream2Group.Controls.Add(Me.txtPronouns2)
        Me.stream2Group.Controls.Add(Me.Label4)
        Me.stream2Group.Controls.Add(Me.btnReplay2)
        Me.stream2Group.Controls.Add(Me.updStream2)
        Me.stream2Group.Controls.Add(Me.txtStream2)
        Me.stream2Group.Controls.Add(Me.trkbrStream2)
        Me.stream2Group.Controls.Add(Me.btnStream2Gen)
        Me.stream2Group.Location = New System.Drawing.Point(12, 102)
        Me.stream2Group.Name = "stream2Group"
        Me.stream2Group.Size = New System.Drawing.Size(292, 69)
        Me.stream2Group.TabIndex = 12
        Me.stream2Group.TabStop = False
        Me.stream2Group.Text = "Stream 2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Pronouns"
        '
        'txtPronouns2
        '
        Me.txtPronouns2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtPronouns2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPronouns2.Location = New System.Drawing.Point(63, 42)
        Me.txtPronouns2.Name = "txtPronouns2"
        Me.txtPronouns2.Size = New System.Drawing.Size(67, 20)
        Me.txtPronouns2.TabIndex = 24
        Me.txtPronouns2.WordWrap = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Username"
        '
        'btnReplay2
        '
        Me.btnReplay2.Location = New System.Drawing.Point(200, 42)
        Me.btnReplay2.Name = "btnReplay2"
        Me.btnReplay2.Size = New System.Drawing.Size(20, 21)
        Me.btnReplay2.TabIndex = 23
        Me.btnReplay2.Text = "R"
        Me.btnReplay2.UseVisualStyleBackColor = True
        '
        'updStream2
        '
        Me.updStream2.Location = New System.Drawing.Point(237, 43)
        Me.updStream2.Name = "updStream2"
        Me.updStream2.Size = New System.Drawing.Size(38, 20)
        Me.updStream2.TabIndex = 11
        '
        'txtStream2
        '
        Me.txtStream2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtStream2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtStream2.Location = New System.Drawing.Point(63, 16)
        Me.txtStream2.Name = "txtStream2"
        Me.txtStream2.Size = New System.Drawing.Size(157, 20)
        Me.txtStream2.TabIndex = 0
        '
        'trkbrStream2
        '
        Me.trkbrStream2.Enabled = False
        Me.trkbrStream2.LargeChange = 1
        Me.trkbrStream2.Location = New System.Drawing.Point(226, 13)
        Me.trkbrStream2.Maximum = 4
        Me.trkbrStream2.Minimum = 1
        Me.trkbrStream2.Name = "trkbrStream2"
        Me.trkbrStream2.Size = New System.Drawing.Size(60, 45)
        Me.trkbrStream2.TabIndex = 3
        Me.trkbrStream2.TabStop = False
        Me.trkbrStream2.Value = 4
        '
        'btnStream2Gen
        '
        Me.btnStream2Gen.Location = New System.Drawing.Point(136, 42)
        Me.btnStream2Gen.Name = "btnStream2Gen"
        Me.btnStream2Gen.Size = New System.Drawing.Size(60, 21)
        Me.btnStream2Gen.TabIndex = 1
        Me.btnStream2Gen.Text = "Generate"
        Me.btnStream2Gen.UseVisualStyleBackColor = True
        '
        'stream3Group
        '
        Me.stream3Group.Controls.Add(Me.Label5)
        Me.stream3Group.Controls.Add(Me.txtPronouns3)
        Me.stream3Group.Controls.Add(Me.Label6)
        Me.stream3Group.Controls.Add(Me.updStream3)
        Me.stream3Group.Controls.Add(Me.btnReplay3)
        Me.stream3Group.Controls.Add(Me.txtStream3)
        Me.stream3Group.Controls.Add(Me.trkbrStream3)
        Me.stream3Group.Controls.Add(Me.btnStream3Gen)
        Me.stream3Group.Location = New System.Drawing.Point(12, 177)
        Me.stream3Group.Name = "stream3Group"
        Me.stream3Group.Size = New System.Drawing.Size(292, 69)
        Me.stream3Group.TabIndex = 13
        Me.stream3Group.TabStop = False
        Me.stream3Group.Text = "Stream 3"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Pronouns"
        '
        'txtPronouns3
        '
        Me.txtPronouns3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtPronouns3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPronouns3.Location = New System.Drawing.Point(63, 42)
        Me.txtPronouns3.Name = "txtPronouns3"
        Me.txtPronouns3.Size = New System.Drawing.Size(67, 20)
        Me.txtPronouns3.TabIndex = 25
        Me.txtPronouns3.WordWrap = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Username"
        '
        'updStream3
        '
        Me.updStream3.Location = New System.Drawing.Point(237, 43)
        Me.updStream3.Name = "updStream3"
        Me.updStream3.Size = New System.Drawing.Size(38, 20)
        Me.updStream3.TabIndex = 12
        '
        'btnReplay3
        '
        Me.btnReplay3.Location = New System.Drawing.Point(200, 42)
        Me.btnReplay3.Name = "btnReplay3"
        Me.btnReplay3.Size = New System.Drawing.Size(20, 21)
        Me.btnReplay3.TabIndex = 24
        Me.btnReplay3.Text = "R"
        Me.btnReplay3.UseVisualStyleBackColor = True
        '
        'txtStream3
        '
        Me.txtStream3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtStream3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtStream3.Location = New System.Drawing.Point(63, 16)
        Me.txtStream3.Name = "txtStream3"
        Me.txtStream3.Size = New System.Drawing.Size(157, 20)
        Me.txtStream3.TabIndex = 0
        '
        'trkbrStream3
        '
        Me.trkbrStream3.Enabled = False
        Me.trkbrStream3.LargeChange = 1
        Me.trkbrStream3.Location = New System.Drawing.Point(226, 13)
        Me.trkbrStream3.Maximum = 4
        Me.trkbrStream3.Minimum = 1
        Me.trkbrStream3.Name = "trkbrStream3"
        Me.trkbrStream3.Size = New System.Drawing.Size(60, 45)
        Me.trkbrStream3.TabIndex = 3
        Me.trkbrStream3.TabStop = False
        Me.trkbrStream3.Value = 4
        '
        'btnStream3Gen
        '
        Me.btnStream3Gen.Location = New System.Drawing.Point(136, 42)
        Me.btnStream3Gen.Name = "btnStream3Gen"
        Me.btnStream3Gen.Size = New System.Drawing.Size(60, 21)
        Me.btnStream3Gen.TabIndex = 1
        Me.btnStream3Gen.Text = "Generate"
        Me.btnStream3Gen.UseVisualStyleBackColor = True
        '
        'stream4Group
        '
        Me.stream4Group.Controls.Add(Me.Label7)
        Me.stream4Group.Controls.Add(Me.txtPronouns4)
        Me.stream4Group.Controls.Add(Me.Label8)
        Me.stream4Group.Controls.Add(Me.btnReplay4)
        Me.stream4Group.Controls.Add(Me.updStream4)
        Me.stream4Group.Controls.Add(Me.txtStream4)
        Me.stream4Group.Controls.Add(Me.trkbrStream4)
        Me.stream4Group.Controls.Add(Me.btnStream4Gen)
        Me.stream4Group.Location = New System.Drawing.Point(12, 252)
        Me.stream4Group.Name = "stream4Group"
        Me.stream4Group.Size = New System.Drawing.Size(292, 69)
        Me.stream4Group.TabIndex = 14
        Me.stream4Group.TabStop = False
        Me.stream4Group.Text = "Stream 4"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Pronouns"
        '
        'txtPronouns4
        '
        Me.txtPronouns4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtPronouns4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPronouns4.Location = New System.Drawing.Point(63, 42)
        Me.txtPronouns4.Name = "txtPronouns4"
        Me.txtPronouns4.Size = New System.Drawing.Size(67, 20)
        Me.txtPronouns4.TabIndex = 25
        Me.txtPronouns4.WordWrap = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 13)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Username"
        '
        'btnReplay4
        '
        Me.btnReplay4.Location = New System.Drawing.Point(200, 42)
        Me.btnReplay4.Name = "btnReplay4"
        Me.btnReplay4.Size = New System.Drawing.Size(20, 21)
        Me.btnReplay4.TabIndex = 25
        Me.btnReplay4.Text = "R"
        Me.btnReplay4.UseVisualStyleBackColor = True
        '
        'updStream4
        '
        Me.updStream4.Location = New System.Drawing.Point(237, 43)
        Me.updStream4.Name = "updStream4"
        Me.updStream4.Size = New System.Drawing.Size(38, 20)
        Me.updStream4.TabIndex = 13
        '
        'txtStream4
        '
        Me.txtStream4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtStream4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtStream4.Location = New System.Drawing.Point(63, 16)
        Me.txtStream4.Name = "txtStream4"
        Me.txtStream4.Size = New System.Drawing.Size(157, 20)
        Me.txtStream4.TabIndex = 0
        '
        'trkbrStream4
        '
        Me.trkbrStream4.Enabled = False
        Me.trkbrStream4.LargeChange = 1
        Me.trkbrStream4.Location = New System.Drawing.Point(226, 13)
        Me.trkbrStream4.Maximum = 4
        Me.trkbrStream4.Minimum = 1
        Me.trkbrStream4.Name = "trkbrStream4"
        Me.trkbrStream4.Size = New System.Drawing.Size(60, 45)
        Me.trkbrStream4.TabIndex = 3
        Me.trkbrStream4.TabStop = False
        Me.trkbrStream4.Value = 4
        '
        'btnStream4Gen
        '
        Me.btnStream4Gen.Location = New System.Drawing.Point(136, 42)
        Me.btnStream4Gen.Name = "btnStream4Gen"
        Me.btnStream4Gen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnStream4Gen.Size = New System.Drawing.Size(60, 21)
        Me.btnStream4Gen.TabIndex = 1
        Me.btnStream4Gen.Text = "Generate"
        Me.btnStream4Gen.UseVisualStyleBackColor = True
        '
        'menuStrip1
        '
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem1, Me.tsmiCondorSchedule, Me.StreamlinkToolStripMenuItem})
        Me.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.MaximumSize = New System.Drawing.Size(470, 24)
        Me.menuStrip1.MinimumSize = New System.Drawing.Size(470, 24)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.menuStrip1.Size = New System.Drawing.Size(470, 24)
        Me.menuStrip1.TabIndex = 18
        '
        'fileToolStripMenuItem1
        '
        Me.fileToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiSelectAutocompleteFile, Me.tsmiEditAutocompleteFile, Me.tsmiChangeVLCWindowSize, Me.InstallMacsgHandlerToolStripMenuItem, Me.tsmiOpenAppData, Me.tsmiCombineNamesPronouns})
        Me.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1"
        Me.fileToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.fileToolStripMenuItem1.Text = "File"
        '
        'tsmiSelectAutocompleteFile
        '
        Me.tsmiSelectAutocompleteFile.Name = "tsmiSelectAutocompleteFile"
        Me.tsmiSelectAutocompleteFile.Size = New System.Drawing.Size(240, 22)
        Me.tsmiSelectAutocompleteFile.Text = "Select autocomplete file..."
        '
        'tsmiEditAutocompleteFile
        '
        Me.tsmiEditAutocompleteFile.Name = "tsmiEditAutocompleteFile"
        Me.tsmiEditAutocompleteFile.Size = New System.Drawing.Size(240, 22)
        Me.tsmiEditAutocompleteFile.Text = "Edit autocomplete file..."
        '
        'tsmiChangeVLCWindowSize
        '
        Me.tsmiChangeVLCWindowSize.Name = "tsmiChangeVLCWindowSize"
        Me.tsmiChangeVLCWindowSize.Size = New System.Drawing.Size(240, 22)
        Me.tsmiChangeVLCWindowSize.Text = "Change window size..."
        '
        'InstallMacsgHandlerToolStripMenuItem
        '
        Me.InstallMacsgHandlerToolStripMenuItem.Name = "InstallMacsgHandlerToolStripMenuItem"
        Me.InstallMacsgHandlerToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.InstallMacsgHandlerToolStripMenuItem.Text = "Install macsg: protocol"
        '
        'tsmiOpenAppData
        '
        Me.tsmiOpenAppData.Name = "tsmiOpenAppData"
        Me.tsmiOpenAppData.Size = New System.Drawing.Size(240, 22)
        Me.tsmiOpenAppData.Text = "Open AppData folder..."
        '
        'tsmiCombineNamesPronouns
        '
        Me.tsmiCombineNamesPronouns.CheckOnClick = True
        Me.tsmiCombineNamesPronouns.Name = "tsmiCombineNamesPronouns"
        Me.tsmiCombineNamesPronouns.Size = New System.Drawing.Size(240, 22)
        Me.tsmiCombineNamesPronouns.Text = "Combine Names and Pronouns"
        '
        'tsmiCondorSchedule
        '
        Me.tsmiCondorSchedule.AutoToolTip = True
        Me.tsmiCondorSchedule.Name = "tsmiCondorSchedule"
        Me.tsmiCondorSchedule.Size = New System.Drawing.Size(118, 20)
        Me.tsmiCondorSchedule.Text = "CoNDOR Schedule"
        '
        'StreamlinkToolStripMenuItem
        '
        Me.StreamlinkToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiEditStreamlinkConfig, Me.tsmiResetStreamlinkPath})
        Me.StreamlinkToolStripMenuItem.Name = "StreamlinkToolStripMenuItem"
        Me.StreamlinkToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.StreamlinkToolStripMenuItem.Text = "Streamlink"
        '
        'tsmiEditStreamlinkConfig
        '
        Me.tsmiEditStreamlinkConfig.Name = "tsmiEditStreamlinkConfig"
        Me.tsmiEditStreamlinkConfig.Size = New System.Drawing.Size(159, 22)
        Me.tsmiEditStreamlinkConfig.Text = "Edit config file..."
        '
        'tsmiResetStreamlinkPath
        '
        Me.tsmiResetStreamlinkPath.BackColor = System.Drawing.SystemColors.Control
        Me.tsmiResetStreamlinkPath.Name = "tsmiResetStreamlinkPath"
        Me.tsmiResetStreamlinkPath.Size = New System.Drawing.Size(159, 22)
        Me.tsmiResetStreamlinkPath.Text = "Reset path"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 22)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(348, 4)
        Me.ProgressBar1.TabIndex = 19
        Me.ProgressBar1.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusLabel1, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 320)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip1.Size = New System.Drawing.Size(418, 22)
        Me.StatusStrip1.TabIndex = 21
        '
        'statusLabel1
        '
        Me.statusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.statusLabel1.Name = "statusLabel1"
        Me.statusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 342)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.menuStrip1)
        Me.Controls.Add(Me.btnGenAll)
        Me.Controls.Add(Me.btnKillVLC)
        Me.Controls.Add(Me.btnMoveResize)
        Me.Controls.Add(Me.stream1Group)
        Me.Controls.Add(Me.stream2Group)
        Me.Controls.Add(Me.stream3Group)
        Me.Controls.Add(Me.stream4Group)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(600, 381)
        Me.MinimumSize = New System.Drawing.Size(381, 381)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "MacSG"
        Me.stream1Group.ResumeLayout(False)
        Me.stream1Group.PerformLayout()
        CType(Me.updStream1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkbrStream1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stream2Group.ResumeLayout(False)
        Me.stream2Group.PerformLayout()
        CType(Me.updStream2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkbrStream2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stream3Group.ResumeLayout(False)
        Me.stream3Group.PerformLayout()
        CType(Me.updStream3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkbrStream3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stream4Group.ResumeLayout(False)
        Me.stream4Group.PerformLayout()
        CType(Me.updStream4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkbrStream4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnGenAll As Button
    Private WithEvents btnKillVLC As Button
    Private WithEvents btnMoveResize As Button
    Private WithEvents stream1Group As GroupBox
    Friend WithEvents updStream1 As NumericUpDown
    Friend WithEvents trkbrStream1 As TrackBar
    Friend WithEvents txtStream1 As TextBox
    Private WithEvents btnStream1Gen As Button
    Private WithEvents stream2Group As GroupBox
    Friend WithEvents updStream2 As NumericUpDown
    Friend WithEvents txtStream2 As TextBox
    Friend WithEvents trkbrStream2 As TrackBar
    Private WithEvents btnStream2Gen As Button
    Private WithEvents stream3Group As GroupBox
    Friend WithEvents updStream3 As NumericUpDown
    Friend WithEvents txtStream3 As TextBox
    Friend WithEvents trkbrStream3 As TrackBar
    Private WithEvents btnStream3Gen As Button
    Private WithEvents stream4Group As GroupBox
    Friend WithEvents updStream4 As NumericUpDown
    Friend WithEvents txtStream4 As TextBox
    Friend WithEvents trkbrStream4 As TrackBar
    Private WithEvents btnStream4Gen As Button
    Private WithEvents menuStrip1 As MenuStrip
    Private WithEvents fileToolStripMenuItem1 As ToolStripMenuItem
    Private WithEvents tsmiSelectAutocompleteFile As ToolStripMenuItem
    Friend WithEvents tsmiEditAutocompleteFile As ToolStripMenuItem
    Friend WithEvents tsmiChangeVLCWindowSize As ToolStripMenuItem
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents InstallMacsgHandlerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents statusLabel1 As ToolStripStatusLabel
    Friend WithEvents tsmiCondorSchedule As ToolStripMenuItem
    Friend WithEvents btnReplay1 As Button
    Friend WithEvents btnReplay2 As Button
    Friend WithEvents btnReplay3 As Button
    Friend WithEvents btnReplay4 As Button
    Friend WithEvents tsmiOpenAppData As ToolStripMenuItem
    Friend WithEvents StreamlinkToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsmiEditStreamlinkConfig As ToolStripMenuItem
    Friend WithEvents tsmiResetStreamlinkPath As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents txtPronouns1 As TextBox
    Friend WithEvents txtPronouns2 As TextBox
    Friend WithEvents txtPronouns3 As TextBox
    Friend WithEvents txtPronouns4 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents tsmiCombineNamesPronouns As ToolStripMenuItem
End Class

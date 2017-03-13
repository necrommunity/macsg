<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSchedule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSchedule))
        Me.dgvSchedule = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.timestamp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.racer_1_rtmp_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.racer_2_rtmp_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.league = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvSchedule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvSchedule
        '
        Me.dgvSchedule.AllowUserToAddRows = False
        Me.dgvSchedule.AllowUserToDeleteRows = False
        Me.dgvSchedule.AllowUserToResizeColumns = False
        Me.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSchedule.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.timestamp, Me.racer_1_rtmp_name, Me.racer_2_rtmp_name, Me.league})
        Me.dgvSchedule.Location = New System.Drawing.Point(12, 88)
        Me.dgvSchedule.Name = "dgvSchedule"
        Me.dgvSchedule.ReadOnly = True
        Me.dgvSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSchedule.Size = New System.Drawing.Size(480, 242)
        Me.dgvSchedule.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(406, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "All times are in UTC.  Double click the left most column to automatically open a " &
    "race. "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(200, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Use the search box below to filter results."
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(368, 52)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(124, 20)
        Me.btnFilter.TabIndex = 4
        Me.btnFilter.Text = "Filter schedule..."
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'txtFilter
        '
        Me.txtFilter.AcceptsReturn = True
        Me.txtFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtFilter.Location = New System.Drawing.Point(12, 52)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(350, 20)
        Me.txtFilter.TabIndex = 5
        '
        'timestamp
        '
        Me.timestamp.Frozen = True
        Me.timestamp.HeaderText = "Timestamp"
        Me.timestamp.Name = "timestamp"
        Me.timestamp.ReadOnly = True
        Me.timestamp.Width = 115
        '
        'racer_1_rtmp_name
        '
        Me.racer_1_rtmp_name.Frozen = True
        Me.racer_1_rtmp_name.HeaderText = "Racer 1"
        Me.racer_1_rtmp_name.Name = "racer_1_rtmp_name"
        Me.racer_1_rtmp_name.ReadOnly = True
        Me.racer_1_rtmp_name.Width = 115
        '
        'racer_2_rtmp_name
        '
        Me.racer_2_rtmp_name.Frozen = True
        Me.racer_2_rtmp_name.HeaderText = "Racer 2"
        Me.racer_2_rtmp_name.Name = "racer_2_rtmp_name"
        Me.racer_2_rtmp_name.ReadOnly = True
        Me.racer_2_rtmp_name.Width = 115
        '
        'league
        '
        Me.league.Frozen = True
        Me.league.HeaderText = "Division"
        Me.league.Name = "league"
        Me.league.ReadOnly = True
        '
        'frmSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 342)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvSchedule)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSchedule"
        Me.Text = "Schedule"
        CType(Me.dgvSchedule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvSchedule As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnFilter As Button
    Friend WithEvents txtFilter As TextBox
    Friend WithEvents timestamp As DataGridViewTextBoxColumn
    Friend WithEvents racer_1_rtmp_name As DataGridViewTextBoxColumn
    Friend WithEvents racer_2_rtmp_name As DataGridViewTextBoxColumn
    Friend WithEvents league As DataGridViewTextBoxColumn
End Class

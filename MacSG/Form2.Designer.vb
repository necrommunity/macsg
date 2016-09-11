<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.dgdStreamerList = New System.Windows.Forms.DataGridView()
        Me.lblStreamerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgdStreamerList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgdStreamerList
        '
        Me.dgdStreamerList.AllowUserToResizeRows = False
        Me.dgdStreamerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgdStreamerList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.lblStreamerName})
        Me.dgdStreamerList.Location = New System.Drawing.Point(13, 13)
        Me.dgdStreamerList.MaximumSize = New System.Drawing.Size(249, 212)
        Me.dgdStreamerList.MinimumSize = New System.Drawing.Size(249, 212)
        Me.dgdStreamerList.Name = "dgdStreamerList"
        Me.dgdStreamerList.Size = New System.Drawing.Size(249, 212)
        Me.dgdStreamerList.TabIndex = 0
        '
        'lblStreamerName
        '
        Me.lblStreamerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.lblStreamerName.HeaderText = "Streamer name"
        Me.lblStreamerName.Name = "lblStreamerName"
        Me.lblStreamerName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(274, 236)
        Me.Controls.Add(Me.dgdStreamerList)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form2"
        Me.Text = "Edit streamer file"
        CType(Me.dgdStreamerList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgdStreamerList As DataGridView
    Friend WithEvents lblStreamerName As DataGridViewTextBoxColumn
End Class

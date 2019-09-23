<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BlackListControl
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.listbox_blacklistselection = New System.Windows.Forms.ListBox()
        Me.btn_removeitem = New System.Windows.Forms.Button()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(877, 269)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.listbox_blacklistselection)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(877, 269)
        Me.Panel2.TabIndex = 0
        '
        'listbox_blacklistselection
        '
        Me.listbox_blacklistselection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listbox_blacklistselection.FormattingEnabled = True
        Me.listbox_blacklistselection.Location = New System.Drawing.Point(0, 0)
        Me.listbox_blacklistselection.Name = "listbox_blacklistselection"
        Me.listbox_blacklistselection.Size = New System.Drawing.Size(877, 269)
        Me.listbox_blacklistselection.TabIndex = 0
        '
        'btn_removeitem
        '
        Me.btn_removeitem.Location = New System.Drawing.Point(3, 3)
        Me.btn_removeitem.Name = "btn_removeitem"
        Me.btn_removeitem.Size = New System.Drawing.Size(75, 23)
        Me.btn_removeitem.TabIndex = 1
        Me.btn_removeitem.Text = "Remove"
        Me.btn_removeitem.UseVisualStyleBackColor = True
        '
        'btn_close
        '
        Me.btn_close.Location = New System.Drawing.Point(84, 3)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(75, 23)
        Me.btn_close.TabIndex = 2
        Me.btn_close.Text = "Close"
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_removeitem)
        Me.FlowLayoutPanel1.Controls.Add(Me.btn_close)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 9)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(200, 32)
        Me.FlowLayoutPanel1.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 266)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(877, 47)
        Me.Panel3.TabIndex = 1
        '
        'BlackListControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 313)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "BlackListControl"
        Me.Text = "BlackListControl"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_removeitem As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents listbox_blacklistselection As System.Windows.Forms.ListBox
    Friend WithEvents btn_close As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
End Class

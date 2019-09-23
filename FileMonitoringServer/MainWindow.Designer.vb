<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindow
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btn_SendReport = New System.Windows.Forms.Button()
        Me.timer_blacklist = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btn_viewblacklist = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lbl_TotalRemoved = New System.Windows.Forms.Label()
        Me.lbl_TotalRemovedByDay = New System.Windows.Forms.Label()
        Me.lbl_TotalSize = New System.Windows.Forms.Label()
        Me.lbl_TotalSizeByDay = New System.Windows.Forms.Label()
        Me.btn_SaveActualLog = New System.Windows.Forms.Button()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Path:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(51, 14)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(295, 20)
        Me.TextBox1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(352, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Browse"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.HideSelection = False
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 0)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(596, 294)
        Me.RichTextBox1.TabIndex = 3
        Me.RichTextBox1.Text = ""
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.IncludeSubdirectories = True
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(4, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Save XML"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 5000
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(85, 6)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Report"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'btn_SendReport
        '
        Me.btn_SendReport.Location = New System.Drawing.Point(216, 6)
        Me.btn_SendReport.Name = "btn_SendReport"
        Me.btn_SendReport.Size = New System.Drawing.Size(95, 23)
        Me.btn_SendReport.TabIndex = 6
        Me.btn_SendReport.Text = "Send Report"
        Me.btn_SendReport.UseVisualStyleBackColor = True
        '
        'timer_blacklist
        '
        Me.timer_blacklist.Enabled = True
        Me.timer_blacklist.Interval = 60000
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(596, 53)
        Me.Panel1.TabIndex = 8
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RichTextBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 53)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(596, 294)
        Me.Panel2.TabIndex = 9
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Button3)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(228, 91)
        Me.Panel3.TabIndex = 10
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btn_SaveActualLog)
        Me.Panel4.Controls.Add(Me.btn_viewblacklist)
        Me.Panel4.Controls.Add(Me.btn_SendReport)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(282, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(314, 91)
        Me.Panel4.TabIndex = 11
        '
        'btn_viewblacklist
        '
        Me.btn_viewblacklist.Location = New System.Drawing.Point(3, 6)
        Me.btn_viewblacklist.Name = "btn_viewblacklist"
        Me.btn_viewblacklist.Size = New System.Drawing.Size(75, 23)
        Me.btn_viewblacklist.TabIndex = 7
        Me.btn_viewblacklist.Text = "Black List"
        Me.btn_viewblacklist.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Panel3)
        Me.Panel5.Controls.Add(Me.Panel4)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 347)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(596, 91)
        Me.Panel5.TabIndex = 12
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.lbl_TotalRemoved)
        Me.Panel6.Controls.Add(Me.lbl_TotalRemovedByDay)
        Me.Panel6.Controls.Add(Me.lbl_TotalSize)
        Me.Panel6.Controls.Add(Me.lbl_TotalSizeByDay)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(0, 384)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(596, 33)
        Me.Panel6.TabIndex = 13
        '
        'lbl_TotalRemoved
        '
        Me.lbl_TotalRemoved.AutoSize = True
        Me.lbl_TotalRemoved.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotalRemoved.Location = New System.Drawing.Point(468, 8)
        Me.lbl_TotalRemoved.Name = "lbl_TotalRemoved"
        Me.lbl_TotalRemoved.Size = New System.Drawing.Size(16, 18)
        Me.lbl_TotalRemoved.TabIndex = 3
        Me.lbl_TotalRemoved.Text = "0"
        '
        'lbl_TotalRemovedByDay
        '
        Me.lbl_TotalRemovedByDay.AutoSize = True
        Me.lbl_TotalRemovedByDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotalRemovedByDay.Location = New System.Drawing.Point(310, 8)
        Me.lbl_TotalRemovedByDay.Name = "lbl_TotalRemovedByDay"
        Me.lbl_TotalRemovedByDay.Size = New System.Drawing.Size(145, 18)
        Me.lbl_TotalRemovedByDay.TabIndex = 2
        Me.lbl_TotalRemovedByDay.Text = "Total Removed (BL):"
        '
        'lbl_TotalSize
        '
        Me.lbl_TotalSize.AutoSize = True
        Me.lbl_TotalSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotalSize.Location = New System.Drawing.Point(143, 8)
        Me.lbl_TotalSize.Name = "lbl_TotalSize"
        Me.lbl_TotalSize.Size = New System.Drawing.Size(16, 18)
        Me.lbl_TotalSize.TabIndex = 1
        Me.lbl_TotalSize.Text = "0"
        '
        'lbl_TotalSizeByDay
        '
        Me.lbl_TotalSizeByDay.AutoSize = True
        Me.lbl_TotalSizeByDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotalSizeByDay.Location = New System.Drawing.Point(4, 8)
        Me.lbl_TotalSizeByDay.Name = "lbl_TotalSizeByDay"
        Me.lbl_TotalSizeByDay.Size = New System.Drawing.Size(133, 18)
        Me.lbl_TotalSizeByDay.TabIndex = 0
        Me.lbl_TotalSizeByDay.Text = "Total Size By Day: "
        '
        'btn_SaveActualLog
        '
        Me.btn_SaveActualLog.Location = New System.Drawing.Point(110, 6)
        Me.btn_SaveActualLog.Name = "btn_SaveActualLog"
        Me.btn_SaveActualLog.Size = New System.Drawing.Size(75, 23)
        Me.btn_SaveActualLog.TabIndex = 8
        Me.btn_SaveActualLog.Text = "Save log"
        Me.btn_SaveActualLog.UseVisualStyleBackColor = True
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(596, 417)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainWindow"
        Me.Text = "Folder Storage Monitor"
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents FileSystemWatcher1 As System.IO.FileSystemWatcher
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btn_SendReport As System.Windows.Forms.Button
    Friend WithEvents timer_blacklist As System.Windows.Forms.Timer
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lbl_TotalSize As System.Windows.Forms.Label
    Friend WithEvents lbl_TotalSizeByDay As System.Windows.Forms.Label
    Friend WithEvents lbl_TotalRemoved As System.Windows.Forms.Label
    Friend WithEvents lbl_TotalRemovedByDay As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_viewblacklist As System.Windows.Forms.Button
    Friend WithEvents btn_SaveActualLog As System.Windows.Forms.Button
End Class

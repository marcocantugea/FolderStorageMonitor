Public Class MainWindow

    Private _FolderToWatch As String
    Private _ItemsCollected As New FileMonitoringCore.com.lib.objects.FileObjCollection
    Private _RunDate As Date


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FolderBrowserDialog1.ShowDialog()
        TextBox1.Text = FolderBrowserDialog1.SelectedPath
        _FolderToWatch = TextBox1.Text
        FileSystemWatcher1.Path = _FolderToWatch
    End Sub

    Private Sub FileSystemWatcher1_Changed(ByVal sender As System.Object, ByVal e As System.IO.FileSystemEventArgs) Handles FileSystemWatcher1.Changed

    End Sub

    Private Sub FileSystemWatcher1_Created(ByVal sender As Object, ByVal e As System.IO.FileSystemEventArgs) Handles FileSystemWatcher1.Created
        Try
            'System.Threading.Thread.Sleep(500)
            Dim filecreated As New IO.FileInfo(e.FullPath)
            If Not filecreated.Extension.Equals("") Then
                Dim fileobj As New FileMonitoringCore.com.lib.objects.FileObj(filecreated)
                _ItemsCollected.Add(fileobj)
                'Dim filesize As Long
                'Dim label As String
                'If fileobj.SizeFileinMB = 0 Then
                '    filesize = fileobj.SizeFileinKB
                '    label = "KB"
                'Else
                '    filesize = fileobj.SizeFileinMB
                '    label = "MB"
                'End If

                RichTextBox1.AppendText(fileobj.FileName.ToString & vbCrLf)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SaveXML()
    End Sub

    Public Sub DisplayTotal()
        Dim totalkb As Long = _ItemsCollected.TotalinBytesOfFiles / 1024
        Dim totalmb As Long = totalkb / 1024
        Dim totalgb As Long = totalmb / 1024

        If totalkb < 1024 Then
            RichTextBox1.AppendText("Total Copied:" & FormatNumber(totalkb, 2) & " KB" & vbCrLf)
        End If

        If totalkb > 1024 And totalmb < 1024 Then
            RichTextBox1.AppendText("Total Copied:" & FormatNumber(totalmb, 2) & " MB" & vbCrLf)
        End If

        If totalkb > 1024 And totalmb > 1024 Then
            RichTextBox1.AppendText("Total Copied:" & FormatNumber(totalgb, 2) & " GB" & vbCrLf)
        End If
    End Sub

    Public Sub SaveXML()
        Try
            Dim xmlsaver As New FileMonitoringCore.com.lib.file.XMLControler

            Dim Filename As String = Application.StartupPath & "\logs\" & Date.Now.ToString("MMddyymmss") & "FileMonitoring.xml"
            xmlsaver.CreateXML(Filename, _ItemsCollected)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If _RunDate.Day < Date.Now.Day Then
            SaveXML()
            _RunDate = Date.Now
            _ItemsCollected = Nothing
            _ItemsCollected = New FileMonitoringCore.com.lib.objects.FileObjCollection
        End If
    End Sub

    Private Sub MainWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _RunDate = Date.Now
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim form1 As New Form1
        form1.Show()


    End Sub
End Class
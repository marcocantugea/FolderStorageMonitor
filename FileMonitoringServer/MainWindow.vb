Public Class MainWindow

    Private _FolderToWatch As String
    Private _ItemsCollected As New FileMonitoringCore.com.lib.objects.FileObjCollection
    Private _RunDate As Date
    Private _Blacklist As New FileMonitoringCore.com.lib.objects.FileObjCollection
    Private _DeletedItems As New FileMonitoringCore.com.lib.objects.FileObjCollection
    Public _SelectedFilesFromblacklist As New FileMonitoringCore.com.lib.objects.FileObjCollection
    Private _ImageList As New List(Of FileMonitoringCore.com.lib.objects.ImageObj)

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
            System.Threading.Thread.Sleep(500)
            Dim filecreated As New IO.FileInfo(e.FullPath)
            Dim addedtoblacklist As Boolean = False
            If Not filecreated.Extension.Equals("") Then
                Dim fileobj As New FileMonitoringCore.com.lib.objects.FileObj(filecreated)
                _ItemsCollected.Add(fileobj)

                'if the file is JPEG (photo) and is biger that 2 mb
                Dim applyresizephotos As Boolean = False
                applyresizephotos = Boolean.Parse(Configuration.ConfigurationSettings.AppSettings("ResizePhotos"))
                If applyresizephotos Then
                    If fileobj.Fileinformation.Extension.ToUpper = ".JPG" And fileobj.SizeFileinMB >= 2 Then
                        'Dim apptoresize As String = Configuration.ConfigurationSettings.AppSettings("AppToResizePhotos")
                        'Dim arguments As String = "-c resizephoto """ & fileobj.FullPathFile & """ "
                        'RunCMDCom(apptoresize, arguments, True)
                        Dim radio As Double = 0.5
                        Try
                            radio = Double.Parse(Configuration.ConfigurationSettings.AppSettings("PercentRationImageToCompress")) / 100
                        Catch ex As Exception
                            Throw

                        End Try

                        Dim NewImage As New FileMonitoringCore.com.lib.objects.ImageObj(filecreated)
                        NewImage.PercentRationToCompress = radio
                        NewImage.StartExpirationTime()
                        _ImageList.Add(NewImage)

                    End If
                End If
                Try
                    addedtoblacklist = ApplyBlackList(fileobj)
                Catch ex As Exception
                    Throw
                End Try

                If addedtoblacklist Then
                    If fileobj.SizeFileinMB <= 0.9 Then
                        RichTextBox1.AppendText(fileobj.FullPathFile.ToString & " Size:" & fileobj.SizeFileinKB.ToString & " KB")
                        RichTextBox1.SelectionColor = Color.Red
                        RichTextBox1.SelectedText = " --> Added to blacklist " & Date.Now.ToString("dd-MM-yyyy hh:mm:ss") & vbNewLine
                    Else

                        If fileobj.SizeFileinMB >= 50 Then
                            RichTextBox1.AppendText(fileobj.FullPathFile.ToString)
                            RichTextBox1.SelectionColor = Color.Red
                            RichTextBox1.SelectedText = " Size:" & fileobj.SizeFileinMB.ToString & " MB --> Added to blacklist " & Date.Now.ToString("dd-MM-yyyy hh:mm:ss") & vbNewLine
                        Else
                            RichTextBox1.AppendText(fileobj.FullPathFile.ToString & " Size:" & fileobj.SizeFileinMB.ToString & " MB ")
                            RichTextBox1.SelectionColor = Color.Red
                            RichTextBox1.SelectedText = " --> Added to blacklist " & Date.Now.ToString("dd-MM-yyyy hh:mm:ss") & vbNewLine
                        End If
                    End If

                Else
                    If fileobj.SizeFileinMB <= 0.9 Then
                        RichTextBox1.AppendText(fileobj.FullPathFile.ToString & " Size:" & fileobj.SizeFileinKB.ToString & " KB " & Date.Now.ToString("dd-MM-yyyy hh:mm:ss") & vbCrLf)
                    Else
                        If fileobj.SizeFileinMB >= 50 Then
                            RichTextBox1.AppendText(fileobj.FullPathFile.ToString)
                            RichTextBox1.SelectionColor = Color.Red
                            RichTextBox1.SelectedText = " Size:" & fileobj.SizeFileinMB.ToString & " MB " & Date.Now.ToString("dd-MM-yyyy hh:mm:ss") & vbCrLf
                        Else
                            RichTextBox1.AppendText(fileobj.FullPathFile.ToString & " Size:" & fileobj.SizeFileinMB.ToString & " MB " & Date.Now.ToString("dd-MM-yyyy hh:mm:ss") & vbCrLf)
                        End If

                    End If

                End If

                lbl_TotalSize.Text = GetTotalInMemory()

            End If
        Catch ex As Exception

            Throw
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

    Public Function GetTotalInMemory() As String
        Dim message As String
        Dim totalkb As Long = _ItemsCollected.TotalinBytesOfFiles / 1024
        Dim totalmb As Long = totalkb / 1024
        Dim totalgb As Long = totalmb / 1024

        If totalkb < 1024 Then
            message = FormatNumber(totalkb, 3) & " KB"
        End If

        If totalkb > 1024 And totalmb < 1024 Then
            message = FormatNumber(totalmb, 3) & " MB"
        End If

        If totalkb > 1024 And totalmb > 1024 Then
            message = FormatNumber(totalgb, 3) & " GB"
        End If
        Return message
    End Function

    Public Function GetTotalDeletedInMemory() As String
        Dim message As String
        Dim totalkb As Long = _DeletedItems.TotalinBytesOfFiles / 1024
        Dim totalmb As Long = totalkb / 1024
        Dim totalgb As Long = totalmb / 1024

        If totalkb < 1024 Then
            message = FormatNumber(totalkb, 3) & " KB"
        End If

        If totalkb > 1024 And totalmb < 1024 Then
            message = FormatNumber(totalmb, 3) & " MB"
        End If

        If totalkb > 1024 And totalmb > 1024 Then
            message = FormatNumber(totalgb, 3) & " GB"
        End If
        Return message
    End Function

    Public Sub SaveXML()
        Try
            Dim xmlsaver As New FileMonitoringCore.com.lib.file.XMLControler

            Dim Filename As String = Application.StartupPath & "\logs\" & Date.Now.ToString("MMddyymmss") & "FileMonitoring.xml"
            xmlsaver.CreateXML(Filename, _ItemsCollected)
        Catch ex As Exception
            Throw

        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If _RunDate.Day < Date.Now.Day Then
            SaveXML()
            SendReport()
            _RunDate = Date.Now
            _ItemsCollected = Nothing
            _ItemsCollected = New FileMonitoringCore.com.lib.objects.FileObjCollection
            'reset deleted items by day
            _DeletedItems.Clear()
            _DeletedItems = Nothing
            _DeletedItems = New FileMonitoringCore.com.lib.objects.FileObjCollection
            'Reset label of totals by day
            lbl_TotalSize.Text = 0
            lbl_TotalRemoved.Text = 0
            CreateLog(_RunDate)
            RichTextBox1.Text = ""
        End If
    End Sub

    Private Sub MainWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _RunDate = Date.Now
        timer_blacklist.Start()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim form1 As New Form1
        form1.Show()

    End Sub

    Public Sub SendReport()
        Dim EmailSender As New FileMonitoringCore.com.lib.notifications.EmailSender

        'Add Headers to the message
        EmailSender.AddTextToMessage("Report of new files on server.")
        EmailSender.AddTextToMessage(" Total Copied: " & _ItemsCollected.DisplayTotal & vbNewLine)

        'Search files between 3MB and 10MB
        Dim countfiles As Integer = 0
        Dim itemsselected As New Collection
        For Each file As FileMonitoringCore.com.lib.objects.FileObj In _ItemsCollected.Items
            If file.SizeFileinMB >= 3 And file.SizeFileinMB <= 10 Then
                itemsselected.Add("File > " & file.FullPathFile & " > Size: " & file.SizeFileinMB & " MB")
                countfiles = countfiles + 1
            End If
        Next

        If countfiles > 0 Then
            EmailSender.AddTextToMessage("Files between 3MB and 10MB ")
            For Each item As String In itemsselected
                EmailSender.AddTextToMessage(item)
            Next
        End If


        'Search files between 10MB and 100MB
        EmailSender.AddTextToMessage(vbNewLine)
        countfiles = 0
        itemsselected = New Collection
        For Each file As FileMonitoringCore.com.lib.objects.FileObj In _ItemsCollected.Items
            If file.SizeFileinMB >= 10 And file.SizeFileinMB <= 100 Then
                itemsselected.Add("File > " & file.FullPathFile & " > Size: " & file.SizeFileinMB & " MB")
                countfiles = countfiles + 1
            End If
        Next

        If countfiles > 0 Then
            EmailSender.AddTextToMessage("Files between 10MB and 100MB ")
            For Each item As String In itemsselected
                EmailSender.AddTextToMessage(item)
            Next
        End If

        'Search files more than 100MB
        EmailSender.AddTextToMessage(vbNewLine)
        countfiles = 0
        itemsselected = New Collection
        For Each file As FileMonitoringCore.com.lib.objects.FileObj In _ItemsCollected.Items
            If file.SizeFileinMB > 100 Then
                itemsselected.Add("File > " & file.FullPathFile & " > Size: " & file.SizeFileinMB & " MB")
                countfiles = countfiles + 1
            End If
        Next

        If countfiles > 0 Then
            EmailSender.AddTextToMessage("Files more than 100MB " & vbNewLine)
            For Each item As String In itemsselected
                EmailSender.AddTextToMessage(item)
            Next
        End If

        EmailSender.AddTextToMessage(vbNewLine)
        EmailSender.AddTextToMessage(vbNewLine)

        Try
            EmailSender.SendMail()
        Catch ex As Exception
            MsgBox("Error Trying send email = Error: " & ex.Message.ToString, MsgBoxStyle.Critical, "Error sending email")
        End Try
    End Sub

    Private Sub btn_SendReport_Click(sender As Object, e As EventArgs) Handles btn_SendReport.Click
        SendReport()
    End Sub

    Public Function ApplyBlackList(file As FileMonitoringCore.com.lib.objects.FileObj) As Boolean
        Dim addedtoblacklist As Boolean = False
        'Bring the Blacklist extention files
        Try
            Dim Blacklist_extentionFiles As String() = Configuration.ConfigurationSettings.AppSettings("BlacklistExtension").Split("|")
            For Each ext As String In Blacklist_extentionFiles
                If file.Fileinformation.Extension.ToUpper = ext.ToUpper Then
                    file.StartExpirationTime()
                    _Blacklist.Add(file)
                    addedtoblacklist = True
                End If
            Next

        Catch ex As Exception
            Throw

        End Try

        'Bring the black list fo file names
        Try
            Dim Blacklist_filenames As String() = Configuration.ConfigurationSettings.AppSettings("BlacklistFileName").Split("|")
            For Each filename As String In Blacklist_filenames
                If file.FileName.ToUpper = filename.ToUpper Then
                    file.StartExpirationTime()
                    _Blacklist.Add(file)
                    addedtoblacklist = True
                End If
            Next
        Catch ex As Exception
            Throw

        End Try

        Return addedtoblacklist
    End Function

    Private Sub timer_blacklist_Tick(sender As Object, e As EventArgs) Handles timer_blacklist.Tick

        Dim filesdeleted As New Collection
        Dim files_pending As New Collection

        'Check witch items are expire
        For Each file As FileMonitoringCore.com.lib.objects.FileObj In _Blacklist.Items
            If file.timeout Then
                'Console.WriteLine("item > " & file.FullPathFile & " is expire")
                Dim blacklistbackup As Boolean = False
                Try
                    blacklistbackup = Boolean.Parse(Configuration.ConfigurationSettings.AppSettings("BlacklistBackup"))
                Catch ex As Exception
                    Throw

                End Try

                If blacklistbackup Then
                    'Create a copy of the file before delete
                    Dim backupfolder As String = Configuration.ConfigurationSettings.AppSettings("BlacklistFolderBackup")
                    If Not IO.File.Exists(backupfolder & "\" & file.FileName) And IO.File.Exists(file.FullPathFile) Then
                        System.IO.File.Copy(file.FullPathFile, backupfolder & "\" & file.FileName)
                    End If

                End If

                Try
                    'Delete the file from the source
                    _DeletedItems.Add(file)
                    System.IO.File.Delete(file.FullPathFile)
                    RichTextBox1.SelectionColor = Color.Red
                    RichTextBox1.SelectedText = "**** File removed from system >> " & file.FullPathFile & " " & Date.Now.ToString("dd-MM-yyyy hh:mm:ss") & vbNewLine
                    filesdeleted.Add(file.FullPathFile)
                Catch ex As Exception
                    Throw

                End Try
            Else
                files_pending.Add(file)
            End If
        Next

        'clean blacklis
        _Blacklist.Clear()

        For Each filepending As FileMonitoringCore.com.lib.objects.FileObj In files_pending
            _Blacklist.Add(filepending)
        Next

        lbl_TotalRemoved.Text = GetTotalDeletedInMemory()

        CleanItemsExpiredFromImageList()
    End Sub

    Private Sub btn_viewblacklist_Click(sender As Object, e As EventArgs) Handles btn_viewblacklist.Click
        _SelectedFilesFromblacklist.Items.Clear()
        Dim frm_blacklistcontrol As New BlackListControl
        frm_blacklistcontrol.Show()
        frm_blacklistcontrol._Blacklist = _Blacklist
    End Sub

    Public Sub RemoveFromBlackList()

        If _SelectedFilesFromblacklist.Items.Count > 0 Then
            Dim bk_blacklist As New FileMonitoringCore.com.lib.objects.FileObjCollection
            For Each fileobj As FileMonitoringCore.com.lib.objects.FileObj In _Blacklist.Items
                bk_blacklist.Items.Add(fileobj)
            Next
            _Blacklist.Clear()
            For Each file As FileMonitoringCore.com.lib.objects.FileObj In bk_blacklist.Items

                If Not _SelectedFilesFromblacklist.ExistFileInItems(file) Then
                    _Blacklist.Add(file)
                End If

            Next

        End If
    End Sub

    Public Sub CleanItemsExpiredFromImageList()
        'for debug
        'Dim newform As New Form()
        'Dim lbl_displaytime As New Label
        'newform.Controls.Add(lbl_displaytime)
        'newform.Width = 400
        'newform.Height = 400
        'lbl_displaytime.Width = newform.Width
        'lbl_displaytime.Height = newform.Height
        'Dim sb As New System.Text.StringBuilder
        If _ImageList.Count > 0 Then
            Dim bk_imaglist As New List(Of FileMonitoringCore.com.lib.objects.ImageObj)
            bk_imaglist.AddRange(_ImageList)
            If bk_imaglist.Count > 0 Then
                _ImageList.Clear()
                For Each Image As FileMonitoringCore.com.lib.objects.ImageObj In bk_imaglist
                    'sb.Append("Image : " & Image.FileName & " Time to Expire:" & Image.Time.Interval.ToString & Environment.NewLine)
                    If Not Image.timeout Then
                        _ImageList.Add(Image)
                    End If
                Next
            Else

                'sb.Append("no items on bk_imaglist")
            End If
        End If
        'lbl_displaytime.Text = sb.ToString
        'newform.Show()

    End Sub

    Public Sub CreateLog(RunDay As Date)
        Try
            Dim filepath As String
            Dim logfolder As String = Configuration.ConfigurationSettings.AppSettings("LogFiles")
            Dim filename As String = "Log" & RunDay.Day.ToString & RunDay.Month & RunDay.Year & RunDay.Hour & RunDay.Minute & RunDay.Second & ".txt"
            filepath = logfolder & "\" & filename
            Dim fileobj As New FileMonitoringCore.com.lib.objects.FileObj(New IO.FileInfo(filepath))
            Dim TextFileWrite As New FileMonitoringCore.com.lib.file.TextFileWriter(fileobj)

            For Each textline As String In RichTextBox1.Lines
                TextFileWrite.AddText(textline & vbCrLf)
            Next

            TextFileWrite.CreateFile()

        Catch ex As Exception
            MsgBox("Error to create log file. Error/> " & ex.Message.ToString)
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btn_SaveActualLog.Click
        CreateLog(Date.Now)
        MsgBox("Log Saved in " & Configuration.ConfigurationSettings.AppSettings("LogFiles"), MsgBoxStyle.Information, "File Monitoring System -- Save Log")
    End Sub

    Public Sub RunCMDCom(command As String, arguments As String, permanent As Boolean)
        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        'pi.Arguments = " " + If(permanent = True, "/K", "/C") + " " + command + " " + arguments
        'pi.FileName = "cmd.exe"
        pi.Arguments = arguments
        pi.FileName = command
        p.StartInfo = pi
        p.Start()
    End Sub

End Class
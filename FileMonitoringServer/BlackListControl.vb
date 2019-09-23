Public Class BlackListControl

    Public _Blacklist As FileMonitoringCore.com.lib.objects.FileObjCollection


    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        MainWindow.RemoveFromBlackList()
        Me.Dispose()
    End Sub

    Private Sub BlackListControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BlackListControl_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If _Blacklist.Items.Count > 0 Then
            For Each file As FileMonitoringCore.com.lib.objects.FileObj In _Blacklist.Items
                listbox_blacklistselection.Items.Add(file.FullPathFile.ToString)
            Next

        End If
    End Sub

    Private Sub btn_removeitem_Click(sender As Object, e As EventArgs) Handles btn_removeitem.Click

        Dim fileselected As New IO.FileInfo(listbox_blacklistselection.SelectedItem)
        Dim fileobj As New FileMonitoringCore.com.lib.objects.FileObj(fileselected)
        Console.WriteLine(fileobj.FileName)
        MainWindow._SelectedFilesFromblacklist.Add(fileobj)
        listbox_blacklistselection.Items.Remove(listbox_blacklistselection.SelectedItem)

    End Sub
End Class
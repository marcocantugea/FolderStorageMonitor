Imports System.Configuration
Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim log As String = "C:\Documents and Settings\Administrator\Desktop\FileMonitoring\File Monitoring\FileMonitoringServer\bin\Debug\logs\0716165302FileMonitoring.xml"
        'Dim xmlread As New FileMonitoringCore.com.lib.file.XMLControler
        'Dim files As New FileMonitoringCore.com.lib.objects.FileObjCollection
        'xmlread.ReadXML(log, files)
        'Label1.Text = files.DateLoaded.ToString("MM/dd/yyyy") & " " & files.DisplayTotal
        Try


            Dim logfolder As String = ConfigurationSettings.AppSettings("LogFiles")
            Dim _ADOfilesObj As New FileMonitoringCore.com.lib.ADO.ADOFileObjs
            _ADOfilesObj.LoadXMLFiles(logfolder)
            Dim bigfiles As New FileMonitoringCore.com.lib.objects.FileObjCollection
            _ADOfilesObj.SearchHeavyFilesInDataSource(bigfiles, Integer.Parse(TextBox1.Text))

            DataGridView1.DataSource = bigfiles.Items
            DataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        DataGridView1.Width = Me.Width - 30
        DataGridView1.Height = Me.Height - 90
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class

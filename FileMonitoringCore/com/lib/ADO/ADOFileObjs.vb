Imports FileMonitoringCore.com.lib.objects

Namespace com.lib.ADO
    Public Class ADOFileObjs

        Private _XMLDataBase As New Collection

        Public Sub AddSource(ByVal FilesColection As FileObjCollection)
            _XMLDataBase.Add(FilesColection)
        End Sub

        Public Sub SearchHeavyFilesInDataSource(ByVal result As FileObjCollection, ByVal sizeoffile As Integer)
            For Each item As FileObjCollection In _XMLDataBase
                SearchHeavyFiles(item, result, sizeoffile)
            Next
        End Sub

        Public Sub SearchHeavyFiles(ByVal _filescollected As FileObjCollection, ByVal result As FileObjCollection, ByVal sizeoffile As Integer)
            If Not IsNothing(_filescollected) Then
                For Each item As FileObj In _filescollected.Items
                    If item.SizeFileinMB >= sizeoffile Then
                        Dim newitem As New FileObj(New IO.FileInfo(item.FullPathFile))
                        result.Add(newitem)
                    End If
                Next
            End If
        End Sub

        Public Sub LoadXMLData(ByVal xmlfile As String)
            Dim xmlread As New FileMonitoringCore.com.lib.file.XMLControler
            Dim files As New FileMonitoringCore.com.lib.objects.FileObjCollection
            xmlread.ReadXML(xmlfile, files)
            _XMLDataBase.Add(files)
        End Sub

        Public Sub LoadXMLFiles(ByVal directory As String)
            Dim files() As String = IO.Directory.GetFiles(directory)
            For Each item As String In files
                Dim file As New IO.FileInfo(item)
                If file.Extension.Equals(".xml") Then
                    LoadXMLData(file.FullName)
                End If
            Next
        End Sub

    End Class
End Namespace
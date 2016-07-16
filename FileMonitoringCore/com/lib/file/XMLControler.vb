Imports FileMonitoringCore.com.lib.objects
Imports System.Xml
Imports System.IO

Namespace com.lib.file
    Public Class XMLControler

        Private _filenamea As String
        Private _FileObjs As FileObjCollection

        Public Property FileObjs() As FileObjCollection
            Get
                Return _FileObjs
            End Get
            Set(ByVal value As FileObjCollection)
                _FileObjs = value
            End Set
        End Property

        Public WriteOnly Property Filename() As String
            Set(ByVal value As String)
                _filenamea = value
            End Set
        End Property

        Public Sub CreateXML()
            Dim fil As New System.IO.FileInfo(_filenamea)
            Try
                If Not System.IO.File.Exists(_filenamea) Then
                    CreateXML(_filenamea, _FileObjs)

                    Console.WriteLine("File Created : " & fil.Name)
                End If


            Catch ex As Exception
                Console.WriteLine("Warning : File " & fil.Name & " message:" & ex.Message)
            End Try

        End Sub

        Public Sub CreateXML(ByVal filename As String, ByVal filesobj As FileObjCollection)
            Dim writer As New Xml.XmlTextWriter(filename, System.Text.Encoding.UTF8)
            writer.WriteStartDocument(True)
            writer.Formatting = Xml.Formatting.Indented
            writer.Indentation = 2
            writer.WriteStartElement("FileMonitoring")
            writer.WriteString(Date.Now.ToString("MM/dd/yyyy"))

            writer.WriteStartElement("TotalNewFiles")
            writer.WriteString(filesobj.DisplayTotal)
            writer.WriteEndElement()

            writer.WriteStartElement("FilesCollected")
            For Each item As FileObj In filesobj.Items
                Try
                    writer.WriteStartElement("Fileitem")

                    writer.WriteStartElement("FileFullPath")
                    Try
                        writer.WriteString(item.FullPathFile)
                    Catch ex As Exception

                    End Try

                    writer.WriteEndElement()

                    writer.WriteStartElement("filename")
                    Try
                        writer.WriteString(item.FileName)
                    Catch ex As Exception

                    End Try

                    writer.WriteEndElement()

                    writer.WriteStartElement("filepath")
                    Try
                        writer.WriteString(item.FilePath)
                    Catch ex As Exception

                    End Try

                    writer.WriteEndElement()

                    writer.WriteStartElement("SizeFileinBytes")
                    Try
                        writer.WriteString(item.SizeFileinBytes)
                    Catch ex As Exception

                    End Try

                    writer.WriteEndElement()

                    writer.WriteStartElement("SizeFileinKB")
                    Try
                        writer.WriteString(FormatNumber(item.SizeFileinKB, 2))
                    Catch ex As Exception

                    End Try

                    writer.WriteEndElement()

                    writer.WriteStartElement("SizeFileinMB")
                    Try
                        writer.WriteString(FormatNumber(item.SizeFileinMB, 2))
                    Catch ex As Exception

                    End Try

                    writer.WriteEndElement()

                    writer.WriteStartElement("SizeFileInGB")
                    Try
                        writer.WriteString(FormatNumber(item.SizeFileInGB, 2))
                    Catch ex As Exception

                    End Try

                    writer.WriteEndElement()

                    writer.WriteStartElement("LastWriteTime")
                    Try
                        writer.WriteString(item.LastWriteTime)
                    Catch ex As Exception

                    End Try

                    writer.WriteEndElement()

                    writer.WriteStartElement("CreationTime")
                    Try
                        writer.WriteString(item.CreationTime)
                    Catch ex As Exception

                    End Try

                    writer.WriteEndElement()

                    writer.WriteEndElement()
                Catch ex As Exception

                End Try
                

            Next
            writer.WriteEndElement()
            writer.WriteEndElement()
            writer.WriteEndDocument()

            writer.Close()

        End Sub


        Public Sub ReadXML(ByVal filename As String, ByVal Fileobjs As FileObjCollection)
            Dim xmldoc As New XmlDataDocument
            Dim xmlnode As XmlNodeList
            Dim fs As New FileStream(filename, FileMode.Open, FileAccess.Read)
            xmldoc.Load(fs)
            xmlnode = xmldoc.GetElementsByTagName("FileMonitoring")
            Dim key As String
            Dim fileobj As FileObj
            For Each item As XmlNode In xmlnode
                For Each itm As XmlNode In item.ChildNodes
                    Fileobjs.DateLoaded = Date.Parse(item.InnerText.Substring(0, 10))
                    'If itm.Name.Equals("SerialFilekey") Then
                    '    key = itm.InnerText.Trim
                    'End If
                    'If itm.Name.Equals("key") Then
                    '    Console.WriteLine("Key: " & itm.InnerText.Trim)
                    'End If
                    If itm.Name.Equals("FilesCollected") Then
                        'Console.WriteLine("value: ")
                        For Each it As XmlNode In itm.ChildNodes
                            For Each i As XmlNode In it.ChildNodes
                                If i.Name.Equals("FileFullPath") Then
                                    Dim filesel As New IO.FileInfo(i.InnerText.Trim)
                                    fileobj = New FileObj(filesel)
                                    Fileobjs.Add(fileobj)
                                End If
                            Next
                        Next
                    End If

                Next
            Next
            fs.Close()


        End Sub




    End Class
End Namespace

Namespace com.lib.objects
    Public Class FileObj

        Private _FileInformation As IO.FileInfo
        Private _Serial As Integer


        Public Property Serial() As Integer
            Get
                Return _Serial
            End Get
            Set(ByVal value As Integer)
                _Serial = value
            End Set
        End Property

        Public Sub New(ByVal fileinfo As IO.FileInfo)
            _FileInformation = fileinfo
        End Sub

        Public ReadOnly Property FileName() As String
            Get
                Return _FileInformation.Name
            End Get
        End Property

        Public ReadOnly Property Fileinformation() As IO.FileInfo
            Get
                Return _FileInformation
            End Get
        End Property

        Public ReadOnly Property FilePath() As String
            Get
                Return _FileInformation.DirectoryName
            End Get
        End Property

        Public ReadOnly Property SizeFileinBytes() As Long
            Get
                Return _FileInformation.Length
            End Get
        End Property

        Public ReadOnly Property SizeFileinKB() As Long
            Get
                Dim KB As Long
                Try
                    KB = _FileInformation.Length / 1024
                Catch ex As Exception
                    KB = 0
                End Try

                Return KB
            End Get
        End Property

        Public ReadOnly Property SizeFileinMB() As Long
            Get
                Dim MB As Long
                Try
                    MB = SizeFileinKB / 1024
                Catch ex As Exception
                    MB = 0
                End Try

                Return MB
            End Get
        End Property

        Public ReadOnly Property SizeFileInGB() As Long
            Get
                Dim GB As Long
                Try
                    GB = SizeFileinMB / 1024
                Catch ex As Exception
                    GB = 0
                End Try
                Return GB
            End Get
        End Property

        Public ReadOnly Property LastWriteTime() As Date
            Get
                Return _FileInformation.LastWriteTime
            End Get
        End Property

        Public ReadOnly Property CreationTime() As Date
            Get
                Return _FileInformation.CreationTime
            End Get
        End Property

        Public ReadOnly Property FullPathFile() As String
            Get
                Return _FileInformation.FullName 
            End Get
        End Property

    End Class
End Namespace
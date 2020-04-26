Imports System.Timers

Namespace com.lib.objects
    Public Class FileObj

        Protected _FileInformation As IO.FileInfo
        Protected _Serial As Integer
        Protected WithEvents _Timer As Timer
        Protected _timeout As Boolean = True

        Protected Overridable Sub _Timer_enlapsed(source As Object, e As ElapsedEventArgs)
            _timeout = True
            _Timer.Enabled = False
        End Sub

        Public Function GetExpirationElapsedTime() As String
            Return _Timer.Interval.ToString()
        End Function

        Public Overridable Sub StartExpirationTime()
            'Get the configuration of the expiration time from the config file
            Dim expirationtimeminutes As Double
            Dim timerExpireMiliSeconds As Double
            Try
                expirationtimeminutes = Double.Parse(Configuration.ConfigurationSettings.AppSettings("ExpireFileTimeInMinutes"))
            Catch ex As Exception
                'If the value does not exist it will set it as default value
                ' it will set it as 1440 minutes = 1 day
                expirationtimeminutes = 1440
            End Try

            Try
                timerExpireMiliSeconds = expirationtimeminutes * 60000
            Catch ex As Exception
                timerExpireMiliSeconds = 86400000
            End Try

            SetTime(timerExpireMiliSeconds)
            StartTime()

        End Sub

        Public Sub StartTime()
            _Timer.Start()
            If _timeout Then
                _timeout = False
            End If
        End Sub

        Public Sub SetTime(timevalue As Double)
            _Timer = New Timers.Timer
            _Timer.Interval = timevalue
            _Timer.AutoReset = False
            _Timer.Enabled = True
            AddHandler _Timer.Elapsed, New ElapsedEventHandler(AddressOf _Timer_enlapsed)
        End Sub

        Public Property Time As Timers.Timer
            Get
                Return _Timer
            End Get
            Set(value As Timers.Timer)
                _Timer = value
            End Set
        End Property

        Public Property timeout As Boolean
            Get
                Return _timeout
            End Get
            Set(value As Boolean)
                _timeout = value
            End Set
        End Property

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
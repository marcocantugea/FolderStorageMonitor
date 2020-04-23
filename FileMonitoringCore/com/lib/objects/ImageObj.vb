Imports System.IO
Imports mcgImageTools.com.image

Namespace com.lib.objects
    Public NotInheritable Class ImageObj
        Inherits FileObj

        Private _LimitSizeOfFileToCompress As Long = 1024
        Private _ResizedImagedCreated As FileInfo
        Private _PercentRatio As Double = 0.5

        Sub New(ByVal fileinfo As IO.FileInfo)
            MyBase.New(fileinfo)

        End Sub

        Protected Overrides Sub _Timer_enlapsed(source As Object, e As Timers.ElapsedEventArgs) Handles _Timer.Elapsed
            If SizeFileinKB > _LimitSizeOfFileToCompress Then
                ResizeImage()
            End If
            _timeout = True
            _Timer.Enabled = False
            'MyBase._Timer_enlapsed(source, e)
        End Sub

        Public Sub ResizeImage()
            If Not System.IO.File.Exists(_FileInformation.FullName) Then
                Throw New FileNotFoundException("ImageObj:_Timer_enlapsed: File do not exist")
            End If
            Dim ImageTool As New ImageTool(_FileInformation, _FileInformation.Name)
            _FileInformation = ImageTool.ResizeImage(_PercentRatio)
        End Sub

        Public Property LimitSizeOfFileToCompress As Long
            Get
                Return _LimitSizeOfFileToCompress
            End Get
            Set(value As Long)
                _LimitSizeOfFileToCompress = value
            End Set
        End Property

        ReadOnly Property ImageCreated As FileInfo
            Get
                Return _FileInformation
            End Get
        End Property

        Public Property PercentRationToCompress As Double
            Get
                Return _PercentRatio
            End Get
            Set(value As Double)
                _PercentRatio = value
            End Set
        End Property


    End Class
End Namespace

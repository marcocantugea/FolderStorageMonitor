Imports System.IO
Imports mcgImageTools.com.image
Imports FileMonitoringCore.com.lib.objects

Namespace com.lib.managers
    Public NotInheritable Class ImageManager

        Private _ListOfImages As List(Of ImageObj)

        Sub New()
            _ListOfImages = New List(Of ImageObj)
        End Sub

        Public Sub AddImage(Image As ImageObj)
            If IsNothing(Image) Then
                Throw New NullReferenceException("ImageManager:AddImage: Image object is null")
            End If
            _ListOfImages.Add(Image)
        End Sub

    End Class
End Namespace

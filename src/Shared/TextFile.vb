Imports System.IO
Imports System.Text

''' <summary>
''' Writes text files as UTF-8 with a byte-order mark, which TextFieldParser reads correctly on any PC.
''' Replaces FileOpen/Print/FileClose, which always wrote in the PC's legacy code page.
''' </summary>
Public Module TextFile
    Private writer As StreamWriter

    Public Sub Open(fileName As String)
        Close()
        writer = New StreamWriter(fileName, False, New UTF8Encoding(True))
    End Sub

    Public Sub Write(text As String)
        writer.Write(text)
    End Sub

    Public Sub Close()
        If writer IsNot Nothing Then
            writer.Dispose()
            writer = Nothing
        End If
    End Sub
End Module

Imports System.Drawing.Text
Imports System.IO
Imports System.Runtime.InteropServices

''' <summary>
''' Fonts compiled into the program from src\Shared\Fonts, so they need no installation. Windows does not
''' know them by name, so fonts that the designer or the language files ask for by name are swapped for them.
''' </summary>
Public Module EmbeddedFonts
    Private collection As PrivateFontCollection

    'A font by family name, taken from the embedded fonts when it is one of them
    Public Function Create(familyName As String, emSize As Single, Optional style As FontStyle = FontStyle.Regular) As Font
        Dim family = Find(familyName)
        Return If(family Is Nothing, New Font(familyName, emSize, style), New Font(family, emSize, style))
    End Function

    'Gives a form's controls the embedded fonts their designer code asked for by name
    Public Sub Apply(control As Control)
        Dim font = control.Font
        Dim family = Find(font.OriginalFontName)
        If family IsNot Nothing AndAlso font.FontFamily.Name <> family.Name Then
            control.Font = New Font(family, font.Size, font.Style, font.Unit, font.GdiCharSet, font.GdiVerticalFont)
        End If
        For Each child As Control In control.Controls
            Apply(child)
        Next
    End Sub

    Private Function Find(familyName As String) As FontFamily
        If familyName Is Nothing Then Return Nothing
        Load()
        Return collection.Families.FirstOrDefault(Function(f) String.Equals(f.Name, familyName, StringComparison.OrdinalIgnoreCase))
    End Function

    Private Sub Load()
        If collection IsNot Nothing Then Return
        collection = New PrivateFontCollection()
        Dim assembly = GetType(EmbeddedFonts).Assembly
        For Each name In assembly.GetManifestResourceNames().Where(Function(n) n.StartsWith("Fonts."))
            Dim data As Byte()
            Using stream = assembly.GetManifestResourceStream(name), buffer As New MemoryStream()
                stream.CopyTo(buffer)
                data = buffer.ToArray()
            End Using
            'The font data must stay in memory for as long as the program runs
            Dim memory = Marshal.AllocCoTaskMem(data.Length)
            Marshal.Copy(data, 0, memory, data.Length)
            collection.AddMemoryFont(memory, data.Length) 'For text drawn by .NET
            Dim count As UInteger
            AddFontMemResourceEx(memory, CUInt(data.Length), IntPtr.Zero, count) 'For text drawn by the controls through Windows
        Next
    End Sub

    Private Declare Function AddFontMemResourceEx Lib "gdi32.dll" (font As IntPtr, size As UInteger, reserved As IntPtr, ByRef count As UInteger) As IntPtr
End Module

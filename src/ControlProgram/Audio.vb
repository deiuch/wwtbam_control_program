Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Threading

''' <summary>Background music channel.</summary>
Public Module BackgroundMusic
    Private Const FadeOutMilliseconds As Integer = 2000

    Public Sub PlayLoop(fileName As String)
        AudioOutput.Music = Voice.Load(fileName, True)
    End Sub

    Public Sub PlayOnce(fileName As String)
        AudioOutput.Music = Voice.Load(fileName, False)
    End Sub

    Public Sub [Stop]()
        AudioOutput.Music = Nothing
    End Sub

    Public Sub FadeOut()
        AudioOutput.FadeOutMusic(FadeOutMilliseconds)
    End Sub
End Module

''' <summary>Sound cue channel: one cue at a time, a new cue replaces the previous one.</summary>
Public Module SoundCues
    Public Sub Play(fileName As String)
        AudioOutput.Cue = Voice.Load(fileName, False)
    End Sub

    Public Sub [Stop]()
        AudioOutput.Cue = Nothing
    End Sub
End Module

''' <summary>
''' The single waveOut stream that the game's audio plays through. It is opened once and kept running,
''' and a feeder thread mixes what is playing into short buffers, so starting a sound never opens a device.
''' </summary>
Friend Module AudioOutput
    Friend Const Channels As Integer = 2
    Private Const BufferCount As Integer = 4
    Private Const BufferMilliseconds As Integer = 25 'Keeps the delay before a sound starts under 0.1 s

    Private ReadOnly gate As New Object
    Private ReadOnly bufferDone As New AutoResetEvent(False)
    Private mixed As Integer()
    Private musicVoice As Voice
    Private cueVoice As Voice
    Private device As IntPtr
    Private feeder As Thread

    'Fixed by the first Open call; files at any other rate are resampled to it when loaded
    Friend ReadOnly Property SampleRate As Integer

    Friend WriteOnly Property Music As Voice
        Set(value As Voice)
            SyncLock gate
                musicVoice = value
            End SyncLock
        End Set
    End Property

    Friend WriteOnly Property Cue As Voice
        Set(value As Voice)
            SyncLock gate
                cueVoice = value
            End SyncLock
        End Set
    End Property

    Friend Sub FadeOutMusic(milliseconds As Integer)
        SyncLock gate
            If musicVoice IsNot Nothing Then musicVoice.FadeOut(milliseconds)
        End SyncLock
    End Sub

    'Opens the output at the sample rate most of the folder's WAV files use, so they play without
    'resampling. Called at startup so that the first sound is not delayed.
    Friend Sub Open(musicFolder As String)
        If Not Directory.Exists(musicFolder) Then Return
        Dim rates = Directory.GetFiles(musicFolder, "*.wav").Select(AddressOf Voice.SampleRateOf).Where(Function(rate) rate > 0)
        If rates.Any() Then Open(rates.GroupBy(Function(rate) rate).OrderByDescending(Function(group) group.Count()).First().Key)
    End Sub

    'Opens the output on first use. Without an audio device it stays closed and the game runs silently.
    Friend Sub Open(rate As Integer)
        If _SampleRate = 0 Then
            _SampleRate = rate
            mixed = New Integer((SampleRate * BufferMilliseconds \ 1000) * Channels - 1) {}
        End If
        If feeder IsNot Nothing Then Return
        Dim format As New WaveFormatEx With {
            .FormatTag = 1, .Channels = Channels, .SamplesPerSec = SampleRate,
            .BlockAlign = Channels * 2, .AvgBytesPerSec = SampleRate * Channels * 2, .BitsPerSample = 16}
        If waveOutOpen(device, WaveMapper, format, bufferDone.SafeWaitHandle.DangerousGetHandle(), IntPtr.Zero, CallbackEvent) <> 0 Then Return
        feeder = New Thread(AddressOf Run) With {.IsBackground = True, .Name = "Audio output", .Priority = ThreadPriority.Highest}
        feeder.Start()
    End Sub

    'Keeps every buffer queued for the life of the program, refilling each one as soon as it has played.
    Private Sub Run()
        Dim samples(mixed.Length - 1) As Short
        Dim headerSize = Marshal.SizeOf(GetType(WaveHdr))
        Dim headers(BufferCount - 1) As IntPtr
        For i = 0 To BufferCount - 1
            headers(i) = Marshal.AllocHGlobal(headerSize)
            Marshal.StructureToPtr(New WaveHdr With {.Data = Marshal.AllocHGlobal(samples.Length * 2), .BufferLength = samples.Length * 2}, headers(i), False)
            waveOutPrepareHeader(device, headers(i), headerSize)
            Submit(headers(i), samples, headerSize)
        Next
        Do
            bufferDone.WaitOne()
            For Each header In headers
                If (Marshal.PtrToStructure(Of WaveHdr)(header).Flags And HeaderDone) <> 0 Then Submit(header, samples, headerSize)
            Next
        Loop
    End Sub

    Private Sub Submit(header As IntPtr, samples As Short(), headerSize As Integer)
        SyncLock gate
            Array.Clear(mixed, 0, mixed.Length)
            If musicVoice IsNot Nothing AndAlso Not musicVoice.MixInto(mixed) Then musicVoice = Nothing
            If cueVoice IsNot Nothing AndAlso Not cueVoice.MixInto(mixed) Then cueVoice = Nothing
        End SyncLock
        For i = 0 To mixed.Length - 1
            samples(i) = CShort(Math.Max(Short.MinValue, Math.Min(Short.MaxValue, mixed(i))))
        Next
        Marshal.Copy(samples, 0, Marshal.PtrToStructure(Of WaveHdr)(header).Data, samples.Length)
        waveOutWrite(device, header, headerSize)
    End Sub

    Private ReadOnly WaveMapper As New UIntPtr(UInteger.MaxValue) 'WAVE_MAPPER: the default output device
    Private Const CallbackEvent As Integer = &H50000
    Private Const HeaderDone As Integer = 1

    <StructLayout(LayoutKind.Sequential, Pack:=2)>
    Private Structure WaveFormatEx
        Public FormatTag As Short
        Public Channels As Short
        Public SamplesPerSec As Integer
        Public AvgBytesPerSec As Integer
        Public BlockAlign As Short
        Public BitsPerSample As Short
        Public ExtraSize As Short
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Private Structure WaveHdr
        Public Data As IntPtr
        Public BufferLength As Integer
        Public BytesRecorded As Integer
        Public User As IntPtr
        Public Flags As Integer
        Public Loops As Integer
        Public NextHeader As IntPtr
        Public Reserved As IntPtr
    End Structure

    Private Declare Function waveOutOpen Lib "winmm.dll" (ByRef device As IntPtr, deviceId As UIntPtr, ByRef format As WaveFormatEx, callback As IntPtr, instance As IntPtr, flags As Integer) As Integer
    Private Declare Function waveOutPrepareHeader Lib "winmm.dll" (device As IntPtr, header As IntPtr, size As Integer) As Integer
    Private Declare Function waveOutWrite Lib "winmm.dll" (device As IntPtr, header As IntPtr, size As Integer) As Integer
End Module

''' <summary>
''' A WAV file held in memory as stereo 16-bit samples at the output rate, with its playback state:
''' position, looping and fade-out. Only touched by AudioOutput, under its lock.
''' </summary>
Friend NotInheritable Class Voice
    Private ReadOnly samples As Short()
    Private ReadOnly looped As Boolean
    Private position As Integer 'Index of the next sample to play
    Private fadeFrames As Integer 'Length of the fade-out; 0 while not fading
    Private fadeFramesLeft As Integer

    Private Sub New(samples As Short(), looped As Boolean)
        Me.samples = samples
        Me.looped = looped
    End Sub

    'Returns Nothing for a missing or unreadable file: like Winamp, a bad file must not stop the show.
    Friend Shared Function Load(fileName As String, looped As Boolean) As Voice
        Try
            Dim rate As Integer
            Dim stereo = ReadWav(fileName, rate)
            AudioOutput.Open(rate) 'Does nothing once open; otherwise this file sets the output rate
            Return New Voice(If(rate = AudioOutput.SampleRate, stereo, Resample(stereo, rate)), looped)
        Catch ex As IOException
        Catch ex As InvalidDataException
        End Try
        Return Nothing
    End Function

    'Returns 0 for a missing or unreadable file.
    Friend Shared Function SampleRateOf(fileName As String) As Integer
        Try
            Using reader As New BinaryReader(File.OpenRead(fileName))
                Dim channels, rate, bits As Integer
                FindData(reader, fileName, channels, rate, bits)
                Return rate
            End Using
        Catch ex As IOException
        Catch ex As InvalidDataException
        End Try
        Return 0
    End Function

    Friend Sub FadeOut(milliseconds As Integer)
        If fadeFrames = 0 Then
            fadeFrames = Math.Max(1, AudioOutput.SampleRate * milliseconds \ 1000)
            fadeFramesLeft = fadeFrames
        End If
    End Sub

    'Adds the next stretch of audio to the mix, wrapping around when looped and applying the fade.
    'Returns False once there is nothing left to play.
    Friend Function MixInto(mix As Integer()) As Boolean
        Dim count = 0
        Do While count < mix.Length
            If position >= samples.Length Then
                If Not looped Then Exit Do
                position = 0
            End If
            Dim gain = 1.0F
            If fadeFrames > 0 Then
                If fadeFramesLeft = 0 Then Exit Do
                gain = CSng(fadeFramesLeft) / fadeFrames
                fadeFramesLeft -= 1
            End If
            For c = 0 To AudioOutput.Channels - 1
                mix(count + c) += CInt(samples(position + c) * gain)
            Next
            position += AudioOutput.Channels
            count += AudioOutput.Channels
        Loop
        Return count > 0
    End Function

    'Reads an uncompressed 8- or 16-bit PCM WAV file, mono or stereo, as interleaved stereo samples.
    Private Shared Function ReadWav(fileName As String, ByRef rate As Integer) As Short()
        Using reader As New BinaryReader(File.OpenRead(fileName))
            Dim channels, bits As Integer
            Dim frames = FindData(reader, fileName, channels, rate, bits) \ ((bits \ 8) * channels)
            If frames = 0 Then Throw New InvalidDataException("No audio data: " & fileName)
            Dim stereo(frames * 2 - 1) As Short
            If bits = 16 AndAlso channels = 2 Then
                'Already in the output format: copy it straight in, a block at a time
                Dim block(65535) As Byte
                Dim offset = 0
                Do While offset < stereo.Length * 2
                    Dim count = reader.Read(block, 0, Math.Min(block.Length, stereo.Length * 2 - offset))
                    If count = 0 Then Throw New EndOfStreamException("Truncated WAV file: " & fileName)
                    Buffer.BlockCopy(block, 0, stereo, offset, count)
                    offset += count
                Loop
            Else
                Dim bytes = reader.ReadBytes(frames * (bits \ 8) * channels)
                For i = 0 To stereo.Length - 1
                    Dim source = If(channels = 2, i, i \ 2) 'Mono plays on both sides
                    stereo(i) = If(bits = 8, CShort((bytes(source) - 128) << 8), BitConverter.ToInt16(bytes, source * 2))
                Next
            End If
            Return stereo
        End Using
    End Function

    'Reads the format and leaves the reader at the start of the audio data. Returns its size in bytes.
    Private Shared Function FindData(reader As BinaryReader, fileName As String, ByRef channels As Integer, ByRef rate As Integer, ByRef bits As Integer) As Integer
        If Text.Encoding.ASCII.GetString(reader.ReadBytes(4)) <> "RIFF" Then Throw New InvalidDataException("Not a WAV file: " & fileName)
        reader.ReadBytes(4)
        If Text.Encoding.ASCII.GetString(reader.ReadBytes(4)) <> "WAVE" Then Throw New InvalidDataException("Not a WAV file: " & fileName)
        Do
            Dim id = Text.Encoding.ASCII.GetString(reader.ReadBytes(4))
            Dim size = reader.ReadInt32()
            If id = "fmt " Then
                Dim formatTag = reader.ReadInt16()
                channels = reader.ReadInt16()
                rate = reader.ReadInt32()
                reader.ReadBytes(6) 'Byte rate and block align follow from the rest
                bits = reader.ReadInt16()
                reader.ReadBytes(size - 16 + (size And 1))
                If formatTag <> 1 OrElse (bits <> 8 AndAlso bits <> 16) OrElse (channels <> 1 AndAlso channels <> 2) Then
                    Throw New InvalidDataException("Only 8/16-bit mono/stereo PCM is supported: " & fileName)
                End If
            ElseIf id = "data" AndAlso bits <> 0 Then
                Return CInt(Math.Min(size, reader.BaseStream.Length - reader.BaseStream.Position))
            Else
                reader.ReadBytes(size + (size And 1)) 'Chunks are padded to an even size
            End If
        Loop
    End Function

    'Linear interpolation. Good enough for an odd replacement file; the game's own files need none.
    Private Shared Function Resample(stereo As Short(), rate As Integer) As Short()
        Dim frames = stereo.Length \ 2
        Dim resultFrames = CInt(Math.Max(1, CLng(frames) * AudioOutput.SampleRate \ rate))
        Dim result(resultFrames * 2 - 1) As Short
        For f = 0 To resultFrames - 1
            Dim source = CDbl(f) * rate / AudioOutput.SampleRate
            Dim i = Math.Min(CInt(Math.Floor(source)), frames - 1)
            Dim j = Math.Min(i + 1, frames - 1)
            Dim t = source - i
            For c = 0 To 1
                result(f * 2 + c) = CShort(stereo(i * 2 + c) * (1 - t) + stereo(j * 2 + c) * t)
            Next
        Next
        Return result
    End Function
End Class

Public Class Client
    Event Connected(sender As Object, e As EventArgs)
    Event Disconnected(sender As Object, e As EventArgs)
    Event ReceiveData(sender As Object, e As ReceiveDataEventArgs)
    Event SendCompleted(sender As Object, e As EventArgs)

    Private UserClient As Net.Sockets.Socket
    Private BoolIsConnection As Boolean = False
    Private Current As Threading.SynchronizationContext

    Sub New()
        Current = Threading.SynchronizationContext.Current
    End Sub

    REM Соединение с сервером!!!
    Public Overridable Function Connect(host As String, port As Integer) As Boolean 'Попытка подключения к серверу
        If BoolIsConnection Then Return False : Exit Function 'Если подключение существует, вернуть False в Form.ConnectBtn.Click
        Dim result As Boolean = True
        Try
            UserClient = New Net.Sockets.Socket(Net.Sockets.AddressFamily.InterNetwork, Net.Sockets.SocketType.Stream, Net.Sockets.ProtocolType.Tcp)
            UserClient.Connect(host, port)
            BoolIsConnection = True
            RaiseEvent Connected(Me, New EventArgs)
            InvokeMethod(AddressOf OnEventListener, UserClient)
        Catch ex As Exception
            result = False
        End Try
        GC.Collect()
        Return result
    End Function

    Private Sub InvokeMethod(method As Threading.ParameterizedThreadStart, param As Object)
        Dim ThreadAsync As New Threading.Thread(method)
        ThreadAsync.IsBackground = True
        ThreadAsync.Start(param)
        GC.Collect()
    End Sub
    REM Конец соединения с сервером!!!

    REM Пересылка данных!!!
    Private Sub OnEventListener(e As Net.Sockets.Socket)
        Dim ReceiveLength As Long = 0
        Dim BufferBytes(e.ReceiveBufferSize - 1) As Byte
        Try
            With e
                Dim ResultMessage As New IO.MemoryStream
                While .Connected
                    ReceiveLength = .Receive(BufferBytes)
                    If ReceiveLength = 0 Then Exit While
                    ResultMessage.Write(BufferBytes, 0, ReceiveLength)
                    If .Available = 0 Then
                        Current.Post(AddressOf Post_ReceiveData, ResultMessage.ToArray)
                        ResultMessage = New IO.MemoryStream
                        GC.Collect()
                    End If
                    GC.Collect()
                End While
            End With
        Catch ex As Exception
        Finally
            Current.Post(AddressOf Post_Disconnected, Nothing)
            GC.Collect()
        End Try
    End Sub

    Public Sub Send(content() As Byte)
        If Not BoolIsConnection Then Exit Sub
        Try
            UserClient.Send(content) 'САМА ПЕРЕСЫЛКА ДАННЫХ
            RaiseEvent SendCompleted(Me, New EventArgs)

        Catch ex As Exception

        End Try
        GC.Collect()
    End Sub

    Private Sub Post_ReceiveData(e() As Byte) 'При чтении данных сервером...
        RaiseEvent ReceiveData(Me, New ReceiveDataEventArgs(e))
        GC.Collect()
    End Sub
    REM Конец пересылки данных

    REM Отключение
    Public Overridable Sub Disconnect()
        If Not BoolIsConnection Then Exit Sub
        UserClient.Disconnect(False)
        UserClient.Close()
        BoolIsConnection = False
        RaiseEvent Disconnected(Me, New EventArgs)
        GC.Collect()
    End Sub

    Private Sub Post_Disconnected()
        Disconnect()
    End Sub
    REM Конец отключения

    Public Class ReceiveDataEventArgs
        Private _bytesData() As Byte
        Sub New(bytes() As Byte)
            _bytesData = bytes
        End Sub
        Public Overridable ReadOnly Property MessageData As Byte()
            Get
                Return _bytesData
            End Get
        End Property
    End Class

    Public Overridable ReadOnly Property IsConnection As Boolean
        Get
            Return BoolIsConnection
        End Get
    End Property
End Class
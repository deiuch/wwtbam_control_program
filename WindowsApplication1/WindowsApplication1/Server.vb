Public Class Server
    Event StartedListener(sender As Object, e As EventArgs)
    Event StopedListener(sender As Object, e As EventArgs)
    Event ConnectedSocket(sender As Object, e As ConnectedSocketEventArgs)
    Event DisconnectedSocket(sender As Object, e As DisconnectedSocketEventArgs)
    Event ReceiveData(sender As Object, e As ReceiveDataEventArgs)
    Event SendCompleted(sender As Object, e As EventArgs)

    Private BoolIsListener As Boolean = False 'Слушает ли программа или отсылает
    Private UserServer As Net.Sockets.Socket
    Private Current As Threading.SynchronizationContext
    Private ListUsers As New Collections.Generic.Dictionary(Of Net.EndPoint, Net.Sockets.Socket)

    Sub New()
        Current = Threading.SynchronizationContext.Current
    End Sub

    Public Overridable ReadOnly Property IsListener As Boolean
        Get
            Return BoolIsListener
        End Get
    End Property


    Public Overridable ReadOnly Property Users As Collections.Generic.Dictionary(Of Net.EndPoint, Net.Sockets.Socket)
        Get
            Return ListUsers
        End Get
    End Property

    REM Запуск сервера!!!
    Public Overridable Sub Start(Optional maxUsers As Integer = 100, Optional port As Integer = 8000) 'Старт прослушивания
        If BoolIsListener Then Exit Sub
        UserServer = New System.Net.Sockets.Socket(Net.Sockets.AddressFamily.InterNetwork, Net.Sockets.SocketType.Stream, Net.Sockets.ProtocolType.Tcp)
        With UserServer
            .Bind(New Net.IPEndPoint(Net.IPAddress.Any, Project.hostPort)) 'вместо Project.hostPort -> port
            .Listen(maxUsers)
        End With
        InvokeMethod(AddressOf OnEventListener, Nothing)
        BoolIsListener = True
        RaiseEvent StartedListener(Me, New EventArgs)
    End Sub

    Private Sub OnEventListener() 'Прослушка
        Try
            While BoolIsListener
                Try
                    Dim AcceptSocket As Net.Sockets.Socket = UserServer.Accept()
                    ListUsers.Add(AcceptSocket.RemoteEndPoint, AcceptSocket)
                    Current.Post(AddressOf Post_ConnectedSocket, AcceptSocket.RemoteEndPoint)
                    InvokeMethod(AddressOf OnEventAcceptSocket, AcceptSocket)
                    GC.Collect()
                Catch ex As Exception
                End Try
            End While
        Catch ex As Exception
            GC.Collect()
            Current.Post(AddressOf Post_StopedListener, Nothing)
        End Try
    End Sub

    Private Sub OnEventAcceptSocket(e As Net.Sockets.Socket) 'Получение доступа
        Dim RemoteEndPoint As Net.EndPoint = e.RemoteEndPoint
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
                        Current.Post(AddressOf Post_ReceiveData, {ResultMessage.ToArray, .RemoteEndPoint})
                        ResultMessage = New IO.MemoryStream
                        GC.Collect()
                    End If
                    GC.Collect()
                End While
            End With
        Catch ex As Exception
        Finally
            ListUsers.Remove(RemoteEndPoint)
            GC.Collect()
            Current.Post(AddressOf Post_DisconnectedSocket, RemoteEndPoint)
        End Try
    End Sub

    Private Sub Post_ReceiveData(e As Object) 'Принятие данных сервером
        RaiseEvent ReceiveData(Me, New ReceiveDataEventArgs(e(0), e(1)))
        GC.Collect()
    End Sub

    Private Sub Post_ConnectedSocket(e As Net.EndPoint) 'Когда сокет подсоединён...
        RaiseEvent ConnectedSocket(Me, New ConnectedSocketEventArgs(e))
    End Sub

    Public Class ReceiveDataEventArgs
        Private _Message() As Byte
        Private _EndPoint As Net.EndPoint
        Sub New(resultBytes() As Byte, endPoint As Net.EndPoint)
            _EndPoint = endPoint
            _Message = resultBytes
        End Sub
        Public Overridable ReadOnly Property MessageData As Byte()
            Get
                Return _Message
            End Get
        End Property

        Public Overridable ReadOnly Property RemoteEndPoint As Net.EndPoint
            Get
                Return _EndPoint
            End Get
        End Property
    End Class

    Private Sub InvokeMethod(method As Threading.ParameterizedThreadStart, param As Object) 'Настройка соединения
        Dim ThreadAsync As New Threading.Thread(method)
        ThreadAsync.IsBackground = True
        ThreadAsync.Start(param)
        GC.Collect()
    End Sub

    REM Конец запуска сервера!!!

    REM Чтение полученных данных!!!

    REM Конец чтения полученных данных!!!

    Private Sub Post_DisconnectedSocket(e As Net.EndPoint) 'При разрыве соединения...
        RaiseEvent DisconnectedSocket(Me, New DisconnectedSocketEventArgs(e))
    End Sub

    REM Отключение сервера
    Public Overridable Sub [Stop]()
        If Not BoolIsListener Then Exit Sub
        KickAll()
        UserServer.Close()
        ListUsers.Clear()
        BoolIsListener = False
        RaiseEvent StopedListener(Me, New EventArgs)
        GC.Collect()
    End Sub

    Public Overridable Sub KickAll() 'Очистка списка клиентов
        On Error GoTo EventHandler
        If Not BoolIsListener Then Exit Sub
        Dim RemoteEndPoint As Net.EndPoint = Nothing
        For Each item As Net.Sockets.Socket In ListUsers.Values
            RemoteEndPoint = item.RemoteEndPoint
            item.Close()
            RaiseEvent DisconnectedSocket(Me, New DisconnectedSocketEventArgs(RemoteEndPoint))
        Next
        ListUsers.Clear()
        GC.Collect()
EventHandler:
    End Sub
    REM Конец отключения сервера

    Public Class ConnectedSocketEventArgs
        Private _EndPoint As Net.EndPoint
        Public Sub New(endPoint As Net.EndPoint)
            _EndPoint = endPoint
        End Sub
        Public Overridable ReadOnly Property RemoteEndPoint As Net.EndPoint
            Get
                Return _EndPoint
            End Get
        End Property
    End Class

    Public Class DisconnectedSocketEventArgs
        Private _EndPoint As Net.EndPoint
        Public Sub New(endPoint As Net.EndPoint)
            _EndPoint = endPoint
        End Sub
        Public Overridable ReadOnly Property RemoteEndPoint As Net.EndPoint
            Get
                Return _EndPoint
            End Get
        End Property
    End Class

    Private Sub Post_StopedListener()
        [Stop]()
    End Sub
End Class
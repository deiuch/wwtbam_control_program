<Serializable> Public Class IONetwork
    Public Property Command As String
    Public Property Param As String
    Public Property Content As Object
    Public Property Guid As Guid

    Public Property Files As IONetwork.FileInfo()
    Public Property Directories As IONetwork.DirectoryInfo()
    Public Property Drivers As DriveInfo()

    <Serializable> Public Class FileInfo
        Public Property Length As Long
        Public Property FullName As String
        Public Property Name As String
        Public Property Extension As String
        Public Property DirectoryName As String
        Public Property Attributes As IO.FileAttributes
        Public Property CreationTime As Date
        Public Property LastAccessTime As Date
        Public Property LastWriteTime As Date
        Public Property IsReadOnly As Boolean
        Public Property Exists As Boolean
    End Class

    <Serializable> Public Class DirectoryInfo
        Public Property FullName As String
        Public Property Name As String
        Public Property Parent As String
        Public Property Root As String
        Public Property Attributes As IO.FileAttributes
        Public Property CreationTime As Date
        Public Property LastAccessTime As Date
        Public Property LastWriteTime As Date
        Public Property Exists As Boolean
    End Class

    <Serializable> Public Class DriveInfo
        Public Property AvailableFreeSpace As Long
        Public Property DriveFormat As String
        Public Property DriveType As IO.DriveType
        Public Property IsReady As Boolean
        Public Property Name As String
        Public Property RootDirectory As String
        Public Property TotalFreeSpace As Long
        Public Property TotalSize As Long
        Public Property VolumeLabel As String
    End Class
End Class

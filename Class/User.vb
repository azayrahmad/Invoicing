Imports System.Data.SqlClient

Public Class User
    Inherits Audit
    Public Property Email As String
    Public Property FullName As String
    Public Property Id As Integer
    Public Property IsActive As Boolean
    Public Property Password As String
End Class

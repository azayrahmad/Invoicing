Imports System.Data.SqlClient

Public Class User
    Inherits Audit
    Public Property Email As String
    Public Property FullName As String
    Public Property Id As Integer
    Public Property IsActive As Boolean
    Public Property Password As String

    Public Sub Save()
        Dim InsertSql As String = String.Format("INSERT INTO [InvoiceAziz].[dbo].[User] VALUES ('{0}', '{1}', {2}, {3}, '{4}')",
                                  Email, FullName, Id, If(IsActive, 1, 0), Password)

        Dim UpdateSql As String = String.Format("UPDATE [InvoiceAziz].[dbo].[User] SET Email ='{0}', FullName = '{1}', IsActive = {2}, Password = '{3}' WHERE Id = {4} ",
                                  Email, FullName, If(IsActive, 1, 0), Password, Id)
        Dim con As SqlConnection = New SqlConnection(InvoicingConstants.StringSQLConnectionString)
        Dim cmd As SqlCommand = New SqlCommand(InsertSql, con)

        Dim existingUser As User = New User()
        existingUser.Id = Me.Id
        If (Load(existingUser)) Then
            cmd = New SqlCommand(UpdateSql, con)
        End If

        con.Open()
        Dim result As Integer = cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Shared Function Load(ByRef user As User) As Boolean
        Dim stringLoadSql As String = String.Format("SELECT * FROM [InvoiceAziz].[dbo].[User] WHERE Id = {0}", user.Id)
        Dim con As SqlConnection = New SqlConnection(InvoicingConstants.StringSQLConnectionString)
        Dim cmd As SqlCommand = New SqlCommand(stringLoadSql, con)
        Dim result As Boolean = False

        con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()

        If reader.HasRows Then
            reader.Read()
            With user
                .Email = reader.Item("Email")
                .FullName = reader.Item("FullName")
                .IsActive = reader.Item("IsActive") = 1
                .Password = reader.Item("Password")
            End With
            result = True
        End If
        con.Close()

        Return result
    End Function

    Public Shared Sub Delete(ByRef existingUser As User)
        Dim DeleteSql As String = String.Format("DELETE FROM [InvoiceAziz].[dbo].[User] WHERE Id = {0}", existingUser.Id)
        Dim con As SqlConnection = New SqlConnection(InvoicingConstants.StringSQLConnectionString)
        Dim cmd As SqlCommand = New SqlCommand(DeleteSql, con)

        If (Load(existingUser)) Then
            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()
        End If
    End Sub

    Public Function Login() As Boolean
        Dim loggingUser As New User()
        With loggingUser
            .Id = Me.Id
        End With
        If (Load(loggingUser)) Then
            Return Me.Password = loggingUser.Password
        Else
            Return False
        End If

    End Function
End Class

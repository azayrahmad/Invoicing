Imports System.Data.SqlClient

Public Class TaskType
    Inherits Audit
    Public Property ChargePerHour As Double
    Public Property Id As Integer
    Public Property Name As String

    Public Sub Save()
        Dim InsertSql As String = String.Format("INSERT INTO [InvoiceAziz].[dbo].[TaskType] VALUES ({0}, {1}, '{2}')",
                                  ChargePerHour, GetNextNumber(), Name)

        Dim UpdateSql As String = String.Format("UPDATE [InvoiceAziz].[dbo].[TaskType] SET ChargePerHour ={0}, Name = '{1}' ",
                                  ChargePerHour, Name)
        Dim con As SqlConnection = New SqlConnection(InvoicingConstants.StringSQLConnectionString)
        Dim cmd As SqlCommand = New SqlCommand(InsertSql, con)

        Dim existingTaskType As TaskType = New TaskType()
        existingTaskType.Id = Me.Id
        If Me.Id <> Nothing AndAlso Load(existingTaskType) Then
            cmd = New SqlCommand(UpdateSql, con)
        Else
            Me.Id = GetNextNumber()
        End If

        con.Open()
        Dim result As Integer = cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Shared Function Load(ByRef taskType As TaskType) As Boolean
        Dim stringLoadSql As String = String.Format("SELECT * FROM [InvoiceAziz].[dbo].[TaskType] WHERE Id = {0}", taskType.Id)
        Dim con As SqlConnection = New SqlConnection(InvoicingConstants.StringSQLConnectionString)
        Dim cmd As SqlCommand = New SqlCommand(stringLoadSql, con)
        Dim result As Boolean = False

        con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()

        If reader.HasRows Then
            reader.Read()
            With taskType
                .ChargePerHour = reader.Item("ChargePerHour")
                .Name = reader.Item("Name")
            End With
            result = True
        End If
        con.Close()

        Return result
    End Function

    Public Sub Delete()
        Dim DeleteSql As String = String.Format("DELETE FROM [InvoiceAziz].[dbo].[TaskType] WHERE Id = {0}", Id)
        Dim con As SqlConnection = New SqlConnection(InvoicingConstants.StringSQLConnectionString)
        Dim cmd As SqlCommand = New SqlCommand(DeleteSql, con)

        Dim existingTaskType As TaskType = New TaskType()
        existingTaskType.Id = Me.Id
        If Load(existingTaskType) Then
            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()
        End If
    End Sub

    Private Function GetNextNumber() As Integer
        Dim InsertSql As String = "SELECT MAX(Id) FROM [InvoiceAziz].[dbo].[TaskType]"
        Dim con As SqlConnection = New SqlConnection(InvoicingConstants.StringSQLConnectionString)
        Dim cmd As SqlCommand = New SqlCommand(InsertSql, con)
        Dim result As Integer = 0

        con.Open()
        Dim nextNumber As Object = cmd.ExecuteScalar()
        If Not IsDBNull(nextNumber) Then
            result = Val(nextNumber)
        End If
        con.Close()

        Return result + 1
    End Function
End Class

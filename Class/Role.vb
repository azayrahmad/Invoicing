Imports System.Data.SqlClient
Public Class Role
    Inherits Audit

    Enum RoleName
        Employee = 1
        Employer = 2
        Finance = 3
    End Enum
    Public Property Id As Integer
    Public Property Name As Integer

    Public Shared Function GetRoleByUserId(ByVal userId As Integer) As Integer
        Dim stringLoadSql As String = String.Format("SELECT Name FROM [InvoiceAziz].[dbo].[Role] WHERE Id = {0}", userId)
        Dim con As SqlConnection = New SqlConnection(InvoicingConstants.StringSQLConnectionString)
        Dim cmd As SqlCommand = New SqlCommand(stringLoadSql, con)
        Dim result As Integer = 0
        con.Open()
        result = cmd.ExecuteScalar()

        con.Close()

        Return result
    End Function
End Class

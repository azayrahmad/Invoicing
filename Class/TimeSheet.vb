Imports System.Data.SqlClient

Public Class TimeSheet
    Inherits Audit
    Public Property HourActual As Double
    Public Property HourPlanned As Double
    Public Property Id As Integer
    Public Property Number As String
    Public Property Status As InvoicingEnum.Status
    Public Property TaskDescription As String
    Public Property TaskType As TaskType
    Public Function GetTotalPrice() As Double
        Return Me.HourActual * Me.TaskType.ChargePerHour
    End Function


    Public Sub Save()
        Dim nextNumber As Integer = GetNextNumber()
        Dim InsertSql As String = String.Format("INSERT INTO [InvoiceAziz].[dbo].[TimeSheet] VALUES ({0}, {1}, {2}, {3}, {4}, '{5}', {6})",
                                      HourActual, HourPlanned, Id, nextNumber, Convert.ToInt32(InvoicingEnum.Status.Created), TaskDescription, TaskType.Id)
        Dim UpdateSql As String = String.Format("UPDATE [InvoiceAziz].[dbo].[TimeSheet] SET HourActual ='{0}', HourPlanned = '{1}', Status = '{2}', TaskDescription = '{3}', TaskType = '{4}' WHERE Id = {5}  AND Number = {6}",
                                      HourActual, HourPlanned, Convert.ToInt32(InvoicingEnum.Status.Created), TaskDescription, TaskType.Id, Id, Number)
        Dim con As SqlConnection = New SqlConnection(InvoicingConstants.StringSQLConnectionString)
        Dim cmd As SqlCommand = New SqlCommand(InsertSql, con)

        Dim existingTimesheet As TimeSheet = New TimeSheet()
        existingTimesheet.Id = Me.Id
        existingTimesheet.Number = Me.Number
        If Me.Number <> Nothing AndAlso (Load(existingTimesheet)) Then
            cmd = New SqlCommand(UpdateSql, con)
        Else
            Me.Number = nextNumber
        End If
        con.Open()
        Dim result As Integer = cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub Save(tsList As List(Of TimeSheet))
        tsList.Add(Me)
    End Sub


    Public Sub Submit()
        Dim UpdateSql As String = String.Format("UPDATE [InvoiceAziz].[dbo].[TimeSheet] SET  Status = '{0}'  WHERE Id = {1}  AND Number = {2}",
                                      Convert.ToInt32(InvoicingEnum.Status.Submitted), Id, Number)
        Dim con As SqlConnection = New SqlConnection(InvoicingConstants.StringSQLConnectionString)
        Dim cmd As SqlCommand = New SqlCommand(UpdateSql, con)

        con.Open()
        Dim result As Integer = cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub Submit(tsList As List(Of TimeSheet))
        Dim tsToSubmit As TimeSheet = Me

    End Sub

    Public Function Load(ByVal timeSheet As TimeSheet) As Boolean
        Dim stringLoadSql As String = String.Format("SELECT * FROM [InvoiceAziz].[dbo].[TimeSheet] WHERE Id = {0} AND Number = {1}", timeSheet.Id, timeSheet.Number)
        Dim con As SqlConnection = New SqlConnection(InvoicingConstants.StringSQLConnectionString)
        Dim cmd As SqlCommand = New SqlCommand(stringLoadSql, con)
        Dim taskType As New TaskType
        Dim result As Boolean = False

        con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        reader.Read()
        If reader.HasRows() Then
            With timeSheet
                .HourActual = reader.Item("HourActual")
                .HourPlanned = reader.Item("HourPlanned")
                .Status = CType(reader.Item("Status"), InvoicingEnum.Status)
                .TaskDescription = reader.Item("TaskDescription")
            End With
            taskType.Id = reader.Item("TaskType")
            If taskType.Load(taskType) Then
                timeSheet.TaskType = taskType
            End If
            result = True
        End If
        con.Close()

        Return result
    End Function

    Public Sub Load(tsList As List(Of TimeSheet))
        Dim tsToLoad As TimeSheet = tsList.Find(Function(p) p.Id = Me.Id AndAlso p.Number = Me.Number)

    End Sub

    Public Shared Function LoadAllTimeSheet(ByVal id As Integer) As DataTable
        Dim stringLoadSql As String = String.Format("SELECT * FROM [InvoiceAziz].[dbo].[TimeSheet] WHERE Id = {0}", id)
        Dim con As SqlConnection = New SqlConnection(InvoicingConstants.StringSQLConnectionString)
        Dim cmd As SqlCommand = New SqlCommand(stringLoadSql, con)
        Dim taskType As New TaskType
        Dim result As New DataTable

        con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        result.Load(reader)
        con.Close()

        Return result
    End Function

    Public Function LoadSubmittedTimeSheet(ByRef dataTable As DataTable) As Boolean
        Dim stringLoadSql As String = String.Format("SELECT * FROM [InvoiceAziz].[dbo].[TimeSheet] WHERE Status = {0}", Convert.ToInt32(InvoicingEnum.Status.Submitted))
        Dim con As SqlConnection = New SqlConnection(InvoicingConstants.StringSQLConnectionString)
        Dim cmd As SqlCommand = New SqlCommand(stringLoadSql, con)
        Dim taskType As New TaskType
        Dim result As Boolean = False

        con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        dataTable.Load(reader)
        If dataTable.Rows.Count > 0 Then
            result = True
        End If
        con.Close()

        Return result
    End Function

    Public Shared Function SelectTimesheetFromTable(ByVal id As Integer, ByVal number As Integer, ByVal dataTable As DataTable) As TimeSheet
        Dim tsSelectedTimesheet As New TimeSheet
        Dim ttSelectedTaskType As New TaskType
        Dim rowTimesheet As DataRow

        rowTimesheet = dataTable.Select(String.Format("Number = {1}", id, number)).First

        With tsSelectedTimesheet
            .Id = id
            .Number = number
            .HourActual = Convert.ToDouble(rowTimesheet("HourActual"))
            .HourPlanned = Convert.ToDouble(rowTimesheet("HourPlanned"))
            .Status = CType(Convert.ToInt32(rowTimesheet("Status")), InvoicingEnum.Status)
            .TaskDescription = rowTimesheet("TaskDescription").ToString()
        End With

        ttSelectedTaskType.Id = Convert.ToInt32(rowTimesheet("TaskType"))
        If TaskType.Load(ttSelectedTaskType) Then
            tsSelectedTimesheet.TaskType = ttSelectedTaskType
        End If

        Return tsSelectedTimesheet
    End Function

    Public Sub Delete()
        Dim DeleteSql As String = String.Format("DELETE FROM [InvoiceAziz].[dbo].[TimeSheet] WHERE Id = {0} AND Number = {1}", Me.Id, Me.Number)
        Dim con As SqlConnection = New SqlConnection(InvoicingConstants.StringSQLConnectionString)
        Dim cmd As SqlCommand = New SqlCommand(DeleteSql, con)

        con.Open()
        Dim result As Integer = cmd.ExecuteNonQuery()
        con.Close()

    End Sub

    Public Sub Clean()
        Dim CleanSql As String = String.Format("TRUNCATE TABLE [InvoiceAziz].[dbo].[TimeSheet]")
        Dim con As SqlConnection = New SqlConnection(InvoicingConstants.StringSQLConnectionString)
        Dim cmd As SqlCommand = New SqlCommand(CleanSql, con)

        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

    End Sub

    Private Function GetNextNumber() As Integer
        Dim InsertSql As String = "SELECT MAX(Number) FROM [InvoiceAziz].[dbo].[TimeSheet]"
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

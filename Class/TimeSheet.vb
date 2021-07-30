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

End Class

Imports NUnit.Framework

<TestFixture>
Public Class TimeSheet_ShouldCreateTimeSheet
    Inherits TestBase

    Private Const _HourActual = 3
    Private Const _HourPlanned = 8
    Private Const _TaskDescription As String = "Task Description Test"
    Private _User As User = mockUserEmployee
    Private _TaskType As TaskType = mockTasktypeNormalDay

    <Test>
    Public Sub TimeSheet_ShouldCreateTimeSheet()
        ' Arrange
        Dim _timesheetCreated As New TimeSheet
        With _timesheetCreated
            .Id = _User.Id
            .HourActual = _HourActual
            .HourPlanned = _HourPlanned
            .TaskType = _TaskType
            .TaskDescription = _TaskDescription
        End With


        mockInsertTimesheetToList(_timesheetCreated, mockUserEmployee.FullName)

        Dim _timesheetRetrieved As TimeSheet = mockLoadTimesheetFromList(mockUserEmployee.Id, _timesheetCreated.Number)

        Assert.IsTrue(_timesheetRetrieved.Id = mockUserEmployee.Id)
        Assert.IsTrue(_timesheetRetrieved.HourActual = _HourActual)
        Assert.IsTrue(_timesheetRetrieved.HourPlanned = _HourPlanned)
        Assert.AreEqual(_timesheetRetrieved.TaskType, _TaskType)
        Assert.IsTrue(_timesheetRetrieved.Status = InvoicingEnum.Status.Created)

    End Sub

End Class
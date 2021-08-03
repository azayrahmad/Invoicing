Imports NUnit.Framework

<TestFixture>
Public Class BusinessProcess_Employee_UpdateTS
    Inherits TestBase

    Public _timesheetRejected As New TimeSheet
    Public _timesheetRetrieved As New TimeSheet
    Public _timesheetSubmitted As New TimeSheet

    <SetUp>
    Public Sub SetUpRejectedTSToUpdate()
        ' Submit 2 timesheet
        With _timesheetRejected
            .Id = mockUserEmployee.Id
            .HourActual = 6
            .HourPlanned = 8
            .TaskType = mockTasktypeNormalDay
            .TaskDescription = mockTasktypeNormalDay.Name
        End With
        mockInsertTimesheetToList(_timesheetRejected, mockUserEmployee.Id)
        mockSubmitTimeSheet(_timesheetRejected, mockUserEmployee.Id)

    End Sub

    <Test>
    Public Sub BusinessProcess_Employee_UpdateTS()

        ' Search timesheet
        _timesheetRetrieved = mockLoadTimesheetFromList(_timesheetRejected.Id, _timesheetRejected.Number)

        ' Update timesheet
        _timesheetRetrieved.HourActual = 8
        _timesheetRetrieved.HourPlanned = 8
        mockUpdateTimeSheetInList(_timesheetRetrieved, mockUserEmployee.Id)

        ' Submit timesheet
        mockSubmitTimeSheet(_timesheetRetrieved, mockUserEmployee.Id)
        _timesheetSubmitted = mockLoadTimesheetFromList(_timesheetRetrieved.Id, _timesheetRetrieved.Number)

        Assert.IsTrue(_timesheetSubmitted.Status = InvoicingEnum.Status.Submitted)

    End Sub

End Class
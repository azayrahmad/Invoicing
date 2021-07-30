Imports NUnit.Framework

<TestFixture>
Public Class BusinessProcess_Employee_SubmitTS
    Inherits TestBase

    Public _timesheetCreated As New TimeSheet
    Public _timesheetRetrieved As New TimeSheet
    Public _timesheetSubmitted As New TimeSheet

    <Test>
    Public Sub BusinessProcess_Employee_SubmitTS()

        ' Create timesheet 
        With _timesheetCreated
            .Id = mockUserEmployee.Id
            .HourActual = 8
            .HourPlanned = 8
            .TaskType = mockTasktypeNormalDay
            .TaskDescription = mockTasktypeNormalDay.Name
        End With
        mockInsertTimesheetToList(_timesheetCreated, mockUserEmployee.FullName)

        ' Search timesheet
        _timesheetRetrieved = mockLoadTimesheetFromList(_timesheetCreated.Id, _timesheetCreated.Number)

        ' Submit timesheet
        mockSubmitTimeSheet(_timesheetRetrieved, mockUserEmployee.Id)
        _timesheetSubmitted = mockLoadTimesheetFromList(_timesheetRetrieved.Id, _timesheetRetrieved.Number)

        Assert.IsTrue(_timesheetSubmitted.Status = InvoicingEnum.Status.Submitted)

    End Sub

End Class
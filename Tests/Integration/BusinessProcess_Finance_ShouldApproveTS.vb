Imports NUnit.Framework

<TestFixture>
Public Class BusinessProcess_Finance_ShouldApproveTS
    Inherits TestBase

    Private mockTimesheetSubmitted1 As New TimeSheet
    Private _timesheetRetrieved1 As New TimeSheet
    Private _timesheetApproved As New TimeSheet


    <SetUp>
    Public Sub SetUpTSApproval()
        ' Submit timesheet to approve
        With mockTimesheetSubmitted1
            .Id = mockUserEmployee.Id
            .HourActual = 6
            .HourPlanned = 8
            .TaskType = mockTasktypeNormalDay
            .TaskDescription = mockTasktypeNormalDay.Name
        End With
        mockInsertTimesheetToList(mockTimesheetSubmitted1, mockUserEmployee.Id)
        mockSubmitTimeSheet(mockTimesheetSubmitted1, mockUserEmployee.Id)
    End Sub

    <Test>
    Public Sub BusinessProcess_Finance_ShouldApproveTS()
        ' Display Detail Timesheet
        _timesheetRetrieved1 = mockLoadTimesheetFromList(mockTimesheetSubmitted1.Id, mockTimesheetSubmitted1.Number)

        ' Approve Timesheet
        mockEvaluateTimeSheet(_timesheetRetrieved1, mockUserFinance.Id, InvoicingEnum.Status.Approved)
        _timesheetApproved = mockLoadTimesheetFromList(_timesheetRetrieved1.Id, _timesheetRetrieved1.Number)

        Assert.AreEqual(_timesheetApproved, _timesheetRetrieved1)
    End Sub

End Class
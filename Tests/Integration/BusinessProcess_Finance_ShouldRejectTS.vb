Imports NUnit.Framework

<TestFixture>
Public Class BusinessProcess_Finance_ShouldRejectTS
    Inherits TestBase

    Private mockTimesheetSubmitted As New TimeSheet
    Private _timesheetRetrieved As New TimeSheet
    Private _timesheetRejected As New TimeSheet


    <SetUp>
    Public Sub SetUpTSRejection()
        ' Submit timesheet to reject
        With mockTimesheetSubmitted
            .Id = mockUserEmployee.Id
            .HourActual = 2
            .HourPlanned = 8
            .TaskType = mockTasktypeLeaveDay
            .TaskDescription = mockTasktypeLeaveDay.Name
        End With
        mockInsertTimesheetToList(mockTimesheetSubmitted, mockUserEmployee.Id)
        mockSubmitTimeSheet(mockTimesheetSubmitted, mockUserEmployee.Id)
    End Sub

    <Test>
    Public Sub BusinessProcess_Finance_ShouldRejectTS()
        ' Display Detail Timesheet
        _timesheetRetrieved = mockLoadTimesheetFromList(mockTimesheetSubmitted.Id, mockTimesheetSubmitted.Number)

        ' Reject Timesheet
        mockEvaluateTimeSheet(_timesheetRetrieved, mockUserFinance.Id, InvoicingEnum.Status.Rejected)
        _timesheetRejected = mockLoadTimesheetFromList(_timesheetRetrieved.Id, _timesheetRetrieved.Number)

        ' Send Rejected Timesheet Notification
        mockSendEmail(mockUserFinance, "timesheet", False, mockUserEmployee)
        Assert.IsTrue(mockListEmail.Any(Function(email)
                                            Return email.EmailContent = "Dear First Employee, your timesheet is rejected. Sincerely, Finance Guy No 1." AndAlso
                                            email.EmailAddress = mockUserEmployee.Email
                                        End Function))
    End Sub

End Class
Imports NUnit.Framework

<TestFixture>
Public Class BusinessProcess1
    Private _userEmployee As New User
    Private _timesheetCreated As New TimeSheet
    Private _timesheetSearched As New TimeSheet
    Private _timesheetSubmitted As New TimeSheet
    Private _tasktypeNormalDay As New TaskType
    Private _dtUserTimesheet As New DataTable

    <SetUp>
    Protected Sub SetUp()
        With _tasktypeNormalDay
            .Name = "Normal Day"
            .ChargePerHour = 100
        End With

        _tasktypeNormalDay.Save()

        With _userEmployee
            .Id = 1
            .FullName = "First Employee"
            .Password = "employee1"
            .Email = "employee.1@company.co.id"
            .IsActive = True
        End With

        _userEmployee.Save()

    End Sub

    <TearDown>
    Protected Sub Cleanup()
        User.Delete(_userEmployee)
        _tasktypeNormalDay.Delete()
        _timesheetCreated.Delete()
    End Sub

    <Test>
    Public Sub TestBusinessProcess1()
        Assert.IsTrue(_userEmployee.Login())
        If _userEmployee.Login() Then
            ' Create timesheet 
            With _timesheetCreated
                .Id = _userEmployee.Id
                .HourActual = 8
                .HourPlanned = 7
                .TaskType = _tasktypeNormalDay
            End With
            _timesheetCreated.Save()

            ' Search timesheet
            _dtUserTimesheet = TimeSheet.LoadAllTimeSheet(_userEmployee.Id)
            _timesheetSearched = TimeSheet.SelectTimesheetFromTable(_userEmployee.Id, _timesheetCreated.Number, _dtUserTimesheet)
            Assert.AreEqual(_timesheetSearched.HourActual, _timesheetCreated.HourActual)
            Assert.AreEqual(_timesheetSearched.HourPlanned, _timesheetCreated.HourPlanned)

            ' Submit timesheet
            _timesheetSearched.Submit()

            _dtUserTimesheet = TimeSheet.LoadAllTimeSheet(_userEmployee.Id)
            _timesheetSubmitted = TimeSheet.SelectTimesheetFromTable(_userEmployee.Id, _timesheetCreated.Number, _dtUserTimesheet)
            Assert.AreEqual(_timesheetSubmitted.Status, InvoicingEnum.Status.Submitted)

        End If
    End Sub
End Class
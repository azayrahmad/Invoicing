Imports System
Imports NUnit.Framework


<TestFixture>
Public Class TestClass1

    <Test>
    Public Sub TestMethod()
        ' TaskType Definitions
        Dim taskTypeNormal As New Invoicing.TaskType With {
            .Id = 1,
            .Name = "Normal Hour",
            .ChargePerHour = 10
        }
        taskTypeNormal.SaveTaskType()
        Dim taskTypeLeave As New Invoicing.TaskType With {
            .Id = 2,
            .Name = "Leave",
            .ChargePerHour = 5
        }
        taskTypeLeave.SaveTaskType()

        ' User Definitions
        Dim userEmployee As New User With {
            .Id = 1,
            .FullName = "Employee",
            .Email = "employee@company.co.id",
            .IsActive = True,
            .Password = "employee"
        }
        userEmployee.SaveUser()
        Dim userEmployer As New User With {
            .Id = 2,
            .FullName = "Employer",
            .Email = "employer@company.co.id",
            .IsActive = True,
            .Password = "employer"
        }
        userEmployer.SaveUser()
        Dim userFinance As New User With {
            .Id = 2,
            .FullName = "Finance",
            .Email = "finance@company.co.id",
            .IsActive = True,
            .Password = "finance"
        }
        userFinance.SaveUser()

        ' Login Test
        Dim userLoginWrong As New User With {
            .Id = 2,
            .Password = "noemployee"
        }
        Assert.That(Not userLoginWrong.Login())

        ' Employee 1
        Dim userLoginRight As New User()
        userLoginRight.Id = userEmployee.Id
        userLoginRight.Password = userEmployee.Password
        Assert.That(userLoginRight.Login())

        If (userLoginRight.Login()) Then
            ' Create Timesheet
            Dim timesheetMonday As New Invoicing.TimeSheet With {
                .HourActual = 6,
                .HourPlanned = 8,
                .Id = userLoginRight.Id,
                .Number = 1,
                .Status = InvoicingEnum.Status.Created,
                .TaskType = taskTypeNormal,
                .TaskDescription = "First Day"
             }
            timesheetMonday.SaveTimeSheet()
            Dim timesheetTuesday As New Invoicing.TimeSheet With {
                .HourActual = 8,
                .HourPlanned = 8,
                .Id = userLoginRight.Id,
                .Number = 2,
                .Status = InvoicingEnum.Status.Created,
                .TaskType = taskTypeLeave,
                .TaskDescription = "One Day Leave"
             }
            timesheetTuesday.SaveTimeSheet()

            ' Search Timesheet
            Dim timesheetSearch As New Invoicing.TimeSheet With {
                .Id = userLoginRight.Id,
                .Number = timesheetTuesday.Number
             }
            timesheetSearch.LoadTimeSheet(timesheetSearch)
            Assert.That(timesheetSearch.TaskDescription = timesheetTuesday.TaskDescription)

            Dim timesheetLoadOne As New Invoicing.TimeSheet()
            timesheetLoadOne.Id = timesheetMonday.Id
            timesheetLoadOne.Number = timesheetMonday.Number
            Assert.That(timesheetLoadOne.LoadTimeSheet(timesheetLoadOne))

            ' Submit Timesheet
            timesheetSearch.Status = InvoicingEnum.Status.Submitted
            timesheetSearch.SaveTimeSheet()

        End If

        Dim userLoginFinance As New User()
        userLoginFinance.Id = userFinance.Id
        userLoginFinance.Password = userFinance.Password

        If (userLoginFinance.Login()) Then
            ' Display Detail Timesheet
            Dim timesheetSubmitted As New Invoicing.TimeSheet()
            Dim tableSubmittedTS As New DataTable()
            If timesheetSubmitted.LoadSubmittedTimeSheet(tableSubmittedTS) Then

            End If

        End If


        ' Employer Definition
        Dim employerFirst As New Employer()
        With employerFirst
            .Id = 2
            .Name = userEmployer.FullName
            .Address = "Home No 2"
            .ContactName = "Mr Employer"
            .ContactEmail = userEmployer.Email
        End With


        'Cleanup

        ' Delete User
        userLoginRight.DeleteUser()
        Assert.That(Not userLoginRight.Login())

        taskTypeLeave.DeleteTaskType()
        taskTypeNormal.DeleteTaskType()
        Dim timesheetdelete As New Invoicing.TimeSheet()
        timesheetdelete.CleanTimeSheet()

    End Sub

    Public Sub Test()

    End Sub

End Class


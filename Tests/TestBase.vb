Imports NUnit.Framework

<TestFixture>
Public Class TestBase
    Public Class Email
        Public Property EmailAddress As String
        Public Property EmailContent As String
    End Class
    Public Enum RoleName
        Employee = 1
        Employer = 2
        Finance = 3
    End Enum

    Public mockListRole As New List(Of Role)

    Public mockUserEmployee As New User
    Public mockUserEmployer As New User
    Public mockUserFinance As New User

    Public mockEmployer As New Employer

    Public mockTasktypeNormalDay As New TaskType
    Public mockTasktypeLeaveDay As New TaskType

    Public mockListTimesheet As New List(Of TimeSheet)
    Public mockListEmail As New List(Of Email)

    Public mockListEmailEmployee As New List(Of String)
    Public mockListEmailEmployer As New List(Of String)
    Public mockListEmailFinance As New List(Of String)

    Public mockListInvoice As New List(Of Invoice)

    Public Const mockEmailFormat As String = "Dear {0}, your {1} is {2}. Sincerely, {3}."

    <SetUp>
    Protected Sub SetUp()
        'Setup Task Types
        With mockTasktypeNormalDay
            .Id = 1
            .Name = "Normal Day"
            .ChargePerHour = 100
        End With

        With mockTasktypeLeaveDay
            .Id = 2
            .Name = "Leave Day"
            .ChargePerHour = 100
        End With

        ' Setup Users
        With mockUserFinance
            .Id = 1
            .FullName = "Finance Guy No 1"
            .Password = "finance"
            .Email = "finance.1@company.co.id"
            .IsActive = True
            .SetCreatedBy("Finance Guy No 1")
            .SetCreatedDate(Today.Date)
        End With
        mockListRole.Add(New Role() With {.Id = mockUserFinance.Id, .Name = RoleName.Finance})

        With mockUserEmployer
            .Id = 2
            .FullName = "First Boss"
            .Password = "boss1"
            .Email = "boss.1@company.co.id"
            .IsActive = True
            .SetCreatedBy(mockUserFinance.FullName)
            .SetCreatedDate(Today.Date)
        End With
        mockListRole.Add(New Role() With {.Id = mockUserEmployer.Id, .Name = RoleName.Employer})

        With mockUserEmployee
            .Id = 3
            .FullName = "First Employee"
            .Password = "employee1"
            .Email = "employee.1@company.co.id"
            .IsActive = True
            .SetCreatedBy(mockUserEmployer.FullName)
            .SetCreatedDate(Today.Date)
        End With
        mockListRole.Add(New Role() With {.Id = mockUserEmployee.Id, .Name = RoleName.Employee})

        ' Setup Employer
        With mockEmployer
            .Address = "Sudirman St 222"
            .ContactEmail = mockUserEmployer.Email
            .ContactName = mockUserEmployer.FullName
            .Id = mockUserEmployer.Id
            .Name = mockUserEmployer.FullName
        End With

    End Sub

    <TearDown>
    Protected Sub Cleanup()
        mockListTimesheet.Clear()
    End Sub

#Region "Timesheet Related Function"
    Public Sub mockInsertTimesheetToList(ByRef timeSheet As TimeSheet, ByVal creator As String)
        timeSheet.Number = getTimesheetNextNumber()
        timeSheet.Status = InvoicingEnum.Status.Created
        timeSheet.SetCreatedBy(creator)
        timeSheet.SetCreatedDate(Today.Date)
        mockListTimesheet.Add(timeSheet)
    End Sub

    Public Function mockLoadTimesheetFromList(ByVal id As Integer, ByVal number As Integer)
        Return mockListTimesheet.Find(Function(t) t.Id = id AndAlso t.Number = number)
    End Function

    Public Sub mockUpdateTimeSheetInList(ByVal timeSheet As TimeSheet, ByVal updater As String)
        Dim tsToSubmit As TimeSheet = mockListTimesheet.Find(Function(t) t.Id = timeSheet.Id AndAlso t.Number = timeSheet.Number)
        tsToSubmit.Status = InvoicingEnum.Status.Created
        tsToSubmit.SetModifiedBy(updater)
        tsToSubmit.SetModifiedDate(Today.Date)
    End Sub

    Public Sub mockSubmitTimeSheet(ByVal timeSheet As TimeSheet, ByVal submitter As String)
        Dim tsToSubmit As TimeSheet = mockListTimesheet.Find(Function(t) t.Id = timeSheet.Id AndAlso t.Number = timeSheet.Number)
        tsToSubmit.Status = InvoicingEnum.Status.Submitted
        tsToSubmit.SetModifiedBy(submitter)
        tsToSubmit.SetModifiedDate(Today.Date)
    End Sub

    Public Sub mockEvaluateTimeSheet(ByVal timeSheet As TimeSheet, ByVal evaluator As String, ByVal status As InvoicingEnum.Status)
        Dim tsToSubmit As TimeSheet = mockListTimesheet.Find(Function(t) t.Id = timeSheet.Id AndAlso t.Number = timeSheet.Number)
        tsToSubmit.Status = status
        tsToSubmit.SetModifiedBy(evaluator)
        tsToSubmit.SetModifiedDate(Today.Date)
    End Sub

    Private Function getTimesheetNextNumber() As Integer
        Dim maxNumber As Integer = 0
        For Each ts As TimeSheet In mockListTimesheet
            If ts.Number > maxNumber Then
                maxNumber = ts.Number
            End If
        Next

        Return maxNumber + 1
    End Function
#End Region

    Public Sub mockSendEmail(ByVal sender As User, ByVal type As String, ByVal isApproved As Boolean, ByVal receiver As User)
        Dim emailContent As String = String.Format(mockEmailFormat, receiver.FullName, type, If(isApproved, "approved", "rejected"), sender.FullName)
        Dim email As New Email With {
            .EmailAddress = receiver.Email,
            .EmailContent = emailContent
            }
        mockListEmail.Add(email)
    End Sub

    Public Sub mockInsertComment(ByRef comment As Comment, ByRef listComment As List(Of Comment), ByVal creator As String)
        Dim maxId As Integer = 0
        For Each c As Comment In listComment
            If c.Id > maxId Then
                maxId = c.Id
            End If
        Next
        comment.Id = maxId + 1
        comment.SetCreatedBy(creator)
        comment.SetCreatedDate(Today.Date)
        listComment.Add(comment)
    End Sub

    Public Sub mockInsertInvoiceDetail(ByRef invoiceDetail As InvoiceDetail, ByVal listInvoiceDetail As List(Of InvoiceDetail), ByVal creator As String)
        Dim maxId As Integer = 0
        For Each id As InvoiceDetail In listInvoiceDetail
            If id.Id > maxId Then
                maxId = id.Id
            End If
        Next
        invoiceDetail.Id = maxId + 1
        invoiceDetail.SetCreatedBy(creator)
        invoiceDetail.SetCreatedDate(Today.Date)
        listInvoiceDetail.Add(invoiceDetail)
    End Sub

    Public Sub mockInsertInvoiceToList(ByRef invoice As Invoice)
        Dim maxId As Integer = 0
        For Each i As Invoice In mockListInvoice
            If i.Id > maxId Then
                maxId = i.Id
            End If
        Next
        invoice.Id = maxId + 1
        With invoice
            .InvoiceCreatedDate = Today.Date
            .InvoiceNumber = .Id.ToString()
            .SetCreatedBy(.BillFrom)
            .SetCreatedDate(.InvoiceCreatedDate)
        End With
        mockListInvoice.Add(invoice)
    End Sub

    Public Sub mockUpdateInvoice(ByVal invoice As Invoice, ByVal updater As String)
        Dim invoiceToUpdate As Invoice = mockListInvoice.Find(Function(i) i.Id = invoice.Id)
        invoiceToUpdate.SetInvoiceStatus(Nothing)
        invoiceToUpdate.SetModifiedBy(updater)
        invoiceToUpdate.SetModifiedDate(Today.Date)
    End Sub

    Public Function mockLoadInvoiceFromList(ByVal id As Integer)
        Return mockListInvoice.Find(Function(i) i.Id = id)
    End Function

    Public Sub mockEvaluateInvoice(ByVal invoice As Invoice, ByVal evaluator As String, ByVal approval As InvoicingEnum.Approval)
        Dim invoiceToSubmit As Invoice = mockLoadInvoiceFromList(invoice.Id)
        invoiceToSubmit.SetInvoiceStatus(approval)
        invoiceToSubmit.SetModifiedBy(evaluator)
        invoiceToSubmit.SetModifiedDate(Today.Date)
    End Sub
End Class
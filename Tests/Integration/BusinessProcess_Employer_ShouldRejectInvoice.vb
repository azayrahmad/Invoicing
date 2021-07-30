Imports NUnit.Framework

<TestFixture>
Public Class BusinessProcess_Employer_ShouldRejectInvoice
    Inherits TestBase

    Public _invoiceToReject As New Invoice

    Public _invoiceDetailToReject1 As New InvoiceDetail
    Public _invoiceDetailToReject2 As New InvoiceDetail

    Public _commentToReject As New Comment
    Public _commentToReject2 As New Comment

    Public _listCommentToReject As New List(Of Comment)

    <SetUp>
    Public Sub SetUpInvoices()

        ' Create invoice to reject
        _commentToReject.Description = "Description for rejected invoice number 1"
        _commentToReject2.Description = "Description for rejected invoice number 2"

        With _invoiceDetailToReject1
            .Description = "Detail for Week 3"
            .Price = 12.24
            .Qty = 100
        End With
        With _invoiceDetailToReject2
            .Description = "Detail for Week 4"
            .Price = 20
            .Qty = 75
        End With

        With _invoiceToReject
            .BillFrom = "Finance Friend"
            .BillFromAddress = "Sutrisno St 44"
            .BillFromContactEmail = "finance.friend@company.com"
            .BillFromContactPhone = "444 - 44 44444"
            .BillTo = mockEmployer
            .Comments = New List(Of Comment)
            mockInsertComment(_commentToReject, .Comments, .BillFrom)
            mockInsertComment(_commentToReject2, .Comments, .BillFrom)
            .InvoiceDateIssued = Today.AddDays(-4)
            .InvoiceDetails = New List(Of InvoiceDetail)
            mockInsertInvoiceDetail(_invoiceDetailToReject1, .InvoiceDetails, .BillFrom)
            mockInsertInvoiceDetail(_invoiceDetailToReject2, .InvoiceDetails, .BillFrom)
        End With
        mockInsertInvoiceToList(_invoiceToReject)

    End Sub

    <Test>
    Public Sub BusinessProcess_Employer_ShouldRejectInvoice()

        ' Search invoice
        mockEvaluateInvoice(_invoiceToReject, mockUserEmployer.FullName, InvoicingEnum.Approval.Rejected)

        If mockListInvoice.Find(Function(i) i.Id = _invoiceToReject.Id).GetInvoiceStatus() = InvoicingEnum.Approval.Rejected Then
            mockSendEmail(mockUserEmployer, "invoice", False, mockUserEmployee)
        End If


        Assert.IsTrue(mockListEmail.Any(Function(email)
                                            Return email.EmailContent = "Dear First Employee, your invoice is rejected. Sincerely, First Boss." AndAlso
                                           email.EmailAddress = mockUserEmployee.Email
                                        End Function))
    End Sub

End Class
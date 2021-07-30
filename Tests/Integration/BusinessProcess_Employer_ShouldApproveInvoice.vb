Imports NUnit.Framework

<TestFixture>
Public Class BusinessProcess_Employer_ShouldApproveInvoice
    Inherits TestBase

    Public _invoiceToApprove As New Invoice

    Public _invoiceDetailToApprove1 As New InvoiceDetail
    Public _invoiceDetailToApprove2 As New InvoiceDetail

    Public _commentToApprove As New Comment

    Public _listCommentToApprove As New List(Of Comment)

    <SetUp>
    Public Sub SetUpInvoices()
        ' Create invoice to approve
        _commentToApprove.Description = "Description for approved invoice number 1"

        With _invoiceDetailToApprove1
            .Description = "Detail for Week 1"
            .Price = 1500.5
            .Qty = 12
        End With
        With _invoiceDetailToApprove2
            .Description = "Detail for Week 2"
            .Price = 400
            .Qty = 5
        End With

        With _invoiceToApprove
            .BillFrom = mockUserFinance.FullName
            .BillFromAddress = "Sutomo St 33"
            .BillFromContactEmail = mockUserFinance.Email
            .BillFromContactPhone = "333 - 333 3333"
            .BillTo = mockEmployer
            .Comments = New List(Of Comment)
            mockInsertComment(_commentToApprove, .Comments, .BillFrom)
            .InvoiceDateIssued = Today.AddDays(-2)
            .InvoiceDetails = New List(Of InvoiceDetail)
            mockInsertInvoiceDetail(_invoiceDetailToApprove1, .InvoiceDetails, .BillFrom)
            mockInsertInvoiceDetail(_invoiceDetailToApprove2, .InvoiceDetails, .BillFrom)
        End With
        mockInsertInvoiceToList(_invoiceToApprove)
    End Sub

    <Test>
    Public Sub BusinessProcess_Employer_ShouldApproveInvoice()
        ' Search invoice
        mockEvaluateInvoice(_invoiceToApprove, mockUserEmployer.FullName, InvoicingEnum.Approval.Approved)

        If mockListInvoice.Find(Function(i) i.Id = _invoiceToApprove.Id).GetInvoiceStatus() = InvoicingEnum.Approval.Approved Then
            mockSendEmail(mockUserEmployer, "invoice", True, mockUserEmployee)
        End If


        Assert.IsTrue(mockListEmail.Any(Function(email)
                                            Return email.EmailContent = "Dear First Employee, your invoice is approved. Sincerely, First Boss." AndAlso
                                           email.EmailAddress = mockUserEmployee.Email
                                        End Function))
    End Sub

End Class
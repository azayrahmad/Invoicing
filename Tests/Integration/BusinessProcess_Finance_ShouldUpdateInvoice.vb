Imports NUnit.Framework

<TestFixture>
Public Class BusinessProcess_Finance_ShouldUpdateInvoice
    Inherits TestBase

    Public _invoiceToSubmit As New Invoice

    Public _invoiceDetailToSubmit1 As New InvoiceDetail
    Public _invoiceDetailToSubmit2 As New InvoiceDetail

    Public _commentToSubmit As New Comment

    Public _listCommentToSubmit As New List(Of Comment)

    <SetUp>
    Public Sub SetUpInvoices()
        ' Create invoice to approve
        _commentToSubmit.Description = "Description for approved invoice number 1"

        With _invoiceDetailToSubmit1
            .Description = "Detail for Week 1"
            .Price = 1500.5
            .Qty = 12
        End With
        With _invoiceDetailToSubmit2
            .Description = "Detail for Week 2"
            .Price = 400
            .Qty = 5
        End With

        With _invoiceToSubmit
            .BillFrom = mockUserFinance.FullName
            .BillFromAddress = "Sutomo St 33"
            .BillFromContactEmail = mockUserFinance.Email
            .BillFromContactPhone = "333 - 333 3333"
            .BillTo = mockEmployer
            .Comments = New List(Of Comment)
            mockInsertComment(_commentToSubmit, .Comments, .BillFrom)
            .InvoiceDateIssued = Today.AddDays(-2)
            .InvoiceDetails = New List(Of InvoiceDetail)
            mockInsertInvoiceDetail(_invoiceDetailToSubmit1, .InvoiceDetails, .BillFrom)
            mockInsertInvoiceDetail(_invoiceDetailToSubmit2, .InvoiceDetails, .BillFrom)
        End With
        mockInsertInvoiceToList(_invoiceToSubmit)
    End Sub

    <Test>
    Public Sub BusinessProcess_Finance_ShouldUpdateInvoice()

        ' Search invoice
        Dim invoiceLoaded As Invoice = mockLoadInvoiceFromList(_invoiceToSubmit.Id)
        Dim numberOfInvoiceDetails As Integer = invoiceLoaded.InvoiceDetails.Count
        Dim invoiceDetailNew As New InvoiceDetail
        With invoiceDetailNew
            .Description = "Detail for Week 5"
            .Price = 34
            .Qty = 2
        End With

        ' Update invoice
        invoiceLoaded.InvoiceDetails.Add(invoiceDetailNew)
        invoiceLoaded.BillFromContactPhone = "111 - 11111"
        mockUpdateInvoice(invoiceLoaded, mockUserFinance.FullName)

        'Submit invoice
        Dim invoiceUpdated As Invoice = mockLoadInvoiceFromList(invoiceLoaded.Id)

    End Sub

End Class
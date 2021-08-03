Public Class Invoice
    Inherits Audit
    Public Property BillFrom As String
    Public Property BillFromAddress As String
    Public Property BillFromContactEmail As String
    Public Property BillFromContactPhone As String
    Public Property BillTo As Employer
    Public Property Comments As List(Of Comment)
    Public Property Id As Integer
    Public Property InvoiceCreatedDate As DateTime
    Public Property InvoiceDateIssued As DateTime
    Public Property InvoiceDetails As List(Of InvoiceDetail)
    Public Property InvoiceNumber As String
    Private _InvoiceStatus As InvoicingEnum.Approval

    Public Function GetInvoiceStatus() As InvoicingEnum.Approval
        Return _InvoiceStatus
    End Function

    Public Sub SetInvoiceStatus(AutoPropertyValue As InvoicingEnum.Approval)
        _InvoiceStatus = AutoPropertyValue
    End Sub

    Public Function GetGrandTotal() As Double
        Dim grandTotal As Double = 0
        For Each detail As InvoiceDetail In InvoiceDetails
            grandTotal += detail.GetTotal()
        Next

        Return grandTotal
    End Function

    Public Sub New()
        Me.Comments = New List(Of Comment)
        Me.InvoiceDetails = New List(Of InvoiceDetail)
    End Sub

End Class

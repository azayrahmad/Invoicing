Public Class InvoiceDetail
    Inherits Audit
    Public Property Description As String
    Public Property Id As Integer
    Public Property Price As Double
    Public Property Qty As Integer

    Public Function GetTotal() As Double
        Return Me.Qty * Me.Price
    End Function
End Class

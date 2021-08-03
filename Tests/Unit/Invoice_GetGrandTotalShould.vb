Imports NUnit.Framework

<TestFixture>
Public Class Invoice_GetGrandTotalShould
    Inherits TestBase

    <Test>
    Public Sub GetTotal_EmptyReturnZero()
        Dim emptyInvoiceDetail As New Invoice
        Dim expected As Double = 0

        Assert.AreEqual(emptyInvoiceDetail.GetGrandTotal, expected)
    End Sub

    <Test>
    Public Sub GetTotal_DetailReturnZero()
        ' Arrange
        Dim zeroInvoiceDetail As New Invoice
        Dim invoiceDetail1 As New InvoiceDetail
        Dim invoiceDetail2 As New InvoiceDetail

        Const zeroPrice As Double = 0
        Const zeroQty As Integer = 0
        Const nonZeroPrice As Double = 35
        Const nonZeroQty As Integer = 14

        With invoiceDetail1
            .Price = zeroPrice
            .Qty = nonZeroQty
        End With
        With invoiceDetail2
            .Price = nonZeroPrice
            .Qty = zeroQty
        End With

        Dim expected As Double = 0

        ' Act
        zeroInvoiceDetail.InvoiceDetails.Add(invoiceDetail1)
        zeroInvoiceDetail.InvoiceDetails.Add(invoiceDetail2)

        ' Assert
        Assert.AreEqual(zeroInvoiceDetail.GetGrandTotal, expected)
    End Sub

    <Test>
    Public Sub GetTotal_DetailReturnSum()
        ' Arrange
        Dim invoiceDetail As New Invoice
        Dim invoiceDetail1 As New InvoiceDetail
        Dim invoiceDetail2 As New InvoiceDetail

        Const nonZeroPrice1 As Double = 4
        Const nonZeroQty1 As Integer = 3
        Const nonZeroPrice2 As Double = 78
        Const nonZeroQty2 As Integer = 2

        With invoiceDetail1
            .Price = nonZeroPrice1
            .Qty = nonZeroQty1
        End With
        With invoiceDetail2
            .Price = nonZeroPrice2
            .Qty = nonZeroQty2
        End With

        Dim expected As Double = 168 ' 4*3 + 78*2

        ' Act
        invoiceDetail.InvoiceDetails.Add(invoiceDetail1)
        invoiceDetail.InvoiceDetails.Add(invoiceDetail2)

        ' Assert
        Assert.AreEqual(invoiceDetail.GetGrandTotal, expected)
    End Sub

End Class
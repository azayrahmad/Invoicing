Imports NUnit.Framework

<TestFixture>
Public Class InvoiceDetail_GetTotalShould
    Private _invoiceDetailPrice0 As New InvoiceDetail
    Private _invoiceDetailPrice1 As New InvoiceDetail
    Private _invoiceDetailPrice300 As New InvoiceDetail
    Private _invoiceDetailPriceHalf As New InvoiceDetail

    <SetUp>
    Protected Sub SetUp()
        _invoiceDetailPrice0.Price = 0
        _invoiceDetailPrice1.Price = 1
        _invoiceDetailPrice300.Price = 300
        _invoiceDetailPriceHalf.Price = 0.5
    End Sub

    <TestCase(0)>
    <TestCase(45.53)>
    <TestCase(378)>
    Public Sub GetTotal_ReturnZero(value As Double)
        ' x * 0 = 0
        Dim expected As Double = 0
        _invoiceDetailPrice0.Qty = value
        Assert.AreEqual(expected, _invoiceDetailPrice0.GetTotal)
    End Sub

    <TestCase(0.7)>
    <TestCase(95)>
    <TestCase(31)>
    Public Sub GetTotal_ReturnAsChargePerHour(value As Double)
        Dim expected As Double = Convert.ToInt32(value)
        _invoiceDetailPrice1.Qty = value
        Assert.AreEqual(expected, _invoiceDetailPrice1.GetTotal)
    End Sub

    <TestCase(0)>
    <TestCase(5)>
    <TestCase(31)>
    Public Sub GetTotal_ReturnTimesThreeHundred(value As Double)
        Dim expected As Double = Convert.ToInt32(value) * 300
        _invoiceDetailPrice300.Qty = value
        Assert.AreEqual(expected, _invoiceDetailPrice300.GetTotal)
    End Sub

    <TestCase(59)>
    <TestCase(80)>
    <TestCase(100.3)>
    Public Sub GetTotalPrice_ReturnHalf(value As Double)
        Dim expected As Double = Convert.ToInt32(value) * 0.5
        _invoiceDetailPriceHalf.Qty = value
        Assert.AreEqual(expected, _invoiceDetailPriceHalf.GetTotal)
    End Sub

End Class
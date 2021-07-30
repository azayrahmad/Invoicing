Imports NUnit.Framework

<TestFixture>
Public Class TimeSheet_GetTotalPriceShould
    Private _timeSheet0Hour As New TimeSheet
    Private _timeSheet1Hour As New TimeSheet
    Private _timeSheet3Hour As New TimeSheet
    Private _timeSheet8Hour As New TimeSheet
    Private _taskType As New TaskType

    <SetUp>
    Protected Sub SetUp()
        _timeSheet0Hour.HourActual = 0
        _timeSheet1Hour.HourActual = 1
        _timeSheet3Hour.HourActual = 3
        _timeSheet8Hour.HourActual = 8
        With _taskType
            .ChargePerHour = 0
            .Id = 1
            .Name = "Test task type"
        End With
    End Sub

    <TestCase(0)>
    <TestCase(4.5)>
    <TestCase(78)>
    Public Sub GetTotalPrice_ReturnZero(value As Double)
        ' x * 0 = 0
        Dim expected As Double = 0
        _taskType.ChargePerHour = value
        _timeSheet0Hour.TaskType = _taskType
        Assert.AreEqual(expected, _timeSheet0Hour.GetTotalPrice)
    End Sub

    <TestCase(0)>
    <TestCase(5)>
    <TestCase(31.1)>
    Public Sub GetTotalPrice_ReturnAsChargePerHour(value As Double)
        _taskType.ChargePerHour = value
        _timeSheet1Hour.TaskType = _taskType
        Assert.AreEqual(value, _timeSheet1Hour.GetTotalPrice)
    End Sub

    <TestCase(0)>
    <TestCase(5)>
    <TestCase(31)>
    Public Sub GetTotalPrice_ReturnTriple(value As Double)
        _taskType.ChargePerHour = value
        _timeSheet3Hour.TaskType = _taskType
        Assert.AreEqual(value * 3, _timeSheet3Hour.GetTotalPrice)
    End Sub

    <TestCase(59)>
    <TestCase(80)>
    <TestCase(100)>
    Public Sub GetTotalPrice_ReturnEightTimes(value As Double)
        _taskType.ChargePerHour = value
        _timeSheet8Hour.TaskType = _taskType
        Assert.AreEqual(value * 8, _timeSheet8Hour.GetTotalPrice)
    End Sub

End Class
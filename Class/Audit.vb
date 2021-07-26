Public Class Audit
    Private _CreatedBy As String
    Private Function GetCreatedBy() As String
        Return _CreatedBy
    End Function
    Public Sub SetCreatedBy(AutoPropertyValue As String)
        _CreatedBy = AutoPropertyValue
    End Sub

    Private _CreatedDate As Date
    Private Function GetCreatedDate() As Date
        Return _CreatedDate
    End Function
    Public Sub SetCreatedDate(AutoPropertyValue As Date)
        _CreatedDate = AutoPropertyValue
    End Sub

    Private _ModifiedBy As String
    Private Function GetModifiedBy() As String
        Return _ModifiedBy
    End Function
    Public Sub SetModifiedBy(Value As String)
        _ModifiedBy = Value
    End Sub

    Private _ModifiedDate As Date
    Private Function GetModifiedDate() As Date
        Return _ModifiedDate
    End Function
    Public Sub SetModifiedDate(AutoPropertyValue As Date)
        _ModifiedDate = AutoPropertyValue
    End Sub
End Class

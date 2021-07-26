Imports System.Data.SqlClient

Public Class InvoicingStart

    Dim con As SqlConnection = New SqlConnection(InvoicingConstants.StringSQLConnectionString)
    Dim cmd As SqlCommand
    Dim sql As String
    Dim result As Integer
    Private myReader As SqlDataReader


    Private Sub ButtonEmployee_Click(sender As Object, e As EventArgs) Handles ButtonEmployee.Click
        If Not String.IsNullOrEmpty(TextboxEmployee.Text) AndAlso Not String.IsNullOrEmpty(TextPasswordEmployee.Text) Then
            Dim EmployeeUser As New User()
            EmployeeUser.Id = TextboxEmployee.Text
            EmployeeUser.Password = TextPasswordEmployee.Text
            If EmployeeUser.Login() AndAlso User.Load(EmployeeUser) Then
                With TimesheetCreate
                    .TimesheetTitle.Text = EmployeeUser.FullName + "'s Timesheet"
                    .LoggedUser = EmployeeUser
                    .Show()
                End With
                LabelMessageEmployee.Text = "Employee window is open"
                LabelMessageEmployee.ForeColor = Color.Black
            Else
                LabelMessageEmployee.Text = "Employee Id and/or Password invalid"
                LabelMessageEmployee.ForeColor = Color.Red
            End If
        Else
            LabelMessageEmployee.Text = "Please enter your Employee Id and Password"
            LabelMessageEmployee.ForeColor = Color.Red
        End If
    End Sub

    Private Sub ButtonFinance_Click(sender As Object, e As EventArgs) Handles ButtonFinance.Click
        If Not String.IsNullOrEmpty(TextFinance.Text) AndAlso Not String.IsNullOrEmpty(TextPasswordFinance.Text) Then
            Dim financeUser As New User()
            financeUser.Id = TextFinance.Text
            financeUser.Password = TextPasswordFinance.Text
            If financeUser.Login() Then
                TimesheetCreate.Show()
                LabelMessageEmployee.Text = "Finance window is open"
                LabelMessageEmployee.ForeColor = Color.Black
            Else
                LabelMessageEmployee.Text = "Finance Id and/or Password invalid"
                LabelMessageEmployee.ForeColor = Color.Red
            End If
        Else
            LabelMessageEmployee.Text = "Please enter your Finance Id and Password"
            LabelMessageEmployee.ForeColor = Color.Red
        End If
    End Sub

    Private Sub ButtonEmployer_Click(sender As Object, e As EventArgs) Handles ButtonEmployer.Click
        If Not String.IsNullOrEmpty(TextBoxEmployer.Text) AndAlso Not String.IsNullOrEmpty(TextPasswordEmployer.Text) Then
            Dim EmployerUser As New User()
            EmployerUser.Id = TextBoxEmployer.Text
            EmployerUser.Password = TextPasswordEmployer.Text
            If EmployerUser.Login() Then
                TimesheetCreate.Show()
                LabelMessageEmployee.Text = "Employer window is open"
                LabelMessageEmployee.ForeColor = Color.Black
            Else
                LabelMessageEmployee.Text = "Employer Id and/or Password invalid"
                LabelMessageEmployee.ForeColor = Color.Red
            End If
        Else
            LabelMessageEmployee.Text = "Please enter your Employer Id and Password"
            LabelMessageEmployee.ForeColor = Color.Red
        End If

    End Sub
End Class


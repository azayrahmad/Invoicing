Public Class TimesheetCreate

    Public Property LoggedUser As User
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtUserTimesheet As New DataTable()
        Dim intRole As New Integer

        TextId.Text = LoggedUser.Id

        intRole = Role.GetRoleByUserId(LoggedUser.Id)
        dtUserTimesheet = TimeSheet.LoadAllTimeSheet(LoggedUser.Id)
        dgvTimesheet.DataSource = dtUserTimesheet

        If intRole = Role.RoleName.Employee Then
            dgvTimesheet.Columns("Id").Visible = False
        End If
    End Sub


End Class

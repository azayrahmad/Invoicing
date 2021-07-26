<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimesheetCreate
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TimesheetTitle = New System.Windows.Forms.Label()
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.LabelId = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.dgvTimesheet = New System.Windows.Forms.DataGridView()
        CType(Me.dgvTimesheet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TimesheetTitle
        '
        Me.TimesheetTitle.AutoSize = True
        Me.TimesheetTitle.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TimesheetTitle.Location = New System.Drawing.Point(33, 27)
        Me.TimesheetTitle.Name = "TimesheetTitle"
        Me.TimesheetTitle.Size = New System.Drawing.Size(281, 46)
        Me.TimesheetTitle.TabIndex = 0
        Me.TimesheetTitle.Text = "Create Timesheet"
        '
        'TextId
        '
        Me.TextId.Enabled = False
        Me.TextId.Location = New System.Drawing.Point(156, 123)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(125, 27)
        Me.TextId.TabIndex = 2
        '
        'LabelId
        '
        Me.LabelId.AutoSize = True
        Me.LabelId.Location = New System.Drawing.Point(33, 126)
        Me.LabelId.Name = "LabelId"
        Me.LabelId.Size = New System.Drawing.Size(92, 20)
        Me.LabelId.TabIndex = 4
        Me.LabelId.Text = "Employee Id"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 170)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Period End Date"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(156, 165)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(250, 27)
        Me.DateTimePicker1.TabIndex = 6
        '
        'dgvTimesheet
        '
        Me.dgvTimesheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTimesheet.Location = New System.Drawing.Point(156, 213)
        Me.dgvTimesheet.Name = "dgvTimesheet"
        Me.dgvTimesheet.RowHeadersWidth = 51
        Me.dgvTimesheet.RowTemplate.Height = 29
        Me.dgvTimesheet.Size = New System.Drawing.Size(582, 197)
        Me.dgvTimesheet.TabIndex = 7
        '
        'TimesheetCreate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.dgvTimesheet)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LabelId)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.TimesheetTitle)
        Me.Name = "TimesheetCreate"
        Me.Text = "Timesheet"
        CType(Me.dgvTimesheet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TimesheetTitle As Label
    Friend WithEvents TextId As TextBox
    Friend WithEvents LabelId As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents dgvTimesheet As DataGridView
End Class

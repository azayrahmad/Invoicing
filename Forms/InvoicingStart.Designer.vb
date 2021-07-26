<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InvoicingStart
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Title = New System.Windows.Forms.Label()
        Me.LabelEmployee = New System.Windows.Forms.Label()
        Me.TextboxEmployee = New System.Windows.Forms.TextBox()
        Me.ButtonEmployee = New System.Windows.Forms.Button()
        Me.GroupBoxEmployee = New System.Windows.Forms.GroupBox()
        Me.TextPasswordEmployee = New System.Windows.Forms.TextBox()
        Me.LabelPasswordEmployee = New System.Windows.Forms.Label()
        Me.GroupBoxEmployer = New System.Windows.Forms.GroupBox()
        Me.TextPasswordEmployer = New System.Windows.Forms.TextBox()
        Me.LabelPasswordEmployer = New System.Windows.Forms.Label()
        Me.ButtonEmployer = New System.Windows.Forms.Button()
        Me.TextBoxEmployer = New System.Windows.Forms.TextBox()
        Me.LabelEmployer = New System.Windows.Forms.Label()
        Me.LabelMessageEmployee = New System.Windows.Forms.Label()
        Me.GroupFinance = New System.Windows.Forms.GroupBox()
        Me.TextPasswordFinance = New System.Windows.Forms.TextBox()
        Me.LabelPasswordFinance = New System.Windows.Forms.Label()
        Me.ButtonFinance = New System.Windows.Forms.Button()
        Me.TextFinance = New System.Windows.Forms.TextBox()
        Me.LabelFinance = New System.Windows.Forms.Label()
        Me.GroupBoxEmployee.SuspendLayout()
        Me.GroupBoxEmployer.SuspendLayout()
        Me.GroupFinance.SuspendLayout()
        Me.SuspendLayout()
        '
        'Title
        '
        Me.Title.AutoSize = True
        Me.Title.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Title.Location = New System.Drawing.Point(12, 9)
        Me.Title.Name = "Title"
        Me.Title.Size = New System.Drawing.Size(270, 46)
        Me.Title.TabIndex = 0
        Me.Title.Text = "Invoicing System"
        '
        'LabelEmployee
        '
        Me.LabelEmployee.AutoSize = True
        Me.LabelEmployee.Location = New System.Drawing.Point(6, 25)
        Me.LabelEmployee.Name = "LabelEmployee"
        Me.LabelEmployee.Size = New System.Drawing.Size(99, 20)
        Me.LabelEmployee.TabIndex = 1
        Me.LabelEmployee.Text = "Employee Id :"
        '
        'TextboxEmployee
        '
        Me.TextboxEmployee.Location = New System.Drawing.Point(104, 22)
        Me.TextboxEmployee.Name = "TextboxEmployee"
        Me.TextboxEmployee.Size = New System.Drawing.Size(125, 27)
        Me.TextboxEmployee.TabIndex = 2
        '
        'ButtonEmployee
        '
        Me.ButtonEmployee.Location = New System.Drawing.Point(620, 21)
        Me.ButtonEmployee.Name = "ButtonEmployee"
        Me.ButtonEmployee.Size = New System.Drawing.Size(94, 29)
        Me.ButtonEmployee.TabIndex = 5
        Me.ButtonEmployee.Text = "Enter"
        Me.ButtonEmployee.UseVisualStyleBackColor = True
        '
        'GroupBoxEmployee
        '
        Me.GroupBoxEmployee.Controls.Add(Me.TextPasswordEmployee)
        Me.GroupBoxEmployee.Controls.Add(Me.LabelPasswordEmployee)
        Me.GroupBoxEmployee.Controls.Add(Me.ButtonEmployee)
        Me.GroupBoxEmployee.Controls.Add(Me.TextboxEmployee)
        Me.GroupBoxEmployee.Controls.Add(Me.LabelEmployee)
        Me.GroupBoxEmployee.Location = New System.Drawing.Point(39, 76)
        Me.GroupBoxEmployee.Name = "GroupBoxEmployee"
        Me.GroupBoxEmployee.Size = New System.Drawing.Size(720, 61)
        Me.GroupBoxEmployee.TabIndex = 0
        Me.GroupBoxEmployee.TabStop = False
        Me.GroupBoxEmployee.Text = "Employee"
        '
        'TextPasswordEmployee
        '
        Me.TextPasswordEmployee.Location = New System.Drawing.Point(333, 22)
        Me.TextPasswordEmployee.Name = "TextPasswordEmployee"
        Me.TextPasswordEmployee.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextPasswordEmployee.Size = New System.Drawing.Size(125, 27)
        Me.TextPasswordEmployee.TabIndex = 4
        '
        'LabelPasswordEmployee
        '
        Me.LabelPasswordEmployee.AutoSize = True
        Me.LabelPasswordEmployee.Location = New System.Drawing.Point(250, 25)
        Me.LabelPasswordEmployee.Name = "LabelPasswordEmployee"
        Me.LabelPasswordEmployee.Size = New System.Drawing.Size(77, 20)
        Me.LabelPasswordEmployee.TabIndex = 3
        Me.LabelPasswordEmployee.Text = "Password :"
        '
        'GroupBoxEmployer
        '
        Me.GroupBoxEmployer.Controls.Add(Me.TextPasswordEmployer)
        Me.GroupBoxEmployer.Controls.Add(Me.LabelPasswordEmployer)
        Me.GroupBoxEmployer.Controls.Add(Me.ButtonEmployer)
        Me.GroupBoxEmployer.Controls.Add(Me.TextBoxEmployer)
        Me.GroupBoxEmployer.Controls.Add(Me.LabelEmployer)
        Me.GroupBoxEmployer.Location = New System.Drawing.Point(39, 167)
        Me.GroupBoxEmployer.Name = "GroupBoxEmployer"
        Me.GroupBoxEmployer.Size = New System.Drawing.Size(720, 61)
        Me.GroupBoxEmployer.TabIndex = 6
        Me.GroupBoxEmployer.TabStop = False
        Me.GroupBoxEmployer.Text = "Employer"
        '
        'TextPasswordEmployer
        '
        Me.TextPasswordEmployer.Location = New System.Drawing.Point(333, 22)
        Me.TextPasswordEmployer.Name = "TextPasswordEmployer"
        Me.TextPasswordEmployer.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextPasswordEmployer.Size = New System.Drawing.Size(125, 27)
        Me.TextPasswordEmployer.TabIndex = 10
        '
        'LabelPasswordEmployer
        '
        Me.LabelPasswordEmployer.AutoSize = True
        Me.LabelPasswordEmployer.Location = New System.Drawing.Point(250, 25)
        Me.LabelPasswordEmployer.Name = "LabelPasswordEmployer"
        Me.LabelPasswordEmployer.Size = New System.Drawing.Size(77, 20)
        Me.LabelPasswordEmployer.TabIndex = 9
        Me.LabelPasswordEmployer.Text = "Password :"
        '
        'ButtonEmployer
        '
        Me.ButtonEmployer.Location = New System.Drawing.Point(620, 20)
        Me.ButtonEmployer.Name = "ButtonEmployer"
        Me.ButtonEmployer.Size = New System.Drawing.Size(94, 29)
        Me.ButtonEmployer.TabIndex = 11
        Me.ButtonEmployer.Text = "Enter"
        Me.ButtonEmployer.UseVisualStyleBackColor = True
        '
        'TextBoxEmployer
        '
        Me.TextBoxEmployer.Location = New System.Drawing.Point(104, 22)
        Me.TextBoxEmployer.Name = "TextBoxEmployer"
        Me.TextBoxEmployer.Size = New System.Drawing.Size(125, 27)
        Me.TextBoxEmployer.TabIndex = 8
        '
        'LabelEmployer
        '
        Me.LabelEmployer.AutoSize = True
        Me.LabelEmployer.Location = New System.Drawing.Point(6, 25)
        Me.LabelEmployer.Name = "LabelEmployer"
        Me.LabelEmployer.Size = New System.Drawing.Size(96, 20)
        Me.LabelEmployer.TabIndex = 7
        Me.LabelEmployer.Text = "Employer Id :"
        '
        'LabelMessageEmployee
        '
        Me.LabelMessageEmployee.AutoSize = True
        Me.LabelMessageEmployee.Location = New System.Drawing.Point(45, 402)
        Me.LabelMessageEmployee.Name = "LabelMessageEmployee"
        Me.LabelMessageEmployee.Size = New System.Drawing.Size(0, 20)
        Me.LabelMessageEmployee.TabIndex = 9
        '
        'GroupFinance
        '
        Me.GroupFinance.Controls.Add(Me.TextPasswordFinance)
        Me.GroupFinance.Controls.Add(Me.LabelPasswordFinance)
        Me.GroupFinance.Controls.Add(Me.ButtonFinance)
        Me.GroupFinance.Controls.Add(Me.TextFinance)
        Me.GroupFinance.Controls.Add(Me.LabelFinance)
        Me.GroupFinance.Location = New System.Drawing.Point(39, 256)
        Me.GroupFinance.Name = "GroupFinance"
        Me.GroupFinance.Size = New System.Drawing.Size(720, 61)
        Me.GroupFinance.TabIndex = 12
        Me.GroupFinance.TabStop = False
        Me.GroupFinance.Text = "Finance"
        '
        'TextPasswordFinance
        '
        Me.TextPasswordFinance.Location = New System.Drawing.Point(333, 22)
        Me.TextPasswordFinance.Name = "TextPasswordFinance"
        Me.TextPasswordFinance.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextPasswordFinance.Size = New System.Drawing.Size(125, 27)
        Me.TextPasswordFinance.TabIndex = 16
        '
        'LabelPasswordFinance
        '
        Me.LabelPasswordFinance.AutoSize = True
        Me.LabelPasswordFinance.Location = New System.Drawing.Point(250, 25)
        Me.LabelPasswordFinance.Name = "LabelPasswordFinance"
        Me.LabelPasswordFinance.Size = New System.Drawing.Size(77, 20)
        Me.LabelPasswordFinance.TabIndex = 15
        Me.LabelPasswordFinance.Text = "Password :"
        '
        'ButtonFinance
        '
        Me.ButtonFinance.Location = New System.Drawing.Point(620, 20)
        Me.ButtonFinance.Name = "ButtonFinance"
        Me.ButtonFinance.Size = New System.Drawing.Size(94, 29)
        Me.ButtonFinance.TabIndex = 17
        Me.ButtonFinance.Text = "Enter"
        Me.ButtonFinance.UseVisualStyleBackColor = True
        '
        'TextFinance
        '
        Me.TextFinance.Location = New System.Drawing.Point(104, 22)
        Me.TextFinance.Name = "TextFinance"
        Me.TextFinance.Size = New System.Drawing.Size(125, 27)
        Me.TextFinance.TabIndex = 14
        '
        'LabelFinance
        '
        Me.LabelFinance.AutoSize = True
        Me.LabelFinance.Location = New System.Drawing.Point(6, 25)
        Me.LabelFinance.Name = "LabelFinance"
        Me.LabelFinance.Size = New System.Drawing.Size(83, 20)
        Me.LabelFinance.TabIndex = 13
        Me.LabelFinance.Text = "Finance Id :"
        '
        'InvoicingStart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GroupFinance)
        Me.Controls.Add(Me.LabelMessageEmployee)
        Me.Controls.Add(Me.GroupBoxEmployer)
        Me.Controls.Add(Me.GroupBoxEmployee)
        Me.Controls.Add(Me.Title)
        Me.Name = "InvoicingStart"
        Me.Text = "Invoicing"
        Me.GroupBoxEmployee.ResumeLayout(False)
        Me.GroupBoxEmployee.PerformLayout()
        Me.GroupBoxEmployer.ResumeLayout(False)
        Me.GroupBoxEmployer.PerformLayout()
        Me.GroupFinance.ResumeLayout(False)
        Me.GroupFinance.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Title As Label
    Friend WithEvents LabelEmployee As Label
    Friend WithEvents TextboxEmployee As TextBox
    Friend WithEvents ButtonEmployee As Button
    Friend WithEvents GroupBoxEmployee As GroupBox
    Friend WithEvents GroupBoxEmployer As GroupBox
    Friend WithEvents ButtonEmployer As Button
    Friend WithEvents TextBoxEmployer As TextBox
    Friend WithEvents LabelEmployer As Label
    Friend WithEvents LabelMessageEmployee As Label
    Friend WithEvents TextPasswordEmployee As TextBox
    Friend WithEvents LabelPasswordEmployee As Label
    Friend WithEvents TextPasswordEmployer As TextBox
    Friend WithEvents LabelPasswordEmployer As Label
    Friend WithEvents GroupFinance As GroupBox
    Friend WithEvents TextPasswordFinance As TextBox
    Friend WithEvents LabelPasswordFinance As Label
    Friend WithEvents ButtonFinance As Button
    Friend WithEvents TextFinance As TextBox
    Friend WithEvents LabelFinance As Label
End Class

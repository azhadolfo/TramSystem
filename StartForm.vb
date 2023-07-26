Public Class StartForm

    Private Sub StartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Create an instance of the login form
        Dim LoginForm = New LoginForm()

        ' Set the login form's parent to the start form
        LoginForm.TopLevel = False
        LoginForm.FormBorderStyle = FormBorderStyle.None
        LoginForm.Dock = DockStyle.Fill

        ' Add the login form as a control to the start form
        Controls.Add(LoginForm)

        ' Show the login form
        LoginForm.Show()

        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class
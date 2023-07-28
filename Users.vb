Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports DocumentFormat.OpenXml.Wordprocessing



Public Class Users
    Private bAdd As Boolean
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Function GetUsers(ByVal userid As String) As DataTable
        Dim dtUserid As New DataTable()

        ' Query to fetch the data from the database
        Dim query As String = "SELECT * FROM tblemployee WHERE userid = @userid ORDER by id "

        Using command As New SqlCommand(query, LoginForm.Sqlconnection)
            command.Parameters.AddWithValue("@userid", userid)
            Try
                Dim reader As SqlDataReader = command.ExecuteReader()
                dtUserid.Load(reader)

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "MIS DEPARTMENT", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            End Try
        End Using

        Return dtUserid
    End Function

    Private Sub Users_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtEmpname.Enabled = False
        Me.txtPassword.Enabled = False
        Me.txtConfirm.Enabled = False

        Me.chkAdmin.Enabled = False
        Me.chkFast.Enabled = False
        Me.chkEdit.Enabled = False
        Me.chktugboat.Enabled = False
        Me.chkUsers.Enabled = False
        Me.chkReport.Enabled = False

        Me.btnSave.Enabled = False

    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        UserFile.Show()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(txtEmpno.Text) Then
            MessageBox.Show("Please enter Employee ID.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtEmpno.Focus()
            Return
        End If

        If String.IsNullOrEmpty(txtEmpname.Text) Then
            MessageBox.Show("Please enter Employee Name.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtEmpname.Focus()
            Return
        End If

        If String.IsNullOrEmpty(txtPassword.Text) Then
            MessageBox.Show("Please enter Password.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPassword.Focus()
            Return
        End If

        If String.IsNullOrEmpty(txtConfirm.Text) Then
            MessageBox.Show("Please confirm Password.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtConfirm.Focus()
            Return
        End If

        If txtPassword.Text.Trim() <> txtConfirm.Text.Trim() Then
            MessageBox.Show("Passwords did not match.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPassword.Focus()
            Return
        End If

        If MessageBox.Show("Are all entries correct?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If

        Dim password As String = txtPassword.Text
        Dim hashedPassword As String = HashPassword(password)

        If bAdd Then
            Try
                LoginForm.Sqlconnection.Open()

                'Hashing the Password


                ' Create a SQL command to insert the data into the database
                Dim sql As String = "INSERT INTO tblemployee (userid, username, password, allowgetdata, allowedit, allowreport, allowtugboat, allowuserfile, admin, createdby, createddate) VALUES (@EmpNo, @EmpName, @Password, @AllowGetData, @AllowEdit, @AllowReport, @AllowTugboat, @AllowUserFile, @Admin, @createdby, @createddate)"
                Using command As New SqlCommand(sql, LoginForm.Sqlconnection)
                    ' Set the parameter values
                    command.Parameters.AddWithValue("@EmpNo", txtEmpno.Text)
                    command.Parameters.AddWithValue("@EmpName", txtEmpname.Text)
                    command.Parameters.AddWithValue("@Password", hashedPassword)
                    command.Parameters.AddWithValue("@AllowGetData", chkFast.Checked)
                    command.Parameters.AddWithValue("@AllowEdit", chkEdit.Checked)
                    command.Parameters.AddWithValue("@AllowReport", chkReport.Checked)
                    command.Parameters.AddWithValue("@AllowTugboat", chktugboat.Checked)
                    command.Parameters.AddWithValue("@AllowUserFile", chkUsers.Checked)
                    command.Parameters.AddWithValue("@Admin", chkAdmin.Checked)
                    command.Parameters.AddWithValue("@createdby", username)
                    command.Parameters.AddWithValue("@createddate", DateTime.Now)

                    ' Execute the SQL command
                    command.ExecuteNonQuery()
                End Using

                bAdd = False

                MessageBox.Show("Record Added.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim query2 As String = "INSERT INTO atrail (userid, computer, date, source, activity, [file], record_id, remarks) 
                                                    VALUES (@userid, @computer, @date, 'Users Form', @activity, 'Users', @recid, @remarks)"

                Using command2 As New SqlCommand(query2, LoginForm.Sqlconnection)
                    ' Add parameters for the query
                    command2.Parameters.AddWithValue("@userid", username)
                    command2.Parameters.AddWithValue("@computer", Environment.UserName)
                    command2.Parameters.AddWithValue("@date", DateTime.Now)
                    command2.Parameters.AddWithValue("@activity", "Add record - user name: " & txtEmpname.Text)
                    command2.Parameters.AddWithValue("@recid", "") ' Assuming recid is a variable storing the record ID
                    command2.Parameters.AddWithValue("@remarks", "New record userid #" & txtEmpno.Text) ' Assuming you want to insert the text with the selected tugboat value

                    command2.ExecuteNonQuery()
                End Using

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "CONTACT MIS DEPARTMENT")
            End Try

        Else

            Try
                LoginForm.Sqlconnection.Open()
                Dim query As String = "UPDATE tblemployee SET username = @EmpName, password = @Password, allowgetdata = @AllowGetData, allowedit = @AllowEdit, allowreport = @AllowReport, allowtugboat = @AllowTugboat, allowuserfile = @AllowUserFile, editedby = @editedby, editeddate = @editeddate WHERE userid = @EmpNo"

                Using command As New SqlCommand(query, LoginForm.Sqlconnection)
                    command.Parameters.AddWithValue("@EmpNo", txtEmpno.Text)
                    command.Parameters.AddWithValue("@EmpName", txtEmpname.Text)
                    command.Parameters.AddWithValue("@Password", hashedPassword)
                    command.Parameters.AddWithValue("@AllowGetData", chkFast.Checked)
                    command.Parameters.AddWithValue("@AllowEdit", chkEdit.Checked)
                    command.Parameters.AddWithValue("@AllowReport", chkReport.Checked)
                    command.Parameters.AddWithValue("@AllowTugboat", chktugboat.Checked)
                    command.Parameters.AddWithValue("@AllowUserFile", chkUsers.Checked)
                    command.Parameters.AddWithValue("@Admin", chkAdmin.Checked)
                    command.Parameters.AddWithValue("@editedby", username)
                    command.Parameters.AddWithValue("@editeddate", DateTime.Now)


                    command.ExecuteNonQuery()
                End Using

                MessageBox.Show("Record updated.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim query2 As String = "INSERT INTO atrail (userid, computer, date, source, activity, [file], record_id, remarks) 
                                                    VALUES (@userid, @computer, @date, 'Users Form', @activity, 'Users', @recid, @remarks)"

                Using command2 As New SqlCommand(query2, LoginForm.Sqlconnection)
                    ' Add parameters for the query
                    command2.Parameters.AddWithValue("@userid", username)
                    command2.Parameters.AddWithValue("@computer", Environment.UserName)
                    command2.Parameters.AddWithValue("@date", DateTime.Now)
                    command2.Parameters.AddWithValue("@activity", "Edit record - user name: " & txtEmpname.Text)
                    command2.Parameters.AddWithValue("@recid", "") ' Assuming recid is a variable storing the record ID
                    command2.Parameters.AddWithValue("@remarks", "Update record userid" & txtEmpno.Text) ' Assuming you want to insert the text with the selected tugboat value

                    command2.ExecuteNonQuery()
                End Using


            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "CONTACT MIS DEPARTMENT")
            Finally


                LoginForm.Sqlconnection.Close()
            End Try
        End If

        ' Clear the input fields
        txtEmpno.Text = ""
        txtEmpname.Text = ""
        txtPassword.Text = ""
        txtConfirm.Text = ""
        chkAdmin.Checked = False
        chkEdit.Checked = False
        chkFast.Checked = False
        chkReport.Checked = False
        chktugboat.Checked = False
        chkUsers.Checked = False

    End Sub

    Private Sub txtEmpno_TextChanged(sender As Object, e As EventArgs) Handles txtEmpno.TextChanged

        Me.txtEmpname.Enabled = False
        Me.txtPassword.Enabled = False
        Me.txtConfirm.Enabled = False

        Me.chkAdmin.Enabled = False
        Me.chkFast.Enabled = False
        Me.chkEdit.Enabled = False
        Me.chktugboat.Enabled = False
        Me.chkUsers.Enabled = False
        Me.chkReport.Enabled = False

        Me.btnSave.Enabled = False


        Try
            LoginForm.Sqlconnection.Open()
            Dim userid As String = txtEmpno.Text
            Dim dtUsers As DataTable = GetUsers(userid)

            If dtUsers.Rows.Count > 0 Then

                bAdd = False
                Me.txtEmpname.Text = dtUsers.Rows(0)("username")
                Me.txtPassword.Text = dtUsers.Rows(0)("password")
                Me.txtConfirm.Text = dtUsers.Rows(0)("password")

                Me.chkAdmin.Checked = dtUsers.Rows(0)("admin")
                Me.chkFast.Checked = dtUsers.Rows(0)("allowgetdata")
                Me.chkEdit.Checked = dtUsers.Rows(0)("allowedit")
                Me.chktugboat.Checked = dtUsers.Rows(0)("allowtugboat")
                Me.chkUsers.Checked = dtUsers.Rows(0)("allowuserfile")
                Me.chkReport.Checked = dtUsers.Rows(0)("allowreport")

                If admin Then

                    Me.txtEmpname.Enabled = True
                    Me.txtPassword.Enabled = True
                    Me.txtConfirm.Enabled = True

                    Me.chkAdmin.Enabled = True
                    Me.chkFast.Enabled = True
                    Me.chkEdit.Enabled = True
                    Me.chktugboat.Enabled = True
                    Me.chkUsers.Enabled = True
                    Me.chkReport.Enabled = True

                    Me.btnSave.Enabled = True

                Else
                    If Me.txtEmpno.Text = username Then
                        Me.txtPassword.Enabled = True
                        Me.txtConfirm.Enabled = True
                        Me.btnSave.Enabled = True
                    End If

                End If


            Else

                Me.txtEmpname.Text = ""
                Me.txtPassword.Text = ""
                Me.txtConfirm.Text = ""

                Me.chkAdmin.Enabled = False
                Me.chkFast.Enabled = False
                Me.chkEdit.Enabled = False
                Me.chktugboat.Enabled = False
                Me.chkUsers.Enabled = False
                Me.chkReport.Enabled = False


                If admin Then

                    bAdd = True

                    Me.txtEmpname.Enabled = True
                    Me.txtPassword.Enabled = True
                    Me.txtConfirm.Enabled = True

                    Me.chkAdmin.Enabled = True
                    Me.chkFast.Enabled = True
                    Me.chkEdit.Enabled = True
                    Me.chktugboat.Enabled = True
                    Me.chkUsers.Enabled = True
                    Me.chkReport.Enabled = True

                    Me.btnSave.Enabled = True


                End If


            End If




        Catch ex As Exception
            MessageBox.Show("Please click ok to proceed", "CONTACT MIS DEPARTMENT", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            LoginForm.Sqlconnection.Close()
        End Try






        'Dim sql As String = "SELECT * FROM tblemployee WHERE userid=@userid"
        'Using command As New SqlCommand(sql, LoginForm.Sqlconnection)
        '    command.Parameters.AddWithValue("@userid", Me.txtEmpno.Text)
        '    Dim reader As SqlDataReader
        '    LoginForm.Sqlconnection.Open()

        '    reader = command.ExecuteReader

        '    If reader.HasRows Then
        '        bAdd = False
        '        reader.Read()
        '        Me.txtEmpname.Text = reader("username")
        '        Me.txtPassword.Text = reader("password")
        '        Me.txtConfirm.Text = reader("password")

        '        Me.chkAdmin.Checked = reader("Admin")
        '        Me.chkFast.Checked = reader("allowgetdata")
        '        Me.chkEdit.Checked = reader("allowedit")
        '        Me.chktugboat.Checked = reader("allowtugboat")
        '        Me.chkUsers.Checked = reader("allowuserfile")
        '        Me.chkReport.Checked = reader("allowreport")
        '        reader.Close()
        '        If admin Then

        '            Me.txtEmpname.Enabled = True
        '            Me.txtPassword.Enabled = True
        '            Me.txtConfirm.Enabled = True

        '            Me.chkAdmin.Enabled = True
        '            Me.chkFast.Enabled = True
        '            Me.chkEdit.Enabled = True
        '            Me.chktugboat.Enabled = True
        '            Me.chkUsers.Enabled = True
        '            Me.chkReport.Enabled = True

        '            Me.btnSave.Enabled = True
        '        Else
        '            If Me.txtEmpno.Text = username Then
        '                Me.txtPassword.Enabled = True
        '                Me.txtConfirm.Enabled = True
        '                Me.btnSave.Enabled = True
        '            End If
        '        End If

        '    Else
        '        Me.txtEmpname.Enabled = True
        '        Me.txtPassword.Enabled = True
        '        Me.txtConfirm.Enabled = True

        '        Me.chkAdmin.Enabled = True
        '        Me.chkFast.Enabled = True
        '        Me.chkEdit.Enabled = True
        '        Me.chktugboat.Enabled = True
        '        Me.chkUsers.Enabled = True
        '        Me.chkReport.Enabled = True

        '        If admin Then

        '            bAdd = True

        '            Me.txtEmpname.Text = ""
        '            Me.txtPassword.Text = ""
        '            Me.txtConfirm.Text = ""

        '            Me.chkAdmin.Enabled = True
        '            Me.chkFast.Enabled = True
        '            Me.chkEdit.Enabled = True
        '            Me.chktugboat.Enabled = True
        '            Me.chkUsers.Enabled = True
        '            Me.chkReport.Enabled = True

        '            Me.btnSave.Enabled = True



        '        End If

        '    End If

        'End Using


        'LoginForm.Sqlconnection.Close()

    End Sub

    Private Sub Users_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        MainForm.Show()
    End Sub




End Class
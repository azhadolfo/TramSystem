Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports DocumentFormat.OpenXml.Drawing
Imports DocumentFormat.OpenXml.Math

Public Class TugboatForm

    Private bAdd As Boolean
    Private bEdit As Boolean
    Private iRecid As Integer
    Private cParam As String
    Private Sub TugboatForm_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        MainForm.Show()
    End Sub

    Private Sub TugboatForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtName.Text = ""
        Me.txtAcquired.Text = ""
        Me.txtDate.Text = DateTime.Now.ToString("M/dd/yyyy")
        Me.txtAmount.Text = "0.00"
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        MainForm.Show()
    End Sub

    Private Sub EnableFields()
        Me.txtName.Enabled = True
        Me.txtAcquired.Enabled = True
        Me.txtDate.Enabled = True
        Me.txtAmount.Enabled = True
    End Sub

    Private Sub ClearFields()
        Me.txtNum.Text = ""
        Me.txtName.Text = ""
        Me.txtDate.Text = DateTime.Now.ToString("M/dd/yyyy")
        Me.txtAcquired.Text = ""
        Me.txtAmount.Text = "0.00"
    End Sub

    Private Sub DisableFields()
        Me.txtName.Enabled = False
        Me.txtAcquired.Enabled = False
        Me.txtDate.Enabled = False
        Me.txtAmount.Enabled = False
    End Sub

    Private Sub DisplayRec()
        LoginForm.Sqlconnection.Open()
        Try
            Dim dt As DataTable = GetTugboatNumber()

            If dt.Rows.Count > 0 Then

                Me.txtNum.Text = dt.Rows(0)("number")
                Me.txtName.Text = dt.Rows(0)("name")
                Me.txtAcquired.Text = dt.Rows(0)("acquiredfrom")
                Me.txtDate.Text = dt.Rows(0)("acquireddate")
                Me.txtAmount.Text = dt.Rows(0)("cost")
            End If




        Catch ex As Exception
            MessageBox.Show("There's an error connecting to the database", "CONTACT MIS DEPARTMENT", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            LoginForm.Sqlconnection.Close()
        End Try




    End Sub


    Private Sub SetButtons(cParam As String)
        ' Assuming lEdit and lAdd are already declared and set appropriately

        If cParam = "new" Or cParam = "edit" Then
            Me.btnNew.Enabled = False
            Me.btnEdit.Enabled = False
            Me.btnSearch.Enabled = False
            Me.btnSave.Enabled = True
            Me.btnCancel.Enabled = True
            Me.btnClose.Enabled = False
        End If

        If cParam = "cancel" Then
            Me.btnNew.Enabled = True
            If bEdit Then
                Me.btnEdit.Enabled = True
            Else ' lAdd
                Me.btnEdit.Enabled = False
            End If
            Me.btnSearch.Enabled = True
            Me.btnSave.Enabled = False
            Me.btnCancel.Enabled = False
            Me.btnClose.Enabled = True
        End If

        If cParam = "save" Or cParam = "search" Then
            Me.btnNew.Enabled = True
            Me.btnEdit.Enabled = True
            Me.btnSearch.Enabled = True
            Me.btnSave.Enabled = False
            Me.btnCancel.Enabled = False
            Me.btnClose.Enabled = True
        End If
    End Sub


    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        bAdd = True
        bEdit = False

        Me.txtNum.Enabled = False
        Me.lblSearch.Visible = False
        Me.ClearFields()
        Me.EnableFields()


        cParam = "new"
        SetButtons(cParam)
        Me.txtName.Focus()

        LoginForm.Sqlconnection.Open()
        Try
            Dim dtTugboatnumber As DataTable = GetTugboatNumber()

            If dtTugboatnumber.Rows.Count > 0 Then
                Dim lastRow As DataRow = dtTugboatnumber.Rows(dtTugboatnumber.Rows.Count - 1)

                ' Retrieve the last number as a string
                Dim lastNumber As String = lastRow("number").ToString()
                Dim lastRecid As String = lastRow("recid").ToString()

                ' Parse the last number string to an integer
                Dim numberValue As Integer = Integer.Parse(lastNumber)
                Dim recidValue As Integer = Integer.Parse(lastRecid)

                ' Increment the number
                numberValue += 1
                recidValue += 1

                ' Format the number with leading zeros (e.g., "005" to "006")
                Dim formattedNumber As String = numberValue.ToString("D3") ' "D3" means at least 3 digits with leading zeros

                txtNum.Text = formattedNumber
                iRecid = recidValue
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "MIS DEPARTMENT", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        Finally
            LoginForm.Sqlconnection.Close()
        End Try
    End Sub

    Private Function GetTugboatNumber() As DataTable

        Dim dtTugboatnumber As New DataTable()

        ' Query to fetch the data from the database
        Dim query As String = "SELECT * FROM tugboat ORDER by number"

        Using command As New SqlCommand(query, LoginForm.Sqlconnection)
            Try
                Dim reader As SqlDataReader = command.ExecuteReader()
                dtTugboatnumber.Load(reader)

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "MIS DEPARTMENT", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            End Try
        End Using

        Return dtTugboatnumber
    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.ClearFields()
        Me.txtNum.Enabled = True
        Me.lblSearch.Visible = True
        Me.txtNum.Focus()
        Me.btnClose.Enabled = False
    End Sub

    Private xNumber
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(txtNum.Text) Then
            MessageBox.Show("Kindly input tugboat number.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNum.Focus()
            Return
        End If

        If String.IsNullOrEmpty(txtName.Text) Then
            MessageBox.Show("Please enter tugboat name.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtName.Focus()
            Return
        End If

        If MessageBox.Show("Are all entries correct?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If

        Dim nErrorNum As Integer = 0

        Try
            LoginForm.Sqlconnection.Open()
            If bAdd Then


                ' Create a SQL command to insert the data into the database
                Dim sql As String = "INSERT INTO tugboat (number, name, acquireddate, acquiredfrom, cost, createddate, createdby) VALUES (@number, @name, @acquireddate, @acquiredfrom, @cost, @createddate, @createdby)"
                Using command As New SqlCommand(sql, LoginForm.Sqlconnection)
                    ' Set the parameter values
                    command.Parameters.AddWithValue("@number", txtNum.Text)
                    command.Parameters.AddWithValue("@name", txtName.Text)
                    command.Parameters.AddWithValue("@acquireddate", txtDate.Text)
                    command.Parameters.AddWithValue("@acquiredfrom", txtAcquired.Text)
                    command.Parameters.AddWithValue("@cost", txtAmount.Text)
                    command.Parameters.AddWithValue("@createddate", DateTime.Now)
                    command.Parameters.AddWithValue("@createdby", username)

                    ' Execute the SQL command
                    command.ExecuteNonQuery()
                End Using
            Else
                Dim query As String = "UPDATE tugboat SET name = @name, acquireddate = @acquireddate, acquiredfrom = @acquiredfrom, cost = @cost WHERE number = @number"

                Using command As New SqlCommand(query, LoginForm.Sqlconnection)
                    command.Parameters.AddWithValue("@number", txtNum.Text)
                    command.Parameters.AddWithValue("@name", txtName.Text)
                    command.Parameters.AddWithValue("@acquireddate", txtDate.Text)
                    command.Parameters.AddWithValue("@acquiredfrom", txtAcquired.Text)
                    command.Parameters.AddWithValue("@cost", txtAmount.Text)

                    command.ExecuteNonQuery()
                End Using
            End If
            If nErrorNum = 0 Then
                'CODES FOR ATRAIL UNCOMMENT THIS ONCE THE FORM IS IN FINAL
                If bAdd Then
                    MessageBox.Show("Record Added.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Dim query As String = "INSERT INTO atrail (userid, computer, date, source, activity, [file], record_id, remarks) 
                                                    VALUES (@userid, @computer, @date, 'Tugboat Form', @activity, 'TugboatForm', @recid, @remarks)"

                    Using command As New SqlCommand(query, LoginForm.Sqlconnection)
                        ' Add parameters for the query
                        command.Parameters.AddWithValue("@userid", username)
                        command.Parameters.AddWithValue("@computer", Environment.UserName)
                        command.Parameters.AddWithValue("@date", DateTime.Now)
                        command.Parameters.AddWithValue("@activity", "Add record = tugboat name: " & txtName.Text)
                        command.Parameters.AddWithValue("@recid", iRecid) ' Assuming recid is a variable storing the record ID
                        command.Parameters.AddWithValue("@remarks", "New record tugboat#" & txtNum.Text) ' Assuming you want to insert the text with the selected tugboat value

                        command.ExecuteNonQuery()
                    End Using
                Else

                    MessageBox.Show("Record updated.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim query2 As String = "INSERT INTO atrail (userid, computer, date, source, activity, [file], record_id, remarks) 
                                                    VALUES (@userid, @computer, @date, 'Tugboat Form', @activity, 'TugboatForm', @recid, @remarks)"

                    Using command2 As New SqlCommand(query2, LoginForm.Sqlconnection)
                        ' Add parameters for the query
                        command2.Parameters.AddWithValue("@userid", username)
                        command2.Parameters.AddWithValue("@computer", Environment.UserName)
                        command2.Parameters.AddWithValue("@date", DateTime.Now)
                        command2.Parameters.AddWithValue("@activity", "Edit record = tugboat name: " & txtName.Text)
                        command2.Parameters.AddWithValue("@recid", iRecid) ' Assuming recid is a variable storing the record ID
                        command2.Parameters.AddWithValue("@remarks", "Update record tugboat#" & txtNum.Text) ' Assuming you want to insert the text with the selected tugboat value

                        command2.ExecuteNonQuery()
                    End Using
                End If
            End If

            bAdd = False
            bEdit = False

            Me.DisableFields()

            cParam = "save"
            SetButtons(cParam)


        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "CONTACT MIS DEPARTMENT")
        Finally
            LoginForm.Sqlconnection.Close()
        End Try

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        bEdit = True
        bAdd = False

        Me.txtNum.Enabled = False

        Me.EnableFields()
        Me.SetButtons("edit")
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Me.DisableFields()
        Me.SetButtons("cancel")

        If bAdd Then
            Me.ClearFields()
        Else
            Me.DisplayRec()
            Me.btnEdit.Enabled = True
        End If

    End Sub

    Private Sub txtNum_TextChanged(sender As Object, e As EventArgs) Handles txtNum.TextChanged

        If LoginForm.Sqlconnection.State = ConnectionState.Open Then
            LoginForm.Sqlconnection.Close() ' Close the SqlConnection in the Finally block
        End If

        Dim sql As String = "SELECT * FROM tugboat WHERE number = @number"
        Try
            Using command As New SqlCommand(sql, LoginForm.Sqlconnection)
                command.Parameters.AddWithValue("@number", Me.txtNum.Text)
                Dim reader As SqlDataReader
                LoginForm.Sqlconnection.Open()
                reader = command.ExecuteReader

                If reader.HasRows Then
                    reader.Read()

                    Me.txtName.Text = reader("name")
                    Me.txtAcquired.Text = reader("acquiredfrom")
                    Me.txtDate.Text = reader("acquireddate")
                    Me.txtAmount.Text = reader("cost")
                    iRecid = reader("recid")

                    Me.btnEdit.Enabled = True
                    Me.btnSave.Enabled = False

                Else
                    Me.txtName.Text = ""
                    Me.txtAcquired.Text = ""
                    Me.txtDate.Text = DateTime.Now.ToString("M/dd/yyyy")
                    Me.txtAmount.Text = "0.00"
                End If

                reader.Close() ' Close the SqlDataReader here

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "MIS DEPARTMENT", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            If LoginForm.Sqlconnection.State = ConnectionState.Open Then
                LoginForm.Sqlconnection.Close() ' Close the SqlConnection in the Finally block
            End If
        End Try
    End Sub

    Private Sub txtDate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDate.KeyPress
        ' Check if the input character is a digit, slash, or a control character (e.g., Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "/" AndAlso Not Char.IsControl(e.KeyChar) Then
            ' Reject the input by setting the Handled property to True
            e.Handled = True
        End If
    End Sub
End Class
Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.VisualBasic.Devices

Public Class DataEntry
    Private currentRowIndex As Integer = 0
    Private LTransno As String
    Private iRecid As String
    Private totalRowCount As Integer = 0
    Private curdetails As New DataTable
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim currentDate As DateTime = DateTime.Now
        txtDate.Text = currentDate.ToString("M/d/yyyy")
        cboTugboat.SelectedIndex = 0
        txtRef.Text = ""
        txtSupplier.Text = ""
        txtParticulars.Text = ""
        txtRemarks.Text = ""
        Close()
    End Sub

    Private Sub DataEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoginForm.Sqlconnection.Open()

        ' Call the function to get the record count from the database
        Dim recordCount As Integer = GetRecordCount()


        Dim voucher_hdr As DataTable = DisplayHeader()
        totalRowCount = voucher_hdr.Rows.Count

        txtVoucherdate.Text = voucher_hdr.Rows(0)("cvdate")
        txtVoucherno.Text = voucher_hdr.Rows(0)("cvno")
        txtPayee.Text = voucher_hdr.Rows(0)("payee")
        txtParticular.Text = voucher_hdr.Rows(0)("particular")
        txtCheckno.Text = voucher_hdr.Rows(0)("checkno")
        txtCheckdate.Text = voucher_hdr.Rows(0)("checkdate")
        txtAmount.Text = voucher_hdr.Rows(0)("amount")
        LTransno = voucher_hdr.Rows(0)("transno")

        ' Update the label's text with the record count
        lblRecs.Text = (currentRowIndex + 1).ToString() & "/" & totalRowCount.ToString()


        ' Query to fetch the data from the database

        Dim query As String = "SELECT a.acctno AS [CODE#], a.acctname AS [DESCRIPTION], a.amount AS [AMOUNT], a.refid, 
                               CASE WHEN b.tugboat IS NULL THEN '   ' ELSE b.tugboat END as tugboat, 
                               CASE WHEN c.number IS NULL THEN '   ' ELSE c.number END as number, 
                               CASE WHEN c.name IS NULL THEN SPACE(35) ELSE c.name END AS [TUGBOAT], 
                               a.transno, a.recid
                            FROM voucher_dtl AS a 
                            LEFT JOIN repair_dtl AS b ON a.transno = b.transno AND a.refid = b.recid
                            LEFT JOIN tugboat AS c ON b.tugboat = c.number
                            WHERE a.transno = @tTransno"
        Dim cmd As SqlCommand = New SqlCommand(query, LoginForm.Sqlconnection)
        cmd.Parameters.AddWithValue("@tTransno", LTransno)
        Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim curdetails As DataTable = New DataTable()
        sda.Fill(curdetails)

        DataGridView1.Columns.Add("CODE#", "CODE#")
        DataGridView1.Columns("CODE#").DataPropertyName = "CODE#"
        DataGridView1.Columns("CODE#").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        DataGridView1.Columns.Add("DESCRIPTION", "DESCRIPTION")
        DataGridView1.Columns("DESCRIPTION").DataPropertyName = "DESCRIPTION"
        DataGridView1.Columns("DESCRIPTION").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DataGridView1.Columns.Add("AMOUNT", "AMOUNT")
        DataGridView1.Columns("AMOUNT").DataPropertyName = "AMOUNT"
        DataGridView1.Columns("AMOUNT").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        DataGridView1.Columns.Add("TUGBOAT1", "TUGBOAT")
        DataGridView1.Columns("TUGBOAT1").DataPropertyName = "TUGBOAT1"
        DataGridView1.Columns("TUGBOAT1").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        DataGridView1.Columns.Add("refid", "refid")
        DataGridView1.Columns("refid").DataPropertyName = "refid"

        DataGridView1.Columns.Add("tugboat", "tugboat")
        DataGridView1.Columns("tugboat").DataPropertyName = "tugboat"

        DataGridView1.Columns.Add("number", "number")
        DataGridView1.Columns("number").DataPropertyName = "number"

        DataGridView1.Columns.Add("transno", "transno")
        DataGridView1.Columns("transno").DataPropertyName = "transno"

        DataGridView1.Columns.Add("recid", "recid")
        DataGridView1.Columns("recid").DataPropertyName = "recid"


        DataGridView1.Columns("number").Visible = False
        DataGridView1.Columns("refid").Visible = False
        DataGridView1.Columns("tugboat").Visible = False
        DataGridView1.Columns("transno").Visible = False
        DataGridView1.Columns("recid").Visible = False


        DataGridView1.DataSource = curdetails

        Dim currentDate As DateTime = DateTime.Now
        txtDate.Text = currentDate.ToString("M/d/yyyy")
        cboTugboat.SelectedIndex = 0
        'Try

        '    ' SQL query to fetch data from a table, adjust this query based on your needs
        '    Dim query1 As String = "SELECT * FROM tugboat"
        '    Dim command As New SqlCommand(query1, LoginForm.Sqlconnection)

        '    ' Execute the query and read data into a SqlDataReader
        '    Dim reader As SqlDataReader = command.ExecuteReader()

        '    ' Clear the existing items in the ComboBox
        '    cboTugboat.Items.Clear()

        '    ' Loop through the data and add it to the ComboBox
        '    While reader.Read()
        '        cboTugboat.Items.Add(reader("number").ToString())
        '    End While

        '    ' Close the reader and connection
        '    reader.Close()

        'Catch ex As Exception
        '    MessageBox.Show("Error: " & ex.Message)
        '    LoginForm.Sqlconnection.Close()
        'End Try

        LoginForm.Sqlconnection.Close()

    End Sub

    Private Function GetTugboatName(tugboatNumber As String) As String
        Dim tugboatName As String = String.Empty

        ' Establish connection to SQL Server
        Try

            ' SQL query to fetch the tugboat name based on the selected tugboat number
            Dim query As String = "SELECT name FROM tugboat WHERE number = @tugboatNumber"
            Dim command As New SqlCommand(query, LoginForm.Sqlconnection)
            command.Parameters.AddWithValue("@tugboatNumber", tugboatNumber)

            ' Execute the query and read the data
            Dim result As Object = command.ExecuteScalar()

            ' Check if the result is not null and convert it to a string
            If result IsNot Nothing Then
                tugboatName = result.ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "MIS DEPARTMENT", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        End Try


        Return tugboatName
    End Function

    Private Function DisplayHeader() As DataTable

        Dim voucher_hdr As New DataTable()

        ' Query to fetch the data from the database
        Dim query As String = "SELECT * FROM voucher_hdr ORDER by recid"

        Using command As New SqlCommand(query, LoginForm.Sqlconnection)
            Try
                Dim reader As SqlDataReader = command.ExecuteReader()
                voucher_hdr.Load(reader)

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "MIS DEPARTMENT", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            End Try
        End Using

        Return voucher_hdr
    End Function

    Private Sub btnTop_Click(sender As Object, e As EventArgs) Handles btnTop.Click
        LoginForm.Sqlconnection.Open()
        Dim voucher_hdr As DataTable = DisplayHeader()
        totalRowCount = voucher_hdr.Rows.Count

        txtVoucherdate.Text = voucher_hdr.Rows(0)("cvdate")
        txtVoucherno.Text = voucher_hdr.Rows(0)("cvno")
        txtPayee.Text = voucher_hdr.Rows(0)("payee")
        txtParticular.Text = voucher_hdr.Rows(0)("particular")
        txtCheckno.Text = voucher_hdr.Rows(0)("checkno")
        txtCheckdate.Text = voucher_hdr.Rows(0)("checkdate")
        txtAmount.Text = voucher_hdr.Rows(0)("amount")
        LTransno = voucher_hdr.Rows(0)("transno")

        currentRowIndex = 0

        ' Update the label's text with the record count
        lblRecs.Text = (currentRowIndex + 1).ToString() & "/" & totalRowCount.ToString()

        Dim query As String = "SELECT a.acctno AS [CODE#], a.acctname AS [DESCRIPTION], a.amount AS [AMOUNT], a.refid, 
                               CASE WHEN b.tugboat IS NULL THEN '   ' ELSE b.tugboat END as tugboat, 
                               CASE WHEN c.number IS NULL THEN '   ' ELSE c.number END as number, 
                               CASE WHEN c.name IS NULL THEN SPACE(35) ELSE c.name END AS [TUGBOAT], 
                               a.transno, a.recid
                            FROM voucher_dtl AS a 
                            LEFT JOIN repair_dtl AS b ON a.transno = b.transno AND a.refid = b.recid
                            LEFT JOIN tugboat AS c ON b.tugboat = c.number
                            WHERE a.transno = @tTransno"
        Dim cmd As SqlCommand = New SqlCommand(query, LoginForm.Sqlconnection)
        cmd.Parameters.AddWithValue("@tTransno", LTransno)
        Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim curdetails As DataTable = New DataTable()
        sda.Fill(curdetails)

        DataGridView1.DataSource = curdetails


        txtRef.Text = ""
        txtSupplier.Text = ""
        txtParticulars.Text = ""
        txtRemarks.Text = ""

        Dim currentDate As DateTime = DateTime.Now
        txtDate.Text = currentDate.ToString("M/d/yyyy")
        cboTugboat.SelectedIndex = 0

        LoginForm.Sqlconnection.Close()
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click


        LoginForm.Sqlconnection.Open()
        Dim voucher_hdr As DataTable = DisplayHeader()

        If voucher_hdr.Rows.Count > 0 Then
            Dim lastrow As DataRow = voucher_hdr.Rows(voucher_hdr.Rows.Count - 1)

            txtVoucherdate.Text = lastrow("cvdate")
            txtVoucherno.Text = lastrow("cvno")
            txtPayee.Text = lastrow("payee")
            txtParticular.Text = lastrow("particular")
            txtCheckno.Text = lastrow("checkno")
            txtCheckdate.Text = lastrow("checkdate")
            txtAmount.Text = lastrow("amount")
            LTransno = lastrow("transno")

            ' Update the currentRowIndex to indicate the last row (zero-based index)
            currentRowIndex = voucher_hdr.Rows.Count - 1

            'Update the record count label with the current position and the total number of rows
            lblRecs.Text = (currentRowIndex + 1).ToString() & "/" & voucher_hdr.Rows.Count.ToString()

            Dim query As String = "SELECT a.acctno AS [CODE#], a.acctname AS [DESCRIPTION], a.amount AS [AMOUNT], a.refid, 
                               CASE WHEN b.tugboat IS NULL THEN '   ' ELSE b.tugboat END as tugboat, 
                               CASE WHEN c.number IS NULL THEN '   ' ELSE c.number END as number, 
                               CASE WHEN c.name IS NULL THEN SPACE(35) ELSE c.name END AS [TUGBOAT], 
                               a.transno, a.recid
                                FROM voucher_dtl AS a 
                                LEFT JOIN repair_dtl AS b ON a.transno = b.transno AND a.refid = b.recid
                                LEFT JOIN tugboat AS c ON b.tugboat = c.number
                                WHERE a.transno = @tTransno;
"
            Dim cmd As SqlCommand = New SqlCommand(query, LoginForm.Sqlconnection)
            cmd.Parameters.AddWithValue("@tTransno", LTransno)
            Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim curdetails As DataTable = New DataTable()
            sda.Fill(curdetails)

            DataGridView1.DataSource = curdetails

            Dim currentDate As DateTime = DateTime.Now
            txtDate.Text = currentDate.ToString("M/d/yyyy")
            cboTugboat.SelectedIndex = 0

            txtRef.Text = ""
            txtSupplier.Text = ""
            txtParticulars.Text = ""
            txtRemarks.Text = ""

        End If



        LoginForm.Sqlconnection.Close()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        LoginForm.Sqlconnection.Open()
        currentRowIndex += 1

        Dim voucher_hdr As DataTable = DisplayHeader()
        totalRowCount = voucher_hdr.Rows.Count
        If currentRowIndex > 0 AndAlso currentRowIndex < voucher_hdr.Rows.Count Then
            ' Retrieve the next row based on the current row index
            Dim nextRow As DataRow = voucher_hdr.Rows(currentRowIndex)

            ' Access the values in the next row
            txtVoucherdate.Text = nextRow("cvdate")
            txtVoucherno.Text = nextRow("cvno")
            txtPayee.Text = nextRow("payee")
            txtParticular.Text = nextRow("particular")
            txtCheckno.Text = nextRow("checkno")
            txtCheckdate.Text = nextRow("checkdate")
            txtAmount.Text = nextRow("amount")
            LTransno = nextRow("transno")

            ' Update the record count label with the current position and the total number of rows
            lblRecs.Text = (currentRowIndex + 1).ToString() & "/" & totalRowCount.ToString()

            Dim query As String = "SELECT a.acctno AS [CODE#], a.acctname AS [DESCRIPTION], a.amount AS [AMOUNT], a.refid, 
                               CASE WHEN b.tugboat IS NULL THEN '   ' ELSE b.tugboat END as tugboat, 
                               CASE WHEN c.number IS NULL THEN '   ' ELSE c.number END as number, 
                               CASE WHEN c.name IS NULL THEN SPACE(35) ELSE c.name END AS [TUGBOAT], 
                               a.transno, a.recid
                                FROM voucher_dtl AS a 
                                LEFT JOIN repair_dtl AS b ON a.transno = b.transno AND a.refid = b.recid
                                LEFT JOIN tugboat AS c ON b.tugboat = c.number
                                WHERE a.transno = @tTransno;
"
            Dim cmd As SqlCommand = New SqlCommand(query, LoginForm.Sqlconnection)
            cmd.Parameters.AddWithValue("@tTransno", LTransno)
            Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim curdetails As DataTable = New DataTable()
            sda.Fill(curdetails)

            DataGridView1.DataSource = curdetails

            Dim currentDate As DateTime = DateTime.Now
            txtDate.Text = currentDate.ToString("M/d/yyyy")
            cboTugboat.SelectedIndex = 0

            txtRef.Text = ""
            txtSupplier.Text = ""
            txtParticulars.Text = ""
            txtRemarks.Text = ""



            ' ...

            ' Perform any operations with the next row's values
            ' ...
        Else
            ' Display a message or perform any other action when there are no more rows
            MessageBox.Show("No more rows.")
        End If

        LoginForm.Sqlconnection.Close()
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        LoginForm.Sqlconnection.Open()
        currentRowIndex -= 1

        Dim voucher_hdr As DataTable = DisplayHeader()
        totalRowCount = voucher_hdr.Rows.Count

        ' Update the label's text with the record count
        lblRecs.Text = (currentRowIndex + 1).ToString() & "/" & totalRowCount.ToString()
        If currentRowIndex >= 0 AndAlso currentRowIndex < voucher_hdr.Rows.Count Then
            ' Retrieve the next row based on the current row index
            Dim prevRow As DataRow = voucher_hdr.Rows(currentRowIndex)

            ' Access the values in the next row
            txtVoucherdate.Text = prevRow("cvdate")
            txtVoucherno.Text = prevRow("cvno")
            txtPayee.Text = prevRow("payee")
            txtParticular.Text = prevRow("particular")
            txtCheckno.Text = prevRow("checkno")
            txtCheckdate.Text = prevRow("checkdate")
            txtAmount.Text = prevRow("amount")
            LTransno = prevRow("transno")


            Dim query As String = "SELECT a.acctno AS [CODE#], a.acctname AS [DESCRIPTION], a.amount AS [AMOUNT], a.refid, 
                               CASE WHEN b.tugboat IS NULL THEN '   ' ELSE b.tugboat END as tugboat, 
                               CASE WHEN c.number IS NULL THEN '   ' ELSE c.number END as number, 
                               CASE WHEN c.name IS NULL THEN SPACE(35) ELSE c.name END AS [TUGBOAT], 
                               a.transno, a.recid
                                FROM voucher_dtl AS a 
                                LEFT JOIN repair_dtl AS b ON a.transno = b.transno AND a.refid = b.recid
                                LEFT JOIN tugboat AS c ON b.tugboat = c.number
                                WHERE a.transno = @tTransno;
"
            Dim cmd As SqlCommand = New SqlCommand(query, LoginForm.Sqlconnection)
            cmd.Parameters.AddWithValue("@tTransno", LTransno)
            Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim curdetails As DataTable = New DataTable()
            sda.Fill(curdetails)

            DataGridView1.DataSource = curdetails

            Dim currentDate As DateTime = DateTime.Now
            txtDate.Text = currentDate.ToString("M/d/yyyy")
            cboTugboat.SelectedIndex = 0

            cboTugboat.Text = ""
            txtTugboatname.Text = ""
            txtRef.Text = ""
            txtSupplier.Text = ""
            txtParticulars.Text = ""
            txtRemarks.Text = ""


        End If

        LoginForm.Sqlconnection.Close()


    End Sub

    Private Function GetLatestRecid(transno As String) As String
        Dim latestRecid As String = ""

        ' Query to fetch the maximum recid for the given transno
        Dim query As String = "SELECT MAX(recid) FROM repair_dtl WHERE transno = @transno"

        Try
            Using command As New SqlCommand(query, LoginForm.Sqlconnection)
                command.Parameters.AddWithValue("@transno", transno)
                Dim result As Object = command.ExecuteScalar()

                If result IsNot Nothing AndAlso Not Convert.IsDBNull(result) Then
                    latestRecid = result.ToString()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "MIS DEPARTMENT", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        End Try

        Return latestRecid
    End Function


    Private Function DisplayRepairDetails(ByVal transno As String, refid As String) As DataTable
        Dim repair_dtl As New DataTable()

        ' Query to fetch the data from the database
        Dim query As String = "SELECT * FROM repair_dtl WHERE transno = @transno AND recid = @refid"

        Using command As New SqlCommand(query, LoginForm.Sqlconnection)
            command.Parameters.AddWithValue("@transno", transno)
            command.Parameters.AddWithValue("@refid", refid)
            Try
                Dim reader As SqlDataReader = command.ExecuteReader()
                repair_dtl.Load(reader)

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "MIS DEPARTMENT", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            End Try
        End Using

        Return repair_dtl
    End Function


    Private Sub cboTugboat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTugboat.SelectedIndexChanged


        If cboTugboat.SelectedItem = 1 Then
            txtTugboatname.Text = "AMATA MARU"
        End If
        If cboTugboat.SelectedItem = 2 Then
            txtTugboatname.Text = "M/T BOHOL SEA"
        End If
        If cboTugboat.SelectedItem = 3 Then
            txtTugboatname.Text = "M/T CEBU STRAIT"
        End If
        If cboTugboat.SelectedItem = 4 Then
            txtTugboatname.Text = "LAKANDULA"
        End If
        If cboTugboat.SelectedItem = 5 Then
            txtTugboatname.Text = "M/T TABANGAO"
        End If

        'If cboTugboat.SelectedIndex <> -1 Then

        '    Dim selectedTugboatNumber As String = cboTugboat.SelectedItem.ToString()

        '    ' Fetch the corresponding tugboat name based on the selected tugboat number
        '    Dim tugboatName As String = GetTugboatName(selectedTugboatNumber)

        '    ' Display the retrieved tugboat name in the txtName TextBox
        '    txtTugboatname.Text = tugboatName
        'End If



    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(txtDate.Text) Then
            MessageBox.Show("Please enter date.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDate.Focus()
            Return
        End If
        If String.IsNullOrEmpty(txtTugboatname.Text) Then
            MessageBox.Show("Please choose tugboat name.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboTugboat.Focus()
            Return
        End If
        If String.IsNullOrEmpty(txtRef.Text) Then
            MessageBox.Show("Please enter reference number.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRef.Focus()
            Return
        End If

        If String.IsNullOrEmpty(txtSupplier.Text) Then
            MessageBox.Show("Please enter supplier name.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtSupplier.Focus()
            Return
        End If
        If String.IsNullOrEmpty(txtParticulars.Text) Then
            MessageBox.Show("Please enter particulars.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtParticulars.Focus()
            Return
        End If

        If String.IsNullOrEmpty(txtRemarks.Text) Then
            MessageBox.Show("Please enter remarks.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtRemarks.Focus()
            Return
        End If

        If MessageBox.Show("Are all entries correct?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If




        Try
            LoginForm.Sqlconnection.Open()

            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            ' Extract the data from the selected row
            Dim acctno As String = selectedRow.Cells("CODE#").Value.ToString()


            ' Query to insert data into the database
            Dim query As String = "INSERT INTO repair_dtl (transno, tugboat, date, reference, supplier, particular, remarks, createdby, createddate) VALUES (@tTransno, @tugboat, @date, @reference, @supplier, @particular, @remarks, @createdby, @createddate)"

            Using command As New SqlCommand(query, LoginForm.Sqlconnection)
                command.Parameters.AddWithValue("@tTransno", LTransno)
                command.Parameters.AddWithValue("@tugboat", cboTugboat.Text)
                command.Parameters.AddWithValue("@date", txtDate.Text)
                command.Parameters.AddWithValue("@reference", txtRef.Text)
                command.Parameters.AddWithValue("@supplier", txtSupplier.Text)
                command.Parameters.AddWithValue("@particular", txtParticulars.Text)
                command.Parameters.AddWithValue("@remarks", txtRemarks.Text)
                command.Parameters.AddWithValue("@createdby", username)
                command.Parameters.AddWithValue("@createddate", DateTime.Now)


                command.ExecuteNonQuery()
            End Using

            Dim transno As String = LTransno
            Dim iRecid As String = GetLatestRecid(transno)

            ' Update the database with the latest recid
            Dim query2 As String = "UPDATE voucher_dtl SET refid = @iRecid WHERE acctno = @acctno AND transno = @transno"

            Using command2 As New SqlCommand(query2, LoginForm.Sqlconnection)
                command2.Parameters.AddWithValue("@iRecid", iRecid)
                command2.Parameters.AddWithValue("@acctno", acctno)
                command2.Parameters.AddWithValue("@transno", transno)

                command2.ExecuteNonQuery()
            End Using

            Dim query4 As String = "INSERT INTO atrail (userid, computer, date, source, activity, [file], record_id, remarks) 
                                                    VALUES (@userid, @computer, @date, 'DataEntry Form', 'New repair detail', 'DataEntry', @recid, @remarks)"

            Using command3 As New SqlCommand(query4, LoginForm.Sqlconnection)
                ' Add parameters for the query
                command3.Parameters.AddWithValue("@userid", username)
                command3.Parameters.AddWithValue("@computer", Environment.UserName)
                command3.Parameters.AddWithValue("@date", DateTime.Now)
                command3.Parameters.AddWithValue("@recid", iRecid) ' Assuming recid is a variable storing the record ID
                command3.Parameters.AddWithValue("@remarks", "New repair record tugboat#" & cboTugboat.Text) ' Assuming you want to insert the text with the selected tugboat value

                command3.ExecuteNonQuery()
            End Using

            'cboTugboat.Text = ""
            'txtTugboatname.Text = ""
            'txtRef.Text = ""
            'txtSupplier.Text = ""
            'txtParticulars.Text = ""
            'txtRemarks.Text = ""

            Dim query3 As String = "SELECT a.acctno AS [CODE#], a.acctname AS [DESCRIPTION], a.amount AS [AMOUNT], a.refid, 
                               CASE WHEN b.tugboat IS NULL THEN '   ' ELSE b.tugboat END as tugboat, 
                               CASE WHEN c.number IS NULL THEN '   ' ELSE c.number END as number, 
                               CASE WHEN c.name IS NULL THEN SPACE(35) ELSE c.name END AS [TUGBOAT], 
                               a.transno, a.recid
                            FROM voucher_dtl AS a 
                            LEFT JOIN repair_dtl AS b ON a.transno = b.transno AND a.refid = b.recid
                            LEFT JOIN tugboat AS c ON b.tugboat = c.number
                            WHERE a.transno = @tTransno"
            Dim cmd As SqlCommand = New SqlCommand(query3, LoginForm.Sqlconnection)
            cmd.Parameters.AddWithValue("@tTransno", LTransno)
            Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim curdetails As DataTable = New DataTable()
            sda.Fill(curdetails)
            DataGridView1.DataSource = curdetails



            ' Show success message box and refresh designated forms
            Dim result As DialogResult = MessageBox.Show("Data successfully recorded.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If result = DialogResult.OK Then
                Me.Refresh()
            End If

        Catch ex As Exception
            MessageBox.Show("Saving the data is not successful please put valid data and check the entries.", "MIS DEPARTMENT", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            LoginForm.Sqlconnection.Close()
        End Try


    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            LoginForm.Sqlconnection.Open()

            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            ' Extract the data from the selected row
            Dim recid As String = selectedRow.Cells("refid").Value.ToString()

            ' Query to delete data from the database
            Dim query As String = "DELETE FROM repair_dtl WHERE transno = @transno AND recid = @recid "

            Using command As New SqlCommand(query, LoginForm.Sqlconnection)
                command.Parameters.AddWithValue("@transno", LTransno)
                command.Parameters.AddWithValue("@recid", recid)
                command.ExecuteNonQuery()
            End Using

            If MessageBox.Show("Are you sure to delete this entry?", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return
            End If

            Dim query4 As String = "INSERT INTO atrail (userid, computer, date, source, activity, [file], record_id, remarks) 
                                                    VALUES (@userid, @computer, @date, 'DataEntry Form', 'Delete repair detail', 'DataEntry', @recid, @remarks)"

            Using command3 As New SqlCommand(query4, LoginForm.Sqlconnection)
                ' Add parameters for the query
                command3.Parameters.AddWithValue("@userid", username)
                command3.Parameters.AddWithValue("@computer", Environment.UserName)
                command3.Parameters.AddWithValue("@date", DateTime.Now)
                command3.Parameters.AddWithValue("@recid", iRecid) ' Assuming recid is a variable storing the record ID
                command3.Parameters.AddWithValue("@remarks", "Deleted repair record tugboat#" & cboTugboat.Text) ' Assuming you want to insert the text with the selected tugboat value

                command3.ExecuteNonQuery()
            End Using

            cboTugboat.Text = ""
            txtTugboatname.Text = ""
            txtRef.Text = ""
            txtSupplier.Text = ""
            txtParticulars.Text = ""
            txtRemarks.Text = ""

            ' Show success message box and refresh designated forms
            Dim result As DialogResult = MessageBox.Show("Data successfully deleted.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If result = DialogResult.OK Then
                Me.Refresh()
            End If

        Catch ex As Exception
            MessageBox.Show("Please choose the correct data", "MIS DEPARTMENT", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            LoginForm.Sqlconnection.Close()
        End Try

    End Sub



    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            If DataGridView1.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
                ' Retrieve the data from the selected row
                LoginForm.Sqlconnection.Open()
                Dim transno As String = selectedRow.Cells("transno").Value.ToString()
                Dim refid As String = selectedRow.Cells("refid").Value.ToString()
                Dim repair_dtl As DataTable = DisplayRepairDetails(transno, refid)
                ' Perform editing logic or open a new form for editing
                ' For example, you can display the selected values in a MessageBox

                Me.btnSave.Enabled = False

                txtDate.Text = repair_dtl.Rows(0)("date")
                cboTugboat.Text = repair_dtl.Rows(0)("tugboat")
                txtRef.Text = repair_dtl.Rows(0)("reference")
                txtSupplier.Text = repair_dtl.Rows(0)("supplier")
                txtParticulars.Text = repair_dtl.Rows(0)("particular")
                txtRemarks.Text = repair_dtl.Rows(0)("remarks")
                LoginForm.Sqlconnection.Close()
            End If
        Catch
            cboTugboat.Text = ""
            txtTugboatname.Text = ""
            txtRef.Text = ""
            txtSupplier.Text = ""
            txtParticulars.Text = ""
            txtRemarks.Text = ""
            LoginForm.Sqlconnection.Close()
            Me.btnSave.Enabled = True
        End Try


    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ' Check if a row is selected
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a row to update.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Check if the selected row has data in the required cells
        Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
        'If Not IsDBNull(selectedRow.Cells("date").Value) AndAlso Not IsDBNull(selectedRow.Cells("tugboat").Value) AndAlso Not IsDBNull(selectedRow.Cells("reference").Value) AndAlso Not IsDBNull(selectedRow.Cells("supplier").Value) AndAlso Not IsDBNull(selectedRow.Cells("particular").Value) AndAlso Not IsDBNull(selectedRow.Cells("remarks").Value) Then
        ' Retrieve the data from the selected row
        LoginForm.Sqlconnection.Open()
        Dim transno As String = selectedRow.Cells("transno").Value.ToString()
        Dim refid As String = selectedRow.Cells("refid").Value.ToString()

        ' Check if the record already exists in the database
        Dim repair_dtl As DataTable = DisplayRepairDetails(transno, refid)

        If repair_dtl.Rows.Count > 0 Then
            ' Perform the UPDATE operation
            Try


                ' Query to update data in the database
                Dim query As String = "UPDATE repair_dtl SET tugboat = @tugboat, date = @date, reference = @reference, supplier = @supplier, particular = @particular, remarks = @remarks, updatedby = @updatedby, updateddate = @updateddate WHERE transno = @transno AND recid = @refid"

                Using command As New SqlCommand(query, LoginForm.Sqlconnection)
                    command.Parameters.AddWithValue("@tugboat", cboTugboat.Text)
                    command.Parameters.AddWithValue("@date", txtDate.Text)
                    command.Parameters.AddWithValue("@reference", txtRef.Text)
                    command.Parameters.AddWithValue("@supplier", txtSupplier.Text)
                    command.Parameters.AddWithValue("@particular", txtParticulars.Text)
                    command.Parameters.AddWithValue("@remarks", txtRemarks.Text)
                    command.Parameters.AddWithValue("@transno", transno)
                    command.Parameters.AddWithValue("@refid", refid)
                    command.Parameters.AddWithValue("@updatedby", username)
                    command.Parameters.AddWithValue("@updateddate", DateTime.Now)

                    command.ExecuteNonQuery()
                End Using

                Dim query2 As String = "INSERT INTO atrail (userid, computer, date, source, activity, [file], record_id, remarks) 
                                                    VALUES (@userid, @computer, @date, 'DataEntry Form', 'Update repair detail', 'DataEntry', @recid, @remarks)"

                Using command2 As New SqlCommand(query2, LoginForm.Sqlconnection)
                    ' Add parameters for the query
                    command2.Parameters.AddWithValue("@userid", username)
                    command2.Parameters.AddWithValue("@computer", Environment.UserName)
                    command2.Parameters.AddWithValue("@date", DateTime.Now)
                    command2.Parameters.AddWithValue("@recid", refid) ' Assuming recid is a variable storing the record ID
                    command2.Parameters.AddWithValue("@remarks", "Updated repair record tugboat#" & cboTugboat.Text) ' Assuming you want to insert the text with the selected tugboat value

                    command2.ExecuteNonQuery()
                End Using

                Dim query3 As String = "SELECT a.acctno AS [CODE#], a.acctname AS [DESCRIPTION], a.amount AS [AMOUNT], a.refid, 
                               CASE WHEN b.tugboat IS NULL THEN '   ' ELSE b.tugboat END as tugboat, 
                               CASE WHEN c.number IS NULL THEN '   ' ELSE c.number END as number, 
                               CASE WHEN c.name IS NULL THEN SPACE(35) ELSE c.name END AS [TUGBOAT], 
                               a.transno, a.recid
                            FROM voucher_dtl AS a 
                            LEFT JOIN repair_dtl AS b ON a.transno = b.transno AND a.refid = b.recid
                            LEFT JOIN tugboat AS c ON b.tugboat = c.number
                            WHERE a.transno = @tTransno"
                Dim cmd As SqlCommand = New SqlCommand(query3, LoginForm.Sqlconnection)
                cmd.Parameters.AddWithValue("@tTransno", LTransno)
                Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                Dim curdetails As DataTable = New DataTable()
                sda.Fill(curdetails)


                ' Show success message box and refresh designated forms
                Dim result As DialogResult = MessageBox.Show("Data successfully updated.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If result = DialogResult.OK Then
                    ' Optional: Refresh the DataGridView to reflect the updated data
                    DataGridView1.DataSource = curdetails
                End If

            Catch ex As Exception
                MessageBox.Show("Please choose the valid data to update.", "MIS DEPARTMENT", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            Finally
                LoginForm.Sqlconnection.Close()
            End Try
        Else
            ' The record does not exist, show an error message or handle as needed
            MessageBox.Show("Record not found in the database.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        'Else
        '    ' If the selected row has no data, show an error message or handle as needed
        '    MessageBox.Show("Selected row does not contain complete data.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If
    End Sub

    Private Sub txtDate_Validating(sender As Object, e As CancelEventArgs) Handles txtDate.Validating
        Dim inputDate As String = txtDate.Text.Trim()
        Dim parsedDate As DateTime

        If Not DateTime.TryParseExact(inputDate, "M/d/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, parsedDate) Then
            ' Invalid date format entered by the user
            MessageBox.Show("Please enter a valid date in the format e.g 07/22/2023.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True ' This will prevent the focus from leaving the textbox until a valid date is entered
        Else
            ' The date is valid, update the textbox with the formatted date
            txtDate.Text = parsedDate.ToString("M/d/yyyy")
        End If
    End Sub

    Private Sub txtDate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDate.KeyPress
        ' Check if the entered key is a digit or a slash (for date format)
        If (Not Char.IsDigit(e.KeyChar)) AndAlso (e.KeyChar <> "/"c) AndAlso (Not Char.IsControl(e.KeyChar)) Then
            e.Handled = True ' Ignore the key press event (do not allow non-numeric/non-date characters)
        End If
    End Sub


    Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles Panel1.Click
        Dim searchKeyword As String = txtSearch.Text.Trim()
        If String.IsNullOrEmpty(searchKeyword) Then
            MessageBox.Show("Please enter a search keyword.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            LoginForm.Sqlconnection.Open()

            ' Prepare and execute the SQL query
            Dim query As String = "SELECT * FROM voucher_hdr WHERE cvno LIKE '%' + @searchKeyword + '%'"
            Using command As New SqlCommand(query, LoginForm.Sqlconnection)
                command.Parameters.AddWithValue("@searchKeyword", searchKeyword)

                Dim adapter As New SqlDataAdapter(command)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                ' Display the search results in DataGridView1


                txtVoucherdate.Text = dt.Rows(0)("cvdate")
                txtVoucherno.Text = dt.Rows(0)("cvno")
                txtPayee.Text = dt.Rows(0)("payee")
                txtParticular.Text = dt.Rows(0)("particular")
                txtCheckno.Text = dt.Rows(0)("checkno")
                txtCheckdate.Text = dt.Rows(0)("checkdate")
                txtAmount.Text = dt.Rows(0)("amount")
                LTransno = dt.Rows(0)("transno")


            End Using

            Dim query2 As String = "SELECT a.acctno AS [CODE#], a.acctname AS [DESCRIPTION], a.amount AS [AMOUNT], a.refid, 
                               CASE WHEN b.tugboat IS NULL THEN '   ' ELSE b.tugboat END as tugboat, 
                               CASE WHEN c.number IS NULL THEN '   ' ELSE c.number END as number, 
                               CASE WHEN c.name IS NULL THEN SPACE(35) ELSE c.name END AS [TUGBOAT], 
                               a.transno, a.recid
                            FROM voucher_dtl AS a 
                            LEFT JOIN repair_dtl AS b ON a.transno = b.transno AND a.refid = b.recid
                            LEFT JOIN tugboat AS c ON b.tugboat = c.number
                            WHERE a.transno = @tTransno"
            Dim cmd As SqlCommand = New SqlCommand(query2, LoginForm.Sqlconnection)
            cmd.Parameters.AddWithValue("@tTransno", LTransno)
            Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim curdetails As DataTable = New DataTable()
            sda.Fill(curdetails)

            DataGridView1.DataSource = curdetails

        Catch ex As Exception
            MessageBox.Show("The voucher number you input is invalid", "MIS DEPARTMENT", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            LoginForm.Sqlconnection.Close()
        End Try
    End Sub

    Private Sub DataEntry_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        DataGridView1.DataSource = curdetails
        DataGridView1.Refresh()
        Me.Refresh()
        MainForm.Show()
    End Sub

    Private Function GetRecordCount() As Integer
        Dim count As Integer = 0

        ' Replace "YourConnectionString" with the actual connection string to your database

        ' Create a SQL query to get the count of records in the voucher_hdr table
        Dim sql As String = "SELECT COUNT(*) FROM voucher_hdr"

        Using command As New SqlCommand(sql, LoginForm.Sqlconnection)
            ' Execute the query and get the result
            count = Convert.ToInt32(command.ExecuteScalar())
        End Using


        Return count
    End Function

End Class




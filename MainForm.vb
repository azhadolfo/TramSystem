Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows
Imports System.Data.SqlClient
Imports System.Text

Public Class MainForm

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles btnGetData.Click
        If allowGetdata Then
            '----------------------- FoxPro Connection ---------------------'
            'Dim connectionString As String = "Provider=VFPOLEDB; Data Source=C:\Users\FILPRIDE\source\repos\vbcrud\"
            '------------------------End of Connection ----------------------'
            Try

                Dim applicationPath As String = "\\192.168.0.251\public_trams\trams.exe" ' Replace with the path to your application
                Dim workingDirectory As String = "\\192.168.0.251\public_trams" ' Replace with the desired working directory path

                ' Disable or lock the user interface elements
                btnGetData.Enabled = False ' Disable the button
                btnDataEntry.Enabled = False ' Disable the button
                btnFile.Enabled = False ' Disable the button
                btnClose.Enabled = False ' Disable the button
                btnUsers.Enabled = False ' Disable the button

                ' Set the working directory
                Environment.CurrentDirectory = workingDirectory

                ' Start the application
                Dim process As Process = Process.Start(applicationPath)

                ' Wait for the application to exit
                process.WaitForExit()

                ' Enable the user interface elements after the application has finished
                btnGetData.Enabled = True ' Disable the button
                btnDataEntry.Enabled = True ' Disable the button
                btnFile.Enabled = True ' Disable the button
                btnClose.Enabled = True ' Disable the button
                btnUsers.Enabled = True ' Disable the button

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "CONTACT MIS DEPARTMENT")
                LoginForm.Sqlconnection.Close()
            End Try

            'Dim connetionString As String
            'Dim cnn As OleDbConnection
            'connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=C:\Users\FILPRIDE\source\repos\vbcrud;Extended Properties=dBase IV"
            'cnn = New OleDbConnection(connetionString)
            'Try
            '    cnn.Open()
            '    MsgBox("Connection Open ! ")
            '    cnn.Close()
            'Catch ex As Exception
            '    MsgBox("Can not open connection ! ")
            'End Try
        Else
            MessageBox.Show("You have no access in this module.", "MIS DEPARTMENT", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        StartForm.Close()
    End Sub

    Private Sub btnDataEntry_Click(sender As Object, e As EventArgs) Handles btnDataEntry.Click
        If allowEdit Then
            MessageBox.Show("Please wait to process and validate the data you get.", "MIS DEPARTMENT", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Try
                LoginForm.Vfpconnection.Open()
                LoginForm.Sqlconnection.Open()

                'Retrieve Data from voucher header table into curvoucher_hdr DataTable
                Dim voucherHdr_cmd As New OleDbCommand("Select * From voucher_hdr", LoginForm.Vfpconnection)
                Dim voucherHdr_reader As OleDbDataReader = voucherHdr_cmd.ExecuteReader()
                voucherHdr_cmd.CommandTimeout = 60 ' Set the timeout value in seconds
                Dim curvoucher_hdr As New DataTable()
                curvoucher_hdr.Load(voucherHdr_reader)

                'Retrieve Data from voucher detail table into voucher_dtl DataTable
                Dim voucherDtl_cmd As New OleDbCommand("Select * From voucher_dtl", LoginForm.Vfpconnection)
                Dim voucherDtl_reader As OleDbDataReader = voucherDtl_cmd.ExecuteReader()
                voucherDtl_cmd.CommandTimeout = 60 ' Set the timeout value in seconds
                Dim curvoucher_dtl As New DataTable()
                curvoucher_dtl.Load(voucherDtl_reader)

                'Retrieve Data from xvoucher header table into xvoucher DataTable
                Dim xvoucherHdr_cmd As New OleDbCommand("Select * From xvoucher_hdr", LoginForm.Vfpconnection)
                Dim xvoucherHdr_reader As OleDbDataReader = xvoucherHdr_cmd.ExecuteReader()
                xvoucherHdr_cmd.CommandTimeout = 60 ' Set the timeout value in seconds
                Dim curxvoucher_hdr As New DataTable()
                curxvoucher_hdr.Load(xvoucherHdr_reader)

                'Retrieve Data from xvoucher detail table into xvoucher_dtl DataTable
                Dim xvoucherDtl_cmd As New OleDbCommand("Select * From xvoucher_dtl", LoginForm.Vfpconnection)
                Dim xvoucherDtl_reader As OleDbDataReader = xvoucherDtl_cmd.ExecuteReader()
                xvoucherDtl_cmd.CommandTimeout = 60 ' Set the timeout value in seconds
                Dim curxvoucher_dtl As New DataTable()
                curxvoucher_dtl.Load(xvoucherDtl_reader)

                'Dim tugboat_cmd As New OleDbCommand("Select * From tugboat", LoginForm.Vfpconnection)
                'Dim tugboat_reader As OleDbDataReader = tugboat_cmd.ExecuteReader()
                'tugboat_cmd.CommandTimeout = 60 ' Set the timeout value in seconds
                'Dim tugboat As New DataTable()
                'tugboat.Load(tugboat_reader)

                ' Check if the destination table exists in SQL Server
                Dim tableExistsVheader As Boolean = CheckIfTableExists("voucher_hdr", LoginForm.Sqlconnection)
                Dim tableExistsVdetail As Boolean = CheckIfTableExists("voucher_dtl", LoginForm.Sqlconnection)
                Dim tableExistsxVheader As Boolean = CheckIfTableExists("xvoucher_hdr", LoginForm.Sqlconnection)
                Dim tableExistsxVdetail As Boolean = CheckIfTableExists("xvoucher_dtl", LoginForm.Sqlconnection)
                'Dim tableExistsTugboat As Boolean = CheckIfTableExists("tugboat", LoginForm.Sqlconnection)

                ' Create or replace the destination table in SQL Server
                If Not tableExistsVheader Then
                    CreateDestinationTable(curvoucher_hdr, "voucher_hdr", LoginForm.Sqlconnection)
                Else
                    DropDestinationTable("voucher_hdr", LoginForm.Sqlconnection)
                End If
                If tableExistsVdetail Then
                    If curvoucher_dtl.Rows.Count > 0 Then
                        Dim showMessage As Boolean = True
                        For Each row As DataRow In curvoucher_dtl.Rows
                            Dim refId As Integer = CInt(row("refid"))
                            Dim transno As String = row("transno").ToString()
                            Dim acctno As String = (row("acctno")).ToString()
                            Dim acctname As String = row("acctname").ToString()

                            Dim rowExists As Boolean = CheckIfRowExists(transno, acctno, acctname, "voucher_dtl", LoginForm.Sqlconnection)

                            If Not rowExists Then
                                ' Insert the data into the main table
                                Dim insertQuery As String = "INSERT INTO voucher_dtl (refid, transno, acctno, acctname, amount, downloadedby, downloadeddate) VALUES (@refId, @transno, @acctno, @acctname, @value3, @value4, @value5)"
                                Using command As New SqlCommand(insertQuery, LoginForm.Sqlconnection)
                                    command.Parameters.AddWithValue("@refId", refId)
                                    command.Parameters.AddWithValue("@transno", transno)
                                    command.Parameters.AddWithValue("@acctno", acctno)
                                    command.Parameters.AddWithValue("@acctname", acctname)
                                    command.Parameters.AddWithValue("@value3", row("amount"))
                                    command.Parameters.AddWithValue("@value4", row("downloadedby"))
                                    command.Parameters.AddWithValue("@value5", row("downloadeddate"))
                                    command.ExecuteNonQuery()
                                End Using
                            ElseIf showMessage Then
                                ' Update the data in the main table
                                MessageBox.Show("Some of the data you want to get is already uploaded in our database.", "MIS DEPARTMENT", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                showMessage = False
                            End If
                        Next
                    End If
                End If

                If Not tableExistsxVheader Then
                    CreateDestinationTable(curxvoucher_hdr, "xvoucher_hdr", LoginForm.Sqlconnection)
                Else
                    DropDestinationTable("xvoucher_hdr", LoginForm.Sqlconnection)
                End If
                If Not tableExistsxVdetail Then
                    CreateDestinationTable(curxvoucher_dtl, "xvoucher_dtl", LoginForm.Sqlconnection)
                Else
                    DropDestinationTable("xvoucher_dtl", LoginForm.Sqlconnection)
                End If
                'If Not tableExistsTugboat Then
                '    CreateDestinationTable(tugboat, "tugboat", LoginForm.Sqlconnection)
                'Else
                '    DropDestinationTable("tugboat", LoginForm.Sqlconnection)
                'End If



                'Use SqlBulkCopy to send sumpay DataTable to SQL Server
                Using bulkCopy As New SqlBulkCopy(LoginForm.Sqlconnection)
                    bulkCopy.DestinationTableName = "voucher_hdr"
                    MapColumns(curvoucher_hdr, bulkCopy)
                    bulkCopy.WriteToServer(curvoucher_hdr)
                End Using

                'Use SqlBulkCopy to send apledger DataTable to SQL Server
                'Using bulkCopy As New SqlBulkCopy(LoginForm.Sqlconnection)
                'bulkCopy.DestinationTableName = "voucher_dtl"
                'MapColumns(curvoucher_dtl, bulkCopy)
                '    bulkCopy.WriteToServer(curvoucher_dtl)
                'End Using

                ' Use SqlBulkCopy to send curchracct DataTable to SQL Server
                Using bulkCopy As New SqlBulkCopy(LoginForm.Sqlconnection)
                    bulkCopy.DestinationTableName = "xvoucher_hdr"
                    MapColumns(curxvoucher_hdr, bulkCopy)
                    bulkCopy.WriteToServer(curxvoucher_hdr)
                End Using

                Using bulkCopy As New SqlBulkCopy(LoginForm.Sqlconnection)
                    bulkCopy.DestinationTableName = "xvoucher_dtl"
                    MapColumns(curxvoucher_dtl, bulkCopy)
                    bulkCopy.WriteToServer(curxvoucher_dtl)
                End Using

                'Using bulkCopy As New SqlBulkCopy(LoginForm.Sqlconnection)
                '    bulkCopy.DestinationTableName = "tugboat"
                '    MapColumns(tugboat, bulkCopy)
                '    bulkCopy.WriteToServer(tugboat)
                'End Using






                ' Close the readers if they were opened
                voucherHdr_reader.Close()
                voucherDtl_reader.Close()
                xvoucherHdr_reader.Close()
                xvoucherDtl_reader.Close()
                'tugboat_reader.Close()











            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)

            Finally
                'Close the connection if it was opened
                If LoginForm.Sqlconnection.State = ConnectionState.Open Then
                    LoginForm.Sqlconnection.Close()
                End If

                If LoginForm.Vfpconnection.State = ConnectionState.Open Then
                    LoginForm.Vfpconnection.Close()
                End If
            End Try
            DataEntry.ShowDialog()
        Else
            MessageBox.Show("You have no access in this module.", "MIS DEPARTMENT", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Function CheckIfRowExists(transno As String, acctno As String, acctname As String, tableName As String, connection As SqlConnection) As Boolean
        Dim exists As Boolean = False
        Dim selectQuery As String = $"SELECT COUNT(*) FROM {tableName} WHERE transno = @transno AND acctno = @acctno AND acctname = @acctname"

        Using command As New SqlCommand(selectQuery, connection)
            command.Parameters.AddWithValue("@transno", transno)
            command.Parameters.AddWithValue("@acctno", acctno)
            command.Parameters.AddWithValue("@acctname", acctname)
            Dim count As Integer = CInt(command.ExecuteScalar())
            exists = (count > 0)
        End Using

        Return exists
    End Function



    Public Function GenerateCreateTableQuery(dataTable As DataTable, tableName As String) As String
        Dim sb As New StringBuilder()
        sb.AppendLine($"IF OBJECT_ID('{tableName}', 'U') IS NOT NULL")
        sb.AppendLine($"    DROP TABLE {tableName}")
        sb.AppendLine($"CREATE TABLE {tableName} (")

        For Each column As DataColumn In dataTable.Columns
            Dim columnName As String = column.ColumnName
            Dim columnType As String = "NVARCHAR(MAX)" ' Change to the appropriate default type
            sb.AppendLine($"[{columnName}] {columnType},")
        Next

        sb.Length -= 3 ' Remove the trailing comma and newline
        sb.AppendLine()
        sb.AppendLine(")")

        Return sb.ToString()
    End Function

    Private Function CheckIfTableExists(tableName As String, connection As SqlConnection) As Boolean
        Dim query As String = $"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}'"
        Using command As New SqlCommand(query, connection)
            Dim count As Integer = CInt(command.ExecuteScalar())
            Return count > 0
        End Using
    End Function

    Private Sub CreateDestinationTable(dataTable As DataTable, tableName As String, connection As SqlConnection)
        Dim createTableQuery As String = GenerateCreateTableQuery(dataTable, tableName)
        Using createTableCmd As New SqlCommand(createTableQuery, connection)
            createTableCmd.ExecuteNonQuery()
        End Using
    End Sub
    Private Sub MapColumns(dataTable As DataTable, bulkCopy As SqlBulkCopy)
        For Each column As DataColumn In dataTable.Columns
            bulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName)
        Next
    End Sub

    Private Function GetColumnType(dataType As Type) As String
        If dataType Is GetType(String) Then
            Return "NVARCHAR(MAX)"
        ElseIf dataType Is GetType(Integer) Then
            Return "INT"
        ElseIf dataType Is GetType(Decimal) Then
            Return "DECIMAL(18, 2)"
        ElseIf dataType Is GetType(Date) Then
            Return "DATE"
        ElseIf dataType Is GetType(DateTime) Then
            Return "DATETIME"
        Else
            ' Handle any other data types here '
            Return "NCHAR(MAX)"
        End If
    End Function
    Private Sub btnUsers_Click(sender As Object, e As EventArgs) Handles btnUsers.Click
        If allowUser Then
            Users.Show()
        Else
            MessageBox.Show("You have no access in this module.", "MIS DEPARTMENT", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub DropDestinationTable(tableName As String, connection As SqlConnection)
        Dim query As String = "DELETE FROM " + tableName
        Using command As New SqlCommand(query, connection)
            command.ExecuteNonQuery()
        End Using
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim connectionString As String = "Data Source=DESKTOP-LCC7IC5\SQLEXPRESS;Initial catalog=vb_crud;Integrated Security=True"

        ' Query to delete all records from the table
        Dim query As String = "DELETE FROM xvoucher_hdr"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    MessageBox.Show("All records deleted from the table.")
                Catch ex As Exception
                    ' Handle any exceptions here
                    MessageBox.Show("An error occurred: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnFile_Click(sender As Object, e As EventArgs) Handles btnFile.Click
        If allowReport Then
            ReportForm.ShowDialog()
        Else
            MessageBox.Show("You have no access in this module.", "MIS DEPARTMENT", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnTugBoat_Click(sender As Object, e As EventArgs) Handles btnTugBoat.Click
        If allowTugboat Then
            TugboatForm.ShowDialog()
        Else
            MessageBox.Show("You have no access in this module.", "MIS DEPARTMENT", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class

'----------------------LAST PAGE OF MY CODE ------------------------------